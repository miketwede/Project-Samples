using System.Collections.Generic;
using System.Windows.Forms;

using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;
using System.Drawing;
using System.IO;
using System.Text;

using SampleDemoWebApi.CustomerApi.Global;

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

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{

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
	}
}
