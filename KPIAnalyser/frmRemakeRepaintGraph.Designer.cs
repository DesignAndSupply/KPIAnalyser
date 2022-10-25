namespace KPIAnalyser
{
    partial class frmRemakeRepaintGraph
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
            this.repaintChart = new LiveCharts.WinForms.CartesianChart();
            this.remakeChart = new LiveCharts.WinForms.CartesianChart();
            this.lblRepaints = new System.Windows.Forms.Label();
            this.lblRemakes = new System.Windows.Forms.Label();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // repaintChart
            // 
            this.repaintChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repaintChart.Location = new System.Drawing.Point(12, 39);
            this.repaintChart.Name = "repaintChart";
            this.repaintChart.Size = new System.Drawing.Size(1439, 401);
            this.repaintChart.TabIndex = 3;
            this.repaintChart.Text = "cartesianChart4";
            this.repaintChart.DataClick += new LiveCharts.Events.DataClickHandler(this.repaintChart_DataClick);
            // 
            // remakeChart
            // 
            this.remakeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remakeChart.Location = new System.Drawing.Point(12, 498);
            this.remakeChart.Name = "remakeChart";
            this.remakeChart.Size = new System.Drawing.Size(1439, 486);
            this.remakeChart.TabIndex = 4;
            this.remakeChart.Text = "cartesianChart1";
            this.remakeChart.DataClick += new LiveCharts.Events.DataClickHandler(this.remakeChart_DataClick);
            // 
            // lblRepaints
            // 
            this.lblRepaints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRepaints.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblRepaints.Location = new System.Drawing.Point(12, 8);
            this.lblRepaints.Name = "lblRepaints";
            this.lblRepaints.Size = new System.Drawing.Size(1439, 28);
            this.lblRepaints.TabIndex = 5;
            this.lblRepaints.Text = "Department Repaints between XX/XX/XXXX  and XX/XX/XXXX";
            this.lblRepaints.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRemakes
            // 
            this.lblRemakes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblRemakes.Location = new System.Drawing.Point(12, 467);
            this.lblRemakes.Name = "lblRemakes";
            this.lblRemakes.Size = new System.Drawing.Size(1439, 28);
            this.lblRemakes.TabIndex = 6;
            this.lblRemakes.Text = "Department Repaints between XX/XX/XXXX  and XX/XX/XXXX";
            this.lblRemakes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnEmail.Location = new System.Drawing.Point(1357, 8);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(91, 28);
            this.btnEmail.TabIndex = 7;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnPrint.Location = new System.Drawing.Point(1260, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 28);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmRemakeRepaintGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 996);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.lblRemakes);
            this.Controls.Add(this.lblRepaints);
            this.Controls.Add(this.remakeChart);
            this.Controls.Add(this.repaintChart);
            this.Name = "frmRemakeRepaintGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remake Repaint Graph";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart repaintChart;
        private LiveCharts.WinForms.CartesianChart remakeChart;
        private System.Windows.Forms.Label lblRepaints;
        private System.Windows.Forms.Label lblRemakes;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnPrint;
    }
}