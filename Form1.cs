using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyBlog
{
	public partial class Form1 : Form
	{
		private System.Windows.Forms.Timer transitionTimer;
		private float opacity = 0f;
		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.Location = pictureBox1.Location;
			pictureBox2.Size = pictureBox1.Size;
			timer1 = new() { Interval = 50 };
			timer1.Tick += timer1_Tick;
			pictureBox2.Visible = true;
			pictureBox2.Visible = false;
			timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			opacity += 0.05f;
			if (opacity >= 1)
			{
				timer1.Stop();
				pictureBox1.Visible = false;
				pictureBox2.Visible = true;
			}

		}
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.Location = this.Location;
			form.Show();
			this.Hide();
		}
	}
}
