using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
	public partial class checkLogin : Form
	{
		public checkLogin()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			new Login().ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			new registerRunner().ShowDialog();

		}

		private void button5_Click(object sender, EventArgs e)
		{
			new Login().ShowDialog();
		}
	}
}
