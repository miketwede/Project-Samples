using System;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Configuration;

using NLog;

using FileMailnenance.DAL;
using FileMailnenance.Models;

namespace FileMailnenance
{
	public class FileOperations
	{
		private string FilePath = ConfigurationManager.AppSettings["FilePath"];
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public FileOperations()
		{
		}

		/// <summary>
		/// Takes an uploaded file and saves a single copy on the server disk and 
		/// multiple upload file names. Saves meta data in db file table.
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="FileContents"></param>
		/// <returns></returns>
		public bool SaveFile(string FileName, Stream FileContents)
		{
			bool retVal = true;

			using (MD5 md5Hash = MD5.Create())
			{
				string hash = GetMd5Hash(md5Hash, FileContents);
				FilesDO FilesDO = new FilesDO();

				if (!FilesDO.FileExists(hash)) // save file to disk
				{
					FileIO FileIO = new FileIO();
				//	if (FileIO.SaveFileToDisk(FilePath, FileName, FileContents))
						if (FileIO.SaveFileToDisk(FilePath, hash, FileContents))
						{
							logger.Info(string.Format("File added to disk (Filename = {0}).", hash));
					}
					else
					{
						logger.Info(string.Format("Failure adding file to disk (Filename = {0}).", hash));
						return false;
					}
				}

				if (!FilesDO.FilenameExists(hash, FileName))
				{
					// save file record to database
					DiskFile newFile = new DiskFile()
					{
						FileCreationDate = DateTime.Now,
						FileName = FileName,
						HashCode = hash,
						FileSize = FileContents.Length
					};
					newFile = FilesDO.CreateFile(newFile);
					if (newFile.FileID > 0)
						logger.Info(string.Format("New file record added (Filename = {0}, Hash code = {1}).", FileName, hash));
					else
						logger.Info(string.Format("Failure inserting new file (Filename = {0}, Hash code = {1}).", FileName, hash));
				}
				else
				{
					logger.Info(string.Format("File record already exists (Filename = {0}, Hash code = {1}).", FileName, hash));
				}
			}

			return retVal;
		}

		private string GetMd5Hash(MD5 md5Hash, object input)
		{

			// Convert the input string to a byte array and compute the hash.
			//byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			byte[] data = md5Hash.ComputeHash(ObjectToByteArray(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

		// Verify a hash against a string.
		private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
		{
			// Hash the input.
			string hashOfInput = GetMd5Hash(md5Hash, input);

			// Create a StringComparer an compare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		// Verify a hash against an object.
		private bool VerifyMd5Hash(MD5 md5Hash, object input, string hash)
		{
			// Hash the input.
			string hashOfInput = GetMd5Hash(md5Hash, input);

			// Create a StringComparer an compare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private byte[] ObjectToByteArray(object obj)
		{
			if (obj == null)
				return null;
			BinaryFormatter bf = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}
	}
}
