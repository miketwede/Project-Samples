using System.Configuration;
using System;
using FileMailnenance.Models;
using NLog;


using System.Data;
using System.Data.SqlClient;

//using System.IO;

namespace FileMailnenance.DAL
{
	public class FilesDO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private string connectionString = ConfigurationManager.ConnectionStrings["FileDatabase"].ConnectionString;

		#region GET File functions

		public bool FileExists(string HashCode)
		{
			bool FileExists;

			try
			{
				FileExists = FileExistsADO("dbo.File_Exists", HashCode);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return FileExists;
		}

		public bool FilenameExists(string HashCode, string FileName)
		{
			bool FileExists;

			try
			{
				FileExists = FilenameExistsADO("dbo.Filename_Exists", HashCode, FileName);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
				throw;
			}

			return FileExists;
		}

		#endregion

		#region SAVE File functions

		public DiskFile CreateFile(DiskFile fileInfo)
		{
			DiskFile newFile = new DiskFile();

			try
			{
				newFile = CreateFileADO("dbo.Files_Insert", fileInfo);
			}
			catch (Exception ex)
			{
				logger.Fatal(ex.ToString());
			}

			return newFile;
		}

		#endregion

		#region ADO functions

		private bool FileExistsADO(string queryString, string HashCode)
		{
			bool retVal = true;

			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@HashKey", HashCode);
				try
				{
					connection.Open();
					var FileID = command.ExecuteScalar();
					if (FileID == null)
						retVal = false;
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return retVal;
		}

		private bool FilenameExistsADO(string queryString, string HashCode, string FileName)
		{
			bool retVal = true;

			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@HashKey", HashCode);
				command.Parameters.AddWithValue("@FileName", FileName);
				try
				{
					connection.Open();
					var FileID = command.ExecuteScalar();
					if (FileID == null)
						retVal = false;
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return retVal;
		}

		private DiskFile CreateFileADO(string queryString, DiskFile fileInfo)
		{
			// Create and open the connection in a using block. This
			// ensures that all resources will be closed and disposed
			// when the code exits.

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(queryString, connection);
				command.CommandType = CommandType.StoredProcedure;
				SqlParameter FileIDParam = new SqlParameter()
				{
					 ParameterName = "@FileID",
					  DbType = DbType.Int32,
					   Direction = ParameterDirection.Output
				};

				command.Parameters.Add(FileIDParam);

				command.Parameters.AddWithValue("@HashKey", fileInfo.HashCode);
				command.Parameters.AddWithValue("@FileName", fileInfo.FileName);

				try
				{
					connection.Open();
					int result = command.ExecuteNonQuery();
					//	fileInfo.FileID = (int)command.Parameters["@FileID"].SqlValue;
				//	fileInfo.FileID = (Int32)command.Parameters["@FileID"].SqlValue;
					fileInfo.FileID = (int)command.Parameters["@FileID"].Value;
					//fileInfo.FileName = (string)command.Parameters["@FileName"].SqlValue;
					//fileInfo.HashCode = (string)command.Parameters["@HaskKey"].SqlValue;
				}
				catch (Exception ex)
				{
					logger.Fatal(ex.ToString());
					throw;
				}
			}

			return fileInfo;
		}

		#endregion

		#region not used

		//private Customer GetCustomerADO(string queryString, int customerID)
		//{
		//	Customer customer = null;
		//	// Create and open the connection in a using block. This
		//	// ensures that all resources will be closed and disposed
		//	// when the code exits.
		//	using (SqlConnection connection = new SqlConnection(connectionString))
		//	{
		//		SqlCommand command = new SqlCommand(queryString, connection);
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.AddWithValue("@CustomerID", customerID);
		//		try
		//		{
		//			connection.Open();
		//			SqlDataReader reader = command.ExecuteReader();
		//			while (reader.Read())
		//			{
		//				XmlDocument DemographicsXML = new XmlDocument();
		//				XmlDocument AdditionalContactInfoXML = new XmlDocument();

		//				customer = new Customer
		//				{
		//					customerID = (int)reader["CustomerID"],
		//					person = new Person
		//					{
		//						personID = (int)reader["PersonID"],
		//						personType = reader["PersonType"].ToString(),
		//						title = reader["Title"].ToString(),
		//						firstName = reader["FirstName"].ToString(),
		//						lastName = reader["LastName"].ToString(),
		//						middleInitial = reader["MiddleName"].ToString(),
		//						suffix = reader["Suffix"].ToString(),
		//						addressID = (int)reader["AddressID"],
		//						address1 = reader["AddressLine1"].ToString(),
		//						address2 = reader["AddressLine2"].ToString(),
		//						city = reader["City"].ToString(),
		//						state = reader["State"].ToString(),
		//						zip = reader["PostalCode"].ToString(),
		//						country = reader["CountryRegionCode"].ToString(),
		//						emailAddressID = (int)reader["EmailAddressID"],
		//						emailAddress = reader["EmailAddress"].ToString(),
		//						phoneNumberID = (int)reader["PhoneNumberID"],
		//						phoneNumber = reader["PhoneNumber"].ToString(),
		//						//photo = reader["Photo"] == System.DBNull.Value ? null : getImage((byte[])reader["Photo"])
		//						photo = reader["Photo"] == System.DBNull.Value ? null : (byte[])reader["Photo"]
		//					},

		//					accountNumber = reader["AccountNumber"].ToString(),
		//					emailPromotion = (int)reader["EmailPromotion"],
		//					demographics = ParseXML(GetXML(reader["Demographics"].ToString())),
		//					additionalContactInfo = GetXML(reader["AdditionalContactInfo"].ToString())

		//					//Demographics = (XmlElement)reader["Demographics"],
		//					//AdditionalContactInfo = (XmlElement)reader["AdditionalContactInfo"]

		//				};
		//			}
		//			reader.Close();
		//		}
		//		catch (Exception ex)
		//		{
		//			logger.Fatal(ex.ToString());
		//			throw;
		//		}
		//	}

		//	return customer;
		//}

		//public Customer GetCustomerByCustomerID(int customerID)
		//{
		//	Customer customer = null;

		//	try
		//	{
		//		customer = GetCustomerADO("dbo.GetCustomerByCustomerID", customerID);
		//	}
		//	catch (Exception ex)
		//	{
		//		logger.Fatal(ex.ToString());
		//		throw;
		//	}

		//	return customer;
		//}

		#endregion
	}
}
