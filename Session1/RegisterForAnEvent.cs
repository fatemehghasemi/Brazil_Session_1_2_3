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
	public partial class RegisterForAnEvent : Form
	{
		brezil2015Entities db = new brezil2015Entities();
		decimal cost = 0;
		Runner Runner;
		String RaceKitOptionId;
		List<String> eventids = null;
		public RegisterForAnEvent()
		{
			InitializeComponent();
		}
		public RegisterForAnEvent(Runner Runner)
		{
			InitializeComponent();
			this.Runner = Runner;
		}
	
		private void RegisterForAnEvent_Load(object sender, EventArgs e)
		{
			var charity = db.Charities.ToList();
			comboBox1.DataSource = charity;
			comboBox1.DisplayMember = "CharityName";
			comboBox1.ValueMember = "CharityId";
			var race=db.RaceKitOptions.ToList();
			int y = 35;
			for (int i = 0; i < race.Count; i++)
			{
				RadioButton radio = new RadioButton();
				radio.Location = new Point(32, y);
				radio.Text = "Option " + race[i].RaceKitOptionId + " ($ " + race[i].Cost + ") :";
				radio.Width = 180;
				radio.Tag = race[i].Cost.ToString()+","+race[i].RaceKitOptionId;
				groupBox1.Controls.Add(radio);
				radio.CheckedChanged += check_changeRace;
				Label lab = new Label();
				lab.Location = new Point(250, y);
				lab.Text = race[i].RaceKitOption1;
				lab.Width = 200;
				lab.Height = 40;
				groupBox1.Controls.Add(lab);
				y += 50;
			}
			int y2 = 20;
			var events = db.Events.Include(c => c.EventType).Where(c=>c.MarathonId==5).ToList();

			for (int i = 0; i < events.Count; i++)
			{
				CheckBox check = new CheckBox();
				check.Text = events[i].EventType.EventTypeName + "($ " + events[i].Cost + ")";
				check.Tag = events[i].Cost.ToString()+","+events[i].EventId;
				check.Location = new Point(20, y2);
				check.CheckedChanged += check_changeRace;
				check.Width = 200;
				y2 += 20;
				panel1.Controls.Add(check);
			}


		}

		private void calculateCost()
		{
			eventids = new List<string>();
			cost = 0;
			var races=groupBox1.Controls.OfType<RadioButton>() ;
			foreach (var item in races)
			{
				if (item.Checked)
				{
					var val = item.Tag.ToString().Split(',');
					cost += Convert.ToDecimal(val[0]);
					RaceKitOptionId = val[1].ToString();
				}
			}
			var events = panel1.Controls.OfType<CheckBox>();
			foreach (var item in events)
			{
				if (item.Checked)
				{
					var val = item.Tag.ToString().Split(',');
					cost += Convert.ToDecimal(val[0]);
					eventids.Add(val[1].ToString());
				}
			}

			cost += numericUpDown1.Value;
			label8.Text="$ " + cost.ToString();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void check_changeRace(object sender, EventArgs e)
		{
			calculateCost();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			this.Close();
			new ThanksForRegisterRunner().ShowDialog();

		}

		private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
		{

		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			calculateCost();
		}
	}
}
