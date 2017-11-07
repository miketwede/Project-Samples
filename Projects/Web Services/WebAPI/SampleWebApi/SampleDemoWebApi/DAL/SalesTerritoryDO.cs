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

namespace SampleDemoWebApi.SalesTerritoryApi.DAL
{
	public class SalesTerritoryDO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private string connectionString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;


		#region GET SalesTerritory functions

		public SalesTerritory GetSalesTerritoryBySalesTerritoryID(int SalesTerritoryID)
		{
			SalesTerritory salesTerritory = null;

			try
			{
				salesTerritory = GetSalesTerritoryADO("dbo.GetSalesTerritoryBySalesTerritoryID", SalesTerritoryID);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return salesTerritory;
		}

		public List<SalesTerritory> GetSalesTerritories()
		{
			List<SalesTerritory> salesTerritories = new List<SalesTerritory>();
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
				salesTerritories = null;
				testConnection.Close();
				return salesTerritories;
			}
			testConnection.Close();


			try
			{
				salesTerritories = GetSalesTerritoriesADO("dbo.GetSalesTerritories");
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}
			return salesTerritories;


		}

		public void SaveSalesTerritory(SalesTerritory salesTerritory)
		{
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
				testConnection.Close();
				return;
			}
			testConnection.Close();


			try
			{
				SaveSalesTerritoryADO("dbo.SaveSalesTerritory", salesTerritory);
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

		private SalesTerritory GetSalesTerritoryADO(string queryString, int SalesTerritoryID)
		{
			SalesTerritory salesTerritory = null;
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@TerritoryID", SalesTerritoryID);
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						salesTerritory = new SalesTerritory
						{
							territoryID = SalesTerritoryID,
							costLastYear = (decimal)reader["CostLastYear"],
							costYTD = (decimal)reader["CostYTD"],
							country = (string)reader["Country"],
							group = (string)reader["Group"],
							region = (string)reader["Region"],
							salesLastYear = (decimal)reader["SalesLastYear"],
							//salesPersons = (int)reader["BusinessEntityID"],
							salesYTD = (decimal)reader["SalesYTD"]



						};
					}
					reader.Close();

					SalesPerson salesPerson = new SalesPerson();

					command = new SqlCommand("GetSalesPersonsByTerritoryID", connection);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@TerritoryID", salesTerritory.territoryID);
					reader = command.ExecuteReader();
					while (reader.Read())
					{
						salesPerson = new SalesPerson
						{
							bonus = (decimal)reader["Bonus"],
							commissionPct = (decimal)reader["CommissionPct"],
							person = new Person
							{
								title = (reader["Title"] ?? "").ToString(),
								firstName = (reader["FirstName"] ?? "").ToString(),
								lastName = (reader["LastName"] ?? "").ToString(),
								middleInitial = (reader["MiddleName"] ?? "").ToString(),
								suffix = (reader["Suffix"] ?? "").ToString(),
								address1 = (reader["AddressLine1"] ?? "").ToString(),
								address2 = (reader["AddressLine2"] ?? "").ToString(),
								city = (reader["City"] ?? "").ToString(),
								state = (reader["State"] ?? "").ToString(),
								zip = (reader["PostalCode"] ?? "").ToString(),
								country = (reader["CountryRegionCode"] ?? "").ToString(),
								emailAddress = (reader["EmailAddress"] ?? "").ToString(),
								phoneNumber = (reader["PhoneNumber"] ?? "").ToString(),
								photo = (reader["Photo"] ?? "").ToString()
							},
							salesYTD = (decimal)reader["SalesYTD"],
							salesLastYear = (decimal)reader["SalesLastYear"],
							salesPersonID = (int)reader["BusinessEntityID"],
							salesQuota = (decimal)reader["SalesQuota"],
							territiryID = (int)reader["TerritoryID"]





						};
						salesTerritory.salesPersons.Add(salesPerson);

					}
					reader.Close();

				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return salesTerritory;
		}

