using System.Collections.Generic;
using System.Windows.Forms;

using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;
using System.Drawing;
using System.IO;
using System.Text;

using SampleDemoWebApi.CustomerApi.Global;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace customers.Forms
{
	public partial class CustomerEdit : Form
	{
		Customer customer;

		public CustomerEdit(int CustomerID)
		{
			InitializeComponent();
			GetCustomerSQL(CustomerID);
			txtCustomerID.Text = CustomerID.ToString();
		}

		private void GetCustomerSQL(int CustomerID)
		{
			CustomerBO customerBO = new CustomerBO();

			customer = customerBO.GetCustomerByCustomerID(CustomerID);

			DisplayCustomerSQL();
		}

		private void DisplayCustomerSQL()
		{
			// Name
			txtTitle.Text = customer.person.title;
			txtFirstName.Text = customer.person.firstName;
			txtMiddleInitial.Text = customer.person.middleInitial;
			txtLastName.Text = customer.person.lastName;
			txtSuffix.Text = customer.person.suffix;

			// Address
			txtAddress1.Text = customer.person.address1;
			txtAddress2.Text = customer.person.address2;
			txtCity.Text = customer.person.city;
			txtState.Text = customer.person.state;
			txtZip.Text = customer.person.zip;
			txtCountry.Text = customer.person.country;

			txtPhone.Text = customer.person.phoneNumber;
			txtEmail.Text = customer.person.emailAddress;
			txtAccountNumber.Text = customer.accountNumber;

			txtEmailPromotion.Text = customer.emailPromotion.ToString();
			txtTotalPurchaseYTD.Text = customer.demographics.totalPurchaseYTD.ToString();
			txtDateFirstPurchase.Text = customer.demographics.dateFirstPurchase.ToString();
			txtBirthDate.Text = customer.demographics.birthDate.ToString();


			cmboMaritalStatus.DataSource = new BindingSource(Globals.MaritalStatus, null);
			cmboMaritalStatus.DisplayMember = "Value";
			cmboMaritalStatus.ValueMember = "Key";
			cmboMaritalStatus.SelectedIndex = cmboMaritalStatus.FindString(customer.demographics.maritalStatus);

			txtYearlyIncome.Text = customer.demographics.yearlyIncome;



			cmboGender.DataSource = new BindingSource(Globals.Gender, null);
			cmboGender.DisplayMember = "Value";
			cmboGender.ValueMember = "Key";
			cmboGender.SelectedIndex = cmboGender.FindString(customer.demographics.gender);


			//txtGender.Text = customer.demographics.gender;
			txtTotalChildren.Text = customer.demographics.totalChildren.ToString();
			txtNumberChildrenAtHome.Text = customer.demographics.numberChildrenAtHome.ToString();
			txtEducation.Text = customer.demographics.education;
			txtOccupation.Text = customer.demographics.occupation;
			chkHomeOwnerFlag.Checked = customer.demographics.homeOwnerFlag ?? false | (bool)customer.demographics.homeOwnerFlag;
			txtNumberCarsOwned.Text = customer.demographics.numberCarsOwned.ToString();
			txtCommuteDistance.Text = customer.demographics.commuteDistance;

			// convert string to stream
			//byte[] byteArray = Encoding.UTF8.GetBytes(customer.person.photo);
			byte[] byteArray = customer.person.photo;
			//byte[] byteArray = Encoding.ASCII.GetBytes(customer.person.photo);
			//byte[] byteArray = Encoding.UTF32.GetBytes(customer.person.photo);
			//byte[] byteArray = Encoding.UTF7.GetBytes(customer.person.photo);
			//byte[] byteArray = Encoding.Unicode.GetBytes(customer.person.photo);
			//byte[] byteArray = Encoding.BigEndianUnicode.GetBytes(customer.person.photo);


			MemoryStream stream = new MemoryStream();
			Bitmap bitmap = null;

			//byte[] byteArray = Encoding.Default.GetBytes(customer.person.photo)
			if (byteArray != null && byteArray.Length > 0)
			{
				stream = new MemoryStream(byteArray);
				bitmap = new Bitmap(stream);

			}
			//else
			//{
			//	if (customer.person.title == "Ms." | customer.person.title == "Miss" | customer.person.title == "Sra.")
			//	{
			//		using (var ms = new MemoryStream(Globals.FemaleImage))
			//		{
			//			//stream = new MemoryStream(Globals.FemaleImage);
			//			bitmap = new Bitmap(ms);
			//			//return Image.FromStream(ms);
			//		}


			//	}
			//	else if (customer.person.title == "Mr." | customer.person.title == "Sr.")
			//	{
			//		stream = new MemoryStream(Globals.FemaleImage);
			//		bitmap = new Bitmap(stream);
			//	}


			//}

			////MemoryStream stream = new MemoryStream(byteArray);
			////stream.Position = 0;

			////pbPhoto.Image = Image.FromStream(stream);



			pbPhoto.Image = bitmap;
			//pbPhoto.Image.Height = bitmap.Height;
			//pbPhoto.Image.Width = bitmap.Width;


			//System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
			//pbPhoto.Image = (Image)converter.ConvertFrom(byteArray);





			//public Decimal? totalPurchaseYTD;
			//public DateTime? dateFirstPurchase;
			//public DateTime? birthDate;
			//public String maritalStatus;
			//public String yearlyIncome;
			//public String gender;
			//public int? totalChildren;
			//public int? numberChildrenAtHome;
			//public String education;
			//public String occupation;
			//public bool? homeOwnerFlag;
			//public int? numberCarsOwned;
			//public String commuteDistance;
		}

		private void label3_Click(object sender, System.EventArgs e)
		{

		}

		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			Customers CustomersForm = new Customers();
			CustomersForm.MdiParent = this.Parent.FindForm();
			CustomersForm.StartPosition = FormStartPosition.Manual;
			CustomersForm.Location = new Point(0, 0);
			CustomersForm.Show();
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtMessages.Visible = false;
			txtMessages.Text = "";

			DisplayCustomerSQL();

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			CustomerBO customerBO = new CustomerBO();

			PopulateCustomer();

			customerBO.UpdateCustomer(customer);
			txtMessages.Visible = true;
			txtMessages.ForeColor = Color.Green;
			txtMessages.Text = "Customer saved.";
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			txtTitle.ReadOnly = false;
			txtFirstName.ReadOnly = false;
			txtMiddleInitial.ReadOnly = false;
			txtLastName.ReadOnly = false;
			txtSuffix.ReadOnly = false;
			txtAddress1.ReadOnly = false;
			txtAddress2.ReadOnly = false;
			txtCity.ReadOnly = false;
			txtState.ReadOnly = false;
			txtZip.ReadOnly = false;
			txtCountry.ReadOnly = false;

			txtPhone.ReadOnly = false;
			txtEmail.ReadOnly = false;
			txtAccountNumber.ReadOnly = false;

			txtEmailPromotion.ReadOnly = false;
			txtTotalPurchaseYTD.ReadOnly = false;
			txtDateFirstPurchase.ReadOnly = false;
			txtBirthDate.ReadOnly = false;
			cmboMaritalStatus.Enabled = true;
			txtYearlyIncome.ReadOnly = false;
			cmboGender.Enabled = true;
			txtTotalChildren.ReadOnly = false;
			txtNumberChildrenAtHome.ReadOnly = false;
			txtEducation.ReadOnly = false;
			txtOccupation.ReadOnly = false;
			chkHomeOwnerFlag.Enabled = true;
			txtNumberCarsOwned.ReadOnly = false;
			txtCommuteDistance.ReadOnly = false;

			btnSave.Enabled = true;
			btnCancel.Enabled = true;
		}

		private void PopulateCustomer()
		{








			// Name
			customer.person.title = txtTitle.Text;
			customer.person.firstName = txtFirstName.Text;
			customer.person.middleInitial = txtMiddleInitial.Text;
			customer.person.lastName = txtLastName.Text;
			customer.person.suffix = txtSuffix.Text;

			// Address
			customer.person.address1 = txtAddress1.Text;
			customer.person.address2 = txtAddress2.Text;
			customer.person.city = txtCity.Text;
			customer.person.state = txtState.Text;
			customer.person.zip = txtZip.Text;
			customer.person.country = txtCountry.Text;

			customer.person.phoneNumber = txtPhone.Text;
			customer.person.emailAddress = txtEmail.Text;
			customer.accountNumber = txtAccountNumber.Text;

			if (!Int32.TryParse(txtEmailPromotion.Text, out customer.emailPromotion))
			{
				MessageBox.Show("EmailPromotion could not be parsed.");
				return;
			}

			decimal totalPurchaseYTD;
			if (!Decimal.TryParse(txtTotalPurchaseYTD.Text, out totalPurchaseYTD))
			{
				MessageBox.Show("TotalPurchaseYTD could not be parsed.");
				return;
			}
			customer.demographics.totalPurchaseYTD = totalPurchaseYTD;

			DateTime dateFirstPurchase;
			if (!DateTime.TryParse(txtDateFirstPurchase.Text, out dateFirstPurchase))
			{
				MessageBox.Show("dateFirstPurchase could not be parsed.");
				return;
			}
			customer.demographics.dateFirstPurchase = dateFirstPurchase;

			DateTime birthDate;
			if (!DateTime.TryParse(txtBirthDate.Text, out birthDate))
			{
				MessageBox.Show("BirthDate could not be parsed.");
				return;
			}
			customer.demographics.birthDate = birthDate;

			//	customer.demographics.totalPurchaseYTD = txtTotalPurchaseYTD.Text;
			//customer.demographics.dateFirstPurchase = Convert.ToDateTime(txtDateFirstPurchase.Text);
			//customer.demographics.birthDate = txtBirthDate.Text;

			//((System.Collections.Generic.KeyValuePair<string, string>)cmboMaritalStatus.SelectedItem).Value
			customer.demographics.maritalStatus = cmboMaritalStatus.Text;
			//customer.demographics.maritalStatus = cmboMaritalStatus.SelectedValue.ToString();

			//cmboMaritalStatus.DataSource = new BindingSource(Globals.MaritalStatus, null);
			//cmboMaritalStatus.DisplayMember = "Value";
			//cmboMaritalStatus.ValueMember = "Key";
			//cmboMaritalStatus.SelectedIndex = cmboMaritalStatus.FindString(customer.demographics.maritalStatus);

			customer.demographics.yearlyIncome = txtYearlyIncome.Text;

			customer.demographics.gender = cmboGender.Text;


			//cmboGender.DataSource = new BindingSource(Globals.Gender, null);
			//cmboGender.DisplayMember = "Value";
			//cmboGender.ValueMember = "Key";
			//cmboGender.SelectedIndex = cmboGender.FindString(customer.demographics.gender);


			//txtGender.Text = customer.demographics.gender;

			int totalChildren;
			if (!Int32.TryParse(txtTotalChildren.Text, out totalChildren))
			{
				MessageBox.Show("totalChildren could not be parsed.");
				return;
			}
			customer.demographics.totalChildren = totalChildren;

			//customer.demographics.totalPurchaseYTD = totalPurchaseYTD;


			//customer.demographics.totalChildren = txtTotalChildren.Text;

			int numberChildrenAtHome;
			if (!Int32.TryParse(txtNumberChildrenAtHome.Text, out numberChildrenAtHome))
			{
				MessageBox.Show("numberChildrenAtHome could not be parsed.");
				return;
			}
			customer.demographics.numberChildrenAtHome = numberChildrenAtHome;



			//customer.demographics.numberChildrenAtHome = txtNumberChildrenAtHome.Text;

			customer.demographics.education = txtEducation.Text;

			customer.demographics.occupation = txtOccupation.Text;

			customer.demographics.homeOwnerFlag = chkHomeOwnerFlag.Checked;

			//chkHomeOwnerFlag.Checked = customer.demographics.homeOwnerFlag ?? false | (bool)customer.demographics.homeOwnerFlag;

			int numberCarsOwned;
			if (!Int32.TryParse(txtNumberChildrenAtHome.Text, out numberCarsOwned))
			{
				MessageBox.Show("numberCarsOwned could not be parsed.");
				return;
			}
			customer.demographics.numberCarsOwned = numberCarsOwned;



			//	customer.demographics.numberCarsOwned = txtNumberCarsOwned.Text;

			customer.demographics.commuteDistance = txtCommuteDistance.Text;





		}
	}
}
