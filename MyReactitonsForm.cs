using MyBlog.help;
using MyBlog.Migrations;
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
	
	public delegate void PostButtonClicked(object sender, PostEventArgs e);
	public partial class MyReactitonsForm : Form
	{
		EventHandler[] PostsHandlers=new EventHandler[9];
		EventHandler[] CommentsHandlers=new EventHandler[6];

		MyBlogContext context = MyBlogContext.myBlogContext;
		User _user;
		Panel[] CommentsPanel = new Panel[3];
		int CommentCurrent = 0;
		int NumOfCommentsPages;
		Panel[] PostPanel = new Panel[3];
		int PostCurrent = 0;
		int NumOfPostsPages;
		public MyReactitonsForm(User User)
		{
			InitializeComponent();
			PreviousPageComments.Hide();
			PreviousPagePosts.Hide();
			this._user = User;
			CommentsPanel[0] = Comment1panel;
			CommentsPanel[1] = Comment2Panel;
			CommentsPanel[2] = Comment3Panel;
			PostPanel[0] = PostPanel1;
			PostPanel[1] = PostPanel2;
			PostPanel[2] = PostPanel3;


			button1.SetButton(0, 120, "Back");
			NumOfCommentsPages = ((int)Math.Ceiling((context.comments.Where(c => c.PublisherId == _user.Id).Count()) / 3.0f));
			NumOfPostsPages = ((int)Math.Ceiling((context.Posts.Where(c => c.PublisherId == _user.Id).Count()) / 3.0f));
			if (NumOfCommentsPages <= 1)
			{
				NextPageComments.Hide();
			}
			if (NumOfPostsPages <= 1)
			{
				NextPagePosts.Hide();
			}
		}

		private void MyReactitonsForm_Load(object sender, EventArgs e)
		{
			SetNexPage();
			this.Text = "MyInteractions";
			Visitcomment1.SetSecondaryButton(Width: 100, pointa: Visitcomment1.Location.X -27);
			Visitcomment2.SetSecondaryButton(Width: 100, pointa: Visitcomment2.Location.X -27);
			visitcomment3.SetSecondaryButton(Width: 100, pointa: visitcomment3.Location.X -27);
			VisitPost1.SetSecondaryButton(Width: 100 );
			VisitPost2.SetSecondaryButton(Width: 100 );
			VisitPost3.SetSecondaryButton(Width: 100 );
			LoadComments();
			LoadPosts();
		}
		private void SetNexPage()
		{
			NumOfPostsPages = ((int)Math.Ceiling((context.Posts.Where(c => c.PublisherId == _user.Id).Count()) / 3.0f));
			if (NumOfPostsPages <= 1)
			{
				NextPagePosts.Hide();
			}
			else if (PostCurrent <= NumOfPostsPages - 2)
			{
				NextPagePosts.Show();
			}
		}
		private void LoadPosts()
		{
			SetNexPage();
			MyPosts.Text = "My Posts" + $" ({context.Posts.Where(c => c.PublisherId == _user.Id).Count()})";
			richTextBox4.Text = "My Comments" + $" ({context.comments.Where(c => c.PublisherId == _user.Id).Count()})";
			EditDesignerPostStuff(0, PostPublisherLabel1, Post1picturebox, Post1Content, Publisher1PictureBox, ref DeletePost1, ref VisitPost1, ref EditPost1);
			EditDesignerPostStuff(1, PostPublisherLabel2, Post2picturebox, Post2Content, Publisher2PictureBox, ref DeletePost2, ref VisitPost2, ref EditPost2);
			EditDesignerPostStuff(2, PostPublisherLabel3, Post3picturebox, Post3content, Publisher3PictureBox, ref DeletePost3, ref VisitPost3, ref EditPost3);
			Publisher1PictureBox.BringToFront();
			Publisher2PictureBox.BringToFront();
			Publisher3PictureBox.BringToFront();

			DeletePost1.BringToFront();
			DeletePost2.BringToFront();
			DeletePost3.BringToFront();
			VisitPost1.BringToFront();
			VisitPost2.BringToFront();
			VisitPost3.BringToFront();
			EditPost1.BringToFront();
			EditPost2.BringToFront();
			EditPost3.BringToFront();

		}
		private void LoadComments()
		{
			MyPosts.Text = "My Posts" + $" ({context.Posts.Where(c => c.PublisherId == _user.Id).Count()})";
			richTextBox4.Text = "My Comments" + $" ({context.comments.Where(c => c.PublisherId == _user.Id).Count()})";
			NumOfCommentsPages = ((int)Math.Ceiling((context.comments.Where(c => c.PublisherId == _user.Id).Count()) / 3.0f));
			if (NumOfCommentsPages <= 1)
			{
				NextPageComments.Hide();
			}
			else if (CommentCurrent <= NumOfCommentsPages - 2)
			{
				NextPageComments.Show();
			}

			EditDesignerCommentStuff(0, usernamecomment1, comment1photo, comment1content, comment1pfpicturebox, ref deletecomment1, ref Visitcomment1);
			EditDesignerCommentStuff(1, usernamecomment2, comment2photo, comment2content, comment2pfpicturebox, ref deletecomment2, ref Visitcomment2);
			EditDesignerCommentStuff(2, usernamecomment3, comment3photo, comment3contentt, comment3pfp, ref deletecomment3, ref visitcomment3);
			deletecomment1.BringToFront();
			deletecomment2.BringToFront();
			deletecomment3.BringToFront();
			Visitcomment1.BringToFront();
			Visitcomment2.BringToFront();
			visitcomment3.BringToFront();
			//EditDesignerCommentStuff(0, usernamecomment1, comment1photo, comment1content, comment1pfpicturebox, ref deletecomment1, ref Visitcomment1);

		}
		public void EditDesignerPostStuff(int index, Label UserName, PictureBox CommentPicture12, RichTextBox Comment12Textbox, PictureBox COMMENT12PFP, ref Button myDeleteButton, ref Button VisitButton, ref Button EditButton)
		{

			var Post = context.Posts.Where(c => c.PublisherId == _user.Id).OrderByDescending(c => c.CreationDate).Skip(3 * PostCurrent + index).FirstOrDefault();

			if (Post == null)
			{
				PostPanel[index].Hide();
			}
			else
			{
				PostPanel[index].Show();

				if (Post.Picture is not null)
				{
					using (MemoryStream ms = new MemoryStream(Post.Picture))
					{

						CommentPicture12.Image = Image.FromStream(ms);
						CommentPicture12.SizeMode = PictureBoxSizeMode.StretchImage;
					}
				}
				Comment12Textbox.Text = Post.Content;
				Comment12Textbox.ReadOnly = true;
				//var publisher = context.Users.FirstOrDefault(x => x.Id == comment.PublisherId);
				var pfp = _user.Picture;
				UserName.Text = _user.UserName;
				UserName.Font = new Font("Arial", 12, FontStyle.Bold);
				if (_user.Picture is null)
				{
					COMMENT12PFP.Image = Image.FromFile("C:\\Users\\Mahmod\\Desktop\\PhotoProject\\istockphoto-1327592449-612x612.jpg");
					COMMENT12PFP.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				else
				{
					using (MemoryStream ms = new MemoryStream(pfp))
					{

						COMMENT12PFP.Image = Image.FromStream(ms);
						COMMENT12PFP.SizeMode = PictureBoxSizeMode.StretchImage;
					}
				}

				PostEventArgs args = new PostEventArgs(Post.Id);

				if (PostsHandlers[index * 3 + 0] != null)
				{
					VisitButton.Click -= PostsHandlers[index * 3 + 0];
				}
				PostsHandlers[index * 3 + 0] = (s, e) => VisitPostPress(s, args);
				VisitButton.Click += PostsHandlers[index * 3 + 0];


				if (PostsHandlers[index * 3 + 1] != null)
				{
					EditButton.Click -= PostsHandlers[index * 3 + 1];
				}
				PostsHandlers[index * 3 + 1] = (s, e) => EditPostPressed(s, args);
				EditButton.Click += PostsHandlers[index * 3 + 1];


				if (PostsHandlers[index * 3 + 2] != null)
				{
					myDeleteButton.Click -= PostsHandlers[index * 3 + 2];
				}
				PostsHandlers[index * 3 + 2] = (s, e) => DeletePostClicked(s, args);
				myDeleteButton.Click += PostsHandlers[index * 3 + 2];


				myDeleteButton.BringToFront();
				VisitButton.BringToFront();
				EditButton.BringToFront();
			}

		}
		private void DeletePostClicked(object sender, PostEventArgs args)
		{
			var PostToBeDELETED = context.Posts.SingleOrDefault(c => c.Id == args._PostId);
			if (PostToBeDELETED is not null)
			{
				context.Posts.Remove(PostToBeDELETED);
			}

			context.SaveChanges();
			LoadPosts();
		}
		private void VisitPostPress(object sender, PostEventArgs args)
		{
			//var CommentToBeVisited = context.Posts.SingleOrDefault(c => c.Id == args._PostId);
			Form5 form = new Form5(_user, args._PostId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}
		private void EditPostPressed(object sender, PostEventArgs args)
		{
			//var PostToBeEdited = context.Posts.SingleOrDefault(c => c.Id == args._PostId);
			HomeForm form = new HomeForm(_user, args._PostId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}
		private void EditDesignerCommentStuff(int index, Label UserName, PictureBox CommentPicture12, RichTextBox Comment12Textbox, PictureBox COMMENT12PFP, ref Button myDeleteButton, ref Button VisitButton)
		{
			var comment = context.comments.Where(c => c.PublisherId == _user.Id).OrderByDescending(c => c.CreationDate).Skip(3 * CommentCurrent + index).FirstOrDefault();

			if (comment == null)
			{
				CommentsPanel[index].Hide();
			}
			else
			{
				CommentsPanel[index].Show();

				if (comment.Picture is not null)
				{
					using (MemoryStream ms = new MemoryStream(comment.Picture))
					{

						CommentPicture12.Image = Image.FromStream(ms);
						CommentPicture12.SizeMode = PictureBoxSizeMode.StretchImage;
					}
				}
				Comment12Textbox.Text = comment.Content;
				Comment12Textbox.ReadOnly = true;
				//var publisher = context.Users.FirstOrDefault(x => x.Id == comment.PublisherId);
				var pfp = _user.Picture;
				UserName.Text = _user.UserName;
				
				if (_user.Picture is null)
				{
					COMMENT12PFP.Image = Image.FromFile("C:\\Users\\Mahmod\\Desktop\\PhotoProject\\istockphoto-1327592449-612x612.jpg");
					COMMENT12PFP.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				else
				{
					using (MemoryStream ms = new MemoryStream(pfp))
					{

						COMMENT12PFP.Image = Image.FromStream(ms);
						COMMENT12PFP.SizeMode = PictureBoxSizeMode.StretchImage;
					}
				}



				//var comment2 = context.comments.SingleOrDefault(c => c.Id ==)
				DeleteCommentEventArgs args = new DeleteCommentEventArgs(comment.Id);

				if (CommentsHandlers[index * 2 + 0] != null)
				{
					VisitButton.Click -= CommentsHandlers[index * 2 + 0];
				}
				CommentsHandlers[index * 2 + 0] = (s, e) => VisitCommentPress(s, args);
				VisitButton.Click += CommentsHandlers[index * 2 + 0];


		

				if (CommentsHandlers[index * 2 + 1] != null)
				{
					myDeleteButton.Click -= CommentsHandlers[index * 2 + 1];
				}
				CommentsHandlers[index * 2 + 1] = (s, e) => DeleteCommentPress(s, args);
				myDeleteButton.Click += CommentsHandlers[index * 2 + 1];


				VisitButton.BringToFront();
				myDeleteButton.BringToFront();

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
		private void VisitCommentPress(object sender, DeleteCommentEventArgs args)
		{

			var CommentToBeVisited = context.comments.SingleOrDefault(c => c.Id == args._CommentId);
			Form5 form = new Form5(_user, CommentToBeVisited.PostId);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();

		}

		private void PreviousPageComments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CommentCurrent--;
			if (CommentCurrent <= NumOfCommentsPages - 2)
				NextPageComments.Show();
			if (CommentCurrent == 0)
			{
				PreviousPageComments.Hide();
			}
			LoadComments();
		}

		private void NextPageComments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CommentCurrent++;
			PreviousPageComments.Show();
			if (CommentCurrent >= NumOfCommentsPages - 1)
			{
				NextPageComments.Hide();
			}
			LoadComments();
		}

		private void PostPanel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void NextPagePosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			PostCurrent++;
			PreviousPagePosts.Show();
			if (PostCurrent >= NumOfPostsPages - 1)
			{
				NextPagePosts.Hide();
			}
			LoadPosts();
		}

		private void PreviousPagePosts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			PostCurrent--;
			if (PostCurrent <= NumOfPostsPages - 2)
				NextPagePosts.Show();
			if (PostCurrent == 0)
			{
				PreviousPagePosts.Hide();
			}
			LoadPosts();
		}

		private void PostPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			HomeForm form = new(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}

		
	}
}
