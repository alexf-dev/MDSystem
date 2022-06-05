namespace MDSystem
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаОПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAnalysisDocuments = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUserList = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDocumentList = new System.Windows.Forms.Button();
            this.btnAddDocument = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScriptList = new System.Windows.Forms.Button();
            this.addScriptBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRankOperators = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(0, 32);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 32);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(733, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(71, 28);
            this.toolStripMenuItem1.Text = "Добавить";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem2.Text = "Новый пользователь";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItem3.Text = "Новое подразделение";
            this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItem4.Text = "Новая должность";
            this.ToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаОПрограммеToolStripMenuItem,
            this.ToolStripMenuItemExit});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(53, 28);
            this.toolStripMenuItem5.Text = "Меню";
            // 
            // справкаОПрограммеToolStripMenuItem
            // 
            this.справкаОПрограммеToolStripMenuItem.Name = "справкаОПрограммеToolStripMenuItem";
            this.справкаОПрограммеToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.справкаОПрограммеToolStripMenuItem.Text = "Справка о программе";
            this.справкаОПрограммеToolStripMenuItem.Visible = false;
            this.справкаОПрограммеToolStripMenuItem.Click += new System.EventHandler(this.справкаОПрограммеToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemExit.Text = "Выход";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInformation);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 32);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(733, 265);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.tableLayoutPanel1);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(725, 239);
            this.tabPageInformation.TabIndex = 1;
            this.tabPageInformation.Text = "Информация";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAnalysisDocuments);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(540, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 227);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Анализ документации";
            // 
            // btnAnalysisDocuments
            // 
            this.btnAnalysisDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAnalysisDocuments.Location = new System.Drawing.Point(37, 57);
            this.btnAnalysisDocuments.Name = "btnAnalysisDocuments";
            this.btnAnalysisDocuments.Size = new System.Drawing.Size(96, 35);
            this.btnAnalysisDocuments.TabIndex = 3;
            this.btnAnalysisDocuments.Text = "Просмотр";
            this.btnAnalysisDocuments.UseVisualStyleBackColor = true;
            this.btnAnalysisDocuments.Click += new System.EventHandler(this.btnAnalysisDocuments_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUserList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(361, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 227);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Пользователи";
            // 
            // btnUserList
            // 
            this.btnUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUserList.Location = new System.Drawing.Point(39, 57);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(96, 35);
            this.btnUserList.TabIndex = 2;
            this.btnUserList.Text = "Просмотр";
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDocumentList);
            this.groupBox2.Controls.Add(this.btnAddDocument);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(182, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 227);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Бортовая документация";
            // 
            // btnDocumentList
            // 
            this.btnDocumentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnDocumentList.Location = new System.Drawing.Point(38, 124);
            this.btnDocumentList.Name = "btnDocumentList";
            this.btnDocumentList.Size = new System.Drawing.Size(96, 35);
            this.btnDocumentList.TabIndex = 2;
            this.btnDocumentList.Text = "Просмотр";
            this.btnDocumentList.UseVisualStyleBackColor = true;
            this.btnDocumentList.Click += new System.EventHandler(this.btnDocumentList_Click);
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAddDocument.Location = new System.Drawing.Point(26, 47);
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(126, 54);
            this.btnAddDocument.TabIndex = 2;
            this.btnAddDocument.Text = "Загрузить данные";
            this.btnAddDocument.UseVisualStyleBackColor = true;
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScriptList);
            this.groupBox1.Controls.Add(this.addScriptBtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тестовые сценарии";
            // 
            // btnScriptList
            // 
            this.btnScriptList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnScriptList.Location = new System.Drawing.Point(37, 124);
            this.btnScriptList.Name = "btnScriptList";
            this.btnScriptList.Size = new System.Drawing.Size(96, 35);
            this.btnScriptList.TabIndex = 1;
            this.btnScriptList.Text = "Просмотр";
            this.btnScriptList.UseVisualStyleBackColor = true;
            this.btnScriptList.Click += new System.EventHandler(this.btnScriptList_Click);
            // 
            // addScriptBtn
            // 
            this.addScriptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addScriptBtn.Location = new System.Drawing.Point(19, 47);
            this.addScriptBtn.Name = "addScriptBtn";
            this.addScriptBtn.Size = new System.Drawing.Size(131, 54);
            this.addScriptBtn.TabIndex = 0;
            this.addScriptBtn.Text = "Загрузить данные о сценарии";
            this.addScriptBtn.UseVisualStyleBackColor = true;
            this.addScriptBtn.Click += new System.EventHandler(this.addScriptButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnRankOperators);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Выбор действия";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRankOperators
            // 
            this.btnRankOperators.Location = new System.Drawing.Point(471, 35);
            this.btnRankOperators.Name = "btnRankOperators";
            this.btnRankOperators.Size = new System.Drawing.Size(142, 59);
            this.btnRankOperators.TabIndex = 3;
            this.btnRankOperators.Text = "Рекомендации по использованию операторов";
            this.btnRankOperators.UseVisualStyleBackColor = true;
            this.btnRankOperators.Click += new System.EventHandler(this.btnRankOperators_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(251, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 59);
            this.button3.TabIndex = 2;
            this.button3.Text = "Вывести отчеты оператора";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выполнить тестовый сценарий";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "Распределение процессов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 297);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "СППР";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem справкаОПрограммеToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddDocument;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScriptList;
        private System.Windows.Forms.Button addScriptBtn;
        private System.Windows.Forms.Button btnAnalysisDocuments;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.Button btnDocumentList;
        private System.Windows.Forms.Button btnRankOperators;
        private System.Windows.Forms.Button button1;
    }
}