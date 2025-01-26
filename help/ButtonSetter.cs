using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace MyBlog.help
{
	public static class ButtonSetter
	{

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		public static void SetButton(this Button button ,int pointa, int pointb, string text, bool isSmall = false, bool isReverse = false)
		{
			var grayColour = Color.FromArgb(255, 217, 217, 217);
			var MainColour = Color.FromArgb(104, 195, 215);
			button.Text = text;

			button.Size = isSmall ? new Size(133, 43 * 2 / 3) : new Size(133, 43);  // Set the button size
			
			button.Location = new Point(pointa , pointb); // Set the position of the button
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			if (!isReverse)
			{
				button.BackColor = MainColour; // Blue color
				button.ForeColor = Color.White;
			}
			else
			{

				button.ForeColor = MainColour; // Blue color
				button.BackColor = grayColour;
			}
			button.Font = new Font("Times New Roman", 14.25f, FontStyle.Regular);
			button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 20, 20));
			button.MouseEnter += (sender, e) =>
			{
				if (!isReverse)
				{

					button.BackColor = grayColour;
					button.ForeColor = MainColour;
				}
				else
				{
					button.ForeColor = Color.White; // Blue color
					button.BackColor = MainColour;
				}
			};
			button.MouseLeave += (sender, e) =>
			{
				if (!isReverse)
				{

					button.BackColor = MainColour;
					button.ForeColor = Color.White;
				}
				else
				{
					button.ForeColor = MainColour;
					button.BackColor = grayColour;
				}
			};
		}
		public static void SetSecondaryButton(this Button button,int? pointa=null,int? pointb=null,int? Width=null ,int?height=null, bool isReverse = false)
		{
			var grayColour = Color.FromArgb(255, 217, 217, 217);
			var MainColour = Color.FromArgb(104, 195, 215);


			button.Size = new Size(Width??133/2, height ?? 43 * 2 / 3); // Set the button size

			button.Location = new Point(pointa?? button.Location.X, pointb?? button.Location.Y); // Set the position of the button
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			if (!isReverse)
			{
				button.BackColor = MainColour; // Blue color
				button.ForeColor = Color.White;
			}
			else
			{

				button.ForeColor = MainColour; // Blue color
				button.BackColor = grayColour;
			}
			button.Font = new Font("Times New Roman", 12, FontStyle.Regular);
			button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width, button.Height, 20, 20));
			button.MouseEnter += (sender, e) =>
			{
				if (!isReverse)
				{

					button.BackColor = grayColour;
					button.ForeColor = MainColour;
				}
				else
				{
					button.ForeColor = Color.White; // Blue color
					button.BackColor = MainColour;
				}
			};
			button.MouseLeave += (sender, e) =>
			{
				if (!isReverse)
				{

					button.BackColor = MainColour;
					button.ForeColor = Color.White;
				}
				else
				{
					button.ForeColor = MainColour;
					button.BackColor = grayColour;
				}
			};
		}
		public static void SetThirdButton(this Button button, bool isSmall = false, bool isReverse = false)
		{

		}
	}
}
