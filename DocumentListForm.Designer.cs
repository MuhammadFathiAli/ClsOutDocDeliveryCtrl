namespace ClsOutDocDeliveryCtrl
{
    partial class frm_DocumentList
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
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.gridView_ProjectList = new System.Windows.Forms.DataGridView();
            this.lbl_ProjectSearch = new System.Windows.Forms.Label();
            this.txt_ProjectSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Back.Location = new System.Drawing.Point(54, 412);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 10;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // btn_Open
            // 
            this.btn_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Open.Location = new System.Drawing.Point(1066, 412);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 9;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            // 
            // gridView_ProjectList
            // 
            this.gridView_ProjectList.AllowUserToAddRows = false;
            this.gridView_ProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_ProjectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridView_ProjectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridView_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_ProjectList.Location = new System.Drawing.Point(43, 99);
            this.gridView_ProjectList.Name = "gridView_ProjectList";
            this.gridView_ProjectList.ReadOnly = true;
            this.gridView_ProjectList.RowTemplate.Height = 25;
            this.gridView_ProjectList.Size = new System.Drawing.Size(1087, 298);
            this.gridView_ProjectList.TabIndex = 8;
            // 
            // lbl_ProjectSearch
            // 
            this.lbl_ProjectSearch.AutoSize = true;
            this.lbl_ProjectSearch.Location = new System.Drawing.Point(54, 63);
            this.lbl_ProjectSearch.Name = "lbl_ProjectSearch";
            this.lbl_ProjectSearch.Size = new System.Drawing.Size(131, 15);
            this.lbl_ProjectSearch.TabIndex = 7;
            this.lbl_ProjectSearch.Text = "Search by project name";
            // 
            // txt_ProjectSearch
            // 
            this.txt_ProjectSearch.Location = new System.Drawing.Point(235, 60);
            this.txt_ProjectSearch.Name = "txt_ProjectSearch";
            this.txt_ProjectSearch.Size = new System.Drawing.Size(802, 23);
            this.txt_ProjectSearch.TabIndex = 6;
            // 
            // frm_DocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 495);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.gridView_ProjectList);
            this.Controls.Add(this.lbl_ProjectSearch);
            this.Controls.Add(this.txt_ProjectSearch);
            this.Name = "frm_DocumentList";
            this.Text = "DocumentListForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Back;
        private Button btn_Open;
        private DataGridView gridView_ProjectList;
        private Label lbl_ProjectSearch;
        private TextBox txt_ProjectSearch;
    }
}