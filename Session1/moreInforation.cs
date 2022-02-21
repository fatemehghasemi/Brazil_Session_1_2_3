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
	public partial class moreInforation : Form
	{
			public moreInforation()
		{
			InitializeComponent();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			listOfCharitis list = new listOfCharitis();
			list.ShowDialog();
		}

		private void moreInforation_Load(object sender, EventArgs e)
		{
		

		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new howLongIsMarathon().ShowDialog();
		}
	}
}
