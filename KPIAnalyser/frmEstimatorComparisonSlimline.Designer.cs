namespace KPIAnalyser
{
    partial class frmEstimatorComparisonSlimline
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
            this.label8 = new System.Windows.Forms.Label();
            this.c_view_estimatorsTableAdapter = new KPIAnalyser.user_infoDataSet1TableAdapters.c_view_estimatorsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.overtimeChart = new LiveCharts.WinForms.CartesianChart();
            this.label5 = new System.Windows.Forms.Label();
            this.absenseBar = new LiveCharts.WinForms.CartesianChart();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c_view_sales_program_usersTableAdapter = new KPIAnalyser.user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter();
            this.user_infoDataSet = new KPIAnalyser.user_infoDataSet();
            this.cviewsalesprogramusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_infoDataSet1 = new KPIAnalyser.user_infoDataSet1();
            this.userinfoDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cviewestimatorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.dailyAverageItemsBar = new LiveCharts.WinForms.CartesianChart();
            this.latenessBar = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewestimatorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1042, 528);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(792, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Overtime";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c_view_estimatorsTableAdapter
            // 
            this.c_view_estimatorsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Email Screen:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(14, 399);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(200, 23);
            this.btnPrint.TabIndex = 37;
            this.btnPrint.Text = "Print Screen";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(792, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "LATE DAYS DURING PERIOD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // overtimeChart
            // 
            this.overtimeChart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.overtimeChart.Location = new System.Drawing.Point(1042, 551);
            this.overtimeChart.Name = "overtimeChart";
            this.overtimeChart.Size = new System.Drawing.Size(792, 463);
            this.overtimeChart.TabIndex = 39;
            this.overtimeChart.Text = "cartesianChart1";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1042, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(792, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "ABSENT DAYS DURING PERIOD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // absenseBar
            // 
            this.absenseBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.absenseBar.Location = new System.Drawing.Point(1042, 26);
            this.absenseBar.Name = "absenseBar";
            this.absenseBar.Size = new System.Drawing.Size(792, 463);
            this.absenseBar.TabIndex = 31;
            this.absenseBar.Text = "cartesianChart1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(788, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "AVERAGE ITEMS QUOTED DAILY DURING PERIOD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Start Date:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(14, 68);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 26;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(14, 24);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 25;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(14, 370);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(200, 23);
            this.btnCompare.TabIndex = 24;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Select Estimators:";
            // 
            // c_view_sales_program_usersTableAdapter
            // 
            this.c_view_sales_program_usersTableAdapter.ClearBeforeFill = true;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cviewsalesprogramusersBindingSource
            // 
            this.cviewsalesprogramusersBindingSource.DataMember = "c_view_sales_program_users";
            this.cviewsalesprogramusersBindingSource.DataSource = this.user_infoDataSet;
            // 
            // user_infoDataSet1
            // 
            this.user_infoDataSet1.DataSetName = "user_infoDataSet1";
            this.user_infoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userinfoDataSet1BindingSource
            // 
            this.userinfoDataSet1BindingSource.DataSource = this.user_infoDataSet1;
            this.userinfoDataSet1BindingSource.Position = 0;
            // 
            // cviewestimatorsBindingSource
            // 
            this.cviewestimatorsBindingSource.DataMember = "c_view_estimators";
            this.cviewestimatorsBindingSource.DataSource = this.userinfoDataSet1BindingSource;
            // 
            // lstStaff
            // 
            this.lstStaff.DisplayMember = "id";
            this.lstStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.ItemHeight = 20;
            this.lstStaff.Location = new System.Drawing.Point(14, 121);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStaff.Size = new System.Drawing.Size(200, 244);
            this.lstStaff.TabIndex = 22;
            this.lstStaff.ValueMember = "id";
            // 
            // dailyAverageItemsBar
            // 
            this.dailyAverageItemsBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dailyAverageItemsBar.Location = new System.Drawing.Point(228, 26);
            this.dailyAverageItemsBar.Name = "dailyAverageItemsBar";
            this.dailyAverageItemsBar.Size = new System.Drawing.Size(792, 463);
            this.dailyAverageItemsBar.TabIndex = 41;
            this.dailyAverageItemsBar.Text = "cartesianChart1";
            // 
            // latenessBar
            // 
            this.latenessBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.latenessBar.Location = new System.Drawing.Point(228, 551);
            this.latenessBar.Name = "latenessBar";
            this.latenessBar.Size = new System.Drawing.Size(792, 463);
            this.latenessBar.TabIndex = 42;
            this.latenessBar.Text = "cartesianChart1";
            // 
            // frmEstimatorComparisonSlimline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1861, 1017);
            this.Controls.Add(this.latenessBar);
            this.Controls.Add(this.dailyAverageItemsBar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.overtimeChart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.absenseBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstStaff);
            this.Name = "frmEstimatorComparisonSlimline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estimator Comparison Slimline";
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewsalesprogramusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cviewestimatorsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private user_infoDataSet1TableAdapters.c_view_estimatorsTableAdapter c_view_estimatorsTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label6;
        private LiveCharts.WinForms.CartesianChart overtimeChart;
        private System.Windows.Forms.Label label5;
        private LiveCharts.WinForms.CartesianChart absenseBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label1;
        private user_infoDataSetTableAdapters.c_view_sales_program_usersTableAdapter c_view_sales_program_usersTableAdapter;
        private user_infoDataSet user_infoDataSet;
        private System.Windows.Forms.BindingSource cviewsalesprogramusersBindingSource;
        private user_infoDataSet1 user_infoDataSet1;
        private System.Windows.Forms.BindingSource userinfoDataSet1BindingSource;
        private System.Windows.Forms.BindingSource cviewestimatorsBindingSource;
        private System.Windows.Forms.ListBox lstStaff;
        private LiveCharts.WinForms.CartesianChart dailyAverageItemsBar;
        private LiveCharts.WinForms.CartesianChart latenessBar;
    }
}