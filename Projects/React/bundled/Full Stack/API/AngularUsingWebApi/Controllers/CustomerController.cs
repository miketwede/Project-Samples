using System.Collections.Generic;
using System.Web.Http;

using ReactUsingWebApi.Models;
using ReactUsingWebApi.BO;

namespace ReactUsingWebApi.Controllers
{
	[RoutePrefix("api/customers")]
	public class CustomerController : ApiController
	{
		[Route("{GetCustomers}")]
		public List<Customer> GetCustomers()
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomers();

			return customers;
		}

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
	}
}
