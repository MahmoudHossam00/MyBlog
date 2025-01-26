namespace MyBlog
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			MyButton = new Button();
			button1 = new Button();
			FirstNameTextBox = new TextBox();
			LastNameTextbox = new TextBox();
			AddressTextBox = new TextBox();
			UserNameTextbox = new TextBox();
			EmailTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			RegisterButton = new Button();
			linkLabel1 = new LinkLabel();
			LoginButton = new Button();
			LoginLinkedLabel = new LinkLabel();
			UserOrEmailTextBox = new TextBox();
			PasswordLoginTextBox = new TextBox();
			uploadbutton = new Button();
			PFPicturebox = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)PFPicturebox).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.FromArgb(224, 224, 224);
			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
			pictureBox1.ErrorImage = null;
			pictureBox1.InitialImage = Properties.Resources._2;
			pictureBox1.Location = new Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(133, 736);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Image = Properties.Resources._3;
			pictureBox2.Location = new Point(0, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(133, 120);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			// 
			// MyButton
			// 
			MyButton.BackColor = Color.Red;
			MyButton.BackgroundImageLayout = ImageLayout.Stretch;
			MyButton.Cursor = Cursors.Hand;
			MyButton.Location = new Point(0, 118);
			MyButton.Name = "MyButton";
			MyButton.Size = new Size(133, 65);
			MyButton.TabIndex = 2;
			MyButton.Text = "button1";
			MyButton.UseVisualStyleBackColor = false;
			MyButton.Click += MyButton_Click;
			// 
			// button1
			// 
			button1.BackColor = Color.Red;
			button1.BackgroundImageLayout = ImageLayout.Stretch;
			button1.Cursor = Cursors.Hand;
			button1.Location = new Point(0, 189);
			button1.Name = "button1";
			button1.Size = new Size(133, 65);
			button1.TabIndex = 3;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// FirstNameTextBox
			// 
			FirstNameTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			FirstNameTextBox.Location = new Point(266, 185);
			FirstNameTextBox.Name = "FirstNameTextBox";
			FirstNameTextBox.Size = new Size(112, 29);
			FirstNameTextBox.TabIndex = 4;
			FirstNameTextBox.Leave += FirstNameTextBox_Leave;
			// 
			// LastNameTextbox
			// 
			LastNameTextbox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			LastNameTextbox.Location = new Point(612, 185);
			LastNameTextbox.Name = "LastNameTextbox";
			LastNameTextbox.Size = new Size(112, 29);
			LastNameTextbox.TabIndex = 5;
			LastNameTextbox.Leave += LastNameTextbox_Leave;
			// 
			// AddressTextBox
			// 
			AddressTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			AddressTextBox.Location = new Point(266, 256);
			AddressTextBox.Name = "AddressTextBox";
			AddressTextBox.Size = new Size(112, 29);
			AddressTextBox.TabIndex = 6;
			AddressTextBox.Leave += AddressTextBox_Leave;
			// 
			// UserNameTextbox
			// 
			UserNameTextbox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			UserNameTextbox.Location = new Point(612, 256);
			UserNameTextbox.Name = "UserNameTextbox";
			UserNameTextbox.Size = new Size(112, 29);
			UserNameTextbox.TabIndex = 7;
			UserNameTextbox.Leave += UserNameTextbox_Leave;
			// 
			// EmailTextBox
			// 
			EmailTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			EmailTextBox.Location = new Point(266, 330);
			EmailTextBox.Name = "EmailTextBox";
			EmailTextBox.Size = new Size(112, 29);
			EmailTextBox.TabIndex = 8;
			EmailTextBox.Leave += EmailTextBox_Leave;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			PasswordTextBox.Location = new Point(612, 330);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.Size = new Size(112, 29);
			PasswordTextBox.TabIndex = 9;
			PasswordTextBox.Leave += PasswordTextBox_Leave;
			// 
			// RegisterButton
			// 
			RegisterButton.BackColor = Color.FromArgb(192, 255, 192);
			RegisterButton.BackgroundImageLayout = ImageLayout.Stretch;
			RegisterButton.Cursor = Cursors.Hand;
			RegisterButton.FlatAppearance.BorderSize = 2;
			RegisterButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			RegisterButton.Location = new Point(680, 499);
			RegisterButton.Name = "RegisterButton";
			RegisterButton.Size = new Size(133, 65);
			RegisterButton.TabIndex = 10;
			RegisterButton.Text = "button2";
			RegisterButton.UseVisualStyleBackColor = false;
			RegisterButton.Click += RegisterButton_Click;
			// 
			// linkLabel1
			// 
			linkLabel1.ActiveLinkColor = Color.White;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(708, 567);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(111, 15);
			linkLabel1.TabIndex = 11;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Already A member?";
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// LoginButton
			// 
			LoginButton.BackColor = Color.FromArgb(192, 255, 192);
			LoginButton.BackgroundImageLayout = ImageLayout.Stretch;
			LoginButton.Cursor = Cursors.Hand;
			LoginButton.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LoginButton.Location = new Point(473, 402);
			LoginButton.Name = "LoginButton";
			LoginButton.Size = new Size(133, 65);
			LoginButton.TabIndex = 13;
			LoginButton.Text = "button2";
			LoginButton.UseVisualStyleBackColor = false;
			LoginButton.Click += LoginButton_Click;
			// 
			// LoginLinkedLabel
			// 
			LoginLinkedLabel.ActiveLinkColor = Color.White;
			LoginLinkedLabel.AutoSize = true;
			LoginLinkedLabel.Location = new Point(512, 473);
			LoginLinkedLabel.Name = "LoginLinkedLabel";
			LoginLinkedLabel.Size = new Size(84, 15);
			LoginLinkedLabel.TabIndex = 14;
			LoginLinkedLabel.TabStop = true;
			LoginLinkedLabel.Text = "New Member?";
			LoginLinkedLabel.LinkClicked += LoginLinkedLabel_LinkClicked;
			// 
			// UserOrEmailTextBox
			// 
			UserOrEmailTextBox.Location = new Point(482, 220);
			UserOrEmailTextBox.Name = "UserOrEmailTextBox";
			UserOrEmailTextBox.Size = new Size(112, 23);
			UserOrEmailTextBox.TabIndex = 15;
			// 
			// PasswordLoginTextBox
			// 
			PasswordLoginTextBox.Location = new Point(482, 294);
			PasswordLoginTextBox.Name = "PasswordLoginTextBox";
			PasswordLoginTextBox.Size = new Size(112, 23);
			PasswordLoginTextBox.TabIndex = 16;
			// 
			// uploadbutton
			// 
			uploadbutton.BackColor = Color.FromArgb(192, 255, 192);
			uploadbutton.FlatAppearance.BorderSize = 3;
			uploadbutton.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
			uploadbutton.Location = new Point(266, 402);
			uploadbutton.Name = "uploadbutton";
			uploadbutton.Size = new Size(131, 31);
			uploadbutton.TabIndex = 17;
			uploadbutton.Text = "UploadPic";
			uploadbutton.UseVisualStyleBackColor = false;
			uploadbutton.Click += button2_Click;
			// 
			// PFPicturebox
			// 
			PFPicturebox.BackColor = Color.Transparent;
			PFPicturebox.Location = new Point(266, 456);
			PFPicturebox.Name = "PFPicturebox";
			PFPicturebox.Size = new Size(131, 67);
			PFPicturebox.TabIndex = 18;
			PFPicturebox.TabStop = false;
			// 
			// Form2
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(979, 743);
			Controls.Add(PFPicturebox);
			Controls.Add(uploadbutton);
			Controls.Add(PasswordLoginTextBox);
			Controls.Add(UserOrEmailTextBox);
			Controls.Add(LoginLinkedLabel);
			Controls.Add(LoginButton);
			Controls.Add(linkLabel1);
			Controls.Add(RegisterButton);
			Controls.Add(PasswordTextBox);
			Controls.Add(EmailTextBox);
			Controls.Add(UserNameTextbox);
			Controls.Add(AddressTextBox);
			Controls.Add(LastNameTextbox);
			Controls.Add(FirstNameTextBox);
			Controls.Add(button1);
			Controls.Add(MyButton);
			Controls.Add(pictureBox2);
			Controls.Add(pictureBox1);
			Name = "Form2";
			Text = "Register/Login";
			Load += Form2_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)PFPicturebox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private Button MyButton;
		private Button button1;
		private TextBox FirstNameTextBox;
		private TextBox LastNameTextbox;
		private TextBox AddressTextBox;
		private TextBox UserNameTextbox;
		private TextBox EmailTextBox;
		private TextBox PasswordTextBox;
		private Button RegisterButton;
		private LinkLabel linkLabel1;
		private Button LoginButton;
		private LinkLabel LoginLinkedLabel;
		private TextBox UserOrEmailTextBox;
		private TextBox PasswordLoginTextBox;
		private Button uploadbutton;
		private PictureBox PFPicturebox;
	}
}