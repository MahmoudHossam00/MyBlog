using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Bans
	{

		public int BanneduserId { set; get; }
		public int BanningAdminId { set; get; }
		public string BanReason { set; get; }
		public DateTime BannedTill { set; get; }
		[InverseProperty("GotBanned")]
		public User Banneduser { set; get; } = null!;
		[InverseProperty("GaveBans")]
		public User BanningAdmin { set; get; } = null!;
	}
}
