using SampleDemoWebApi.CustomerApi.Models;

namespace customers.Models
{
	public class CustomerRow
	{
		private int customerID;
		private string accountNumber;
		private string name;
		private string address;
		private string phone;
		private string email;

		public CustomerRow(Customer customer)
		{
			customerID = customer.customerID;
			accountNumber = customer.accountNumber;
			name = customer.person.title + " " + customer.person.firstName + " " + customer.person.middleInitial + " " + customer.person.lastName + " " + customer.person.suffix;
			address = customer.person.address1 + " " + customer.person.address2 + " " + customer.person.city + " " + customer.person.state + " " + customer.person.zip + " " + customer.person.country;
			phone = customer.person.phoneNumber;
			email = customer.person.emailAddress;
		}

		public CustomerRow()
		{
		}


		public int CustomerID
		{
			get
			{
				return customerID;
			}
			set
			{
				customerID = value;
			}
		}

		public string AccountNumber
		{
			get
			{
				return accountNumber;
			}
			set
			{
				accountNumber = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}

		}

		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}

		public string Phone
		{
			get
			{
				return phone;
			}
			set
			{
				phone = value;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}


	}
}
