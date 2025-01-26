using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Follow
	{
		public int FollowerId { set; get; }
		public int FollowedId { set; get; }
		public User Follower { set; get; }
		public User Followed { set; get; }
	}
}
