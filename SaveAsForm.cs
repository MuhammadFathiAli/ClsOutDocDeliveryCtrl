using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_SaveAs : Form
    {
        Project _project;
        public frm_SaveAs(Project project)
        {
            _project = project;
            InitializeComponent();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                var newName = txt_NewProjectName.Text;
                List<Document> newProjectDocs = new List<Document>();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    using (AppDBContext context = new AppDBContext())
                    {
                        var newProject = new Project();
                        newProjectDocs = context.Documents.Where(d => d.ProjectId == _project.ProjectId).ToList();
                        newProject.Name = newName;
                        newProject.StartDate = _project.StartDate;
                        newProject.PlannedEndDate = _project.PlannedEndDate;
                        newProject.Currency = _project.Currency;
                        newProject.ContractValue = _project.ContractValue;
                        newProject.ConsultantName = _project.ConsultantName;
                        newProject.ContractorName = _project.ContractorName;
                        newProject.OwnerName = _project.OwnerName;
                        newProject.ConsultantReviewTimeInDays = _project.ConsultantReviewTimeInDays;
                        newProject.Documents = newProjectDocs;
                        context.Projects.Add(newProject);
                        context.SaveChanges();
                    }
                    MessageBox.Show("New project saved successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter valid new project name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") ?? false)
                {
                    MessageBox.Show($"Error Creating a new project: Project [{this.txt_NewProjectName.Text}] aleardy exists",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                MessageBox.Show($"Error Creating a new project, Check Database Existence"
                    , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
