using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class UserEdit : Form
    {
        private List<Workplace> _workplaces = new List<Workplace>();
        private List<Department> _departments = new List<Department>();
        private Department selectedDepartment { get { return (Department)cmbDepartment.SelectedItem; } }
        private Workplace selectedWorkplace { get { return (Workplace)cmbWorkplace.SelectedItem; } }
        private AccessLevel selectedAccessLevel { get { return (AccessLevel)cmbAccessLevel.SelectedItem; } }

        public UserEdit(bool isNewRecord = true)
        {
            InitializeComponent();

            if (isNewRecord)
                this.Text = "Новый пользователь";

            _departments = (DataTransfer.GetDataObjects<Department>(new GetDataFilterDepartment { AllObjects = true })).ConvertAll(it => (Department)it);
            cmbDepartment.Items.AddRange(_departments.ToArray());
            cmbAccessLevel.Items.AddRange(ApplicationData.AcessLevels.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                if (SaveUser())
                    MessageBox.Show("Пользователь сохранен");
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

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                result += "Не указана фамилия\r\n";
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                result += "Не указано имя\r\n";
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                result += "Не указано отчество\r\n";
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
                result += "Не указан логин\r\n";
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                result += "Не указан пароль\r\n";
            if (selectedDepartment == null)
                result += "Не указано подразделение\r\n";
            else                
                if (selectedWorkplace == null)
                    result += "Не указана должность\r\n";
            if (selectedAccessLevel == null)
                result += "Не указан уровень доступа\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveUser()
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.MiddleName = txtMiddleName.Text;
            user.UserName = txtLogin.Text;
            user.Password = txtPassword.Text;
            user.Workplace = selectedWorkplace;  
            user.Department = selectedDepartment;
            user.AccessLevel = selectedAccessLevel;
            user.AccessLevelValue = selectedAccessLevel.Value;

            return user.Save(CommandAttribute.INSERT);
        }

        private void cmbDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbWorkplace.Enabled = false;

            cmbWorkplace.Items.Clear(); 
            _workplaces = (DataTransfer.GetDataObjects<Workplace>(new GetDataFilterWorkplace { ParentId = selectedDepartment.Id })).ConvertAll(it => (Workplace)it);
            cmbWorkplace.Items.AddRange(_workplaces.ToArray());

            cmbWorkplace.Enabled = true;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = !string.IsNullOrWhiteSpace(txtLogin.Text);
        }
    }
}
