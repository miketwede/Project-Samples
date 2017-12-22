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
		//private DataGridView dataGridView1 = new DataGridView();
		private BindingSource bindingSource1 = new BindingSource();

		public Customers()
		{
			InitializeComponent();
			this.Load += new System.EventHandler(GetCustomers);
		}

		public void GetCustomers(object sender, System.EventArgs e)
		{
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

		//	BuildCustomerGrid();
		}

		public void GetCustomersAccess(object sender, System.EventArgs e)
		{
			CustomerDO customerDO = new CustomerDO();
			List<CustomerRow> customerRows = customerDO.GetCustomers();

			if (customerRows != null)
			{
				if (customerRows.Count > 0)
				{
					foreach (CustomerRow customerRow in customerRows)
					{
						bindingSource1.Add(customerRow);
					}
				}
			}

		//	BuildCustomerGrid();
		}

		public void BuildCustomerGrid()
		{
			// Initialize the DataGridView.
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.AutoSize = false;
			this.dataGridView1.DataSource = bindingSource1;
			this.dataGridView1.ScrollBars = ScrollBars.Vertical;
			this.dataGridView1.Height = 600;
			this.dataGridView1.Width = 1200;

			// Initialize and add grid columns.
			DataGridViewColumn column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "AccountNumber";
			column.Name = "Account";
			column.Width = 100;
			this.dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Name";
			column.Name = "Name";
			column.Width = 200;
			this.dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Address";
			column.Name = "Address";
			column.Width = 400;
			this.dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Phone";
			column.Name = "Phone";
			column.Width = 100;
			this.dataGridView1.Columns.Add(column);

			column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Email";
			column.Name = "Email";
			column.Width = 200;
			this.dataGridView1.Columns.Add(column);

			// Initialize the form.
			//this.Controls.Add(dataGridView1);
			this.AutoSize = true;
			this.Text = "Customers";
		}

		private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
		{

		}

		private void Customers_Validated(object sender, System.EventArgs e)
		{
		//	BuildCustomerGrid();
		}

		private void Customers_Shown(object sender, System.EventArgs e)
		{
		//	BuildCustomerGrid();
		}

		private void Customers_Load(object sender, System.EventArgs e)
		{
		//	BuildCustomerGrid();
		}

		private void Customers_Activated(object sender, System.EventArgs e)
		{
			BuildCustomerGrid();
		}

		private void Customers_MdiChildActivate(object sender, System.EventArgs e)
			{
		//		BuildCustomerGrid();
			}
	}
}
