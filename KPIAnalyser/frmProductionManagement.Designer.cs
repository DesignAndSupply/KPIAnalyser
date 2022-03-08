namespace KPIAnalyser
{
    partial class frmProductionManagement
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
            this.tabEngineering = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart2 = new LiveCharts.Wpf.CartesianChart();
            this.btnPrintLateness = new System.Windows.Forms.Button();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoQuaterly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabEngineering.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEngineering
            // 
            this.tabEngineering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEngineering.Controls.Add(this.tabPage1);
            this.tabEngineering.Controls.Add(this.tabPage2);
            this.tabEngineering.Location = new System.Drawing.Point(12, 118);
            this.tabEngineering.Name = "tabEngineering";
            this.tabEngineering.SelectedIndex = 0;
            this.tabEngineering.Size = new System.Drawing.Size(1265, 527);
            this.tabEngineering.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1257, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Completed on Time";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(4, 6);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1247, 478);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.elementHost2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1257, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  Absenteeism";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // elementHost2
            // 
            this.elementHost2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost2.Location = new System.Drawing.Point(5, 10);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(1247, 465);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.cartesianChart2;
            // 
            // btnPrintLateness
            // 
            this.btnPrintLateness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLateness.Location = new System.Drawing.Point(1183, 90);
            this.btnPrintLateness.Name = "btnPrintLateness";
            this.btnPrintLateness.Size = new System.Drawing.Size(94, 22);
            this.btnPrintLateness.TabIndex = 13;
            this.btnPrintLateness.Text = "Print Chart";
            this.btnPrintLateness.UseVisualStyleBackColor = true;
            this.btnPrintLateness.Click += new System.EventHandler(this.btnPrintLateness_Click);
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(20, 82);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 18;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.Click += new System.EventHandler(this.rdoYearly_Click);
            // 
            // rdoQuaterly
            // 
            this.rdoQuaterly.AutoSize = true;
            this.rdoQuaterly.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdoQuaterly.Location = new System.Drawing.Point(20, 59);
            this.rdoQuaterly.Name = "rdoQuaterly";
            this.rdoQuaterly.Size = new System.Drawing.Size(67, 17);
            this.rdoQuaterly.TabIndex = 17;
            this.rdoQuaterly.Text = "Quarterly";
            this.rdoQuaterly.UseVisualStyleBackColor = true;
            this.rdoQuaterly.Click += new System.EventHandler(this.rdoQuaterly_Click);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(20, 36);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 16;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.Click += new System.EventHandler(this.rdoMonthly_Click);
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(20, 13);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdoWeekly.TabIndex = 15;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            this.rdoWeekly.Click += new System.EventHandler(this.rdoWeekly_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(157, 92);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(309, 21);
            this.cmbCustomer.TabIndex = 19;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            this.cmbCustomer.TextChanged += new System.EventHandler(this.cmbCustomer_TextChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(157, 76);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(309, 13);
            this.lblCustomer.TabIndex = 20;
            this.lblCustomer.Text = "Customer Filter";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(472, 92);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmProductionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 658);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.tabEngineering);
            this.Controls.Add(this.btnPrintLateness);
            this.Controls.Add(this.rdoYearly);
            this.Controls.Add(this.rdoQuaterly);
            this.Controls.Add(this.rdoMonthly);
            this.Controls.Add(this.rdoWeekly);
            this.Name = "frmProductionManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Management";
            this.Shown += new System.EventHandler(this.frmProductionManagement_Shown);
            this.tabEngineering.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabEngineering;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.Button btnPrintLateness;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.RadioButton rdoQuaterly;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnClear;
        private LiveCharts.Wpf.CartesianChart cartesianChart2;
    }
}