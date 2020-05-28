namespace MDSystem.Forms
{
    partial class RunTestedScript
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
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserActionsList = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBDActionsList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeControl = new System.Windows.Forms.TextBox();
            this.btnMakeStatus = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(92, 15);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(363, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(92, 59);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(363, 20);
            this.txtScriptName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сценарий:";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(682, 35);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(86, 44);
            this.btnRunTest.TabIndex = 4;
            this.btnRunTest.Text = "Старт";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserActionsList);
            this.groupBox1.Location = new System.Drawing.Point(30, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 328);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия пользователя:";
            // 
            // txtUserActionsList
            // 
            this.txtUserActionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserActionsList.Location = new System.Drawing.Point(3, 16);
            this.txtUserActionsList.Multiline = true;
            this.txtUserActionsList.Name = "txtUserActionsList";
            this.txtUserActionsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserActionsList.Size = new System.Drawing.Size(419, 309);
            this.txtUserActionsList.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBDActionsList);
            this.groupBox2.Location = new System.Drawing.Point(482, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 328);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Действия по сценарию в БД:";
            // 
            // txtBDActionsList
            // 
            this.txtBDActionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBDActionsList.Location = new System.Drawing.Point(3, 16);
            this.txtBDActionsList.Multiline = true;
            this.txtBDActionsList.Name = "txtBDActionsList";
            this.txtBDActionsList.ReadOnly = true;
            this.txtBDActionsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBDActionsList.Size = new System.Drawing.Size(418, 309);
            this.txtBDActionsList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Время выполнения:";
            // 
            // txtTimeControl
            // 
            this.txtTimeControl.Location = new System.Drawing.Point(33, 469);
            this.txtTimeControl.Multiline = true;
            this.txtTimeControl.Name = "txtTimeControl";
            this.txtTimeControl.Size = new System.Drawing.Size(419, 54);
            this.txtTimeControl.TabIndex = 8;
            // 
            // btnMakeStatus
            // 
            this.btnMakeStatus.Enabled = false;
            this.btnMakeStatus.Location = new System.Drawing.Point(562, 469);
            this.btnMakeStatus.Name = "btnMakeStatus";
            this.btnMakeStatus.Size = new System.Drawing.Size(113, 35);
            this.btnMakeStatus.TabIndex = 9;
            this.btnMakeStatus.Text = "Сменить статус";
            this.btnMakeStatus.UseVisualStyleBackColor = true;
            this.btnMakeStatus.Click += new System.EventHandler(this.btnMakeStatus_Click);
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Enabled = false;
            this.btnSaveReport.Location = new System.Drawing.Point(730, 469);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(113, 35);
            this.btnSaveReport.TabIndex = 10;
            this.btnSaveReport.Text = "Сохранить отчет";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunTestedScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.btnMakeStatus);
            this.Controls.Add(this.txtTimeControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRunTest);
            this.Controls.Add(this.txtScriptName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Name = "RunTestedScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выполнение тестового сценария";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUserActionsList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBDActionsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeControl;
        private System.Windows.Forms.Button btnMakeStatus;
        private System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.Button button1;
    }
}