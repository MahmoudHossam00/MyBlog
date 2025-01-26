using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public static class PictureAdder
	{
		
		public static void SetPostPicture(this PictureBox picturebox, byte[] Img)
		{
			if (Img is not null)
			{
				using (MemoryStream ms = new MemoryStream(Img))
				{

					picturebox.Image = Image.FromStream(ms);
					picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
				}
			}
			else
			{
				picturebox.Image = null;
			}
		}
		public static void SetProfilePicture(this PictureBox picturebox, byte[] Img)
		{
			if (Img is not null)
			{
				using (MemoryStream ms = new MemoryStream(Img)) // Convert byte[] to MemoryStream
				{
					picturebox.Image = Image.FromStream(ms); // Set the image to the PictureBox
					picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
				}

			}
			else
			{
				picturebox.Image = Properties.Resources.istockphoto_1327592449_612x612;

				picturebox.SizeMode = PictureBoxSizeMode.StretchImage;

			}
		}
	}
}
