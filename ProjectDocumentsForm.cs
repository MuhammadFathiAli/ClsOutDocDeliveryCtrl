using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
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

        private Project _project;
        private DataGridViewCell _clickedCell;
        private DateTimePicker _dtp;
        private DataGridViewComboBoxColumn firstStatusCol;
        private DataGridViewComboBoxColumn secondStatusCol;
        private DataGridViewComboBoxColumn thirdStatusCol;
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
            tabControl1.Selected += TabControl1_Selected;
            FormClosing += ProjectDocumentsForm_FormClosing;
            gridView_ProjectDocs.Visible = true;
            firstStatusCol = new DataGridViewComboBoxColumn();
            secondStatusCol = new DataGridViewComboBoxColumn();
            thirdStatusCol = new DataGridViewComboBoxColumn();
            submitalFormatCol = new DataGridViewComboBoxColumn();
        }

        private void ProjectDocumentsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit Project Documents Form?", "Warning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void ProjectDocumentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUpColumns();
            AddComboBoxColumns();
            SetSubmitColsVisibility();
            SetSubmitStatusColumn(SubmitalPhase.first);
            SetResponseStatusColumn(SubmitalPhase.first);
            RemoveSecondSubmitTrailsScreen();
            RemoveThirdSubmitTrailsScreen();
            FirstSubmitView();
        }

        private void RemoveExtraSubmitTrailsPages()
        {
        RemoveSecondSubmitTrailsScreen();
        RemoveThirdSubmitTrailsScreen();

        }

        private void RemoveThirdSubmitTrailsScreen()
        {
            this.tabControl1.TabPages.Remove(this.tabPage_ThirdCTRSubmit);
            this.tabControl1.TabPages.Remove(this.tabPage_ConsultThirdResponse);
        }

        private void RemoveSecondSubmitTrailsScreen()
        {
            this.tabControl1.TabPages.Remove(this.tabPage_SecondCTRSubmit);
            this.tabControl1.TabPages.Remove(this.tabPage_ConsultSecondResponse);
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
        private void HidePermenantCols()
        {
            gridView_ProjectDocs.Columns["DocumentId"].Visible = false;
            gridView_ProjectDocs.Columns["Description"].Visible = false;
            gridView_ProjectDocs.Columns["Project"].Visible = false;
            gridView_ProjectDocs.Columns["ProjectId"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultFirstRspCode"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Visible = false;
            gridView_ProjectDocs.Columns["OwnerSubmitFormat"].Visible = false;
        }
        private void HideSecondSubmits(bool hide)
        {
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeadline"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeliveryDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].Visible = !hide;
            gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].Visible = !hide;
            secondStatusCol.Visible = !hide;
        }
        private void HideThirdSubmits(bool hide)
        {
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeadline"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeliveryDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].Visible = !hide;
            gridView_ProjectDocs.Columns["ExpThirdConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActThirdConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].Visible = !hide;
            thirdStatusCol.Visible = !hide;
        }
        private void renameCols()
        {
            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].HeaderText = "Recomended DeadLine Before Handover";
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].HeaderText = "Recomended DeadLine After Handover";
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


            gridView_ProjectDocs.Columns["ActOwnerSubmitDate"].HeaderText = "Actual Owner Submittal Date";
            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].HeaderText = "Owner Submittal Status";
            gridView_ProjectDocs.Columns["OwnerSubmitFormat"].HeaderText = "Owner Submittal Format";
            gridView_ProjectDocs.Columns["StoragePlace"].HeaderText = "Storage Place";
            gridView_ProjectDocs.Columns["ReceivedBy"].HeaderText = "Received By";
            gridView_ProjectDocs.Columns["Retention"].HeaderText = "Retention";
            gridView_ProjectDocs.Columns["Deduction"].HeaderText = "Deduction";
        }
        private void AddComboBoxColumns()
        {

            var subCodeList = Enum.GetValues(typeof(ResponseCode)).Cast<ResponseCode>().ToList();

            firstStatusCol.HeaderText = "First Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultFirstRspCode"].Index, firstStatusCol);



            secondStatusCol.HeaderText = "Second Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Index, secondStatusCol);



            thirdStatusCol.HeaderText = "Third Consultant Response Code";
            gridView_ProjectDocs.Columns.Insert(gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Index, thirdStatusCol);



            var comboBoxColumns = new List<DataGridViewComboBoxColumn> { firstStatusCol, secondStatusCol, thirdStatusCol };

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
            firstStatusCol.DataPropertyName = "ConsultFirstRspCode";
            firstStatusCol.Name = "ConsultFirstRspCode";
            secondStatusCol.DataPropertyName = "ConsultSecondRspCode";
            secondStatusCol.Name = "ConsultSecondRspCode";
            thirdStatusCol.DataPropertyName = "ConsultThirdRspCode";
            thirdStatusCol.Name = "ConsultThirdRspCode";

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
        }
        private void SetSubmitColsVisibility()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[firstStatusCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());

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
                //HideSecondSubmits(true);
                //HideThirdSubmits(true);
            }
        }
        private void SetSecondSubmitColVisibilty()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[secondStatusCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());
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
                ShowThirdSubmital = false;
                //HideThirdSubmits(true);
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
                            row.Cells[statusColName].Value = DeliveryStatus.Pending;
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
                            row.Cells[statusColName].Value = ResponseStatus.Pending;
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
            if (e.ColumnIndex >= 8 && e.ColumnIndex <= 30 && e.Value is ResponseStatus)
            {
                var value = (ResponseStatus)e.Value;
                e.Value = value.ToString();
            }
        }
        private void GridView_ProjectDocs_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumKeyPress);
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
            }
            if (columnName == firstStatusCol.Name)
            {
                SetSubmitColsVisibility();
            }
            if (columnName == secondStatusCol.Name)
            {
                SetSecondSubmitColVisibilty();
            }
            if (columnName == thirdStatusCol.Name)
            {
                handleMaxSubmitTrails(sender, e);
            }
            if (columnName == "ActFirstCTRSubmitDeadline" || columnName == "ActFirstCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.first);
            }
            if (columnName == "ActSecondCTRSubmitDeadline" || columnName == "ActSecondCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.second);
            }
            if (columnName == "ActThirdCTRSubmitDeadline" || columnName == "ActThirdCTRSubmitDeliveryDate")
            {
                SetSubmitStatusColumn(SubmitalPhase.third);
            }
            if (columnName == "ActFirstConsultRspDate" || columnName == "ExpFirstConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.first);
            }
            if (columnName == "ActSecondConsultRspDate" || columnName == "ExpSecondConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.second);
            }
            if (columnName == "ActThirdConsultRspDate" || columnName == "ExpThirdConsultRspDate")
            {
                SetResponseStatusColumn(SubmitalPhase.third);
            }
            if (columnName == "ActOwnerSubmitDate")
            {
                SetSbmitToOwnerStatus(sender, e);
            }
        }

        private void SetSbmitToOwnerStatus(object? sender, DataGridViewCellEventArgs e)
        {
            var columnName = gridView_ProjectDocs.Columns[e.ColumnIndex].Name;
            var cell = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && columnName == "ActOwnerSubmitDate")
            {
                if ((DateTime)cell.Value > _project.PlannedEndDate)
                {
                    gridView_ProjectDocs.Rows[cell.RowIndex].Cells["OwnerSubmitStatus"].Value = DeliveryStatus.DeliveredLate;
                }
                else if ((DateTime)cell.Value <= _project.PlannedEndDate)
                {
                    gridView_ProjectDocs.Rows[cell.RowIndex].Cells["OwnerSubmitStatus"].Value = DeliveryStatus.DeliveredOnTime;
                }
            }
        }

        private void handleMaxSubmitTrails(object? sender, DataGridViewCellEventArgs e)
        {
            var columnName = gridView_ProjectDocs.Columns[e.ColumnIndex].Name;
            var cell = gridView_ProjectDocs.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && columnName == thirdStatusCol.Name
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
        private void NumKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
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
            var cellRectangle = gridView_ProjectDocs.
                GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
            _dtp.Size = new Size(cellRectangle.Width, cellRectangle.Height);
            _dtp.Location = new Point(cellRectangle.X, cellRectangle.Y);
            _dtp.Visible = true;
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
        }
        private void HideAllColumns()
        {
            foreach (DataGridViewColumn col in gridView_ProjectDocs.Columns)
            {
                col.Visible = false;
            }
            _dtp.Visible = false;
        }

        private void FirstSubmitView()
        {
            HideAllColumns();
            ShowFirstSubmitContent(true);
        }
        private void ShowFirstSubmitContent(bool show)
        {
            tabControl1.SelectTab("tabPage_FirstCTRSubmit");
            gridView_ProjectDocs.Columns["Name"].Visible = show;
            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].Visible = show;
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].Visible = show;
            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeadline"].Visible = show;
            gridView_ProjectDocs.Columns["ActFirstCTRSubmitDeliveryDate"].Visible = show;
            gridView_ProjectDocs.Columns["FirstCTRSubmitStatus"].Visible = show;
        }
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
            firstStatusCol.Visible = show;
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].Visible = show;
        }

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
            //gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].HeaderText = "Expected Second Consultant Response Date";
            //gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].HeaderText = "Actual Second Consultant Response Date";
            ////gridView_ProjectDocs.Columns["ConsultSecondRspCode"].HeaderText = "Second Consultant Response Code";
            //gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].HeaderText = "Second Consultant Response Status";
        }
        private void btn_FirstCTRCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_FirstCTRNext_Click(object sender, EventArgs e)
        {
            FirstResponseView();
        }
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
                //show to owner
            }

        }

        private void InsertSecondSubmitTrailScreen()
        {
            this.tabControl1.TabPages.Insert(2, this.tabPage_SecondCTRSubmit);
            this.tabControl1.TabPages.Insert(3, this.tabPage_ConsultSecondResponse);
        }
        private void InsertThirdSubmitTrailScreen()
        {
            this.tabControl1.TabPages.Insert(4, this.tabPage_ThirdCTRSubmit);
            this.tabControl1.TabPages.Insert(5, this.tabPage_ConsultThirdResponse);
        }
    }
}