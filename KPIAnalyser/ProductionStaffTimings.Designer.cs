namespace KPIAnalyser
{
    partial class ProductionStaffTimings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionStaffTimings));
            this.dgStaffTimings = new System.Windows.Forms.DataGridView();
            this.cmbStaffSelect = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaffTimings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgStaffTimings
            // 
            this.dgStaffTimings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStaffTimings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStaffTimings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStaffTimings.Location = new System.Drawing.Point(13, 38);
            this.dgStaffTimings.Name = "dgStaffTimings";
            this.dgStaffTimings.RowHeadersVisible = false;
            this.dgStaffTimings.Size = new System.Drawing.Size(563, 328);
            this.dgStaffTimings.TabIndex = 0;
            // 
            // cmbStaffSelect
            // 
            this.cmbStaffSelect.FormattingEnabled = true;
            this.cmbStaffSelect.Location = new System.Drawing.Point(13, 11);
            this.cmbStaffSelect.Name = "cmbStaffSelect";
            this.cmbStaffSelect.Size = new System.Drawing.Size(242, 21);
            this.cmbStaffSelect.TabIndex = 1;
            this.cmbStaffSelect.SelectedIndexChanged += new System.EventHandler(this.cmbStaffSelect_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(262, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ProductionStaffTimings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 378);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbStaffSelect);
            this.Controls.Add(this.dgStaffTimings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductionStaffTimings";
            this.Text = "Staff Breakdown";
            this.Load += new System.EventHandler(this.ProductionStaffTimings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStaffTimings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStaffTimings;
        private System.Windows.Forms.ComboBox cmbStaffSelect;
        private System.Windows.Forms.Button btnRefresh;
    }
}