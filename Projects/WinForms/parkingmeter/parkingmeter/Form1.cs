using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parkingmeter
{
    /// <summary>
    /// Parking Meter Program
    /// You have to write the code for figuring out how many minutes someone is paying for a parking meter via his/her debit card.  
    /// The fees are $1.75 per hour.  Different parking meters have different time limits (1 hour, 2 hours, 3 hours, 5 hours, and 30 minutes).  
    /// You may not overcharge customers beyond the time limit.  Also, parking meters are only valid from 7am, to 7pm Monday to Saturday, and from 1pm to 7pm on Sundays.  
    /// The customer can ask to charge a certain $ amount, or the maximum time.  You will need to calculate how many minutes they spend and the end time to print on the ticket.
    /// </summary>
    public partial class Form1 : Form
    {
        private int PaidMinutes = 0;
        private decimal AmountSpent = 0.0M;
        private const decimal Rate = 1.75M;

        public Form1()
        {
            InitializeComponent();

			lblInstructions.Text =	"The fees are $1.75 per hour.\n " +
									"Different parking meters have different time limits (1 hour, 2 hours, 3 hours, 5 hours, and 30 minutes).\n" +  
									"You may not overcharge customers beyond the time limit.\n" +
									"Also, parking meters are only valid from 7am, to 7pm Monday to Saturday, and from 1pm to 7pm on Sundays.\n" +  
									"The customer can ask to charge a certain $ amount, or the maximum time.\n" +
									"You will need to calculate how many minutes they spend and the end time to print on the ticket.";

			//if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
			//{
			//	if (DateTime.Now.Hour < 13 || DateTime.Now.Hour > 19)
			//	{
			//		cmbMeterType.Enabled = false;
			//		txtAmount.Enabled = false;
			//		txtMinutes.Enabled = false;
			//		lblInstructions.ForeColor = Color.Red;
			//		lblInstructions.Text = "Sorry we are closed!";
			//	}
			//}
			//else
			//{
			//	if (DateTime.Now.Hour < 7 || DateTime.Now.Hour > 19)
			//	{
			//		cmbMeterType.Enabled = false;
			//		txtAmount.Enabled = false;
			//		txtMinutes.Enabled = false;
			//		lblInstructions.ForeColor = Color.Red;
			//		lblInstructions.Text = "Sorry we are closed!";
			//	}
			//}

		}

		private int CalculateTime(decimal AmountSpent)
		{
			int minutesAvailable = 0;

			if (AmountSpent <= 0)
			{
				MessageBox.Show("Insufficient amount provided. Amount must be positive amount.");
				return 0;
			}

			minutesAvailable = (int)((AmountSpent / Rate) * 60);

			return minutesAvailable;
		}

		private decimal CalculateAmount(int Minutes)
		{
			decimal amount = 0.0M;

			if (Minutes < 1)
			{
				MessageBox.Show("Insufficient time provided. Time must be positive amount.");
				return 0;
			}

			amount = Rate * Minutes / 60;

			return amount;
		}

		private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal amountSpent;

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Insufficient amount provided. Amount must be positive amount.");
                return;
            }

            if (string.IsNullOrEmpty(cmbMeterType.Text))
            {
                MessageBox.Show("Please select the meter type.");
                return;
            }

            if (decimal.TryParse(txtAmount.Text, out amountSpent))
            {
                PaidMinutes = CalculateTime(amountSpent);
                switch (cmbMeterType.Text)
                {
                    case "30 minutes":
                        if (PaidMinutes > 30)
                        {
                            MessageBox.Show("Paid too much for this meter. Please select a different meter or pay less.");
                            return;
                        }
                        break;

                    case "1 hour":
                        if (PaidMinutes > 60)
                        {
                            MessageBox.Show("Paid too much for this meter. Please select a different meter or pay less.");
                            return;
                        }
                        break;

                    case "2 hours":
                        if (PaidMinutes > 120)
                        {
                            MessageBox.Show("Paid too much for this meter. Please select a different meter or pay less.");
                            return;
                        }
                        break;

                    case "3 hours":
                        if (PaidMinutes > 180)
                        {
                            MessageBox.Show("Paid too much for this meter. Please select a different meter or pay less.");
                            return;
                        }
                        break;

                    case "5 hours":
                        if (PaidMinutes > 300)
                        {
                            MessageBox.Show("Paid too much for this meter. Please select a different meter or pay less.");
                            return;
                        }
                        break;
                }
                txtMinutes.Text = PaidMinutes.ToString();
            }
            else
            {
                MessageBox.Show("Invalid amount provided. Please enter a positive dollar amount.");
                return;
            }

			MessageBox.Show(string.Format("Your meter is valid for {0} minutes.\n\n Start Time : {1}.\n End Time : {2}.", PaidMinutes, DateTime.Now, DateTime.Now.AddMinutes(PaidMinutes)));

		}

		private void txtAmount_TextChanged(object sender, EventArgs e)
		{
			decimal AmountSpent = 0.0M;

			//if (decimal.TryParse(sender.ToString(), out AmountSpent))
				if (decimal.TryParse(txtAmount.Text, out AmountSpent))
				{
					txtMinutes.Text = CalculateTime(AmountSpent).ToString();
			}


		}

		private void btnMax_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cmbMeterType.Text))
			{
				MessageBox.Show("Please select the meter type.");
				return;
			}


				switch (cmbMeterType.Text)
				{
					case "30 minutes":
					txtMinutes.Text = "30";
					txtAmount.Text = CalculateAmount(30).ToString(); ;
					break;

					case "1 hour":
					txtMinutes.Text = "60";
					txtAmount.Text = CalculateAmount(60).ToString(); ;
					break;

				case "2 hours":
					txtMinutes.Text = "120";
					txtAmount.Text = CalculateAmount(120).ToString(); ;
					break;

				case "3 hours":
					txtMinutes.Text = "180";
					txtAmount.Text = CalculateAmount(180).ToString(); ;
					break;


				case "5 hours":
					txtMinutes.Text = "300";
					txtAmount.Text = CalculateAmount(300).ToString(); ;
					break;
			}

		}
	}
}
