using MyBlog.help;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBlog
{
	public partial class FollowerForm : Form
	{
		private MyBlogContext context = MyBlogContext.myBlogContext;
		private User _user;
		private int FollowersPageNum = 0;
		private int FollowingPageNum = 0;
		private int NumOfFollowerPages;
		private int NumOfFollowingPages;
		public FollowerForm(User user)
		{
			InitializeComponent();
			
			this._user = user;
		}

		//private void FollowerForm_Load(object sender, EventArgs e)
		//{
		//	int followersnum = context.Follows.Where(f => f.FollowedId == _user.Id).Count();
		//	int Followingnum = (context.Follows.Where(f => f.FollowerId == _user.Id).Count());
		//	richTextBox2.Text = "Following" + " ( " + Followingnum.ToString() + " )";
		//	richTextBox1.Text = "Followers" + " ( " + followersnum.ToString() + " )";
		//	richTextBox2.BringToFront();
		//	richTextBox1.BringToFront();

		//	NumOfFollowerPages = (int)Math.Ceiling((followersnum / 3.0f));
		//	Followingnum = (int)Math.Ceiling((Followingnum / 3.0f));

	
		//	LoadFollowers();
		//	LoadFollowing();
		//}
		private void LoadFollowers()
		{
			//NumOfFollowingPages = (int)Math.Ceiling((context.Follows.Where(f => f.FollowerId == _user.Id).Count() / 3.0f));
			NumOfFollowerPages = (int)Math.Ceiling((context.Follows.Where(f => f.FollowedId == _user.Id).Count() / 3.0f));
			if (NumOfFollowerPages <= FollowersPageNum+1)
			{
				NextFollowersPage.Hide();
			}
			else
			{
				NextFollowersPage.Show();
			}
			if(FollowersPageNum>0)
			{

				PreviousFollowersPage.Show();
			}
			else
			{
				PreviousFollowersPage.Hide();
			}

			var query = context.Follows.OrderBy(x => x.FollowerId).Where(f => f.FollowedId == _user.Id).Skip(3 * FollowersPageNum).Take(3);
			var userid = query.Select(i => i.FollowerId)?.ToList();
			if (query.Count() >= 0)
			{
				panel1.Hide();
				panel2.Hide();
				panel3.Hide();
				if (query.Count() >= 1)
				{
					panel1.Show();
					SetPanel(UserNameLabel1, ProfilePictureBox3, userid[0]);
					//VisitButton1.Click += VisitButton1_Click;

					if (query.Count() >= 2)
					{
						panel2.Show();
						SetPanel(label1, pictureBox3, userid[1]);
						//button1.Click += button1_Click;
						if (query.Count() >= 3)
						{
							panel3.Show();
							SetPanel(label2, pictureBox4, userid[2]);

							//button2.Click += button2_Click;
						}
					}
				}

			}

		}
		private void SetPanel(Label name, PictureBox profilepic, int _profileId)
		{
			name.Text = context.Users.FirstOrDefault(u => u.Id == _profileId)?.UserName;
			//name.Font = new Font("Arial", 24, FontStyle.Bold); // Change size and style as needed
			//name.Size = new Size(400, 50); // Adjust width and height
			name.TextAlign = ContentAlignment.MiddleCenter;
			var Img = context.Users.FirstOrDefault(u => u.Id == _profileId).Picture;
			if (Img == null || Img.Length == 0)
			{
				profilepic.Image = Image.FromFile("C:\\Users\\Mahmod\\Desktop\\PhotoProject\\istockphoto-1327592449-612x612.jpg");

				profilepic.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else
			{
				using (MemoryStream ms = new MemoryStream(Img))
				{
					Image image = Image.FromStream(ms);
					profilepic.Image = image;
				}
			}
			profilepic.SizeMode = PictureBoxSizeMode.StretchImage;
			// Optional: Change the background and foreground colors
			name.ForeColor = Color.Black; // Text color
			name.BackColor = Color.Transparent; // Background color
		}
		private void LoadFollowing()
		{
			NumOfFollowingPages = (int)Math.Ceiling((context.Follows.Where(f => f.FollowerId == _user.Id).Count() / 3.0f));
			//NumOfFollowerPages = (int)Math.Ceiling((context.Follows.Where(f => f.FollowedId == _user.Id).Count() / 3.0f));
			if (NumOfFollowingPages <= FollowingPageNum+1)
			{

				NextFollowingPage.Hide();
			}
			else
			{
				NextFollowingPage.Show();
			}
			if(FollowingPageNum>0)
			{
				PreviousFollowingPagel.Show();
			}
			else
			{
				PreviousFollowingPagel.Hide();
			}


			var query = context.Follows.OrderBy(x => x.FollowedId).Where(f => f.FollowerId == _user.Id).Skip(3 * FollowingPageNum).Take(3);
			var userid = query.Select(i => i.FollowedId).ToList();
			if (query.Count() >= 0)
			{

				panel4.Hide();
				panel5.Hide();
				panel6.Hide();
				if (query.Count() >= 1)
				{
					panel4.Show();
					SetPanel(label3, pictureBox5, userid[0]);
					//button3.Click += button3_Click;
					if (query.Count() >= 2)
					{
						panel5.Show();
						SetPanel(label4, pictureBox6, userid[1]);
						//button4.Click += button4_Click;
						if (query.Count() >= 3)
						{
							panel6.Show();
							SetPanel(label5, pictureBox7, userid[2]);
						//	button5.Click += button5_Click;
						}
					}
				}

			}
		}

		private void VisitButton1_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f=>f.FollowedId==_user.Id).Skip(3 * FollowersPageNum + 0).FirstOrDefault()?.FollowerId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f => f.FollowedId == _user.Id).Skip(3 * FollowersPageNum + 1).FirstOrDefault()?.FollowerId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f => f.FollowedId == _user.Id).Skip(3 * FollowersPageNum + 2).FirstOrDefault()?.FollowerId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f=>f.FollowerId==_user.Id).Skip(3 * FollowingPageNum + 2).FirstOrDefault()?.FollowedId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f => f.FollowerId == _user.Id).Skip(3 * FollowingPageNum + 1).FirstOrDefault()?.FollowedId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var profilenum = context.Follows.Where(f => f.FollowerId == _user.Id).Skip(3 *  FollowingPageNum + 0).FirstOrDefault()?.FollowedId;
			VisitProfileForm form = new(_user, (int)profilenum!);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		private void NextPageLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

			++FollowingPageNum;
			PreviousFollowingPagel.Show();
			if (FollowingPageNum >= NumOfFollowingPages - 1)
			{
				NextFollowingPage.Hide();
			}

			LoadFollowing();

		}

		private void PreviousPageLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			--FollowingPageNum;
			if (FollowingPageNum == 0)
			{
				PreviousFollowingPagel.Hide();
			}
			if (FollowingPageNum <= NumOfFollowingPages - 2)
			{
				NextFollowingPage.Show();
			}
			LoadFollowing();
		}

		private void nextPageLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			++FollowersPageNum;
			
			LoadFollowers();
		}

		private void PreviousPageLABEL2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

			//++FollowingPageNum;
			//PreviousPageLABEL2.Show();
			//if (FollowingPageNum >= NumOfFollowingPages - 1)
			//{
			//	nextPageLabel2.Hide();
			//}
			//LoadFollowing();

			--FollowersPageNum;
			LoadFollowers();
		}

		private void FollowerForm_Load_1(object sender, EventArgs e)
		{


			int followersnum = context.Follows.Where(f => f.FollowedId == _user.Id).Count();
			int Followingnum = (context.Follows.Where(f => f.FollowerId == _user.Id).Count());
			richTextBox1.Text = "Following" + " ( " + Followingnum.ToString() + " )";
			richTextBox2.Text = "Followers" + " ( " + followersnum.ToString() + " )";
			richTextBox2.BringToFront();
			richTextBox1.BringToFront();

			NumOfFollowerPages = (int)Math.Ceiling((followersnum / 3.0f));
			Followingnum = (int)Math.Ceiling((Followingnum / 3.0f));


			VisitButton1.SetSecondaryButton(Width: 100);
			button1.SetSecondaryButton(Width: 100);
			button2.SetSecondaryButton(Width: 100);
			button3.SetSecondaryButton(Width: 100);
			button4.SetSecondaryButton(Width: 100);
			button5.SetSecondaryButton(Width: 100);
			//richTextBox1.BackColor = Color.Transparent;
			//richTextBox2.BackColor = Color.Transparent;
			GoBackButton1.SetButton( 0, 120, "Back");
			//panel7.BackColor = Color.Transparent;
			//panel8.BackColor = Color.Transparent;
			//panel6.BackColor = Color.Transparent;
			//panel5.BackColor = Color.Transparent;
			//panel4.BackColor = Color.Transparent;
			//panel3.BackColor = Color.Transparent;
			//panel2.BackColor = Color.Transparent;
			//panel1.BackColor = Color.Transparent;
			LoadFollowers();
			LoadFollowing();
		}

		private void GoBackButton1_Click(object sender, EventArgs e)
		{
			HomeForm form = new(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void panel7_Paint(object sender, PaintEventArgs e)
		{

		}

		private void panel8_Paint(object sender, PaintEventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
