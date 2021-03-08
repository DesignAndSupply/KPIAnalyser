namespace KPIAnalyser
{
    partial class frmViewQuotationItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewQuotationItems));
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbDoorType = new System.Windows.Forms.ComboBox();
            this.viewsolidworksquoteddoortypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_databaseDataSet = new KPIAnalyser.order_databaseDataSet();
            this.user_infoDataSet = new KPIAnalyser.user_infoDataSet();
            this.userinfoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_solidworks_quoted_door_typesTableAdapter = new KPIAnalyser.order_databaseDataSetTableAdapters.view_solidworks_quoted_door_typesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEmailItem = new System.Windows.Forms.Button();
            this.lblDoorTypes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewsolidworksquoteddoortypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(12, 35);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(57, 20);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "label1";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(12, 62);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(57, 20);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "label1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1110, 456);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick_1);
            // 
            // btnEmail
            // 
            this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmail.Location = new System.Drawing.Point(993, 38);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(129, 23);
            this.btnEmail.TabIndex = 9;
            this.btnEmail.Text = "Email List";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(993, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print Screen";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // cmbDoorType
            // 
            this.cmbDoorType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDoorType.DataSource = this.viewsolidworksquoteddoortypesBindingSource;
            this.cmbDoorType.DisplayMember = "DoorType";
            this.cmbDoorType.FormattingEnabled = true;
            this.cmbDoorType.Location = new System.Drawing.Point(826, 95);
            this.cmbDoorType.Name = "cmbDoorType";
            this.cmbDoorType.Size = new System.Drawing.Size(296, 21);
            this.cmbDoorType.TabIndex = 10;
            this.cmbDoorType.ValueMember = "DoorType";
            this.cmbDoorType.Visible = false;
            this.cmbDoorType.SelectedIndexChanged += new System.EventHandler(this.CmbDoorType_SelectedIndexChanged);
            this.cmbDoorType.SelectedValueChanged += new System.EventHandler(this.CmbDoorType_SelectedValueChanged);
            // 
            // viewsolidworksquoteddoortypesBindingSource
            // 
            this.viewsolidworksquoteddoortypesBindingSource.DataMember = "view_solidworks_quoted_door_types";
            this.viewsolidworksquoteddoortypesBindingSource.DataSource = this.order_databaseDataSet;
            // 
            // order_databaseDataSet
            // 
            this.order_databaseDataSet.DataSetName = "order_databaseDataSet";
            this.order_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // user_infoDataSet
            // 
            this.user_infoDataSet.DataSetName = "user_infoDataSet";
            this.user_infoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userinfoDataSetBindingSource
            // 
            this.userinfoDataSetBindingSource.DataSource = this.user_infoDataSet;
            this.userinfoDataSetBindingSource.Position = 0;
            // 
            // view_solidworks_quoted_door_typesTableAdapter
            // 
            this.view_solidworks_quoted_door_typesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filter Door Type";
            this.label1.Visible = false;
            // 
            // btnEmailItem
            // 
            this.btnEmailItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailItem.Location = new System.Drawing.Point(993, 66);
            this.btnEmailItem.Name = "btnEmailItem";
            this.btnEmailItem.Size = new System.Drawing.Size(129, 23);
            this.btnEmailItem.TabIndex = 12;
            this.btnEmailItem.Text = "Email Selected Item:";
            this.btnEmailItem.UseVisualStyleBackColor = true;
            this.btnEmailItem.Click += new System.EventHandler(this.BtnEmailItem_Click);
            // 
            // lblDoorTypes
            // 
            this.lblDoorTypes.AutoSize = true;
            this.lblDoorTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoorTypes.Location = new System.Drawing.Point(12, 86);
            this.lblDoorTypes.Name = "lblDoorTypes";
            this.lblDoorTypes.Size = new System.Drawing.Size(57, 20);
            this.lblDoorTypes.TabIndex = 13;
            this.lblDoorTypes.Text = "label1";
            // 
            // frmViewQuotationItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 590);
            this.Controls.Add(this.lblDoorTypes);
            this.Controls.Add(this.btnEmailItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDoorType);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewQuotationItems";
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.FrmViewQuotationItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewsolidworksquoteddoortypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_infoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userinfoDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbDoorType;
        private System.Windows.Forms.BindingSource userinfoDataSetBindingSource;
        private user_infoDataSet user_infoDataSet;
        private order_databaseDataSet order_databaseDataSet;
        private System.Windows.Forms.BindingSource viewsolidworksquoteddoortypesBindingSource;
        private order_databaseDataSetTableAdapters.view_solidworks_quoted_door_typesTableAdapter view_solidworks_quoted_door_typesTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmailItem;
        private System.Windows.Forms.Label lblDoorTypes;
    }
}