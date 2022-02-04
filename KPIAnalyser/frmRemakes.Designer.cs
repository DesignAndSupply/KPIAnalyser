namespace KPIAnalyser
{
    partial class frmRemakes
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbLoggedBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPersonResponsible = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeptResponsible = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDeptNoticed = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1106, 393);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1109, 27);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Remakes From: \'YYYYMMDD\' to \'YYYYMMDD\'";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbLoggedBy
            // 
            this.cmbLoggedBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbLoggedBy.FormattingEnabled = true;
            this.cmbLoggedBy.Location = new System.Drawing.Point(202, 59);
            this.cmbLoggedBy.Name = "cmbLoggedBy";
            this.cmbLoggedBy.Size = new System.Drawing.Size(121, 21);
            this.cmbLoggedBy.TabIndex = 2;
            this.cmbLoggedBy.SelectedIndexChanged += new System.EventHandler(this.cmbLoggedBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Location = new System.Drawing.Point(202, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Logged by";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Location = new System.Drawing.Point(329, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Person Responsible";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPersonResponsible
            // 
            this.cmbPersonResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPersonResponsible.FormattingEnabled = true;
            this.cmbPersonResponsible.Location = new System.Drawing.Point(329, 59);
            this.cmbPersonResponsible.Name = "cmbPersonResponsible";
            this.cmbPersonResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonResponsible.TabIndex = 4;
            this.cmbPersonResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbPersonResponsible_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Location = new System.Drawing.Point(452, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Department Responsible";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptResponsible
            // 
            this.cmbDeptResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeptResponsible.FormattingEnabled = true;
            this.cmbDeptResponsible.Location = new System.Drawing.Point(456, 59);
            this.cmbDeptResponsible.Name = "cmbDeptResponsible";
            this.cmbDeptResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptResponsible.TabIndex = 6;
            this.cmbDeptResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbDeptResponsible_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Location = new System.Drawing.Point(583, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Department Noticed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptNoticed
            // 
            this.cmbDeptNoticed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeptNoticed.FormattingEnabled = true;
            this.cmbDeptNoticed.Location = new System.Drawing.Point(583, 59);
            this.cmbDeptNoticed.Name = "cmbDeptNoticed";
            this.cmbDeptNoticed.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptNoticed.TabIndex = 8;
            this.cmbDeptNoticed.SelectedIndexChanged += new System.EventHandler(this.cmbDeptNoticed_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(935, 57);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(710, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(710, 59);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(219, 21);
            this.cmbCustomer.TabIndex = 11;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(899, 484);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(219, 20);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmail.Location = new System.Drawing.Point(1020, 57);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(98, 23);
            this.btnEmail.TabIndex = 15;
            this.btnEmail.Text = "Email Data";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // frmRemakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 513);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDeptNoticed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeptResponsible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPersonResponsible);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLoggedBy);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRemakes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remakes";
            this.Shown += new System.EventHandler(this.frmRemakes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbLoggedBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersonResponsible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeptResponsible;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDeptNoticed;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEmail;
    }
}