namespace KPIAnalyser
{
    partial class frmInstallationProductivity
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.salesCostsChart = new LiveCharts.WinForms.CartesianChart();
            this.internalReturnGuage = new LiveCharts.WinForms.AngularGauge();
            this.externalReturnGuage = new LiveCharts.WinForms.AngularGauge();
            this.lblInternalCount = new System.Windows.Forms.Label();
            this.lblExternalCount = new System.Windows.Forms.Label();
            this.lblInternalCost = new System.Windows.Forms.Label();
            this.internalReturnCostGuage = new LiveCharts.WinForms.AngularGauge();
            this.externalReturnCostGuage = new LiveCharts.WinForms.AngularGauge();
            this.lblExternalCost = new System.Windows.Forms.Label();
            this.btnInternalVisit = new System.Windows.Forms.Button();
            this.btnExternal = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInternalVisitSL = new System.Windows.Forms.Button();
            this.lblInternalCountSL = new System.Windows.Forms.Label();
            this.internalReturnGuageSL = new LiveCharts.WinForms.AngularGauge();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExternalSL = new System.Windows.Forms.Button();
            this.lblExternalCostSL = new System.Windows.Forms.Label();
            this.externalReturnCostGuageSL = new LiveCharts.WinForms.AngularGauge();
            this.lblInternalCostSL = new System.Windows.Forms.Label();
            this.internalReturnCostGuageSL = new LiveCharts.WinForms.AngularGauge();
            this.lblExternalCountSL = new System.Windows.Forms.Label();
            this.externalReturnGuageSL = new LiveCharts.WinForms.AngularGauge();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.complaintGuage = new LiveCharts.WinForms.AngularGauge();
            this.btnComplaintView = new System.Windows.Forms.Button();
            this.lblComplaintCount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblComplaintCountSL = new System.Windows.Forms.Label();
            this.btnComplaintViewSL = new System.Windows.Forms.Button();
            this.complaintGuageSlimline = new LiveCharts.WinForms.AngularGauge();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 95);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Refresh";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date:";
            // 
            // dteEnd
            // 
            this.dteEnd.Location = new System.Drawing.Point(15, 69);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(200, 20);
            this.dteEnd.TabIndex = 9;
            // 
            // dteStart
            // 
            this.dteStart.Location = new System.Drawing.Point(15, 25);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(200, 20);
            this.dteStart.TabIndex = 8;
            // 
            // salesCostsChart
            // 
            this.salesCostsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.salesCostsChart.Location = new System.Drawing.Point(240, 622);
            this.salesCostsChart.Name = "salesCostsChart";
            this.salesCostsChart.Size = new System.Drawing.Size(1580, 144);
            this.salesCostsChart.TabIndex = 13;
            this.salesCostsChart.Text = "cartesianChart1";
            // 
            // internalReturnGuage
            // 
            this.internalReturnGuage.Location = new System.Drawing.Point(244, 60);
            this.internalReturnGuage.Name = "internalReturnGuage";
            this.internalReturnGuage.Size = new System.Drawing.Size(268, 214);
            this.internalReturnGuage.TabIndex = 14;
            this.internalReturnGuage.Text = "angularGauge1";
            // 
            // externalReturnGuage
            // 
            this.externalReturnGuage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.externalReturnGuage.Location = new System.Drawing.Point(631, 48);
            this.externalReturnGuage.Name = "externalReturnGuage";
            this.externalReturnGuage.Size = new System.Drawing.Size(260, 212);
            this.externalReturnGuage.TabIndex = 15;
            this.externalReturnGuage.Text = "angularGauge1";
            // 
            // lblInternalCount
            // 
            this.lblInternalCount.AutoSize = true;
            this.lblInternalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalCount.Location = new System.Drawing.Point(261, 37);
            this.lblInternalCount.Name = "lblInternalCount";
            this.lblInternalCount.Size = new System.Drawing.Size(175, 16);
            this.lblInternalCount.TabIndex = 16;
            this.lblInternalCount.Text = "Return Site Visits (Our Fault):";
            // 
            // lblExternalCount
            // 
            this.lblExternalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExternalCount.AutoSize = true;
            this.lblExternalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalCount.Location = new System.Drawing.Point(651, 18);
            this.lblExternalCount.Name = "lblExternalCount";
            this.lblExternalCount.Size = new System.Drawing.Size(202, 16);
            this.lblExternalCount.TabIndex = 17;
            this.lblExternalCount.Text = "Return Site Visits (External Fault):";
            // 
            // lblInternalCost
            // 
            this.lblInternalCost.AutoSize = true;
            this.lblInternalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalCost.Location = new System.Drawing.Point(303, 25);
            this.lblInternalCost.Name = "lblInternalCost";
            this.lblInternalCost.Size = new System.Drawing.Size(218, 16);
            this.lblInternalCost.TabIndex = 19;
            this.lblInternalCost.Text = "COST: Return Site Visits (Our Fault):";
            // 
            // internalReturnCostGuage
            // 
            this.internalReturnCostGuage.Location = new System.Drawing.Point(278, 48);
            this.internalReturnCostGuage.Name = "internalReturnCostGuage";
            this.internalReturnCostGuage.Size = new System.Drawing.Size(268, 214);
            this.internalReturnCostGuage.TabIndex = 18;
            this.internalReturnCostGuage.Text = "angularGauge1";
            // 
            // externalReturnCostGuage
            // 
            this.externalReturnCostGuage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.externalReturnCostGuage.Location = new System.Drawing.Point(886, 57);
            this.externalReturnCostGuage.Name = "externalReturnCostGuage";
            this.externalReturnCostGuage.Size = new System.Drawing.Size(268, 214);
            this.externalReturnCostGuage.TabIndex = 20;
            this.externalReturnCostGuage.Text = "angularGauge1";
            // 
            // lblExternalCost
            // 
            this.lblExternalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExternalCost.AutoSize = true;
            this.lblExternalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalCost.Location = new System.Drawing.Point(893, 18);
            this.lblExternalCost.Name = "lblExternalCost";
            this.lblExternalCost.Size = new System.Drawing.Size(245, 16);
            this.lblExternalCost.TabIndex = 21;
            this.lblExternalCost.Text = "COST: Return Site Visits (External Fault):";
            // 
            // btnInternalVisit
            // 
            this.btnInternalVisit.Location = new System.Drawing.Point(264, 280);
            this.btnInternalVisit.Name = "btnInternalVisit";
            this.btnInternalVisit.Size = new System.Drawing.Size(522, 23);
            this.btnInternalVisit.TabIndex = 22;
            this.btnInternalVisit.Text = "View";
            this.btnInternalVisit.UseVisualStyleBackColor = true;
            this.btnInternalVisit.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnExternal
            // 
            this.btnExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExternal.Location = new System.Drawing.Point(642, 268);
            this.btnExternal.Name = "btnExternal";
            this.btnExternal.Size = new System.Drawing.Size(522, 23);
            this.btnExternal.TabIndex = 23;
            this.btnExternal.Text = "View";
            this.btnExternal.UseVisualStyleBackColor = true;
            this.btnExternal.Click += new System.EventHandler(this.BtnExternal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnExternal);
            this.groupBox1.Controls.Add(this.lblExternalCost);
            this.groupBox1.Controls.Add(this.externalReturnCostGuage);
            this.groupBox1.Controls.Add(this.lblInternalCost);
            this.groupBox1.Controls.Add(this.internalReturnCostGuage);
            this.groupBox1.Controls.Add(this.lblExternalCount);
            this.groupBox1.Controls.Add(this.externalReturnGuage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(240, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 307);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRADITIONAL DOORS";
            // 
            // btnInternalVisitSL
            // 
            this.btnInternalVisitSL.Location = new System.Drawing.Point(264, 593);
            this.btnInternalVisitSL.Name = "btnInternalVisitSL";
            this.btnInternalVisitSL.Size = new System.Drawing.Size(522, 23);
            this.btnInternalVisitSL.TabIndex = 28;
            this.btnInternalVisitSL.Text = "View";
            this.btnInternalVisitSL.UseVisualStyleBackColor = true;
            this.btnInternalVisitSL.Click += new System.EventHandler(this.BtnInternalVisitSL_Click);
            // 
            // lblInternalCountSL
            // 
            this.lblInternalCountSL.AutoSize = true;
            this.lblInternalCountSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalCountSL.Location = new System.Drawing.Point(261, 350);
            this.lblInternalCountSL.Name = "lblInternalCountSL";
            this.lblInternalCountSL.Size = new System.Drawing.Size(175, 16);
            this.lblInternalCountSL.TabIndex = 27;
            this.lblInternalCountSL.Text = "Return Site Visits (Our Fault):";
            // 
            // internalReturnGuageSL
            // 
            this.internalReturnGuageSL.Location = new System.Drawing.Point(244, 373);
            this.internalReturnGuageSL.Name = "internalReturnGuageSL";
            this.internalReturnGuageSL.Size = new System.Drawing.Size(268, 214);
            this.internalReturnGuageSL.TabIndex = 26;
            this.internalReturnGuageSL.Text = "angularGauge1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExternalSL);
            this.groupBox2.Controls.Add(this.lblExternalCostSL);
            this.groupBox2.Controls.Add(this.externalReturnCostGuageSL);
            this.groupBox2.Controls.Add(this.lblInternalCostSL);
            this.groupBox2.Controls.Add(this.internalReturnCostGuageSL);
            this.groupBox2.Controls.Add(this.lblExternalCountSL);
            this.groupBox2.Controls.Add(this.externalReturnGuageSL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(240, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 307);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SLIMLINE  DOORS";
            // 
            // btnExternalSL
            // 
            this.btnExternalSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExternalSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExternalSL.Location = new System.Drawing.Point(642, 268);
            this.btnExternalSL.Name = "btnExternalSL";
            this.btnExternalSL.Size = new System.Drawing.Size(522, 23);
            this.btnExternalSL.TabIndex = 23;
            this.btnExternalSL.Text = "View";
            this.btnExternalSL.UseVisualStyleBackColor = true;
            this.btnExternalSL.Click += new System.EventHandler(this.BtnExternalSL_Click);
            // 
            // lblExternalCostSL
            // 
            this.lblExternalCostSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExternalCostSL.AutoSize = true;
            this.lblExternalCostSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalCostSL.Location = new System.Drawing.Point(893, 18);
            this.lblExternalCostSL.Name = "lblExternalCostSL";
            this.lblExternalCostSL.Size = new System.Drawing.Size(245, 16);
            this.lblExternalCostSL.TabIndex = 21;
            this.lblExternalCostSL.Text = "COST: Return Site Visits (External Fault):";
            // 
            // externalReturnCostGuageSL
            // 
            this.externalReturnCostGuageSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.externalReturnCostGuageSL.Location = new System.Drawing.Point(886, 50);
            this.externalReturnCostGuageSL.Name = "externalReturnCostGuageSL";
            this.externalReturnCostGuageSL.Size = new System.Drawing.Size(268, 214);
            this.externalReturnCostGuageSL.TabIndex = 20;
            this.externalReturnCostGuageSL.Text = "angularGauge1";
            // 
            // lblInternalCostSL
            // 
            this.lblInternalCostSL.AutoSize = true;
            this.lblInternalCostSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalCostSL.Location = new System.Drawing.Point(303, 25);
            this.lblInternalCostSL.Name = "lblInternalCostSL";
            this.lblInternalCostSL.Size = new System.Drawing.Size(218, 16);
            this.lblInternalCostSL.TabIndex = 19;
            this.lblInternalCostSL.Text = "COST: Return Site Visits (Our Fault):";
            // 
            // internalReturnCostGuageSL
            // 
            this.internalReturnCostGuageSL.Location = new System.Drawing.Point(278, 48);
            this.internalReturnCostGuageSL.Name = "internalReturnCostGuageSL";
            this.internalReturnCostGuageSL.Size = new System.Drawing.Size(268, 214);
            this.internalReturnCostGuageSL.TabIndex = 18;
            this.internalReturnCostGuageSL.Text = "angularGauge1";
            // 
            // lblExternalCountSL
            // 
            this.lblExternalCountSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExternalCountSL.AutoSize = true;
            this.lblExternalCountSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalCountSL.Location = new System.Drawing.Point(651, 18);
            this.lblExternalCountSL.Name = "lblExternalCountSL";
            this.lblExternalCountSL.Size = new System.Drawing.Size(202, 16);
            this.lblExternalCountSL.TabIndex = 17;
            this.lblExternalCountSL.Text = "Return Site Visits (External Fault):";
            // 
            // externalReturnGuageSL
            // 
            this.externalReturnGuageSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.externalReturnGuageSL.Location = new System.Drawing.Point(631, 51);
            this.externalReturnGuageSL.Name = "externalReturnGuageSL";
            this.externalReturnGuageSL.Size = new System.Drawing.Size(260, 212);
            this.externalReturnGuageSL.TabIndex = 15;
            this.externalReturnGuageSL.Text = "angularGauge1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblComplaintCount);
            this.groupBox3.Controls.Add(this.btnComplaintView);
            this.groupBox3.Controls.Add(this.complaintGuage);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1419, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 307);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Complaints (Traditional)";
            // 
            // complaintGuage
            // 
            this.complaintGuage.Location = new System.Drawing.Point(7, 48);
            this.complaintGuage.Name = "complaintGuage";
            this.complaintGuage.Size = new System.Drawing.Size(394, 214);
            this.complaintGuage.TabIndex = 0;
            this.complaintGuage.Text = "angularGauge1";
            // 
            // btnComplaintView
            // 
            this.btnComplaintView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplaintView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplaintView.Location = new System.Drawing.Point(7, 268);
            this.btnComplaintView.Name = "btnComplaintView";
            this.btnComplaintView.Size = new System.Drawing.Size(394, 23);
            this.btnComplaintView.TabIndex = 24;
            this.btnComplaintView.Text = "View";
            this.btnComplaintView.UseVisualStyleBackColor = true;
            this.btnComplaintView.Click += new System.EventHandler(this.BtnComplaintView_Click);
            // 
            // lblComplaintCount
            // 
            this.lblComplaintCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComplaintCount.AutoSize = true;
            this.lblComplaintCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplaintCount.Location = new System.Drawing.Point(120, 29);
            this.lblComplaintCount.Name = "lblComplaintCount";
            this.lblComplaintCount.Size = new System.Drawing.Size(141, 16);
            this.lblComplaintCount.TabIndex = 24;
            this.lblComplaintCount.Text = "Number of complaints:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblComplaintCountSL);
            this.groupBox4.Controls.Add(this.btnComplaintViewSL);
            this.groupBox4.Controls.Add(this.complaintGuageSlimline);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(1419, 325);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(411, 307);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Complaints (Slimline)";
            // 
            // lblComplaintCountSL
            // 
            this.lblComplaintCountSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComplaintCountSL.AutoSize = true;
            this.lblComplaintCountSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplaintCountSL.Location = new System.Drawing.Point(120, 29);
            this.lblComplaintCountSL.Name = "lblComplaintCountSL";
            this.lblComplaintCountSL.Size = new System.Drawing.Size(141, 16);
            this.lblComplaintCountSL.TabIndex = 24;
            this.lblComplaintCountSL.Text = "Number of complaints:";
            // 
            // btnComplaintViewSL
            // 
            this.btnComplaintViewSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplaintViewSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplaintViewSL.Location = new System.Drawing.Point(7, 268);
            this.btnComplaintViewSL.Name = "btnComplaintViewSL";
            this.btnComplaintViewSL.Size = new System.Drawing.Size(394, 23);
            this.btnComplaintViewSL.TabIndex = 24;
            this.btnComplaintViewSL.Text = "View";
            this.btnComplaintViewSL.UseVisualStyleBackColor = true;
            this.btnComplaintViewSL.Click += new System.EventHandler(this.BtnComplaintViewSL_Click);
            // 
            // complaintGuageSlimline
            // 
            this.complaintGuageSlimline.Location = new System.Drawing.Point(7, 48);
            this.complaintGuageSlimline.Name = "complaintGuageSlimline";
            this.complaintGuageSlimline.Size = new System.Drawing.Size(394, 214);
            this.complaintGuageSlimline.TabIndex = 0;
            this.complaintGuageSlimline.Text = "angularGauge1";
            // 
            // frmInstallationProductivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1842, 789);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnInternalVisitSL);
            this.Controls.Add(this.btnInternalVisit);
            this.Controls.Add(this.lblInternalCountSL);
            this.Controls.Add(this.lblInternalCount);
            this.Controls.Add(this.internalReturnGuageSL);
            this.Controls.Add(this.internalReturnGuage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.salesCostsChart);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInstallationProductivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installation Productivity";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInstallationProductivity_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.DateTimePicker dteStart;
        private LiveCharts.WinForms.CartesianChart salesCostsChart;
        private LiveCharts.WinForms.AngularGauge internalReturnGuage;
        private LiveCharts.WinForms.AngularGauge externalReturnGuage;
        private System.Windows.Forms.Label lblInternalCount;
        private System.Windows.Forms.Label lblExternalCount;
        public System.Windows.Forms.Label lblInternalCost;
        public LiveCharts.WinForms.AngularGauge internalReturnCostGuage;
        public LiveCharts.WinForms.AngularGauge externalReturnCostGuage;
        public System.Windows.Forms.Label lblExternalCost;
        private System.Windows.Forms.Button btnInternalVisit;
        private System.Windows.Forms.Button btnExternal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInternalVisitSL;
        private System.Windows.Forms.Label lblInternalCountSL;
        private LiveCharts.WinForms.AngularGauge internalReturnGuageSL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExternalSL;
        public System.Windows.Forms.Label lblExternalCostSL;
        public LiveCharts.WinForms.AngularGauge externalReturnCostGuageSL;
        public System.Windows.Forms.Label lblInternalCostSL;
        public LiveCharts.WinForms.AngularGauge internalReturnCostGuageSL;
        private System.Windows.Forms.Label lblExternalCountSL;
        private LiveCharts.WinForms.AngularGauge externalReturnGuageSL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnComplaintView;
        private LiveCharts.WinForms.AngularGauge complaintGuage;
        public System.Windows.Forms.Label lblComplaintCount;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label lblComplaintCountSL;
        private System.Windows.Forms.Button btnComplaintViewSL;
        private LiveCharts.WinForms.AngularGauge complaintGuageSlimline;
    }
}