using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Comment : Interaction
	{
		public Post Post { get; set; }
		public int PostId { get; set; }

	}
}
