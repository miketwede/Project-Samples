using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
	public class Actor
	{
		//public int ID;
		//public string Firstname;
		//public string Lastname;
		//public DateTime LastUpdated; 

		public int ID { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateTime LastUpdated { get; set; }

		public Actor(int id, string firstname, string lastname, DateTime lastUpdated)
		{
			ID = id;
			Firstname = firstname;
			Lastname = lastname;
			LastUpdated = lastUpdated;
		}
	}
}
