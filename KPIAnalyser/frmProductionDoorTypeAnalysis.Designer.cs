namespace KPIAnalyser
{
    partial class frmProductionDoorTypeAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionDoorTypeAnalysis));
            this.dgvDoorTypeBreakdown = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorTypeBreakdown)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoorTypeBreakdown
            // 
            this.dgvDoorTypeBreakdown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoorTypeBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoorTypeBreakdown.Location = new System.Drawing.Point(13, 13);
            this.dgvDoorTypeBreakdown.Name = "dgvDoorTypeBreakdown";
            this.dgvDoorTypeBreakdown.RowHeadersVisible = false;
            this.dgvDoorTypeBreakdown.Size = new System.Drawing.Size(950, 531);
            this.dgvDoorTypeBreakdown.TabIndex = 0;
            // 
            // frmProductionDoorTypeAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 556);
            this.Controls.Add(this.dgvDoorTypeBreakdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductionDoorTypeAnalysis";
            this.Text = "Door Type Analysis:";
            this.Load += new System.EventHandler(this.FrmProductionDoorTypeAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorTypeBreakdown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoorTypeBreakdown;
    }
}