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
        private const decimal Rate = 1.74M;

        public Form1()
        {
            InitializeComponent();

            //Minutes = CalculateTime(AmountSpent);

        }

        private int CalculateTime(decimal AmountSpent)
        {
            int minutesAvailable = 0;

            if (AmountSpent < 1)
            {
                MessageBox.Show("Insufficient amount provided. Amount must be positive amount.");
                return 0;
            }

            minutesAvailable = (int)((Rate / AmountSpent) * 60);

            return minutesAvailable;
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

        }

    }
}
