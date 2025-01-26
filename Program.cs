using MyBlog.Model;

namespace MyBlog
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MyBlogContext context = MyBlogContext.myBlogContext;
			//var user = context.Users.First();
			
            //context.Users.FirstOrDefault(x => x.Id == 7).Picture =
            //    context.Users.FirstOrDefault(x => x.Id == 6).Picture;
            // context.SaveChanges();
            //Application.Run(new VisitProfileForm(context.Users.FirstOrDefault(U=>U.Id==18),2));

            //Application.Run(new Form1());

			Application.Run(new Form1());
		}
	}

    [Flags]
    public enum Role
    {
        user=0,
        Moderator=1,
        Admin=2
    }
}