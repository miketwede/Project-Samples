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

		public void UpdateCustomer(Customer customer)
		{
		//	Customer customer = null;

			try
			{
				UpdateCustomerADO("dbo.UpdateCustomer", customer);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return;
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
							customerID = (int)reader["CustomerID"],
							person = new Person
							{
								personID = (int)reader["PersonID"],
								personType = reader["PersonType"].ToString(),
								title = reader["Title"].ToString(),
								firstName = reader["FirstName"].ToString(),
								lastName = reader["LastName"].ToString(),
								middleInitial = reader["MiddleName"].ToString(),
								suffix = reader["Suffix"].ToString(),
								addressID = (int)reader["AddressID"],
								address1 = reader["AddressLine1"].ToString(),
								address2 = reader["AddressLine2"].ToString(),
								city = reader["City"].ToString(),
								state = reader["State"].ToString(),
								zip = reader["PostalCode"].ToString(),
								country = reader["CountryRegionCode"].ToString(),
								emailAddressID = (int)reader["EmailAddressID"],
								emailAddress = reader["EmailAddress"].ToString(),
								phoneNumberID = (int)reader["PhoneNumberID"],
								phoneNumber = reader["PhoneNumber"].ToString(),
								photo = reader["Photo"] == System.DBNull.Value ? null : getImage((byte[])reader["Photo"])
							},

							accountNumber = reader["AccountNumber"].ToString(),
							emailPromotion = (int)reader["EmailPromotion"],
							demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
							additionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())

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
							customerID = (int)reader["CustomerID"],
							person = new Person
							{
								personID = (int)reader["PersonID"],
								personType = reader["PersonType"].ToString(),
								title = reader["Title"].ToString(),
								firstName = reader["FirstName"].ToString(),
								lastName = reader["LastName"].ToString(),
								middleInitial = reader["MiddleName"].ToString(),
								suffix = reader["Suffix"].ToString(),
								addressID = (int)reader["AddressID"],
								address1 = reader["AddressLine1"].ToString(),
								address2 = reader["AddressLine2"].ToString(),
								city = reader["City"].ToString(),
								state = reader["State"].ToString(),
								zip = reader["PostalCode"].ToString(),
								country = reader["CountryRegionCode"].ToString(),
								emailAddressID = (int)reader["EmailAddressID"],
								emailAddress = reader["EmailAddress"].ToString(),
								phoneNumberID = (int)reader["PhoneNumberID"],
								phoneNumber = reader["PhoneNumber"].ToString(),
								photo = reader["Photo"] == System.DBNull.Value ? null : getImage((byte[])reader["Photo"])
							},
							accountNumber = reader["AccountNumber"].ToString(),
							emailPromotion = (int)reader["EmailPromotion"],
							demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
							additionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())
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
				command.Parameters.AddWithValue("@CustomerID", customerInfo.customerID);

				command.Parameters.AddWithValue("@PersonType", customerInfo.person.personType);
				command.Parameters.AddWithValue("@Title", customerInfo.person.title);
				command.Parameters.AddWithValue("@FirstName", customerInfo.person.firstName);
				command.Parameters.AddWithValue("@LastName", customerInfo.person.lastName);
				command.Parameters.AddWithValue("@MiddleInitial", customerInfo.person.middleInitial);
				command.Parameters.AddWithValue("@Suffix", customerInfo.person.suffix);
				command.Parameters.AddWithValue("@Address1", customerInfo.person.address1);
				command.Parameters.AddWithValue("@Address2", customerInfo.person.address2);
				command.Parameters.AddWithValue("@City", customerInfo.person.city);
				command.Parameters.AddWithValue("@State", customerInfo.person.state);
				command.Parameters.AddWithValue("@Zip", customerInfo.person.zip);
				command.Parameters.AddWithValue("@Country", customerInfo.person.country);
				command.Parameters.AddWithValue("@EmailAddress", customerInfo.person.emailAddress);
				command.Parameters.AddWithValue("@PhoneNumber", customerInfo.person.phoneNumber);
				command.Parameters.AddWithValue("@AccountNumber", customerInfo.accountNumber);
				command.Parameters.AddWithValue("@EmailPromotion", customerInfo.emailPromotion);
				command.Parameters.AddWithValue("@Demographics", customerInfo.demographics);
				command.Parameters.AddWithValue("@AdditionalContactInfo", customerInfo.additionalContactInfo);

				try
				{
					connection.Open();
					int result = command.ExecuteNonQuery();
					customerInfo.customerID = (int)command.Parameters["@CustomerID"].SqlValue;
					customerInfo.accountNumber = (string)command.Parameters["@AccountNumber"].SqlValue;
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return customerInfo;
		}

		private Customer UpdateCustomerADO(string queryString, Customer customerInfo)
		{
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@PersonID", customerInfo.person.personID);

				command.Parameters.AddWithValue("@PersonType", customerInfo.person.personType);
				command.Parameters.AddWithValue("@Title", customerInfo.person.title);
				command.Parameters.AddWithValue("@FirstName", customerInfo.person.firstName);
				command.Parameters.AddWithValue("@LastName", customerInfo.person.lastName);
				command.Parameters.AddWithValue("@MiddleInitial", customerInfo.person.middleInitial);
				command.Parameters.AddWithValue("@Suffix", customerInfo.person.suffix);
				command.Parameters.AddWithValue("@AddressID", customerInfo.person.addressID);
				command.Parameters.AddWithValue("@Address1", customerInfo.person.address1);
				command.Parameters.AddWithValue("@Address2", customerInfo.person.address2);
				command.Parameters.AddWithValue("@City", customerInfo.person.city);
				command.Parameters.AddWithValue("@State", customerInfo.person.state);
				command.Parameters.AddWithValue("@Zip", customerInfo.person.zip);
				command.Parameters.AddWithValue("@Country", customerInfo.person.country);
				command.Parameters.AddWithValue("@EmailAddressID", customerInfo.person.emailAddressID);
				command.Parameters.AddWithValue("@EmailAddress", customerInfo.person.emailAddress);
				command.Parameters.AddWithValue("@PhoneNumberID", customerInfo.person.phoneNumberID);
				command.Parameters.AddWithValue("@PhoneNumber", customerInfo.person.phoneNumber);
				command.Parameters.AddWithValue("@AccountNumber", customerInfo.accountNumber);
				command.Parameters.AddWithValue("@EmailPromotion", customerInfo.emailPromotion);
				//command.Parameters.AddWithValue("@Demographics", customerInfo.demographics);
				//command.Parameters.AddWithValue("@AdditionalContactInfo", customerInfo.additionalContactInfo);

				try
				{
					connection.Open();
					int result = command.ExecuteNonQuery();
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
				individualSurvey.totalPurchaseYTD = totalPurchaseYTD;
			else
				individualSurvey.totalPurchaseYTD = null;

			individualSurvey.dateFirstPurchase = DateTime.Parse(head.ChildNodes[1].InnerXml);
			individualSurvey.birthDate = DateTime.Parse(head.ChildNodes[2].InnerXml);

			Globals.MaritalStatus.TryGetValue(head.ChildNodes[3].InnerXml, out individualSurvey.maritalStatus);

			individualSurvey.yearlyIncome = head.ChildNodes[4].InnerXml;

			Globals.Gender.TryGetValue(head.ChildNodes[5].InnerXml, out individualSurvey.gender);

			if (Int32.TryParse(head.ChildNodes[6].InnerXml, out totalChildren))
				individualSurvey.totalChildren = totalChildren;
			else
				individualSurvey.totalChildren = null;

			if (Int32.TryParse(head.ChildNodes[7].InnerXml, out numberChildrenAtHome))
				individualSurvey.numberChildrenAtHome = numberChildrenAtHome;
			else
				individualSurvey.numberChildrenAtHome = null;

			individualSurvey.education = head.ChildNodes[8].InnerXml;
			individualSurvey.occupation = head.ChildNodes[9].InnerXml;

			if (Int32.TryParse(head.ChildNodes[10].InnerXml, out homeOwnerFlag))
				individualSurvey.homeOwnerFlag = Convert.ToBoolean(homeOwnerFlag);
			else
				individualSurvey.homeOwnerFlag = null;

			if (Int32.TryParse(head.ChildNodes[11].InnerXml, out numberCarsOwned))
				individualSurvey.numberCarsOwned = numberCarsOwned;
			else
				individualSurvey.numberCarsOwned = null;

			individualSurvey.commuteDistance = head.ChildNodes[12].InnerXml;
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