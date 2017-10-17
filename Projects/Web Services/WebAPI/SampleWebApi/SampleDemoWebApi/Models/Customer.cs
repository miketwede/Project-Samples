using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Drawing;

namespace SampleDemoWebApi.CustomerApi.Models
{
	public class Customer
	{
		public int customerID;
		public Person person;
		public string accountNumber;
		public int emailPromotion;
		public IndividualSurvey demographics;
		public XmlDocument additionalContactInfo;
	}
}