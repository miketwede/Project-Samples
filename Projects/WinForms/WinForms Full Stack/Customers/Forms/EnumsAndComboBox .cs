using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using customers.Models;

namespace customers.Forms
{
	public partial class EnumsAndComboBox : Form
	{
		private DataGridView dataGridView1 = new DataGridView();
		private BindingSource bindingSource1 = new BindingSource();

		public EnumsAndComboBox()
		{
			this.Load += new System.EventHandler(EnumsAndComboBox_Load);
		}

		private void EnumsAndComboBox_Load(object sender, System.EventArgs e)
		{
			// Populate the data source.
			bindingSource1.Add(new Knight(Global.Title.King, "Uther", true));
			bindingSource1.Add(new Knight(Global.Title.King, "Arthur", true));
			bindingSource1.Add(new Knight(Global.Title.Sir, "Mordred", false));
			bindingSource1.Add(new Knight(Global.Title.Sir, "Gawain", true));
			bindingSource1.Add(new Knight(Global.Title.Sir, "Galahad", true));

			// Initialize the DataGridView.
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.AutoSize = true;
			dataGridView1.DataSource = bindingSource1;

			dataGridView1.Columns.Add(CreateComboBoxWithEnums());

			// Initialize and add a text box column.
			DataGridViewColumn column = new DataGridViewTextBoxColumn();
			column.DataPropertyName = "Name";
			column.Name = "Knight";
			dataGridView1.Columns.Add(column);

			// Initialize and add a check box column.
			column = new DataGridViewCheckBoxColumn();
			column.DataPropertyName = "GoodGuy";
			column.Name = "Good";
			dataGridView1.Columns.Add(column);

			// Initialize the form.
			this.Controls.Add(dataGridView1);
			this.AutoSize = true;
			this.Text = "DataGridView object binding demo";
		}

		DataGridViewComboBoxColumn CreateComboBoxWithEnums()
		{
			DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
			combo.DataSource = Enum.GetValues(typeof(Global.Title));
			combo.DataPropertyName = "Title";
			combo.Name = "Title";
			return combo;
		}
	}
}
