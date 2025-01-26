using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public static class TextboxAndLabelsEditor
	{
		public static void EditRichTextBox(this RichTextBox textbot)
		{


		}
		public static void DateLabel(this Label label)
		{


		}
		public static void BigUserName(this Label label)
		{
			label.Font = new Font("Arial", 14, FontStyle.Regular);

		}
		public static void UserName(this Label label)
		{
			label.Font = new Font("Arial", 12, FontStyle.Regular);

		}

	}
}
