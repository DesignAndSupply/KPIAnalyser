namespace KPIAnalyser
{
    partial class frmRepaintsRemakes
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblTotalPaint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDeptNoticed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeptResponsible = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPersonResponsible = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLoggedBy = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvRemakes = new System.Windows.Forms.DataGridView();
            this.dgvRepaints = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPaintCustomer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPaintDeptResponsible = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPaintPersonResponsible = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTotalRemake = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepaints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.Location = new System.Drawing.Point(1043, 54);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 23);
            this.btnPrint.TabIndex = 32;
            this.btnPrint.Text = "Print Data";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmail.Location = new System.Drawing.Point(1147, 54);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(98, 23);
            this.btnEmail.TabIndex = 31;
            this.btnEmail.Text = "Email Data";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblTotalPaint
            // 
            this.lblTotalPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPaint.Location = new System.Drawing.Point(1232, 972);
            this.lblTotalPaint.Name = "lblTotalPaint";
            this.lblTotalPaint.Size = new System.Drawing.Size(219, 20);
            this.lblTotalPaint.TabIndex = 30;
            this.lblTotalPaint.Text = "TOTAL:";
            this.lblTotalPaint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(736, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(733, 56);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(219, 21);
            this.cmbCustomer.TabIndex = 28;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(958, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Location = new System.Drawing.Point(609, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Department Noticed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptNoticed
            // 
            this.cmbDeptNoticed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeptNoticed.FormattingEnabled = true;
            this.cmbDeptNoticed.Location = new System.Drawing.Point(606, 56);
            this.cmbDeptNoticed.Name = "cmbDeptNoticed";
            this.cmbDeptNoticed.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptNoticed.TabIndex = 25;
            this.cmbDeptNoticed.SelectedIndexChanged += new System.EventHandler(this.cmbDeptNoticed_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Location = new System.Drawing.Point(478, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Department Responsible";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptResponsible
            // 
            this.cmbDeptResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbDeptResponsible.FormattingEnabled = true;
            this.cmbDeptResponsible.Location = new System.Drawing.Point(479, 56);
            this.cmbDeptResponsible.Name = "cmbDeptResponsible";
            this.cmbDeptResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptResponsible.TabIndex = 23;
            this.cmbDeptResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbDeptResponsible_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Location = new System.Drawing.Point(355, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Person Responsible";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPersonResponsible
            // 
            this.cmbPersonResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPersonResponsible.FormattingEnabled = true;
            this.cmbPersonResponsible.Location = new System.Drawing.Point(352, 56);
            this.cmbPersonResponsible.Name = "cmbPersonResponsible";
            this.cmbPersonResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonResponsible.TabIndex = 21;
            this.cmbPersonResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbPersonResponsible_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Location = new System.Drawing.Point(228, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Logged by";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbLoggedBy
            // 
            this.cmbLoggedBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbLoggedBy.FormattingEnabled = true;
            this.cmbLoggedBy.Location = new System.Drawing.Point(225, 56);
            this.cmbLoggedBy.Name = "cmbLoggedBy";
            this.cmbLoggedBy.Size = new System.Drawing.Size(121, 21);
            this.cmbLoggedBy.TabIndex = 19;
            this.cmbLoggedBy.SelectedIndexChanged += new System.EventHandler(this.cmbLoggedBy_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1439, 27);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = " \'YYYYMMDD\' to \'YYYYMMDD\'";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvRemakes
            // 
            this.dgvRemakes.AllowUserToAddRows = false;
            this.dgvRemakes.AllowUserToDeleteRows = false;
            this.dgvRemakes.AllowUserToResizeColumns = false;
            this.dgvRemakes.AllowUserToResizeRows = false;
            this.dgvRemakes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemakes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemakes.Location = new System.Drawing.Point(12, 117);
            this.dgvRemakes.Name = "dgvRemakes";
            this.dgvRemakes.RowHeadersVisible = false;
            this.dgvRemakes.Size = new System.Drawing.Size(1439, 382);
            this.dgvRemakes.TabIndex = 17;
            // 
            // dgvRepaints
            // 
            this.dgvRepaints.AllowUserToAddRows = false;
            this.dgvRepaints.AllowUserToDeleteRows = false;
            this.dgvRepaints.AllowUserToResizeColumns = false;
            this.dgvRepaints.AllowUserToResizeRows = false;
            this.dgvRepaints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRepaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepaints.Location = new System.Drawing.Point(12, 579);
            this.dgvRepaints.Name = "dgvRepaints";
            this.dgvRepaints.RowHeadersVisible = false;
            this.dgvRepaints.Size = new System.Drawing.Size(1439, 390);
            this.dgvRepaints.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(12, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1439, 27);
            this.label6.TabIndex = 34;
            this.label6.Text = "Remakes";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(12, 549);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1439, 27);
            this.label7.TabIndex = 35;
            this.label7.Text = "Repaints";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Location = new System.Drawing.Point(736, 505);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Customer";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPaintCustomer
            // 
            this.cmbPaintCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPaintCustomer.FormattingEnabled = true;
            this.cmbPaintCustomer.Location = new System.Drawing.Point(733, 525);
            this.cmbPaintCustomer.Name = "cmbPaintCustomer";
            this.cmbPaintCustomer.Size = new System.Drawing.Size(219, 21);
            this.cmbPaintCustomer.TabIndex = 40;
            this.cmbPaintCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbPaintCustomer_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.Location = new System.Drawing.Point(605, 505);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 39;
            this.label9.Text = "Department Responsible";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPaintDeptResponsible
            // 
            this.cmbPaintDeptResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPaintDeptResponsible.FormattingEnabled = true;
            this.cmbPaintDeptResponsible.Location = new System.Drawing.Point(606, 525);
            this.cmbPaintDeptResponsible.Name = "cmbPaintDeptResponsible";
            this.cmbPaintDeptResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbPaintDeptResponsible.TabIndex = 38;
            this.cmbPaintDeptResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbPaintDeptResponsible_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.Location = new System.Drawing.Point(482, 505);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Person Responsible";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPaintPersonResponsible
            // 
            this.cmbPaintPersonResponsible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPaintPersonResponsible.FormattingEnabled = true;
            this.cmbPaintPersonResponsible.Location = new System.Drawing.Point(479, 525);
            this.cmbPaintPersonResponsible.Name = "cmbPaintPersonResponsible";
            this.cmbPaintPersonResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbPaintPersonResponsible.TabIndex = 36;
            this.cmbPaintPersonResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbPaintPersonResponsible_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(958, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Clear Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTotalRemake
            // 
            this.lblTotalRemake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRemake.Location = new System.Drawing.Point(1232, 503);
            this.lblTotalRemake.Name = "lblTotalRemake";
            this.lblTotalRemake.Size = new System.Drawing.Size(219, 23);
            this.lblTotalRemake.TabIndex = 43;
            this.lblTotalRemake.Text = "TOTAL:";
            this.lblTotalRemake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Location = new System.Drawing.Point(1043, 523);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Print Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Location = new System.Drawing.Point(1147, 523);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "Email Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmRepaintsRemakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 996);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTotalRemake);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPaintCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbPaintDeptResponsible);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbPaintPersonResponsible);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvRepaints);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.lblTotalPaint);
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
            this.Controls.Add(this.dgvRemakes);
            this.MinimizeBox = false;
            this.Name = "frmRepaintsRemakes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRepaintsRemakes";
            this.Load += new System.EventHandler(this.frmRepaintsRemakes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblTotalPaint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDeptNoticed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeptResponsible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersonResponsible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLoggedBy;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvRemakes;
        private System.Windows.Forms.DataGridView dgvRepaints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPaintCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPaintDeptResponsible;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPaintPersonResponsible;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTotalRemake;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}