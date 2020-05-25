using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveUser())
                MessageBox.Show("Пользователь сохранен.");
            else                
                MessageBox.Show("Ошибка сохранения.");

        }

        private bool SaveUser()
        {
            User user = new User();

            user.Id = Guid.NewGuid();

            if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                user.FirstName = txtFirstName.Text;
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                user.LastName = txtLastName.Text;
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                user.MiddleName = txtMiddleName.Text;

            if (!string.IsNullOrWhiteSpace(txtLogin.Text))
                user.UserName = txtLogin.Text;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                user.Password = txtPassword.Text;

            if (cmbWorkplace.SelectedItem != null)
            {
                Workplace wp = ApplicationData.Workplaces.FirstOrDefault(it => it.Name.Equals(cmbWorkplace.Text));
                if (wp != null)
                    user.Workplace = wp;
            }

            if (cmbDepartment.SelectedItem != null)
            {
                Department dp = ApplicationData.Departments.FirstOrDefault(it => it.Name.Equals(cmbDepartment.Text));
                if (dp != null)
                    user.Department = dp;
            }

            return user.Save(CommandAttribute.INSERT);
        }
    }
}
