namespace MyBlog
{
	partial class Form4
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
			AddCategoryButton = new Button();
			CategoryNameTextBox = new TextBox();
			CategoryLabel = new Label();
			pictureBox1 = new PictureBox();
			Categories2DatagridView = new DataGridView();
			pictureBox2 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)Categories2DatagridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// Home
			// 
			Home.Location = new Point(-1, 125);
			Home.Name = "Home";
			Home.Size = new Size(75, 23);
			Home.TabIndex = 22;
			Home.Text = "button1";
			Home.UseVisualStyleBackColor = true;
			Home.Click += Home_Click;
			// 
			// AddCategoryButton
			// 
			AddCategoryButton.BackColor = Color.FromArgb(106, 195, 211);
			AddCategoryButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			AddCategoryButton.Location = new Point(518, 242);
			AddCategoryButton.Name = "AddCategoryButton";
			AddCategoryButton.Size = new Size(125, 35);
			AddCategoryButton.TabIndex = 27;
			AddCategoryButton.Text = "AddCategory";
			AddCategoryButton.UseVisualStyleBackColor = false;
			AddCategoryButton.Click += AddCategoryButton_Click;
			// 
			// CategoryNameTextBox
			// 
			CategoryNameTextBox.BackColor = Color.White;
			CategoryNameTextBox.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			CategoryNameTextBox.Location = new Point(492, 168);
			CategoryNameTextBox.Name = "CategoryNameTextBox";
			CategoryNameTextBox.PlaceholderText = "Category Name";
			CategoryNameTextBox.Size = new Size(181, 29);
			CategoryNameTextBox.TabIndex = 30;
			CategoryNameTextBox.Leave += CategoryNameTextBox_Leave;
			// 
			// CategoryLabel
			// 
			CategoryLabel.AutoSize = true;
			CategoryLabel.BackColor = Color.Transparent;
			CategoryLabel.Font = new Font("Times New Roman", 14.25F, FontStyle.Italic);
			CategoryLabel.ForeColor = Color.Red;
			CategoryLabel.Location = new Point(713, 171);
			CategoryLabel.Name = "CategoryLabel";
			CategoryLabel.Size = new Size(109, 21);
			CategoryLabel.TabIndex = 31;
			CategoryLabel.Text = "InvalidName";
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.FromArgb(224, 224, 224);
			pictureBox1.Location = new Point(-1, -1);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(133, 782);
			pictureBox1.TabIndex = 42;
			pictureBox1.TabStop = false;
			// 
			// Categories2DatagridView
			// 
			Categories2DatagridView.BackgroundColor = Color.White;
			Categories2DatagridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			Categories2DatagridView.GridColor = Color.Silver;
			Categories2DatagridView.Location = new Point(378, 337);
			Categories2DatagridView.Name = "Categories2DatagridView";
			Categories2DatagridView.Size = new Size(432, 242);
			Categories2DatagridView.TabIndex = 44;
			Categories2DatagridView.CellValueChanged += Categories2DatagridView_CellValueChanged;
			Categories2DatagridView.KeyDown += Categories2DatagridView_KeyDown;
			// 
			// pictureBox2
			// 
			pictureBox2.BackColor = Color.Transparent;
			pictureBox2.Image = Properties.Resources._3;
			pictureBox2.Location = new Point(-1, -1);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(133, 120);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 47;
			pictureBox2.TabStop = false;
			// 
			// Form4
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1047, 640);
			Controls.Add(pictureBox2);
			Controls.Add(Categories2DatagridView);
			Controls.Add(pictureBox1);
			Controls.Add(CategoryLabel);
			Controls.Add(CategoryNameTextBox);
			Controls.Add(AddCategoryButton);
			Controls.Add(Home);
			Name = "Form4";
			Text = "AddCategory";
			Load += Form4_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)Categories2DatagridView).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button Home;
		private Button AddCategoryButton;
		private TextBox CategoryNameTextBox;
		private Label CategoryLabel;
		private PictureBox pictureBox1;
		private DataGridView Categories2DatagridView;
		private PictureBox pictureBox2;
	}
}