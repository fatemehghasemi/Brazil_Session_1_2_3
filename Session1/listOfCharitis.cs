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
	public partial class listOfCharitis : Form
	{
		brezil2015Entities db = new brezil2015Entities();

		public listOfCharitis()
		{
			InitializeComponent();
		}

		private void listOfCharitis_Load(object sender, EventArgs e)
		{
			var items = db.Charities.ToList();
			int xp = 40, yp = 160;
			int xdescription = 220, ydescription = 200;
			int xname = 220, yname = 170;
			foreach (var item in items)
			{
			
				PictureBox picture = new PictureBox();
				picture.Location=new Point(xp, yp);
				picture.SizeMode=PictureBoxSizeMode.StretchImage;
				picture.Width=100;
				picture.Height=100;
				picture.Image=Image.FromFile(AppDomain.CurrentDomain.BaseDirectory+"images\\"+item.CharityLogo);
				yp+=200;

				Label name = new Label();
				name.Text=item.CharityName;
				var fontfamily = new FontFamily("Microsoft Sans Serif");
				name.Font=new Font(fontfamily, 16);
				name.Location=new Point(xname, yname);
				yname+=200;

				Label description = new Label();
				description.Text=item.CharityDescription;
				//description.MaximumSize=new Size(800, 0);
				description.Width=1100;
				description.Height=150;
				description.Location=new Point(xdescription, ydescription);
				ydescription+=200;

				panel2.Controls.Add(description);
				panel2.Controls.Add(name);
				panel2.Controls.Add(picture);



			}
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
