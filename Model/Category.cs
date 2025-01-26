using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Category
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public int UserId { get; set; }
		public User User { get; set; } = null!;
		public List<Post>? CategoryPosts { get; set; } = new List<Post>();
	}
}
