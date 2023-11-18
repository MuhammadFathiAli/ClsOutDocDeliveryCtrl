namespace ClsOutDocDeliveryCtrl
{
    partial class frm_NewProject
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
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.lbl_PrjName = new System.Windows.Forms.Label();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.lbl_EndDate = new System.Windows.Forms.Label();
            this.lbl_CtrctValue = new System.Windows.Forms.Label();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.lbl_OwnerName = new System.Windows.Forms.Label();
            this.lbl_ConsltName = new System.Windows.Forms.Label();
            this.lbl_CtrctName = new System.Windows.Forms.Label();
            this.lbl_ConsultRvwTime = new System.Windows.Forms.Label();
            this.txt_PrjctName = new System.Windows.Forms.TextBox();
            this.datime_StartDate = new System.Windows.Forms.DateTimePicker();
            this.datime_PEndDate = new System.Windows.Forms.DateTimePicker();
            this.num_ContactValue = new System.Windows.Forms.NumericUpDown();
            this.txt_Currency = new System.Windows.Forms.TextBox();
            this.txt_OwnerName = new System.Windows.Forms.TextBox();
            this.txt_ConsltName = new System.Windows.Forms.TextBox();
            this.txt_ContrctName = new System.Windows.Forms.TextBox();
            this.num_ConsltReviewDays = new System.Windows.Forms.NumericUpDown();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.errorProvider_NewProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.num_Retention = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_ContactValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ConsltReviewDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_NewProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Retention)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_instructions.Location = new System.Drawing.Point(54, 33);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(318, 21);
            this.lbl_instructions.TabIndex = 0;
            this.lbl_instructions.Text = "Please fill down the following information:";
            // 
            // lbl_PrjName
            // 
            this.lbl_PrjName.AutoSize = true;
            this.lbl_PrjName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_PrjName.Location = new System.Drawing.Point(54, 86);
            this.lbl_PrjName.Name = "lbl_PrjName";
            this.lbl_PrjName.Size = new System.Drawing.Size(79, 15);
            this.lbl_PrjName.TabIndex = 1;
            this.lbl_PrjName.Text = "Project Name";
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.AutoSize = true;
            this.lbl_StartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_StartDate.Location = new System.Drawing.Point(54, 121);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(60, 15);
            this.lbl_StartDate.TabIndex = 2;
            this.lbl_StartDate.Text = "Start Date";
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.AutoSize = true;
            this.lbl_EndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_EndDate.Location = new System.Drawing.Point(54, 156);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(101, 15);
            this.lbl_EndDate.TabIndex = 3;
            this.lbl_EndDate.Text = "Planned End Date";
            // 
            // lbl_CtrctValue
            // 
            this.lbl_CtrctValue.AutoSize = true;
            this.lbl_CtrctValue.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_CtrctValue.Location = new System.Drawing.Point(54, 191);
            this.lbl_CtrctValue.Name = "lbl_CtrctValue";
            this.lbl_CtrctValue.Size = new System.Drawing.Size(121, 15);
            this.lbl_CtrctValue.TabIndex = 4;
            this.lbl_CtrctValue.Text = "Contract Value (Price)";
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.AutoSize = true;
            this.lbl_Currency.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Currency.Location = new System.Drawing.Point(54, 226);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(54, 15);
            this.lbl_Currency.TabIndex = 5;
            this.lbl_Currency.Text = "Currency";
            // 
            // lbl_OwnerName
            // 
            this.lbl_OwnerName.AutoSize = true;
            this.lbl_OwnerName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_OwnerName.Location = new System.Drawing.Point(54, 261);
            this.lbl_OwnerName.Name = "lbl_OwnerName";
            this.lbl_OwnerName.Size = new System.Drawing.Size(77, 15);
            this.lbl_OwnerName.TabIndex = 6;
            this.lbl_OwnerName.Text = "Owner Name";
            // 
            // lbl_ConsltName
            // 
            this.lbl_ConsltName.AutoSize = true;
            this.lbl_ConsltName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ConsltName.Location = new System.Drawing.Point(54, 296);
            this.lbl_ConsltName.Name = "lbl_ConsltName";
            this.lbl_ConsltName.Size = new System.Drawing.Size(99, 15);
            this.lbl_ConsltName.TabIndex = 7;
            this.lbl_ConsltName.Text = "Consultant Name";
            // 
            // lbl_CtrctName
            // 
            this.lbl_CtrctName.AutoSize = true;
            this.lbl_CtrctName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_CtrctName.Location = new System.Drawing.Point(54, 331);
            this.lbl_CtrctName.Name = "lbl_CtrctName";
            this.lbl_CtrctName.Size = new System.Drawing.Size(98, 15);
            this.lbl_CtrctName.TabIndex = 8;
            this.lbl_CtrctName.Text = "Contractor Name";
            // 
            // lbl_ConsultRvwTime
            // 
            this.lbl_ConsultRvwTime.AutoSize = true;
            this.lbl_ConsultRvwTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ConsultRvwTime.Location = new System.Drawing.Point(54, 358);
            this.lbl_ConsultRvwTime.MaximumSize = new System.Drawing.Size(200, 0);
            this.lbl_ConsultRvwTime.Name = "lbl_ConsultRvwTime";
            this.lbl_ConsultRvwTime.Size = new System.Drawing.Size(200, 30);
            this.lbl_ConsultRvwTime.TabIndex = 9;
            this.lbl_ConsultRvwTime.Text = "Consultant review time for a piece of document (Days)";
            // 
            // txt_PrjctName
            // 
            this.txt_PrjctName.Location = new System.Drawing.Point(309, 78);
            this.txt_PrjctName.Name = "txt_PrjctName";
            this.txt_PrjctName.Size = new System.Drawing.Size(200, 23);
            this.txt_PrjctName.TabIndex = 10;
            // 
            // datime_StartDate
            // 
            this.datime_StartDate.Location = new System.Drawing.Point(309, 113);
            this.datime_StartDate.Name = "datime_StartDate";
            this.datime_StartDate.Size = new System.Drawing.Size(200, 23);
            this.datime_StartDate.TabIndex = 11;
            // 
            // datime_PEndDate
            // 
            this.datime_PEndDate.Location = new System.Drawing.Point(309, 148);
            this.datime_PEndDate.Name = "datime_PEndDate";
            this.datime_PEndDate.Size = new System.Drawing.Size(200, 23);
            this.datime_PEndDate.TabIndex = 12;
            // 
            // num_ContactValue
            // 
            this.num_ContactValue.Location = new System.Drawing.Point(309, 183);
            this.num_ContactValue.Name = "num_ContactValue";
            this.num_ContactValue.Size = new System.Drawing.Size(200, 23);
            this.num_ContactValue.TabIndex = 13;
            // 
            // txt_Currency
            // 
            this.txt_Currency.Location = new System.Drawing.Point(309, 218);
            this.txt_Currency.Name = "txt_Currency";
            this.txt_Currency.Size = new System.Drawing.Size(200, 23);
            this.txt_Currency.TabIndex = 14;
            // 
            // txt_OwnerName
            // 
            this.txt_OwnerName.Location = new System.Drawing.Point(309, 253);
            this.txt_OwnerName.Name = "txt_OwnerName";
            this.txt_OwnerName.Size = new System.Drawing.Size(200, 23);
            this.txt_OwnerName.TabIndex = 15;
            // 
            // txt_ConsltName
            // 
            this.txt_ConsltName.Location = new System.Drawing.Point(309, 288);
            this.txt_ConsltName.Name = "txt_ConsltName";
            this.txt_ConsltName.Size = new System.Drawing.Size(200, 23);
            this.txt_ConsltName.TabIndex = 16;
            // 
            // txt_ContrctName
            // 
            this.txt_ContrctName.Location = new System.Drawing.Point(309, 323);
            this.txt_ContrctName.Name = "txt_ContrctName";
            this.txt_ContrctName.Size = new System.Drawing.Size(200, 23);
            this.txt_ContrctName.TabIndex = 17;
            // 
            // num_ConsltReviewDays
            // 
            this.num_ConsltReviewDays.Location = new System.Drawing.Point(309, 358);
            this.num_ConsltReviewDays.Name = "num_ConsltReviewDays";
            this.num_ConsltReviewDays.Size = new System.Drawing.Size(81, 23);
            this.num_ConsltReviewDays.TabIndex = 18;
            this.num_ConsltReviewDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Next.Location = new System.Drawing.Point(713, 476);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 19;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Back.Location = new System.Drawing.Point(12, 476);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 20;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // errorProvider_NewProject
            // 
            this.errorProvider_NewProject.ContainerControl = this;
            // 
            // num_Retention
            // 
            this.num_Retention.Location = new System.Drawing.Point(308, 407);
            this.num_Retention.Name = "num_Retention";
            this.num_Retention.Size = new System.Drawing.Size(82, 23);
            this.num_Retention.TabIndex = 22;
            this.num_Retention.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(53, 407);
            this.label1.MaximumSize = new System.Drawing.Size(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 30);
            this.label1.TabIndex = 21;
            this.label1.Text = "Retention for Documents Delivery (Percentage)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(399, 404);
            this.label2.MaximumSize = new System.Drawing.Size(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(399, 358);
            this.label3.MaximumSize = new System.Drawing.Size(200, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Days";
            // 
            // frm_NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_Retention);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Next);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_NewProject";
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.frm_NewProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_ContactValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ConsltReviewDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_NewProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Retention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_instructions;
        private Label lbl_PrjName;
        private Label lbl_StartDate;
        private Label lbl_EndDate;
        private Label lbl_CtrctValue;
        private Label lbl_Currency;
        private Label lbl_OwnerName;
        private Label lbl_ConsltName;
        private Label lbl_CtrctName;
        private Label lbl_ConsultRvwTime;
        private TextBox txt_PrjctName;
        private DateTimePicker datime_StartDate;
        private DateTimePicker datime_PEndDate;
        private NumericUpDown num_ContactValue;
        private TextBox txt_Currency;
        private TextBox txt_OwnerName;
        private TextBox txt_ConsltName;
        private TextBox txt_ContrctName;
        private NumericUpDown num_ConsltReviewDays;
        private Button btn_Next;
        private Button btn_Back;
        private ErrorProvider errorProvider_NewProject;
        private Label label3;
        private Label label2;
        private NumericUpDown num_Retention;
        private Label label1;
    }
}