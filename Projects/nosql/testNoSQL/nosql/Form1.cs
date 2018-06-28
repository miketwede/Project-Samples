using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sqo;
using nosql.Models;
using System.IO;

namespace nosql
{
	public partial class Form1 : Form
	{
		private static Siaqodb instance;
		private static string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		private Siaqodb siaqodb;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		//	CreateDatabase2();
			CreateDatabase1();
			GetData();
		}


		private void GetData()
		{
			IObjectList<Company> companies = siaqodb.LoadAll<Company>();
			dataGridView1.DataSource = companies.ToList();
		}




		private void CreateDatabase1()
		{
			try
			{
				siaqodb = new Siaqodb(@"c:\Siaqodb\");

				//Siaqodb siaqodb = new Siaqodb(@"c:\Siaqodb\");
				//	Siaqodb siaqodb = new Siaqodb();
				//siaqodb.GetDBPath
				//siaqodb.


				//		siaqodb.Open(@"c:\Siaqodb\");

				Siaqodb.Stat mike = siaqodb.DbInfo;

				Company company = new Company();
				company.Name = "MyCompany";
				siaqodb.StoreObject(company);
				Employee employee1 = new Employee();
				employee1.Employer = company;
				employee1.FirstName = "John";
				employee1.LastName = "Walter";
				siaqodb.StoreObject(employee1);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}


		private void CreateDatabase2()
		{
			try
			{


				SiaqodbConfigurator.SetLicense(@"triallicensecode");
				SiaqodbConfigurator.EncryptedDatabase = true;
				SiaqodbConfigurator.SetEncryptor(BuildInAlgorithm.AES);
				SiaqodbConfigurator.SetEncryptionPassword("supersecret");

				string path = System.IO.Path.Combine(BasePath, "SiaqoTest");
				Directory.CreateDirectory(path);
				instance = new Siaqodb(path);


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}


	}
}