		private SalesTerritory SaveSalesTerritoryADO(string queryString, SalesTerritory salesTerritory)
		{
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@TerritoryID", salesTerritory.territoryID);
				command.Parameters.AddWithValue("@Name", salesTerritory.region);
				command.Parameters.AddWithValue("@Country", salesTerritory.country);
				command.Parameters.AddWithValue("@Group", salesTerritory.group);
				command.Parameters.AddWithValue("@SalesYTD", salesTerritory.salesYTD);
				command.Parameters.AddWithValue("@SalesLastYear", salesTerritory.salesLastYear);
				command.Parameters.AddWithValue("@CostYTD", salesTerritory.costYTD);
				command.Parameters.AddWithValue("@CostLastYear", salesTerritory.costLastYear);

				try
				{
					connection.Open();
					salesTerritory.territoryID = (int)command.ExecuteScalar();



				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return salesTerritory;
		}

		private List<SalesTerritory> GetSalesTerritoriesADO(string queryString, string[] parameterName = null, string[] parameterValue = null)
		{
			List<SalesTerritory> SalesTerritories = new List<SalesTerritory>();
			SalesTerritory salesTerritory = new SalesTerritory();
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
						//int territoryID = (int)reader["TerritoryID"];

						salesTerritory = new SalesTerritory
						{
							territoryID = (int)reader["TerritoryID"],
							group = (string)reader["Group"],
							country = (string)reader["Country"],
							region = (string)reader["Region"],
							salesLastYear = (decimal)reader["SalesLastYear"],
							salesYTD = (decimal)reader["SalesYTD"],
							costLastYear = (decimal)reader["CostLastYear"],
							costYTD = (decimal)reader["CostYTD"],
							//salesPersons = GetSalesPersonsADO(territoryID, connection)
						};

						SalesTerritories.Add(salesTerritory);
					}
					reader.Close();

					SalesPerson salesPerson = new SalesPerson();

					foreach (SalesTerritory st in SalesTerritories)
					{
						st.salesPersons = GetSalesPersonsADO(st.territoryID, connection);
					}

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
			}


			return SalesTerritories;
		}

		private List<SalesPerson> GetSalesPersonsADO(int SalesTerritoryID, SqlConnection connection)
		{
			List<SalesPerson> salesPersons = new List<SalesPerson>();
			SalesPerson salesPerson = new SalesPerson();

			SqlCommand command = new SqlCommand("GetSalesPersonsByTerritoryID", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.AddWithValue("@TerritoryID", SalesTerritoryID);
			try
			{
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					salesPerson = new SalesPerson
					{
						salesPersonID = (int)reader["SalesPersonID"],
						territiryID = (int)reader["TerritoryID"],
						person = new Person
						{
							personID = (int)reader["PersonID"],
							title = (reader["Title"] ?? "").ToString(),
							firstName = (reader["FirstName"] ?? "").ToString(),
							lastName = (reader["LastName"] ?? "").ToString(),
							middleInitial = (reader["MiddleName"] ?? "").ToString(),
							suffix = (reader["Suffix"] ?? "").ToString(),
							address1 = (reader["AddressLine1"] ?? "").ToString(),
							address2 = (reader["AddressLine2"] ?? "").ToString(),
							city = (reader["City"] ?? "").ToString(),
							state = (reader["State"] ?? "").ToString(),
							zip = (reader["PostalCode"] ?? "").ToString(),
							country = (reader["CountryRegionCode"] ?? "").ToString(),
							emailAddress = (reader["EmailAddress"] ?? "").ToString(),
							phoneNumber = (reader["PhoneNumber"] ?? "").ToString(),
							photo = reader["Photo"] == System.DBNull.Value ? null : getImage((byte[])reader["Photo"])
						//	photo = (reader["Photo"] ?? "").ToString()
						},
						bonus = (decimal)reader["Bonus"],
						commissionPct = (decimal)reader["CommissionPct"],
						salesYTD = (decimal)reader["SalesYTD"],
						salesLastYear = (decimal)reader["SalesLastYear"],
						salesQuota = (decimal)reader["SalesQuota"],
					};
					salesPersons.Add(salesPerson);
				}
				reader.Close();


			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return salesPersons;
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