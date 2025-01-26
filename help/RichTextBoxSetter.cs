using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public static class RichTextBoxSetter
	{
		public static void SetRichTextBox(this RichTextBox richTextBox)
		{
			//richTextBox.Text = content;
			richTextBox.ReadOnly = true;
		}
	}
}
