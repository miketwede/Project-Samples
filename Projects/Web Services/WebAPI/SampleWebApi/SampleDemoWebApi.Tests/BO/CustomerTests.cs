using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SampleDemoWebApi.CustomerApi;
using SampleDemoWebApi.CustomerApi.Controllers;
using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;

//using log4net;
//using log4net.Config;
using NLog;

namespace SampleDemoWebApi.CustomerApi.Tests.Controllers
{
	[TestClass]
	public class DALTests
	{
		//private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private static Logger logger = LogManager.GetCurrentClassLogger();

		[TestMethod]
		public void GetCustomerByCustomerID()
		{
			int customerID;
			CustomerBO customerBO = new CustomerBO();
			Customer customer;

			customerID = -1;

			customer = customerBO.GetCustomerByCustomerID(customerID);

			Assert.IsNull(customer);


			customerID = 0;

			customer = customerBO.GetCustomerByCustomerID(customerID);

			Assert.IsNull(customer);


			customerID = 1;

			customer = customerBO.GetCustomerByCustomerID(customerID);

			Assert.IsNotNull(customer);
			Assert.AreEqual(customer.CustomerID, customerID);


			customerID = 2;

			customer = customerBO.GetCustomerByCustomerID(customerID);

			Assert.IsNotNull(customer);
			Assert.AreEqual(customer.CustomerID, customerID);


			customerID = 3;

			customer = customerBO.GetCustomerByCustomerID(customerID);

			Assert.IsNotNull(customer);
			Assert.AreEqual(customer.CustomerID, customerID);



		}

		[TestMethod]
		public void GetCustomers()
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomers();

			Assert.AreEqual(customers.Count, 3);
		}

		[TestMethod]
		public void GetCustomersByFirstName()
		{
			string FirstName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();

			// 1 from last name
			FirstName = "Fred";

			customers = customerBO.GetCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 1);

			// 1 from last name
			FirstName = "re";

			customers = customerBO.GetCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 0);

			// 0 from last name
			FirstName = "";

			customers = customerBO.GetCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 0);

			// 0 from last name
			FirstName = null;

			customers = customerBO.GetCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 0);
		}

		[TestMethod]
		public void GetCustomersByLastName()
		{
			string LastName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();

			// 2 from last name
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 2);

			// 2 from last name
			LastName = "Flint";

			customers = customerBO.GetCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 0);

			// 0 from last name
			LastName = "";

			customers = customerBO.GetCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 0);

			// 0 from last name
			LastName = null;

			customers = customerBO.GetCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 0);
		}

		[TestMethod]
		public void GetCustomersByFirstNameAndLastName()
		{
		string FirstName;
		string LastName;
		CustomerBO customerBO = new CustomerBO();
		List<Customer> customers = new List<Customer>();


		// one from first name 2 from last name
		FirstName = "Fred";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);


			// one from first name 2 from last name
			FirstName = "Fred";
			LastName = "";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


			// one from first name 2 from last name
			FirstName = "";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


			// one from first name 2 from last name
			FirstName = "re";
			LastName = "Flint";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);



			// one from first name 2 from last name
			FirstName = "re";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


			// none from first name 2 from last name
			FirstName = null;
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


			// one from first name none from last name
			FirstName = "Fred";
			LastName = null;

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// one from first name none from last name
			FirstName = null;
			LastName = null;

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// one from first name none from last name
			FirstName = "";
			LastName = "";

			customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

		}

		[TestMethod]
		public void GetCustomersByFirstNameOrLastName()
		{
			string FirstName;
			string LastName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();


			// one from first name 2 from last name
			FirstName = "Fred";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// one from first name 2 from last name
			FirstName = "Fred";
			LastName = "";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);


			// one from first name 2 from last name
			FirstName = "";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// one from first name 2 from last name
			FirstName = "re";
			LastName = "Flint";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);



			// one from first name 2 from last name
			FirstName = "re";
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// none from first name 2 from last name
			FirstName = null;
			LastName = "Flintstone";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// one from first name none from last name
			FirstName = "Fred";
			LastName = null;

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);

			// one from first name none from last name
			FirstName = null;
			LastName = null;

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// one from first name none from last name
			FirstName = "";
			LastName = "";

			customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


		}

		[TestMethod]
		public void SearchCustomersByFirstName()
		{
			string FirstName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();

			// 1 from last name
			FirstName = "Fred";

			customers = customerBO.SearchCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 1);

			// 1 from last name
			FirstName = "re";

			customers = customerBO.SearchCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 1);

			// 0 from last name
			FirstName = "";

			customers = customerBO.SearchCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 3);

			// 0 from last name
			FirstName = null;

			customers = customerBO.SearchCustomersByFirstName(FirstName);

			Assert.AreEqual(customers.Count, 0);
		}

		[TestMethod]
		public void SearchCustomersByLastName()
		{
			string LastName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();

			// 2 from last name
			LastName = "Flintstone";

			customers = customerBO.SearchCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 2);

			// 2 from last name
			LastName = "Flint";

			customers = customerBO.SearchCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 2);

			// 0 from last name
			LastName = "";

			customers = customerBO.SearchCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 3);

			// 0 from last name
			LastName = null;

			customers = customerBO.SearchCustomersByLastName(LastName);

			Assert.AreEqual(customers.Count, 0);

		}

		[TestMethod]
		public void SearchCustomersByFirstNameAndLastName()
		{
			string FirstName;
			string LastName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();


			// one from first name and 1 from last name
			FirstName = "Fred";
			LastName = "Flintstone";

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);


			// one from first name and 1 from last name
			FirstName = "re";
			LastName = "Flint";

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);


			// none from first name and 1 from last name
			FirstName = null;
			LastName = "Flint";

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);


			// one from first name none from last name
			FirstName = "re";
			LastName = null;

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// one from first name none from last name
			FirstName = null;
			LastName = null;

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// none from first name none from last name
			FirstName = "";
			LastName = "";

			customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 3);

		}

		[TestMethod]
		public void SearchCustomersByFirstNameOrLastName()
		{
			string FirstName;
			string LastName;
			CustomerBO customerBO = new CustomerBO();
			List<Customer> customers = new List<Customer>();


			// one from first name 2 from last name
			FirstName = "Fred";
			LastName = "Flintstone";

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// one from first name 2 from last name
			FirstName = "re";
			LastName = "Flint";

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// none from first name 2 from last name
			FirstName = null;
			LastName = "Flint";

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 2);


			// one from first name none from last name
			FirstName = "re";
			LastName = null;

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 1);

			// one from first name none from last name
			FirstName = null;
			LastName = null;

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 0);

			// one from first name none from last name
			FirstName = "";
			LastName = "";

			customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			Assert.AreEqual(customers.Count, 3);



		}

		[TestMethod]
		public void logfornet()
		{
			//log.Info("Hello logging world!");

			logger.Fatal("Sample fatal error message");

		}

	}
}
