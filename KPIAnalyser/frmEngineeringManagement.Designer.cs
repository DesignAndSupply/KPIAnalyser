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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoQuaterly = new System.Windows.Forms.RadioButton();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.tabEngineering.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEngineering
            // 
            this.tabEngineering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEngineering.Controls.Add(this.tabPage1);
            this.tabEngineering.Controls.Add(this.tabPage2);
            this.tabEngineering.Location = new System.Drawing.Point(15, 134);
            this.tabEngineering.Name = "tabEngineering";
            this.tabEngineering.SelectedIndex = 0;
            this.tabEngineering.Size = new System.Drawing.Size(1217, 437);
            this.tabEngineering.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1209, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Programming Lateness";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(4, 7);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1199, 398);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1209, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remake Frequency";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Checked = true;
            this.rdoWeekly.Location = new System.Drawing.Point(19, 13);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdoWeekly.TabIndex = 5;
            this.rdoWeekly.TabStop = true;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
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
            this.rdoQuaterly.Location = new System.Drawing.Point(19, 59);
            this.rdoQuaterly.Name = "rdoQuaterly";
            this.rdoQuaterly.Size = new System.Drawing.Size(64, 17);
            this.rdoQuaterly.TabIndex = 7;
            this.rdoQuaterly.Text = "Quaterly";
            this.rdoQuaterly.UseVisualStyleBackColor = true;
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
            // 
            // frmEngineeringManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 583);
            this.Controls.Add(this.rdoYearly);
            this.Controls.Add(this.rdoQuaterly);
            this.Controls.Add(this.rdoMonthly);
            this.Controls.Add(this.rdoWeekly);
            this.Controls.Add(this.tabEngineering);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEngineeringManagement";
            this.Text = "Engineering Manager KPI";
            this.Load += new System.EventHandler(this.FrmEngineeringManagement_Load);
            this.tabEngineering.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}