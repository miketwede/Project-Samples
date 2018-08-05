using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileMailnenance;
using System.Text;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			//----------------------------------------------------------------------------------------------

			string FileName = "testfile.txt";
			string FileContents = "some test data";
			bool fileSaved = false;
			MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(FileContents));
			FileOperations FileOperations = new FileOperations();

			// test 1 
			// PreCondition      : nothing saved. 
			// Test condition    : supply a file name and file content.
			// Expected behavior : Should create a disk file and add new file record to db.
			fileSaved = FileOperations.SaveFile(FileName, mStrm);
			Assert.IsTrue(fileSaved);

			//----------------------------------------------------------------------------------------------

			 FileName = "testfile2.txt";
			 FileContents = "some test data";
			 fileSaved = false;
			 mStrm = new MemoryStream(Encoding.UTF8.GetBytes(FileContents));
			 FileOperations = new FileOperations();

			// test 2 
			// PreCondition      : one disk file added and one file record inserted.
			// Test condition    : change the file name.
			// Expected behavior : Should add new file record to db.
			fileSaved = FileOperations.SaveFile(FileName, mStrm);
			Assert.IsTrue(fileSaved);

			//----------------------------------------------------------------------------------------------

			FileName = "testfile2.txt";
			FileContents = "some test data!";
			fileSaved = false;
			mStrm = new MemoryStream(Encoding.UTF8.GetBytes(FileContents));
			FileOperations = new FileOperations();

			// test 3
			// PreCondition      : one disk file added and two file record inserted..
			// Test condition    : change the file contents.
			// Expected behavior : Should create a new disk file and add new file record to db.
			fileSaved = FileOperations.SaveFile(FileName, mStrm);
			Assert.IsTrue(fileSaved);

			//----------------------------------------------------------------------------------------------



		}
	}
}
