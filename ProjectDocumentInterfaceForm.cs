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
            this.btn_EditDoc.Enabled = false;
            this.btn_DeleteDoc.Enabled = false;
            this.btn_Info.Enabled = false;
            this.gridView_ProjectDocsList.SelectionChanged += GridView_ProjectDocsList_SelectionChanged;

        }

        private void GridView_ProjectDocsList_SelectionChanged(object? sender, EventArgs e)
        {
            if (gridView_ProjectDocsList.SelectedRows.Count > 0)
            {
                btn_EditDoc.Enabled = true;
            this.btn_Info.Enabled = true;
                btn_DeleteDoc.Enabled = true;
            }
            else
            {
                btn_EditDoc.Enabled = false;
                btn_DeleteDoc.Enabled = false;
                this.btn_Info.Enabled = false;

            }
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
        private void btn_EditDoc_Click(object sender, EventArgs e)
        {
            var selectedRows = this.gridView_ProjectDocsList.SelectedRows;
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single document to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = selectedRows[0];
            var docName = selectedRow.Cells[1].Value.ToString();
            var projectName = selectedRow.Cells[1]?.Value?.ToString() ?? string.Empty;

            // Fetch the object to be edited from the database
            using (var context = new AppDBContext())
            {
                var docToEdit = context.Documents.FirstOrDefault(d => (d.ProjectId == _project.ProjectId) && (d.Name == docName));
                if (docToEdit == null)
                {
                    MessageBox.Show("Selected document not found in the database.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frm_EditDocument frmEditDoc = new(docToEdit);
                this.Hide();
                frmEditDoc.ShowDialog();
                this.Show();
                this.LoadGrid();
            }
        }

        private void btn_DeleteDoc_Click(object sender, EventArgs e)
        {
            var count = gridView_ProjectDocsList.SelectedRows.Count;
            if (count != 1)
            {
                MessageBox.Show("Please select a single project.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var docName = gridView_ProjectDocsList.SelectedRows[0].Cells[1].Value.ToString() ?? string.Empty;
            var confirmationMessage = $"Are you sure you want to delete document [{docName}] of project [{_project.Name}]?";
            var confirmationResult = MessageBox.Show(confirmationMessage, "Warning", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirmationResult == DialogResult.Yes)
            {
                using (var context = new AppDBContext())
                {
                    foreach (DataGridViewRow row in gridView_ProjectDocsList.SelectedRows)
                    {
                        var docToDelete = context.Documents.FirstOrDefault(d => (d.ProjectId == _project.ProjectId) && (d.Name == docName));
                        if (docToDelete != null)
                        {
                            context.Documents.Remove(docToDelete);
                            context.SaveChanges();
                        }
                    }
                }
                MessageBox.Show("Document Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LoadGrid();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            string confirmationMessage = "Are you sure these are all the contract's documents? \n CANNOT be edited again ";
            var confirmationResult = MessageBox.Show(confirmationMessage, "Warning", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirmationResult == DialogResult.Yes)
            {
                //navigate to projectDocument Form
                frm_ProjectDosc projectDocumentsForm = new(_project);
                this.Close();
                projectDocumentsForm.ShowDialog();
            }
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            var selectedRows = this.gridView_ProjectDocsList.SelectedRows;
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single document to show its info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = selectedRows[0];
            var docName = selectedRow.Cells[1].Value.ToString();
            var projectName = selectedRow.Cells[1]?.Value?.ToString() ?? string.Empty;

            // Fetch the object to be edited from the database
            using (var context = new AppDBContext())
            {
                var docToEdit = context.Documents.FirstOrDefault(d => (d.ProjectId == _project.ProjectId) && (d.Name == docName));
                if (docToEdit == null)
                {
                    MessageBox.Show("Selected document not found in the database.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frm_MoreInfo frmMoreInfo = new(docToEdit);
                this.Hide();
                frmMoreInfo.ShowDialog();
                this.Show();
                this.LoadGrid();
            }
        }
    }
}