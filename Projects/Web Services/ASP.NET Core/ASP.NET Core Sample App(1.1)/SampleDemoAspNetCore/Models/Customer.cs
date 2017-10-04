//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SampleDemoAspNetCore.Models
//{
//    public class Customer
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Xml;
//using System.Drawing;

namespace SampleDemoAspNetCore.Models
{
	public class Customer
	{
		public int CustomerID;
		public string Title;
		public string FirstName;
		public string LastName;
		public string MiddleInitial;
		public string Suffix;
		public string Address1;
		public string Address2;
		public string City;
		public string State;
		public string Zip;
		public string Country;
		public string EmailAddress;
		public string PhoneNumber;
		public string AccountNumber;
		//public Image Photo;
		public string Photo;
		public int EmailPromotion;
		public IndividualSurvey Demographics;
		public XmlDocument AdditionalContactInfo;
	}
}