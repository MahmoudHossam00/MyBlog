using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.help
{
	public class DeleteCommentEventArgs
	{
		public int _CommentId { get; set; }
		public DeleteCommentEventArgs(int CommentId)
		{
			_CommentId = CommentId;
		}
	}
}
