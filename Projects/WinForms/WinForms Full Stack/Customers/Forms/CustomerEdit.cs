using System.Collections.Generic;
using System.Windows.Forms;

using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;
using System.Drawing;

namespace customers.Forms
{
	public partial class CustomerEdit : Form
	{
		public CustomerEdit(int CustomerID)
		{
			InitializeComponent();
			GetCustomerSQL(CustomerID);
			txtCustomerID.Text = CustomerID.ToString();
		}

		private void GetCustomerSQL(int CustomerID)
		{
			CustomerBO customerBO = new CustomerBO();

			Customer customer = customerBO.GetCustomerByCustomerID(CustomerID);

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
			txtMaritalStatus.Text = customer.demographics.maritalStatus;
			txtYearlyIncome.Text = customer.demographics.yearlyIncome;
			txtGender.Text = customer.demographics.gender;
			txtTotalChildren.Text = customer.demographics.totalChildren.ToString();
			txtNumberChildrenAtHome.Text = customer.demographics.numberChildrenAtHome.ToString();
			txtEducation.Text = customer.demographics.education;
			txtOccupation.Text = customer.demographics.occupation;
			txtHomeOwnerFlag.Text = customer.demographics.homeOwnerFlag.ToString();
			txtNumberCarsOwned.Text = customer.demographics.numberCarsOwned.ToString();
			txtCommuteDistance.Text = customer.demographics.commuteDistance;
			//txtPhoto.Text = customer.person.photo;





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

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{

		}
	}
}
