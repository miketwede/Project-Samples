//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SampleMVC.BO
//{
//	public class CustomerBO
//	{
//	}
//}
using System;
using System.Collections.Generic;

using SampleMVC.Models;
using SampleMVC.DAL;

namespace SampleMVC.BO
{
	public class CustomerBO
	{
		public Customer GetCustomerByCustomerID(int customerID)
		{
			CustomerDO customerDAL = new CustomerDO();

			Customer customer = customerDAL.GetCustomerByCustomerID(customerID);

			return customer;
		}

		public List<Customer> GetCustomers()
		{
			CustomerDO customerDAL = new CustomerDO();
			List<Customer> customers = new List<Customer>();

			try
			{
				customers = customerDAL.GetCustomers();

				if (customers == null)
				{
					customers = new List<Customer>();
					customers.Add(new Customer
					{
						customerID = 1,
						firstName = "Fred",
						lastName = "Flinstone",
						middleInitial = "",
						address1 = "",
						address2 = "",
						city = "Bedrock",
						state = "A place right out of History",
						zip = ""
					});
					customers.Add(new Customer
					{
						customerID = 2,
						firstName = "Wilma",
						lastName = "Flinstone",
						middleInitial = "",
						address1 = "",
						address2 = "",
						city = "Bedrock",
						state = "A place right out of History",
						zip = ""
					});
				}
			}
			catch (Exception ex)
			{
				throw;
			}


			return customers;
		}

		public List<Customer> GetCustomersByFirstName(string FirstName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.GetCustomersByFirstName(FirstName);

			return customers;
		}

		public List<Customer> GetCustomersByLastName(string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.GetCustomersByLastName(LastName);

			return customers;
		}

		public List<Customer> GetCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			return customers;
		}

		public List<Customer> GetCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			return customers;
		}

		public List<Customer> SearchCustomersByFirstName(string FirstName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.SearchCustomersByFirstName(FirstName);

			return customers;
		}

		public List<Customer> SearchCustomersByLastName(string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.SearchCustomersByLastName(LastName);

			return customers;
		}

		public List<Customer> SearchCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			return customers;
		}

		public List<Customer> SearchCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			return customers;
		}

		public string formatName(Customer customer)
		{
			var fullName = "";
			if (customer.title != null)
			{
				fullName += customer.title + " ";
			}
			fullName += customer.firstName + " ";
			if (customer.middleInitial != null)
			{
				fullName += customer.middleInitial + " ";
			}
			fullName += customer.lastName + " ";
			if (customer.suffix != null)
			{
				fullName += customer.suffix;
			}

			return fullName.Trim();
		}

		public string formatAddress(Customer customer)
		{
			var fullAddress = "";

			fullAddress += customer.address1 + " ";
			if (customer.address2 != null)
			{
				fullAddress += customer.address2 + " ";
			}

			fullAddress += customer.city + " ";
			fullAddress += customer.state + " ";
			fullAddress += customer.zip + " ";
			if (customer.country != null)
			{
				fullAddress += customer.country;
			}

			return fullAddress.Trim();
		}
	}
}