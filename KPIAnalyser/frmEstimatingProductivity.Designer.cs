namespace KPIAnalyser
{
    partial class frmEstimatingProductivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstimatingProductivity));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStaffMember = new System.Windows.Forms.ComboBox();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new KPIAnalyser.user_infoDataSet();
            this.c_view_sales_program_usersTableAdapter = new KPIAnalyser.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.c_view_sales_program_usersTableAdapter1 = new KPIAnalyser.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.chkIncludeRevisions = new System.Windows.Forms.CheckBox();
            this.absentGuage = new LiveCharts.WinForms.AngularGauge();
            this.annualLeaveGuage = new LiveCharts.WinForms.AngularGauge();
            this.lateGuage = new LiveCharts.WinForms.AngularGauge();
            this.unpaidGuage = new LiveCharts.WinForms.AngularGauge();
            this.absentDays = new System.Windows.Forms.Label();
            this.annualLeave = new System.Windows.Forms.Label();
            this.lateDays = new System.Windows.Forms.Label();
            this.unpaidLeave = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dailyItemsGuage = new LiveCharts.WinForms.AngularGauge();
            this.lblDailyAverage = new System.Windows.Forms.Label();
            this.problemsGuage = new LiveCharts.WinForms.AngularGauge();
            this.lblEstimatorissues = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewQuotes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Staff Member:";
            // 
            // cmbStaffMember
            // 
            this.cmbStaffMember.DataSource = this.cviewsalesprogramusersBindingSource;
            this.cmbStaffMember.DisplayMember = "fullname";
            this.cmbStaffMember.FormattingEnabled = true;
            this.cmbStaffMember.Location = new System.Drawing.Point(12, 49);
            this.cmbStaffMember.Name = "cmbStaffMember";
            this.cmbStaffMember.Size = new System.Drawing.Size(200, 21);
            this.cmbStaffMember.TabIndex = 1;
            this.cmbStaffMember.ValueMember = "id";
            // 
            // cviewsalesprogramusersBindingSource
            // 
            this.cviewsalesprogramusersBindingSource.DataMember = "c_view_sales_program_users";
            this.cviewsalesprogramusersBindingSource.DataSource = this.user_infoDataSet;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c_view_sales_program_usersTableAdapter
            // 
            this.c_view_sales_program_usersTableAdapter.ClearBeforeFill = true;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(12, 90);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 2;
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(12, 134);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Date:";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(271, 311);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(373, 337);
            this.pieChart1.TabIndex = 6;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 160);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Refresh";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // c_view_sales_program_usersTableAdapter1
            // 
            this.c_view_sales_program_usersTableAdapter1.ClearBeforeFill = true;
            // 
            // pieChart2
            // 
            this.pieChart2.Location = new System.Drawing.Point(662, 311);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(380, 337);
            this.pieChart2.TabIndex = 8;
            this.pieChart2.Text = "pieChart2";
            // 
            // chkIncludeRevisions
            // 
            this.chkIncludeRevisions.AutoSize = true;
            this.chkIncludeRevisions.Location = new System.Drawing.Point(6, 19);
            this.chkIncludeRevisions.Name = "chkIncludeRevisions";
            this.chkIncludeRevisions.Size = new System.Drawing.Size(110, 17);
            this.chkIncludeRevisions.TabIndex = 9;
            this.chkIncludeRevisions.Text = "Include Revisions";
            this.chkIncludeRevisions.UseVisualStyleBackColor = true;
            // 
            // absentGuage
            // 
            this.absentGuage.Location = new System.Drawing.Point(271, 75);
            this.absentGuage.Name = "absentGuage";
            this.absentGuage.Size = new System.Drawing.Size(157, 146);
            this.absentGuage.TabIndex = 10;
            this.absentGuage.Text = "angularGauge1";
            // 
            // annualLeaveGuage
            // 
            this.annualLeaveGuage.Location = new System.Drawing.Point(455, 75);
            this.annualLeaveGuage.Name = "annualLeaveGuage";
            this.annualLeaveGuage.Size = new System.Drawing.Size(157, 146);
            this.annualLeaveGuage.TabIndex = 11;
            this.annualLeaveGuage.Text = "angularGauge1";
            // 
            // lateGuage
            // 
            this.lateGuage.Location = new System.Drawing.Point(662, 75);
            this.lateGuage.Name = "lateGuage";
            this.lateGuage.Size = new System.Drawing.Size(157, 146);
            this.lateGuage.TabIndex = 13;
            this.lateGuage.Text = "angularGauge2";
            // 
            // unpaidGuage
            // 
            this.unpaidGuage.Location = new System.Drawing.Point(870, 75);
            this.unpaidGuage.Name = "unpaidGuage";
            this.unpaidGuage.Size = new System.Drawing.Size(157, 146);
            this.unpaidGuage.TabIndex = 14;
            this.unpaidGuage.Text = "angularGauge3";
            // 
            // absentDays
            // 
            this.absentDays.AutoSize = true;
            this.absentDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.absentDays.Location = new System.Drawing.Point(40, 25);
            this.absentDays.Name = "absentDays";
            this.absentDays.Size = new System.Drawing.Size(104, 20);
            this.absentDays.TabIndex = 15;
            this.absentDays.Text = "Absent Days:";
            // 
            // annualLeave
            // 
            this.annualLeave.AutoSize = true;
            this.annualLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annualLeave.Location = new System.Drawing.Point(220, 25);
            this.annualLeave.Name = "annualLeave";
            this.annualLeave.Size = new System.Drawing.Size(110, 20);
            this.annualLeave.TabIndex = 16;
            this.annualLeave.Text = "Annual Leave:";
            // 
            // lateDays
            // 
            this.lateDays.AutoSize = true;
            this.lateDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lateDays.Location = new System.Drawing.Point(447, 25);
            this.lateDays.Name = "lateDays";
            this.lateDays.Size = new System.Drawing.Size(85, 20);
            this.lateDays.TabIndex = 17;
            this.lateDays.Text = "Late Days:";
            // 
            // unpaidLeave
            // 
            this.unpaidLeave.AutoSize = true;
            this.unpaidLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpaidLeave.Location = new System.Drawing.Point(638, 23);
            this.unpaidLeave.Name = "unpaidLeave";
            this.unpaidLeave.Size = new System.Drawing.Size(111, 20);
            this.unpaidLeave.TabIndex = 18;
            this.unpaidLeave.Text = "Unpaid Leave:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.absentDays);
            this.groupBox1.Controls.Add(this.annualLeave);
            this.groupBox1.Controls.Add(this.lateDays);
            this.groupBox1.Controls.Add(this.unpaidLeave);
            this.groupBox1.Location = new System.Drawing.Point(243, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 210);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attendance";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewQuotes);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkIncludeRevisions);
            this.groupBox2.Location = new System.Drawing.Point(243, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 471);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Estimating Breakdown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quote Value by customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Item count by customer";
            // 
            // dailyItemsGuage
            // 
            this.dailyItemsGuage.Location = new System.Drawing.Point(12, 243);
            this.dailyItemsGuage.Name = "dailyItemsGuage";
            this.dailyItemsGuage.Size = new System.Drawing.Size(217, 113);
            this.dailyItemsGuage.TabIndex = 21;
            this.dailyItemsGuage.Text = "angularGauge1";
            // 
            // lblDailyAverage
            // 
            this.lblDailyAverage.AutoSize = true;
            this.lblDailyAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyAverage.Location = new System.Drawing.Point(31, 220);
            this.lblDailyAverage.Name = "lblDailyAverage";
            this.lblDailyAverage.Size = new System.Drawing.Size(154, 20);
            this.lblDailyAverage.TabIndex = 22;
            this.lblDailyAverage.Text = "Daily Average Items:";
            // 
            // problemsGuage
            // 
            this.problemsGuage.Location = new System.Drawing.Point(12, 437);
            this.problemsGuage.Name = "problemsGuage";
            this.problemsGuage.Size = new System.Drawing.Size(217, 113);
            this.problemsGuage.TabIndex = 23;
            this.problemsGuage.Text = "angularGauge1";
            // 
            // lblEstimatorissues
            // 
            this.lblEstimatorissues.AutoSize = true;
            this.lblEstimatorissues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatorissues.Location = new System.Drawing.Point(50, 414);
            this.lblEstimatorissues.Name = "lblEstimatorissues";
            this.lblEstimatorissues.Size = new System.Drawing.Size(112, 20);
            this.lblEstimatorissues.TabIndex = 24;
            this.lblEstimatorissues.Text = "Issues logged:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runComparisonToolStripMenuItem,
            this.printScreenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runComparisonToolStripMenuItem
            // 
            this.runComparisonToolStripMenuItem.Name = "runComparisonToolStripMenuItem";
            this.runComparisonToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.runComparisonToolStripMenuItem.Text = "Run Comparison";
            this.runComparisonToolStripMenuItem.Click += new System.EventHandler(this.RunComparisonToolStripMenuItem_Click);
            // 
            // printScreenToolStripMenuItem
            // 
            this.printScreenToolStripMenuItem.Name = "printScreenToolStripMenuItem";
            this.printScreenToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.printScreenToolStripMenuItem.Text = "Print Screen";
            this.printScreenToolStripMenuItem.Click += new System.EventHandler(this.PrintScreenToolStripMenuItem_Click);
            // 
            // btnViewQuotes
            // 
            this.btnViewQuotes.Location = new System.Drawing.Point(28, 421);
            this.btnViewQuotes.Name = "btnViewQuotes";
            this.btnViewQuotes.Size = new System.Drawing.Size(771, 23);
            this.btnViewQuotes.TabIndex = 10;
            this.btnViewQuotes.Text = "View Quotations";
            this.btnViewQuotes.UseVisualStyleBackColor = true;
            this.btnViewQuotes.Click += new System.EventHandler(this.BtnViewQuotes_Click);
            // 
            // frmEstimatingProductivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 735);
            this.Controls.Add(this.lblEstimatorissues);
            this.Controls.Add(this.problemsGuage);
            this.Controls.Add(this.lblDailyAverage);
            this.Controls.Add(this.dailyItemsGuage);
            this.Controls.Add(this.unpaidGuage);
            this.Controls.Add(this.lateGuage);
            this.Controls.Add(this.annualLeaveGuage);
            this.Controls.Add(this.absentGuage);
            this.Controls.Add(this.pieChart2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.cmbStaffMember);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEstimatingProductivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Staff Productivity";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEstimatingProductivity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStaffMember;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button btnGenerate;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter1;
        private LiveCharts.WinForms.PieChart pieChart2;
        private System.Windows.Forms.CheckBox chkIncludeRevisions;
        private LiveCharts.WinForms.AngularGauge absentGuage;
        private LiveCharts.WinForms.AngularGauge annualLeaveGuage;
        private LiveCharts.WinForms.AngularGauge lateGuage;
        private LiveCharts.WinForms.AngularGauge unpaidGuage;
        private System.Windows.Forms.Label absentDays;
        private System.Windows.Forms.Label annualLeave;
        private System.Windows.Forms.Label lateDays;
        private System.Windows.Forms.Label unpaidLeave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private LiveCharts.WinForms.AngularGauge dailyItemsGuage;
        private System.Windows.Forms.Label lblDailyAverage;
        private LiveCharts.WinForms.AngularGauge problemsGuage;
        private System.Windows.Forms.Label lblEstimatorissues;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printScreenToolStripMenuItem;
        private System.Windows.Forms.Button btnViewQuotes;
    }
}