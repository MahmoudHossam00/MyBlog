namespace MyBlog
{
	partial class Form3
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
			Home = new Button();
			UsersDatagridView = new DataGridView();
			dateTimePicker1 = new DateTimePicker();
			BanUntillLabel = new Label();
			BanButton = new Button();
			CorrectDateLabel = new Label();
			UserForBanComboBox = new ComboBox();
			BanReasonTextBox = new TextBox();
			ChooseUserLabel = new Label();
			AllUsersButton = new Button();
			UserRoleComboBox = new ComboBox();
			RoleLabel = new Label();
			ChooseRoleComboBox = new ComboBox();
			GiveRoleButton = new Button();
			ViewBan = new Button();
			button2 = new Button();
			pictureBox2 = new PictureBox();
			pictureBox1 = new PictureBox();
			BanReasonLabel = new Label();
			ChooseRoleLabel = new Label();
			((System.ComponentModel.ISupportInitialize)UsersDatagridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// Home
			// 
			Home.Location = new Point(12, 137);
			Home.Name = "Home";
			Home.Size = new Size(75, 23);
			Home.TabIndex = 0;
			Home.Text = "button1";
			Home.UseVisualStyleBackColor = true;
			Home.Click += Home_Click;
			// 
			// UsersDatagridView
			// 
			UsersDatagridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			UsersDatagridView.Location = new Point(140, 293);
			UsersDatagridView.Name = "UsersDatagridView";
			UsersDatagridView.Size = new Size(990, 316);
			UsersDatagridView.TabIndex = 2;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			dateTimePicker1.Location = new Point(400, 109);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(225, 29);
			dateTimePicker1.TabIndex = 4;
			dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
			// 
			// BanUntillLabel
			// 
			BanUntillLabel.AutoSize = true;
			BanUntillLabel.BackColor = Color.Transparent;
			BanUntillLabel.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			BanUntillLabel.ForeColor = Color.Black;
			BanUntillLabel.Location = new Point(140, 117);
			BanUntillLabel.Name = "BanUntillLabel";
			BanUntillLabel.Size = new Size(70, 17);
			BanUntillLabel.TabIndex = 5;
			BanUntillLabel.Text = "BanUntill";
			// 
			// BanButton
			// 
			BanButton.BackColor = Color.FromArgb(106, 195, 211);
			BanButton.Font = new Font("Segoe UI", 12F);
			BanButton.Location = new Point(400, 205);
			BanButton.Name = "BanButton";
			BanButton.Size = new Size(95, 35);
			BanButton.TabIndex = 6;
			BanButton.Text = "Ban";
			BanButton.UseVisualStyleBackColor = false;
			BanButton.Click += button1_Click;
			// 
			// CorrectDateLabel
			// 
			CorrectDateLabel.AutoSize = true;
			CorrectDateLabel.BackColor = Color.Transparent;
			CorrectDateLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			CorrectDateLabel.ForeColor = Color.Red;
			CorrectDateLabel.Location = new Point(634, 111);
			CorrectDateLabel.Name = "CorrectDateLabel";
			CorrectDateLabel.Size = new Size(166, 21);
			CorrectDateLabel.TabIndex = 7;
			CorrectDateLabel.Text = "Enter A correct Date";
			// 
			// UserForBanComboBox
			// 
			UserForBanComboBox.BackColor = Color.White;
			UserForBanComboBox.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
			UserForBanComboBox.FormattingEnabled = true;
			UserForBanComboBox.Location = new Point(400, 67);
			UserForBanComboBox.Name = "UserForBanComboBox";
			UserForBanComboBox.Size = new Size(225, 27);
			UserForBanComboBox.TabIndex = 8;
			// 
			// BanReasonTextBox
			// 
			BanReasonTextBox.BackColor = Color.White;
			BanReasonTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			BanReasonTextBox.ForeColor = Color.Black;
			BanReasonTextBox.Location = new Point(400, 158);
			BanReasonTextBox.Name = "BanReasonTextBox";
			BanReasonTextBox.Size = new Size(225, 29);
			BanReasonTextBox.TabIndex = 9;
			// 
			// ChooseUserLabel
			// 
			ChooseUserLabel.AutoSize = true;
			ChooseUserLabel.BackColor = Color.Transparent;
			ChooseUserLabel.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ChooseUserLabel.ForeColor = Color.Black;
			ChooseUserLabel.Location = new Point(140, 74);
			ChooseUserLabel.Name = "ChooseUserLabel";
			ChooseUserLabel.Size = new Size(220, 17);
			ChooseUserLabel.TabIndex = 10;
			ChooseUserLabel.Text = "Choose User To Ban or viewban";
			// 
			// AllUsersButton
			// 
			AllUsersButton.BackColor = Color.FromArgb(106, 195, 211);
			AllUsersButton.Font = new Font("Segoe UI", 12F);
			AllUsersButton.ForeColor = SystemColors.ControlText;
			AllUsersButton.Location = new Point(1004, 7);
			AllUsersButton.Name = "AllUsersButton";
			AllUsersButton.Size = new Size(150, 47);
			AllUsersButton.TabIndex = 13;
			AllUsersButton.Text = "GiveRole/BanUser";
			AllUsersButton.UseVisualStyleBackColor = false;
			AllUsersButton.Click += button1_Click_1;
			// 
			// UserRoleComboBox
			// 
			UserRoleComboBox.BackColor = Color.White;
			UserRoleComboBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			UserRoleComboBox.FormattingEnabled = true;
			UserRoleComboBox.Location = new Point(861, 70);
			UserRoleComboBox.Name = "UserRoleComboBox";
			UserRoleComboBox.Size = new Size(225, 29);
			UserRoleComboBox.TabIndex = 14;
			// 
			// RoleLabel
			// 
			RoleLabel.AutoSize = true;
			RoleLabel.BackColor = Color.Transparent;
			RoleLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			RoleLabel.ForeColor = Color.Black;
			RoleLabel.Location = new Point(651, 70);
			RoleLabel.Name = "RoleLabel";
			RoleLabel.Size = new Size(188, 19);
			RoleLabel.TabIndex = 15;
			RoleLabel.Text = "Choose User To Give Role";
			// 
			// ChooseRoleComboBox
			// 
			ChooseRoleComboBox.BackColor = Color.White;
			ChooseRoleComboBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			ChooseRoleComboBox.FormattingEnabled = true;
			ChooseRoleComboBox.Location = new Point(861, 152);
			ChooseRoleComboBox.Name = "ChooseRoleComboBox";
			ChooseRoleComboBox.Size = new Size(225, 29);
			ChooseRoleComboBox.TabIndex = 20;
			// 
			// GiveRoleButton
			// 
			GiveRoleButton.BackColor = Color.FromArgb(106, 195, 211);
			GiveRoleButton.Font = new Font("Segoe UI", 12F);
			GiveRoleButton.ForeColor = SystemColors.ControlText;
			GiveRoleButton.Location = new Point(980, 205);
			GiveRoleButton.Name = "GiveRoleButton";
			GiveRoleButton.Size = new Size(106, 35);
			GiveRoleButton.TabIndex = 22;
			GiveRoleButton.Text = "GiveRole";
			GiveRoleButton.UseVisualStyleBackColor = false;
			GiveRoleButton.Click += GiveRoleButton_Click_1;
			// 
			// ViewBan
			// 
			ViewBan.BackColor = Color.FromArgb(106, 195, 211);
			ViewBan.Font = new Font("Segoe UI", 12F);
			ViewBan.Location = new Point(530, 205);
			ViewBan.Name = "ViewBan";
			ViewBan.Size = new Size(95, 35);
			ViewBan.TabIndex = 23;
			ViewBan.Text = "ViewBan";
			ViewBan.UseVisualStyleBackColor = false;
			ViewBan.Click += ViewBan_Click;
			// 
			// button2
			// 
			button2.BackColor = Color.FromArgb(106, 195, 211);
			button2.Font = new Font("Segoe UI", 12F);
			button2.ForeColor = SystemColors.ControlText;
			button2.Location = new Point(140, 252);
			button2.Name = "button2";
			button2.Size = new Size(106, 35);
			button2.TabIndex = 24;
			button2.Text = "AllUsers";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// pictureBox2
			// 
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Image = Properties.Resources._3;
			pictureBox2.Location = new Point(1, -2);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(133, 120);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 26;
			pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.FromArgb(224, 224, 224);
			pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
			pictureBox1.ErrorImage = null;
			pictureBox1.InitialImage = Properties.Resources._2;
			pictureBox1.Location = new Point(1, -2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(133, 736);
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			// 
			// BanReasonLabel
			// 
			BanReasonLabel.AutoSize = true;
			BanReasonLabel.BackColor = Color.Transparent;
			BanReasonLabel.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			BanReasonLabel.ForeColor = Color.Black;
			BanReasonLabel.Location = new Point(140, 170);
			BanReasonLabel.Name = "BanReasonLabel";
			BanReasonLabel.Size = new Size(83, 17);
			BanReasonLabel.TabIndex = 27;
			BanReasonLabel.Text = "BanReason";
			// 
			// ChooseRoleLabel
			// 
			ChooseRoleLabel.AutoSize = true;
			ChooseRoleLabel.BackColor = Color.Transparent;
			ChooseRoleLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			ChooseRoleLabel.ForeColor = Color.Black;
			ChooseRoleLabel.Location = new Point(651, 162);
			ChooseRoleLabel.Name = "ChooseRoleLabel";
			ChooseRoleLabel.Size = new Size(107, 19);
			ChooseRoleLabel.TabIndex = 28;
			ChooseRoleLabel.Text = "Choose a Role";
			// 
			// Form3
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1149, 637);
			Controls.Add(ChooseRoleLabel);
			Controls.Add(BanReasonLabel);
			Controls.Add(pictureBox2);
			Controls.Add(pictureBox1);
			Controls.Add(button2);
			Controls.Add(ViewBan);
			Controls.Add(GiveRoleButton);
			Controls.Add(ChooseRoleComboBox);
			Controls.Add(RoleLabel);
			Controls.Add(UserRoleComboBox);
			Controls.Add(AllUsersButton);
			Controls.Add(ChooseUserLabel);
			Controls.Add(BanReasonTextBox);
			Controls.Add(UserForBanComboBox);
			Controls.Add(CorrectDateLabel);
			Controls.Add(BanButton);
			Controls.Add(BanUntillLabel);
			Controls.Add(dateTimePicker1);
			Controls.Add(UsersDatagridView);
			Controls.Add(Home);
			Name = "Form3";
			Text = "AdminView";
			Load += Form3_Load;
			((System.ComponentModel.ISupportInitialize)UsersDatagridView).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button Home;
		private DataGridView UsersDatagridView;
		private DateTimePicker dateTimePicker1;
		private Label BanUntillLabel;
		private Button BanButton;
		private Label CorrectDateLabel;
		private ComboBox UserForBanComboBox;
		private TextBox BanReasonTextBox;
		private Label ChooseUserLabel;
		private Button AllUsersButton;
		private ComboBox UserRoleComboBox;
		private Label RoleLabel;
		private ComboBox ChooseRoleComboBox;
		private Button GiveRoleButton;
		private Button ViewBan;
		private Button button2;
		private PictureBox pictureBox2;
		private PictureBox pictureBox1;
		private Label BanReasonLabel;
		private Label ChooseRoleLabel;
	}
}