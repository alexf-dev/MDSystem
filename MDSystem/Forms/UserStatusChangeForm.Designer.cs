namespace MDSystem.Forms
{
    partial class UserStatusChangeForm
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
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatuses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUserFullName.Location = new System.Drawing.Point(59, 47);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.ReadOnly = true;
            this.txtUserFullName.Size = new System.Drawing.Size(231, 21);
            this.txtUserFullName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ФИО:";
            // 
            // cmbStatuses
            // 
            this.cmbStatuses.FormattingEnabled = true;
            this.cmbStatuses.Location = new System.Drawing.Point(59, 106);
            this.cmbStatuses.Name = "cmbStatuses";
            this.cmbStatuses.Size = new System.Drawing.Size(231, 21);
            this.cmbStatuses.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выбрать статус:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserStatusChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 222);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatuses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserFullName);
            this.Name = "UserStatusChangeForm";
            this.Text = "Редактирование статуса пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatuses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}