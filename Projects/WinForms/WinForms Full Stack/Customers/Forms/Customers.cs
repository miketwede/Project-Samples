using System.Windows.Forms;
using System.Collections.Generic;

using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;
using customers.Models;

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


	}
}
