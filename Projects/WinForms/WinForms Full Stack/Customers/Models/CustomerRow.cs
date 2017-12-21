using SampleDemoWebApi.CustomerApi.Models;

namespace customers.Models
{
	public class CustomerRow
	{
		private string accountNumber;
		private string name;
		private string address;
		private string phone;
		private string email;

		public CustomerRow(Customer customer)
		{
			accountNumber = customer.accountNumber;
			name = customer.person.title + " " + customer.person.firstName + " " + customer.person.middleInitial + " " + customer.person.lastName + " " + customer.person.suffix;
			address = customer.person.address1 + " " + customer.person.address2 + " " + customer.person.city + " " + customer.person.state + " " + customer.person.zip + " " + customer.person.country;
			phone = customer.person.phoneNumber;
			email = customer.person.emailAddress;
		}

		public string AccountNumber
		{
			get
			{
				return accountNumber;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public string Address
		{
			get
			{
				return address;
			}
		}

		public string Phone
		{
			get
			{
				return phone;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
		}


	}
}
