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
		public int TerritoryID;
		public string group;
		public string country;
		public string region;
		public string salesLastYear;
		public string salesYTD;
		public string costLastYear;
		public string costYTD;
		public XmlDocument additionalContactInfo;
	}
}