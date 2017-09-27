using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SampleDemoWebApi.CustomerApi.Models;
using System.Configuration;
using System.Xml;
using System.IO;

using NLog;

using SampleDemoWebApi.CustomerApi.Global;
using System.Drawing;

namespace SampleDemoWebApi.CustomerApi.DAL
{
	public class CustomerDO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;


		#region GET Customer functions

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

		#endregion

		#region SAVE Customer functions

		public Customer UpdateCustomer(Customer customer)
		{
		//	Customer customer = null;

			try
			{
				customer = CreateCustomerADO("dbo.CreateNewCustomer", customer);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return customer;
		}
		public Customer CreateCustomer(Customer customerInfo)
		{
			Customer newCustomer = new Customer();

			try
			{
				newCustomer = CreateCustomerADO("dbo.CreateNewCustomer", customerInfo);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return newCustomer;
		}


		#endregion

		#region ADO functions

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
							AccountNumber = reader["AccountNumber"].ToString(),
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
							AccountNumber = reader["AccountNumber"].ToString(),
							Photo = reader["Photo"] == System.DBNull.Value ? null : getImage((byte[])reader["Photo"]),
							EmailPromotion = (int)reader["EmailPromotion"],
							Demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
							AdditionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())
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

		private Customer CreateCustomerADO(string queryString, Customer customerInfo)
		{
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@CustomerID", customerInfo.CustomerID);
				command.Parameters.AddWithValue("@Title", customerInfo.Title);
				command.Parameters.AddWithValue("@FirstName", customerInfo.FirstName);
				command.Parameters.AddWithValue("@LastName", customerInfo.LastName);
				command.Parameters.AddWithValue("@MiddleInitial", customerInfo.MiddleInitial);
				command.Parameters.AddWithValue("@Suffix", customerInfo.Suffix);
				command.Parameters.AddWithValue("@Address1", customerInfo.Address1);
				command.Parameters.AddWithValue("@Address2", customerInfo.Address2);
				command.Parameters.AddWithValue("@City", customerInfo.City);
				command.Parameters.AddWithValue("@State", customerInfo.State);
				command.Parameters.AddWithValue("@Zip", customerInfo.Zip);
				command.Parameters.AddWithValue("@Country", customerInfo.Country);
				command.Parameters.AddWithValue("@EmailAddress", customerInfo.EmailAddress);
				command.Parameters.AddWithValue("@PhoneNumber", customerInfo.PhoneNumber);
				command.Parameters.AddWithValue("@AccountNumber", customerInfo.AccountNumber);
				command.Parameters.AddWithValue("@EmailPromotion", customerInfo.EmailPromotion);
				command.Parameters.AddWithValue("@Demographics", customerInfo.Demographics);
				command.Parameters.AddWithValue("@AdditionalContactInfo", customerInfo.AdditionalContactInfo);

				try
				{
					connection.Open();
					int result = command.ExecuteNonQuery();
					customerInfo.CustomerID = (int)command.Parameters["@CustomerID"].SqlValue;
					customerInfo.AccountNumber = (string)command.Parameters["@AccountNumber"].SqlValue;
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return customerInfo;
		}

		#endregion

		#region Utility functions

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
			return individualSurvey;
		}
		//Open file in to a filestream and read data in a byte array.
		byte[] ReadFile(string sPath)
		{
			//Initialize byte array with a null value initially.
			byte[] data = null;

			//Use FileInfo object to get file size.
			FileInfo fInfo = new FileInfo(sPath);
			long numBytes = fInfo.Length;

			//Open FileStream to read file
			FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

			//Use BinaryReader to read file stream into byte array.
			BinaryReader br = new BinaryReader(fStream);

			//When you use BinaryReader, you need to supply number of bytes 
			//to read from file.
			//In this case we want to read entire file. 
			//So supplying total number of bytes.
			data = br.ReadBytes((int)numBytes);

			return data;
		}

		public void saveImage(string path, string filename, int businessEntityID)
		{
			try
			{
				//Read Image Bytes into a byte array
				//	byte[] imageData = ReadFile(Path.Combine(path, filename));
				string originalPath = Path.Combine(path, filename);
				byte[] imageData = File.ReadAllBytes(originalPath);

				//Initialize SQL Server Connection
				SqlConnection CN = new SqlConnection(connectionString);

				//Set insert query
				string qry = "insert into Person.Photo (BusinessEntityID, Photo, FileName) values(@BusinessEntityID, @Photo, @FileName)";

				//Initialize SqlCommand object for insert.
				SqlCommand SqlCom = new SqlCommand(qry, CN);

				//We are passing Original Image Path and 
				//Image byte data as SQL parameters.
				SqlCom.Parameters.Add(new SqlParameter("@BusinessEntityID", businessEntityID));
				SqlCom.Parameters.Add(new SqlParameter("@Photo", (object)imageData));
				SqlCom.Parameters.Add(new SqlParameter("@FileName", (object)originalPath));

				//Open connection and execute insert query.
				CN.Open();
				SqlCom.ExecuteNonQuery();
				CN.Close();

				//Close form and return to list or images.
				//this.Close();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return;
		}

		public Image getImage()
		{
			try
			{
				//Initialize SQL Server connection.

				SqlConnection CN = new SqlConnection(connectionString);

				//Initialize SQL adapter.
				SqlDataAdapter ADAP = new SqlDataAdapter("Select * from Person.Photo", CN);

				//Initialize Dataset.
				DataSet DS = new DataSet();

				//Fill dataset with ImagesStore table.
				ADAP.Fill(DS, "ImagesStore");

				//Fill Grid with dataset.
				System.Data.DataTable table = DS.Tables["ImagesStore"];

				byte[] ba = (byte[])table.Rows[0].ItemArray[2];



				using (var ms = new MemoryStream(ba))
				{
					return Image.FromStream(ms);
				}


			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			//return null;
		}

		//public Image getImage(byte[] ba)
		public string getImage(byte[] ba)
		{
			if (ba == null)
				return null;

			try
			{
				return Convert.ToBase64String(ba);
				//using (var ms = new MemoryStream(ba))
				//{
				//	Convert.ToBase64String(ba);
				//	return Image.FromStream(ms);
				//}


			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			//return null;
		}

		#endregion



	}
}