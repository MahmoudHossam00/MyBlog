using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog
{
	public  class SetForm
	{
		public Button Home = new Button();
		public Button AdminView = new();
		public Button AddCategory = new();
		public Button ViewFollowers = new();
		public Button MyInteractions = new();
		public Button LogOut = new();
		public PictureBox Logo = new();
		public PictureBox Background = new();

		 public SetForm()
		{
			Form2 form = new Form2();
			form.Hide();
			LeftButtonsHelper.GetButtons(ref Home, ref AdminView, ref AddCategory, ref ViewFollowers,ref MyInteractions, ref LogOut);
		}
	}
}
