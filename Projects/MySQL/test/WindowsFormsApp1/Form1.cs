using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1
{
	public partial class frmActors : Form
	{
		private BindingSource bindingSource1 = new BindingSource();

		public frmActors()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			GetObjectData();
			GetTableData();
		}

		// Populate object grid with actor list
		private void GetObjectData()
		{
			try
			{
				// Set up the DataGridView.
				dgvActorObject.Dock = DockStyle.Fill;

				// Automatically generate the DataGridView columns.
				dgvActorObject.AutoGenerateColumns = true;


				// Set up the data source.


				///////////////////	actorBindingSource.DataSource = CreateObjectData();
				dgvActorObject.DataSource = CreateObjectData().ToList();


				//bindingSource1.DataSource = CreateObjectData();
				//dgvActorObject.DataSource = bindingSource1.DataSource;

				//dataGridView1.DataSource = GetData2();

				// Automatically resize the visible rows.
				dgvActorObject.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

				// Set the DataGridView control's border.
				dgvActorObject.BorderStyle = BorderStyle.Fixed3D;

				// Put the cells in edit mode when user enters them.
				dgvActorObject.EditMode = DataGridViewEditMode.EditOnEnter;

				dgvActorObject.Refresh();

				dgvActorObject.Columns[0].HeaderText = "ID";
				dgvActorObject.Columns[1].HeaderText = "First Name";
				dgvActorObject.Columns[2].HeaderText = "Last Name";
				dgvActorObject.Columns[3].HeaderText = "Last Modified";

			}
			catch (Exception ex)
			{
				MessageBox.Show("To run this sample replace connection.ConnectionString" +
					" with a valid connection string to a Northwind" +
					" database accessible to your system.", "ERROR",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				System.Threading.Thread.CurrentThread.Abort();
			}
		}

		private List<Actor> CreateObjectData()
		{
			MySql.Data.MySqlClient.MySqlConnection conn;
			string myConnectionString;
			//server=localhost;user id=miketwede;database=sakila;persistsecurityinfo=True

			//myConnectionString = "server=127.0.0.1;uid=root;" +
			//	"pwd=12345;database=test";

			myConnectionString = "server=localhost;uid=root;pwd=Mike_1701;database=sakila";
			List<Actor> actors = new List<Actor>();
			;

			try
			{
				conn = new MySql.Data.MySqlClient.MySqlConnection();
				conn.ConnectionString = myConnectionString;
				conn.Open();

				string query = "select * from actor";

				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
				cmd.CommandText = query;
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;

				//MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter();

				//adapter.SelectCommand = cmd;

				//DataTable table = new DataTable();
				//table.Locale = System.Globalization.CultureInfo.InvariantCulture;
				//adapter.Fill(table);

				//return table;

				MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int ID = int.Parse(reader["actor_id"].ToString());
					string Firstname = reader["first_name"].ToString();
					string Lastname = reader["last_name"].ToString();
					DateTime LastUpdated = DateTime.Parse(reader["last_update"].ToString());

					actors.Add(new Actor(ID, Firstname, Lastname, LastUpdated));






					//actors.Add(new Actor
					//{
					//	ID = int.Parse(reader["actor_id"].ToString()),
					//	Firstname = reader["first_name"].ToString(),
					//	Lastname = reader["last_name"].ToString(),
					//	LastUpdated = DateTime.Parse(reader["last_update"].ToString())


					//}
					//);

					//MessageBox.Show(reader["actor_id"].ToString());
					//MessageBox.Show(reader["first_name"].ToString());
					//MessageBox.Show(reader["last_name"].ToString());
					//MessageBox.Show(reader["last_update"].ToString());

				}

				return actors;

				//bindingSource1.DataSource = actors;

				// Resize the DataGridView columns to fit the newly loaded content.

				//dataGridView1.DataSource = actors;
				//dataGridView1.Refresh();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}


		}


		// Populate table grid with actor table
		private void GetTableData()
		{
			try
			{
				// Set up the DataGridView.
				dgvActorObject.Dock = DockStyle.Fill;

				// Automatically generate the DataGridView columns.
				dgvActorObject.AutoGenerateColumns = true;

				// Set up the data source.




				bindingSource1.DataSource = CreateTableData();
				dgvActorTable.DataSource = bindingSource1.DataSource;

				//dataGridView1.DataSource = GetData2();

				// Automatically resize the visible rows.
				dgvActorObject.AutoSizeRowsMode =
					DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

				// Set the DataGridView control's border.
				dgvActorObject.BorderStyle = BorderStyle.Fixed3D;

				// Put the cells in edit mode when user enters them.
				dgvActorObject.EditMode = DataGridViewEditMode.EditOnEnter;
			}
			catch (Exception ex)
			{
				MessageBox.Show("To run this sample replace connection.ConnectionString" +
					" with a valid connection string to a Northwind" +
					" database accessible to your system.", "ERROR",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				System.Threading.Thread.CurrentThread.Abort();
			}
		}

		private DataTable CreateTableData()
		{
			MySql.Data.MySqlClient.MySqlConnection conn;
			string myConnectionString;
			//server=localhost;user id=miketwede;database=sakila;persistsecurityinfo=True

			//myConnectionString = "server=127.0.0.1;uid=root;" +
			//	"pwd=12345;database=test";

			myConnectionString = "server=localhost;uid=root;pwd=Mike_1701;database=sakila";
			List<Actor> actors = new List<Actor>();
			;

			try
			{
				conn = new MySql.Data.MySqlClient.MySqlConnection();
				conn.ConnectionString = myConnectionString;
				conn.Open();

				string query = "select * from actor";

				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
				cmd.CommandText = query;
				cmd.Connection = conn;
				cmd.CommandType = CommandType.Text;

				MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter();

				adapter.SelectCommand = cmd;

				DataTable table = new DataTable();
				table.Locale = System.Globalization.CultureInfo.InvariantCulture;
				adapter.Fill(table);

				return table;


			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}


		}

		private void actorBindingSource_CurrentChanged(object sender, EventArgs e)
		{

		}











		//private static DataTable GetData(string sqlCommand)
		//{
		//	string connectionString = "Integrated Security=SSPI;" +
		//		"Persist Security Info=False;" +
		//		"Initial Catalog=Northwind;Data Source=localhost";

		//	//dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);


		//	//SqlConnection northwindConnection = new SqlConnection(connectionString);

		//	//SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
		//	//SqlDataAdapter adapter = new SqlDataAdapter();
		//	//adapter.SelectCommand = command;

		//	DataTable table = new DataTable();
		//	table.Locale = System.Globalization.CultureInfo.InvariantCulture;
		//	//adapter.Fill(table);

		//	return table;
		//}

		//private void Form1_Load(object sender, EventArgs e)
		//{
		//	// Bind the DataGridView to the BindingSource
		//	// and load the data from the database.
		//	dataGridView1.DataSource = bindingSource1;
		//	GetData();



		//}


		//private DataTable GetData2()
		//{
		//	MySql.Data.MySqlClient.MySqlConnection conn;
		//	string myConnectionString;
		//	//server=localhost;user id=miketwede;database=sakila;persistsecurityinfo=True

		//	//myConnectionString = "server=127.0.0.1;uid=root;" +
		//	//	"pwd=12345;database=test";

		//	myConnectionString = "server=localhost;uid=root;pwd=Mike_1701;database=sakila";
		//	List<Actor> actors = new List<Actor>();
		//	;

		//	try
		//	{
		//		conn = new MySql.Data.MySqlClient.MySqlConnection();
		//		conn.ConnectionString = myConnectionString;
		//		conn.Open();

		//		string query = "select * from actor";

		//		MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
		//		cmd.CommandText = query;
		//		cmd.Connection = conn;
		//		cmd.CommandType = CommandType.Text;

		//		MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter();

		//		adapter.SelectCommand = cmd;

		//		DataTable table = new DataTable();
		//		table.Locale = System.Globalization.CultureInfo.InvariantCulture;
		//		adapter.Fill(table);

		//		return table;

		//		//MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
		//		//while (reader.Read())
		//		//{
		//		//	actors.Add(new Actor
		//		//	{
		//		//		ID = int.Parse(reader["actor_id"].ToString()),
		//		//		Firstname = reader["first_name"].ToString(),
		//		//		Lastname = reader["last_name"].ToString(),
		//		//		LastUpdated = DateTime.Parse(reader["last_update"].ToString())


		//		//	}
		//		//	);

		//		//	//MessageBox.Show(reader["actor_id"].ToString());
		//		//	//MessageBox.Show(reader["first_name"].ToString());
		//		//	//MessageBox.Show(reader["last_name"].ToString());
		//		//	//MessageBox.Show(reader["last_update"].ToString());

		//		//}

		//		//bindingSource1.DataSource = actors;

		//		// Resize the DataGridView columns to fit the newly loaded content.

		//		//dataGridView1.DataSource = actors;
		//		//dataGridView1.Refresh();
		//	}
		//	catch (MySql.Data.MySqlClient.MySqlException ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//		return null;
		//	}


		//}

	}
}
