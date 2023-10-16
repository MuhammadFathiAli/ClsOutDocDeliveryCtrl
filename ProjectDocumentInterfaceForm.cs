using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_ProjectDocumentInterface : Form
    {
        private Project _project;
        public frm_ProjectDocumentInterface(Project project)
        {
            _project = project;
            InitializeComponent();

        }
        private void frm_ProjectDocumentInterface_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            List<Document> docs = LoadDocuments();
            DisplayDocuments();
        }

        private List<Document> LoadDocuments()
        {
            throw new NotImplementedException();
        }

        private void InitializeDataGridView()
        {
            gridView_ProjectDocsList.ColumnCount = 3;
            gridView_ProjectDocsList.Columns[0].Name = "No.";
            gridView_ProjectDocsList.Columns[1].Name = "Document Name";
            gridView_ProjectDocsList.Columns[2].Name = "Document Description";
            gridView_ProjectDocsList.AutoGenerateColumns = false;
        }

        private void DisplayDocuments()
        {
            foreach (var document in _project.Documents.Select((value, index) => new { Index = index + 1, Value = value }))
            {
                gridView_ProjectDocsList.Rows.Add(document.Index, document.Value.Name, document.Value.Description);
            }
        }

        private void txt_DocSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_DocSearch.Text.Trim();
            gridView_ProjectDocsList.Rows.Clear();

            foreach (var document in _project.Documents.Select((value, index) => new { Index = index + 1, Value = value }))
            {
                if (document.Value.Name.ToLower().Contains(searchText))
                {
                    gridView_ProjectDocsList.Rows.Add(document.Index, document.Value.Name, document.Value.Description);
                }
            }
        }

        private void btn_AddDoc_Click(object sender, EventArgs e)
        {
            frm_NewDocument frm_NewDocument = new frm_NewDocument(_project);
            this.Hide();
            frm_NewDocument.ShowDialog();
            this.Show();
            this.Refresh();
        }
    }
}
