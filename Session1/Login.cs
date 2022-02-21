using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Session1
{
	public partial class Login : Form
	{
		brezil2015Entities db = new brezil2015Entities();
		public Login()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var login = db.Users.Include(c=>c.Role).Where(c => c.Email == textBox1.Text && c.Password == textBox2.Text).FirstOrDefault();
			if (login!=null)
			{
				if (login.RoleId == "A")
				{

				}
				else if (login.RoleId == "C")
				{
					 new CoordinationMenu().ShowDialog();
				}
				else if (login.RoleId == "R")
				{
					LoginInfo.curentuser = login;
					new RunnerMenu().ShowDialog();
				}
			}
		}
	}
	public static class LoginInfo
	{
		public static User curentuser;
	}
}
