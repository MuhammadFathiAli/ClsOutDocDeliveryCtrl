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
    public partial class ProjectDocumentsForm : Form
    {
        int _projectID;
        private DataGridViewCell _clickedCell;
        private DateTimePicker _dtp;
        private DataGridViewComboBoxColumn firstStatusCol;
        private DataGridViewComboBoxColumn secondStatusCol;
        private DataGridViewComboBoxColumn thirdStatusCol;

        public ProjectDocumentsForm(int projectID)
        {
            _projectID = projectID;
            InitializeComponent();
            _dtp = new DateTimePicker { Visible = false, Format = DateTimePickerFormat.Short };
            gridView_ProjectDocs.Controls.Add(_dtp);
            _dtp.TextChanged += _dtp_TextChanged;
            gridView_ProjectDocs.CellClick += GridView_ProjectDocs_CellClick;
            gridView_ProjectDocs.Scroll += GridView_ProjectDocs_Scroll;
            gridView_ProjectDocs.CellValueChanged += GridView_ProjectDocs_CellValueChanged;
            gridView_ProjectDocs.EditingControlShowing += GridView_ProjectDocs_EditingControlShowing;
            gridView_ProjectDocs.CellFormatting += GridView_ProjectDocs_CellFormatting;
            firstStatusCol = new DataGridViewComboBoxColumn();
            secondStatusCol = new DataGridViewComboBoxColumn();
            thirdStatusCol = new DataGridViewComboBoxColumn();
        }

        private void ProjectDocumentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetUpColumns();
            AddComboBoxColumns();
            SetColumnVisibility();
            SetSubmitStatusColumn(SubmitalPhase.first);
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
                SetColumnVisibility();
            }
            if (columnName == secondStatusCol.Name)
            {
                SetSecondColumnVisibilty();
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
        private void HideThirdSubmits(bool hide)
        {


            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeadline"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeliveryDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].Visible = !hide;
            gridView_ProjectDocs.Columns["ExpThirdConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActThirdConsultRspDate"].Visible = !hide;
            //gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].Visible = !hide;
            thirdStatusCol.Visible = !hide;
        }
        private void HideSecondSubmits(bool hide)
        {
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeadline"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeliveryDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].Visible = !hide;
            gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].Visible = !hide;
            gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].Visible = !hide;
            //gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Visible = !hide;
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].Visible = !hide;
            secondStatusCol.Visible = !hide;
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
        }
        private void SetColumnVisibility()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[firstStatusCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());

            if (isResubmitAsPerNotedPresent)
            {
                HideSecondSubmits(false);
                SetSecondColumnVisibilty();
            }
            else
            {
                HideSecondSubmits(true);
                HideThirdSubmits(true);
            }
        }
        private void SetSecondColumnVisibilty()
        {
            bool isResubmitAsPerNotedPresent = gridView_ProjectDocs.Rows.Cast<DataGridViewRow>()
                .Any(row => (row.Cells[secondStatusCol.Index].Value?.ToString() ?? string.Empty) == ResponseCode.ResubmitAsPerNoted.ToString());
            if (isResubmitAsPerNotedPresent)
            {
                HideThirdSubmits(false);
            }
            else
            {
                HideThirdSubmits(true);
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
        private void LoadData()
        {
            using (var context = new AppDBContext())
            {
                var documents = context.Documents.Where(d => d.ProjectId == _projectID).ToList();
                gridView_ProjectDocs.DataSource = documents;
            }
        }
        private void SetUpColumns()
        {

            foreach (DataGridViewColumn column in gridView_ProjectDocs.Columns)
            {
                if (column.ValueType == typeof(DateTime?))
                {
                    column.DefaultCellStyle.NullValue = "Click to insert";
                    column.DefaultCellStyle.Format = "d";
                }
            }

            gridView_ProjectDocs.Columns["DocumentId"].Visible = false;
            gridView_ProjectDocs.Columns["Description"].Visible = false;
            gridView_ProjectDocs.Columns["Project"].Visible = false;
            gridView_ProjectDocs.Columns["ProjectId"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultFirstRspCode"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultSecondRspCode"].Visible = false;
            gridView_ProjectDocs.Columns["ConsultThirdRspCode"].Visible = false;

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



            renameCoumns();
        }
        private void renameCoumns()
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



    }
}
