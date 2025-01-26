//using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBlog.help;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace MyBlog
{
	public delegate void PictureBoxClickedEventHandler(object sender, PictureBoxEventArgs e);
	public delegate void EditClickedEventHandler(object sender, EditEventArgs e);
	public partial class HomeForm : Form
	{
		public PictureBox[] Reacts = new PictureBox[6];

		public int CategorySearchId = -1;
		public User _user { get; }
		int current { set; get; } = 0;
		int numofpages { set; get; }
		Panel panel1 = new Panel();
		Panel panel2 = new Panel();
		MyBlogContext context = MyBlogContext.myBlogContext;
		public Button Home = new Button();
		public Button AdminView = new();
		public Button AddCategory = new();
		public Button ViewFollowers = new();
		public Button MyInteractions = new Button();
		public Button LogOut = new();
		public PictureBox Logo = new();
		public PictureBox Background = new();
		public int editingid = -1;
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
		public HomeForm(User user, int PostIdForEdit = -1)
		{
			//this.Controls.Add(panel1);
			//this.Controls.Add(panel2);
			InitializeComponent();
			_user = user;
			SetForm formsetter = new SetForm();
			Home = formsetter.Home;
			AdminView = formsetter.AdminView;
			AddCategory = formsetter.AddCategory;
			ViewFollowers = formsetter.ViewFollowers;
			LogOut = formsetter.LogOut;
			MyInteractions = formsetter.MyInteractions;
			//AddCategory = formsetter.AddCategory;
			Logo = formsetter.Logo;
			Background = formsetter.Background;
			this.Controls.Add(Home);
			this.Controls.Add(AdminView);
			if ((_user.Role & Role.Admin) != Role.Admin)
			{
				AdminView.BackColor = Color.Gray;
			}
			this.Controls.Add(AddCategory);
			this.Controls.Add(ViewFollowers);
			this.Controls.Add(AddCategory);
			this.Controls.Add(LogOut);
			this.Controls.Add(MyInteractions);
			Home.Click += HandleHomeButtonClick;
			AdminView.Click += HandleAdminViewButtonClick;
			AddCategory.Click += HandleAddCategoryButtonClick;
			ViewFollowers.Click += HandleViewFollowersButtonClick;
			LogOut.Click += HandleLogOutButtonClick;
			MyInteractions.Click += HandleMyInteractionsButtonClick;
			//this.Controls.Add(Logo);
			//this.Controls.Add(Background);
			MyInteractions.BringToFront();
			MyInteractions.Show();
			pictureBox1.SendToBack();
			if (PostIdForEdit != -1)
			{
				editingid = PostIdForEdit;
				var post = context.Posts.FirstOrDefault(p => p.Id == editingid);
				if (post?.Content is not null)
				{
					PostRichTextBox.Text = post.Content;
				}
				CategoryComboBox.SelectedValue = post.CategoryId;
				var pic = post.Picture;
				if (pic != null && user != null)
				{
					using (var ms = new MemoryStream(pic))
					{
						PostPhotoButton1.Image = Image.FromStream(ms);
						PostPhotoButton1.SizeMode = PictureBoxSizeMode.StretchImage;
					}
				}

			}
			linkLabel1.Hide();
			linkLabel1.LinkColor = Color.Black;
			linkLabel2.LinkColor = Color.Black;
			//Logo.BringToFront();
		}
		private void LoadPosts()
		{
			List<Post> FollowedPosts;
			if (CategorySearchId == -1)
			{
				var FollowedIds = context.Follows.Where(f => f.FollowerId == _user.Id).Select(f => f.FollowedId).ToList();
				numofpages = ((int)Math.Ceiling((context.Posts.Where(p => p.PublisherId == _user.Id
																	|| FollowedIds.Contains((int)p.PublisherId)).Count() / 2.0f)));

				FollowedPosts = (context.Posts.OrderByDescending(p => p.CreationDate).Where(p => p.PublisherId == _user.Id
										 || FollowedIds.Contains((int)p.PublisherId)).ToList());
			}
			else
			{

				numofpages = ((int)Math.Ceiling((context.Posts.Where(p => p.CategoryId == CategorySearchId).Count() / 2.0f)));
				FollowedPosts = (context.Posts.OrderByDescending(p => p.CreationDate).Where(p => p.CategoryId == CategorySearchId).ToList());
			}

			if (numofpages <= 1)
			{
				linkLabel2.Hide();
			}
			if (current <= numofpages - 2)
			{
				linkLabel2.Show();
			}
			//this.PostShow(_user.Id, context.Posts.FirstOrDefault(), 0, React_Click, Comments_Click, Delete_Click, Ediittt_Click);
			//var my2posts=FollowedPosts.Skip(current * 2).Take(2);
			panel1.Hide();
			panel2.Hide();
			if (FollowedPosts.Skip(current*2).ToList().Count != 0)
			{
				if (FollowedPosts.Skip(current * 2).FirstOrDefault() is not null)
				{
					Post pst = FollowedPosts.Skip(current * 2).FirstOrDefault();
					panel1 = this.PostShow(context, _user.Id, pst, 0, null, (s, e) => { }, (s, e) => { }, (s, e) => { });

					panel1.Show();
					panel1.BringToFront();
				}
				else
				{

					panel1.SendToBack();
					panel1.Hide();

				}
				if (FollowedPosts.Skip(current * 2 + 1).FirstOrDefault() is not null)
				{
					Post pst = FollowedPosts.Skip(current * 2 + 1).FirstOrDefault();

					panel2 = this.PostShow(context, _user.Id, pst, 1, null, (s, e) => { }, (s, e) => { }, (s, e) => { });

					panel2.Show();
					panel2.BringToFront();

					panel2.Show();
					panel2.BringToFront();
				}
				else
				{

					panel2.SendToBack();
					panel2.Hide();
				}
			}
			

		}
		private void HandleMyInteractionsButtonClick(object? sender, EventArgs e)
		{
			MyReactitonsForm form = new(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void HandleHomeButtonClick(object sender, EventArgs e)
		{

		}

		private void HandleAdminViewButtonClick(object sender, EventArgs e)
		{
			if (_user.Role >= Role.Admin)
			{
				Form3 form = new Form3(_user);
				//form.Size = this.Size;
				form.Location = this.Location;
				this.Hide();
				form.Show();
			}
			else
			{
				MessageBox.Show("Only For Admins", "Error", MessageBoxButtons.OK);
				AdminView.BackColor = Color.Gray;
			}

		}

		private void HandleAddCategoryButtonClick(object sender, EventArgs e)
		{
			Form4 form = new Form4(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void HandleViewFollowersButtonClick(object sender, EventArgs e)
		{
			FollowerForm form = new(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void HandleLogOutButtonClick(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}
		private void HomeForm_Load(object sender, EventArgs e)
		{
			ThoughtLabel1.Text = "Enter\nYour\nThoughts";
			CategoryComboBox.DataSource = context.categories.Select(c => new { c.Name, c.Id }).ToList();
			CategoryComboBox.DisplayMember = "Name";
			CategoryComboBox.ValueMember = "Id";
			//CategoryComboBox.SelectedIndex= 0;
			CategorySortComboBox.DataSource = CategoryComboBox.DataSource;
			CategorySortComboBox.DisplayMember = "Name";
			CategorySortComboBox.ValueMember = "Id";
			linkLabel1.Hide();

			LoadPosts();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			var query = context.Users.Where(u => (u.FirstName.Contains(SearchTextBox1.Text) ||
																	u.LastName.Contains(SearchTextBox1.Text) ||
																	u.UserName.Contains(SearchTextBox1.Text)));
			dataGridView1.DataSource = query.Select(u => new { u.FirstName, u.LastName, u.UserName, Followers = u.Followers.Count, Following = u.Followed.Count, u.Address })
																	.ToList();

			FollowUserComboBox1.DataSource = query.Select(u => new { u.UserName, u.Id }).ToList();
			FollowUserComboBox1.ValueMember = "Id";
			FollowUserComboBox1.DisplayMember = "UserName";

		}

		private void VisitProfileButton1_Click(object sender, EventArgs e)
		{
			VisitProfileForm form = new(_user, (int)FollowUserComboBox1.SelectedValue!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void UploadButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					PostPhotoButton1.Show();
					PostPhotoButton1.Image = Image.FromFile(openFileDialog.FileName);
					PostPhotoButton1.SizeMode = PictureBoxSizeMode.StretchImage;
					PostPhotoButton1.Tag = openFileDialog.FileName;
					// Display the selected image in the PictureBox
					//pictureBoxPreview.Image = Image.FromFile(openFileDialog.FileName);
					//pictureBoxPreview.Tag = openFileDialog.FileName; // Store the file path for later use
				}
				else
				{
					MessageBox.Show("Error, invalid image type");
				}
			}
		}

		private void PostButton1_Click(object sender, EventArgs e)
		{
			if (editingid != -1)
			{

			}

			if ((PostRichTextBox.Text == null || PostRichTextBox.Text == string.Empty) && (PostPhotoButton1.Image == null))
			{
				MessageBox.Show("no post or photo was attached", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (context.Users.Include(u => u.GotBanned).Where(u => u.Id == _user.Id).Any(u => u.GotBanned != null && u.GotBanned.Any(b => b.BannedTill >= DateTime.Now)))
			{
				MessageBox.Show($"You are banned from posting");
			}
			else
			{
				Post post;
				if (editingid != -1)
				{
					post = context.Posts.FirstOrDefault(x => x.Id == editingid);
					if (PostPhotoButton1.Image != null)
					{
						using (MemoryStream ms = new MemoryStream())
						{
							using (var clonedImage = new Bitmap(PostPhotoButton1.Image))
							{
								clonedImage.Save(ms, PostPhotoButton1.Image.RawFormat);
								byte[] imgByteArray = ms.ToArray();
								post.Picture = imgByteArray;
							}
						}
					}
				}
				else
				{
					post = new Post();
					post.PublisherId = _user.Id;
					post.CreationDate = DateTime.Now;
					if (PostPhotoButton1.Image != null)
					{
						using (MemoryStream ms = new MemoryStream())
						{
							using (var clonedImage = new Bitmap(PostPhotoButton1.Image))
							{
								clonedImage.Save(ms, PostPhotoButton1.Image.RawFormat);
								byte[] imgByteArray = ms.ToArray();
								post.Picture = imgByteArray;
							}
						}
					}
				}
				post.Content = PostRichTextBox.Text == null ? "" : PostRichTextBox.Text;
				if (CategoryComboBox?.SelectedValue != null)
				{
					post.CategoryId = (int)CategoryComboBox?.SelectedValue;
				}


				if (editingid != -1)
				{
					context.Posts.Update(post);
					editingid = -1;
				}
				else
				{
					context.Posts.Add(post);
				}
				context.SaveChanges();
				PostRichTextBox.Text = string.Empty;
				LoadPosts();
				PostPhotoButton1.Hide();
				if (context.categories.FirstOrDefault() is not null)
				{
					CategoryComboBox.SelectedValue = context.categories.FirstOrDefault();
				}

			}
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{

		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		public void OnPictureBoxClicked(object sender, PictureBoxEventArgs e)
		{
			bool PictureGotDownFlag = false;
			PictureBox pictureBox = sender as PictureBox;
			if (pictureBox != null)
			{
				int j = (int)pictureBox.Tag;
				if (pictureBox.Location.Y == 145)
				{
					pictureBox.Location = new Point(pictureBox.Location.X, 145 - 30);
					if (context.Reacts.FirstOrDefault(u => u.UserId == _user.Id && u.PostId == e.PostId) is not null)
					{
						var react = context.Reacts.FirstOrDefault(u => u.UserId == _user.Id && u.PostId == e.PostId);
						react.Reaction = (reaction)j;
						context.Update(react);
						//context.Entry(react).Reload();
					}
					else
					{
						React react = new React();
						react.PostId = e.PostId;
						react.UserId = _user.Id;
						react.Reaction = (reaction)j;
						context.Reacts.Add(react);
						//context.Entry(react).Reload();
					}
					context.SaveChanges();
				}
				else
				{
					var react = context.Reacts.FirstOrDefault(u => u.UserId == _user.Id && u.PostId == e.PostId);
					if (context.Reacts.FirstOrDefault(u => u.UserId == _user.Id && u.PostId == e.PostId) is not null)
					{
						context.Reacts.Remove(context.Reacts.FirstOrDefault(u => u.UserId == _user.Id && u.PostId == e.PostId)); //FirstOrDefault()
						context.SaveChanges();
						//context.Entry(react).Reload();
						PictureGotDownFlag = true;
					}
					pictureBox.Location = new Point(pictureBox.Location.X, 145);
				}
				foreach (var pic in e.boxes)
				{
					if ((int)pic.Tag != j || PictureGotDownFlag == true)
					{
						pic.Location = new Point(pic.Location.X, 145);
					}

				}
				int x = 5;
				LoadPosts();
			}
		}


		public void Delete_Click(object sender, EditEventArgs e)
		{
			// Cast the sender to a Button to access its properties
			DeletePostFnc(e.PostId);
			LoadPosts();
		}
		public void DeletePostFnc(int postid)
		{
			context.Posts.Remove(context.Posts.FirstOrDefault(p => p.Id == postid));
			context.SaveChanges();
			//LoadPosts();
		}

		public void Edit_Click(object sender, EditEventArgs e)
		{

			HomeForm form = new(_user, e.PostId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		public void Comments_Click(object sender, EditEventArgs e)
		{

			Form5 form = new Form5(_user, e.PostId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			current++;
			linkLabel1.Show();
			if (current >= numofpages - 1)
			{
				linkLabel2.Hide();
			}
			LoadPosts();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{



			//--FollowingPageNum;
			//if (FollowingPageNum == 0)
			//{
			//	PreviousPageLABEL2.Hide();
			//}
			//if (FollowingPageNum <= NumOfFollowingPages - 2)
			//{
			//	nextPageLabel2.Show();
			//}
			//LoadFollowing();
			current--;

			if (current == 0)
			{
				linkLabel1.Hide();
			}
			if (current <= numofpages - 2)
			{
				linkLabel2.Show();
			}

			LoadPosts();
		}

		private void ViewPostsByCategoryButton_Click(object sender, EventArgs e)
		{
			CategorySearchId = CategorySortComboBox.SelectedValue == null ? -1 : (int)CategorySortComboBox.SelectedValue;
			LoadPosts();
		}

		private void FollowedPostsButton_Click(object sender, EventArgs e)
		{
			CategorySearchId = -1;
			LoadPosts();
		}

		private void PostingPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
