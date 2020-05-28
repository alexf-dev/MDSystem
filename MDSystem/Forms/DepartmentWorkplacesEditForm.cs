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
    public partial class DepartmentWorkplacesEditForm : Form
    {
        private List<Workplace> _workplaces = new List<Workplace>();
        private List<Department> _departments = new List<Department>();
        private Department selectedDepartment  { get { return (Department)cmbDepartments.SelectedItem; } }
        private Workplace selectedWorkplace  { get { return (Workplace)cmbWorkplaces.SelectedItem; } }
               
        public DepartmentWorkplacesEditForm(bool isNewRecord = true)
        {
            InitializeComponent();

            if (isNewRecord)
                this.Text = "Новая должность в подразделении";

            _departments = (DataTransfer.GetDataObjects<Department>(new GetDataFilterDepartment { AllObjects = true })).ConvertAll(it => (Department)it);
            _workplaces = (DataTransfer.GetDataObjects<Workplace>(new GetDataFilterWorkplace { AllObjects = true, ParentId = Guid.Empty })).ConvertAll(it => (Workplace)it);

            cmbDepartments.Items.AddRange(_departments.ToArray());
            cmbWorkplaces.Items.AddRange(_workplaces.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                MessageBox.Show(result, "Внимание!");
                return;
            }
        }

        private bool IsValidData(out string result)
        {
            result = "";

            if (selectedWorkplace == null)
                result += "Не указана должность\r\n";

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
            workplace.Name = selectedWorkplace.Name;

            bool isSuccess = false;

            isSuccess = workplace.Save(CommandAttribute.INSERT);

            return isSuccess;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
