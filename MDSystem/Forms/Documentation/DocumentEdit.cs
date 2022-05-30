using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms.Documentation
{
    public partial class DocumentEdit : Form
    {
        public DocumentEdit()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                if (SaveDocument())
                    MessageBox.Show("Документ сохранен");
                else
                    MessageBox.Show("Ошибка сохранения");
            }
            else
            {
                MessageBox.Show(result, "Внимание!");
                return;
            }
        }

        private bool IsValidData(out string result)
        {
            result = "";

            if (string.IsNullOrWhiteSpace(txtDocName.Text))
                result += "Не указано наименование документа\r\n";
            if (string.IsNullOrWhiteSpace(txtDocDescripton.Text))
                result += "Не указано содержание документа\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveDocument()
        {
            DocumentMD document = new DocumentMD();
            document.Id = Guid.NewGuid();
            document.ParentId = Guid.Empty;
            document.Name = txtDocName.Text;
            document.Description = txtDocDescripton.Text;

            return document.Save(CommandAttribute.INSERT);
        }
    }
}
