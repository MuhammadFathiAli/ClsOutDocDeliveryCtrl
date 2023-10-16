namespace ClsOutDocDeliveryCtrl
{
    partial class frm_NewDocument
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
            this.lbl_InsertNewDoc = new System.Windows.Forms.Label();
            this.lbl_DocName = new System.Windows.Forms.Label();
            this.lbl_DocDescription = new System.Windows.Forms.Label();
            this.txt_DocName = new System.Windows.Forms.TextBox();
            this.rtxt_DocDescription = new System.Windows.Forms.RichTextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_InsertNewDoc
            // 
            this.lbl_InsertNewDoc.AutoSize = true;
            this.lbl_InsertNewDoc.Location = new System.Drawing.Point(39, 32);
            this.lbl_InsertNewDoc.Name = "lbl_InsertNewDoc";
            this.lbl_InsertNewDoc.Size = new System.Drawing.Size(250, 15);
            this.lbl_InsertNewDoc.TabIndex = 0;
            this.lbl_InsertNewDoc.Text = "Pleas fill the following document information:";
            // 
            // lbl_DocName
            // 
            this.lbl_DocName.AutoSize = true;
            this.lbl_DocName.Location = new System.Drawing.Point(57, 113);
            this.lbl_DocName.Name = "lbl_DocName";
            this.lbl_DocName.Size = new System.Drawing.Size(39, 15);
            this.lbl_DocName.TabIndex = 1;
            this.lbl_DocName.Text = "Name";
            // 
            // lbl_DocDescription
            // 
            this.lbl_DocDescription.AutoSize = true;
            this.lbl_DocDescription.Location = new System.Drawing.Point(57, 180);
            this.lbl_DocDescription.Name = "lbl_DocDescription";
            this.lbl_DocDescription.Size = new System.Drawing.Size(71, 15);
            this.lbl_DocDescription.TabIndex = 2;
            this.lbl_DocDescription.Text = "Descriprtion";
            // 
            // txt_DocName
            // 
            this.txt_DocName.Location = new System.Drawing.Point(192, 105);
            this.txt_DocName.Name = "txt_DocName";
            this.txt_DocName.Size = new System.Drawing.Size(350, 23);
            this.txt_DocName.TabIndex = 3;
            // 
            // rtxt_DocDescription
            // 
            this.rtxt_DocDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_DocDescription.Location = new System.Drawing.Point(192, 177);
            this.rtxt_DocDescription.Name = "rtxt_DocDescription";
            this.rtxt_DocDescription.Size = new System.Drawing.Size(350, 125);
            this.rtxt_DocDescription.TabIndex = 4;
            this.rtxt_DocDescription.Text = "";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(12, 415);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(713, 415);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // frm_NewDocument
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
            this.Controls.Add(this.lbl_InsertNewDoc);
            this.Name = "frm_NewDocument";
            this.Text = "New Document";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_InsertNewDoc;
        private Label lbl_DocName;
        private Label lbl_DocDescription;
        private TextBox txt_DocName;
        private RichTextBox rtxt_DocDescription;
        private Button btn_Cancel;
        private Button btn_Save;
    }
}