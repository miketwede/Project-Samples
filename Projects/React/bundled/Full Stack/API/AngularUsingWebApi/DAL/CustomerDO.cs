using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ReactUsingWebApi.Models;
using System.Configuration;

namespace ReactUsingWebApi.DAL
{
	public class CustomerDO
	{
		public List<Customer> GetCustomers()
		{
			List<Customer> customers = new List<Customer>();
			string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;


			string queryString = "SELECT * from Customer C order by C.LastName, FirstName";

			// Specify the parameter value.
			//	int paramValue = 5;



			// Test to see if there is a valid database connection.
			// Return null if there isn't.
			// Since this is a demo app, the users should be able to use it whether or not a valid database exists or not.
			SqlConnection testConnection = new SqlConnection(connectionString);
			SqlCommand testCommand = new SqlCommand(queryString, testConnection);
			try
			{
				testConnection.Open();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); // TODO: log error message
				customers = null;
				testConnection.Close();
				return customers;
			}
			testConnection.Close();

			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
			//	command.Parameters.AddWithValue("@pricePoint", paramValue);

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{

						customers.Add(new Customer
						{
							CustomerID = (int)reader[0],
							FirstName = reader[1].ToString(),
							LastName = reader[2].ToString(),
							MiddleInitial = reader[3].ToString(),
							NickName = reader[4].ToString(),
							Address1 = reader[5].ToString(),
							Address2 = reader[6].ToString(),
							City = reader[7].ToString(),
							State = reader[8].ToString(),
							Zip = reader[9].ToString(),
							Age = (int)reader[10],
							Occupation = reader[11].ToString(),
							Hobbies = reader[12].ToString()
						});
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message); // TODO: log error message
					customers = null;
				}
			}

			return customers;
		}
	}
}