using Microsoft.EntityFrameworkCore.Storage.Json;
using MyBlog.help;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyBlog
{
	public partial class Form2 : Form
	{
		#region globalproperties

		private bool[] ValidInputs = new bool[6];
		private bool[] ValidLogin = new bool[2];
		MyBlogContext context = MyBlogContext.myBlogContext;

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		#endregion

		public Form2()
		{
			InitializeComponent();

		}
		public static void SetButtonThird(Button button, int sizea, int sizeb, int pointa, int pointb, string text)
		{
			button.Text = text;
			button.Size = new Size(sizea, sizeb);  // Set the button size
			button.Location = new Point(pointa, pointb); // Set the position of the button
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.BackColor = Color.White; // Blue color
			button.ForeColor = Color.FromArgb(104, 195, 215);
			button.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular);
			button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 20, 20));
			button.MouseEnter += (sender, e) =>
			{
				button.BackColor = Color.FromArgb(104, 195, 215);
				button.ForeColor = Color.White;
			};
			button.MouseLeave += (sender, e) =>
			{
				button.BackColor = Color.White;
				button.ForeColor = Color.FromArgb(104, 195, 215);
			};
		}
		public static void SetTextBox(TextBox textBox, string placeholder)
		{
			textBox.Size = new Size(200, 30);
			textBox.BackColor = Color.FromArgb(255, 255, 255);
			textBox.ForeColor = Color.Black;
			textBox.Font = new Font("Segoe UI", 12);
			textBox.PlaceholderText = placeholder;
		}
		public static void SetLabel(Label label, int pointa, int pointb)
		{
			//linkLabel1.Location = new Point(linkLabel1.Location.X - 30, linkLabel1.Location.Y);
		}
		public static void SetLinkLabel(LinkLabel linklabel, int pointa, int pointb)
		{
			linklabel.Location = new Point(pointa, pointb);
			linklabel.BackColor = Color.Transparent;
			linklabel.LinkColor = Color.Black;
			linklabel.Font = new Font("Times New Roman", 12f, FontStyle.Italic);
			linklabel.MouseEnter += (sender, e) =>
			{
				linklabel.LinkColor = Color.DarkGray;
			};

			linklabel.MouseLeave += (sender, e) =>
			{
				linklabel.LinkColor = Color.Black;
			};
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			MyButton.SetButton( 0, 120, "Register");
			button1.SetButton( 0, 164, "Login");
			LoginButton.SetButton( LoginButton.Location.X + 35, LoginButton.Location.Y, "Login");
			RegisterButton.SetButton( RegisterButton.Location.X, RegisterButton.Location.Y, "Register");
			uploadbutton.SetButton( uploadbutton.Location.X, uploadbutton.Location.Y, "Upload", true, true);

			SetTextBox(FirstNameTextBox, "Enter Your First Name");
			SetTextBox(LastNameTextbox, "Enter Your Last Name");
			SetTextBox(AddressTextBox, "Enter Your Address ");
			SetTextBox(EmailTextBox, "Enter Your Email Name");


			SetTextBox(UserNameTextbox, "Enter Your UserName ");
			SetTextBox(PasswordTextBox, "Enter Your Password");
			SetTextBox(UserOrEmailTextBox, "Enter username or Email");
			SetTextBox(PasswordLoginTextBox, "Enter Your Password");

			SetLinkLabel(LoginLinkedLabel, LoginLinkedLabel.Location.X+10, LoginLinkedLabel.Location.Y-25);
			SetLinkLabel(linkLabel1, linkLabel1.Location.X - 30, linkLabel1.Location.Y-25);

			PasswordTextBox.PasswordChar = '*';
			PasswordTextBox.UseSystemPasswordChar = false;
			PasswordLoginTextBox.PasswordChar = '*';
			PasswordLoginTextBox.UseSystemPasswordChar = false;

			RegisterView();
		}



		private void MyButton_Click(object sender, EventArgs e)
		{
			RegisterView();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoginView();
		}



		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LoginView();
		}
		private void LoginView()
		{
			//SuspendLayout();

			FirstNameTextBox.Hide();
			LastNameTextbox.Hide();
			AddressTextBox.Hide();
			EmailTextBox.Hide();
			UserNameTextbox.Hide();
			PasswordTextBox.Hide();
			linkLabel1.Hide();
			RegisterButton.Hide();
			uploadbutton.Hide();
			PFPicturebox.Hide();

			LoginButton.Show();
			LoginLinkedLabel.Show();
			UserOrEmailTextBox.Show();
			PasswordLoginTextBox.Show();

			var list = this.Controls.OfType<Label>().Where(lbl => (
			lbl.Name == "PasswordLab" || lbl.Name == "FirstNamelab" ||
			lbl.Name == "AddressLab" || lbl.Name == "UserNameLab" ||
			lbl.Name == "LastNameLab" || lbl.Name == "EmailLab"));
			foreach (var lab in list)
			{
			lab.Hide();
			}
		}
		private void RegisterView()
		{
			//SuspendLayout();

			FirstNameTextBox.Show();
			LastNameTextbox.Show();
			AddressTextBox.Show();
			EmailTextBox.Show();
			UserNameTextbox.Show();
			PasswordTextBox.Show();

			PFPicturebox.Show();
			uploadbutton.Show();

			linkLabel1.Show();

			RegisterButton.Show();

			LoginButton.Hide();
			LoginLinkedLabel.Hide();
			UserOrEmailTextBox.Hide();
			PasswordLoginTextBox.Hide();


		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			bool flag = false;
			foreach (bool x in ValidInputs)
			{
				if (x == false)
				{
					flag = true;
				}
			}
			if (flag == true)
			{
				MessageBox.Show("Incorrect Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{

				User usr = new User()
				{
					FirstName = FirstNameTextBox.Text.ToString(),
					LastName = LastNameTextbox.Text.ToString(),
					Email = EmailTextBox.Text.ToString(),
					UserName = UserNameTextbox.Text.ToString(),
					password = PasswordTextBox.Text.ToString(),
					Address = AddressTextBox.Text.ToString()
				};
				if (PFPicturebox.Image != null)
				{
					using (MemoryStream ms = new MemoryStream())
					{
						PFPicturebox.Image.Save(ms, PFPicturebox.Image.RawFormat);
						byte[] ImgByteArray = ms.ToArray();
						usr.Picture = ImgByteArray;
					}
				}
				else
				{
					usr.Picture = null;
				}

				context.Users.Add(usr);
				context.SaveChanges();
				RedirectToHomeForm(usr);


			}
		}
		private void RedirectToHomeForm(User user)
		{
			HomeForm form = new HomeForm(user);
			//form.StartPosition = FormStartPosition.Manual;
			form.Location = this.Location;
			//form.Size = this.Size;
			this.Hide(); ;
			form.Show();
		}
		private void LoginButton_Click(object sender, EventArgs e)
		{
			var text = UserOrEmailTextBox.Text.ToString();
			var flag = false;
			if (context?.Users.FirstOrDefault(x => x.UserName.ToLower() == text.ToLower() || x.Email.ToLower() == text.ToLower()) is not null)
			{
				User user = context?.Users.FirstOrDefault(x => x.UserName.ToLower() == text.ToLower() || x.Email.ToLower() == text.ToLower())!;
				if (user.password == PasswordLoginTextBox.Text.ToString())
				{
					RedirectToHomeForm(user);
				}
				else
				{
					flag = true;
					MessageBox.Show("Invalid username/password\n combination", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Invalid username/password\n combination", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#region ChecksHelpers
		private bool ConsistsOfCharacters(string str)
		{
			foreach (char c in str)
			{
				if (!Char.IsLetter(c))
				{
					return false;
				}
			}
			return true;
		}
		private bool ConsistsOfCharactersAndNumbers(string str)
		{
			foreach (char c in str)
			{
				if (!Char.IsLetter(c) && !int.TryParse(c.ToString(), out int x) && c != ',' && c != '.' && c != ' ')
				{
					return false;
				}
			}
			return true;
		}
		#endregion

		#region Checks
		private void SetErrorLabel(Label label,int pointa,int pointb)
		{
			label.Size = new Size(300, 25);
			label.BackColor = Color.Transparent;
			label.ForeColor = Color.Red;
			label.Location = new Point(pointa, pointb);
		}
		private void FirstNameTextBox_Leave(object sender, EventArgs e)
		{
			Label FirstNamelab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "FirstNamelab");

			if (FirstNamelab == null)
			{
				// Create the label if it doesn't exist
				FirstNamelab = new Label();
				FirstNamelab.Name = "FirstNamelab"; // Assign a name to the label to identify it later
				FirstNamelab.Text = "Only characters Allowed ";
				SetErrorLabel(FirstNamelab, FirstNameTextBox.Location.X, FirstNameTextBox.Location.Y + FirstNameTextBox.Height + 5);
				this.Controls.Add(FirstNamelab);
			}
			if (!ConsistsOfCharacters(FirstNameTextBox.Text) || FirstNameTextBox.Text.Length < 3)
			{
				ValidInputs[0] = false;
				FirstNamelab.Show();
			}
			else
			{
				FirstNamelab.Hide();
				ValidInputs[0] = true;
			}
			FirstNamelab.BringToFront();
		}

		private void LastNameTextbox_Leave(object sender, EventArgs e)
		{
			Label LastNameLab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "LastNameLab");

			if (LastNameLab == null)
			{
				// Create the label if it doesn't exist
				LastNameLab = new Label();
				LastNameLab.Name = "LastNameLab"; // Assign a name to the label to identify it later
				LastNameLab.Text = "Only characters Allowed";
				SetErrorLabel(LastNameLab, LastNameTextbox.Location.X, LastNameTextbox.Location.Y + LastNameTextbox.Height + 5);
				this.Controls.Add(LastNameLab); // Add the label to the form
			}
			if (!ConsistsOfCharacters(LastNameTextbox.Text) || LastNameTextbox.Text.Length < 3)
			{
				ValidInputs[1] = false;
				LastNameLab.Show();
			}
			else
			{
				LastNameLab.Hide();
				ValidInputs[1] = true;
			}
			LastNameLab.BringToFront();
		}

		private void AddressTextBox_Leave(object sender, EventArgs e)
		{
			Label AddressLab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "AddressLab");

			if (AddressLab == null)
			{
				// Create the label if it doesn't exist
				AddressLab = new Label();
				AddressLab.Name = "AddressLab"; // Assign a name to the label to identify it later
				AddressLab.Text = "Only use characters,letters";
				SetErrorLabel(AddressLab, AddressTextBox.Location.X, AddressTextBox.Location.Y + FirstNameTextBox.Height + 5);
				this.Controls.Add(AddressLab); // Add the label to the form
				
			}
			if (!ConsistsOfCharactersAndNumbers(AddressTextBox.Text) || AddressTextBox.Text.Length < 3)
			{
				ValidInputs[2] = false;
				AddressLab.Show();
			}
			else
			{
				AddressLab.Hide();
				ValidInputs[2] = true;
			}
			AddressLab.BringToFront();
		}

		private void UserNameTextbox_Leave(object sender, EventArgs e)
		{
			Label UserNameLab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "UserNameLab");

			if (UserNameLab == null || UserNameLab.Text == string.Empty)
			{
				// Create the label if it doesn't exist
				UserNameLab = new Label();
				UserNameLab.Name = "UserNameLab"; // Assign a name to the label to identify it later
				SetErrorLabel(UserNameLab, UserNameTextbox.Location.X, UserNameTextbox.Location.Y + FirstNameTextBox.Height + 5);
				this.Controls.Add(UserNameLab); // Add the label to the form
			}
			if (context.Users?.FirstOrDefault(x => x.UserName == UserNameTextbox.Text) is not null)
			{
				UserNameLab.Text = "UserName Exists";
				ValidInputs[3] = false;
				UserNameLab.Show();
			}
			else if (UserNameTextbox.Text.Length < 5 || UserNameTextbox.Text == string.Empty)
			{
				UserNameLab.Text = "Invalid Username";
				ValidInputs[3] = false;
				UserNameLab.Show();
			}
			else
			{
				UserNameLab.Hide();
				ValidInputs[3] = true;
			}
			UserNameLab.BringToFront();
		}

		private void EmailTextBox_Leave(object sender, EventArgs e)
		{
			Label EmailLab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "EmailLab");

			if (EmailLab == null)
			{
				// Create the label if it doesn't exist
				EmailLab = new Label();
				EmailLab.Name = "EmailLab"; // Assign a name to the label to identify it later
				SetErrorLabel(EmailLab, EmailTextBox.Location.X, EmailTextBox.Location.Y + FirstNameTextBox.Height + 5);
				this.Controls.Add(EmailLab); // Add the label to the form
			}

			if (context.Users?.FirstOrDefault(x => x.Email == EmailTextBox.Text) is not null)
			{
				EmailLab.Text = "Email Exists";
				ValidInputs[4] = false;
				EmailLab.Show();
			}
			else if (!EmailTextBox.Text.EndsWith(".com") || !EmailTextBox.Text.Contains("@") || EmailTextBox.Text.Length < 5)
			{

				EmailLab.Text = "invalid email";
				ValidInputs[4] = false;
				EmailLab.Show();
			}
			else
			{
				EmailLab.Hide();
				ValidInputs[4] = true;
			}
			EmailLab.BringToFront();

		}

		private void PasswordTextBox_Leave(object sender, EventArgs e)
		{

			Label PasswordLab = this.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name == "PasswordLab");

			if (PasswordLab == null)
			{
				// Create the label if it doesn't exist
				PasswordLab = new Label();
				PasswordLab.Name = "PasswordLab"; // Assign a name to the label to identify it later
				PasswordLab.Text = "invalid Password, more than 8";
				SetErrorLabel(PasswordLab, PasswordTextBox.Location.X, PasswordTextBox.Location.Y + FirstNameTextBox.Height + 5);
				this.Controls.Add(PasswordLab); // Add the label to the form
			}
			if (PasswordTextBox.Text.Length < 8)
			{

				PasswordLab.Show();
				ValidInputs[5] = false;
			}
			else
			{
				PasswordLab.Hide();
				PasswordLab = null;
				ValidInputs[5] = true;
			}
		}

		#endregion

		private void LoginLinkedLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RegisterView();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					PFPicturebox.Image = Image.FromFile(openFileDialog.FileName);
					PFPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
					PFPicturebox.Tag = openFileDialog.FileName;
				}
			}
		}
	}
}
