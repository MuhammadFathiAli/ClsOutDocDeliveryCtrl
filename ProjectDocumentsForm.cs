using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using ClsOutDocDeliveryCtrl.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ClsOutDocDeliveryCtrl
{
    public enum SubmitalPhase
    {
        first,
        second,
        third
    }
    public partial class frm_ProjectDosc : Form
    {
        private bool ShowSecondSubmital;
        private bool ShowThirdSubmital;

        private bool ISShownSecondSubmital;
        private bool ISShownThirdSubmital;
        private bool IsCanceledClose;

        private Project _project;
        private DataGridViewCell _clickedCell;
        private DateTimePicker _dtp;
        private DataGridViewComboBoxColumn sendCopyCombBoxCol;
        private DataGridViewComboBoxColumn firstRspCodeCombBoxCol;
        private DataGridViewComboBoxColumn secondRspCodeCombBoxCol;
        private DataGridViewComboBoxColumn thirdRspCodeCombBoxCol;
        private DataGridViewComboBoxColumn submitalFormatCol;
        public frm_ProjectDosc(Project project)

        {
            _project = project;
            InitializeComponent();
            _dtp = new DateTimePicker { Visible = false, Format = DateTimePickerFormat.Short };
            gridView_ProjectDocs.Controls.Add(_dtp);
            _dtp.TextChanged += _dtp_TextChanged;
            gridView_ProjectDocs.CellClick += GridView_ProjectDocs_CellClick;
            gridView_ProjectDocs.Scroll += GridView_ProjectDocs_Scroll;
            gridView_ProjectDocs.CellValueChanged += GridView_ProjectDocs_CellValueChanged;
            gridView_ProjectDocs.EditingControlShowing += GridView_ProjectDocs_EditingControlShowing;
            gridView_ProjectDocs.CellFormatting += GridView_ProjectDocs_CellFormatting;
            gridView_ProjectDocs.CellLeave += GridView_ProjectDocs_CellEndEdit;
            tabControl1.Selected += TabControl1_Selected;
            FormClosing += ProjectDocumentsForm_FormClosing;
            gridView_ProjectDocs.Visible = true;
            sendCopyCombBoxCol = new DataGridViewComboBoxColumn();
            firstRspCodeCombBoxCol = new DataGridViewComboBoxColumn();
            secondRspCodeCombBoxCol = new DataGridViewComboBoxColumn();
            thirdRspCodeCombBoxCol = new DataGridViewComboBoxColumn();
            submitalFormatCol = new DataGridViewComboBoxColumn();
        }

        private void GridView_ProjectDocs_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            _dtp.Visible = false;
        }

        private void ProjectDocumentsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit Project Documents Form?", "Warning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
                IsCanceledClose = true;
            }
            else
                IsCanceledClose = false;
        }

        private void ProjectDocumentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUpColumns();
            AddComboBoxColumns();
            SetSubmitStatusColumn(SubmitalPhase.first);
            SetResponseStatusColumn(SubmitalPhase.first);
            RemoveSecondSubmitTrailsScreen(true);
            RemoveThirdSubmitTrailsScreen(true);
            SetSubmitColsVisibility();
            SetExpectedConsultResponse();
            SetOwnerSubmitStatus();
            FirstSubmitView();
        }

        private void SetExpectedConsultResponse()
        {
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                DataGridViewCellEventArgs e = new(0, row.Index);
                setExpectedConsultRspDate(e, SubmitalPhase.first);
                setExpectedConsultRspDate(e, SubmitalPhase.second);
                setExpectedConsultRspDate(e, SubmitalPhase.third);
            }
        }

        private void SetOwnerSubmitStatus()
        {
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                if (row.Cells["ActOwnerSubmitDate"].Value is null && row.Cells["OwnerSubmitalDeadline"].Value is DateTime deadLine)
                {
                    if (deadLine < DateTime.Today.Date)
                    {
                        row.Cells["OwnerSubmitStatus"].Value = DeliveryStatus.Late;
                    }
                    else
                    {
                        row.Cells["OwnerSubmitStatus"].Value = DeliveryStatus.Required;
                    }
                }
            }
        }

        private void RemoveThirdSubmitTrailsScreen(bool firstTime = false)
        {
            if (ISShownThirdSubmital || firstTime)
            {
                this.tabControl1.TabPages.Remove(this.tabPage_ThirdCTRSubmit);
                this.tabControl1.TabPages.Remove(this.tabPage_ConsultThirdResponse);
                ISShownThirdSubmital = false;
            }
        }

        private void RemoveSecondSubmitTrailsScreen(bool firstTime = false)
        {
            if (ISShownSecondSubmital || firstTime)
            {
                this.tabControl1.TabPages.Remove(this.tabPage_SecondCTRSubmit);
                this.tabControl1.TabPages.Remove(this.tabPage_ConsultSecondResponse);
                ISShownSecondSubmital = false;
            }
        }

        private void LoadData()
        {
            using (var context = new AppDBContext())
            {
                var documents = context.Documents.Where(d => d.ProjectId == _project.ProjectId).ToList();
                gridView_ProjectDocs.DataSource = documents;
            }
        }
        private void SetUpColumns()
        {
            SetDateFormat();
            SetupStatusColsFormat();
            //HidePermenantCols();
            //HideSecondSubmits(true);
            //HideThirdSubmits(true);

            renameCols();
        }
        private void SetDateFormat()
        {
            foreach (DataGridViewColumn column in gridView_ProjectDocs.Columns)
            {
                if (column.ValueType == typeof(DateTime?))
                {
                    column.DefaultCellStyle.NullValue = "Click to insert";
                    column.DefaultCellStyle.Format = "d";
                }
            }
        }
        private void SetupStatusColsFormat()
        {
            gridView_ProjectDocs.Columns["FirstCTRSubmitStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["FirstCTRSubmitStatus"].DefaultCellStyle.BackColor = Color.DarkGray;
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].DefaultCellStyle.BackColor = Color.DarkGray;



            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].DefaultCellStyle.BackColor = Color.DarkGray;
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].DefaultCellStyle.BackColor = Color.DarkGray;

            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].DefaultCellStyle.BackColor = Color.DarkGray;
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].DefaultCellStyle.BackColor = Color.DarkGray;

            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].ReadOnly = true;
            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].DefaultCellStyle.BackColor = Color.DarkGray;
        }
        private void renameCols()
        {
            gridView_ProjectDocs.Columns["Name"].ReadOnly = true;
            gridView_ProjectDocs.Columns["Name"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridView_ProjectDocs.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].HeaderText = "Recomended DeadLine Before Handover (Weeks)";
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].HeaderText = "Recomended DeadLine After Handover (Weeks)";

            gridView_ProjectDocs.Columns["SendCopyToOwner"].HeaderText = "Send a copy to Owner to include Facility Management feedback";

            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeadline"].HeaderText = "Actual First Contractor Submittal Deadline";
            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeliveryDate"].HeaderText = "Actual First Contractor Submittal Delivery Date";
            gridView_ProjectDocs.Columns["FirstCTRSubmitStatus"].HeaderText = "First Contractor Submittal Status";
            gridView_ProjectDocs.Columns["ExpFirstConsultRspDate"].HeaderText = "Expected First Consultant Response Date";
            gridView_ProjectDocs.Columns["ActFirstConsultRspDate"].HeaderText = "Actual First Consultant Response Date";
            //gridView_ProjectDocs.Columns["ConsultFirstRspCode"].HeaderText = "First Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].HeaderText = "First Consultant Response Status";


            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeadline"].HeaderText = "Actual Second Contractor Submittal Deadline";
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeliveryDate"].HeaderText = "Actual Second Contractor Submittal Delivery Date";
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].HeaderText = "Second Contractor Submittal Status";
            gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].HeaderText = "Expected Second Consultant Response Date";
            gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].HeaderText = "Actual Second Consultant Response Date";
            //gridView_ProjectDocs.Columns["ConsultSecondRspCode"].HeaderText = "Second Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].HeaderText = "Second Consultant Response Status";


            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeadline"].HeaderText = "Actual Third Contractor Submittal Deadline";
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeliveryDate"].HeaderText = "Actual Third Contractor Submittal Delivery Date";
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].HeaderText = "Third Contractor Submittal Status";
            gridView_ProjectDocs.Columns["ExpThirdConsultRspDate"].HeaderText = "Expected Third Consultant Response Date";
            gridView_ProjectDocs.Columns["ActThirdConsultRspDate"].HeaderText = "Actual Third Consultant Response Date";
            //gridView_ProjectDocs.Columns["ConsultThirdRspCode"].HeaderText = "Third Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].HeaderText = "Third Consultant Response Status";


            gridView_ProjectDocs.Columns["OwnerSubmitalDeadline"].HeaderText = "Deadline";
            gridView_ProjectDocs.Columns["OwnerSubmitalDeadline"].ReadOnly = true;
            gridView_ProjectDocs.Columns["ActOwnerSubmitDate"].HeaderText = "Actual Owner Submittal Date";
            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].HeaderText = "Owner Submittal Status";
            gridView_ProjectDocs.Columns["OwnerSubmitFormat"].HeaderText = "Owner Submittal Format";
            gridView_ProjectDocs.Columns["StoragePlace"].HeaderText = "Physical Storage Place";
            gridView_ProjectDocs.Columns["SoftCopyLink"].HeaderText = "Soft-Copy Link";
            gridView_ProjectDocs.Columns["ReceivedBy"].HeaderText = "Received By";
            gridView_ProjectDocs.Columns["SoftCopyFormat"].HeaderText = "Soft-Copy Format";



            gridView_ProjectDocs.Columns["RetentionWeight"].HeaderText = "Retention Weight";
            gridView_ProjectDocs.Columns["Retention"].HeaderText = "Retention (% from total project value)";
            gridView_ProjectDocs.Columns["Retention"].ReadOnly = true;
            gridView_ProjectDocs.Columns["Deduction"].HeaderText = "Deduction (% from total project value)";
            gridView_ProjectDocs.Columns["Deduction"].ReadOnly = true;
        }
        private void AddComboBoxColumns()
        {

            var subCodeList = Enum.GetValues(typeof(ResponseCode)).Cast<ResponseCode>().ToList();

            firstRspCodeCombBoxCol.HeaderText = "First Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultFirstRspCode"].Index, firstRspCodeCombBoxCol);



            secondRspCodeCombBoxCol.HeaderText = "Second Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Index, secondRspCodeCombBoxCol);



            thirdRspCodeCombBoxCol.HeaderText = "Third Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Index, thirdRspCodeCombBoxCol);



            var comboBoxColumns = new List<DataGridViewComboBoxColumn> { firstRspCodeCombBoxCol, secondRspCodeCombBoxCol, thirdRspCodeCombBoxCol };

            foreach (var col in comboBoxColumns)
            {
                col.ValueType = typeof(ResponseCode);
                col.DataSource = subCodeList.
                    Select(s => new
                    {
                        Display = s.ToDescriptionString(),
                        Value = s
                    }).ToList();
                col.DisplayMember = "Display";
                col.ValueMember = "Value";
            }
            firstRspCodeCombBoxCol.DataPropertyName = "ConsultFirstRspCode";
            firstRspCodeCombBoxCol.Name = "ConsultFirstRspCode";
            secondRspCodeCombBoxCol.DataPropertyName = "ConsultSecondRspCode";
            secondRspCodeCombBoxCol.Name = "ConsultSecondRspCode";
            thirdRspCodeCombBoxCol.DataPropertyName = "ConsultThirdRspCode";
            thirdRspCodeCombBoxCol.Name = "ConsultThirdRspCode";

            submitalFormatCol.HeaderText = "Owner Submittal Format";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["OwnerSubmitFormat"].Index, submitalFormatCol);
            submitalFormatCol.ValueType = typeof(SubmitalFormat);
            var subFormatList = Enum.GetValues(typeof(SubmitalFormat)).Cast<SubmitalFormat>().ToList();
            submitalFormatCol.DataSource = subFormatList.Select(s => new
            {
                Display = s.ToDescriptionString(),
                Value = s
            }).ToList();
            submitalFormatCol.DisplayMember = "Display";
            submitalFormatCol.ValueMember = "Value";
            submitalFormatCol.DataPropertyName = "OwnerSubmitFormat";
            submitalFormatCol.Name = "OwnerSubmitFormat";

            sendCopyCombBoxCol.HeaderText = "Send a copy to Owner to include Facility Management feedback";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["SendCopyToOwner"].Index, sendCopyCombBoxCol);
            sendCopyCombBoxCol.ValueType = typeof(SendCopy);
            var sendCopyFormatList = Enum.GetValues(typeof(SendCopy)).Cast<SendCopy>().ToList();
            sendCopyCombBoxCol.DataSource = sendCopyFormatList.Select(s => new
            {
                Display = s.ToDescriptionString(),
                Value = s
            }).ToList();
            sendCopyCombBoxCol.DisplayMember = "Display";
            sendCopyCombBoxCol.ValueMember = "Value";
            sendCopyCombBoxCol.DataPropertyName = "SendCopyToOwner";
            sendCopyCombBoxCol.Name = "SendCopyToOwner";
        }
        private void SetSubmitColsVisibility()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[firstRspCodeCombBoxCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());


            if (isResubmitAsPerNotedPresent)
            {
                ShowSecondSubmital = true;
                InsertSecondSubmitTrailScreen();
                //HideSecondSubmits(false);
                SetSecondSubmitColVisibilty();
            }
            else
            {
                ShowSecondSubmital = false;
                ShowThirdSubmital = false;
                RemoveSecondSubmitTrailsScreen();
                RemoveThirdSubmitTrailsScreen();
                //ChangeSecondTrailtoNull();
                //ChangeThirdTrailtoNull();
                //HideSecondSubmits(true);
                //HideThirdSubmits(true);
            }

            var firstRowList = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()?.ToList();
            if (firstRowList is not null)
            {
                foreach (DataGridViewRow row in firstRowList)
                {
                    var e = new DataGridViewCellEventArgs(firstRspCodeCombBoxCol.Index, row.Index);
                    SetSubmitColsValues(new object(), e, false);
                    var x = new DataGridViewCellEventArgs(secondRspCodeCombBoxCol.Index, row.Index);
                    SetSubmitColsValues(new object(), x, true);
                }
            }
        }
        private void SetSecondSubmitColVisibilty()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[secondRspCodeCombBoxCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());
            if (isResubmitAsPerNotedPresent)
            {
                ShowThirdSubmital = true;
                InsertThirdSubmitTrailScreen();
                //HideThirdSubmits(false);
                //InsertThirdTrail();
            }
            else
            {
                RemoveThirdSubmitTrailsScreen();
                //ChangeThirdTrailtoNull();
                ShowThirdSubmital = false;
                //HideThirdSubmits(true);
            }
        }

        private void SetSubmitColsValues(object? sender, DataGridViewCellEventArgs e, bool thirdOnly)
        {
            var defColor = gridView_ProjectDocs.Rows[e.RowIndex].Cells["Name"].Style.BackColor;
            var cellValue = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            bool isResubmitAsPerNoted = (cellValue?.ToString() ?? String.Empty) == ResponseCode.ResubmitAsPerNoted.ToString();
            var secondTrailcells = new List<DataGridViewCell>()
                    {
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeadline"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeliveryDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["SecondCTRSubmitStatus"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpSecondConsultRspDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondConsultRspDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultSecondRspCode"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells[secondRspCodeCombBoxCol.Index],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultSecondRspStatus"]
                    };
            var thirdTrailcells = new List<DataGridViewCell>()
                    {
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeadline"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeliveryDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ThirdCTRSubmitStatus"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpThirdConsultRspDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdConsultRspDate"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultThirdRspCode"],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells[thirdRspCodeCombBoxCol.Index],
                        gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultThirdRspStatus"]
                    };
            if (!isResubmitAsPerNoted)
            {

                if (thirdOnly == false) // work on second too
                {
                    foreach (var cell in secondTrailcells)
                    {
                        cell.ReadOnly = true;
                        cell.Style.BackColor = Color.DarkGray;
                    }
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeadline"].Value = null;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeliveryDate"].Value = null;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["SecondCTRSubmitStatus"].Value = DeliveryStatus.NotSet;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpSecondConsultRspDate"].Value = null;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondConsultRspDate"].Value = null;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultSecondRspCode"].Value = ResponseCode.NotSet;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells[secondRspCodeCombBoxCol.Index].Value = ResponseCode.NotSet;
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultSecondRspStatus"].Value = ResponseStatus.NotSet;

                }
                // work on third
                foreach (var cell in thirdTrailcells)
                {
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.DarkGray;
                }
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeadline"].Value = null;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeliveryDate"].Value = null;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ThirdCTRSubmitStatus"].Value = DeliveryStatus.NotSet;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpThirdConsultRspDate"].Value = null;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdConsultRspDate"].Value = null;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultThirdRspCode"].Value = ResponseCode.NotSet;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells[thirdRspCodeCombBoxCol.Index].Value = ResponseCode.NotSet;
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["ConsultThirdRspStatus"].Value = ResponseStatus.NotSet;

            }
            if (isResubmitAsPerNoted)
            {

                if (thirdOnly == false) // work on second too
                {
                    foreach (var cell in secondTrailcells)
                    {
                        cell.ReadOnly = false;
                        cell.Style.BackColor = defColor;
                    }

                    //Second Dates
                    SetActualExtraSubmitDeadline(e, second: true);
                }
                // work on third
                foreach (var cell in thirdTrailcells)
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = defColor;
                }
                //ThirdDate
                SetActualExtraSubmitDeadline(e, second: false);
            }
        }
        private void SetSubmitStatusColumn(SubmitalPhase submitalPhase)
        {
            var deadLineColName = string.Empty;
            var deliveryColName = string.Empty;
            var statusColName = string.Empty;
            switch (submitalPhase)
            {
                case SubmitalPhase.first:
                    deadLineColName = "ActFirstCTRSubmitDeadline";
                    deliveryColName = "ActFirstCTRSubmitDeliveryDate";
                    statusColName = "FirstCTRSubmitStatus";
                    break;
                case SubmitalPhase.second:
                    deadLineColName = "ActSecondCTRSubmitDeadline";
                    deliveryColName = "ActSecondCTRSubmitDeliveryDate";
                    statusColName = "SecondCTRSubmitStatus";
                    break;
                case SubmitalPhase.third:
                    deadLineColName = "ActThirdCTRSubmitDeadline";
                    deliveryColName = "ActThirdCTRSubmitDeliveryDate";
                    statusColName = "ThirdCTRSubmitStatus";
                    break;
                default:
                    break;
            }
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                var deadlineCellValue = row.Cells[deadLineColName].Value;
                var deliveryDateCellValue = row.Cells[deliveryColName].Value;

                if (deadlineCellValue is null)
                {
                    row.Cells[statusColName].Value = DeliveryStatus.NotSet;
                }
                else
                {
                    if (deliveryDateCellValue == null)
                    {
                        if ((DateTime)deadlineCellValue >= DateTime.Today)
                        {
                            row.Cells[statusColName].Value = DeliveryStatus.Required;
                        }
                        else
                        {
                            row.Cells[statusColName].Value = DeliveryStatus.Late;
                        }
                    }

                    else if ((DateTime)deadlineCellValue >= (DateTime)deliveryDateCellValue)
                    {
                        row.Cells[statusColName].Value = DeliveryStatus.DeliveredOnTime;
                    }
                    else if ((DateTime)deadlineCellValue < (DateTime)deliveryDateCellValue)
                    {
                        row.Cells[statusColName].Value = DeliveryStatus.DeliveredLate;
                    }
                }
            }
        }
        private void SetResponseStatusColumn(SubmitalPhase submitalPhase)
        {
            var expectedColName = string.Empty;
            var actualColName = string.Empty;
            var statusColName = string.Empty;
            switch (submitalPhase)
            {
                case SubmitalPhase.first:
                    expectedColName = "ExpFirstConsultRspDate";
                    actualColName = "ActFirstConsultRspDate";
                    statusColName = "ConsultFirstRspStatus";
                    break;
                case SubmitalPhase.second:
                    expectedColName = "ExpSecondConsultRspDate";
                    actualColName = "ActSecondConsultRspDate";
                    statusColName = "ConsultSecondRspStatus";
                    break;
                case SubmitalPhase.third:
                    expectedColName = "ExpThirdConsultRspDate";
                    actualColName = "ActThirdConsultRspDate";
                    statusColName = "ConsultThirdRspStatus";
                    break;
                default:
                    break;
            }
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                var expectedCellValue = row.Cells[expectedColName].Value;
                var actualCellValue = row.Cells[actualColName].Value;

                if (expectedCellValue is null)
                {
                    row.Cells[statusColName].Value = ResponseStatus.NotSet;
                }
                else
                {
                    if (actualCellValue == null)
                    {
                        if ((DateTime)expectedCellValue >= DateTime.Today)
                        {
                            row.Cells[statusColName].Value = ResponseStatus.Required;
                        }
                        else
                        {
                            row.Cells[statusColName].Value = ResponseStatus.Late;
                        }
                    }

                    else if ((DateTime)expectedCellValue >= (DateTime)actualCellValue)
                    {
                        row.Cells[statusColName].Value = ResponseStatus.RespondedOnTime;
                    }
                    else if ((DateTime)expectedCellValue < (DateTime)actualCellValue)
                    {
                        row.Cells[statusColName].Value = ResponseStatus.RespondedLate;
                    }
                }
            }
        }


        private void GridView_ProjectDocs_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var columnName = gridView_ProjectDocs.Columns[e.ColumnIndex].Name;
            if (columnName == "RcmdDeadlineAfterHandover" || columnName == "RcmdDeadlineBeforeHandover")
            {
                if (e.Value == null)
                {
                    e.CellStyle.BackColor = Color.DarkGray;
                }
            }
            if (e.Value is ResponseStatus)
            {
                var value = (ResponseStatus)e.Value;
                var cell = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var backColor = value switch
                {
                    ResponseStatus.RespondedOnTime => Color.LightGreen,
                    ResponseStatus.RespondedLate or ResponseStatus.Late => Color.OrangeRed,
                    ResponseStatus.Required => Color.LightYellow,
                    _ => Color.DarkGray
                };
                cell.Style.BackColor = backColor;
                e.Value = value.ToDescriptionString();
            }
            if (e.Value is DeliveryStatus)
            {
                var value = (DeliveryStatus)e.Value;
                var cell = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];

                var backColor = value switch
                {
                    DeliveryStatus.DeliveredOnTime => Color.LightGreen,
                    DeliveryStatus.DeliveredLate or DeliveryStatus.Late => Color.OrangeRed,
                    DeliveryStatus.Required => Color.LightYellow,
                    _ => Color.DarkGray
                };

                e.Value = value.ToDescriptionString();
                cell.Style.BackColor = backColor;
            }
        }
        private void GridView_ProjectDocs_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumKeyPress);
            if (gridView_ProjectDocs.CurrentCell.ColumnIndex == gridView_ProjectDocs.Columns["Retention"].Index
                || gridView_ProjectDocs.CurrentCell.ColumnIndex == gridView_ProjectDocs.Columns["Deduction"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(WholeNumKeyPress);
                }
            }
            if (gridView_ProjectDocs.CurrentCell.ColumnIndex == gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].Index
               || gridView_ProjectDocs.CurrentCell.ColumnIndex == gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(NumKeyPress);
                }

            }
            if (gridView_ProjectDocs.CurrentCell is DataGridViewComboBoxCell)
            {
                var comboBox = e.Control as ComboBox;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.FlatStyle = FlatStyle.Flat;

            }
        }
        private void GridView_ProjectDocs_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var columnName = gridView_ProjectDocs.Columns[e.ColumnIndex].Name;
            if (columnName == "RcmdDeadlineAfterHandover" || columnName == "RcmdDeadlineBeforeHandover")
            {
                if (int.TryParse(gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out int result))
                {
                    ToggleColumnsEnableState(sender, e);
                }
                if (columnName == "RcmdDeadlineBeforeHandover")
                {
                    SetActualFirstSubmitDeadline(e, before: true);
                    SetOwnerDeadlineDate(e, before: true);
                }
                else
                {
                    SetActualFirstSubmitDeadline(e, before: false);
                    SetOwnerDeadlineDate(e, before: false);
                }
            }
            else if (columnName == firstRspCodeCombBoxCol.Name)
            {
                SetSubmitColsVisibility();
                SetSubmitColsValues(sender, e, thirdOnly: false);

            }
            else if (columnName == secondRspCodeCombBoxCol.Name)
            {
                SetSecondSubmitColVisibilty();
                SetSubmitColsValues(sender, e, thirdOnly: true);

            }
            else if (columnName == thirdRspCodeCombBoxCol.Name)
            {
                handleMaxSubmitTrails(sender, e);
            }
            else if (columnName == "ActFirstCTRSubmitDeadline" || columnName == "ActFirstCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.first);
                if (columnName == "ActFirstCTRSubmitDeliveryDate")
                {
                    setExpectedConsultRspDate(e, SubmitalPhase.first);
                }
            }
            else if (columnName == "ActSecondCTRSubmitDeadline" || columnName == "ActSecondCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.second);
                if (columnName == "ActSecondCTRSubmitDeliveryDate")
                {
                    setExpectedConsultRspDate(e, SubmitalPhase.second);
                }
            }
            else if (columnName == "ActThirdCTRSubmitDeadline" || columnName == "ActThirdCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.third);
                if (columnName == "ActThirdCTRSubmitDeliveryDate")
                {
                    setExpectedConsultRspDate(e, SubmitalPhase.third);
                }
            }
            else if (columnName == "ActFirstConsultRspDate" || columnName == "ExpFirstConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.first);
                bool isResubmit = (gridView_ProjectDocs.Rows[e.RowIndex].Cells[firstRspCodeCombBoxCol.Index].Value?.ToString() ?? String.Empty) == ResponseCode.ResubmitAsPerNoted.ToString();
                if (columnName == "ActFirstConsultRspDate" && isResubmit)
                {
                    SetActualExtraSubmitDeadline(e, second: true);
                }
            }
            else if (columnName == "ActSecondConsultRspDate" || columnName == "ExpSecondConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.second);
                bool isResubmit = (gridView_ProjectDocs.Rows[e.RowIndex].Cells[secondRspCodeCombBoxCol.Index].Value?.ToString() ?? String.Empty) == ResponseCode.ResubmitAsPerNoted.ToString();
                if (columnName == "ActFirstConsultRspDate" && isResubmit)
                {
                    SetActualExtraSubmitDeadline(e, second: false);
                }
            }
            else if (columnName == "ActThirdConsultRspDate" || columnName == "ExpThirdConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.third);
            }
            else if (columnName == "ActOwnerSubmitDate")
            {
                SetSbmitToOwnerStatus(sender, e);
            }
            else if (columnName == "Retention")
            {
                CalculateTotalRetention();
            }
            else if (columnName == "RetentionWeight")
            {
                CalculateRetentions(e);
            }
            else if (columnName == "Deduction")
            {
                CalculateTotalDeductions();
            }
        }

        private void CalculateRetentions(DataGridViewCellEventArgs e)
        {
            decimal totalWeights = 0;
            decimal totalRetentions = 0;
            decimal maxRetention = _project.RetentionforDocumentsDelivery;
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                totalWeights += (decimal)row.Cells["RetentionWeight"].Value;
            }
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                decimal retentionValue = 0;
                decimal retentionValueDisplayed = 0;
                try
                {
                    retentionValue = ((decimal)row.Cells[e.ColumnIndex].Value * maxRetention) / (totalWeights);
                    retentionValueDisplayed = Math.Round(retentionValue, 2, MidpointRounding.ToEven);
                }
                finally
                {
                    row.Cells["Retention"].Value = retentionValueDisplayed;
                    totalRetentions += retentionValue;
                }
            }
        }

        private void SetOwnerDeadlineDate(DataGridViewCellEventArgs e, bool before)
        {
            if (before)
            {
                gridView_ProjectDocs.Rows[e.RowIndex].Cells["OwnerSubmitalDeadline"].Value = _project.PlannedEndDate.Date;
            }
            else
            {
                if (gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActFirstCTRSubmitDeadline"].Value is DateTime actFirstCTRSubmitDeadline)
                {
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["OwnerSubmitalDeadline"].Value = actFirstCTRSubmitDeadline.AddDays(2 * _project.ConsultantReviewTimeInDays).Date;
                }
            }
            SetOwnerSubmitStatus();
        }

        private void setExpectedConsultRspDate(DataGridViewCellEventArgs e, SubmitalPhase phase)
        {
            if (phase == SubmitalPhase.first)
            {
                var firstCTRDeliveryDate = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActFirstCTRSubmitDeliveryDate"].Value;
                if (firstCTRDeliveryDate is DateTime deliveryDate)
                {
                    var expectedFirstRspDate = deliveryDate.AddDays(_project.ConsultantReviewTimeInDays);
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpFirstConsultRspDate"].Value = expectedFirstRspDate;
                }
            }
            else if (phase == SubmitalPhase.second)
            {
                var secondCTRDeliveryDate = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeliveryDate"].Value;
                if (secondCTRDeliveryDate is DateTime deliveryDate)
                {
                    var expectedSecondRspDate = deliveryDate.AddDays(_project.ConsultantReviewTimeInDays);
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpSecondConsultRspDate"].Value = expectedSecondRspDate;
                }
            }
            else if (phase == SubmitalPhase.third)
            {
                var thirdCTRDeliveryDate = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeliveryDate"].Value;
                if (thirdCTRDeliveryDate is DateTime deliveryDate)
                {
                    var expectedThirdRspDate = deliveryDate.AddDays(_project.ConsultantReviewTimeInDays);
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ExpThirdConsultRspDate"].Value = expectedThirdRspDate;
                }
            }
        }

        private void SetActualExtraSubmitDeadline(DataGridViewCellEventArgs e, bool second)
        {
            if (second)
            {
                var firstConsultResponse = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActFirstConsultRspDate"].Value;
                if (firstConsultResponse is not null && firstConsultResponse is DateTime rspDate)
                {
                    var secondDeadLine = rspDate.AddDays(7);
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondCTRSubmitDeadline"].Value = secondDeadLine;
                }
            }
            else
            {
                var secondConsultResponse = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActSecondConsultRspDate"].Value;
                if (secondConsultResponse is not null && secondConsultResponse is DateTime rspDate)
                {
                    var thirdDeadLine = rspDate.AddDays(7);
                    gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActThirdCTRSubmitDeadline"].Value = thirdDeadLine;
                }
            }
        }

        private void SetActualFirstSubmitDeadline(DataGridViewCellEventArgs e, bool before)
        {
            var deadLine = gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActFirstCTRSubmitDeadline"].Value;
            if (before)
            {
                var timeBefore = gridView_ProjectDocs.Rows[e.RowIndex].Cells["RcmdDeadlineBeforeHandover"].Value;
                if (timeBefore != null && timeBefore is int weeks)
                {
                    deadLine = _project.PlannedEndDate.AddDays(-weeks * 7);
                }
            }
            else
            {
                var timeAfter = gridView_ProjectDocs.Rows[e.RowIndex].Cells["RcmdDeadlineAfterHandover"].Value;
                if (timeAfter != null && timeAfter is int weeks)
                {
                    deadLine = _project.PlannedEndDate.AddDays(weeks * 7);
                }
            }
            gridView_ProjectDocs.Rows[e.RowIndex].Cells["ActFirstCTRSubmitDeadline"].Value = deadLine;

        }

        private void SetSbmitToOwnerStatus(object? sender, DataGridViewCellEventArgs e)
        {
            var row = gridView_ProjectDocs.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (row.Cells["OwnerSubmitalDeadline"].Value is DateTime deadLine && cell.Value != null)
            {
                if ((DateTime)cell.Value > deadLine)
                {
                    row.Cells["OwnerSubmitStatus"].Value = DeliveryStatus.DeliveredLate;
                }
                else if ((DateTime)cell.Value <= deadLine)
                {
                    row.Cells["OwnerSubmitStatus"].Value = DeliveryStatus.DeliveredOnTime;
                }
            }
            else if (cell.Value == null)
            {
                row.Cells["OwnerSubmitStatus"].Value = DeliveryStatus.Required;
            }
        }

        private void handleMaxSubmitTrails(object? sender, DataGridViewCellEventArgs e)
        {
            var columnName = gridView_ProjectDocs.Columns[e.ColumnIndex].Name;
            var cell = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && columnName == thirdRspCodeCombBoxCol.Name
               && (ResponseCode)cell.Value == ResponseCode.ResubmitAsPerNoted)
            {
                MessageBox.Show("Error: ResubmitAsPerNoted is not allowed in the third submit," +
                    " Max trails of document submit is [Three times].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cell.Value = ResponseCode.ApprovedAsSubmitted;
            }
        }

        private void GridView_ProjectDocs_Scroll(object? sender, ScrollEventArgs e)
        {
            _dtp.Visible = false;
        }
        private void GridView_ProjectDocs_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;
            var colIndex = gridView_ProjectDocs.Columns[e.ColumnIndex];
            try
            {
                if (colIndex is DataGridViewTextBoxColumn && colIndex.ValueType == typeof(DateTime?))
                {
                    _clickedCell = gridView_ProjectDocs[e.ColumnIndex, e.RowIndex];
                    ShowDateTimePicker(_clickedCell);
                }
            }
            catch (Exception)
            {
                // Handle any specific exception here
            }
        }

        private void ToggleColumnsEnableState(object? sender, DataGridViewCellEventArgs e)
        {
            var afterHandoverColumn = gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"];
            var beforeHandoverColumn = gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"];

            if (e.ColumnIndex != afterHandoverColumn.Index && e.ColumnIndex != beforeHandoverColumn.Index) return;

            var row = gridView_ProjectDocs.Rows[e.RowIndex];
            var afterHandoverCell = row.Cells[afterHandoverColumn.Index];
            var beforeHandoverCell = row.Cells[beforeHandoverColumn.Index];

            var isAfterHandoverColumn = e.ColumnIndex == afterHandoverColumn.Index;
            var isBeforeHandoverColumn = e.ColumnIndex == beforeHandoverColumn.Index;

            if (!string.IsNullOrEmpty(afterHandoverCell.EditedFormattedValue?.ToString()) ||
                !string.IsNullOrEmpty(beforeHandoverCell.EditedFormattedValue?.ToString()))
            {
                if (isAfterHandoverColumn)
                {
                    afterHandoverCell.Style.BackColor = gridView_ProjectDocs.DefaultCellStyle.BackColor;
                    beforeHandoverCell.Value = null;
                    beforeHandoverCell.Style.BackColor = Color.DarkGray;
                }
                else if (isBeforeHandoverColumn)
                {
                    beforeHandoverCell.Style.BackColor = gridView_ProjectDocs.DefaultCellStyle.BackColor;
                    afterHandoverCell.Value = null;
                    afterHandoverCell.Style.BackColor = Color.DarkGray;
                }
            }
        }
        private void _dtp_TextChanged(object? sender, EventArgs e)
        {
            this.gridView_ProjectDocs.CurrentCell.Value = _dtp.Value;
        }
        private void WholeNumKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox)?.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void NumKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //don't delete
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _dtp.Visible = false;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ShowDateTimePicker(DataGridViewCell cell)
        {
            if (!cell.ReadOnly)
            {
                var cellRectangle = gridView_ProjectDocs.
                    GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                _dtp.Size = new Size(cellRectangle.Width, cellRectangle.Height);
                _dtp.Location = new Point(cellRectangle.X, cellRectangle.Y);
                _dtp.Visible = true;
            }
        }

        private void TabControl1_Selected(object? sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage_FirstCTRSubmit)
            {
                FirstSubmitView();
            }
            else if (e.TabPage == tabPage_ConsultFirstResponse)
            {
                FirstResponseView();
            }
            else if (e.TabPage == tabPage_SecondCTRSubmit)
            {
                SecondSubmitView();
            }
            else if (e.TabPage == tabPage_ConsultSecondResponse)
            {
                SecondResponseView();
            }
            else if (e.TabPage == tabPage_ThirdCTRSubmit)
            {
                ThirdSubmitView();
            }
            else if (e.TabPage == tabPage_ConsultThirdResponse)
            {
                ThirdResponseView();
            }
            else if (e.TabPage == tabPage_SubmitToOwner)
            {
                OwnerSubmitView();
            }
            else if (e.TabPage == tabPage_Retentions)
            {
                RetentionsDeductionsView();
            }
        }

        //Views

        private void HideAllColumns()
        {
            foreach (DataGridViewColumn col in gridView_ProjectDocs.Columns)
            {
                col.Visible = false;
            }
            _dtp.Visible = false;
        }

        //First Submit 
        private void FirstSubmitView()
        {
            HideAllColumns();
            ShowFirstSubmitContent(true);
        }
        private void ShowFirstSubmitContent(bool show)
        {
            tabControl1.SelectTab("tabPage_FirstCTRSubmit");
            gridView_ProjectDocs.Columns["Name"].Visible = show;
            gridView_ProjectDocs.Columns["Description"].Visible = show;
            gridView_ProjectDocs.Columns["SendCopyToOwner"].Visible = show;
            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].Visible = show;
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].Visible = show;
            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeadline"].Visible = show;
            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeliveryDate"].Visible = show;
            gridView_ProjectDocs.Columns["FirstCTRSubmitStatus"].Visible = show;
        }

        //First Response
        private void FirstResponseView()
        {
            HideAllColumns();
            ShowFirstResponseContent(true);
        }
        private void ShowFirstResponseContent(bool show)
        {
            tabControl1.SelectTab("tabPage_ConsultFirstResponse");
            gridView_ProjectDocs.Columns["Name"].Visible = true;
            gridView_ProjectDocs.Columns["ExpFirstConsultRspDate"].Visible = show;
            gridView_ProjectDocs.Columns["ActFirstConsultRspDate"].Visible = show;
            firstRspCodeCombBoxCol.Visible = show;
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].Visible = show;
        }

        //Second Submit
        private void SecondSubmitView()
        {
            HideAllColumns();
            ShowSecondSubmitContent(true);
        }
        private void ShowSecondSubmitContent(bool show)
        {
            tabControl1.SelectTab("tabPage_SecondCTRSubmit");
            gridView_ProjectDocs.Columns["Name"].Visible = show;
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeadline"].Visible = show;
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeliveryDate"].Visible = show;
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].Visible = show;

        }

        //Second Response
        private void SecondResponseView()
        {
            HideAllColumns();
            ShowSecondResponseContent(true);
        }
        private void ShowSecondResponseContent(bool show)
        {
            tabControl1.SelectTab("tabPage_ConsultSecondResponse");
            gridView_ProjectDocs.Columns["Name"].Visible = true;
            gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].Visible = show;
            gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].Visible = show;
            secondRspCodeCombBoxCol.Visible = show;
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].Visible = show;
        }

        //Third Submit
        private void ThirdSubmitView()
        {
            HideAllColumns();
            ShowThirdSubmitContent(true);
        }
        private void ShowThirdSubmitContent(bool show)
        {
            tabControl1.SelectTab("tabPage_ThirdCTRSubmit");
            gridView_ProjectDocs.Columns["Name"].Visible = show;
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeadline"].Visible = show;
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeliveryDate"].Visible = show;
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].Visible = show;
        }

        //Third Response
        private void ThirdResponseView()
        {
            HideAllColumns();
            ShowThirdResponseContent(true);
        }
        private void ShowThirdResponseContent(bool show)
        {
            tabControl1.SelectTab("tabPage_ConsultThirdResponse");
            gridView_ProjectDocs.Columns["Name"].Visible = true;
            gridView_ProjectDocs.Columns["ExpThirdConsultRspDate"].Visible = show;
            gridView_ProjectDocs.Columns["ActThirdConsultRspDate"].Visible = show;
            thirdRspCodeCombBoxCol.Visible = show;
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].Visible = show;
        }

        //Owner Submit
        private void OwnerSubmitView()
        {
            HideAllColumns();
            ShowOwnerContent(true);
        }
        private void ShowOwnerContent(bool show)
        {
            tabControl1.SelectTab("tabPage_SubmitToOwner");
            gridView_ProjectDocs.Columns["Name"].Visible = true;
            gridView_ProjectDocs.Columns["OwnerSubmitalDeadline"].Visible = show;
            gridView_ProjectDocs.Columns["OwnerSubmitalDeadline"].DefaultCellStyle.NullValue = null;
            gridView_ProjectDocs.Columns["ActOwnerSubmitDate"].Visible = show;
            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].Visible = show;
            submitalFormatCol.Visible = show;
            gridView_ProjectDocs.Columns["StoragePlace"].Visible = show;
            gridView_ProjectDocs.Columns["SoftCopyFormat"].Visible = show;
            gridView_ProjectDocs.Columns["SoftCopyLink"].Visible = show;
            gridView_ProjectDocs.Columns["Comment"].Visible = show;
            gridView_ProjectDocs.Columns["ReceivedBy"].Visible = show;
        }

        //Retentions-Deductions View
        private void RetentionsDeductionsView()
        {
            HideAllColumns();
            ShowRetentionsDeductionsContent(true);
        }

        private void ShowRetentionsDeductionsContent(bool show)
        {
            tabControl1.SelectTab("tabPage_Retentions");
            gridView_ProjectDocs.Columns["Name"].Visible = true;
            gridView_ProjectDocs.Columns["RetentionWeight"].Visible = show;
            gridView_ProjectDocs.Columns["Retention"].Visible = show;
            gridView_ProjectDocs.Columns["Deduction"].Visible = show;
            CalculateTotalRetention();
            CalculateTotalDeductions();
        }


        //Events

        //First Submit
        private void btn_FirstCTRCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_FirstCTRNext_Click(object sender, EventArgs e)
        {
            FirstResponseView();
        }

        //First Response
        private void btn_FirstResponseBack_Click(object sender, EventArgs e)
        {
            FirstSubmitView();
        }
        private void btn_FirstResponseNext_Click(object sender, EventArgs e)
        {
            if (ShowSecondSubmital)
            {
                InsertSecondSubmitTrailScreen();

                SecondSubmitView();
            }
            else
            {
                OwnerSubmitView();
            }

        }

        //Second Submit
        private void btn_SecondCTRBack_Click(object sender, EventArgs e)
        {
            FirstResponseView();
        }
        private void btn_SecondCTRNext_Click(object sender, EventArgs e)
        {
            SecondResponseView();
        }

        //Second Response
        private void btn_SecondResponseBack_Click(object sender, EventArgs e)
        {
            SecondSubmitView();
        }
        private void btn_SecondResponseNext_Click(object sender, EventArgs e)
        {
            if (ShowThirdSubmital)
            {
                InsertThirdSubmitTrailScreen();

                ThirdSubmitView();
            }
            else
            {
                OwnerSubmitView();
            }
        }

        //Third Submit
        private void btn_ThirdCTRBack_Click(object sender, EventArgs e)
        {
            SecondResponseView();
        }
        private void btn_ThirdCTRSubmit_Click(object sender, EventArgs e)
        {
            ThirdResponseView();
        }

        //Third Response
        private void btn_ThirdResponseBack_Click(object sender, EventArgs e)
        {
            ThirdSubmitView();
        }
        private void btn_ThirdResponseNext_Click(object sender, EventArgs e)
        {
            OwnerSubmitView();
        }

        //Owner Submit
        private void btn_OwnerSubmitBack_Click(object sender, EventArgs e)
        {
            if (ISShownThirdSubmital)
            {
                ThirdResponseView();
            }
            else if (ISShownSecondSubmital)
            {
                SecondResponseView();
            }
            else
            {
                FirstResponseView();
            }

        }
        private void btn_OwnerSubmitNext_Click(object sender, EventArgs e)
        {
            RetentionsDeductionsView();
        }

        //Retentions Submit
        private void btn_RetDedBack_Click(object sender, EventArgs e)
        {
            OwnerSubmitView();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //Save To DB
            SaveToDB();
        }

        //Helpers
        private void InsertSecondSubmitTrailScreen()
        {
            if (!ISShownSecondSubmital)
            {
                this.tabControl1.TabPages.Insert(2, this.tabPage_SecondCTRSubmit);
                this.tabControl1.TabPages.Insert(3, this.tabPage_ConsultSecondResponse);
                ISShownSecondSubmital = true;
            }
        }
        private void InsertThirdSubmitTrailScreen()
        {
            if (!ISShownThirdSubmital)
            {
                this.tabControl1.TabPages.Insert(4, this.tabPage_ThirdCTRSubmit);
                this.tabControl1.TabPages.Insert(5, this.tabPage_ConsultThirdResponse);
                ISShownThirdSubmital = true;
            }
        }
        private void CalculateTotalRetention()
        {
            decimal totalRetention = 0;
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                var retention = row.Cells["Retention"].Value;
                if (retention is not null && retention is decimal retentionValue)
                {
                    totalRetention += retentionValue;
                }
                if (totalRetention != _project.RetentionforDocumentsDelivery && totalRetention != 0)
                {
                    totalRetention = _project.RetentionforDocumentsDelivery;
                    //MessageBox.Show("Retention value can't be more than Project max retention value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //lbl_TotalRetentions.Text = "N.A";
                    //return;
                }
            }
            lbl_TotalRetentions.Text = totalRetention.ToString();
        }
        private void CalculateTotalDeductions()
        {
            decimal totalDeduction = 0;
            foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
            {
                var deduction = row.Cells["Deduction"].Value;
                if (deduction is not null && deduction is decimal deductionValue)
                {
                    totalDeduction += deductionValue;
                }
                if (totalDeduction >= 100)
                {
                    MessageBox.Show("Deduction value can't be more than Project value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lbl_TotalDeductions.Text = "N.A";
                    return;
                }
            }
            lbl_TotalDeductions.Text = totalDeduction.ToString();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save Changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SaveToDB();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            frm_NewProject frm_newProject = new();
            this.Close();
            if (!IsCanceledClose)
            {
                this.Hide();
                frm_newProject.ShowDialog();
            }
        }
        private void SaveToDB()
        {
            using (var context = new AppDBContext())
            {
                try
                {
                    // Attach the modified entities to the context
                    foreach (DataGridViewRow row in gridView_ProjectDocs.Rows)
                    {
                        if (row.DataBoundItem is Document document)
                        {
                            context.Documents.Attach(document);
                            context.Entry(document).State = EntityState.Modified;
                        }
                    }

                    // Save the changes to the database
                    context.SaveChanges();

                    // Optionally, display a success message
                    MessageBox.Show("Data saved successfully to the database.");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the database operation
                    MessageBox.Show($"An error occurred: {ex.InnerException.Message}");
                    MessageBox.Show($"Data not saved, Changes ignored");
                }
            }
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save Changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SaveToDB();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            frm_ProjectList projectListForm = new frm_ProjectList();
            this.Close();
            if (!IsCanceledClose)
            {
                this.Hide();
                projectListForm.ShowDialog();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToDB();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save Changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SaveToDB();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            frm_SaveAs frm_SaveAs = new frm_SaveAs(_project);
            this.Close();
            if (!IsCanceledClose)
            {
                this.Hide();
                frm_SaveAs.ShowDialog();

            }
        }

        private void editProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save Changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);

            if (result == DialogResult.Yes)
            {
                SaveToDB();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            frm_EditProject frmEditProject = new(_project);
            this.Close();
            if (!IsCanceledClose)
            {
                this.Hide();
                frmEditProject.ShowDialog();
            }
        }

        private void exportAsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save Changes?", "Warning", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SaveToDB();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            Report report = new Report(_project.ProjectId);
            report.GenerateReport();
        }

    }
}