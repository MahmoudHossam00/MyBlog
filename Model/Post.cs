using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Post:Interaction
	{
		public int? CategoryId { get; set; }
		public Category Category { get; set; }
		public List<React>? Reacts { get; set; }
		public List<Comment>? Comments { get; set; }
	}
}
