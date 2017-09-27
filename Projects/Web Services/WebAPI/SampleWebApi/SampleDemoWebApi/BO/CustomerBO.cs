using System;
using System.Collections.Generic;

using SampleDemoWebApi.CustomerApi.Models;
using SampleDemoWebApi.CustomerApi.DAL;

namespace SampleDemoWebApi.CustomerApi.BO
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
						CustomerID = 1,
						FirstName = "Fred",
						LastName = "Flinstone",
						MiddleInitial = "",
						Address1 = "",
						Address2 = "",
						City = "Bedrock",
						State = "A place right out of History",
						Zip = ""
					});
					customers.Add(new Customer
					{
						CustomerID = 2,
						FirstName = "Wilma",
						LastName = "Flinstone",
						MiddleInitial = "",
						Address1 = "",
						Address2 = "",
						City = "Bedrock",
						State = "A place right out of History",
						Zip = ""
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
	}
}