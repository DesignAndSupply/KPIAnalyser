namespace KPIAnalyser
{
    partial class frmProgrammerSummary
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProgrammed = new System.Windows.Forms.Label();
            this.lblLaserProgrammed = new System.Windows.Forms.Label();
            this.lblChecked = new System.Windows.Forms.Label();
            this.lblDrawn = new System.Windows.Forms.Label();
            this.lblAssess = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 485);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(9, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(337, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Engineer Work Overview - Full Name - 01/01/1990";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "TOTALS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jobs Assessed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Jobs Drawn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Jobs Checked:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Laser Jobs Programmed:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Jobs Programmed:";
            // 
            // lblProgrammed
            // 
            this.lblProgrammed.AutoSize = true;
            this.lblProgrammed.Location = new System.Drawing.Point(135, 87);
            this.lblProgrammed.Name = "lblProgrammed";
            this.lblProgrammed.Size = new System.Drawing.Size(13, 13);
            this.lblProgrammed.TabIndex = 12;
            this.lblProgrammed.Text = "0";
            // 
            // lblLaserProgrammed
            // 
            this.lblLaserProgrammed.AutoSize = true;
            this.lblLaserProgrammed.Location = new System.Drawing.Point(135, 121);
            this.lblLaserProgrammed.Name = "lblLaserProgrammed";
            this.lblLaserProgrammed.Size = new System.Drawing.Size(13, 13);
            this.lblLaserProgrammed.TabIndex = 11;
            this.lblLaserProgrammed.Text = "0";
            // 
            // lblChecked
            // 
            this.lblChecked.AutoSize = true;
            this.lblChecked.Location = new System.Drawing.Point(135, 70);
            this.lblChecked.Name = "lblChecked";
            this.lblChecked.Size = new System.Drawing.Size(13, 13);
            this.lblChecked.TabIndex = 10;
            this.lblChecked.Text = "0";
            // 
            // lblDrawn
            // 
            this.lblDrawn.AutoSize = true;
            this.lblDrawn.Location = new System.Drawing.Point(135, 104);
            this.lblDrawn.Name = "lblDrawn";
            this.lblDrawn.Size = new System.Drawing.Size(13, 13);
            this.lblDrawn.TabIndex = 9;
            this.lblDrawn.Text = "0";
            // 
            // lblAssess
            // 
            this.lblAssess.AutoSize = true;
            this.lblAssess.Location = new System.Drawing.Point(135, 53);
            this.lblAssess.Name = "lblAssess";
            this.lblAssess.Size = new System.Drawing.Size(13, 13);
            this.lblAssess.TabIndex = 8;
            this.lblAssess.Text = "0";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 2);
            this.label13.TabIndex = 13;
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(963, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Brown;
            this.txtNote.Location = new System.Drawing.Point(205, 53);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(833, 75);
            this.txtNote.TabIndex = 16;
            this.txtNote.Text = "label1";
            // 
            // frmProgrammerSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 635);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblProgrammed);
            this.Controls.Add(this.lblLaserProgrammed);
            this.Controls.Add(this.lblChecked);
            this.Controls.Add(this.lblDrawn);
            this.Controls.Add(this.lblAssess);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "frmProgrammerSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProgrammerSummary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblProgrammed;
        private System.Windows.Forms.Label lblLaserProgrammed;
        private System.Windows.Forms.Label lblChecked;
        private System.Windows.Forms.Label lblDrawn;
        private System.Windows.Forms.Label lblAssess;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label txtNote;
    }
}