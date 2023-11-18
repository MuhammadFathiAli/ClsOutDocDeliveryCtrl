using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using ClsOutDocDeliveryCtrl.Helpers;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_ProjectList : Form
    {
        public frm_ProjectList()
        {
            InitializeComponent();
            this.btn_Open.Enabled = false;
            this.gridView_ProjectList.SelectionChanged += GridView_ProjectList_SelectionChanged;
            this.gridView_ProjectList.CellMouseDown += GridView_ProjectList_CellMouseDown;
        }

        private void ProjectListForm_Load(object sender, EventArgs e)
        {
            LoadAllProjects();
            SetUpColumns();
        }

        private void GridView_ProjectList_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < gridView_ProjectList.RowCount)
            {

                // Clear the previous selection and select the current row
                gridView_ProjectList.ClearSelection();
                gridView_ProjectList.Rows[e.RowIndex].Selected = true;
                gridView_ProjectList.CurrentCell = gridView_ProjectList.Rows[e.RowIndex].Cells[6];

                // Get the coordinates relative to the DataGridView
                Point relativeMousePosition = gridView_ProjectList.PointToClient(Cursor.Position);

                // Perform hit testing using the relative coordinates
                DataGridView.HitTestInfo hitTestInfo = gridView_ProjectList.HitTest(relativeMousePosition.X, relativeMousePosition.Y);

                // Add menu items to the context menu strip
                if (hitTestInfo.RowIndex >= 0)
                {
                    //x.Items.Add($"Do something to row {hitTestInfo.RowIndex.ToString()}", null, CustomAction_Click);
                    contextMenuStrip_projects.Show(gridView_ProjectList, relativeMousePosition);
                }

            }

        }

        private void GridView_ProjectList_SelectionChanged(object? sender, EventArgs e)
        {
            btn_Open.Enabled = gridView_ProjectList.SelectedRows.Count > 0;
        }

        private void brn_ProjectSearch_Click(object sender, EventArgs e)
        {
            string searchText = txt_ProjectSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                using (var context = new AppDBContext())
                {
                    var searchResults = context.Projects
                        .Where(p => p.Name.Contains(searchText))
                        .ToList();
                    this.gridView_ProjectList.DataSource = searchResults;
                }
            }
            else
            {
                LoadAllProjects(); // If the search input is empty, load all projects.
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            var x = gridView_ProjectList.SelectedRows[0];
            int projectID = (int)x.Cells[0].Value;
            Project? project;

            if (x is not null)
            {
                using (var context = new AppDBContext())
                {
                    project = context.Projects.FirstOrDefault(p => p.ProjectId == projectID);
                }
                if (project is not null)
                {
                    frm_ProjectDosc projectDocumentsForm = new(project);
                    this.Hide();
                    projectDocumentsForm.ShowDialog();
                    this.Show();
                }
            }
            else
                MessageBox.Show($"Select a prject whole row");
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = gridView_ProjectList.SelectedRows[0];
            int projectID = (int)x.Cells[0].Value;
            Project? project;

            if (x is not null)
            {
                using (var context = new AppDBContext())
                {
                    project = context.Projects.FirstOrDefault(p => p.ProjectId == projectID);
                }
                if (project is not null)
                {
                    frm_ProjectDosc projectDocumentsForm = new(project);
                    this.Hide();
                    projectDocumentsForm.ShowDialog();
                    this.Show();
                }
            }
            else
                MessageBox.Show($"Select a prject whole row");
        }

        private void editProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = gridView_ProjectList.SelectedRows;
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single project to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = selectedRows[0];
            int projectId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string projectName = selectedRow.Cells[1]?.Value?.ToString() ?? string.Empty;

            // Fetch the object to be edited from the database
            using (var context = new AppDBContext())
            {
                var projectToEdit = context.Projects.FirstOrDefault(p => (p.ProjectId == projectId) && (p.Name == projectName));
                if (projectToEdit == null)
                {
                    MessageBox.Show("Selected project not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frm_EditProject frmEditProject = new(projectToEdit);
                this.Hide();
                frmEditProject.ShowDialog();
                this.Show();
                this.LoadAllProjects();
            }
        }

        private void deleteProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var count = gridView_ProjectList.SelectedRows.Count;
            if (count == 0)
            {
                MessageBox.Show("Please select at least one project.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var projectName = gridView_ProjectList.SelectedRows[0].Cells[1].Value.ToString() ?? string.Empty;
            var confirmationMessage = $"Are you sure you want to delete project [{projectName}]?";
            var confirmationResult = MessageBox.Show(confirmationMessage, "Warning", MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirmationResult == DialogResult.Yes)
            {
                using (var context = new AppDBContext())
                {
                    foreach (DataGridViewRow row in gridView_ProjectList.SelectedRows)
                    {
                        int projectId = Convert.ToInt32(row.Cells[0].Value);

                        var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                        if (projectToDelete != null)
                        {
                            context.Projects.Remove(projectToDelete);
                            context.SaveChanges();
                        }
                    }
                }
                MessageBox.Show("Project Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadAllProjects();
            }
        }

        private void txt_ProjectSearch_TextChanged(object sender, EventArgs e)
        {
            brn_ProjectSearch_Click(sender, e);
        }

        private void SetUpColumns()
        {
            // Hide the "ProjectId" and "Documents" columns
            gridView_ProjectList.Columns["ProjectId"].Visible = false;
            gridView_ProjectList.Columns["Documents"].Visible = false;

            // Change column names to user-friendly names
            gridView_ProjectList.Columns["Name"].HeaderText = "Project Name";
            gridView_ProjectList.Columns["StartDate"].HeaderText = "Start Date";
            gridView_ProjectList.Columns["StartDate"].DefaultCellStyle.Format = "d";
            gridView_ProjectList.Columns["PlannedEndDate"].HeaderText = "Planned End Date";
            gridView_ProjectList.Columns["PlannedEndDate"].DefaultCellStyle.Format = "d";
            gridView_ProjectList.Columns["ContractValue"].HeaderText = "Contract Value (Price)";
            gridView_ProjectList.Columns["OwnerName"].HeaderText = "Owner Name";
            gridView_ProjectList.Columns["ConsultantName"].HeaderText = "Consultant Name";
            gridView_ProjectList.Columns["ContractorName"].HeaderText = "Contractor Name";
            gridView_ProjectList.Columns["ConsultantReviewTimeInDays"].HeaderText = "Consultant review time/document (Days)";
            gridView_ProjectList.Columns["ConsultantReviewTimeInDays"].HeaderCell.Style.WrapMode  = DataGridViewTriState.True;
            gridView_ProjectList.Columns["RetentionforDocumentsDelivery"].HeaderText = "Retention for Documents Delivery (%)";
            gridView_ProjectList.Columns["RetentionforDocumentsDelivery"].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
        }

        private void LoadAllProjects()
        {
            using (var context = new AppDBContext())
            {
                var projects = context.Projects.ToList();
                this.gridView_ProjectList.DataSource = projects;
            }
        }
        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedProject = gridView_ProjectList.SelectedRows[0];
            int projectID = (int)selectedProject.Cells[0].Value;
            Report report = new Report(projectID);
            report.GenerateReport();
        }
    }

}

