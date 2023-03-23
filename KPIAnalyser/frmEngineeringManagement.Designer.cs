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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEngineeringManagement));
            this.tabEngineering = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cartesianChart3 = new LiveCharts.WinForms.CartesianChart();
            this.btnPrintLateness = new System.Windows.Forms.Button();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoQuaterly = new System.Windows.Forms.RadioButton();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblGraphTitle = new System.Windows.Forms.Label();
            this.tabEngineering.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEngineering
            // 
            this.tabEngineering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEngineering.Controls.Add(this.tabPage1);
            this.tabEngineering.Controls.Add(this.tabPage2);
            this.tabEngineering.Controls.Add(this.tabPage3);
            this.tabEngineering.Location = new System.Drawing.Point(15, 240);
            this.tabEngineering.Name = "tabEngineering";
            this.tabEngineering.SelectedIndex = 0;
            this.tabEngineering.Size = new System.Drawing.Size(1217, 331);
            this.tabEngineering.TabIndex = 4;
            this.tabEngineering.SelectedIndexChanged += new System.EventHandler(this.tabEngineering_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1209, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programming Lateness";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(4, 6);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1199, 293);
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
            this.tabPage2.Size = new System.Drawing.Size(1209, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remake Frequency";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart2.Location = new System.Drawing.Point(4, 6);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(1199, 293);
            this.cartesianChart2.TabIndex = 0;
            this.cartesianChart2.Text = "cartesianChart2";
            this.cartesianChart2.DataClick += new LiveCharts.Events.DataClickHandler(this.cartesianChart2_DataClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cartesianChart3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1209, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remakes Returned";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cartesianChart3
            // 
            this.cartesianChart3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart3.Location = new System.Drawing.Point(5, 3);
            this.cartesianChart3.Name = "cartesianChart3";
            this.cartesianChart3.Size = new System.Drawing.Size(1199, 299);
            this.cartesianChart3.TabIndex = 1;
            this.cartesianChart3.Text = "cartesianChart3";
            // 
            // btnPrintLateness
            // 
            this.btnPrintLateness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLateness.Location = new System.Drawing.Point(1137, 220);
            this.btnPrintLateness.Name = "btnPrintLateness";
            this.btnPrintLateness.Size = new System.Drawing.Size(85, 23);
            this.btnPrintLateness.TabIndex = 1;
            this.btnPrintLateness.Text = "Print Chart";
            this.btnPrintLateness.UseVisualStyleBackColor = true;
            this.btnPrintLateness.Click += new System.EventHandler(this.BtnPrintLateness_Click);
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
            this.rdoMonthly.Click += new System.EventHandler(this.rdoMonthly_Click);
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
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToDeleteRows = false;
            this.dgvDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepartment.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartment.Location = new System.Drawing.Point(361, 12);
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.RowHeadersVisible = false;
            this.dgvDepartment.Size = new System.Drawing.Size(456, 202);
            this.dgvDepartment.TabIndex = 1;
            this.dgvDepartment.Visible = false;
            this.dgvDepartment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaff.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaff.Location = new System.Drawing.Point(833, 12);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.Size = new System.Drawing.Size(399, 202);
            this.dgvStaff.TabIndex = 9;
            this.dgvStaff.Visible = false;
            this.dgvStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellDoubleClick);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmail.Location = new System.Drawing.Point(1048, 221);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(83, 22);
            this.btnEmail.TabIndex = 23;
            this.btnEmail.Text = "Email Chart";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblGraphTitle
            // 
            this.lblGraphTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGraphTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblGraphTitle.Location = new System.Drawing.Point(19, 215);
            this.lblGraphTitle.Name = "lblGraphTitle";
            this.lblGraphTitle.Size = new System.Drawing.Size(1209, 29);
            this.lblGraphTitle.TabIndex = 27;
            this.lblGraphTitle.Text = "Programming Lateness";
            this.lblGraphTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEngineeringManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 583);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnPrintLateness);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.dgvDepartment);
            this.Controls.Add(this.rdoYearly);
            this.Controls.Add(this.rdoQuaterly);
            this.Controls.Add(this.rdoMonthly);
            this.Controls.Add(this.rdoWeekly);
            this.Controls.Add(this.tabEngineering);
            this.Controls.Add(this.lblGraphTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEngineeringManagement";
            this.Text = "Engineering Manager KPI";
            this.Load += new System.EventHandler(this.FrmEngineeringManagement_Load);
            this.Shown += new System.EventHandler(this.frmEngineeringManagement_Shown);
            this.tabEngineering.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvDepartment;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.TabPage tabPage3;
        private LiveCharts.WinForms.CartesianChart cartesianChart3;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblGraphTitle;
    }
}