using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public class PostEventArgs
	{
		public int _PostId { get; set; }
		public PostEventArgs(int postid)
		{
			_PostId = postid;
		}
	}
}
