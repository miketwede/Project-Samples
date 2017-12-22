using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customers.Forms
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void customersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.IsMdiContainer = true;
			Customers CustomersForm = new Customers();
			CustomersForm.MdiParent = this;
			CustomersForm.Show();

			

			
		}
	}
}
