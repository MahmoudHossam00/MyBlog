using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
	public class MyBlogContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Bans> Bans { get; set; }
		public DbSet<Follow> Follows { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<React> Reacts { get; set; }

		public DbSet<Comment> comments { get; set; }
		public static MyBlogContext myBlogContext { get; set; }
		static MyBlogContext()
		{
			myBlogContext=new MyBlogContext();
		}
		public MyBlogContext()
		{
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyBlog"].ConnectionString);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
			modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
			modelBuilder.Entity<Bans>().HasKey(x => new { x.BanneduserId, x.BanningAdminId });
			modelBuilder.Entity<Follow>().HasKey(x => new { x.FollowerId, x.FollowedId });
			modelBuilder.Entity<React>().HasKey(x => new { x.UserId, x.PostId });
			#region UsersMigration
			modelBuilder.Entity<Bans>()
				.HasOne(b => b.Banneduser)
				.WithMany(u => u.GotBanned)
				.HasForeignKey(b => b.BanneduserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Bans>()
				.HasOne(b => b.BanningAdmin)
				.WithMany(u => u.GaveBans)
				.HasForeignKey(b => b.BanningAdminId)
				.OnDelete(DeleteBehavior.NoAction);



			modelBuilder.Entity<Follow>()
				.HasOne(F => F.Followed)
				.WithMany(u => u.Followed)
				.HasForeignKey(b => b.FollowedId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Follow>()
				.HasOne(F => F.Follower)
				.WithMany(u => u.Followers)
				.HasForeignKey(b => b.FollowerId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<React>().HasOne(r => r.user).WithMany(u => u.Reacts).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<React>().HasOne(r=>r.post).WithMany(u => u.Reacts).HasForeignKey(r => r.PostId).OnDelete(DeleteBehavior.Cascade);
			#endregion
			modelBuilder.Entity<Post>().HasOne(c=>c.Category).WithMany(c=>c.CategoryPosts)
				.HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.NoAction);//user with posts is still on delete behaviour cascade
			modelBuilder.Entity<User>().HasData(new User() { Id = 1, Email = "MahmoudkHossam@gmail.com", password = "interesting", UserName = "MahmoudkHossam", Role = Role.Admin, Address = "Giza", FirstName = "Mahmoud", LastName = "Hossam", Picture = null });
			//modelBuilder.Entity<Comment>().HasOne(c => c.Publisher).WithMany(p=>p.)
			#region Category
			modelBuilder.Entity<Category>().HasOne(c=>c.User).WithMany(u=>u.categories).HasForeignKey(c=>c.UserId)
				.OnDelete(DeleteBehavior.NoAction);
			#endregion
			//modelBuilder.Entity<User>().Property(x => x.isBanned).HasDefaultValue(false);
			base.OnModelCreating(modelBuilder);

		}
	}
}
