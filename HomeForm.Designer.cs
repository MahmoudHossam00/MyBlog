namespace MyBlog
{
	partial class HomeForm
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
			SearchTextBox1 = new TextBox();
			VisitProfileButton1 = new Button();
			FollowUserComboBox1 = new ComboBox();
			dataGridView1 = new DataGridView();
			PostingPanel1 = new Panel();
			CategoryLabel = new Label();
			CategoryComboBox = new ComboBox();
			PostButton1 = new Button();
			PostPhotoButton1 = new PictureBox();
			UploadButton = new Button();
			ThoughtLabel1 = new Label();
			PostRichTextBox = new RichTextBox();
			linkLabel1 = new LinkLabel();
			linkLabel2 = new LinkLabel();
			CategorySortComboBox = new ComboBox();
			ViewPostsByCategoryButton = new Button();
			label1 = new Label();
			FollowedPostsButton = new Button();
			pictureBox2 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			PostingPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PostPhotoButton1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.FromArgb(224, 224, 224);
			pictureBox1.Location = new Point(1, 1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(133, 711);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			// 
			// SearchTextBox1
			// 
			SearchTextBox1.Location = new Point(536, 26);
			SearchTextBox1.Name = "SearchTextBox1";
			SearchTextBox1.Size = new Size(140, 23);
			SearchTextBox1.TabIndex = 6;
			SearchTextBox1.TextChanged += textBox1_TextChanged;
			// 
			// VisitProfileButton1
			// 
			VisitProfileButton1.Location = new Point(849, 25);
			VisitProfileButton1.Name = "VisitProfileButton1";
			VisitProfileButton1.Size = new Size(99, 23);
			VisitProfileButton1.TabIndex = 9;
			VisitProfileButton1.Text = "VisitProfile";
			VisitProfileButton1.UseVisualStyleBackColor = true;
			VisitProfileButton1.Click += VisitProfileButton1_Click;
			// 
			// FollowUserComboBox1
			// 
			FollowUserComboBox1.FormattingEnabled = true;
			FollowUserComboBox1.Location = new Point(697, 26);
			FollowUserComboBox1.Name = "FollowUserComboBox1";
			FollowUserComboBox1.Size = new Size(133, 23);
			FollowUserComboBox1.TabIndex = 10;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(536, 55);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(304, 91);
			dataGridView1.TabIndex = 11;
			// 
			// PostingPanel1
			// 
			PostingPanel1.Controls.Add(CategoryLabel);
			PostingPanel1.Controls.Add(CategoryComboBox);
			PostingPanel1.Controls.Add(PostButton1);
			PostingPanel1.Controls.Add(PostPhotoButton1);
			PostingPanel1.Controls.Add(UploadButton);
			PostingPanel1.Controls.Add(ThoughtLabel1);
			PostingPanel1.Controls.Add(PostRichTextBox);
			PostingPanel1.Location = new Point(155, 25);
			PostingPanel1.Name = "PostingPanel1";
			PostingPanel1.Size = new Size(361, 202);
			PostingPanel1.TabIndex = 12;
			PostingPanel1.Paint += PostingPanel1_Paint;
			// 
			// CategoryLabel
			// 
			CategoryLabel.AutoSize = true;
			CategoryLabel.Location = new Point(16, 146);
			CategoryLabel.Name = "CategoryLabel";
			CategoryLabel.Size = new Size(55, 15);
			CategoryLabel.TabIndex = 6;
			CategoryLabel.Text = "Category";
			// 
			// CategoryComboBox
			// 
			CategoryComboBox.FormattingEnabled = true;
			CategoryComboBox.Location = new Point(16, 169);
			CategoryComboBox.Name = "CategoryComboBox";
			CategoryComboBox.Size = new Size(121, 23);
			CategoryComboBox.TabIndex = 5;
			// 
			// PostButton1
			// 
			PostButton1.BackColor = Color.White;
			PostButton1.Location = new Point(273, 169);
			PostButton1.Name = "PostButton1";
			PostButton1.Size = new Size(75, 23);
			PostButton1.TabIndex = 4;
			PostButton1.Text = "Post";
			PostButton1.UseVisualStyleBackColor = false;
			PostButton1.Click += PostButton1_Click;
			// 
			// PostPhotoButton1
			// 
			PostPhotoButton1.ErrorImage = null;
			PostPhotoButton1.Location = new Point(143, 142);
			PostPhotoButton1.Name = "PostPhotoButton1";
			PostPhotoButton1.Size = new Size(100, 50);
			PostPhotoButton1.TabIndex = 3;
			PostPhotoButton1.TabStop = false;
			// 
			// UploadButton
			// 
			UploadButton.Location = new Point(249, 142);
			UploadButton.Name = "UploadButton";
			UploadButton.Size = new Size(99, 23);
			UploadButton.TabIndex = 2;
			UploadButton.Text = "UploadPhoto";
			UploadButton.UseVisualStyleBackColor = true;
			UploadButton.Click += UploadButton_Click;
			// 
			// ThoughtLabel1
			// 
			ThoughtLabel1.AutoSize = true;
			ThoughtLabel1.Location = new Point(0, 9);
			ThoughtLabel1.Name = "ThoughtLabel1";
			ThoughtLabel1.Size = new Size(32, 15);
			ThoughtLabel1.TabIndex = 1;
			ThoughtLabel1.Text = "label";
			// 
			// PostRichTextBox
			// 
			PostRichTextBox.Location = new Point(60, 3);
			PostRichTextBox.Name = "PostRichTextBox";
			PostRichTextBox.Size = new Size(298, 133);
			PostRichTextBox.TabIndex = 0;
			PostRichTextBox.Text = "";
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = Color.Transparent;
			linkLabel1.Location = new Point(802, 659);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(94, 15);
			linkLabel1.TabIndex = 0;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "<<PreviousPage";
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// linkLabel2
			// 
			linkLabel2.AutoSize = true;
			linkLabel2.BackColor = Color.Transparent;
			linkLabel2.Location = new Point(916, 659);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new Size(74, 15);
			linkLabel2.TabIndex = 15;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "NextPage>>";
			linkLabel2.LinkClicked += linkLabel2_LinkClicked;
			// 
			// CategorySortComboBox
			// 
			CategorySortComboBox.FormattingEnabled = true;
			CategorySortComboBox.Location = new Point(697, 171);
			CategorySortComboBox.Name = "CategorySortComboBox";
			CategorySortComboBox.Size = new Size(133, 23);
			CategorySortComboBox.TabIndex = 17;
			// 
			// ViewPostsByCategoryButton
			// 
			ViewPostsByCategoryButton.Location = new Point(849, 170);
			ViewPostsByCategoryButton.Name = "ViewPostsByCategoryButton";
			ViewPostsByCategoryButton.Size = new Size(107, 23);
			ViewPostsByCategoryButton.TabIndex = 16;
			ViewPostsByCategoryButton.Text = "ViewByCategory";
			ViewPostsByCategoryButton.UseVisualStyleBackColor = true;
			ViewPostsByCategoryButton.Click += ViewPostsByCategoryButton_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(697, 150);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.TabIndex = 7;
			label1.Text = "Category";
			// 
			// FollowedPostsButton
			// 
			FollowedPostsButton.Location = new Point(849, 218);
			FollowedPostsButton.Name = "FollowedPostsButton";
			FollowedPostsButton.Size = new Size(107, 23);
			FollowedPostsButton.TabIndex = 18;
			FollowedPostsButton.Text = "ViewFollowed";
			FollowedPostsButton.UseVisualStyleBackColor = true;
			FollowedPostsButton.Click += FollowedPostsButton_Click;
			// 
			// pictureBox2
			// 
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Image = Properties.Resources._3;
			pictureBox2.Location = new Point(1, 1);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(133, 120);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 19;
			pictureBox2.TabStop = false;
			// 
			// HomeForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1092, 691);
			Controls.Add(pictureBox2);
			Controls.Add(FollowedPostsButton);
			Controls.Add(label1);
			Controls.Add(CategorySortComboBox);
			Controls.Add(ViewPostsByCategoryButton);
			Controls.Add(linkLabel2);
			Controls.Add(linkLabel1);
			Controls.Add(PostingPanel1);
			Controls.Add(dataGridView1);
			Controls.Add(FollowUserComboBox1);
			Controls.Add(VisitProfileButton1);
			Controls.Add(SearchTextBox1);
			Controls.Add(pictureBox1);
			Name = "HomeForm";
			Text = "HomeForm";
			Load += HomeForm_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			PostingPanel1.ResumeLayout(false);
			PostingPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PostPhotoButton1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private PictureBox pictureBox1;
		private TextBox SearchTextBox1;
		private Button VisitProfileButton1;
		private ComboBox FollowUserComboBox1;
		private DataGridView dataGridView1;
		private Panel PostingPanel1;
		private Label ThoughtLabel1;
		private RichTextBox PostRichTextBox;
		private PictureBox PostPhotoButton1;
		private Button UploadButton;
		private Button PostButton1;
		private Label CategoryLabel;
		private ComboBox CategoryComboBox;
		private LinkLabel linkLabel1;
		private LinkLabel linkLabel2;
		private ComboBox CategorySortComboBox;
		private Button ViewPostsByCategoryButton;
		private Label label1;
		private Button FollowedPostsButton;
		private PictureBox pictureBox2;
	}
}