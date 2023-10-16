using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_NewDocument : Form
    {
        Project _project;
        public frm_NewDocument(Project project)
        {
            InitializeComponent();
            _project = project;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!IsValidDocument())
            {
                return;
            }
            using (var context = new AppDBContext())
            {
                Document newDocument = new Document
                {
                    Name = txt_DocName.Text,
                    Description = rtxt_DocDescription.Text,
                    ProjectId = _project.ProjectId
                };
                context.Documents.Add(newDocument);
                context.SaveChanges();
                MessageBox.Show("Document added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool IsValidDocument()
        {
            if (string.IsNullOrWhiteSpace(txt_DocName.Text))
            {
                errorProvider_NewDoc.SetError(txt_DocName, "Document name is required");
                MessageBox.Show("Document name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rtxt_DocDescription.Text))
            {
                errorProvider_NewDoc.SetError(rtxt_DocDescription, "Document description is required");
                MessageBox.Show("Document description is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}