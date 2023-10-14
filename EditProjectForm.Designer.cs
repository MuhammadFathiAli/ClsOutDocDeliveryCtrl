namespace ClsOutDocDeliveryCtrl
{
    partial class frm_EditProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.num_ConsltReviewDays = new System.Windows.Forms.NumericUpDown();
            this.txt_ContrctName = new System.Windows.Forms.TextBox();
            this.txt_ConsltName = new System.Windows.Forms.TextBox();
            this.txt_OwnerName = new System.Windows.Forms.TextBox();
            this.txt_Currency = new System.Windows.Forms.TextBox();
            this.num_ContactValue = new System.Windows.Forms.NumericUpDown();
            this.datime_PEndDate = new System.Windows.Forms.DateTimePicker();
            this.datime_StartDate = new System.Windows.Forms.DateTimePicker();
            this.txt_PrjctName = new System.Windows.Forms.TextBox();
            this.lbl_ConsultRvwTime = new System.Windows.Forms.Label();
            this.lbl_CtrctName = new System.Windows.Forms.Label();
            this.lbl_ConsltName = new System.Windows.Forms.Label();
            this.lbl_OwnerName = new System.Windows.Forms.Label();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.lbl_CtrctValue = new System.Windows.Forms.Label();
            this.lbl_EndDate = new System.Windows.Forms.Label();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.lbl_PrjName = new System.Windows.Forms.Label();
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.errorProvider_EditProject = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.num_ConsltReviewDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ContactValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_EditProject)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Back.Location = new System.Drawing.Point(12, 405);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 41;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(713, 405);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 40;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // num_ConsltReviewDays
            // 
            this.num_ConsltReviewDays.Location = new System.Drawing.Point(384, 348);
            this.num_ConsltReviewDays.Name = "num_ConsltReviewDays";
            this.num_ConsltReviewDays.Size = new System.Drawing.Size(50, 23);
            this.num_ConsltReviewDays.TabIndex = 39;
            this.num_ConsltReviewDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // txt_ContrctName
            // 
            this.txt_ContrctName.Location = new System.Drawing.Point(359, 313);
            this.txt_ContrctName.Name = "txt_ContrctName";
            this.txt_ContrctName.Size = new System.Drawing.Size(100, 23);
            this.txt_ContrctName.TabIndex = 38;
            // 
            // txt_ConsltName
            // 
            this.txt_ConsltName.Location = new System.Drawing.Point(359, 278);
            this.txt_ConsltName.Name = "txt_ConsltName";
            this.txt_ConsltName.Size = new System.Drawing.Size(100, 23);
            this.txt_ConsltName.TabIndex = 37;
            // 
            // txt_OwnerName
            // 
            this.txt_OwnerName.Location = new System.Drawing.Point(359, 243);
            this.txt_OwnerName.Name = "txt_OwnerName";
            this.txt_OwnerName.Size = new System.Drawing.Size(100, 23);
            this.txt_OwnerName.TabIndex = 36;
            // 
            // txt_Currency
            // 
            this.txt_Currency.Location = new System.Drawing.Point(359, 208);
            this.txt_Currency.Name = "txt_Currency";
            this.txt_Currency.Size = new System.Drawing.Size(100, 23);
            this.txt_Currency.TabIndex = 35;
            // 
            // num_ContactValue
            // 
            this.num_ContactValue.Location = new System.Drawing.Point(349, 173);
            this.num_ContactValue.Name = "num_ContactValue";
            this.num_ContactValue.Size = new System.Drawing.Size(120, 23);
            this.num_ContactValue.TabIndex = 34;
            // 
            // datime_PEndDate
            // 
            this.datime_PEndDate.Location = new System.Drawing.Point(309, 138);
            this.datime_PEndDate.Name = "datime_PEndDate";
            this.datime_PEndDate.Size = new System.Drawing.Size(200, 23);
            this.datime_PEndDate.TabIndex = 33;
            // 
            // datime_StartDate
            // 
            this.datime_StartDate.Location = new System.Drawing.Point(309, 103);
            this.datime_StartDate.Name = "datime_StartDate";
            this.datime_StartDate.Size = new System.Drawing.Size(200, 23);
            this.datime_StartDate.TabIndex = 32;
            // 
            // txt_PrjctName
            // 
            this.txt_PrjctName.Location = new System.Drawing.Point(314, 68);
            this.txt_PrjctName.Name = "txt_PrjctName";
            this.txt_PrjctName.Size = new System.Drawing.Size(190, 23);
            this.txt_PrjctName.TabIndex = 31;
            // 
            // lbl_ConsultRvwTime
            // 
            this.lbl_ConsultRvwTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_ConsultRvwTime.AutoSize = true;
            this.lbl_ConsultRvwTime.Location = new System.Drawing.Point(54, 348);
            this.lbl_ConsultRvwTime.MaximumSize = new System.Drawing.Size(200, 0);
            this.lbl_ConsultRvwTime.Name = "lbl_ConsultRvwTime";
            this.lbl_ConsultRvwTime.Size = new System.Drawing.Size(190, 30);
            this.lbl_ConsultRvwTime.TabIndex = 30;
            this.lbl_ConsultRvwTime.Text = "Consultant review time for a piece of document (Days)";
            // 
            // lbl_CtrctName
            // 
            this.lbl_CtrctName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_CtrctName.AutoSize = true;
            this.lbl_CtrctName.Location = new System.Drawing.Point(54, 321);
            this.lbl_CtrctName.Name = "lbl_CtrctName";
            this.lbl_CtrctName.Size = new System.Drawing.Size(99, 15);
            this.lbl_CtrctName.TabIndex = 29;
            this.lbl_CtrctName.Text = "Contractor Name";
            // 
            // lbl_ConsltName
            // 
            this.lbl_ConsltName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_ConsltName.AutoSize = true;
            this.lbl_ConsltName.Location = new System.Drawing.Point(54, 286);
            this.lbl_ConsltName.Name = "lbl_ConsltName";
            this.lbl_ConsltName.Size = new System.Drawing.Size(100, 15);
            this.lbl_ConsltName.TabIndex = 28;
            this.lbl_ConsltName.Text = "Consultant Name";
            // 
            // lbl_OwnerName
            // 
            this.lbl_OwnerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_OwnerName.AutoSize = true;
            this.lbl_OwnerName.Location = new System.Drawing.Point(54, 251);
            this.lbl_OwnerName.Name = "lbl_OwnerName";
            this.lbl_OwnerName.Size = new System.Drawing.Size(77, 15);
            this.lbl_OwnerName.TabIndex = 27;
            this.lbl_OwnerName.Text = "Owner Name";
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Currency.AutoSize = true;
            this.lbl_Currency.Location = new System.Drawing.Point(54, 216);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(55, 15);
            this.lbl_Currency.TabIndex = 26;
            this.lbl_Currency.Text = "Currency";
            // 
            // lbl_CtrctValue
            // 
            this.lbl_CtrctValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_CtrctValue.AutoSize = true;
            this.lbl_CtrctValue.Location = new System.Drawing.Point(54, 181);
            this.lbl_CtrctValue.Name = "lbl_CtrctValue";
            this.lbl_CtrctValue.Size = new System.Drawing.Size(121, 15);
            this.lbl_CtrctValue.TabIndex = 25;
            this.lbl_CtrctValue.Text = "Contract Value (Price)";
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_EndDate.AutoSize = true;
            this.lbl_EndDate.Location = new System.Drawing.Point(54, 146);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(100, 15);
            this.lbl_EndDate.TabIndex = 24;
            this.lbl_EndDate.Text = "Planned End Date";
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_StartDate.AutoSize = true;
            this.lbl_StartDate.Location = new System.Drawing.Point(54, 111);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(58, 15);
            this.lbl_StartDate.TabIndex = 23;
            this.lbl_StartDate.Text = "Start Date";
            // 
            // lbl_PrjName
            // 
            this.lbl_PrjName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PrjName.AutoSize = true;
            this.lbl_PrjName.Location = new System.Drawing.Point(54, 76);
            this.lbl_PrjName.Name = "lbl_PrjName";
            this.lbl_PrjName.Size = new System.Drawing.Size(79, 15);
            this.lbl_PrjName.TabIndex = 22;
            this.lbl_PrjName.Text = "Project Name";
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Location = new System.Drawing.Point(54, 23);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(241, 15);
            this.lbl_instructions.TabIndex = 21;
            this.lbl_instructions.Text = "Please edit any of the following information:";
            // 
            // errorProvider_EditProject
            // 
            this.errorProvider_EditProject.ContainerControl = this;
            // 
            // frm_EditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.num_ConsltReviewDays);
            this.Controls.Add(this.txt_ContrctName);
            this.Controls.Add(this.txt_ConsltName);
            this.Controls.Add(this.txt_OwnerName);
            this.Controls.Add(this.txt_Currency);
            this.Controls.Add(this.num_ContactValue);
            this.Controls.Add(this.datime_PEndDate);
            this.Controls.Add(this.datime_StartDate);
            this.Controls.Add(this.txt_PrjctName);
            this.Controls.Add(this.lbl_ConsultRvwTime);
            this.Controls.Add(this.lbl_CtrctName);
            this.Controls.Add(this.lbl_ConsltName);
            this.Controls.Add(this.lbl_OwnerName);
            this.Controls.Add(this.lbl_Currency);
            this.Controls.Add(this.lbl_CtrctValue);
            this.Controls.Add(this.lbl_EndDate);
            this.Controls.Add(this.lbl_StartDate);
            this.Controls.Add(this.lbl_PrjName);
            this.Controls.Add(this.lbl_instructions);
            this.Name = "frm_EditProject";
            this.Text = "Edit Project";
            this.Load += new System.EventHandler(this.frm_EditProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_ConsltReviewDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ContactValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_EditProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Back;
        private Button btn_Save;
        private NumericUpDown num_ConsltReviewDays;
        private TextBox txt_ContrctName;
        private TextBox txt_ConsltName;
        private TextBox txt_OwnerName;
        private TextBox txt_Currency;
        private NumericUpDown num_ContactValue;
        private DateTimePicker datime_PEndDate;
        private DateTimePicker datime_StartDate;
        private TextBox txt_PrjctName;
        private Label lbl_ConsultRvwTime;
        private Label lbl_CtrctName;
        private Label lbl_ConsltName;
        private Label lbl_OwnerName;
        private Label lbl_Currency;
        private Label lbl_CtrctValue;
        private Label lbl_EndDate;
        private Label lbl_StartDate;
        private Label lbl_PrjName;
        private Label lbl_instructions;
        private ErrorProvider errorProvider_EditProject;
    }
}