namespace ClsOutDocDeliveryCtrl
{
    partial class frm_SepProjectDocs
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_basicInfo = new System.Windows.Forms.TabPage();
            this.btn_BasicInfoCancel = new System.Windows.Forms.Button();
            this.btn_BasicInfoNext = new System.Windows.Forms.Button();
            this.tabPage_firstCtrConsltSubmittal = new System.Windows.Forms.TabPage();
            this.btn_FirsCtrSubmitalBack = new System.Windows.Forms.Button();
            this.btn_FirstCtrSubmittalNext = new System.Windows.Forms.Button();
            this.tabPage_secondCtrConsltSubmittal = new System.Windows.Forms.TabPage();
            this.btn_SecondCtrSubmitalBack = new System.Windows.Forms.Button();
            this.btn_SecondCtrSubmittalNext = new System.Windows.Forms.Button();
            this.tabPage_thirdCtrConsltSubmittal = new System.Windows.Forms.TabPage();
            this.btn_ThirdCtrSubmitalBack = new System.Windows.Forms.Button();
            this.btn_ThirdCtrSubmittalNext = new System.Windows.Forms.Button();
            this.tabPage_SubmitToOwner = new System.Windows.Forms.TabPage();
            this.btn_SubmitToOwnerBack = new System.Windows.Forms.Button();
            this.btn_SubmitToOwnerNext = new System.Windows.Forms.Button();
            this.tabPage_Retentions = new System.Windows.Forms.TabPage();
            this.btn_RetsDedsBack = new System.Windows.Forms.Button();
            this.btn_RetsDedsSubmit = new System.Windows.Forms.Button();
            this.gridView_BasicInfo = new System.Windows.Forms.DataGridView();
            this.gridView_FirstCTRSubmit = new System.Windows.Forms.DataGridView();
            this.gridView_SecondCTRSubmital = new System.Windows.Forms.DataGridView();
            this.gridView_ThirdCTRSubmital = new System.Windows.Forms.DataGridView();
            this.gridView_OwnerSubmital = new System.Windows.Forms.DataGridView();
            this.gridView_RetDeds = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage_basicInfo.SuspendLayout();
            this.tabPage_firstCtrConsltSubmittal.SuspendLayout();
            this.tabPage_secondCtrConsltSubmittal.SuspendLayout();
            this.tabPage_thirdCtrConsltSubmittal.SuspendLayout();
            this.tabPage_SubmitToOwner.SuspendLayout();
            this.tabPage_Retentions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BasicInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_FirstCTRSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SecondCTRSubmital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ThirdCTRSubmital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OwnerSubmital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RetDeds)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_basicInfo);
            this.tabControl1.Controls.Add(this.tabPage_firstCtrConsltSubmittal);
            this.tabControl1.Controls.Add(this.tabPage_secondCtrConsltSubmittal);
            this.tabControl1.Controls.Add(this.tabPage_thirdCtrConsltSubmittal);
            this.tabControl1.Controls.Add(this.tabPage_SubmitToOwner);
            this.tabControl1.Controls.Add(this.tabPage_Retentions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 570);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_basicInfo
            // 
            this.tabPage_basicInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_basicInfo.Controls.Add(this.gridView_BasicInfo);
            this.tabPage_basicInfo.Controls.Add(this.btn_BasicInfoCancel);
            this.tabPage_basicInfo.Controls.Add(this.btn_BasicInfoNext);
            this.tabPage_basicInfo.Location = new System.Drawing.Point(4, 24);
            this.tabPage_basicInfo.Name = "tabPage_basicInfo";
            this.tabPage_basicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_basicInfo.Size = new System.Drawing.Size(792, 542);
            this.tabPage_basicInfo.TabIndex = 0;
            this.tabPage_basicInfo.Text = "Basic Info";
            // 
            // btn_BasicInfoCancel
            // 
            this.btn_BasicInfoCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_BasicInfoCancel.Location = new System.Drawing.Point(6, 511);
            this.btn_BasicInfoCancel.Name = "btn_BasicInfoCancel";
            this.btn_BasicInfoCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_BasicInfoCancel.TabIndex = 39;
            this.btn_BasicInfoCancel.Text = "Cancel";
            this.btn_BasicInfoCancel.UseVisualStyleBackColor = true;
            // 
            // btn_BasicInfoNext
            // 
            this.btn_BasicInfoNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BasicInfoNext.Location = new System.Drawing.Point(709, 511);
            this.btn_BasicInfoNext.Name = "btn_BasicInfoNext";
            this.btn_BasicInfoNext.Size = new System.Drawing.Size(75, 23);
            this.btn_BasicInfoNext.TabIndex = 38;
            this.btn_BasicInfoNext.Text = "Next";
            this.btn_BasicInfoNext.UseVisualStyleBackColor = true;
            this.btn_BasicInfoNext.Click += new System.EventHandler(this.btn_BasicInfoNext_Click);
            // 
            // tabPage_firstCtrConsltSubmittal
            // 
            this.tabPage_firstCtrConsltSubmittal.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_firstCtrConsltSubmittal.Controls.Add(this.gridView_FirstCTRSubmit);
            this.tabPage_firstCtrConsltSubmittal.Controls.Add(this.btn_FirsCtrSubmitalBack);
            this.tabPage_firstCtrConsltSubmittal.Controls.Add(this.btn_FirstCtrSubmittalNext);
            this.tabPage_firstCtrConsltSubmittal.Location = new System.Drawing.Point(4, 24);
            this.tabPage_firstCtrConsltSubmittal.Name = "tabPage_firstCtrConsltSubmittal";
            this.tabPage_firstCtrConsltSubmittal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_firstCtrConsltSubmittal.Size = new System.Drawing.Size(792, 542);
            this.tabPage_firstCtrConsltSubmittal.TabIndex = 1;
            this.tabPage_firstCtrConsltSubmittal.Text = "1st Contractor Submit";
            // 
            // btn_FirsCtrSubmitalBack
            // 
            this.btn_FirsCtrSubmitalBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FirsCtrSubmitalBack.Location = new System.Drawing.Point(6, 511);
            this.btn_FirsCtrSubmitalBack.Name = "btn_FirsCtrSubmitalBack";
            this.btn_FirsCtrSubmitalBack.Size = new System.Drawing.Size(75, 23);
            this.btn_FirsCtrSubmitalBack.TabIndex = 70;
            this.btn_FirsCtrSubmitalBack.Text = "Back";
            this.btn_FirsCtrSubmitalBack.UseVisualStyleBackColor = true;
            // 
            // btn_FirstCtrSubmittalNext
            // 
            this.btn_FirstCtrSubmittalNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FirstCtrSubmittalNext.Location = new System.Drawing.Point(709, 511);
            this.btn_FirstCtrSubmittalNext.Name = "btn_FirstCtrSubmittalNext";
            this.btn_FirstCtrSubmittalNext.Size = new System.Drawing.Size(75, 23);
            this.btn_FirstCtrSubmittalNext.TabIndex = 69;
            this.btn_FirstCtrSubmittalNext.Text = "Next";
            this.btn_FirstCtrSubmittalNext.UseVisualStyleBackColor = true;
            this.btn_FirstCtrSubmittalNext.Click += new System.EventHandler(this.btn_FirstCtrSubmittalNext_Click);
            // 
            // tabPage_secondCtrConsltSubmittal
            // 
            this.tabPage_secondCtrConsltSubmittal.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_secondCtrConsltSubmittal.Controls.Add(this.gridView_SecondCTRSubmital);
            this.tabPage_secondCtrConsltSubmittal.Controls.Add(this.btn_SecondCtrSubmitalBack);
            this.tabPage_secondCtrConsltSubmittal.Controls.Add(this.btn_SecondCtrSubmittalNext);
            this.tabPage_secondCtrConsltSubmittal.Location = new System.Drawing.Point(4, 24);
            this.tabPage_secondCtrConsltSubmittal.Name = "tabPage_secondCtrConsltSubmittal";
            this.tabPage_secondCtrConsltSubmittal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_secondCtrConsltSubmittal.Size = new System.Drawing.Size(792, 542);
            this.tabPage_secondCtrConsltSubmittal.TabIndex = 2;
            this.tabPage_secondCtrConsltSubmittal.Text = "2nd Contractor Submit";
            // 
            // btn_SecondCtrSubmitalBack
            // 
            this.btn_SecondCtrSubmitalBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SecondCtrSubmitalBack.Location = new System.Drawing.Point(6, 511);
            this.btn_SecondCtrSubmitalBack.Name = "btn_SecondCtrSubmitalBack";
            this.btn_SecondCtrSubmitalBack.Size = new System.Drawing.Size(75, 23);
            this.btn_SecondCtrSubmitalBack.TabIndex = 87;
            this.btn_SecondCtrSubmitalBack.Text = "Back";
            this.btn_SecondCtrSubmitalBack.UseVisualStyleBackColor = true;
            // 
            // btn_SecondCtrSubmittalNext
            // 
            this.btn_SecondCtrSubmittalNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SecondCtrSubmittalNext.Location = new System.Drawing.Point(709, 511);
            this.btn_SecondCtrSubmittalNext.Name = "btn_SecondCtrSubmittalNext";
            this.btn_SecondCtrSubmittalNext.Size = new System.Drawing.Size(75, 23);
            this.btn_SecondCtrSubmittalNext.TabIndex = 86;
            this.btn_SecondCtrSubmittalNext.Text = "Next";
            this.btn_SecondCtrSubmittalNext.UseVisualStyleBackColor = true;
            // 
            // tabPage_thirdCtrConsltSubmittal
            // 
            this.tabPage_thirdCtrConsltSubmittal.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_thirdCtrConsltSubmittal.Controls.Add(this.gridView_ThirdCTRSubmital);
            this.tabPage_thirdCtrConsltSubmittal.Controls.Add(this.btn_ThirdCtrSubmitalBack);
            this.tabPage_thirdCtrConsltSubmittal.Controls.Add(this.btn_ThirdCtrSubmittalNext);
            this.tabPage_thirdCtrConsltSubmittal.Location = new System.Drawing.Point(4, 24);
            this.tabPage_thirdCtrConsltSubmittal.Name = "tabPage_thirdCtrConsltSubmittal";
            this.tabPage_thirdCtrConsltSubmittal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_thirdCtrConsltSubmittal.Size = new System.Drawing.Size(792, 542);
            this.tabPage_thirdCtrConsltSubmittal.TabIndex = 3;
            this.tabPage_thirdCtrConsltSubmittal.Text = "3rd Contractor Submit";
            // 
            // btn_ThirdCtrSubmitalBack
            // 
            this.btn_ThirdCtrSubmitalBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ThirdCtrSubmitalBack.Location = new System.Drawing.Point(6, 511);
            this.btn_ThirdCtrSubmitalBack.Name = "btn_ThirdCtrSubmitalBack";
            this.btn_ThirdCtrSubmitalBack.Size = new System.Drawing.Size(75, 23);
            this.btn_ThirdCtrSubmitalBack.TabIndex = 104;
            this.btn_ThirdCtrSubmitalBack.Text = "Back";
            this.btn_ThirdCtrSubmitalBack.UseVisualStyleBackColor = true;
            // 
            // btn_ThirdCtrSubmittalNext
            // 
            this.btn_ThirdCtrSubmittalNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ThirdCtrSubmittalNext.Location = new System.Drawing.Point(709, 511);
            this.btn_ThirdCtrSubmittalNext.Name = "btn_ThirdCtrSubmittalNext";
            this.btn_ThirdCtrSubmittalNext.Size = new System.Drawing.Size(75, 23);
            this.btn_ThirdCtrSubmittalNext.TabIndex = 103;
            this.btn_ThirdCtrSubmittalNext.Text = "Next";
            this.btn_ThirdCtrSubmittalNext.UseVisualStyleBackColor = true;
            // 
            // tabPage_SubmitToOwner
            // 
            this.tabPage_SubmitToOwner.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_SubmitToOwner.Controls.Add(this.gridView_OwnerSubmital);
            this.tabPage_SubmitToOwner.Controls.Add(this.btn_SubmitToOwnerBack);
            this.tabPage_SubmitToOwner.Controls.Add(this.btn_SubmitToOwnerNext);
            this.tabPage_SubmitToOwner.Location = new System.Drawing.Point(4, 24);
            this.tabPage_SubmitToOwner.Name = "tabPage_SubmitToOwner";
            this.tabPage_SubmitToOwner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SubmitToOwner.Size = new System.Drawing.Size(792, 542);
            this.tabPage_SubmitToOwner.TabIndex = 4;
            this.tabPage_SubmitToOwner.Text = "Submittal to Owner";
            // 
            // btn_SubmitToOwnerBack
            // 
            this.btn_SubmitToOwnerBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SubmitToOwnerBack.Location = new System.Drawing.Point(6, 511);
            this.btn_SubmitToOwnerBack.Name = "btn_SubmitToOwnerBack";
            this.btn_SubmitToOwnerBack.Size = new System.Drawing.Size(75, 23);
            this.btn_SubmitToOwnerBack.TabIndex = 116;
            this.btn_SubmitToOwnerBack.Text = "Back";
            this.btn_SubmitToOwnerBack.UseVisualStyleBackColor = true;
            // 
            // btn_SubmitToOwnerNext
            // 
            this.btn_SubmitToOwnerNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SubmitToOwnerNext.Location = new System.Drawing.Point(709, 511);
            this.btn_SubmitToOwnerNext.Name = "btn_SubmitToOwnerNext";
            this.btn_SubmitToOwnerNext.Size = new System.Drawing.Size(75, 23);
            this.btn_SubmitToOwnerNext.TabIndex = 115;
            this.btn_SubmitToOwnerNext.Text = "Next";
            this.btn_SubmitToOwnerNext.UseVisualStyleBackColor = true;
            // 
            // tabPage_Retentions
            // 
            this.tabPage_Retentions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Retentions.Controls.Add(this.gridView_RetDeds);
            this.tabPage_Retentions.Controls.Add(this.btn_RetsDedsBack);
            this.tabPage_Retentions.Controls.Add(this.btn_RetsDedsSubmit);
            this.tabPage_Retentions.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Retentions.Name = "tabPage_Retentions";
            this.tabPage_Retentions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Retentions.Size = new System.Drawing.Size(792, 542);
            this.tabPage_Retentions.TabIndex = 5;
            this.tabPage_Retentions.Text = "Retention - Deduction";
            // 
            // btn_RetsDedsBack
            // 
            this.btn_RetsDedsBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_RetsDedsBack.Location = new System.Drawing.Point(6, 511);
            this.btn_RetsDedsBack.Name = "btn_RetsDedsBack";
            this.btn_RetsDedsBack.Size = new System.Drawing.Size(75, 23);
            this.btn_RetsDedsBack.TabIndex = 118;
            this.btn_RetsDedsBack.Text = "Back";
            this.btn_RetsDedsBack.UseVisualStyleBackColor = true;
            // 
            // btn_RetsDedsSubmit
            // 
            this.btn_RetsDedsSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RetsDedsSubmit.Location = new System.Drawing.Point(709, 511);
            this.btn_RetsDedsSubmit.Name = "btn_RetsDedsSubmit";
            this.btn_RetsDedsSubmit.Size = new System.Drawing.Size(75, 23);
            this.btn_RetsDedsSubmit.TabIndex = 117;
            this.btn_RetsDedsSubmit.Text = "Submit";
            this.btn_RetsDedsSubmit.UseVisualStyleBackColor = true;
            // 
            // gridView_BasicInfo
            // 
            this.gridView_BasicInfo.AllowUserToAddRows = false;
            this.gridView_BasicInfo.AllowUserToDeleteRows = false;
            this.gridView_BasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_BasicInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_BasicInfo.Location = new System.Drawing.Point(0, 59);
            this.gridView_BasicInfo.Name = "gridView_BasicInfo";
            this.gridView_BasicInfo.RowTemplate.Height = 25;
            this.gridView_BasicInfo.Size = new System.Drawing.Size(796, 421);
            this.gridView_BasicInfo.TabIndex = 40;
            // 
            // gridView_FirstCTRSubmit
            // 
            this.gridView_FirstCTRSubmit.AllowUserToAddRows = false;
            this.gridView_FirstCTRSubmit.AllowUserToDeleteRows = false;
            this.gridView_FirstCTRSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_FirstCTRSubmit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_FirstCTRSubmit.Location = new System.Drawing.Point(-2, 61);
            this.gridView_FirstCTRSubmit.Name = "gridView_FirstCTRSubmit";
            this.gridView_FirstCTRSubmit.RowTemplate.Height = 25;
            this.gridView_FirstCTRSubmit.Size = new System.Drawing.Size(796, 421);
            this.gridView_FirstCTRSubmit.TabIndex = 71;
            // 
            // gridView_SecondCTRSubmital
            // 
            this.gridView_SecondCTRSubmital.AllowUserToAddRows = false;
            this.gridView_SecondCTRSubmital.AllowUserToDeleteRows = false;
            this.gridView_SecondCTRSubmital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_SecondCTRSubmital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_SecondCTRSubmital.Location = new System.Drawing.Point(-2, 61);
            this.gridView_SecondCTRSubmital.Name = "gridView_SecondCTRSubmital";
            this.gridView_SecondCTRSubmital.RowTemplate.Height = 25;
            this.gridView_SecondCTRSubmital.Size = new System.Drawing.Size(796, 421);
            this.gridView_SecondCTRSubmital.TabIndex = 88;
            // 
            // gridView_ThirdCTRSubmital
            // 
            this.gridView_ThirdCTRSubmital.AllowUserToAddRows = false;
            this.gridView_ThirdCTRSubmital.AllowUserToDeleteRows = false;
            this.gridView_ThirdCTRSubmital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_ThirdCTRSubmital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_ThirdCTRSubmital.Location = new System.Drawing.Point(-2, 61);
            this.gridView_ThirdCTRSubmital.Name = "gridView_ThirdCTRSubmital";
            this.gridView_ThirdCTRSubmital.RowTemplate.Height = 25;
            this.gridView_ThirdCTRSubmital.Size = new System.Drawing.Size(796, 421);
            this.gridView_ThirdCTRSubmital.TabIndex = 105;
            // 
            // gridView_OwnerSubmital
            // 
            this.gridView_OwnerSubmital.AllowUserToAddRows = false;
            this.gridView_OwnerSubmital.AllowUserToDeleteRows = false;
            this.gridView_OwnerSubmital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_OwnerSubmital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_OwnerSubmital.Location = new System.Drawing.Point(-2, 61);
            this.gridView_OwnerSubmital.Name = "gridView_OwnerSubmital";
            this.gridView_OwnerSubmital.RowTemplate.Height = 25;
            this.gridView_OwnerSubmital.Size = new System.Drawing.Size(796, 421);
            this.gridView_OwnerSubmital.TabIndex = 117;
            // 
            // gridView_RetDeds
            // 
            this.gridView_RetDeds.AllowUserToAddRows = false;
            this.gridView_RetDeds.AllowUserToDeleteRows = false;
            this.gridView_RetDeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_RetDeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_RetDeds.Location = new System.Drawing.Point(-2, 61);
            this.gridView_RetDeds.Name = "gridView_RetDeds";
            this.gridView_RetDeds.RowTemplate.Height = 25;
            this.gridView_RetDeds.Size = new System.Drawing.Size(796, 421);
            this.gridView_RetDeds.TabIndex = 119;
            // 
            // frm_SepProjectDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_SepProjectDocs";
            this.Text = "Project Documents";
            this.Load += new System.EventHandler(this.frm_NewDoc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_basicInfo.ResumeLayout(false);
            this.tabPage_firstCtrConsltSubmittal.ResumeLayout(false);
            this.tabPage_secondCtrConsltSubmittal.ResumeLayout(false);
            this.tabPage_thirdCtrConsltSubmittal.ResumeLayout(false);
            this.tabPage_SubmitToOwner.ResumeLayout(false);
            this.tabPage_Retentions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_BasicInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_FirstCTRSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SecondCTRSubmital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ThirdCTRSubmital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OwnerSubmital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_RetDeds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage_basicInfo;
        private TabPage tabPage_firstCtrConsltSubmittal;
        private TabPage tabPage_secondCtrConsltSubmittal;
        private TabPage tabPage_thirdCtrConsltSubmittal;
        private Button btn_BasicInfoCancel;
        private Button btn_BasicInfoNext;
        private Button btn_FirsCtrSubmitalBack;
        private Button btn_FirstCtrSubmittalNext;
        private Button btn_SecondCtrSubmitalBack;
        private Button btn_SecondCtrSubmittalNext;
        private Button btn_ThirdCtrSubmitalBack;
        private Button btn_ThirdCtrSubmittalNext;
        private TabPage tabPage_SubmitToOwner;
        private TabPage tabPage_Retentions;
        private Button btn_SubmitToOwnerBack;
        private Button btn_SubmitToOwnerNext;
        private Button btn_RetsDedsBack;
        private Button btn_RetsDedsSubmit;
        private DataGridView gridView_BasicInfo;
        private DataGridView gridView_FirstCTRSubmit;
        private DataGridView gridView_SecondCTRSubmital;
        private DataGridView gridView_ThirdCTRSubmital;
        private DataGridView gridView_OwnerSubmital;
        private DataGridView gridView_RetDeds;
    }
}