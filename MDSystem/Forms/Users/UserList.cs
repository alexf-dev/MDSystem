using LiveCharts;
using MDSystem.Data;
using MDSystem.Objects;
using MDSystem.Objects.Models;
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
    public partial class UserList : Form
    {
        private List<User> _bdUsers = new List<User>();
        private List<UserModel> _bdModelUsers = new List<UserModel>();

        public UserList()
        {
            InitializeComponent();
        }        

        private void UserList_Load(object sender, EventArgs e)
        {
            _bdUsers = (DataTransfer.GetDataObjects<User>(new GetDataFilterUser { AllObjects = true })).ConvertAll(it => (User)it);
            _bdModelUsers = _bdUsers.OrderBy(it => it.RecDate).Select(it => new UserModel(it.Id, it.FirstName, it.LastName, it.MiddleName, it.UserName, it.AccessLevelValue)).ToList();

            if (_bdUsers != null)
            {
                foreach (UserModel user in _bdModelUsers)
                {
                    var userLevel = ApplicationData.AcessLevels.FirstOrDefault(x => x.Value == user.AccessLevelValue);
                    if (userLevel != null)
                    {
                        user.AccessLevel = userLevel;
                    }

                    listBoxUsers.Items.Add(user);
                }
            }
        }

        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chartReports.Series["s1"].Points.Clear();
            chartReports.Titles.Clear();
            txtBestReport.Text = string.Empty;

            var user = (UserModel)listBoxUsers.SelectedItem;
            if (user != null)
            {
                txtUserLogin.Text = user.UserName;
                txtUserAccessLevel.Text = user.AccessLevelName;
                chartReports.Titles.Add("Пройденные сценарии");

                var userReports = (DataTransfer.GetDataObjects<Report>(new GetDataFilterReport { OperatorID = user.Id })).ConvertAll(it => (Report)it);
                var reportHelpers = userReports.GroupBy(x => x.ScriptName).ToDictionary(x => x.Key, y => y.Count());

                if (userReports != null && userReports.Any())
                {
                    chartReports.Series["s1"].IsValueShownAsLabel = true;
                    foreach (var report in reportHelpers)
                    {
                        chartReports.Series["s1"].Points.AddXY(report.Key, report.Value);
                    }

                    var bestReport = reportHelpers.OrderByDescending(x => x.Value).First();
                    txtBestReport.Text = "сценарий " + bestReport.Key;
                }                
            }            
        }

        class reportHelper
        {
            public string ReportName { get; set; }
            public int ExecutionCount { get; set; }
        }
    }
}
