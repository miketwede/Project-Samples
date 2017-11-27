﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SampleDemoWebApi.Models
//{
//	public class Person
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
	public class Person
	{
		public int personID;
		public string personType;
		public string title;
		public string firstName;
		public string lastName;
		public string middleInitial;
		public string suffix;
		public int addressID;
		public string address1;
		public string address2;
		public string city;
		public string state;
		public string zip;
		public string country;
		public int emailAddressID;
		public string emailAddress;
		public int phoneNumberID;
		public string phoneNumber;
		public string photo;
	}
}