using System;
using System.IO;

using NLog;

namespace FileMailnenance.DAL
{
	public class FileIO
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public bool SaveFileToDisk(string FilePath, string FileName, Stream stream)
		{
			bool FileSaved = true;

			try
			{
				FileStream fileStream = File.Create(string.Concat(FilePath, FileName), (int)stream.Length);
				// Initialize the bytes array with the stream length and then fill it with data
				byte[] bytesInStream = new byte[stream.Length];
				stream.Read(bytesInStream, 0, bytesInStream.Length);
				// Use write method to write to the file specified above
				fileStream.Write(bytesInStream, 0, bytesInStream.Length);
				//Close the filestream
				fileStream.Close();
			}
			catch (Exception ex)
			{
				logger.Fatal(string.Format("Exception occurred while saving file to disk(Filename = {0}) : Exception : {1).", string.Concat(FilePath, FileName), ex.ToString()));
				FileSaved = false;
			}

			return FileSaved;
		}
	}
}
