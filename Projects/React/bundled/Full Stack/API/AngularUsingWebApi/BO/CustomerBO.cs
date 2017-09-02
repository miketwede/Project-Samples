using System.Collections.Generic;

using ReactUsingWebApi.Models;
using ReactUsingWebApi.DAL;

namespace ReactUsingWebApi.BO
{
	public class CustomerBO
	{
		public List<Customer> GetCustomers()
		{
			CustomerDO customerDAL = new CustomerDO();

			List<Customer> customers = customerDAL.GetCustomers();

			if (customers == null)
			{
				customers = new List<Customer>();
				customers.Add(new Customer
				{
					CustomerID = 1,
					FirstName = "Fred",
					LastName = "Flinstone",
					MiddleInitial = "",
					NickName = "",
					Address1 = "",
					Address2 = "",
					City = "Bedrock",
					State = "A place right out of History",
					Zip = "",
					Age = 39,
					Occupation = "stone cutter",
					Hobbies = "bowling"
				});
				customers.Add(new Customer
				{
					CustomerID = 2,
					FirstName = "Wilma",
					LastName = "Flinstone",
					MiddleInitial = "",
					NickName = "Wilmaaaaaaaaaa",
					Address1 = "",
					Address2 = "",
					City = "Bedrock",
					State = "A place right out of History",
					Zip = "",
					Age = 29,
					Occupation = "house wife",
					Hobbies = "spending"
				});
			}

			return customers;
		}
	}
}