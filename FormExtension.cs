//using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyBlog.help;
using MyBlog.Migrations;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyBlog
{
	public static class FormExtension
	{
		static MyBlogContext _context;
		public static Panel PostShow(this HomeForm form,MyBlogContext context, int browsingUseriD, Post Post, int index, EventHandler ReactClick = null, EventHandler CommentClick=null,EventHandler DeleteClick=null,EventHandler EditClick=null)
		{

			_context = context; 
			Panel panel = new Panel();
			panel.Location = new Point(155, 246 + index * 215);
			panel.Width = 840;
			panel.Height = 201;
			panel.BackColor = Color.FromArgb(203, 233, 237);
			panel.BorderStyle=BorderStyle.FixedSingle;
			RichTextBox PostContent = new RichTextBox();
			panel.Controls.Add(PostContent);
			PostContent.Location = new(3, 47);
			PostContent.Width = 440;
			PostContent.Height = 29;
			PostContent.BackColor = Color.FromArgb(0XE3, 0XE3, 0XE3);
			
			PostContent.Text = Post.Content;
			PostContent.ReadOnly = true;
			PictureBox PostPictureBox = new PictureBox();
			panel.Controls.Add(PostPictureBox);
			PostPictureBox.Location = new(450, 47);
			PostPictureBox.Size = new Size(222, 92);
			PostPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			
			var Postpic = Post.Picture;
			if (Postpic != null )
			{
				using (var ms = new MemoryStream(Postpic))
				{
					PostPictureBox.Image = Image.FromStream(ms);
				}
				PostPictureBox.Show();
			}
			else
			{
				PostPictureBox.Hide();
			}
			PictureBox profilePicture = new();
			panel.Controls.Add(profilePicture);
			profilePicture.Location = new(3 ,3 );
			profilePicture.Size = new Size(45, 38);
			profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
			var user = context.Users.FirstOrDefault(u => u.Id == Post.PublisherId);
				var pic = user.Picture;
			if (pic != null&& user!=null)
			{
				 using (var ms = new MemoryStream(user.Picture))
				{
					profilePicture.Image = Image.FromStream(ms);
				}
			}
			else
			{
				profilePicture.Image = Properties.Resources.istockphoto_1327592449_612x612;
					//Image.FromFile("C:\\Users\\Mahmod\\Desktop\\PhotoProject\\istockphoto-1327592449-612x612.jpg");
			}
			Label UserName = new Label();
			panel.Controls.Add(UserName);
			UserName.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			UserName.Size =new (138, 44);
			UserName.Location =new (54, 0);
			UserName.Text = user.UserName;

			Label Category = new Label();
		
				//panel.Controls.Add(Category);
				Category.Location = new(PostContent.Location.X, PostContent.Location.Y+ PostContent.Height+5);
			Category cat = context.categories.SingleOrDefault(C => C.Id == Post.CategoryId);
			if (cat is not null)
				Category.Text = "Category: " + cat.Name;
			else
			{
				Category.Text = "NoCategory";


			}
			Category.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			//Category.Text = context.categories.FirstOrDefault(C => C.Id == Post.CategoryId).Name.ToString();
			Category.Width = 430;
			Category.Height = 20;
			Category.BackColor = Color.Transparent;

			panel.Controls.Add(Category);
			Category.BringToFront();
			//UserName.BackColor = Color.White;

			//Label CategoryName = new Label();
			//CategoryName.Location = new(UserName.Location.X + 10, UserName.Location.Y + 10);
			//CategoryName.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			//CategoryName.Text = context.categories.FirstOrDefault(C => C.Id == Post.CategoryId).Name.ToString();
			//CategoryName.Width = 100;
			//CategoryName.Height = 100;
			//CategoryName.BackColor = Color.Transparent;
			//CategoryName.BringToFront();
			//panel.Controls.Add(CategoryName);
			Label Date = new Label();
			panel.Controls.Add(Date);
			Date.Location = new Point(725, 0);
			Date.Width = 100;
			Date.Height = 100;
			Date.BackColor = Color.Transparent;
			Date.Font= new Font("Segoe UI", 9, FontStyle.Regular);
			Date.Text = Post.CreationDate.ToString();
				int i = 0;
				PictureBox[] Reacts = new PictureBox[6];
		
				PictureBox Like = new PictureBox();
				PictureBox Love = new PictureBox();
				PictureBox Sad = new PictureBox();
				PictureBox Haha = new PictureBox();
				PictureBox Wow = new PictureBox();
				PictureBox Angry = new PictureBox();
				Reacts[0] = Like;
				Reacts[1] = Love;
				Reacts[2] = Sad;
				Reacts[3] = Haha;
				Reacts[4] = Wow;
				Reacts[5] = Angry;

				form.Reacts = Reacts;

			 i = 0;
				var trackedentity = context.Reacts.Local.FirstOrDefault(u => u.UserId == form._user.Id && u.PostId == Post.Id);
			React react;
			if (trackedentity != null)
			{
				context.Entry(trackedentity).Reload();
				 react  = trackedentity;
			}
			else
			{
				 react= context.Reacts
				.FirstOrDefault(u => u.UserId == form._user.Id && u.PostId == Post.Id);
			}
			if (react != null && react.Reaction == (reaction)i)
			{
				
				context.Remove(react);
				context.SaveChanges();
			}
			foreach (var React in Reacts)
			{
				panel.Controls.Add(React);
				if (react is null
					|| react.Reaction != (reaction)i)
				{
					React.Location = new(3 + i * 52, 145);
				}
				else if(react.Reaction== (reaction)i)
				{
					React.Location = new(3 + i * 52, 145-30);
				}
				React.Size = new Size(20, 25);
				React.SizeMode = PictureBoxSizeMode.StretchImage;
				//React.Click += ReactClick;
				var args2 = new PictureBoxEventArgs(Reacts, Post.Id);
				React.Click += (s,e)=>form.OnPictureBoxClicked(s,args2);
				React.Tag = i;
				//React.BackColor = Color.Black;

				i++;
			}
			//Reacts[0].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\Like.png");
			//Reacts[1].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\Love.png");
			//Reacts[2].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\NewFolder\\Sad.png");
			//Reacts[3].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\Haha.png");
			//Reacts[4].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\Wow.png");
			//Reacts[5].Image = Image.FromFile("C:\\Users\\Mahmod\\source\\repos\\MyBlog\\MyBlog\\Photos\\Angryy.png");
			Reacts[0].Image = Properties.Resources.Like;
			Reacts[1].Image = Properties.Resources.Love;
			Reacts[2].Image = Properties.Resources.Sad;
			Reacts[3].Image = Properties.Resources.Haha;
			Reacts[4].Image = Properties.Resources.Wow;
			Reacts[5].Image = Properties.Resources.Angry;

			//panel.BorderStyle = BorderStyle.FixedSingle;
			//panel.Controls.Add();
			//form.Controls.Add(panel);
			if (CommentClick != null)
			{
				Button Comments = new Button();
				panel.Controls.Add(Comments);
				Comments.Location = new(300, 145);
				Comments.Size = new Size(160, 41);
				Comments.BackColor = Color.FromArgb(106, 195, 211);//#6AC3D5
				Comments.Font= new Font("Segoe UI", 12, FontStyle.Regular);
				var args3 = new EditEventArgs(Post.Id);
				Comments.Click += (s,e)=>form.Comments_Click(s,args3);
				Comments.Text = "Comments";
			}

			if (EditClick != null)
			{
				Button Edit = new Button();
				panel.Controls.Add(Edit);
				Edit.Location = new(198, 3);
				Edit.Size = new Size(101, 41);
				Edit.BackColor = Color.FromArgb(106, 195, 211);//#6AC3D5
				Edit.Font = new Font("Segoe UI", 12, FontStyle.Regular);
				var args1 = new EditEventArgs(Post.Id);
				Edit.Click += (s, e) => form.Edit_Click(s, args1);
				Edit.Text = "edit";
			Edit.Hide();
				if (browsingUseriD == user.Id)
				{

				Edit.Show();
				}
			}
			if (DeleteClick != null)
			{
				Button Delete = new Button();
				panel.Controls.Add(Delete);
				Delete.Location = new(319, 3);
				Delete.Size = new Size(101, 41);
				Delete.BackColor = Color.FromArgb(106, 195, 211);//#6AC3D5
				Delete.Font = new Font("Segoe UI", 12, FontStyle.Regular);
				var args4 = new EditEventArgs(Post.Id);
				Delete.Click += (s, e) => form.Delete_Click(s, args4);
				Delete.Text = "Delete";
				Delete.Hide();
				if (browsingUseriD == user.Id || context.Users.FirstOrDefault(u=>u.Id==browsingUseriD).Role >=Role.Moderator)
				{
				Delete.Show();

				}
			}

			

			//form.Controls.Add(panel);
			
			Label[] ReactsLabels = new Label[6];
			Label LikeLabel = new Label();
			Label LoveLabel = new Label();
			Label SadLabel = new Label();
			Label HahaLabel = new Label();
			Label WowLabel = new Label();
			Label AngryLabel = new Label();
			ReactsLabels[0] = LikeLabel;
			ReactsLabels[1] = LoveLabel;
			ReactsLabels[2] = SadLabel;
			ReactsLabels[3] = HahaLabel;
			ReactsLabels[4] = WowLabel;
			ReactsLabels[5] = AngryLabel;
			i = 0;
			foreach (var label in ReactsLabels)
			{
				label.Text = context.Reacts.Where(u => Post.Id == u.PostId && u.Reaction == (reaction)i).Count().ToString();
				panel.Controls.Add(label);
				label.Size = new Size(38, 15);
				label.Location = new(3 + i * 52, 186);
				label.Tag = i;
				i++;
			}
			LinkLabel CommentsLabel = new LinkLabel();
			panel.Controls.Add(CommentsLabel);
			CommentsLabel.LinkColor = Color.FromArgb(0x8C, 0x8C, 0x8C);
			CommentsLabel.Size = new Size(100, 15);
			CommentsLabel.Location = new(745, 142);
			CommentsLabel.LinkColor = Color.Black;
			CommentsLabel.Text = context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == Post.Id).Comments.Count().ToString() + "Comments ";
			var args = new EditEventArgs(Post.Id);
			CommentsLabel.Click += (s, e) => form.Comments_Click(s, args);
			CommentsLabel.Show();


			form.Controls.Add(panel);
			panel.BringToFront();
			return panel;
		}

	}
}
