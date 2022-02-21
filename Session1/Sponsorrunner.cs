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
	public partial class Sponsorrunner : Form
	{
		Charity runneerCharity;
		brezil2015Entities db = new brezil2015Entities();
		public Sponsorrunner()
		{
			InitializeComponent();
		}
		private void Sponsorrunner_Load(object sender, EventArgs e)
		{
			pictureBox1.Image= Session1.Properties.Resources.info;

			comboBox1.DataSource= db.Runners.Include(c => c.User).Select(c => new { Name = c.User.FirstName+","+c.User.LastName+" - "+c.CountryCode, ID = c.RunnerId }).ToList();
			comboBox1.ValueMember="ID";
			comboBox1.DisplayMember="Name";
		}



		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			String mess = "";
			if (String.IsNullOrEmpty(textBox1.Text))
				mess+="please enter your name\n";

			if (String.IsNullOrEmpty(textBox5.Text))
				mess+="please enter Name On Card\n";

			if (String.IsNullOrEmpty(textBox6.Text)||textBox6.Text.Length<16)
				mess+="please enter valid Cerdit Card\n";

			if (String.IsNullOrEmpty(textBox4.Text)||textBox4.Text.Length<3)
				mess+="please enter valid CVC\n";

			if (String.IsNullOrEmpty(comboBox1.Text))
				mess+="please select runner\n";

			if (String.IsNullOrEmpty(textBox7.Text.Trim()))
				mess+="please enter amount\n";

			if (String.IsNullOrEmpty(textBox2.Text.Trim())||String.IsNullOrEmpty(textBox2.Text.Trim()))
			{
				mess+="please enter full date\n";
				if (int.TryParse(textBox2.Text, out int s))
				{
					if (s<DateTime.Now.Date.Year)
					{
						mess+="please enter valid year\n";
					}
					else if (s==DateTime.Now.Date.Year)
					{
						if (int.TryParse(textBox3.Text, out int n))
						{
							if (n<DateTime.Now.Date.Month)
							{
								mess+="please enter valid month\n";
							}
						}
					}
				}
			}

			if (mess.Length>0)
			{
				MessageBox.Show(mess);
			}
			else
			{
				int runnerid = Convert.ToInt32(comboBox1.SelectedValue);
				var register = db.Registrations.Where(c => c.RunnerId==runnerid).FirstOrDefault();

				if (register!=null)
				{

					Sponsorship newitem = new Sponsorship()
					{
						Amount=Convert.ToInt64(textBox7.Text),
						RegistrationId=register.RegistrationId,
						SponsorName=textBox1.Text.ToString(),
					};
					db.Sponsorships.Add(newitem);
					db.SaveChanges();
				}



				this.Close();
				runneerCharity=db.Charities.Where(c => c.CharityId==register.CharityId).FirstOrDefault();
				var runner = db.Runners.Where(c => c.RunnerId==runnerid).FirstOrDefault();
				var user = db.Users.Where(c => c.Email==runner.Email).FirstOrDefault();
				peymentConfrim peymentConfrim = new peymentConfrim(runneerCharity.CharityName, user.FirstName+' '+user.LastName+" from "+runner.CountryCode, textBox7.Text);
				peymentConfrim.ShowDialog();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			int val = Convert.ToInt32(textBox7.Text);
			val++;
			textBox7.Text=val.ToString();
			label13.Text="$ "+textBox7.Text.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int val = Convert.ToInt32(textBox7.Text);
			if (val>0)
			{
				val--;
				textBox7.Text=val.ToString();
				label13.Text="$ "+textBox7.Text.ToString();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{


			if (!String.IsNullOrEmpty(comboBox1.Text))
			{
				int runnerid = Convert.ToInt32(comboBox1.SelectedValue);
				var register = db.Registrations.Where(c => c.RunnerId==runnerid).FirstOrDefault();
				runneerCharity=db.Charities.Where(c => c.CharityId==register.CharityId).FirstOrDefault();

				var formPopup = new popupinfo(runneerCharity);
				formPopup.ShowDialog();
			}


		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(comboBox1.Text))
			{
				if (int.TryParse(comboBox1.SelectedValue.ToString(), out int value))
				{
					int runnerid = Convert.ToInt32(comboBox1.SelectedValue);
					var register = db.Registrations.Where(c => c.RunnerId==runnerid).FirstOrDefault();
					runneerCharity=db.Charities.Where(c => c.CharityId==register.CharityId).FirstOrDefault();
					label6.Text=runneerCharity.CharityName;
				}
			}
		}
	}
}
