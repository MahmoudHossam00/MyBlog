using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public static class UserNameLabelSetter
	{
		public static void setUserName(this Label label,int sizea,int sizeb)
		{
			label.Font = new Font("Arial", 24, FontStyle.Bold); // Change size and style as needed
			label.Size = new Size(sizea, sizeb); // Adjust width and height
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.ForeColor = Color.Black;
		}
	}
}
