namespace KPIAnalyser
{
    partial class frmRemakeRepaintDepartmentGraph
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
            this.repaintRemakeChart = new LiveCharts.WinForms.CartesianChart();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDeptNoticed = new System.Windows.Forms.Label();
            this.cmbDeptNoticed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeptResponsible = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPersonResponsible = new System.Windows.Forms.ComboBox();
            this.lblLoggedBy = new System.Windows.Forms.Label();
            this.cmbLoggedBy = new System.Windows.Forms.ComboBox();
            this.dgvRemakesRepaints = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.btnEmailExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakesRepaints)).BeginInit();
            this.SuspendLayout();
            // 
            // repaintRemakeChart
            // 
            this.repaintRemakeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repaintRemakeChart.Location = new System.Drawing.Point(12, 40);
            this.repaintRemakeChart.Name = "repaintRemakeChart";
            this.repaintRemakeChart.Size = new System.Drawing.Size(1352, 149);
            this.repaintRemakeChart.TabIndex = 4;
            this.repaintRemakeChart.Text = "cartesianChart4";
            this.repaintRemakeChart.DataClick += new LiveCharts.Events.DataClickHandler(this.repaintRemakeChart_DataClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1352, 28);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "[Department] [Repaints] between XX/XX/XXXX  and XX/XX/XXXX";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(954, 222);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 23);
            this.btnPrint.TabIndex = 60;
            this.btnPrint.Text = "Export to Excel";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEmail.Location = new System.Drawing.Point(1162, 222);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(98, 23);
            this.btnEmail.TabIndex = 59;
            this.btnEmail.Text = "Email Screen";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Location = new System.Drawing.Point(647, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 58;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(644, 224);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(219, 21);
            this.cmbCustomer.TabIndex = 57;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.Location = new System.Drawing.Point(869, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 23);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "Clear Search";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDeptNoticed
            // 
            this.lblDeptNoticed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDeptNoticed.Location = new System.Drawing.Point(139, 204);
            this.lblDeptNoticed.Name = "lblDeptNoticed";
            this.lblDeptNoticed.Size = new System.Drawing.Size(121, 17);
            this.lblDeptNoticed.TabIndex = 55;
            this.lblDeptNoticed.Text = "Department Noticed";
            this.lblDeptNoticed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptNoticed
            // 
            this.cmbDeptNoticed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDeptNoticed.FormattingEnabled = true;
            this.cmbDeptNoticed.Location = new System.Drawing.Point(136, 224);
            this.cmbDeptNoticed.Name = "cmbDeptNoticed";
            this.cmbDeptNoticed.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptNoticed.TabIndex = 54;
            this.cmbDeptNoticed.SelectedIndexChanged += new System.EventHandler(this.cmbDeptNoticed_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.Location = new System.Drawing.Point(516, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Department Responsible";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbDeptResponsible
            // 
            this.cmbDeptResponsible.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDeptResponsible.FormattingEnabled = true;
            this.cmbDeptResponsible.Location = new System.Drawing.Point(517, 224);
            this.cmbDeptResponsible.Name = "cmbDeptResponsible";
            this.cmbDeptResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbDeptResponsible.TabIndex = 52;
            this.cmbDeptResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbDeptResponsible_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.Location = new System.Drawing.Point(393, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Person Responsible";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbPersonResponsible
            // 
            this.cmbPersonResponsible.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPersonResponsible.FormattingEnabled = true;
            this.cmbPersonResponsible.Location = new System.Drawing.Point(390, 224);
            this.cmbPersonResponsible.Name = "cmbPersonResponsible";
            this.cmbPersonResponsible.Size = new System.Drawing.Size(121, 21);
            this.cmbPersonResponsible.TabIndex = 50;
            this.cmbPersonResponsible.SelectedIndexChanged += new System.EventHandler(this.cmbPersonResponsible_SelectedIndexChanged);
            // 
            // lblLoggedBy
            // 
            this.lblLoggedBy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLoggedBy.Location = new System.Drawing.Point(266, 204);
            this.lblLoggedBy.Name = "lblLoggedBy";
            this.lblLoggedBy.Size = new System.Drawing.Size(121, 17);
            this.lblLoggedBy.TabIndex = 49;
            this.lblLoggedBy.Text = "Logged by";
            this.lblLoggedBy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbLoggedBy
            // 
            this.cmbLoggedBy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbLoggedBy.FormattingEnabled = true;
            this.cmbLoggedBy.Location = new System.Drawing.Point(263, 224);
            this.cmbLoggedBy.Name = "cmbLoggedBy";
            this.cmbLoggedBy.Size = new System.Drawing.Size(121, 21);
            this.cmbLoggedBy.TabIndex = 48;
            this.cmbLoggedBy.SelectedIndexChanged += new System.EventHandler(this.cmbLoggedBy_SelectedIndexChanged);
            // 
            // dgvRemakesRepaints
            // 
            this.dgvRemakesRepaints.AllowUserToAddRows = false;
            this.dgvRemakesRepaints.AllowUserToDeleteRows = false;
            this.dgvRemakesRepaints.AllowUserToResizeColumns = false;
            this.dgvRemakesRepaints.AllowUserToResizeRows = false;
            this.dgvRemakesRepaints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemakesRepaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemakesRepaints.Location = new System.Drawing.Point(12, 251);
            this.dgvRemakesRepaints.Name = "dgvRemakesRepaints";
            this.dgvRemakesRepaints.RowHeadersVisible = false;
            this.dgvRemakesRepaints.Size = new System.Drawing.Size(1352, 406);
            this.dgvRemakesRepaints.TabIndex = 46;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(926, 660);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(438, 23);
            this.lblTotal.TabIndex = 61;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrintScreen.Location = new System.Drawing.Point(1266, 222);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(98, 23);
            this.btnPrintScreen.TabIndex = 62;
            this.btnPrintScreen.Text = "Print Screen";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // btnEmailExcel
            // 
            this.btnEmailExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEmailExcel.Location = new System.Drawing.Point(1058, 222);
            this.btnEmailExcel.Name = "btnEmailExcel";
            this.btnEmailExcel.Size = new System.Drawing.Size(98, 23);
            this.btnEmailExcel.TabIndex = 63;
            this.btnEmailExcel.Text = "Email Excel";
            this.btnEmailExcel.UseVisualStyleBackColor = true;
            this.btnEmailExcel.Click += new System.EventHandler(this.btnEmailExcel_Click);
            // 
            // frmRemakeRepaintDepartmentGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 683);
            this.Controls.Add(this.btnEmailExcel);
            this.Controls.Add(this.btnPrintScreen);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblDeptNoticed);
            this.Controls.Add(this.cmbDeptNoticed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeptResponsible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPersonResponsible);
            this.Controls.Add(this.lblLoggedBy);
            this.Controls.Add(this.cmbLoggedBy);
            this.Controls.Add(this.dgvRemakesRepaints);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.repaintRemakeChart);
            this.Name = "frmRemakeRepaintDepartmentGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Department Graph";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakesRepaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart repaintRemakeChart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblDeptNoticed;
        private System.Windows.Forms.ComboBox cmbDeptNoticed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeptResponsible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPersonResponsible;
        private System.Windows.Forms.Label lblLoggedBy;
        private System.Windows.Forms.ComboBox cmbLoggedBy;
        private System.Windows.Forms.DataGridView dgvRemakesRepaints;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrintScreen;
        private System.Windows.Forms.Button btnEmailExcel;
    }
}