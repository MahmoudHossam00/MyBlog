using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBlog.help;

//using Microsoft.VisualBasic.ApplicationServices;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBlog
{
	public partial class Form4 : Form
	{
		MyBlogContext context = MyBlogContext.myBlogContext;
		public User user { set; get; }
		public Form4(User USER)
		{
			InitializeComponent();
			//ShowCategories()
			user = USER;

		}
		private void ShowCategories()
		{
			//		Categories2DatagridView.DataSource = context.categories
			//.Include(C => C.User)
			//.Select(c => new { Id = c.Id, CategoryName = c.Name, Creator = c.User.UserName })
			//.ToList();
			Categories2DatagridView.DataSource = "";
			Categories2DatagridView.DataSource = context.categories.AsNoTracking().ToList();

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void Form4_Load(object sender, EventArgs e)
		{
			ShowCategories();
			CategoryLabel.Hide();
			pictureBox1.SendToBack();
			Home.SetButton(0, 120, "Home");
			AddCategoryButton.SetSecondaryButton(Width:125);
		}

		private void AddCategoryButton_Click(object sender, EventArgs e)
		{
			Category cat = new Category();
			cat.Name = CategoryNameTextBox.Text;
			cat.UserId = user.Id;
			context.categories.Add(cat);
			context.SaveChanges();
			ShowCategories();
		}

		private void CategoryNameTextBox_Leave(object sender, EventArgs e)
		{
			bool flag = false;
			string str = CategoryNameTextBox.Text;
			foreach (var c in str)
			{
				if (c != ' ' && !Char.IsLetter(c) && !Char.IsNumber(c))
				{
					flag = true;
					CategoryLabel.Show();

				}
			}
			if (flag == false)
			{
				CategoryLabel.Hide();
			}
		}



		private void Categories2DatagridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex >= Categories2DatagridView.Rows.Count)
				return;


			// Get the DataGridViewRow where the click occurred
			DataGridViewRow row = Categories2DatagridView.Rows[e.RowIndex];
			if ((user.Role < Role.Moderator))
			{
				MessageBox.Show("Only Admin Can edit", "Error");
				return;
			}

			else if (Categories2DatagridView.Columns[e.ColumnIndex].Name == "Name")
			{

				int CategoryId = Convert.ToInt32(row.Cells["Id"].Value);
				////chosenUserId = UserId;
				var cat = context.categories.Where(c => c.Id == CategoryId).FirstOrDefault();
				string name = row.Cells["Name"]?.Value.ToString();
				if (cat.Name != name)
				{
					cat.Name = name;
					context.categories.Update(cat);
					context.SaveChanges();
					
				}
			}
			else
			{
				MessageBox.Show("You can only edit the name");
			}

			ShowCategories();

		}
		private void Home_Click(object sender, EventArgs e)
		{
			HomeForm form = new(user);
			//form.Size = this.Size;
			form.Location = this.Location;
			form.Show();
			this.Hide(); ;
		}



		private void Categories2DatagridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (Categories2DatagridView.SelectedRows.Count > 0)
				{
					if ((user.Role & Role.Admin) == Role.Admin)
					{
						int rowIndex = Categories2DatagridView.SelectedRows[0].Index;
	

						var catId = (int)Categories2DatagridView.SelectedRows[0].Cells["Id"].Value;


						var cat = context.categories.FirstOrDefault(x => x.Id == catId);

						var posts = context.Posts.Where(p => p.CategoryId == cat.Id).ToList();
						foreach (var post in posts)
						{
							post.CategoryId = null;
							//post.Category = null;
						}
						context.categories.Remove(cat);
						context.SaveChanges();
						ShowCategories();
					}
					else
					{
						MessageBox.Show("Only Admin Can Delete");
					}



				}
			}
		}
		public static void RemoveCategory(Category cat)
		{
			MyBlogContext context = MyBlogContext.myBlogContext;
			context.Remove(cat);
			context.SaveChanges();
		}
		public static void RemoveCategories(IQueryable<Category> categories)
		{
			MyBlogContext context = MyBlogContext.myBlogContext;
			context.Remove(categories);
			context.SaveChanges();
		}
	}
}
