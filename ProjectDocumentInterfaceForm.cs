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
            LoadGrid();
        }
        private void txt_DocSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_DocSearch.Text.Trim().ToLower();
            List<Document> documents = LoadDocuments();
            List<Document> filteredDocuments = documents
                .Where(document => document.Name.ToLower().Contains(searchText))
                .ToList();

            DisplayDocuments(filteredDocuments);
        }
        private void btn_AddDoc_Click(object sender, EventArgs e)
        {
            frm_NewDocument frm_NewDocument = new frm_NewDocument(_project);
            this.Hide();
            frm_NewDocument.ShowDialog();
            List<Document> docs = LoadDocuments();
            DisplayDocuments(docs);
            this.Show();
        }



        private void InitializeDataGridView()
        {
            gridView_ProjectDocsList.ColumnCount = 3;
            gridView_ProjectDocsList.Columns[0].Name = "No.";
            gridView_ProjectDocsList.Columns[1].Name = "Document Name";
            gridView_ProjectDocsList.Columns[2].Name = "Document Description";  
            gridView_ProjectDocsList.AutoGenerateColumns = false;
        }
        private List<Document> LoadDocuments()
        {
            using (var context = new AppDBContext())
            {
                return context.Documents.Where(d => d.ProjectId == _project.ProjectId).ToList();
            }
        }
        private void DisplayDocuments(List<Document> documents)
        {
            gridView_ProjectDocsList.Rows.Clear();
            int count = 1;
            foreach (var document in documents)
            {
                gridView_ProjectDocsList.Rows.Add(count, document.Name, document.Description);
                count++;
            }
        }
        private void LoadGrid()
        {
            List<Document> docs = LoadDocuments();
            DisplayDocuments(docs);
        }
        
    }
}
