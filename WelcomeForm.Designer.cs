namespace ClsOutDocDeliveryCtrl
{
    partial class frm_welcome
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
            this.lbl_PrjName = new System.Windows.Forms.Label();
            this.btn_NewPrjct = new System.Windows.Forms.Button();
            this.btn_ProjectSearch = new System.Windows.Forms.Button();
            this.cmbox_Recents = new System.Windows.Forms.ComboBox();
            this.lbl_Recents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_PrjName
            // 
            this.lbl_PrjName.AutoSize = true;
            this.lbl_PrjName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lbl_PrjName.Location = new System.Drawing.Point(97, 34);
            this.lbl_PrjName.Name = "lbl_PrjName";
            this.lbl_PrjName.Size = new System.Drawing.Size(581, 32);
            this.lbl_PrjName.TabIndex = 2;
            this.lbl_PrjName.Text = "Close-Out Documents Delivery Control APP";
            // 
            // btn_NewPrjct
            // 
            this.btn_NewPrjct.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_NewPrjct.Location = new System.Drawing.Point(97, 120);
            this.btn_NewPrjct.Name = "btn_NewPrjct";
            this.btn_NewPrjct.Size = new System.Drawing.Size(186, 38);
            this.btn_NewPrjct.TabIndex = 3;
            this.btn_NewPrjct.Text = "New Project";
            this.btn_NewPrjct.UseVisualStyleBackColor = true;
            this.btn_NewPrjct.Click += new System.EventHandler(this.btn_NewPrjct_Click);
            // 
            // btn_ProjectSearch
            // 
            this.btn_ProjectSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ProjectSearch.Location = new System.Drawing.Point(97, 186);
            this.btn_ProjectSearch.Name = "btn_ProjectSearch";
            this.btn_ProjectSearch.Size = new System.Drawing.Size(186, 38);
            this.btn_ProjectSearch.TabIndex = 4;
            this.btn_ProjectSearch.Text = "Open Project";
            this.btn_ProjectSearch.UseVisualStyleBackColor = true;
            this.btn_ProjectSearch.Click += new System.EventHandler(this.btn_ProjectSearch_Click);
            // 
            // cmbox_Recents
            // 
            this.cmbox_Recents.FormattingEnabled = true;
            this.cmbox_Recents.Location = new System.Drawing.Point(315, 250);
            this.cmbox_Recents.Name = "cmbox_Recents";
            this.cmbox_Recents.Size = new System.Drawing.Size(207, 40);
            this.cmbox_Recents.TabIndex = 6;
            this.cmbox_Recents.Text = "Recents";
            this.cmbox_Recents.SelectedIndexChanged += new System.EventHandler(this.cmbox_Recents_SelectedIndexChanged);
            // 
            // lbl_Recents
            // 
            this.lbl_Recents.AutoSize = true;
            this.lbl_Recents.Location = new System.Drawing.Point(107, 250);
            this.lbl_Recents.Name = "lbl_Recents";
            this.lbl_Recents.Size = new System.Drawing.Size(122, 32);
            this.lbl_Recents.TabIndex = 7;
            this.lbl_Recents.Text = "Recents";
            // 
            // frm_welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Recents);
            this.Controls.Add(this.cmbox_Recents);
            this.Controls.Add(this.btn_ProjectSearch);
            this.Controls.Add(this.btn_NewPrjct);
            this.Controls.Add(this.lbl_PrjName);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(109, 31);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.Name = "frm_welcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.frm_welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_PrjName;
        private Button btn_NewPrjct;
        private Button btn_ProjectSearch;
        private ComboBox cmbox_Recents;
        private Label lbl_Recents;
    }
}