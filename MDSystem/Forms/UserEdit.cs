using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using Npgsql;
using System.Data;

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
            if (Save())
                MessageBox.Show("Пользователь сохранен.");
            else                
                MessageBox.Show("Ошибка сохранения.");

        }

        private bool Save()
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

            //1. Insert  
            string _connStr = @"HOST=127.0.0.1;PORT=5432;DATABASE=MD;USER ID=postgres;PASSWORD=123;";

            var insertSQL = "INSERT INTO public.t_users (id, firstname, lastname, middlename, workplace_id, department_id, username, password, status, rec_date, del_rec) Values (@Id, @FirstName, @LastName, @MiddleName, @WorkplaceId, @DepartmentId, @UserName, @Password, @Status, now(), @DelRec);";
            var affectedRows = 0;
            using (var conn = OpenConnection(_connStr))
            {
                affectedRows = conn.Execute(insertSQL, user);
            }

            if (affectedRows > 0)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// get the db connection  
        /// </summary>  
        /// <param name="connStr"></param>  
        /// <returns></returns>  
        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
