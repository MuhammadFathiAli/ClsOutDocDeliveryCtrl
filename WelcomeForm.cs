using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using System.Data;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_welcome : Form
    {
        public frm_welcome()
        {
            InitializeComponent();
            this.FormClosing += Frm_welcome_FormClosing;
        }

        private void Frm_welcome_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (
                    MessageBox.Show("Are you sure to exit?", "Warning", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        == DialogResult.No
                )
                e.Cancel = true;
            else
                Environment.Exit(0);
        }

        private void cmbox_Recents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //frm
            if (cmbox_Recents.SelectedIndex > 0)
            {
                var projectName = cmbox_Recents.SelectedItem;
                Project? project = null;
                using (var context = new AppDBContext())
                {
                     project = context.Projects.Where(x => x.Name == projectName).ToList().FirstOrDefault();
                }
                if (project is not null)
                {
                    frm_ProjectDosc projectDocumentsForm = new(project);
                    this.Hide();
                    projectDocumentsForm.ShowDialog();
                    this.Show();
                }
            }

            //if (cmbox_Recents.SelectedItem is Project selectedProject)
            //{
            //        frm_ProjectDosc projectDocumentsForm = new(selectedProject);
            //        this.Hide();
            //        projectDocumentsForm.ShowDialog();
            //        this.Show();
            //}
            //else
            //    MessageBox.Show($"Project Not exists");

        }

        private void frm_welcome_Load(object sender, EventArgs e)
        {
            // Fetch the last two created projects from your database
            // Replace this with actual database query code
            List<string> recentProjects = GetLastTwoProjectsFromDatabase();

            //if (recentProjects.Count == 0)
            //{
            //    var x = new List<string> { "No Projects Created" }.ToArray();
            //    cmbox_Recents.Items.AddRange(x);
            //}
            recentProjects.Insert(0, "Choose from recents");

            //// Add the project names to the combo box
            cmbox_Recents.DataSource = recentProjects;
        }

        private List<string> GetLastTwoProjectsFromDatabase()
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var recentProjects = context.Projects.OrderByDescending(x => x.ProjectId)
                            .Take(2)
                            .ToList();
                    if (recentProjects is null)
                    {
                        return new List<string>();
                    }
                    return recentProjects.Select(x => x.Name).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        frm_NewProject frm_newProject = new();
        private void btn_NewPrjct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_newProject.ShowDialog();
            this.Visible = true;
        }

        private void btn_ProjectSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ProjectList projectListForm = new frm_ProjectList();
            projectListForm.ShowDialog();
            this.Visible = true;
        }
    }
}
