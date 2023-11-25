namespace ClsOutDocDeliveryCtrl
{
    partial class frm_MoreInfo
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
            this.lbl_DocName = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.lbl_DocNameValue = new System.Windows.Forms.Label();
            this.lbl_DescriptionValue = new System.Windows.Forms.Label();
            this.lbl_ContentValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_DocName
            // 
            this.lbl_DocName.AutoSize = true;
            this.lbl_DocName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DocName.Location = new System.Drawing.Point(73, 34);
            this.lbl_DocName.Name = "lbl_DocName";
            this.lbl_DocName.Size = new System.Drawing.Size(111, 17);
            this.lbl_DocName.TabIndex = 0;
            this.lbl_DocName.Text = "Document Name";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_description.Location = new System.Drawing.Point(73, 116);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(83, 17);
            this.lbl_description.TabIndex = 1;
            this.lbl_description.Text = "Description :";
            // 
            // lbl_Content
            // 
            this.lbl_Content.AutoSize = true;
            this.lbl_Content.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Content.Location = new System.Drawing.Point(73, 254);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(135, 17);
            this.lbl_Content.TabIndex = 2;
            this.lbl_Content.Text = "Document Content : ";
            // 
            // lbl_DocNameValue
            // 
            this.lbl_DocNameValue.AutoSize = true;
            this.lbl_DocNameValue.Location = new System.Drawing.Point(304, 34);
            this.lbl_DocNameValue.Name = "lbl_DocNameValue";
            this.lbl_DocNameValue.Size = new System.Drawing.Size(98, 15);
            this.lbl_DocNameValue.TabIndex = 3;
            this.lbl_DocNameValue.Text = "Document Name";
            // 
            // lbl_DescriptionValue
            // 
            this.lbl_DescriptionValue.AutoSize = true;
            this.lbl_DescriptionValue.Location = new System.Drawing.Point(304, 116);
            this.lbl_DescriptionValue.MaximumSize = new System.Drawing.Size(300, 0);
            this.lbl_DescriptionValue.Name = "lbl_DescriptionValue";
            this.lbl_DescriptionValue.Size = new System.Drawing.Size(126, 15);
            this.lbl_DescriptionValue.TabIndex = 4;
            this.lbl_DescriptionValue.Text = "Document Description";
            // 
            // lbl_ContentValue
            // 
            this.lbl_ContentValue.AutoSize = true;
            this.lbl_ContentValue.Location = new System.Drawing.Point(304, 254);
            this.lbl_ContentValue.Name = "lbl_ContentValue";
            this.lbl_ContentValue.Size = new System.Drawing.Size(92, 15);
            this.lbl_ContentValue.TabIndex = 5;
            this.lbl_ContentValue.Text = "Table of content";
            // 
            // frm_MoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_ContentValue);
            this.Controls.Add(this.lbl_DescriptionValue);
            this.Controls.Add(this.lbl_DocNameValue);
            this.Controls.Add(this.lbl_Content);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_DocName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_MoreInfo";
            this.Text = "Document More Info";
            this.Load += new System.EventHandler(this.frm_MoreInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_DocName;
        private Label lbl_description;
        private Label lbl_Content;
        private Label lbl_DocNameValue;
        private Label lbl_DescriptionValue;
        private Label lbl_ContentValue;
    }
}