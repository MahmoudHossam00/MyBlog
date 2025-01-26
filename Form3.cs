using Microsoft.EntityFrameworkCore;
using MyBlog.help;

//using Microsoft.VisualBasic.ApplicationServices;

//using //Microsoft.VisualBasic.ApplicationServices;

//using Microsoft.VisualBasic.ApplicationServices;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyBlog.Form2;

namespace MyBlog
{
	public partial class Form3 : Form
	{
		User _user { get; }
		MyBlogContext context = MyBlogContext.myBlogContext;

		bool IsViewForAdmins = false;
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
		public Form3(User user)
		{
			InitializeComponent();
			_user = user;
			
		}

		private void ComboBoxesSet()
		{
			UserForBanComboBox.DataSource = context.Users.ToList();
			UserForBanComboBox.ValueMember = "id";
			UserForBanComboBox.DisplayMember = "username";


			var RoleList = new[] { new{ role = Role.Admin, str = "Admin" },
									new{ role = Role.Moderator, str = "Moderator" },
									new{ role = Role.user, str = "user" }};

			ChooseRoleComboBox.DataSource = RoleList;
			ChooseRoleComboBox.ValueMember = "role";
			ChooseRoleComboBox.DisplayMember = "str";
			ChooseRoleComboBox.Hide();

			UserRoleComboBox.DataSource = context.Users.Select(u => new { u.UserName, u.Id }).ToList();
			UserRoleComboBox.ValueMember = "Id";
			UserRoleComboBox.DisplayMember = "UserName";
			GiveRoleButton.Hide();
		}
		private void Form3_Load(object sender, EventArgs e)
		{
			ViewForAdmin();
			CorrectDateLabel.Hide();

			ComboBoxesSet();
			//SetTextBox(BanReasonTextBox,"Ban Reason");
			Home.SetButton(0, 120, "Home");
			Home.BringToFront();
			ViewBan.SetSecondaryButton(ViewBan.Location.X, ViewBan.Location.Y, 100);
			BanButton.SetSecondaryButton(BanButton.Location.X, BanButton.Location.Y, 100);
			GiveRoleButton.SetSecondaryButton(GiveRoleButton.Location.X, GiveRoleButton.Location.Y, 100);
			button2.SetSecondaryButton(button2.Location.X, button2.Location.Y, 100);
			AllUsersButton.SetButton(AllUsersButton.Location.X, AllUsersButton.Location.Y, AllUsersButton.Text);
		}

		public static TextBox SetTextBox(TextBox textBox, string placeholder)
		{
			textBox.Size = new Size(200, 30);   // Set the size
												//textBox.Location = new Point(x, y);       // Set the position
			textBox.BackColor = Color.FromArgb(240, 240, 240); // Light grey background

			textBox.Font = new Font("Segoe UI", 12);  // Custom font

			// Remove the default border
			textBox.BorderStyle = BorderStyle.None;

			// Apply rounded corners
			textBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox.Width, textBox.Height, 20, 20));

			// Create a custom border using Paint event
			textBox.Paint += (sender, e) =>
			{
				ControlPaint.DrawBorder(e.Graphics, textBox.ClientRectangle, Color.FromArgb(0, 122, 204), ButtonBorderStyle.Solid);
			};

			// Optional: Add placeholder text (this requires handling text input)
			textBox.PlaceholderText = placeholder;
			textBox.ForeColor = Color.Gray;
			textBox.Font = new Font("Times New Roman", 14.25f, FontStyle.Italic);
			// Clear placeholder text on focus


			// Restore placeholder text if the user leaves the text box empty
			textBox.Leave += (sender, e) =>
			{
				if (string.IsNullOrEmpty(textBox.Text))
				{
					textBox.PlaceholderText = placeholder;
					textBox.ForeColor = Color.Gray;
				}
			};

			// Optional: Add mouse enter and leave events to change background color dynamically
			textBox.MouseEnter += (sender, e) =>
			{
				textBox.BackColor = Color.FromArgb(230, 230, 230); // Lighter grey when focused
			};

			textBox.MouseLeave += (sender, e) =>
			{
				textBox.BackColor = Color.FromArgb(240, 240, 240); // Original background
			};

