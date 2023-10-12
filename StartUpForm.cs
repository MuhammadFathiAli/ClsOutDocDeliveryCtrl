namespace ClsOutDocDeliveryCtrl
{
    public partial class frm_StartUp : Form
    {
        public frm_StartUp()
        {
            InitializeComponent();
        }
        frm_welcome frm_Welcome = new frm_welcome();
        private void btn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Welcome.ShowDialog();
            this.Visible = true;
            // open new welcome form 
        }
    }
}