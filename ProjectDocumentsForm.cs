using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using System.Data;

namespace ClsOutDocDeliveryCtrl
{
    public partial class ProjectDocumentsForm : Form
    {
        int _projectID;
        private DataGridViewCell _clickedCell;
        private DateTimePicker _dtp;

        public ProjectDocumentsForm(int projectID)
        {
            _projectID = projectID;
            InitializeComponent();
            _dtp = new DateTimePicker();
            this.gridView_ProjectDocs.Controls.Add(_dtp);
            _dtp.Visible = false;
            _dtp.Format = DateTimePickerFormat.Short;
            _dtp.TextChanged += _dtp_TextChanged;
            this.gridView_ProjectDocs.CellClick += GridView_ProjectDocs_CellClick;
            this.gridView_ProjectDocs.Scroll += GridView_ProjectDocs_Scroll;
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


        private void GridView_ProjectDocs_Scroll(object? sender, ScrollEventArgs e)
        {
            _dtp.Visible = false;
        }

        private void _dtp_TextChanged(object? sender, EventArgs e)
        {
            this.gridView_ProjectDocs.CurrentCell.Value = _dtp.Value;
        }

        private void GridView_ProjectDocs_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
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
            }
        }
        private void ShowDateTimePicker(DataGridViewCell cell)
        {
            Rectangle cellRectangle = gridView_ProjectDocs.
                GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
            _dtp.Size = new System.Drawing.Size(cellRectangle.Width, cellRectangle.Height);
            _dtp.Location = new System.Drawing.Point(cellRectangle.X, cellRectangle.Y);
            _dtp.Visible = true;
        }

        private void ProjectDocumentsForm_Load(object sender, EventArgs e)
        {
            using (var context = new AppDBContext())
            {
                List<Document> documents = new List<Document>();
                documents = context.Documents.Where(d => d.ProjectId == _projectID).ToList();
                this.gridView_ProjectDocs.DataSource = documents;


                SetUpColumns();


                foreach (DataGridViewColumn column in gridView_ProjectDocs.Columns)
                {
                    if (column.ValueType == typeof(DateTime?))
                    {
                        column.DefaultCellStyle.NullValue = "Click to insert";
                    }
                }



            }


        }

        private void SetUpColumns()
        {
            gridView_ProjectDocs.Columns["DocumentId"].Visible = false;
            gridView_ProjectDocs.Columns["Description"].Visible = false;
            gridView_ProjectDocs.Columns["Project"].Visible = false;
            gridView_ProjectDocs.Columns["ProjectId"].Visible = false;


            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].ReadOnly = true;
            gridView_ProjectDocs.Columns["RcmdDeadlineBeforeHandover"].DefaultCellStyle.BackColor = Color.DarkGray;
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].ReadOnly = true;
            gridView_ProjectDocs.Columns["RcmdDeadlineAfterHandover"].DefaultCellStyle.BackColor = Color.DarkGray;

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
            gridView_ProjectDocs.Columns["ConsultFirstRspCode"].HeaderText = "First Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultFirstRspStatus"].HeaderText = "First Consultant Response Status";


            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeadline"].HeaderText = "Actual Second Contractor Submittal Deadline";
            gridView_ProjectDocs.Columns["ActSecondCTRSubmitDeliveryDate"].HeaderText = "Actual Second Contractor Submittal Delivery Date";
            gridView_ProjectDocs.Columns["SecondCTRSubmitStatus"].HeaderText = "Second Contractor Submittal Status";
            gridView_ProjectDocs.Columns["ExpSecondConsultRspDate"].HeaderText = "Expected Second Consultant Response Date";
            gridView_ProjectDocs.Columns["ActSecondConsultRspDate"].HeaderText = "Actual Second Consultant Response Date";
            gridView_ProjectDocs.Columns["ConsultSecondRspCode"].HeaderText = "Second Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultSecondRspStatus"].HeaderText = "Second Consultant Response Status";


            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeadline"].HeaderText = "Actual Third Contractor Submittal Deadline";
            gridView_ProjectDocs.Columns["ActThirdCTRSubmitDeliveryDate"].HeaderText = "Actual Third Contractor Submittal Delivery Date";
            gridView_ProjectDocs.Columns["ThirdCTRSubmitStatus"].HeaderText = "Third Contractor Submittal Status";
            gridView_ProjectDocs.Columns["ExpThirdConsultRspDate"].HeaderText = "Expected Third Consultant Response Date";
            gridView_ProjectDocs.Columns["ActThirdConsultRspDate"].HeaderText = "Actual Third Consultant Response Date";
            gridView_ProjectDocs.Columns["ConsultThirdRspCode"].HeaderText = "Third Consultant Response Code";
            gridView_ProjectDocs.Columns["ConsultThirdRspStatus"].HeaderText = "Third Consultant Response Status";


            gridView_ProjectDocs.Columns["ActOwnerSubmitDate"].HeaderText = "Actual Owner Submittal Date";
            gridView_ProjectDocs.Columns["OwnerSubmitStatus"].HeaderText = "Owner Submittal Status";
            gridView_ProjectDocs.Columns["OwnerSubmitFormat"].HeaderText = "Owner Submittal Format";
            gridView_ProjectDocs.Columns["StoragePlace"].HeaderText = "Storage Place";
            gridView_ProjectDocs.Columns["ReceivedBy"].HeaderText = "Received By";
            gridView_ProjectDocs.Columns["Retention"].HeaderText = "Retention";
            gridView_ProjectDocs.Columns["Deduction"].HeaderText = "Deduction";
        }



    }
}
