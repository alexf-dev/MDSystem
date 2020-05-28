namespace MDSystem.Forms
{
    partial class ScriptEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtActionsList = new System.Windows.Forms.TextBox();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtActionsList);
            this.panel1.Controls.Add(this.txtScriptName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 473);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(387, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 38);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список действий:";
            // 
            // txtActionsList
            // 
            this.txtActionsList.Location = new System.Drawing.Point(24, 95);
            this.txtActionsList.Multiline = true;
            this.txtActionsList.Name = "txtActionsList";
            this.txtActionsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActionsList.Size = new System.Drawing.Size(474, 367);
            this.txtActionsList.TabIndex = 4;
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(24, 40);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(290, 20);
            this.txtScriptName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование сценария:";
            // 
            // ScriptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 473);
            this.Controls.Add(this.panel1);
            this.Name = "ScriptEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование сценария";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtActionsList;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
    }
}