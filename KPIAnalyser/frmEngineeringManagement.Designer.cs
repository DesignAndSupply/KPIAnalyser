namespace KPIAnalyser
{
    partial class frmEngineeringManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEngineeringManagement));
            this.tabEngineering = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPrintLateness = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoQuaterly = new System.Windows.Forms.RadioButton();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabEngineering.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEngineering
            // 
            this.tabEngineering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEngineering.Controls.Add(this.tabPage1);
            this.tabEngineering.Controls.Add(this.tabPage2);
            this.tabEngineering.Location = new System.Drawing.Point(15, 210);
            this.tabEngineering.Name = "tabEngineering";
            this.tabEngineering.SelectedIndex = 0;
            this.tabEngineering.Size = new System.Drawing.Size(1217, 361);
            this.tabEngineering.TabIndex = 4;
            this.tabEngineering.SelectedIndexChanged += new System.EventHandler(this.tabEngineering_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPrintLateness);
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1209, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programming Lateness";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPrintLateness
            // 
            this.btnPrintLateness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLateness.Location = new System.Drawing.Point(1078, 5);
            this.btnPrintLateness.Name = "btnPrintLateness";
            this.btnPrintLateness.Size = new System.Drawing.Size(125, 23);
            this.btnPrintLateness.TabIndex = 1;
            this.btnPrintLateness.Text = "Print Lateness Chart";
            this.btnPrintLateness.UseVisualStyleBackColor = true;
            this.btnPrintLateness.Click += new System.EventHandler(this.BtnPrintLateness_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(4, 34);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1199, 284);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cartesianChart2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1209, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remake Frequency";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart2.Location = new System.Drawing.Point(4, 4);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(1199, 325);
            this.cartesianChart2.TabIndex = 0;
            this.cartesianChart2.Text = "cartesianChart2";
            this.cartesianChart2.DataClick += new LiveCharts.Events.DataClickHandler(this.cartesianChart2_DataClick);
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(19, 13);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdoWeekly.TabIndex = 5;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            this.rdoWeekly.CheckedChanged += new System.EventHandler(this.RdoWeekly_CheckedChanged);
            this.rdoWeekly.Click += new System.EventHandler(this.RdoWeekly_Click);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(19, 36);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 6;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.RdoMonthly_CheckedChanged);
            // 
            // rdoQuaterly
            // 
            this.rdoQuaterly.AutoSize = true;
            this.rdoQuaterly.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdoQuaterly.Location = new System.Drawing.Point(19, 59);
            this.rdoQuaterly.Name = "rdoQuaterly";
            this.rdoQuaterly.Size = new System.Drawing.Size(67, 17);
            this.rdoQuaterly.TabIndex = 7;
            this.rdoQuaterly.Text = "Quarterly";
            this.rdoQuaterly.UseVisualStyleBackColor = true;
            this.rdoQuaterly.Click += new System.EventHandler(this.RdoQuaterly_Click);
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(19, 82);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 8;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.CheckedChanged += new System.EventHandler(this.rdoYearly_CheckedChanged);
            this.rdoYearly.Click += new System.EventHandler(this.RdoYearly_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(833, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(399, 202);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // frmEngineeringManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 583);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rdoYearly);
            this.Controls.Add(this.rdoQuaterly);
            this.Controls.Add(this.rdoMonthly);
            this.Controls.Add(this.rdoWeekly);
            this.Controls.Add(this.tabEngineering);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEngineeringManagement";
            this.Text = "Engineering Manager KPI";
            this.Load += new System.EventHandler(this.FrmEngineeringManagement_Load);
            this.Shown += new System.EventHandler(this.frmEngineeringManagement_Shown);
            this.tabEngineering.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabEngineering;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoQuaterly;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button btnPrintLateness;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}