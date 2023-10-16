namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_OldNewDoc : Form
    {
        public frm_OldNewDoc()
        {
            InitializeComponent();
            this.tabControl1.TabPages.Remove(this.tabPage_secondCtrConsltSubmittal);
        }

        private void frm_NewDoc_Load(object sender, EventArgs e)
        {
        }

        private void btn_FirstCtrSubmittalNext_Click(object sender, EventArgs e)
        {

            this.tabControl1.TabPages.Insert(2, this.tabPage_secondCtrConsltSubmittal);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
