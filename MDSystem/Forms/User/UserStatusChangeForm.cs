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

namespace MDSystem.Forms
{
    public partial class UserStatusChangeForm : Form
    {
        private List<statusHelper> _statuses = new List<statusHelper>();
        private statusHelper _selectedHelper { get { return (statusHelper)cmbStatuses.SelectedItem; } }
        private User user = null;

        class statusHelper
        {
            public int StatusId { get; set; }
            public string StatusName { get; set; }
            public UserStatus UserStatus { get; set; }

            public override string ToString()
            {
                return StatusName;
            }
        }

        public UserStatusChangeForm(User operatorsUser)
        {
            InitializeComponent();

            user = operatorsUser;
            txtUserFullName.Text = user.FullName;

            SetStatusHelperList();

            cmbStatuses.Items.AddRange(_statuses.ToArray());
            cmbStatuses.SelectedItem = _statuses.First(it => it.StatusId == (int)user.Status);
        }

        private void SetStatusHelperList()
        {
            foreach (UserStatus status in Enum.GetValues(typeof(UserStatus)))
            {
                _statuses.Add(new statusHelper() { StatusId = (int)status, StatusName = ApplicationData.GetEnumText(status), UserStatus = status });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                if (SaveUser())
                    MessageBox.Show("Статус пользователя сохранен");
                else
                    MessageBox.Show("Ошибка сохранения");
            }
            else
            {
                MessageBox.Show(result, "Внимание!");
                return;
            }
        }

        private bool SaveUser()
        {
            user.Status = _selectedHelper.UserStatus;

            return user.Save(CommandAttribute.UPDATE);
        }

        private bool IsValidData(out string result)
        {
            result = "";

            if (string.IsNullOrWhiteSpace(txtUserFullName.Text))
                result += "Не указано ФИО пользователя\r\n";
            if (_selectedHelper == null)
                result += "Не выбран статус\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
