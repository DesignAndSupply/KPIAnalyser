namespace KPIAnalyser
{
    partial class frmNonReturningCustomerDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonReturningCustomerDetails));
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblContactBy = new System.Windows.Forms.Label();
            this.lblContactDate = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(13, 13);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "label1";
            // 
            // lblContactBy
            // 
            this.lblContactBy.AutoSize = true;
            this.lblContactBy.Location = new System.Drawing.Point(15, 41);
            this.lblContactBy.Name = "lblContactBy";
            this.lblContactBy.Size = new System.Drawing.Size(35, 13);
            this.lblContactBy.TabIndex = 1;
            this.lblContactBy.Text = "label1";
            // 
            // lblContactDate
            // 
            this.lblContactDate.AutoSize = true;
            this.lblContactDate.Location = new System.Drawing.Point(15, 62);
            this.lblContactDate.Name = "lblContactDate";
            this.lblContactDate.Size = new System.Drawing.Size(35, 13);
            this.lblContactDate.TabIndex = 2;
            this.lblContactDate.Text = "label1";
            // 
            // txtNotes
            // 
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(13, 92);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(677, 284);
            this.txtNotes.TabIndex = 3;
            // 
            // frmNonReturningCustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 388);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblContactDate);
            this.Controls.Add(this.lblContactBy);
            this.Controls.Add(this.lblCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNonReturningCustomerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details:";
            this.Load += new System.EventHandler(this.frmNonReturningCustomerDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblContactBy;
        private System.Windows.Forms.Label lblContactDate;
        private System.Windows.Forms.TextBox txtNotes;
    }
}