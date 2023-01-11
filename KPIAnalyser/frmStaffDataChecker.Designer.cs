namespace KPIAnalyser
{
    partial class frmStaffDataChecker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRemakeRepaint = new System.Windows.Forms.Label();
            this.dgvRemakeRepaint = new System.Windows.Forms.DataGridView();
            this.lblPerformance = new System.Windows.Forms.Label();
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.lblLate = new System.Windows.Forms.Label();
            this.lblAbsent = new System.Windows.Forms.Label();
            this.dgvLate = new System.Windows.Forms.DataGridView();
            this.dgvAbsent = new System.Windows.Forms.DataGridView();
            this.tabEngineering = new System.Windows.Forms.TabControl();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.dteStart = new System.Windows.Forms.DateTimePicker();
            this.dteEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakeRepaint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsent)).BeginInit();
            this.tabEngineering.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRemakeRepaint);
            this.tabPage1.Controls.Add(this.dgvRemakeRepaint);
            this.tabPage1.Controls.Add(this.lblPerformance);
            this.tabPage1.Controls.Add(this.dgvPerformance);
            this.tabPage1.Controls.Add(this.lblLate);
            this.tabPage1.Controls.Add(this.lblAbsent);
            this.tabPage1.Controls.Add(this.dgvLate);
            this.tabPage1.Controls.Add(this.dgvAbsent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1678, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Absence / Late";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblRemakeRepaint
            // 
            this.lblRemakeRepaint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemakeRepaint.ForeColor = System.Drawing.Color.Red;
            this.lblRemakeRepaint.Location = new System.Drawing.Point(1271, 3);
            this.lblRemakeRepaint.Name = "lblRemakeRepaint";
            this.lblRemakeRepaint.Size = new System.Drawing.Size(398, 28);
            this.lblRemakeRepaint.TabIndex = 13;
            this.lblRemakeRepaint.Text = "Repaint / Remake";
            this.lblRemakeRepaint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvRemakeRepaint
            // 
            this.dgvRemakeRepaint.AllowUserToAddRows = false;
            this.dgvRemakeRepaint.AllowUserToDeleteRows = false;
            this.dgvRemakeRepaint.AllowUserToResizeColumns = false;
            this.dgvRemakeRepaint.AllowUserToResizeRows = false;
            this.dgvRemakeRepaint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRemakeRepaint.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvRemakeRepaint.Location = new System.Drawing.Point(1271, 34);
            this.dgvRemakeRepaint.Name = "dgvRemakeRepaint";
            this.dgvRemakeRepaint.ReadOnly = true;
            this.dgvRemakeRepaint.RowHeadersVisible = false;
            this.dgvRemakeRepaint.Size = new System.Drawing.Size(398, 717);
            this.dgvRemakeRepaint.TabIndex = 12;
            // 
            // lblPerformance
            // 
            this.lblPerformance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerformance.ForeColor = System.Drawing.Color.Red;
            this.lblPerformance.Location = new System.Drawing.Point(846, 3);
            this.lblPerformance.Name = "lblPerformance";
            this.lblPerformance.Size = new System.Drawing.Size(398, 28);
            this.lblPerformance.TabIndex = 11;
            this.lblPerformance.Text = "0% Over Target";
            this.lblPerformance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.AllowUserToAddRows = false;
            this.dgvPerformance.AllowUserToDeleteRows = false;
            this.dgvPerformance.AllowUserToResizeColumns = false;
            this.dgvPerformance.AllowUserToResizeRows = false;
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPerformance.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPerformance.Location = new System.Drawing.Point(846, 34);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.ReadOnly = true;
            this.dgvPerformance.RowHeadersVisible = false;
            this.dgvPerformance.Size = new System.Drawing.Size(398, 717);
            this.dgvPerformance.TabIndex = 10;
            // 
            // lblLate
            // 
            this.lblLate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLate.ForeColor = System.Drawing.Color.Red;
            this.lblLate.Location = new System.Drawing.Point(426, 3);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(391, 28);
            this.lblLate.TabIndex = 9;
            this.lblLate.Text = "Total Late Days: 0";
            this.lblLate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblAbsent
            // 
            this.lblAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbsent.ForeColor = System.Drawing.Color.Red;
            this.lblAbsent.Location = new System.Drawing.Point(6, 3);
            this.lblAbsent.Name = "lblAbsent";
            this.lblAbsent.Size = new System.Drawing.Size(392, 28);
            this.lblAbsent.TabIndex = 8;
            this.lblAbsent.Text = "Total Absent Days: 0";
            this.lblAbsent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dgvLate
            // 
            this.dgvLate.AllowUserToAddRows = false;
            this.dgvLate.AllowUserToDeleteRows = false;
            this.dgvLate.AllowUserToResizeColumns = false;
            this.dgvLate.AllowUserToResizeRows = false;
            this.dgvLate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLate.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvLate.Location = new System.Drawing.Point(426, 34);
            this.dgvLate.Name = "dgvLate";
            this.dgvLate.ReadOnly = true;
            this.dgvLate.RowHeadersVisible = false;
            this.dgvLate.Size = new System.Drawing.Size(392, 717);
            this.dgvLate.TabIndex = 3;
            this.dgvLate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLate_CellClick);
            // 
            // dgvAbsent
            // 
            this.dgvAbsent.AllowUserToAddRows = false;
            this.dgvAbsent.AllowUserToDeleteRows = false;
            this.dgvAbsent.AllowUserToResizeColumns = false;
            this.dgvAbsent.AllowUserToResizeRows = false;
            this.dgvAbsent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAbsent.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvAbsent.Location = new System.Drawing.Point(6, 34);
            this.dgvAbsent.Name = "dgvAbsent";
            this.dgvAbsent.ReadOnly = true;
            this.dgvAbsent.RowHeadersVisible = false;
            this.dgvAbsent.Size = new System.Drawing.Size(392, 717);
            this.dgvAbsent.TabIndex = 2;
            // 
            // tabEngineering
            // 
            this.tabEngineering.Controls.Add(this.tabPage1);
            this.tabEngineering.Location = new System.Drawing.Point(12, 88);
            this.tabEngineering.Name = "tabEngineering";
            this.tabEngineering.SelectedIndex = 0;
            this.tabEngineering.Size = new System.Drawing.Size(1686, 783);
            this.tabEngineering.TabIndex = 5;
            // 
            // cmbStaff
            // 
            this.cmbStaff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStaff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(12, 46);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(194, 32);
            this.cmbStaff.TabIndex = 6;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // lblStaff
            // 
            this.lblStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(38, 19);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(146, 24);
            this.lblStaff.TabIndex = 7;
            this.lblStaff.Text = "Staff";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dteStart
            // 
            this.dteStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteStart.Location = new System.Drawing.Point(229, 46);
            this.dteStart.Name = "dteStart";
            this.dteStart.Size = new System.Drawing.Size(208, 29);
            this.dteStart.TabIndex = 8;
            this.dteStart.CloseUp += new System.EventHandler(this.dteStart_CloseUp);
            // 
            // dteEnd
            // 
            this.dteEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteEnd.Location = new System.Drawing.Point(474, 46);
            this.dteEnd.Name = "dteEnd";
            this.dteEnd.Size = new System.Drawing.Size(191, 29);
            this.dteEnd.TabIndex = 9;
            this.dteEnd.CloseUp += new System.EventHandler(this.dteEnd_CloseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(443, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(229, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(436, 37);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Date Range";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(764, 50);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(683, 50);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEmail.TabIndex = 13;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // frmStaffDataChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 883);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dteEnd);
            this.Controls.Add(this.dteStart);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.tabEngineering);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStaffDataChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Data";
            this.Load += new System.EventHandler(this.frmStaffDataChecker_Load);
            this.Shown += new System.EventHandler(this.frmStaffDataChecker_Shown);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemakeRepaint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsent)).EndInit();
            this.tabEngineering.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabEngineering;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.DateTimePicker dteStart;
        private System.Windows.Forms.DateTimePicker dteEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgvLate;
        private System.Windows.Forms.DataGridView dgvAbsent;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.Label lblAbsent;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblPerformance;
        private System.Windows.Forms.DataGridView dgvPerformance;
        private System.Windows.Forms.Label lblRemakeRepaint;
        private System.Windows.Forms.DataGridView dgvRemakeRepaint;
    }
}