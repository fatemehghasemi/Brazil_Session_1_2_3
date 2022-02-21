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
	public partial class peymentConfrim : Form
	{
		String name = "";
		String amount = "";
		String namecha = "";
		public peymentConfrim()
		{
			InitializeComponent();
		}
		public peymentConfrim(String namecharitis,String namerunner, String amount)
		{
			InitializeComponent();
			this.name=namerunner;
			this.amount=amount;
			this.namecha=namecharitis;
		}

		private void peymentConfrim_Load(object sender, EventArgs e)
		{
		

		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void peymentConfrim_Load_1(object sender, EventArgs e)
		{
			label6.Text=name;
			label2.Text="$ "+amount;
			label4.Text=namecha;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
