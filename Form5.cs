using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBlog.help;
using MyBlog.Migrations;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBlog
{
	public delegate void DeleteCommentEventHandler(object sender, DeleteCommentEventArgs args);
	public partial class Form5 : Form
	{
		PictureBox[] Reacts = new PictureBox[6];
		Label[] ReactsNumbers = new Label[6];
		public int NumOfCommentsPages;
		public int Current = 0;
		public User _user { get; set; }
		public int _postId { get; set; }
		public MyBlogContext context { get; set; } = MyBlogContext.myBlogContext;
		EventHandler[] DeleteButtonHandler = new EventHandler[4];
		public Form5(User user, int PostId)
		{
			InitializeComponent();
			_user = user;
			_postId = PostId;
		}

		private void Home_Clicked(object sender, EventArgs e)
		{
			HomeForm form = new HomeForm(_user);
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}
		private void Form5_Load(object sender, EventArgs e)
		{

			NumOfCommentsPages = ((int)Math.Ceiling((context.comments.Where(c => c.PostId == _postId).Count()) / 4.0f));
			if (NumOfCommentsPages <= 1)
			{
				NextPageLinkLabel.Hide();
			}

			Home.SetButton(0, 120, "BackHome");
			var post = context.Posts.FirstOrDefault(x => x.Id == _postId);
			if (post.PublisherId != _user.Id)
			{
				EditButton.Hide();
				DeleteButton.Hide();
			}
			if (_user.Role >= Role.Moderator)
			{
				DeleteButton.Show();
			}
			PreviousPageLinkLabel.Hide();

			#region Pictures
			PostPictureBox.SetPostPicture(post.Picture);
			PostDateLabel.Text = post.CreationDate.ToString();

			var user = context.Users.FirstOrDefault(u => u.Id == post.PublisherId);
			var pic = user.Picture;
			PublisherPictureBox.SetProfilePicture(pic);

			#endregion
			PostPublisherLabel.Text = user.UserName;
			PostContentTextBox.Text = post.Content;

			EditButton.Hide();
			DeleteButton.Hide();
			if (user.Id == _user.Id)
			{
				EditButton.Show();
			}
			if (user.Id == _user.Id || context.Users.FirstOrDefault(x => x.Id == _user.Id).Role >= Role.Moderator)
			{
				DeleteButton.Show();
			}



			#region TextBoxesSet
			PostContentTextBox.SetRichTextBox();
			//Comment1Textbox.SetRichTextBox();
			//Comment2Textbox.SetRichTextBox();
			//Comment3Textbox.SetRichTextBox();
			//Comment4Textbox.SetRichTextBox();
			//AddComment1TextBox.EditRichTextBox();


			UploadPhotto.SetSecondaryButton(Width:105);
			AddCommmentButtton.SetSecondaryButton(Width: 105);
			//button1.SetThirdButton();
			//button2.SetThirdButton();
			//button3.SetThirdButton();
			//button4.SetThirdButton();


			//EditButton.SetSecondaryButton();
			//DeleteButton.SetSecondaryButton();

			PostDateLabel.DateLabel();
			datelabel1.DateLabel();
			datelabel2.DateLabel();
			datelabel3.DateLabel();
			datelabel4.DateLabel();

			PostPublisherLabel.BigUserName();
			usernamecomment1.UserName();
			usernamecomment2.UserName();
			usernamecomment3.UserName();
			usernamecomment4.UserName();

			#endregion

			Reacts[0] = LikeBox;
			Reacts[1] = LoveBox;
			Reacts[2] = SadBox;
			Reacts[3] = HahaBox;
			Reacts[4] = WowBox;
			Reacts[5] = AngryBox;
			ReactsNumbers[0] = LikesNum;
			ReactsNumbers[1] = LoveNum;
			ReactsNumbers[2] = SadNum;
			ReactsNumbers[3] = HahaNum;
			ReactsNumbers[4] = WowNum;
			ReactsNumbers[5] = AngryNum;
			for (int i = 0; i <= 5; i++)
			{
				Reacts[i].Tag = i;
				Reacts[i].Click += HandleAddingReact;
			}
			HandleEmojis(Reacts, ReactsNumbers, _user.Id, _postId);
			LoadComments();
		}

		public static void HandleEmojis(PictureBox[] reacts, Label[] reactsNumbers, int usernId, int _postnId)
		{
			MyBlogContext context = MyBlogContext.myBlogContext;
			var LowYposition = reacts[0].Location.Y < reacts[1].Location.Y ? reacts[1].Location.Y : reacts[0].Location.Y;
			var currentReact = context.Reacts.FirstOrDefault(r => r.UserId == usernId && r.PostId == _postnId);
			for (int i = 0; i <= 5; i++)
			{
				//reacts[i].Tag = i;
				reacts[i].Location = new Point(reacts[i].Location.X, LowYposition);
				reactsNumbers[i].Text = context.Reacts.Where(r => r.PostId == _postnId && r.Reaction == (reaction)i).Count().ToString();
			}
			if (currentReact != null)
			{
				int index = (int)currentReact.Reaction;
				reacts[index].Location = new Point(reacts[index].Location.X, LowYposition - 30);

			}

		}
		private void HandleAddingReact(object sender, EventArgs args)
		{
			var LowYposition = Reacts[0].Location.Y < Reacts[1].Location.Y ? Reacts[1].Location.Y : Reacts[0].Location.Y;
			var React = context.Reacts.FirstOrDefault(R => R.UserId == _user.Id && R.PostId == _postId);
			if (sender is PictureBox box)
			{


				if (React == null)
				{
					var React2 = new React
					{
						UserId = _user.Id,
						PostId = _postId,
						Reaction = (reaction)box.Tag,
					};
					context.Reacts.Add(React2);
				}
				else if (LowYposition == box.Location.Y)
				{

					React.Reaction = (reaction)box.Tag;
					context.Reacts.Update(React);
				}
				else
				{
					context.Reacts.Remove(React);
				}

				context.SaveChanges();

			}

			HandleEmojis(Reacts, ReactsNumbers, _user.Id, _postId);


		}

		Panel[] panels = new Panel[4];
		private void LoadComments()
		{
			NumOfCommentsPages = ((int)Math.Ceiling((context.comments.Where(c => c.PostId == context.Posts.FirstOrDefault(p => p.Id == _postId).Id).Count()) / 4.0f));
			if (NumOfCommentsPages <= 1)
			{
				NextPageLinkLabel.Hide();
			}
			else if (Current <= NumOfCommentsPages - 2)
			{
				NextPageLinkLabel.Show();
			}

			panels[0] = CommentPanel1;
			panels[1] = commentpanel2;
			panels[2] = commmentpanel3;
			panels[3] = commentpanel4;
			for (int i = 0; i < 4; i++)
			{
				panels[i].Hide();
			}

			EditDesignerCommentStuff(0, usernamecomment1, datelabel1, CommentPicture1, Comment1Textbox, COMMENT1PFP, ref button1);
			EditDesignerCommentStuff(1, usernamecomment2, datelabel2, CommentPicture2, Comment2Textbox, COMMENT2PFP, ref button2);
			EditDesignerCommentStuff(2, usernamecomment3, datelabel3, CommentPicture3, Comment3Textbox, COMMENT3PFP, ref button3);
			EditDesignerCommentStuff(3, usernamecomment4, datelabel4, CommentPicture4, Comment4Textbox, COMMENT4PFP, ref button4);
			button1.BringToFront();
			button2.BringToFront();
			button3.BringToFront();
			button4.BringToFront();
			COMMENT1PFP.BringToFront();
			COMMENT2PFP.BringToFront();
			COMMENT3PFP.BringToFront();
			COMMENT4PFP.BringToFront();


		}
		private void EditDesignerCommentStuff(int index, Label UserName, Label datelabel12, PictureBox CommentPicture12, RichTextBox Comment12Textbox, PictureBox COMMENT12PFP, ref Button myDeleteButton)
		{

			var post = context.Posts.Include(p => p.Comments).SingleOrDefault(p => p.Id == _postId);
			var comment = post.Comments?.OrderByDescending(c => c.CreationDate).Skip(4 * Current + index).FirstOrDefault();

			if (comment == null)
			{
				panels[index].Hide();
			}
			else
			{
				panels[index].Show();
				datelabel12.Text = comment.CreationDate.ToString();
				CommentPicture12.SetPostPicture(comment.Picture);

				Comment12Textbox.Text = comment.Content;

				var publisher = context.Users.FirstOrDefault(x => x.Id == comment.PublisherId);
				var pfp = publisher.Picture;

				UserName.Text = publisher.UserName;
				COMMENT12PFP.SetProfilePicture(publisher.Picture);

				DeleteCommentEventArgs args = new DeleteCommentEventArgs(comment.Id);


				if (DeleteButtonHandler[index] != null)
				{
					myDeleteButton.Click -= DeleteButtonHandler[index];
				}
				DeleteButtonHandler[index] = (s, e) => DeleteCommentPress(s, args);
				myDeleteButton.Click += DeleteButtonHandler[index];
			}
		}
		private void DeleteCommentPress(object sender, DeleteCommentEventArgs args)
		{
			var CommentToBeDeleted = context.comments.SingleOrDefault(c => c.Id == args._CommentId);
			if (CommentToBeDeleted is not null)
			{
				context.comments.Remove(CommentToBeDeleted);
			}

			context.SaveChanges();
			LoadComments();
		}
		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void PublisherPictureBox_Click(object sender, EventArgs e)
		{

			VisitProfileForm form = new VisitProfileForm(_user, (int)context.Posts.FirstOrDefault(p => p.Id == _postId).PublisherId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void UploadPhotto_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					AddPictureToCommentPicturebox.Show();
					AddPictureToCommentPicturebox.Image = Image.FromFile(openFileDialog.FileName);
					AddPictureToCommentPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
					AddPictureToCommentPicturebox.Tag = openFileDialog.FileName;
					// Display the selected image in the PictureBox
					//pictureBoxPreview.Image = Image.FromFile(openFileDialog.FileName);
					//pictureBoxPreview.Tag = openFileDialog.FileName; // Store the file path for later use
				}
				else
				{
					MessageBox.Show("Incorrect format");
				}
			}
		}

		private void AddCommmentButtton_Click(object sender, EventArgs e)
		{
			Comment comment = new();
			comment.PostId = _postId;

			if (AddPictureToCommentPicturebox.Image != null)
			{

				using (MemoryStream ms = new MemoryStream())
				{
					using (var clonedImage = new Bitmap(AddPictureToCommentPicturebox.Image))
					{
						clonedImage.Save(ms, AddPictureToCommentPicturebox.Image.RawFormat);
						byte[] imgByteArray = ms.ToArray();
						comment.Picture = imgByteArray;
					}
				}

			}
			else
			{
				comment.Picture = null;
			}
			AddPictureToCommentPicturebox.Image = null;
			comment.CreationDate = DateTime.Now;
			comment.PublisherId = _user.Id;
			comment.Content = AddComment1TextBox.Text;

			if (comment.Picture == null && (comment.Content == string.Empty || comment.Content == null))
			{
				MessageBox.Show("Enter A picture or a text to add the Comment");
			}
			else if (context.Users.Include(u => u.GotBanned).Where(u => u.Id == _user.Id).Any(u => u.GotBanned != null && u.GotBanned.Any(b => b.BannedTill >= DateTime.Now)))
			{
				MessageBox.Show("You Are banned from comentinig");
			}
			else
			{
				AddComment1TextBox.Text = "";
				context.comments.Add(comment);
				context.SaveChanges();
			}
			LoadComments();


		}

		private void NextPageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Current++;
			PreviousPageLinkLabel.Show();
			if (Current >= NumOfCommentsPages - 1)
			{
				NextPageLinkLabel.Hide();
			}
			LoadComments();
		}


		private void PreviousPageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Current--;
			if (Current <= NumOfCommentsPages - 2)
				NextPageLinkLabel.Show();
			if (Current == 0)
			{
				PreviousPageLinkLabel.Hide();
			}
			LoadComments();
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{


			HomeForm form = new(_user);
			var post = context.Posts.FirstOrDefault(p => p.Id == _postId);
			if (post != null)
			{
				context.Remove(post);
				context.SaveChanges();
			}
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			HomeForm form = new(_user, _postId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}


	}
}
