using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ReactUsingWebApi.Models;
using System.Configuration;
using System.Xml;

using NLog;

using ReactUsingWebApi.Global;

namespace ReactUsingWebApi.DAL
{
	public class CustomerDO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;

		public Customer GetCustomerByCustomerID(int customerID)
		{
			Customer customer = null;

			try
			{
				customer = GetCustomerADO("dbo.GetCustomerByCustomerID", customerID);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customer;
		}

		public List<Customer> GetCustomers()
		{
			List<Customer> customers = new List<Customer>();
			string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;

			// Test to see if there is a valid database connection.
			// Return null if there isn't.
			// Since this is a demo app, the users should be able to use it whether or not a valid database exists or not.
			SqlConnection testConnection = new SqlConnection(connectionString);
			try
			{
				testConnection.Open();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				customers = null;
				testConnection.Close();
				return customers;
			}
			testConnection.Close();


			try
			{
				customers = GetCustomersADO("dbo.GetCustomers");
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			return customers;

			
		}

		public List<Customer> GetCustomersByFirstName(string FirstName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName" };
			string[] FirstNameParameterValue = new string[] { FirstName };

			try
			{
				customers = GetCustomersADO("dbo.GetCustomersByFirstName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> GetCustomersByLastName(string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@LastName" };
			string[] FirstNameParameterValue = new string[] { LastName };

			try
			{
				customers = GetCustomersADO("dbo.GetCustomersByLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> GetCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName", "@LastName" };
			string[] FirstNameParameterValue = new string[] { FirstName, LastName };

			try
			{
				customers = GetCustomersADO("dbo.GetCustomersByFirstNameAndLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> GetCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName", "@LastName" };
			string[] FirstNameParameterValue = new string[] { FirstName, LastName };

			try
			{
				customers = GetCustomersADO("dbo.GetCustomersByFirstNameOrLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			return customers;
		}

		public List<Customer> SearchCustomersByFirstName(string FirstName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName" };
			string[] FirstNameParameterValue = new string[] { FirstName };

			try
			{
				customers = GetCustomersADO("dbo.SearchCustomersByFirstName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> SearchCustomersByLastName(string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@LastName" };
			string[] FirstNameParameterValue = new string[] { LastName };

			try
			{
				customers = GetCustomersADO("dbo.SearchCustomersByLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> SearchCustomersByFirstNameAndLastName(string FirstName, string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName" };
			string[] FirstNameParameterValue = new string[] { FirstName };

			try
			{
				customers = GetCustomersADO("dbo.SearchCustomersByFirstNameAndLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		public List<Customer> SearchCustomersByFirstNameOrLastName(string FirstName, string LastName)
		{
			List<Customer> customers = null;
			string[] FirstNameParameter = new string[] { "@FirstName" };
			string[] FirstNameParameterValue = new string[] { FirstName };

			try
			{
				customers = GetCustomersADO("dbo.SearchCustomersByFirstNameOrLastName", FirstNameParameter, FirstNameParameterValue);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customers;
		}

		#region ADO and utility functions

		private Customer GetCustomerADO(string queryString, int customerID)
		{
			Customer customer = null;
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@CustomerID", customerID);
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						XmlDocument DemographicsXML = new XmlDocument();
						XmlDocument AdditionalContactInfoXML = new XmlDocument();

						customer = new Customer
						{
							CustomerID = (int)reader["BusinessEntityID"],
							Title = reader["Title"].ToString(),
							FirstName = reader["FirstName"].ToString(),
							LastName = reader["LastName"].ToString(),
							MiddleInitial = reader["MiddleName"].ToString(),
							Suffix = reader["Suffix"].ToString(),
							Address1 = reader["AddressLine1"].ToString(),
							Address2 = reader["AddressLine2"].ToString(),
							City = reader["City"].ToString(),
							State = reader["State"].ToString(),
							Zip = reader["PostalCode"].ToString(),
							Country = reader["CountryRegionCode"].ToString(),
							EmailAddress = reader["EmailAddress"].ToString(),
							PhoneNumber = reader["PhoneNumber"].ToString(),
							EmailPromotion = (int)reader["EmailPromotion"],
							Demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
							AdditionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())

							//Demographics = (XmlElement)reader["Demographics"],
							//AdditionalContactInfo = (XmlElement)reader["AdditionalContactInfo"]

						};
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return customer;
		}

		private List<Customer> GetCustomersADO(string queryString, string[] parameterName = null, string[] parameterValue = null)
		{
			List<Customer> customers = new List<Customer>();
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				if ((parameterName != null) && (parameterValue != null) && (parameterName.Length > 0) && (parameterName.Length > 0))
				{
					for (int i = 0; i < parameterName.Length; i++)
					{
						if (!string.IsNullOrEmpty(parameterName[i]) && !string.IsNullOrEmpty(parameterValue[i]))
						{
							command.Parameters.AddWithValue(parameterName[i], parameterValue[i]);
						}
					}
				}

				//SqlCommand command = new SqlCommand(queryString, connection);
				//command.CommandType = CommandType.StoredProcedure;
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						//XmlDocument DemographicsXML = new XmlDocument();
						//XmlDocument AdditionalContactInfoXML = new XmlDocument();

						customers.Add(new Customer
						{
							CustomerID = (int)reader["BusinessEntityID"],
							Title = reader["Title"].ToString(),
							FirstName = reader["FirstName"].ToString(),
							LastName = reader["LastName"].ToString(),
							MiddleInitial = reader["MiddleName"].ToString(),
							Suffix = reader["Suffix"].ToString(),
							Address1 = reader["AddressLine1"].ToString(),
							Address2 = reader["AddressLine2"].ToString(),
							City = reader["City"].ToString(),
							State = reader["State"].ToString(),
							Zip = reader["PostalCode"].ToString(),
							Country = reader["CountryRegionCode"].ToString(),
							EmailAddress = reader["EmailAddress"].ToString(),
							PhoneNumber = reader["PhoneNumber"].ToString(),
							EmailPromotion = (int)reader["EmailPromotion"],
							Demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
							AdditionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())

							//Demographics = (XmlElement)reader["Demographics"],
							//AdditionalContactInfo = (XmlElement)reader["AdditionalContactInfo"]

						});
					}
					reader.Close();
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return customers;
		}

		private XmlDocument GetXML(string xml)
		{
			XmlDocument XmlDocument = new XmlDocument();
			if (string.IsNullOrEmpty(xml))
			{
				return XmlDocument;
			}

			XmlDocument.LoadXml(xml);

			return XmlDocument;
		}

		private IndividualSurvey ParseXML(XmlDocument xml)
		{
			decimal totalPurchaseYTD;
			int totalChildren;
			int numberChildrenAtHome;
			int homeOwnerFlag;
			int numberCarsOwned;

			IndividualSurvey individualSurvey = new IndividualSurvey();



			XmlNode head = xml.ChildNodes[0];

			if (Decimal.TryParse(head.ChildNodes[0].InnerXml, out totalPurchaseYTD))
				individualSurvey.TotalPurchaseYTD = totalPurchaseYTD;
			else
				individualSurvey.TotalPurchaseYTD = null;

			individualSurvey.DateFirstPurchase = DateTime.Parse(head.ChildNodes[1].InnerXml);
			individualSurvey.BirthDate = DateTime.Parse(head.ChildNodes[2].InnerXml);

			Globals.MaritalStatus.TryGetValue(head.ChildNodes[3].InnerXml, out individualSurvey.MaritalStatus);

			individualSurvey.YearlyIncome = head.ChildNodes[4].InnerXml;

			Globals.Gender.TryGetValue(head.ChildNodes[5].InnerXml, out individualSurvey.Gender);

			if (Int32.TryParse(head.ChildNodes[6].InnerXml, out totalChildren))
				individualSurvey.TotalChildren = totalChildren;
			else
				individualSurvey.TotalChildren = null;

			if (Int32.TryParse(head.ChildNodes[7].InnerXml, out numberChildrenAtHome))
				individualSurvey.NumberChildrenAtHome = numberChildrenAtHome;
			else
				individualSurvey.NumberChildrenAtHome = null;

			individualSurvey.Education = head.ChildNodes[8].InnerXml;
			individualSurvey.Occupation = head.ChildNodes[9].InnerXml;

			if (Int32.TryParse(head.ChildNodes[10].InnerXml, out homeOwnerFlag))
				individualSurvey.HomeOwnerFlag = Convert.ToBoolean(homeOwnerFlag);
			else
				individualSurvey.HomeOwnerFlag = null;

			if (Int32.TryParse(head.ChildNodes[11].InnerXml, out numberCarsOwned))
				individualSurvey.NumberCarsOwned = numberCarsOwned;
			else
				individualSurvey.NumberCarsOwned = null;

			individualSurvey.CommuteDistance = head.ChildNodes[12].InnerXml;









			//if (Decimal.TryParse(xml.SelectSingleNode("//IndividualSurvey/TotalPurchaseYTD/text()").Value, out totalPurchaseYTD))
			//	individualSurvey.TotalPurchaseYTD = totalPurchaseYTD;
			//else
			//	individualSurvey.TotalPurchaseYTD = null;

			//individualSurvey.DateFirstPurchase = DateTime.Parse(xml.SelectSingleNode("//IndividualSurvey/TotalPurchaseYTD/text()").Value);
			//individualSurvey.BirthDate = DateTime.Parse(xml.SelectSingleNode("//IndividualSurvey/BirthDate/text()").Value);

			//Globals.MaritalStatus.TryGetValue(xml.SelectSingleNode("//IndividualSurvey/MaritalStatus/text()").Value, out individualSurvey.MaritalStatus);

			//individualSurvey.YearlyIncome = xml.SelectSingleNode("//IndividualSurvey/YearlyIncome/text()").Value;

			//Globals.Gender.TryGetValue(xml.SelectSingleNode("//IndividualSurvey/Gender/text()").Value, out individualSurvey.Gender);

			//if (Int32.TryParse(xml.SelectSingleNode("//IndividualSurvey/TotalChildren/text()").Value, out totalChildren))
			//	individualSurvey.TotalChildren = totalChildren;
			//else
			//	individualSurvey.TotalChildren = null;

			//if (Int32.TryParse(xml.SelectSingleNode("//IndividualSurvey/NumberChildrenAtHome/text()").Value, out numberChildrenAtHome))
			//	individualSurvey.NumberChildrenAtHome = numberChildrenAtHome;
			//else
			//	individualSurvey.NumberChildrenAtHome = null;

			//individualSurvey.Education = xml.SelectSingleNode("//IndividualSurvey/Education/text()").Value;
			//individualSurvey.Occupation = xml.SelectSingleNode("//IndividualSurvey/Occupation/text()").Value;

			//if (Int32.TryParse(xml.SelectSingleNode("//IndividualSurvey/HomeOwnerFlag/text()").Value, out homeOwnerFlag))
			//	individualSurvey.HomeOwnerFlag = Convert.ToBoolean(homeOwnerFlag);
			//else
			//	individualSurvey.HomeOwnerFlag = null;

			//if (Int32.TryParse(xml.SelectSingleNode("//IndividualSurvey/NumberCarsOwned/text()").Value, out numberCarsOwned))
			//	individualSurvey.NumberCarsOwned = numberCarsOwned;
			//else
			//	individualSurvey.NumberCarsOwned = null;

			//individualSurvey.CommuteDistance = xml.SelectSingleNode("//IndividualSurvey/CommuteDistance/text()").Value;

			return individualSurvey;
		}

		#endregion



	}
}