			return textBox;
			// Add the TextBox to the form
			//this.Controls.Add(textBox);
		}





		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			if (dateTimePicker1.Value <= DateTime.Now)
			{
				CorrectDateLabel.Show();
			}
			else
			{
				CorrectDateLabel.Hide();
			}
		}
		private void ViewForAdmin()
		{
			ChooseRoleLabel.Hide();
			UsersDatagridView.DataSource = context.Users.ToList();
			BanReasonLabel.Show();
			AllUsersButton.Show();
			BanUntillLabel.Show();
			BanButton.Show();
			BanReasonTextBox.Show();
			CorrectDateLabel.Hide();
			ChooseUserLabel.Show();
			dateTimePicker1.Show();
			UserForBanComboBox.Show();
			UsersDatagridView.Show();
			UserRoleComboBox.Hide();
			ChooseRoleComboBox.Hide();
			Home.Text = "Home";
			ViewBan.Show();
			button2.Show();
			AllUsersButton.Text = "GiveRole";
			GiveModFlag = false;
			GiveRoleButton.Hide();
			RoleLabel.Hide();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var user = context.Users.Include(x => x.GotBanned).FirstOrDefault(x => x.Id == (int)UserForBanComboBox.SelectedValue);
			if (dateTimePicker1.Value <= DateTime.Now)
			{
				MessageBox.Show("Invalidi data entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if ((user.Role & Role.Admin) == Role.Admin)
			{
				MessageBox.Show("Can't Ban AN ADMIN", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (context.Bans.FirstOrDefault(x => x.BanneduserId == user.Id) is null)
			{
				var ban = new Bans()
				{
					BanReason = BanReasonTextBox.Text,
					BannedTill = dateTimePicker1.Value,
					BanningAdminId = _user.Id,
					BanneduserId = (int)UserForBanComboBox?.SelectedValue
				};
				context.Bans.Add(ban);
				context.SaveChanges();
				MessageBox.Show("Banned");
			}
			else
			{
				context.Bans.FirstOrDefault(x => x.BanneduserId == user.Id).BannedTill = dateTimePicker1.Value;
				context.SaveChanges();
				MessageBox.Show("Banned");
			}
			ViewForAdmin();
		}

		private void Home_Click(object sender, EventArgs e)
		{
			HomeForm homeForm = new HomeForm(_user);
			homeForm.Location = this.Location;
			this.Hide();
			homeForm.Show();

		}


		int chosenUserId = 0;
		static bool flag = false;
		static bool flag2 = false;
		private void SwitchBansButton_Click(object sender, EventArgs e)
		{
			if (flag)
			{
				flag = false;
				var user = context.Users.Include(x => x.GotBanned).ThenInclude(B => B.BanningAdmin).Where(x => x.Id == chosenUserId);
				UsersDatagridView.DataSource = "";
				UsersDatagridView.DataSource = user.FirstOrDefault().GotBanned.Select(x => new { BanningAdmin = x.BanningAdmin.UserName, x.BannedTill, x.BanReason, BannedUser = x.Banneduser.UserName }).ToList();
			}
			else
			{
				flag = true;
				var user = context.Users.Include(x => x.GaveBans).ThenInclude(B => B.Banneduser)
					.FirstOrDefault(x => x.Id == chosenUserId);
				UsersDatagridView.Show();
				UsersDatagridView.DataSource = "";
				UsersDatagridView.DataSource = user.GaveBans.Select(x => new { BannedUser = x.Banneduser.UserName, x.BannedTill, x.BanReason, BanningAdmin = x.BanningAdmin.UserName }).ToList();
			}
		}

		public static bool GiveModFlag = false;
		private void button1_Click_1(object sender, EventArgs e)
		{
			if (GiveModFlag == false)
			{
				GiveModFlag = true;
				ChooseRoleLabel.Show();
				AllUsersButton.Text = "Ban";
				BanUntillLabel.Hide();
				BanReasonTextBox.Hide();
				BanButton.Hide();
				button2.Hide();
				CorrectDateLabel.Hide();
				ChooseUserLabel.Hide();
				ChooseRoleComboBox.Show();
				dateTimePicker1.Hide();
				GiveRoleButton.Show();
				RoleLabel.Show();
				UserForBanComboBox.Hide();
				UserRoleComboBox.Show();
				ViewBan.Hide();
				BanReasonLabel.Hide();
				UsersDatagridView.DataSource = context.Users.Select(u => new {u.UserName,u.Role}).ToList();
			}
			else
			{
				ViewForAdmin();
			}
		}

		private void GiveRoleButton_Click_1(object sender, EventArgs e)
		{
			var usr = context.Users.FirstOrDefault(u => u.Id == (int)UserRoleComboBox.SelectedValue!);

			usr.Role |= ((Role)ChooseRoleComboBox.SelectedValue);
			context.Update(usr);
			context.SaveChanges();

			UsersDatagridView.DataSource = context.Users.Select(u => new { u.UserName, u.Role }).ToList();
		}

		private void ViewBan_Click(object sender, EventArgs e)
		{
			UsersDatagridView.DataSource = "";
			UsersDatagridView.DataSource = context.Bans.Include(b=>b.Banneduser).Include(b=>b.BanningAdmin).Where(b => b.BanneduserId == (int)UserForBanComboBox.SelectedValue).Select(b => new {
			BannedUser= b.Banneduser.UserName,BanningAdming=b.BanningAdmin.UserName,b.BannedTill,BanReason=b.BanReason}).ToList();

		}

		private void button2_Click(object sender, EventArgs e)
		{ 
			UsersDatagridView.DataSource = context.Users.ToList();
		}
	}
}
