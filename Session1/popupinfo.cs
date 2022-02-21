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
	public partial class popupinfo : Form
	{
		Charity runneerCharity;
		public popupinfo()
		{
			InitializeComponent();
		}
		public popupinfo(Charity runneerCharity)
		{
			InitializeComponent();
			this.runneerCharity=runneerCharity;
			
		}
		private void popupinfo_Load(object sender, EventArgs e)
		{
			pictureBox1.Image=Image.FromFile(AppDomain.CurrentDomain.BaseDirectory+"images\\"+runneerCharity.CharityLogo);
			label2.Text=runneerCharity.CharityName;

			label3.Text=runneerCharity.CharityDescription;

		}
	}
}
