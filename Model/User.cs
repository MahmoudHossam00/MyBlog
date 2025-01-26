using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(30)]
		public string FirstName { get; set; } = null!;
		[MaxLength(30)]
		public string LastName { get; set; } = null!;
		[MaxLength(50)]
		
		public string Address { get; set; } = null!;
		[MaxLength(100)]
		[EmailAddress]
		
		public string Email { get; set; } = null!;
		[MaxLength(100)]
		[EmailAddress]

		public string UserName { get; set; } = null!;
		[PasswordPropertyText]
		public string password { set; get; } = null!;
		public byte[]? Picture { get; set; } 
		public Role Role { get; set; } = Role.user;

		#region BanRegion
		//public bool isBanned { set; get; } = false;
		//public Bans? CurrentUserBan { set; get; }
		#endregion

		//[InverseProperty("Following")]
		//public List<User> Followers { set; get; }
		//[InverseProperty("Followers")]
		//public List<User> Following { set; get; }public
		[InverseProperty("Follower")]
		public List<Follow>? Followers { set; get; } = new List<Follow>();
		[InverseProperty("Followed")]
		public List<Follow>? Followed { set; get; } = new List<Follow>();

		[InverseProperty("Banneduser")]
		public List<Bans>? GotBanned { set; get; }
		[InverseProperty("BanningAdmin")]
		public List<Bans>? GaveBans { set; get; }


		public List<Category>? categories { set; get; }

		public List<React>? Reacts { set; get; }

		//public List<Interaction>? Interactions { set; get; }
		public List<Post>? posts { set; get; }	
		public List<Comment>? comments { set; get; }
	}
}
