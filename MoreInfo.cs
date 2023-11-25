using ClsOutDocDeliveryCtrl.Entities;

namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_MoreInfo : Form
    {
        Document _document;
        public frm_MoreInfo(Document document)
        {
            _document = document;
            InitializeComponent();
        }

        private void frm_MoreInfo_Load(object sender, EventArgs e)
        {
            this.lbl_DocNameValue.Text = _document.Name;
            this.lbl_DescriptionValue.Text = _document.Description;
            this.lbl_ContentValue.Text = "Table of Content";
        }
    }
}
