using MDSystem.Objects;
using MDSystem.Data;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MDSystem.Forms
{
    public partial class DepartmentEdit : Form
    {
        private List<Department> _departments = new List<Department>();

        public DepartmentEdit(bool isNewRecord = true)
        {
            InitializeComponent();

            if (isNewRecord)
                this.Text = "Новое подразделение";
             
            //_departments = (DataTransfer.GetDataObjects<Department>(new GetDataFilterDepartment { AllObjects = true})).ConvertAll(it => (Department)it);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                if (SaveDepartment())
                    MessageBox.Show("Подразделение сохранено");
                else
                    MessageBox.Show("Ошибка сохранения");
            }
            else
            {
                MessageBox.Show(result);
                return;
            }            
        }

        private bool IsValidData(out string result)
        {
            result = "";

            if (string.IsNullOrWhiteSpace(txtDepartmentName.Text))
                result += "Не указано наименование подразделения\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveDepartment()
        {
            Department department = new Department();
            department.Id = Guid.NewGuid();
            department.ParentId = Guid.Empty;
            department.Name = txtDepartmentName.Text;

            bool isSuccess = false;

            isSuccess = department.Save(CommandAttribute.INSERT);

            return isSuccess;
        }
    }
}
