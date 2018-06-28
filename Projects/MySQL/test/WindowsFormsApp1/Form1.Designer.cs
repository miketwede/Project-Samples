namespace WindowsFormsApp1
{
	partial class frmActors
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
			this.components = new System.ComponentModel.Container();
			this.dgvActorObject = new System.Windows.Forms.DataGridView();
			this.dgvActorTable = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.actorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvActorObject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActorTable)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvActorObject
			// 
			this.dgvActorObject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvActorObject.Location = new System.Drawing.Point(18, 12);
			this.dgvActorObject.Name = "dgvActorObject";
			this.dgvActorObject.Size = new System.Drawing.Size(810, 233);
			this.dgvActorObject.TabIndex = 0;
			// 
			// dgvActorTable
			// 
			this.dgvActorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvActorTable.Location = new System.Drawing.Point(18, 15);
			this.dgvActorTable.Name = "dgvActorTable";
			this.dgvActorTable.Size = new System.Drawing.Size(810, 227);
			this.dgvActorTable.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvActorObject);
			this.panel1.Location = new System.Drawing.Point(25, 23);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(841, 260);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgvActorTable);
			this.panel2.Location = new System.Drawing.Point(25, 309);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(841, 268);
			this.panel2.TabIndex = 3;
			// 
			// actorBindingSource
			// 
			this.actorBindingSource.DataSource = typeof(WindowsFormsApp1.Models.Actor);
			this.actorBindingSource.CurrentChanged += new System.EventHandler(this.actorBindingSource_CurrentChanged);
			// 
			// frmActors
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(892, 589);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmActors";
			this.Text = "Actors";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvActorObject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActorTable)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvActorObject;
		private System.Windows.Forms.BindingSource actorBindingSource;
		private System.Windows.Forms.DataGridView dgvActorTable;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

