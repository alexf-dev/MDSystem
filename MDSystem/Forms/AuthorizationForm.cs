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
    public partial class AuthorizationForm : Form
    {
        private List<User> _users = new List<User>();

        public AuthorizationForm()
        {
            InitializeComponent();

            ApplicationData.IsAuthorizedUser = false;
        }

        private void btnAuthorization_Click(object sender, EventArgs e)
        {
            MakeAuthorization();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplicationData.IsAuthorizedUser = false;
            this.Close();
        }

        private void AuthorizationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MakeAuthorization();
            }
        }

        private void MakeAuthorization()
        {
            ApplicationData.IsAuthorizedUser = false;

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Не указан логин пользователя");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Не указан пароль пользователя");
                return;
            }

            if (txtLogin.Text.Equals(MDSystem.Data.ApplicationData.Admin.UserName) && txtPassword.Text.Equals(MDSystem.Data.ApplicationData.Admin.Password))
                ApplicationData.CurrentUser = ApplicationData.Admin;
            else
            {
                _users = (DataTransfer.GetDataObjects<User>(new GetDataFilterUser { AllObjects = true })).ConvertAll(it => (User)it);

                User current = _users.FirstOrDefault(it => it.UserName.Equals(txtLogin.Text));
                if (current == null)
                {
                    MessageBox.Show("Пользователь с логином " + txtLogin.Text + " не найден в базе данных");
                    return;
                }
                else
                {
                    if (!current.Password.Equals(txtPassword.Text))
                    {
                        MessageBox.Show("Не верно указан пароль");
                        return;
                    }
                }

                ApplicationData.CurrentUser = current;
            }

            ApplicationData.IsAuthorizedUser = ApplicationData.CurrentUser != null;
            this.Close();
        }
    }
}
