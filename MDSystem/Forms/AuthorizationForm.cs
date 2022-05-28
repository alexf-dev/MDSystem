using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class AuthorizationForm : Form
    {
        private List<User> _users = new List<User>();
        private string path = "creds.txt";
        private string default_value = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;

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

        private async void MakeAuthorization()
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
                current.Department = (Department)DataTransfer.GetDataObject<Department>(new GetDataFilterDepartment {  });
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

            await AddUserCredentials(txtLogin.Text, txtPassword.Text);

            this.Close();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            SendCheckUserCredentials();            
        }

        private async Task SendCheckUserCredentials()
        {
            if (File.Exists(path))
            {
                var credentials = new List<string>();

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        credentials.Add(line);
                    }

                    if (credentials.Any() && credentials.Count == 2)
                    {
                        _login = credentials[0];
                        _password = credentials[1];
                    }
                }

                if (!string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password))
                {
                    txtLogin.Text = _login;
                    txtPassword.Text = _password;
                }
            }
            else
            {
                // полная перезапись файла 
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    await writer.WriteLineAsync(default_value);
                }
            }
        }

        private async Task AddUserCredentials(string login, string password)
        {
            // полная перезапись файла 
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(login);
                await writer.WriteAsync(password);
            }
        }
    }
}
