using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Drawing;

namespace SampleDemoAspNetCore.Models
{
	public class Customer
	{
		public int customerID;
		public string title;
		public string firstName;
		public string lastName;
		public string middleInitial;
		public string suffix;
		public string address1;
		public string address2;
		public string city;
		public string state;
		public string zip;
		public string country;
		public string emailAddress;
		public string phoneNumber;
		public string accountNumber;
		//public Image Photo;
		public string photo;
		public int emailPromotion;
		public IndividualSurvey demographics;
		public XmlDocument additionalContactInfo;
	}
}