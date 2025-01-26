using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public class EditEventArgs:EventArgs
	{
		public int PostId { get; set; }
		public EditEventArgs(int postid)
		{
			PostId = postid;
		}
	}
}
