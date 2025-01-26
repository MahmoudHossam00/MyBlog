using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class React
	{
		public int UserId { get; set; }
		public int PostId { get; set; }
		public reaction Reaction { get; set; }
		public Post post { get; set; } 
		public User user { get; set; } 
	}
	public enum reaction
	{
		Like,
		Love,
		Sad,
		haha,
		Wow,
		Angry
	}
}
