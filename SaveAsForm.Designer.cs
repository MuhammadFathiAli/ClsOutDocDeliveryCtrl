namespace ClsOutDocDeliveryCtrl
{
    partial class frm_SaveAs
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
            this.lbl_newProjectName = new System.Windows.Forms.Label();
            this.txt_NewProjectName = new System.Windows.Forms.TextBox();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_newProjectName
            // 
            this.lbl_newProjectName.AutoSize = true;
            this.lbl_newProjectName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_newProjectName.Location = new System.Drawing.Point(80, 22);
            this.lbl_newProjectName.Name = "lbl_newProjectName";
            this.lbl_newProjectName.Size = new System.Drawing.Size(121, 17);
            this.lbl_newProjectName.TabIndex = 0;
            this.lbl_newProjectName.Text = "New Project Name";
            // 
            // txt_NewProjectName
            // 
            this.txt_NewProjectName.Location = new System.Drawing.Point(12, 53);
            this.txt_NewProjectName.Name = "txt_NewProjectName";
            this.txt_NewProjectName.Size = new System.Drawing.Size(277, 23);
            this.txt_NewProjectName.TabIndex = 1;
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Location = new System.Drawing.Point(103, 90);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveAs.TabIndex = 2;
            this.btn_SaveAs.Text = "Save";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // frm_SaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 121);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.txt_NewProjectName);
            this.Controls.Add(this.lbl_newProjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_SaveAs";
            this.Text = "Save as";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_newProjectName;
        private TextBox txt_NewProjectName;
        private Button btn_SaveAs;
    }
}