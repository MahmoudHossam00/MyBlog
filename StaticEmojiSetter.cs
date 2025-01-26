using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog
{
	public static class StaticEmojiSetter
	{

		public static void HandleEmojisForForms(this Form form, PictureBox[] reacts, Label[] reactsNumbers, int usernId, int _postnId)
		{
			MyBlogContext context = MyBlogContext.myBlogContext;
			var LowYposition = reacts[0].Location.Y < reacts[1 ].Location.Y ? reacts[1 ].Location.Y : reacts[0 ].Location.Y;
			var currentReact = context.Reacts.FirstOrDefault(r => r.UserId == usernId && r.PostId == _postnId);
			for (int i = 0; i <= 5; i++)
			{
				//reacts[i].Tag = i;
				reacts[i].Location = new Point(reacts[i].Location.X, LowYposition);
				reactsNumbers[i].Text = context.Reacts.Where(r => r.PostId == _postnId && r.Reaction == (reaction)i).Count().ToString();
			}
			if (currentReact != null)
			{
				int index = (int)currentReact.Reaction;
				reacts[index].Location = new Point(reacts[index].Location.X, LowYposition - 30);

			}


		}
	}
}
