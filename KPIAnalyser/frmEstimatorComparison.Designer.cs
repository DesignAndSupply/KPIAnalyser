namespace KPIAnalyser
{
    partial class frmEstimatorComparison
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
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.cviewestimatorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userinfoDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet1 = new KPIAnalyser.user_infoDataSet1();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet = new KPIAnalyser.user_infoDataSet();
            this.c_view_sales_program_usersTableAdapter = new KPIAnalyser.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.dailyAverageItemsBar = new LiveCharts.Wpf.CartesianChart();
            this.label4 = new System.Windows.Forms.Label();
            this.absenseBar = new LiveCharts.WinForms.CartesianChart();
            this.label5 = new System.Windows.Forms.Label();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.latenessBar = new LiveCharts.Wpf.CartesianChart();
            this.label6 = new System.Windows.Forms.Label();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.problemsBar = new LiveCharts.Wpf.CartesianChart();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.c_view_estimatorsTableAdapter = new KPIAnalyser.user_infoDataSet1TableAdapters.c_view_estimatorsTableAdapter();
            this.overtimeChart = new LiveCharts.WinForms.CartesianChart();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cviewestimatorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lstStaff
            // 
            this.lstStaff.DataSource = this.cviewestimatorsBindingSource;
            this.lstStaff.DisplayMember = "fullname";
            this.lstStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.ItemHeight = 20;
            this.lstStaff.Location = new System.Drawing.Point(11, 122);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStaff.Size = new System.Drawing.Size(200, 244);
            this.lstStaff.TabIndex = 0;
            this.lstStaff.ValueMember = "id";
            // 
            // cviewestimatorsBindingSource
            // 
            this.cviewestimatorsBindingSource.DataMember = "c_view_estimators";
            this.cviewestimatorsBindingSource.DataSource = this.userinfoDataSet1BindingSource;
            // 
            // userinfoDataSet1BindingSource
            // 
            this.userinfoDataSet1BindingSource.DataSource = this.user_infoDataSet1;
            this.userinfoDataSet1BindingSource.Position = 0;
            // 
            // user_infoDataSet1
            // 
            this.user_infoDataSet1.DataSetName = "user_infoDataSet1";
            this.user_infoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Estimators:";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(11, 371);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(200, 23);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Start Date:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(11, 69);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 7;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(11, 25);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 6;
            // 
            // elementHost1
            // 
            this.elementHost1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.elementHost1.Location = new System.Drawing.Point(221, 27);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(792, 463);
            this.elementHost1.TabIndex = 10;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.dailyAverageItemsBar;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(792, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "AVERAGE ITEMS QUOTED DAILY DURING PERIOD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // absenseBar
            // 
            this.absenseBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.absenseBar.Location = new System.Drawing.Point(1039, 27);
            this.absenseBar.Name = "absenseBar";
            this.absenseBar.Size = new System.Drawing.Size(792, 463);
            this.absenseBar.TabIndex = 12;
            this.absenseBar.Text = "cartesianChart1";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1039, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(792, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "ABSENT DAYS DURING PERIOD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elementHost2
            // 
            this.elementHost2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.elementHost2.Location = new System.Drawing.Point(217, 548);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(536, 463);
            this.elementHost2.TabIndex = 14;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.latenessBar;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(217, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(536, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "LATE DAYS DURING PERIOD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // elementHost3
            // 
            this.elementHost3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.elementHost3.Location = new System.Drawing.Point(764, 552);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(536, 463);
            this.elementHost3.TabIndex = 16;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.problemsBar;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(764, 529);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(536, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "ISSUES LOGGED BY PROGRAMMERS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(11, 400);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 23);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print Screen";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Email Screen:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // c_view_estimatorsTableAdapter
            // 
            this.c_view_estimatorsTableAdapter.ClearBeforeFill = true;
            // 
            // overtimeChart
            // 
            this.overtimeChart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.overtimeChart.Location = new System.Drawing.Point(1310, 552);
            this.overtimeChart.Name = "overtimeChart";
            this.overtimeChart.Size = new System.Drawing.Size(536, 463);
            this.overtimeChart.TabIndex = 20;
            this.overtimeChart.Text = "cartesianChart1";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1310, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(536, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Overtime";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEstimatorComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1861, 1017);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.overtimeChart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.absenseBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstStaff);
            this.Name = "frmEstimatorComparison";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEstimatorComparison_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cviewestimatorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstStaff;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Label label4;
        private LiveCharts.WinForms.CartesianChart absenseBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource userinfoDataSet1BindingSource;
        private user_infoDataSet1 user_infoDataSet1;
        private System.Windows.Forms.BindingSource cviewestimatorsBindingSource;
        private user_infoDataSet1TableAdapters.c_view_estimatorsTableAdapter c_view_estimatorsTableAdapter;
        private LiveCharts.Wpf.CartesianChart latenessBar;
        private LiveCharts.Wpf.CartesianChart problemsBar;
        private LiveCharts.WinForms.CartesianChart overtimeChart;
        private System.Windows.Forms.Label label8;
        private LiveCharts.Wpf.CartesianChart dailyAverageItemsBar;
    }
}