﻿using ClsOutDocDeliveryCtrl.Context;
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
                project.RetentionforDocumentsDelivery = this.num_Retention.Value;
                project.Documents = new List<Document>()
                {
                    new Document { Name = "As-Built Drawings", Description = "drawings",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "Operation & Maintenance Manuals", Description = "include ''Health & safety file''",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "Fire Safety Plans", Description = "search for it; manual procedures/fa scenario/ evac plan/ maint for ff sys",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "Warranties' Documents", Description = "include warranty period and the supplier and all instructions",
                        RcmdDeadlineBeforeHandover = 4, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Equipment Data Sheets", Description = "contains performance values",
                        RcmdDeadlineBeforeHandover = 4, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Factory/Supplier Certifications", Description = "certifications for quality or success as plumbing",
                        RcmdDeadlineBeforeHandover = 4, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Tests Result Reports", Description = "what is the test conducted and what is the results",
                        RcmdDeadlineBeforeHandover = 2, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(2*7))},
                    new Document { Name = "Inspection Reports", Description = "a documentation of the consultant inspection",
                        RcmdDeadlineBeforeHandover = 2, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(2*7))},
                    new Document { Name = "Commissioning Final Reports", Description = "include T&B",
                        RcmdDeadlineBeforeHandover = 0, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(0*7))},
                    new Document { Name = "Spare Parts Lists", Description = "تقرير يفيد ب ايه هى ال سبير بارتس و مقايسة بيها و ايه اللى تم توريده و مراجعته من الاستشارى و تسليمه للمالك",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "List of Contacts for Suppliers and Subcontractors", Description = "Communication plan for the year of gurantee Description",
                        RcmdDeadlineBeforeHandover = 4, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Defects Reporting Procedure during the Period of Gurantee", Description = "include escalation and contancts and communication method",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "Training Plans", Description = "ايه بنود التدريب و جدولها الزمنى و مين الحضور و كدا",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))},
                    new Document { Name = "Training Materials", Description = "اى مستند للعرض يكون مع المتدربين اثناء التدريب للاضطلاع عليه",
                        RcmdDeadlineBeforeHandover = 4, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(4*7))},
                    new Document { Name = "Training Completion Reports", Description = "Training Completion Reports",
                        RcmdDeadlineBeforeHandover = 0, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(0*7))},
                    new Document { Name = "Training Videos", Description = "تسجيل فيديو كامل للتدريب",
                        RcmdDeadlineAfterHandover = 1, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(1*7)},
                    new Document { Name = "Lessons Learned", Description = "باشتراك جميع الاطراف الخروج بالدروس المستفادة من هذا المشروع Recomm from all teams for next projects",
                        RcmdDeadlineAfterHandover = 2, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(2*7)},
                    new Document { Name = "Photographic Documentation", Description = "تصوير كامل للمشروع و يقدر ال FM يستخدمه بعد كدا فى مقارنة الحالى بالاستلام لتحديد حالة تدهور او تطور المبنى",
                        RcmdDeadlineAfterHandover = 2, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(2*7)},
                    new Document { Name = "Permits & Liscenses", Description = "زى شهادة تسليم الدفاع المدنى",
                        RcmdDeadlineBeforeHandover = 1, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(1*7))},
                    new Document { Name = "Other Documents stated in Contract", Description = "for example: RFIs, MOMs, variation orders",
                        RcmdDeadlineBeforeHandover = 6, ActFirstCTRSubmitDeadline = project.PlannedEndDate.AddDays(-(6*7))}
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
                errorProvider_NewProject.SetError(num_Retention, "Retention for Documents Delivery Max value is 10.00%.");
                errorMessage = "Retention for Documents Delivery Max value is 10.00%.. \n";
                return false;
            }
            errorProvider_NewProject.SetError(num_Retention, ""); // Clear the error message
            return true;
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
