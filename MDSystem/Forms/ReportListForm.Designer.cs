﻿namespace MDSystem.Forms
{
    partial class ReportListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.txtReportList = new System.Windows.Forms.TextBox();
            this.cmbOperatorUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО оператора:";
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(375, 33);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 23);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // txtReportList
            // 
            this.txtReportList.Location = new System.Drawing.Point(25, 75);
            this.txtReportList.Multiline = true;
            this.txtReportList.Name = "txtReportList";
            this.txtReportList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReportList.Size = new System.Drawing.Size(474, 404);
            this.txtReportList.TabIndex = 3;
            // 
            // cmbOperatorUsers
            // 
            this.cmbOperatorUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbOperatorUsers.FormattingEnabled = true;
            this.cmbOperatorUsers.Location = new System.Drawing.Point(25, 36);
            this.cmbOperatorUsers.Name = "cmbOperatorUsers";
            this.cmbOperatorUsers.Size = new System.Drawing.Size(292, 23);
            this.cmbOperatorUsers.TabIndex = 4;
            this.cmbOperatorUsers.SelectedValueChanged += new System.EventHandler(this.cmbOperatorUsers_SelectedValueChanged);
            // 
            // ReportListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 491);
            this.Controls.Add(this.cmbOperatorUsers);
            this.Controls.Add(this.txtReportList);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.label1);
            this.Name = "ReportListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список отчетов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.TextBox txtReportList;
        private System.Windows.Forms.ComboBox cmbOperatorUsers;
    }
}