using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1
{
	internal class timeupdate
	{
		public static String calculateTime()
		{
			var time = new DateTime(2022, 3, 12);
			var now = DateTime.Now;
			var timeuntil = time-now;

			String result = timeuntil.Days+" days "+
				timeuntil.Hours+" hours "+
				timeuntil.Minutes+" minutes until the race start!";

			return result;
		}
	}
}
