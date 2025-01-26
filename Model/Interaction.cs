using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class Interaction
	{
		public int Id { get; set; }
		[Required]
		public DateTime CreationDate { get; set; } 
		public string Content { get; set; } = null!;
		public byte[]? Picture { get; set; }
		//public int Likes { get; set; }
		public int? PublisherId { get; set; }
		public User? Publisher { get; set; }


	}
}
