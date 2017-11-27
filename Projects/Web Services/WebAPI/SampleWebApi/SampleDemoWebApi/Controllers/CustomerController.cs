using System.Collections.Generic;
using System.Web.Http;

using SampleDemoWebApi.CustomerApi.Models;
using SampleDemoWebApi.CustomerApi.BO;

namespace SampleDemoWebApi.CustomerApi.Controllers
{
	[RoutePrefix("api/customers")]
	public class CustomerController : ApiController
	{


		#region GET
		[Route("{GetCustomerByCustomerID}")]
		public Customer GetCustomerByCustomerID(int customerID)
		{
			CustomerBO customerBO = new CustomerBO();

			Customer customer = customerBO.GetCustomerByCustomerID(customerID);

			return customer;
		}

		[Route("{GetCustomers}")]
		public List<Customer> GetCustomers()
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomers();

			return customers;
		}

		[Route("{GetCustomersByFirstName}")]
		public List<Customer> GetCustomersByFirstName(string FirstName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomersByFirstName(FirstName);

			return customers;
		}

		[Route("{GetCustomersByLastName}")]
		public List<Customer> GetCustomersByLastName(string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomersByLastName(LastName);

			return customers;
		}

		[Route("{GetCustomersByFirstNameAndLastName}")]
		public List<Customer> GetCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomersByFirstNameAndLastName(FirstName, LastName);

			return customers;
		}

		[Route("{GetCustomersByFirstNameOrLastName}")]
		public List<Customer> GetCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomersByFirstNameOrLastName(FirstName, LastName);

			return customers;
		}

		[Route("{SearchCustomersByFirstName}")]
		public List<Customer> SearchCustomersByFirstName(string FirstName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.SearchCustomersByFirstName(FirstName);

			return customers;
		}

		[Route("{SearchCustomersByLastName}")]
		public List<Customer> SearchCustomersByLastName(string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.SearchCustomersByLastName(LastName);

			return customers;
		}

		[Route("{SearchCustomersByFirstNameAndLastName}")]
		public List<Customer> SearchCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.SearchCustomersByFirstNameAndLastName(FirstName, LastName);

			return customers;
		}

		[Route("{SearchCustomersByFirstNameOrLastName}")]
		public List<Customer> SearchCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.SearchCustomersByFirstNameOrLastName(FirstName, LastName);

			return customers;
		}
		#endregion

		#region UPDATE
		[Route("{UpdateCustomer}")]
		public void UpdateCustomer(Customer customer)
		{
			CustomerBO customerBO = new CustomerBO();

			customerBO.UpdateCustomer(customer);

			return;
		}

		#endregion

		#region not used

		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}

		#endregion
	}
}
