using MyBlog.help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyBlog.Form3;

namespace MyBlog
{
	public static class LeftButtonsHelper
	{
		public static void GetButtons(ref Button Home,ref Button AdminView,ref Button AddCategory,ref Button ViewFollowers,ref Button MyInteractions,ref Button LogOut)
		{
			Home.SetButton(  0, 120, "Home");
			AdminView.SetButton( 0, 164, "AdminView");
			AddCategory.SetButton( 0, 208, "AddCategory");
			ViewFollowers.SetButton( 0, 252, "ViewFollowers");
			MyInteractions.SetButton( 0, 296, "MyInteractions");
			LogOut.SetButton( 0, 340, "LogOut");

		}

	}
}
