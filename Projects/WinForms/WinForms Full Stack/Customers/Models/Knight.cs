using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customers.Models
{
	public class Knight
	{
		private string hisName;
		private bool good;
		private Global.Title hisTitle;

		public Knight(Global.Title title, string name, bool good)
		{
			hisTitle = title;
			hisName = name;
			this.good = good;
		}

		public Knight()
		{
			hisTitle = Global.Title.Sir;
			hisName = "<enter name>";
			good = true;
		}

		public string Name
		{
			get
			{
				return hisName;
			}

			set
			{
				hisName = value;
			}
		}

		public bool GoodGuy
		{
			get
			{
				return good;
			}
			set
			{
				good = value;
			}
		}

		public Global.Title Title
		{
			get
			{
				return hisTitle;
			}
			set
			{
				hisTitle = value;
			}
		}
	}
}
