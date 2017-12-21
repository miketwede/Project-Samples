using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;

using customers.Models;
using customers.DAL;

using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;

namespace customers.Forms
{
	public partial class Customers : Form
	{
		private DataGridView dataGridView1 = new DataGridView();
		private BindingSource bindingSource1 = new BindingSource();

		public Customers()
		{
			this.Load += new System.EventHandler(GetCustomers);
		}

		public void GetCustomers(object sender, System.EventArgs e)
		{
			//string databaseType = ConfigurationManager.ConnectionStrings["CustomerDatabaseType"].ConnectionString;

			string databaseType = ConfigurationManager.AppSettings["CustomerDatabaseType"];

			if (databaseType == "SQL")
			{
				GetCustomersSQL(sender, e);
			}
			else
			{
				GetCustomersAccess(sender, e);
			}
		}



		public void GetCustomersSQL(object sender, System.EventArgs e)
		{
			CustomerBO customerBO = new CustomerBO();

			List<Customer> customers = customerBO.GetCustomers();

			foreach (Customer customer in customers)
			{
				bindingSource1.Add(new CustomerRow(customer));
			}

			// Initialize the DataGridView.
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.AutoSize = false;
			dataGridView1.DataSource = bindingSource1;
			dataGridView1.ScrollBars = ScrollBars.Vertical;
			dataGridView1.Height = 600;
			dataGridView1.Width = 1200;

			// Initialize and add grid columns.
			DataGridViewColumn column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "AccountNumber";
			column.Name = "Account";
			column.Width = 100;
			dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Name";
			column.Name = "Name";
			column.Width = 200;
			dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Address";
			column.Name = "Address";
			column.Width = 400;
			dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Phone";
			column.Name = "Phone";
			column.Width = 100;
			dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Email";
			column.Name = "Email";
			column.Width = 200;
			dataGridView1.Columns.Add(column);

			// Initialize the form.
			this.Controls.Add(dataGridView1);
			this.AutoSize = true;
			this.Text = "Customers";

		}

		public void GetCustomersAccess(object sender, System.EventArgs e)
		{






			CustomerDO customerDO = new CustomerDO();


			List<CustomerRow> customerRows = customerDO.GetCustomers();





			if (customerRows != null)
			{



				foreach (CustomerRow customerRow in customerRows)
				{
					bindingSource1.Add(customerRow);
				}

				// Initialize the DataGridView.
				dataGridView1.AutoGenerateColumns = false;
				dataGridView1.AutoSize = false;
				dataGridView1.DataSource = bindingSource1;
				dataGridView1.ScrollBars = ScrollBars.Vertical;
				dataGridView1.Height = 600;
				dataGridView1.Width = 1200;

				// Initialize and add grid columns.
				DataGridViewColumn column = new DataGridViewTextBoxColumn();
				column.DataPropertyName = "AccountNumber";
				column.Name = "Account";
				column.Width = 100;
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.DataPropertyName = "Name";
				column.Name = "Name";
				column.Width = 200;
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.DataPropertyName = "Address";
				column.Name = "Address";
				column.Width = 400;
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.DataPropertyName = "Phone";
				column.Name = "Phone";
				column.Width = 100;
				dataGridView1.Columns.Add(column);

				column = new DataGridViewTextBoxColumn();
				column.DataPropertyName = "Email";
				column.Name = "Email";
				column.Width = 200;
				dataGridView1.Columns.Add(column);

				// Initialize the form.
				this.Controls.Add(dataGridView1);
				this.AutoSize = true;
				this.Text = "Customers";
			}
		}




	}
}
