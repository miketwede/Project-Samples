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

			txtTotalChildren.Text = customer.demographics.totalChildren.ToString();
			txtNumberChildrenAtHome.Text = customer.demographics.numberChildrenAtHome.ToString();
			txtEducation.Text = customer.demographics.education;
			txtOccupation.Text = customer.demographics.occupation;
			chkHomeOwnerFlag.Checked = customer.demographics.homeOwnerFlag ?? false | (bool)customer.demographics.homeOwnerFlag;
			txtNumberCarsOwned.Text = customer.demographics.numberCarsOwned.ToString();
			txtCommuteDistance.Text = customer.demographics.commuteDistance;

			byte[] byteArray = customer.person.photo;
			MemoryStream stream = new MemoryStream();
			Bitmap bitmap = null;

			if (byteArray != null && byteArray.Length > 0)
			{
				stream = new MemoryStream(byteArray);
				bitmap = new Bitmap(stream);
			}

			pbPhoto.Image = bitmap;
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
			bool validated = false;

			validated = PopulateCustomer();

			if (!validated)
				return;

			CustomerBO customerBO = new CustomerBO();
			customerBO.UpdateCustomer(customer);
			DisplayMessage(Color.Green, "Customer saved.");			
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

		private bool PopulateCustomer()
		{
			bool validated = true;
			string errorMessages = "";

			int emailPromotion;
			if (!Int32.TryParse(txtEmailPromotion.Text, out emailPromotion))
			{
				//MessageBox.Show("EmailPromotion could not be parsed.");
				errorMessages += "EmailPromotion could not be parsed." + Environment.NewLine;
				validated = false;
			}

			decimal totalPurchaseYTD;
			if (!Decimal.TryParse(txtTotalPurchaseYTD.Text, out totalPurchaseYTD))
			{
				//MessageBox.Show("TotalPurchaseYTD could not be parsed.");
				errorMessages += "TotalPurchaseYTD could not be parsed." + Environment.NewLine;

				validated = false;
			}

			DateTime birthDate;
			if (!DateTime.TryParse(txtBirthDate.Text, out birthDate))
			{
				//MessageBox.Show("BirthDate could not be parsed.");
				errorMessages += "BirthDate could not be parsed." + Environment.NewLine;
				validated = false;
			}

			DateTime dateFirstPurchase;
			if (!DateTime.TryParse(txtDateFirstPurchase.Text, out dateFirstPurchase))
			{
				//MessageBox.Show("dateFirstPurchase could not be parsed.");
				errorMessages += "dateFirstPurchase could not be parsed." + Environment.NewLine;
				validated = false;
			}

			int totalChildren;
			if (!Int32.TryParse(txtTotalChildren.Text, out totalChildren))
			{
				//MessageBox.Show("totalChildren could not be parsed.");
				errorMessages += "totalChildren could not be parsed." + Environment.NewLine;
				validated = false;
			}

			int numberChildrenAtHome;
			if (!Int32.TryParse(txtNumberChildrenAtHome.Text, out numberChildrenAtHome))
			{
				//MessageBox.Show("numberChildrenAtHome could not be parsed.");
				errorMessages += "numberChildrenAtHome could not be parsed." + Environment.NewLine;
				validated = false;
			}

			int numberCarsOwned;
			if (!Int32.TryParse(txtNumberChildrenAtHome.Text, out numberCarsOwned))
			{
				//MessageBox.Show("numberCarsOwned could not be parsed.");
				errorMessages += "numberCarsOwned could not be parsed." + Environment.NewLine;
				validated = false;
			}

			if (!validated)
			{
				DisplayMessage(Color.Red, errorMessages);
				return validated;
			}

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
			customer.emailPromotion = emailPromotion;
			customer.demographics.totalPurchaseYTD = totalPurchaseYTD;
			customer.demographics.dateFirstPurchase = dateFirstPurchase;
			customer.demographics.birthDate = birthDate;

			//string mike = ((System.Collections.Generic.KeyValuePair<string, string>)cmboMaritalStatus.SelectedItem).Value;
			customer.demographics.maritalStatus = cmboMaritalStatus.Text;
			//customer.demographics.maritalStatus = cmboMaritalStatus.SelectedValue.ToString();

			customer.demographics.yearlyIncome = txtYearlyIncome.Text;
			customer.demographics.gender = cmboGender.Text;
			customer.demographics.totalChildren = totalChildren;
			customer.demographics.numberChildrenAtHome = numberChildrenAtHome;
			customer.demographics.education = txtEducation.Text;
			customer.demographics.occupation = txtOccupation.Text;
			customer.demographics.homeOwnerFlag = chkHomeOwnerFlag.Checked;
			customer.demographics.numberCarsOwned = numberCarsOwned;
			customer.demographics.commuteDistance = txtCommuteDistance.Text;

			return validated;
		}


		private void DisplayMessage(Color color, string message)
		{

			txtMessages.ForeColor = color;
			txtMessages.Text = message;
		}

		private void HideMessage()
		{

			txtMessages.Text = "";
		}
	}
}
