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

namespace MDSystem.Forms.Documentation
{
    public partial class DocumentList : Form
    {
        private string _actionsDate = "";

        private List<DocumentMD> _bdDocuments = new List<DocumentMD>();
        private List<ModelDocumentMD> _bdModelDocuments = new List<ModelDocumentMD>();

        private DocumentMD _selectedBDDocument = null;

        public DocumentList()
        {
            InitializeComponent();
        }        

        private void DocumentList_Load(object sender, EventArgs e)
        {
            _bdDocuments = (DataTransfer.GetDataObjects<DocumentMD>(new GetDataFilterDocumentMD { AllObjects = true })).ConvertAll(it => (DocumentMD)it);
            _bdModelDocuments = _bdDocuments.OrderBy(it => it.RecDate).Select(it => new ModelDocumentMD(it.Id, it.Name)).ToList();

            if (_bdDocuments != null)
            {
                foreach (ModelDocumentMD doc in _bdModelDocuments)
                {
                    listDocuments.Items.Add(doc);
                }
            }
        }

        private void listDocuments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var document = listDocuments.SelectedItem as ModelDocumentMD;

            if (document != null)
            {
                _actionsDate = "";
                _selectedBDDocument = null;
                txtDocDescription.Text = "";

                if (string.IsNullOrWhiteSpace(listDocuments.SelectedItem.ToString()))
                    return;

                _selectedBDDocument = (DocumentMD)(DataTransfer.GetDataObject<DocumentMD>(new GetDataFilterDocumentMD { Id = document.Id }));

                if (_selectedBDDocument != null)
                {
                    txtDocDescription.Text = _actionsDate;
                }
                else
                {
                    MessageBox.Show("Документ " + "\"" + document.Name + "\"" + " отсутствует в БД.");
                    return;
                }
            }
        }
    }
}
