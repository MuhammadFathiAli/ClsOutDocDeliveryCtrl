using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

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
            gridView_ProjectList.Columns["PlannedEndDate"].HeaderText = "Planned End Date";
            gridView_ProjectList.Columns["ContractValue"].HeaderText = "Contract Value (Price)";
            gridView_ProjectList.Columns["OwnerName"].HeaderText = "Owner Name";
            gridView_ProjectList.Columns["ConsultantName"].HeaderText = "Consultant Name";
            gridView_ProjectList.Columns["ContractorName"].HeaderText = "Contractor Name";
            gridView_ProjectList.Columns["ConsultantReviewTimeInDays"].HeaderText = "Consultant review time/document (Days)";
        }

        private void LoadAllProjects()
        {
            using (var context = new AppDBContext())
            {
                var projects = context.Projects.ToList();
                this.gridView_ProjectList.DataSource = projects;
            }
        }

        private void lbl_ProjectSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = gridView_ProjectList.SelectedRows[0];
            int projectID = (int)x.Cells[0].Value;
            Project? project;
            List<Entities.Document> documents = new List<Entities.Document>();

            if (x is not null)
            {
                using (var context = new AppDBContext())
                {
                    project = context.Projects.FirstOrDefault(p => p.ProjectId == projectID);
                    documents = context.Documents.Where(d => d.ProjectId == projectID).ToList();
                }
                if (project is not null)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "PDF (*.pdf)|*.pdf";
                    save.FileName = "Result.pdf";
                    bool ErrorMessage = false;
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(save.FileName))
                        {
                            try
                            {
                                File.Delete(save.FileName);
                            }
                            catch (Exception ex)
                            {
                                ErrorMessage = true;
                                MessageBox.Show("Unable to write data to disk: " + ex.Message);
                            }
                        }
                        if (!ErrorMessage)
                        {
                            try
                            {
                                var retentions = documents.Sum(d => d.Retention);
                                var deductions = documents.Sum(d => d.Deduction);
                                var release = retentions - deductions;
                                var totalRequiredDocs = documents.Count;
                                var totalDeliveredToOwner = documents.Where(d => (d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime || d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate)).ToList().Count();
                                var totalDeliveredOntime = documents.Where(d => d.OwnerSubmitStatus == DeliveryStatus.DeliveredOnTime).ToList().Count();
                                var totalDeliveredLate = documents.Where(d => (d.OwnerSubmitStatus == DeliveryStatus.DeliveredLate)).ToList().Count();
                                var totalNotDelivered = documents.Where(d => (d.OwnerSubmitStatus == DeliveryStatus.Pending || d.OwnerSubmitStatus == DeliveryStatus.NotSet || d.OwnerSubmitStatus == DeliveryStatus.Late)).ToList().Count();
                                var performance = (totalDeliveredOntime + (totalDeliveredLate / 2)) / totalDeliveredToOwner;

                                #region ProjectInfo contributers Row
                                Document document = new Document(PageSize.A4.Rotate(), 1f, 1f, 150f, 150f);

                                PdfWriter.GetInstance(document, new FileStream(save.FileName, FileMode.Create));
                                document.Open();
                                PdfPTable pTable = new PdfPTable(3);
                                PdfPCell ownerCell = new PdfPCell(new Phrase($"Project Owner: {project.Name}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                ownerCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);  // Set background color
                                ownerCell.Padding = 5; // Set padding
                                ownerCell.MinimumHeight = 25f; // Set minimum height
                                ownerCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(ownerCell);

                                PdfPCell consultCell = new PdfPCell(new Phrase($"Project Consultant: {project.ConsultantName}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                consultCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen); // Set background color to light green
                                consultCell.Padding = 5; // Set padding
                                consultCell.MinimumHeight = 25f; // Set minimum height
                                consultCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(consultCell);

                                PdfPCell contractorCell = new PdfPCell(new Phrase($"Project Contractor: {project.ContractorName}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                contractorCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen); // Set background color to light green
                                contractorCell.Padding = 5; // Set padding
                                contractorCell.MinimumHeight = 25f; // Set minimum height
                                contractorCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(contractorCell);
                                #endregion

                                #region ProjectInfo Dates Row
                                PdfPCell startDateCell = new PdfPCell(new Phrase($"Starting Date: {project.StartDate.ToShortDateString()}",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                startDateCell.Padding = 5; // Set padding
                                startDateCell.MinimumHeight = 10f; // Set minimum height
                                startDateCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(startDateCell);


                                PdfPCell projectNameCell = new PdfPCell(new Phrase($"Project Name: {project.Name}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                projectNameCell.Padding = 5; // Set padding
                                projectNameCell.MinimumHeight = 10f; // Set minimum height
                                projectNameCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(projectNameCell);


                                PdfPCell endDateCell = new PdfPCell(new Phrase($"Planned End Date: {project.PlannedEndDate.ToShortDateString()}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                endDateCell.Padding = 5; // Set padding
                                endDateCell.MinimumHeight = 10f; // Set minimum height
                                endDateCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(endDateCell);
                                #endregion

                                #region 2 Headers Rows 
                                PdfPCell mainHeaderCell = new PdfPCell(new Phrase("Contractor's Documentation Performance",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                mainHeaderCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightSkyBlue); // Set background color to light green
                                mainHeaderCell.Padding = 5; // Set padding
                                mainHeaderCell.MinimumHeight = 15f; // Set minimum height
                                mainHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                mainHeaderCell.Colspan = 3; // Set horizontal alignment
                                pTable.AddCell(mainHeaderCell);


                                PdfPCell itemHeaderCell = new PdfPCell(new Phrase("Item",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                itemHeaderCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightSkyBlue); // Set background color to light green
                                itemHeaderCell.Padding = 5; // Set padding
                                itemHeaderCell.MinimumHeight = 10f; // Set minimum height
                                itemHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemHeaderCell);

                                PdfPCell valueHeaderCell = new PdfPCell(new Phrase("Value",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                valueHeaderCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightSkyBlue); // Set background color to light green
                                valueHeaderCell.Padding = 5; // Set padding
                                valueHeaderCell.MinimumHeight = 10f; // Set minimum height
                                valueHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueHeaderCell);

                                PdfPCell commentHeaderCell = new PdfPCell(new Phrase("Comment",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)));
                                commentHeaderCell.BackgroundColor = new BaseColor(System.Drawing.Color.LightSkyBlue); // Set background color to light green
                                commentHeaderCell.Padding = 5; // Set padding
                                commentHeaderCell.MinimumHeight = 15f; // Set minimum height
                                commentHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentHeaderCell);
                                #endregion

                                #region Total - Retention
                                PdfPCell itemTotalRetentionCell = new PdfPCell(new Phrase("Total documents retention",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemTotalRetentionCell.Padding = 5; // Set padding
                                itemTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                                itemTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemTotalRetentionCell);

                                PdfPCell valueTotalRetentionCell = new PdfPCell(new Phrase($"{retentions} %",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueTotalRetentionCell.Padding = 5; // Set padding
                                valueTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                                valueTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueTotalRetentionCell);

                                PdfPCell commentTotalRetentionCell = new PdfPCell(new Phrase(""));
                                commentTotalRetentionCell.Padding = 5; // Set padding
                                commentTotalRetentionCell.MinimumHeight = 10f; // Set minimum height
                                commentTotalRetentionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentTotalRetentionCell);
                                #endregion

                                #region Total - Deduction
                                PdfPCell itemTotalDeductionCell = new PdfPCell(new Phrase("Total documents deduction",
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemTotalDeductionCell.Padding = 5; // Set padding
                                itemTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                                itemTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemTotalDeductionCell);

                                PdfPCell valueTotalDeductionCell = new PdfPCell(new Phrase($"{deductions} %",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueTotalDeductionCell.Padding = 5; // Set padding
                                valueTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                                valueTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueTotalDeductionCell);

                                PdfPCell commentTotalDeductionCell = new PdfPCell(new Phrase(""));
                                commentTotalDeductionCell.Padding = 5; // Set padding
                                commentTotalDeductionCell.MinimumHeight = 10f; // Set minimum height
                                commentTotalDeductionCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentTotalDeductionCell);
                                #endregion

                                #region Release
                                PdfPCell itemReleaseCell = new PdfPCell(new Phrase("Release", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemReleaseCell.Padding = 5; // Set padding
                                itemReleaseCell.MinimumHeight = 10f; // Set minimum height
                                itemReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemReleaseCell);

                                PdfPCell valueReleaseCell = new PdfPCell(new Phrase($"{release} %",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueReleaseCell.Padding = 5; // Set padding
                                valueReleaseCell.MinimumHeight = 10f; // Set minimum height
                                valueReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueReleaseCell);

                                PdfPCell commentReleaseCell = new PdfPCell(new Phrase(""));
                                commentReleaseCell.Padding = 5; // Set padding
                                commentReleaseCell.MinimumHeight = 10f; // Set minimum height
                                commentReleaseCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentReleaseCell);
                                #endregion

                                #region Total Required Docs No
                                PdfPCell itemReqDocsCell = new PdfPCell(new Phrase("Number of total documents required", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemReqDocsCell.Padding = 5; // Set padding
                                itemReqDocsCell.MinimumHeight = 10f; // Set minimum height
                                itemReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemReqDocsCell);

                                PdfPCell valueReqDocsCell = new PdfPCell(new Phrase($"{totalRequiredDocs}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueReqDocsCell.Padding = 5; // Set padding
                                valueReqDocsCell.MinimumHeight = 10f; // Set minimum height
                                valueReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueReqDocsCell);

                                PdfPCell commentReqDocsCell = new PdfPCell(new Phrase(""));
                                commentReqDocsCell.Padding = 5; // Set padding
                                commentReqDocsCell.MinimumHeight = 10f; // Set minimum height
                                commentReqDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentReqDocsCell);
                                #endregion

                                #region Total Deliverd to owner No 
                                PdfPCell itemDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents delivered to owner",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemDeliveredDocsCell.Padding = 5; // Set padding
                                itemDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                itemDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemDeliveredDocsCell);

                                PdfPCell valueDeliveredDocsCell = new PdfPCell(new Phrase($"{totalDeliveredToOwner}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueDeliveredDocsCell.Padding = 5; // Set padding
                                valueDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                valueDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueDeliveredDocsCell);

                                PdfPCell commentDeliveredDocsCell = new PdfPCell(new Phrase(""));
                                commentDeliveredDocsCell.Padding = 5; // Set padding
                                commentDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                commentDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentDeliveredDocsCell);
                                #endregion

                                #region Total Delivered Late
                                PdfPCell itemLateDocsCell = new PdfPCell(new Phrase("Number of documents delivered late",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemLateDocsCell.Padding = 5; // Set padding
                                itemLateDocsCell.MinimumHeight = 10f; // Set minimum height
                                itemLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemLateDocsCell);

                                PdfPCell valueLateDocsCell = new PdfPCell(new Phrase($"{totalDeliveredLate}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueLateDocsCell.Padding = 5; // Set padding
                                valueLateDocsCell.MinimumHeight = 10f; // Set minimum height
                                valueLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueLateDocsCell);

                                PdfPCell commentLateDocsCell = new PdfPCell(new Phrase(""));
                                commentLateDocsCell.Padding = 5; // Set padding
                                commentLateDocsCell.MinimumHeight = 10f; // Set minimum height
                                commentLateDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentLateDocsCell);
                                #endregion

                                #region Total Not Delivered
                                PdfPCell itemNotDeliveredDocsCell = new PdfPCell(new Phrase("Number of documents not delivered",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemNotDeliveredDocsCell.Padding = 5; // Set padding
                                itemNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                itemNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemNotDeliveredDocsCell);

                                PdfPCell valueNotDeliveredDocsCell = new PdfPCell(new Phrase($"{totalNotDelivered}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valueNotDeliveredDocsCell.Padding = 5; // Set padding
                                valueNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                valueNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valueNotDeliveredDocsCell);

                                PdfPCell commentNotDeliveredDocsCell = new PdfPCell(new Phrase(""));
                                commentNotDeliveredDocsCell.Padding = 5; // Set padding
                                commentNotDeliveredDocsCell.MinimumHeight = 10f; // Set minimum height
                                commentNotDeliveredDocsCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentNotDeliveredDocsCell);
                                #endregion

                                #region Performance

                                PdfPCell itemPerformanceCell = new PdfPCell(new Phrase("Contractor performance (according to time commitment)",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                itemPerformanceCell.Padding = 5; // Set padding
                                itemPerformanceCell.MinimumHeight = 10f; // Set minimum height
                                itemPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(itemPerformanceCell);

                                PdfPCell valuePerformanceCell = new PdfPCell(new Phrase($"{performance}",
                                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
                                valuePerformanceCell.Padding = 5; // Set padding
                                valuePerformanceCell.MinimumHeight = 10f; // Set minimum height
                                valuePerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(valuePerformanceCell);

                                PdfPCell commentPerformanceCell = new PdfPCell(new Phrase("The reason behind that is the late response of the consultant"));
                                commentPerformanceCell.Padding = 5; // Set padding
                                commentPerformanceCell.MinimumHeight = 10f; // Set minimum height
                                commentPerformanceCell.HorizontalAlignment = Element.ALIGN_CENTER; // Set horizontal alignment
                                pTable.AddCell(commentPerformanceCell);
                                #endregion



                                document.Add(pTable);
                                document.Close();
                                MessageBox.Show("Data Exported Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error while exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a project row");
                return;
            }
        }

    }

}

