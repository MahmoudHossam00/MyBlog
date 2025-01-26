using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public class PictureBoxEventArgs:EventArgs
	{
		public PictureBox[] boxes = new PictureBox[6];
		public int PostId { get; set; }
		public PictureBoxEventArgs(PictureBox[] pictureBox, int postnum)
		{
			boxes = pictureBox;
			PostId = postnum;
		}
	}
}
