using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Drawing;

namespace SampleDemoWebApi.CustomerApi.Models
{
	public class SalesTerritory
	{
		public int territoryID;
		public string group;
		public string country;
		public string region;
		public decimal salesLastYear;
		public decimal salesYTD;
		public decimal costLastYear;
		public decimal costYTD;
		public List<SalesPerson> salesPersons;
	}
}