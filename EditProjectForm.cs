using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_EditProject : Form
    {
        private Project _project;
        private Dictionary<Control, string> customErrorMessages = new();
        private string errorMessage = "";

        public frm_EditProject(Project project)
        {
            _project = project;
            InitializeComponent();
        }

        private void frm_EditProject_Load(object sender, EventArgs e)
        {
            ClearForm();
            SetCustomErrors();

            // Populate the controls with the properties of the selected project
            txt_PrjctName.Text = _project.Name;
            datime_StartDate.Value = _project.StartDate;
            datime_PEndDate.Value = _project.PlannedEndDate;
            num_ContactValue.Value = _project.ContractValue;
            txt_Currency.Text = _project.Currency;
            txt_OwnerName.Text = _project.OwnerName;
            txt_ConsltName.Text = _project.ConsultantName;
            txt_ContrctName.Text = _project.ContractorName;
            num_ConsltReviewDays.Value = _project.ConsultantReviewTimeInDays;
            num_Retention.Value = _project.RetentionforDocumentsDelivery;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //get the project object 
                _project.Name = txt_PrjctName.Text;
                _project.StartDate = datime_StartDate.Value;
                _project.PlannedEndDate = datime_PEndDate.Value;
                _project.ContractValue = num_ContactValue.Value;
                _project.Currency = txt_Currency.Text;
                _project.OwnerName = txt_OwnerName.Text;
                _project.ConsultantName = txt_ConsltName.Text;
                _project.ContractorName = txt_ContrctName.Text;
                _project.ConsultantReviewTimeInDays = (int)num_ConsltReviewDays.Value;
                _project.RetentionforDocumentsDelivery = num_Retention.Value;

                //save changes in database
                using (var context = new AppDBContext())
                {
                    var projectToUpdate = context.Projects.FirstOrDefault(p => ((p.ProjectId == _project.ProjectId)));
                    if (projectToUpdate != null)
                    {
                        projectToUpdate.Name = _project.Name;
                        projectToUpdate.StartDate = _project.StartDate;
                        projectToUpdate.PlannedEndDate = _project.PlannedEndDate;
                        projectToUpdate.ContractValue = _project.ContractValue;
                        projectToUpdate.Currency = _project.Currency;
                        projectToUpdate.OwnerName = _project.OwnerName;
                        projectToUpdate.ConsultantName = _project.ConsultantName;
                        projectToUpdate.ContractorName = _project.ContractorName;
                        projectToUpdate.ConsultantReviewTimeInDays = _project.ConsultantReviewTimeInDays;
                        projectToUpdate.RetentionforDocumentsDelivery = _project.RetentionforDocumentsDelivery;

                        var documentsToEdit = context.Documents.Where(d => d.ProjectId == _project.ProjectId);
                        foreach (var document in documentsToEdit)
                        {
                            var x = document.RcmdDeadlineBeforeHandover;
                            var y = document.RcmdDeadlineAfterHandover;
                            if (x.HasValue && x is not null && x is int beforeWeeks)
                            {
                                document.ActFirstCTRSubmitDeadline = projectToUpdate.PlannedEndDate.AddDays(-(beforeWeeks*7));
                            }
                            else if (y.HasValue && y is not null && y is int afterWeeks)
                            {
                                document.ActFirstCTRSubmitDeadline = projectToUpdate.PlannedEndDate.AddDays(afterWeeks* 7);
                            }
                            if (projectToUpdate.PlannedEndDate < DateTime.Today)
                            {
                                document.OwnerSubmitStatus = DeliveryStatus.Late;
                            }
                            else
                            {
                                document.OwnerSubmitStatus = DeliveryStatus.NotSet;
                            }
                        }
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate") ?? false)
                {
                    MessageBox.Show($"Error Editing the project: Project [{this.txt_PrjctName.Text}] aleardy exists",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                MessageBox.Show($"Error Editing the project, Check Database Existence"
                    , Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Project details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        #region Prepare Form
        private void ClearForm()
        {
            // Clear all input fields
            errorProvider_EditProject.Clear();
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
            num_Retention.Value = 5;
            num_Retention.DecimalPlaces = 2;
            num_Retention.Maximum = 10;

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
            else if (!IsValidRetention())
                return false;
            return IsValidDates();
        }

        private bool IsValidRetention()
        {
            if (num_Retention.Value < 0 || num_Retention.Value > 10)
            {
                errorProvider_EditProject.SetError(num_Retention, "Retention for Documents Delivery Max value is 10.00%.");
                errorMessage = "Retention for Documents Delivery Max value is 10.00%.. \n";
                return false;
            }
            errorProvider_EditProject.SetError(num_Retention, ""); // Clear the error message
            return true;
        }

        private bool IsValidDates()
        {
            // Validate that datime_PEndDate is after datime_StartDate
            if (datime_PEndDate.Value.Date <= datime_StartDate.Value.Date)
            {
                errorProvider_EditProject.SetError(datime_PEndDate, "Planned End Date must be after the Start Date.");
                errorMessage = "Planned End Date must be after the Start Date.. \n";
                return false;
            }
            else
            {
                errorProvider_EditProject.SetError(datime_PEndDate, ""); // Clear the error message
            }
            return true;
        }
        private bool IsValidCurrency()
        {
            // Validate that num_ContactValue is a valid decimal and greater than 100
            if (num_ContactValue.Value <= 100)
            {
                errorProvider_EditProject.SetError(num_ContactValue, "Contract value must be greater than 100.");
                errorMessage = "Contract value must be greater than 100. \n";
                return false;
            }
            errorProvider_EditProject.SetError(num_ContactValue, ""); // Clear the error message
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
                        errorProvider_EditProject.SetError(control, customErrorMessages[control]);
                        errorMessage = customErrorMessages[control] + "\n";
                        return false;
                    }
                    else
                    {
                        errorProvider_EditProject.SetError(control, ""); // Clear the error message
                    }
                }
            }
            return true;
        }
        #endregion

        private void btn_Back_Click(object sender, EventArgs e)
        {
            // Close it
            this.Close();
        }
    }
}
