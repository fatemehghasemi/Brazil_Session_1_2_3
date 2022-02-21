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
	public partial class howLongIsMarathon : Form
	{
		Dictionary<String, double> listSpeed = new Dictionary<string, double>();
		Dictionary<String, double> ListDistance = new Dictionary<string, double>();

		public howLongIsMarathon()
		{
			InitializeComponent();
		}

		private void pictureBox11_Click(object sender, EventArgs e)
		{
			//Distance pic Click
			PictureBox box = (PictureBox)sender;
			var item = ListDistance.Where(c => c.Key == box.Tag.ToString()).FirstOrDefault();
			var lentgh = item.Value;
			var lenghfinal = (1000 * 42) / lentgh;
			discription.Text = $"The length of a {item.Key} is {item.Value}m. It would take {lenghfinal}m of them to cover the track of a 42km marathon";
			pictureBox13.Image = box.Image;
			name.Text = box.Tag.ToString();

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			//Speed pic Click
			PictureBox box = (PictureBox)sender;
			var item = listSpeed.Where(c => c.Key == box.Tag.ToString()).FirstOrDefault();
			var speed = item.Value;
			var time = (60 * 42) / speed;

			discription.Text = $"The top speed of a {item.Key} is {item.Value}km/h. It would take {time} minute to complete a 42km marathon";
			pictureBox13.Image = box.Image;
			name.Text = box.Tag.ToString();


		}

		private void howLongIsMarathon_Load(object sender, EventArgs e)
		{
			listSpeed.Add("F1 Car", 345);//km/h
			listSpeed.Add("Slug", 0.01);
			listSpeed.Add("Horse", 15);
			listSpeed.Add("Sloth", 0.12);
			listSpeed.Add("Capybara", 35);
			listSpeed.Add("Jaguar", 80);
			listSpeed.Add("Worm", 0.03);

			ListDistance.Add("Bus", 10);//m
			ListDistance.Add("Pair of Havaianas", 0.245);
			ListDistance.Add("Airbus A380", 73);
			ListDistance.Add("Football Field", 105);
			ListDistance.Add("Ronaldinho", 1.181);

		}
	}
}
