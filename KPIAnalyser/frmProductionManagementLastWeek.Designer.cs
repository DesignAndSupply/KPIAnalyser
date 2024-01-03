namespace KPIAnalyser
{
    partial class frmProductionManagementLastWeek
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
            this.completedOnTime = new LiveCharts.WinForms.CartesianChart();
            this.remakeRepaintValue = new LiveCharts.WinForms.CartesianChart();
            this.absenteeism = new LiveCharts.WinForms.CartesianChart();
            this.Repaints = new LiveCharts.WinForms.CartesianChart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // completedOnTime
            // 
            this.completedOnTime.Location = new System.Drawing.Point(12, 37);
            this.completedOnTime.Name = "completedOnTime";
            this.completedOnTime.Size = new System.Drawing.Size(910, 450);
            this.completedOnTime.TabIndex = 3;
            this.completedOnTime.Text = "cartesianChart4";
            this.completedOnTime.DataClick += new LiveCharts.Events.DataClickHandler(this.completedOnTime_DataClick);
            // 
            // remakeRepaintValue
            // 
            this.remakeRepaintValue.Location = new System.Drawing.Point(938, 519);
            this.remakeRepaintValue.Name = "remakeRepaintValue";
            this.remakeRepaintValue.Size = new System.Drawing.Size(910, 450);
            this.remakeRepaintValue.TabIndex = 4;
            this.remakeRepaintValue.Text = "cartesianChart1";
            this.remakeRepaintValue.DataClick += new LiveCharts.Events.DataClickHandler(this.remakeRepaintValue_DataClick);
            // 
            // absenteeism
            // 
            this.absenteeism.Location = new System.Drawing.Point(938, 37);
            this.absenteeism.Name = "absenteeism";
            this.absenteeism.Size = new System.Drawing.Size(910, 450);
            this.absenteeism.TabIndex = 6;
            this.absenteeism.Text = "cartesianChart2";
            this.absenteeism.DataClick += new LiveCharts.Events.DataClickHandler(this.absenteeism_DataClick);
            // 
            // Repaints
            // 
            this.Repaints.Location = new System.Drawing.Point(12, 519);
            this.Repaints.Name = "Repaints";
            this.Repaints.Size = new System.Drawing.Size(910, 450);
            this.Repaints.TabIndex = 5;
            this.Repaints.Text = "cartesianChart3";
            this.Repaints.DataClick += new LiveCharts.Events.DataClickHandler(this.Repaints_DataClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(12, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(910, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Repaints";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(910, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Completed on Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(938, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(910, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Absenteeism";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(938, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(910, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Remake / Repaint Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmProductionManagementLastWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1860, 981);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.absenteeism);
            this.Controls.Add(this.Repaints);
            this.Controls.Add(this.remakeRepaintValue);
            this.Controls.Add(this.completedOnTime);
            this.Name = "frmProductionManagementLastWeek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Management";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart completedOnTime;
        private LiveCharts.WinForms.CartesianChart remakeRepaintValue;
        private LiveCharts.WinForms.CartesianChart absenteeism;
        private LiveCharts.WinForms.CartesianChart Repaints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}