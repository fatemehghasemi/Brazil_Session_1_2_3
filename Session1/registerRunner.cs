using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
	public partial class registerRunner : Form
	{
		brezil2015Entities db = new brezil2015Entities();
		public registerRunner()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			String error = "";
			User user = new User();

			if (!String.IsNullOrEmpty(textBox1.Text))
			{
				try
				{
					user.Email = new MailAddress(textBox1.Text).Address;
				}
				catch (Exception)
				{
					error += "email address is invalid\n";
				}

			}
			else
			{
				error += "email address is required\n";
			}
			if (!String.IsNullOrEmpty(textBox2.Text))
			{
				if (textBox2.Text.Length >= 6)
				{
					Regex regex = new Regex("(?=.*[A-Z])(?=.*[1-9])(?=.*[@#!$^%])");

					if (regex.IsMatch(textBox2.Text))
					{
						user.Password = textBox2.Text;
					}
					else
					{
						error += "password must be Contains !@#$% and contains A-Z and contains dighit^\n";
					}
				}
				else
				{
					error += "password must be at least 6 character\n";
				}
			}
			else
			{
				error += "password is required\n";
			}

			if (!String.IsNullOrEmpty(textBox3.Text))
			{
				if (textBox2.Text != textBox3.Text)
				{
					error += "password agine not match\n";
				}
			}
			else
			{
				error += "password agine is required\n";
			}

			if (!String.IsNullOrEmpty(textBox4.Text))
			{

				user.FirstName = textBox4.Text;
			}
			else
			{
				error += "firstname is required\n";
			}

			if (!String.IsNullOrEmpty(textBox5.Text))
			{

				user.LastName = textBox5.Text;
			}
			else
			{
				error += "LastName is required\n";
			}

			if (!String.IsNullOrEmpty(dateTimePicker1.Text))
			{
				var diff = DateTime.Now.Date - dateTimePicker1.Value.Date;
				if ((diff.TotalDays / 365) < 10)
				{
					error += "age must be at least 10 yesrs\n";
				}
				else
				{
					user.LastName = textBox5.Text;
				}
			}
			else
			{
				error += "brith date is required\n";
			}
			if (String.IsNullOrEmpty(error))
			{
				user.RoleId = "R";
				db.Users.Add(user);
				db.SaveChanges();
				var runner = new Runner()
				{
					CountryCode = comboBox2.SelectedValue.ToString(),
					Email = user.Email,
					Gender = comboBox1.SelectedValue.ToString(),
					DateOfBirth = dateTimePicker1.Value

				};
				db.Runners.Add(runner);
				db.SaveChanges();
				new RegisterForAnEvent(runner).ShowDialog();
			}
			else
			{
				MessageBox.Show(error, "Wrning!");
			}
			if (String.IsNullOrEmpty(comboBox1.Text))
			{
				error += "gender is required\n";
			}
			if (String.IsNullOrEmpty(comboBox2.Text))
			{
				error += "country is required\n";
			}
		}

		private void registerRunner_Load(object sender, EventArgs e)
		{
			var gender = db.Genders.Select(c => new { id=c.Gender1,name=c.Gender1}).ToList();
			comboBox1.DataSource = gender;
			comboBox1.DisplayMember = "name";
			comboBox1.ValueMember = "id";

			var country = db.Countries.ToList();
			comboBox2.DataSource = country;
			comboBox2.DisplayMember = "CountryName";
			comboBox2.ValueMember = "CountryCode";
		}
	}
}
