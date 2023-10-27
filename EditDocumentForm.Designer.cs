namespace ClsOutDocDeliveryCtrl
{
    partial class frm_EditDocument
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rtxt_DocDescription = new System.Windows.Forms.RichTextBox();
            this.txt_DocName = new System.Windows.Forms.TextBox();
            this.lbl_DocDescription = new System.Windows.Forms.Label();
            this.lbl_DocName = new System.Windows.Forms.Label();
            this.lbl_EditDoc = new System.Windows.Forms.Label();
            this.errorProvider_EditDoc = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_EditDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(713, 414);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(12, 414);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // rtxt_DocDescription
            // 
            this.rtxt_DocDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_DocDescription.Location = new System.Drawing.Point(192, 167);
            this.rtxt_DocDescription.Name = "rtxt_DocDescription";
            this.rtxt_DocDescription.Size = new System.Drawing.Size(350, 125);
            this.rtxt_DocDescription.TabIndex = 11;
            this.rtxt_DocDescription.Text = "";
            // 
            // txt_DocName
            // 
            this.txt_DocName.Location = new System.Drawing.Point(192, 95);
            this.txt_DocName.Name = "txt_DocName";
            this.txt_DocName.Size = new System.Drawing.Size(350, 23);
            this.txt_DocName.TabIndex = 10;
            // 
            // lbl_DocDescription
            // 
            this.lbl_DocDescription.AutoSize = true;
            this.lbl_DocDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DocDescription.Location = new System.Drawing.Point(57, 170);
            this.lbl_DocDescription.Name = "lbl_DocDescription";
            this.lbl_DocDescription.Size = new System.Drawing.Size(81, 17);
            this.lbl_DocDescription.TabIndex = 9;
            this.lbl_DocDescription.Text = "Descriprtion";
            // 
            // lbl_DocName
            // 
            this.lbl_DocName.AutoSize = true;
            this.lbl_DocName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_DocName.Location = new System.Drawing.Point(57, 103);
            this.lbl_DocName.Name = "lbl_DocName";
            this.lbl_DocName.Size = new System.Drawing.Size(44, 17);
            this.lbl_DocName.TabIndex = 8;
            this.lbl_DocName.Text = "Name";
            // 
            // lbl_EditDoc
            // 
            this.lbl_EditDoc.AutoSize = true;
            this.lbl_EditDoc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_EditDoc.Location = new System.Drawing.Point(39, 22);
            this.lbl_EditDoc.Name = "lbl_EditDoc";
            this.lbl_EditDoc.Size = new System.Drawing.Size(352, 21);
            this.lbl_EditDoc.TabIndex = 7;
            this.lbl_EditDoc.Text = "Please fill the following document information:";
            // 
            // errorProvider_EditDoc
            // 
            this.errorProvider_EditDoc.ContainerControl = this;
            // 
            // frm_EditDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.rtxt_DocDescription);
            this.Controls.Add(this.txt_DocName);
            this.Controls.Add(this.lbl_DocDescription);
            this.Controls.Add(this.lbl_DocName);
            this.Controls.Add(this.lbl_EditDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_EditDocument";
            this.Text = "Edit Document";
            this.Load += new System.EventHandler(this.frm_EditDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_EditDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Save;
        private Button btn_Cancel;
        private RichTextBox rtxt_DocDescription;
        private TextBox txt_DocName;
        private Label lbl_DocDescription;
        private Label lbl_DocName;
        private Label lbl_EditDoc;
        private ErrorProvider errorProvider_EditDoc;
    }
}