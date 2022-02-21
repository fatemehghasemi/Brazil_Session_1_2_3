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
	public partial class Form1 : Form
	{
		static Timer timer = new Timer();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timer.Interval=1000;
			timer.Tick+=new EventHandler(timer_tick);
			timer.Start();
		}

		private void timer_tick(object sender, EventArgs e)
		{
			time.Text=timeupdate.calculateTime();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Sponsorrunner sponsorrunner = new Sponsorrunner();
			sponsorrunner.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			moreInforation list = new moreInforation();
			list.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			new Login().ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new checkLogin().ShowDialog();
		}
	}
}
