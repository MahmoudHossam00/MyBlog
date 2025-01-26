using MyBlog.help;
using MyBlog.Migrations;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBlog
{
	public partial class VisitProfileForm : Form
	{
		private User _user;
		private MyBlogContext context = MyBlogContext.myBlogContext;
		int _profileId;
		Panel[] PostPanel = new Panel[3];
		int PostCurrent = 0;
		int NumOfPostsPages;
		PictureBox[] Emojis = new PictureBox[18];
		Label[] EmojisNumbers = new Label[18];
		Post[] UsedPosts = new Post[3];
		private EventHandler[] handlers = new EventHandler[9];
		public VisitProfileForm(User user, int ProfileId)
		{
			InitializeComponent();
			_user = user;
			_profileId = ProfileId;
		}

		private void VisitProfileForm_Load(object sender, EventArgs e)
		{
			this.Text = context.Users.FirstOrDefault(x => x.Id == _profileId)?.UserName + "'s Profile";

			GoBackButton1.SetButton(0, 120, "GoBack");
			#region CheckForFollowStatus
			if (context.Follows?.FirstOrDefault(f => ((f.FollowedId == _profileId) && (f.FollowerId == _user.Id))) is null)
			{
				FollowButton1.Text = "Follow";
			}
			else
			{
				FollowButton1.Text = "UnFollow";
			}

			if (_user.Id == _profileId)
			{
				FollowButton1.Hide();
			}
			#endregion

			PostPanel[0] = PostPanel1;
			PostPanel[1] = PostPanel2;
			PostPanel[2] = PostPanel3;

			NumOfPostsPages = ((int)Math.Ceiling((context.Posts.Where(c => c.PublisherId == _profileId).Count()) / 3.0f));

			UserNameLabel1.Text = context.Users.FirstOrDefault(u => u.Id == _profileId)?.UserName;
			UserNameLabel1.setUserName(200, 30);

			var Img = context.Users.FirstOrDefault(u => u.Id == _profileId)?.Picture;
			ProfilePictureBox3.SetProfilePicture(Img);



			VisitPost1.SetSecondaryButton();
			VisitPost2.SetSecondaryButton();
			VisitPost3.SetSecondaryButton();

			FollowButton1.SetButton(FollowButton1.Location.X, FollowButton1.Location.Y, FollowButton1.Text);

			Post1Content.EditRichTextBox();
			Post2Content.EditRichTextBox();
			Post3content.EditRichTextBox();

			UserNameLabel1.BigUserName();
			PostPublisherLabel1.UserName();
			PostPublisherLabel2.UserName();
			PostPublisherLabel3.UserName();


			#region Emojis SettingRegion

			#region Emojis
			Emojis[0] = LikeBox;
			Emojis[1] = LoveBox;
			Emojis[2] = SadBox;
			Emojis[3] = HahaBox;
			Emojis[4] = WowBox;
			Emojis[5] = AngryBox;

			Emojis[6] = LikeBox2;
			Emojis[7] = LoveBox2;
			Emojis[8] = SadBox2;
			Emojis[9] = HahaBox2;
			Emojis[10] = WowBox2;
			Emojis[11] = AngryBox2;

			Emojis[12] = LikeBox3;
			Emojis[13] = LoveBox3;
			Emojis[14] = SadBox3;
			Emojis[15] = HahaBox3;
			Emojis[16] = WowBox3;
			Emojis[17] = AngryBox3;
			#endregion

			#region Labels
			EmojisNumbers[0] = LikesNum;
			EmojisNumbers[1] = LoveNum;
			EmojisNumbers[2] = SadNum;
			EmojisNumbers[3] = HahaNum;
			EmojisNumbers[4] = WowNum;
			EmojisNumbers[5] = AngryNum;

			EmojisNumbers[6] = LikesNum2;
			EmojisNumbers[7] = LoveNum2;
			EmojisNumbers[8] = SadNum2;
			EmojisNumbers[9] = HahaNum2;
			EmojisNumbers[10] = WowNum2;
			EmojisNumbers[11] = AngryNum2;

			EmojisNumbers[12] = LikesNum3;
			EmojisNumbers[13] = LoveNum3;
			EmojisNumbers[14] = SadNum3;
			EmojisNumbers[15] = HahaNum3;
			EmojisNumbers[16] = WowNum3;
			EmojisNumbers[17] = AngryNum3;
			#endregion
			for (int i = 0; i <= 17; i++)
			{
				Emojis[i].Tag = i;
				Emojis[i].Click += HandleAddingReact;
			}

			#endregion
			//PictureBox[] First6 = this. Emojis.Take(6).ToArray();

			PreviousPagePosts.Hide();
			SetNexPage();
			LoadPosts();

		}
		private void HandleAddingReact(object sender, EventArgs e)
		{
			if (sender is PictureBox box)
			{
				int ReactsOfApost = ((int)box.Tag) / 6;
				var LowYposition =
					Emojis[ReactsOfApost * 6 + 0].Location.Y < Emojis[ReactsOfApost * 6 + 1].Location.Y ? Emojis[ReactsOfApost * 6 + 1].Location.Y : Emojis[ReactsOfApost * 6 + 0].Location.Y;
				//int Postnum = (int)box.Tag / 6;
				int PostId = UsedPosts[ReactsOfApost].Id;
				var React = context.Reacts.FirstOrDefault(R => R.UserId == _user.Id && R.PostId == PostId);
				if (React == null)
				{
					var React2 = new React
					{
						UserId = _user.Id,
						PostId = PostId,
						Reaction = (reaction)((int)box.Tag - ReactsOfApost * 6)
					};
					context.Reacts.Add(React2);
				}
				else if (LowYposition == box.Location.Y)
				{

					React.Reaction = (reaction)((int)box.Tag - ReactsOfApost * 6);
					context.Reacts.Update(React);
				}
				else
				{
					context.Reacts.Remove(React);
				}

				context.SaveChanges();
				LoadPosts();

			}



		}
		private void SetNexPage()
		{
			NumOfPostsPages = ((int)Math.Ceiling((context.Posts.Where(c => c.PublisherId == _profileId).Count()) / 3.0f));
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
			EditDesignerPostStuff(0, PostPublisherLabel1, Post1picturebox, Post1Content, Publisher1PictureBox, ref DeletePost1, ref VisitPost1, ref button1);
			EditDesignerPostStuff(1, PostPublisherLabel2, Post2picturebox, Post2Content, Publisher2PictureBox, ref DeletePost2, ref VisitPost2, ref EditPost2);
			EditDesignerPostStuff(2, PostPublisherLabel3, Post3picturebox, Post3content, Publisher3PictureBox, ref DeletePost3, ref VisitPost3, ref EditPost3);

			foreach (var emoji in Emojis)
			{
				emoji.BringToFront();
			}
			foreach (var emoji in EmojisNumbers)
			{
				emoji.BringToFront();
			}
			DeletePost1.BringToFront();
			button1.BringToFront();
			VisitPost1.BringToFront();
			DeletePost2.BringToFront();
			EditPost2.BringToFront();
			VisitPost2.BringToFront();
			DeletePost3.BringToFront();
			EditPost3.BringToFront();
			VisitPost3.BringToFront();
			Publisher1PictureBox.BringToFront();
			Publisher2PictureBox.BringToFront();
			Publisher3PictureBox.BringToFront();
			Post1picturebox.BringToFront();
			Post2picturebox.BringToFront();
			Post3picturebox.BringToFront();
			Post1Content.BringToFront();
			Post2Content.BringToFront();
			Post3content.BringToFront();
		}
		public void EditDesignerPostStuff(int index, Label UserName, PictureBox CommentPicture12, RichTextBox Comment12Textbox, PictureBox COMMENT12PFP, ref Button myDeleteButton, ref Button VisitButton, ref Button EditButton)
		{


			var Post = context.Posts.Where(c => c.PublisherId == _profileId).OrderByDescending(c => c.CreationDate).Skip(3 * PostCurrent + index).FirstOrDefault();
			UsedPosts[index] = Post;
			var user = context.Users.FirstOrDefault(C => C.Id == _profileId);


			if (Post == null)
			{
				PostPanel[index].Hide();
			}
			else
			{
				PostPanel[index].Show();

				CommentPicture12.SetPostPicture(Post.Picture);
				Comment12Textbox.Text = Post.Content;

				UserName.Text = user.UserName;

				var pfp = user.Picture;
				COMMENT12PFP.SetProfilePicture(pfp);



				#region Handling previous events
				PostEventArgs args = new PostEventArgs(Post.Id);
				if (handlers[index * 3] != null)
				{
					myDeleteButton.Click -= handlers[index * 3];
				}
				handlers[index * 3] = (s, e) => DeletePostClicked(s, args);
				myDeleteButton.Click += handlers[index * 3];



				if (handlers[index * 3 + 1] != null)
				{
					VisitButton.Click -= handlers[index * 3 + 1];
				}
				handlers[index * 3 + 1] = (s, e) => VisitPostPress(s, args);
				VisitButton.Click += handlers[index * 3 + 1];


				if (handlers[index * 3 + 2] != null)
				{
					EditButton.Click -= handlers[index * 3 + 2];
				}
				handlers[index * 3 + 2] = (s, e) => EditPostPressed(s, args);
				EditButton.Click += handlers[index * 3 + 2];
				#endregion


				this.HandleEmojisForForms(Emojis.Skip(6 * index).Take(6).ToArray(), EmojisNumbers.Skip(6 * index).Take(6).ToArray(), _user.Id, UsedPosts[index].Id);
			}


		}


		private void DeletePostClicked(object sender, PostEventArgs args)
		{
			if (_user.Id == _profileId || _user.Role >= Role.Moderator)
			{
				var PostToBeDELETED = context.Posts.SingleOrDefault(c => c.Id == args._PostId);
				if (PostToBeDELETED is not null)
				{
					context.Posts.Remove(PostToBeDELETED);
					context.SaveChanges();
					LoadPosts();
				}
			}
			else
			{
				MessageBox.Show("Onlyy for admins and post owner");
			}
		}
		private void VisitPostPress(object sender, PostEventArgs args)
		{

			Form5 form = new Form5(_user, args._PostId);
			form.Location = this.Location;
			this.Hide();
			form.Show();
		}
		private void EditPostPressed(object sender, PostEventArgs args)
		{
			if (_user.Id == _profileId)
			{
				//var PostToBeEdited = context.Posts.SingleOrDefault(c => c.Id == args._PostId);
				HomeForm form = new HomeForm(_user, args._PostId);
				//form.Size = this.Size;
				form.Location = this.Location;
				this.Hide();
				form.Show();
			}
			else
			{
				MessageBox.Show("Onlyy Author can edit the post ");
			}
		}
		private void FollowButton1_Click(object sender, EventArgs e)
		{
			if (FollowButton1.Text == "Follow")
			{
				FollowButton1.Text = "UnFollow";
				Follow follow = new Follow();
				follow.FollowerId = _user.Id;
				follow.FollowedId = _profileId;
				context.Follows.Add(follow);
				context.SaveChanges();

			}
			else
			{
				FollowButton1.Text = "Follow";
				context.Follows.Remove(
					context.Follows?.FirstOrDefault(f => ((f.FollowedId == _profileId) && (f.FollowerId == _user.Id)))!);
				context.SaveChanges();

			}
		}

		private void GoBackButton1_Click(object sender, EventArgs e)
		{
			HomeForm form = new(_user);
			//form.Size = this.Size;
			form.Location = this.Location;
			this.Hide();
			form.Show();
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

	
	}
}
