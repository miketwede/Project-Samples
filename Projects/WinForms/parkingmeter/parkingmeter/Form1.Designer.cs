﻿namespace parkingmeter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtMinutes = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbMeterType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblInstructions = new System.Windows.Forms.Label();
			this.btnMax = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(598, 331);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "Calculate";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 199);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(207, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Please enter the dollar amount you will pay";
			// 
			// txtAmount
			// 
			this.txtAmount.Location = new System.Drawing.Point(267, 196);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(232, 20);
			this.txtAmount.TabIndex = 2;
			this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(689, 331);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtMinutes
			// 
			this.txtMinutes.Location = new System.Drawing.Point(267, 228);
			this.txtMinutes.Name = "txtMinutes";
			this.txtMinutes.ReadOnly = true;
			this.txtMinutes.Size = new System.Drawing.Size(232, 20);
			this.txtMinutes.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 231);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Number of minutes available";
			// 
			// cmbMeterType
			// 
			this.cmbMeterType.FormattingEnabled = true;
			this.cmbMeterType.Items.AddRange(new object[] {
            "30 minutes",
            "1 hour",
            "2 hours",
            "3 hours",
            "5 hours"});
			this.cmbMeterType.Location = new System.Drawing.Point(267, 122);
			this.cmbMeterType.Name = "cmbMeterType";
			this.cmbMeterType.Size = new System.Drawing.Size(232, 21);
			this.cmbMeterType.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(43, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Please enter the meter type";
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Location = new System.Drawing.Point(44, 13);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(0, 13);
			this.lblInstructions.TabIndex = 8;
			// 
			// btnMax
			// 
			this.btnMax.Location = new System.Drawing.Point(528, 228);
			this.btnMax.Name = "btnMax";
			this.btnMax.Size = new System.Drawing.Size(75, 23);
			this.btnMax.TabIndex = 9;
			this.btnMax.Text = "Max";
			this.btnMax.UseVisualStyleBackColor = true;
			this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 366);
			this.Controls.Add(this.btnMax);
			this.Controls.Add(this.lblInstructions);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbMeterType);
			this.Controls.Add(this.txtMinutes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.txtAmount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Name = "Form1";
			this.Text = "Parking Meter";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMeterType;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.Button btnMax;
	}
}

