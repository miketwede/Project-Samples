//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SampleDemoWebApi.Models
//{
//	public class SalesPerson
//	{
//	}
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Drawing;

namespace SampleDemoWebApi.CustomerApi.Models
{
	public class SalesPerson
	{
		public int salesPersonID;
		public int territiryID;
		public Person person;
		public decimal salesQuota;
		public decimal bonus;
		public decimal commissionPct;
		public decimal salesYTD;
		public decimal salesLastYear;

	}
}