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
	public partial class RaceResultRunner : Form
	{
		brezil2015Entities db = new brezil2015Entities();
		public RaceResultRunner()
		{
			InitializeComponent();
		}

		private void RaceResultRunner_Load(object sender, EventArgs e)
		{
			fillDataTable();
		}

		private void fillDataTable()
		{
			List<EventsRunner> eventsrunerlist = new List<EventsRunner>();
			var user = LoginInfo.curentuser;
			var runner = db.Runners.Where(c => c.Email == user.Email).FirstOrDefault();
			var registrationEvents = db.RegistrationEvents.Include(c => c.Event)
				.Include(c => c.Event.Marathon)
				.Include(c => c.Event.EventType)
				.Include(c => c.Registration)
				.Include(c => c.Registration.Runner);

			var runnerevent = registrationEvents.Where(c => c.Registration.RunnerId == runner.RunnerId).ToList();
			foreach (var item in runnerevent)
			{
				var runnerssameevent = registrationEvents.
					Where(c => 
					c.EventId == item.EventId &&
					c.Event.MarathonId==item.Event.MarathonId
					&&item.RaceTime!=null
					&&item.RaceTime!=0)
					.GroupBy(c=>c.RaceTime).ToList();

				var runnerItemFound=runnerssameevent.
					Where(c => c.Where(d=>d.Registration.RunnerId == runner.RunnerId).Any())
					.FirstOrDefault();

				var Rank=runnerssameevent.IndexOf(runnerItemFound) + 1;


				var samegender = registrationEvents.Where(c => c.EventId == item.EventId
				  && c.Event.MarathonId == item.Event.MarathonId
				  && c.Registration.Runner.Gender == item.Registration.Runner.Gender
				  && c.RaceTime!=null &&c.RaceTime!=0)
						.GroupBy(c => c.RaceTime).ToList();

				var samegenderItemFound = samegender.Where(c => c
				.Where(d => d.Registration.RunnerId == runner.RunnerId).Any())
					.FirstOrDefault();

				var categoryRank = samegender.IndexOf(samegenderItemFound);


				EventsRunner newevent = new EventsRunner();
				newevent.Marathon = item.Event.Marathon.MarathonName;
				newevent.Event = item.Event.EventName;

				TimeSpan time = TimeSpan.FromSeconds(item.RaceTime.Value);
				newevent.Time = time.Hours + "h " +time.Minutes + "m " +  time.Seconds + "s ";

				//newevent.Time = item.RaceTime.ToString();
				newevent.OverallRank = "#" + Rank.ToString();
				newevent.CategoryRank = "#" + categoryRank.ToString();

				eventsrunerlist.Add(newevent);
			}


			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Marathon");
			dataTable.Columns.Add("Event");
			dataTable.Columns.Add("Time");
			dataTable.Columns.Add("OverallRank");
			dataTable.Columns.Add("CategoryRank");

			foreach (var item in eventsrunerlist)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Marathon"] = item.Marathon;
				dataRow["Event"] = item.Event;
				dataRow["Time"] = item.Time;
				dataRow["OverallRank"] = item.OverallRank;
				dataRow["CategoryRank"] = item.CategoryRank;

				dataTable.Rows.Add(dataRow);

			}

			dataGridView1.DataSource = dataTable;

		}
	}
	public class EventsRunner
	{
		public String Marathon;
		public String Event;
		public String Time;
		public String OverallRank;
		public String CategoryRank;
	

	}

}
