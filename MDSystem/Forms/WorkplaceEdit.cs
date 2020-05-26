using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class WorkplaceEdit : Form
    {
        private List<Workplace> _workplaces = new List<Workplace>();
        private List<Department> _departments = new List<Department>();
        private Department selectedDepartment { get { return (Department)cmbDepartments.SelectedItem; } }
        
        public WorkplaceEdit(bool isNewRecord = true)
        {
            InitializeComponent();

            if (isNewRecord)
                this.Text = "Новая должность";

            _departments = (DataTransfer.GetDataObjects<Department>(new GetDataFilterDepartment { AllObjects = true})).ConvertAll(it => (Department)it);
            cmbDepartments.Items.AddRange(_departments.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                if (SaveWorkplace())
                    MessageBox.Show("Должность сохранена");
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

            if (string.IsNullOrWhiteSpace(txtWorkplaceName.Text))
                result += "Не указано наименование должности\r\n";

            if (selectedDepartment == null)
                result += "Не указано подразделение\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveWorkplace()
        {
            Workplace workplace = new Workplace();
            workplace.Id = Guid.NewGuid();
            workplace.ParentId = selectedDepartment != null ? selectedDepartment.Id : Guid.Empty;
            workplace.Name = txtWorkplaceName.Text;

            bool isSuccess = false;

            isSuccess = workplace.Save(CommandAttribute.INSERT);

            return isSuccess;
        }
    }
}
