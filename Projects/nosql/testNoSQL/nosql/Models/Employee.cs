using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nosql.Models
{
	public class Employee
	{
		public int OID { get; set; }  // note; setting an OID is not required and would happen behind the scenes if you omit it
		public Company Employer { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
		public DateTime HireDate { get; set; }
		public string City { get; set; }
	}
}
