using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;

using NLog;

using customers.Models;

namespace customers.DAL
{
	public class CustomerDO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public List<CustomerRow> GetCustomers()
		{
			List<CustomerRow> customerRows = new List<CustomerRow>();
			string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;
			OleDbDataReader reader = null;

			// Test to see if there is a valid database connection.
			// Return null if there isn't.
			// Since this is a demo app, the users should be able to use it whether or not a valid database exists or not.
			OleDbConnection connection = new OleDbConnection(connectionString);
			try
			{
				connection.Open();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				customerRows = null;
				connection.Close();
				return customerRows;
			}

			try
			{
				OleDbCommand command = new OleDbCommand("SELECT * from  Customers", connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					customerRows.Add(
						  new CustomerRow
						  {
							  CustomerID = (int)reader["CustomerID"],
							  AccountNumber = reader["AccountNumber"].ToString(),
							  Name = reader["CustomerName"].ToString(),
							  Address = reader["Address"].ToString(),
							  Phone = reader["Phone"].ToString(),
							  Email = reader["Email"].ToString()
						  }
						  );
				}

				connection.Close();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			finally
			{
				connection.Close();
			}

			return customerRows;
		}

	}
}
