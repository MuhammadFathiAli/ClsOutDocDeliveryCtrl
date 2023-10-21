using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_EditDocument : Form
    {
        Document _document;
        public frm_EditDocument(Document document)
        {
            _document = document;
            InitializeComponent();
        }

        private void frm_EditDocument_Load(object sender, EventArgs e)
        {
            ClearForm();
            // Populate the controls with the properties of the selected project
            this.txt_DocName.Text = _document.Name;
            this.rtxt_DocDescription.Text = _document.Description;
        }
        private void ClearForm()
        {
            // Clear all input fields
            errorProvider_EditDoc.Clear();
            txt_DocName.Text = string.Empty;
            rtxt_DocDescription.Text = String.Empty;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidDocument())
                {
                    return;
                }
                _document.Name = txt_DocName.Text;
                _document.Description = rtxt_DocDescription.Text;
                using (var context = new AppDBContext())
                {
                    var docToUpdate = context.Documents.FirstOrDefault(d => ((d.DocumentId == _document.DocumentId)));
                    if (docToUpdate != null)
                    {
                        docToUpdate.Name = _document.Name;
                        docToUpdate.Description = _document.Description;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") ?? false)
                {
                    MessageBox.Show($"Error Editing the document: documnet [{this.txt_DocName.Text}] aleardy exists",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                MessageBox.Show($"Error Editing the document, Check Database Existence"
                    , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Document details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private bool IsValidDocument()
        {
            if (string.IsNullOrWhiteSpace(txt_DocName.Text))
            {
                errorProvider_EditDoc.SetError(txt_DocName, "Document name is required");
                MessageBox.Show("Document name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rtxt_DocDescription.Text))
            {
                errorProvider_EditDoc.SetError(rtxt_DocDescription, "Document description is required");
                MessageBox.Show("Document description is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
