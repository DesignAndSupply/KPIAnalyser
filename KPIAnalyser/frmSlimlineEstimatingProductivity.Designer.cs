namespace KPIAnalyser
{
    partial class frmSlimlineEstimatingProductivity
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
            this.unpaidGuage = new LiveCharts.WinForms.AngularGauge();
            this.lateGuage = new LiveCharts.WinForms.AngularGauge();
            this.annualLeaveGuage = new LiveCharts.WinForms.AngularGauge();
            this.absentGuage = new LiveCharts.WinForms.AngularGauge();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.absentDays = new System.Windows.Forms.Label();
            this.annualLeave = new System.Windows.Forms.Label();
            this.dailyItemsGuage = new LiveCharts.WinForms.AngularGauge();
            this.lateDays = new System.Windows.Forms.Label();
            this.unpaidLeave = new System.Windows.Forms.Label();
            this.lblDailyAverage = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.cmbStaffMember = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.label4 = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIncludeRevisions = new System.Windows.Forms.CheckBox();
            this.btnViewQuotes = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblSales = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.chaseGague = new LiveCharts.WinForms.AngularGauge();
            this.lblChase = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // unpaidGuage
            // 
            this.unpaidGuage.Location = new System.Drawing.Point(28, 267);
            this.unpaidGuage.Name = "unpaidGuage";
            this.unpaidGuage.Size = new System.Drawing.Size(193, 186);
            this.unpaidGuage.TabIndex = 23;
            this.unpaidGuage.Text = "~~~~~~~~~~~~";
            // 
            // lateGuage
            // 
            this.lateGuage.Location = new System.Drawing.Point(1537, 76);
            this.lateGuage.Name = "lateGuage";
            this.lateGuage.Size = new System.Drawing.Size(193, 186);
            this.lateGuage.TabIndex = 22;
            this.lateGuage.Text = "~~~~~~~~~~~~";
            // 
            // annualLeaveGuage
            // 
            this.annualLeaveGuage.Location = new System.Drawing.Point(1328, 76);
            this.annualLeaveGuage.Name = "annualLeaveGuage";
            this.annualLeaveGuage.Size = new System.Drawing.Size(193, 186);
            this.annualLeaveGuage.TabIndex = 21;
            this.annualLeaveGuage.Text = "~~~~~~~~~~~~";
            // 
            // absentGuage
            // 
            this.absentGuage.Location = new System.Drawing.Point(1119, 76);
            this.absentGuage.Name = "absentGuage";
            this.absentGuage.Size = new System.Drawing.Size(193, 186);
            this.absentGuage.TabIndex = 20;
            this.absentGuage.Text = "~~~~~~~~~~~~";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chaseGague);
            this.groupBox1.Controls.Add(this.lblChase);
            this.groupBox1.Controls.Add(this.absentDays);
            this.groupBox1.Controls.Add(this.annualLeave);
            this.groupBox1.Controls.Add(this.dailyItemsGuage);
            this.groupBox1.Controls.Add(this.lateDays);
            this.groupBox1.Controls.Add(this.unpaidLeave);
            this.groupBox1.Controls.Add(this.lblDailyAverage);
            this.groupBox1.Controls.Add(this.unpaidGuage);
            this.groupBox1.Location = new System.Drawing.Point(1091, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 481);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "attendance";
            // 
            // absentDays
            // 
            this.absentDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.absentDays.Location = new System.Drawing.Point(24, 13);
            this.absentDays.Name = "absentDays";
            this.absentDays.Size = new System.Drawing.Size(193, 20);
            this.absentDays.TabIndex = 15;
            this.absentDays.Text = "Absent Days:";
            this.absentDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // annualLeave
            // 
            this.annualLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annualLeave.Location = new System.Drawing.Point(233, 15);
            this.annualLeave.Name = "annualLeave";
            this.annualLeave.Size = new System.Drawing.Size(193, 20);
            this.annualLeave.TabIndex = 16;
            this.annualLeave.Text = "Annual Leave:";
            this.annualLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dailyItemsGuage
            // 
            this.dailyItemsGuage.Location = new System.Drawing.Point(237, 267);
            this.dailyItemsGuage.Name = "dailyItemsGuage";
            this.dailyItemsGuage.Size = new System.Drawing.Size(193, 186);
            this.dailyItemsGuage.TabIndex = 33;
            this.dailyItemsGuage.Text = "~~~~~~~~~~~~";
            // 
            // lateDays
            // 
            this.lateDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lateDays.Location = new System.Drawing.Point(442, 13);
            this.lateDays.Name = "lateDays";
            this.lateDays.Size = new System.Drawing.Size(193, 20);
            this.lateDays.TabIndex = 17;
            this.lateDays.Text = "Late Days:";
            this.lateDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // unpaidLeave
            // 
            this.unpaidLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpaidLeave.Location = new System.Drawing.Point(24, 244);
            this.unpaidLeave.Name = "unpaidLeave";
            this.unpaidLeave.Size = new System.Drawing.Size(193, 20);
            this.unpaidLeave.TabIndex = 18;
            this.unpaidLeave.Text = "Unpaid Leave:";
            this.unpaidLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDailyAverage
            // 
            this.lblDailyAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyAverage.Location = new System.Drawing.Point(233, 244);
            this.lblDailyAverage.Name = "lblDailyAverage";
            this.lblDailyAverage.Size = new System.Drawing.Size(197, 20);
            this.lblDailyAverage.TabIndex = 34;
            this.lblDailyAverage.Text = "Daily Average Price:";
            this.lblDailyAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 197);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 31;
            this.btnGenerate.Text = "Refresh";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Start Date:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(15, 171);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 28;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(15, 127);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 27;
            // 
            // cmbStaffMember
            // 
            this.cmbStaffMember.DisplayMember = "fullname";
            this.cmbStaffMember.FormattingEnabled = true;
            this.cmbStaffMember.Location = new System.Drawing.Point(15, 86);
            this.cmbStaffMember.Name = "cmbStaffMember";
            this.cmbStaffMember.Size = new System.Drawing.Size(200, 21);
            this.cmbStaffMember.TabIndex = 26;
            this.cmbStaffMember.ValueMember = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Select Staff Member:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runComparisonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1775, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runComparisonToolStripMenuItem
            // 
            this.runComparisonToolStripMenuItem.Name = "runComparisonToolStripMenuItem";
            this.runComparisonToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.runComparisonToolStripMenuItem.Text = "Run Comparison";
            this.runComparisonToolStripMenuItem.Click += new System.EventHandler(this.runComparisonToolStripMenuItem_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cartesianChart1.Location = new System.Drawing.Point(15, 525);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(877, 209);
            this.cartesianChart1.TabIndex = 41;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 501);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(877, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Daily Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(271, 69);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(786, 423);
            this.pieChart1.TabIndex = 42;
            this.pieChart1.Text = "~";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkIncludeRevisions);
            this.groupBox2.Location = new System.Drawing.Point(232, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 471);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Estimating Breakdown";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(259, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quote Value by customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkIncludeRevisions
            // 
            this.chkIncludeRevisions.AutoSize = true;
            this.chkIncludeRevisions.Checked = true;
            this.chkIncludeRevisions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeRevisions.Location = new System.Drawing.Point(6, 19);
            this.chkIncludeRevisions.Name = "chkIncludeRevisions";
            this.chkIncludeRevisions.Size = new System.Drawing.Size(110, 17);
            this.chkIncludeRevisions.TabIndex = 9;
            this.chkIncludeRevisions.Text = "Include Revisions";
            this.chkIncludeRevisions.UseVisualStyleBackColor = true;
            // 
            // btnViewQuotes
            // 
            this.btnViewQuotes.Location = new System.Drawing.Point(15, 249);
            this.btnViewQuotes.Name = "btnViewQuotes";
            this.btnViewQuotes.Size = new System.Drawing.Size(200, 23);
            this.btnViewQuotes.TabIndex = 10;
            this.btnViewQuotes.Text = "View Quotations";
            this.btnViewQuotes.UseVisualStyleBackColor = true;
            this.btnViewQuotes.Click += new System.EventHandler(this.btnViewQuotes_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblSales);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(10, 292);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(216, 62);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "       Total Sales";
            // 
            // lblSales
            // 
            this.lblSales.Location = new System.Drawing.Point(6, 29);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(204, 27);
            this.lblSales.TabIndex = 0;
            this.lblSales.Text = "£0";
            this.lblSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(898, 501);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(877, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "Daily Chases";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart2.Location = new System.Drawing.Point(898, 525);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(865, 209);
            this.cartesianChart2.TabIndex = 46;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // chaseGague
            // 
            this.chaseGague.Location = new System.Drawing.Point(446, 267);
            this.chaseGague.Name = "chaseGague";
            this.chaseGague.Size = new System.Drawing.Size(193, 186);
            this.chaseGague.TabIndex = 35;
            this.chaseGague.Text = "~~~~~~~~~~~~";
            // 
            // lblChase
            // 
            this.lblChase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChase.Location = new System.Drawing.Point(442, 244);
            this.lblChase.Name = "lblChase";
            this.lblChase.Size = new System.Drawing.Size(197, 20);
            this.lblChase.TabIndex = 36;
            this.lblChase.Text = "Average Chases:";
            this.lblChase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSlimlineEstimatingProductivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1775, 752);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnViewQuotes);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.cmbStaffMember);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lateGuage);
            this.Controls.Add(this.annualLeaveGuage);
            this.Controls.Add(this.absentGuage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSlimlineEstimatingProductivity";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.AngularGauge unpaidGuage;
        private LiveCharts.WinForms.AngularGauge lateGuage;
        private LiveCharts.WinForms.AngularGauge annualLeaveGuage;
        private LiveCharts.WinForms.AngularGauge absentGuage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label absentDays;
        private System.Windows.Forms.Label annualLeave;
        private System.Windows.Forms.Label lateDays;
        private System.Windows.Forms.Label unpaidLeave;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.ComboBox cmbStaffMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runComparisonToolStripMenuItem;
        private System.Windows.Forms.Label lblDailyAverage;
        private LiveCharts.WinForms.AngularGauge dailyItemsGuage;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label label4;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewQuotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIncludeRevisions;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Label label6;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private LiveCharts.WinForms.AngularGauge chaseGague;
        private System.Windows.Forms.Label lblChase;
    }
}