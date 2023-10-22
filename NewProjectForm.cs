using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_NewProject : Form
    {
        private Dictionary<Control, string> customErrorMessages = new();
        private string errorMessage = "";
        public frm_NewProject()
        {
            InitializeComponent();
        }
        private void frm_NewProject_Load(object sender, EventArgs e)
        {
            ClearForm();
            SetCustomErrors();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                Project project = new Project();
                project.Name = this.txt_PrjctName.Text;
                project.StartDate = this.datime_StartDate.Value;
                project.PlannedEndDate = this.datime_PEndDate.Value;
                project.ContractValue = this.num_ContactValue.Value;
                project.Currency = this.txt_Currency.Text;
                project.OwnerName = this.txt_OwnerName.Text;
                project.ConsultantName = this.txt_ConsltName.Text;
                project.ContractorName = this.txt_ContrctName.Text;
                project.ConsultantReviewTimeInDays = (int)this.num_ConsltReviewDays.Value;
                project.Documents = new List<Document>()
                {
                    new Document { Name = "As-built Drawings", Description = "As-built Drawings Description", RcmdDeadlineBeforeHandover = 4,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Operation & Maintenance Manual", Description = "Operation & Maintenance Manual Description", RcmdDeadlineBeforeHandover = 4,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Equipment Warranties", Description = "Equipment Warranties Description", RcmdDeadlineBeforeHandover = 2,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(2*7))},
                    new Document { Name = "Equipment Data sheets", Description = "Equipment Data sheets Description", RcmdDeadlineBeforeHandover = 2,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(2*7))},
                    new Document { Name = "Test results reports", Description = "Test results reports Description", RcmdDeadlineBeforeHandover = 1,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "Commissioning reports", Description = "Description, Commissioning reports", RcmdDeadlineBeforeHandover = 1,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "Record of training for facility team", Description = "Record of training for facility team Description", RcmdDeadlineAfterHandover = 2,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(2*7)},
                    new Document { Name = "Documentation for Variations,RFIs,…", Description = "Documentation for Variations,RFIs,… Description", RcmdDeadlineBeforeHandover = 1,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "List of spare parts", Description = "List of spare parts Description", RcmdDeadlineBeforeHandover = 1,
                        ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "List of contacts for suppliers and subcontractors", Description = "List of contacts for suppliers and subcontractors Description", RcmdDeadlineBeforeHandover = 1
                    , ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "Communication plan for the year of gurantee", Description = "Communication plan for the year of gurantee Description", RcmdDeadlineBeforeHandover = 2
                    , ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(2*7))}
                };

                if (!ValidateForm())
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var context = new AppDBContext())
                {
                    context.Projects.Add(project);
                    context.SaveChanges();
                }
                MessageBox.Show("Project created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Navigate to Project Documents Screen.
                frm_ProjectDocumentInterface projectDocumentInterfaceForm = new frm_ProjectDocumentInterface(project);
                this.Close();
                projectDocumentInterfaceForm.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") ?? false)
                {
                    MessageBox.Show($"Error Creating a new project: Project [{this.txt_PrjctName.Text}] aleardy exists",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                MessageBox.Show($"Error Creating a new project, Check Database Existence"
                    , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            // Close it
            this.Close();
        }

        #region PrepareForm
        private void ClearForm()
        {
            // Clear all input fields
            errorProvider_NewProject.Clear();
            txt_PrjctName.Text = string.Empty;
            datime_StartDate.Value = DateTime.Now;
            datime_PEndDate.Value = DateTime.Now;
            num_ContactValue.Value = 0; // You can set the initial value to whatever you prefer
            txt_Currency.Text = string.Empty;
            txt_OwnerName.Text = string.Empty;
            txt_ConsltName.Text = string.Empty;
            txt_ContrctName.Text = string.Empty;
            num_ConsltReviewDays.Value = 7; // You can set the initial value to whatever you prefer
            num_ContactValue.Maximum = decimal.MaxValue;
            num_ContactValue.DecimalPlaces = 2;
            num_ConsltReviewDays.Maximum = int.MaxValue;

        }
        private void SetCustomErrors()
        {
            customErrorMessages.Clear();
            customErrorMessages.Add(txt_PrjctName, "Project name is required.");
            customErrorMessages.Add(txt_Currency, "Currency is required.");
            customErrorMessages.Add(txt_OwnerName, "Owner name is required.");
            customErrorMessages.Add(txt_ConsltName, "Consultant name is required.");
            customErrorMessages.Add(txt_ContrctName, "Contractor name is required.");
        }
        #endregion

        #region Validation
        private bool ValidateForm()
        {
            if (!IsValidTextBox())
                return false;
            else if (!IsValidCurrency())
                return false;
            return IsValidDates();
        }
        private bool IsValidDates()
        {
            // Validate that datime_PEndDate is after datime_StartDate
            if (datime_PEndDate.Value.Date <= datime_StartDate.Value.Date)
            {
                errorProvider_NewProject.SetError(datime_PEndDate, "Planned End Date must be after the Start Date.");
                errorMessage = "Planned End Date must be after the Start Date.. \n";
                return false;
            }
            else
            {
                errorProvider_NewProject.SetError(datime_PEndDate, ""); // Clear the error message
            }
            return true;
        }
        private bool IsValidCurrency()
        {
            // Validate that num_ContactValue is a valid decimal and greater than 100
            if (num_ContactValue.Value <= 100)
            {
                errorProvider_NewProject.SetError(num_ContactValue, "Contract value must be greater than 100.");
                errorMessage = "Contract value must be greater than 100. \n";
                return false;
            }
            errorProvider_NewProject.SetError(num_ContactValue, ""); // Clear the error message
            return true;
        }
        private bool IsValidTextBox()
        {
            // Validate that each TextBox is non-empty
            foreach (var control in customErrorMessages.Keys)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorProvider_NewProject.SetError(control, customErrorMessages[control]);
                        errorMessage = customErrorMessages[control] + "\n";
                        return false;
                    }
                    else
                    {
                        errorProvider_NewProject.SetError(control, ""); // Clear the error message
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
