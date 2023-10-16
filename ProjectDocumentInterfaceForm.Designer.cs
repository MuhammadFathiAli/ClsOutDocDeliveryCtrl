namespace ClsOutDocDeliveryCtrl
{
    partial class frm_ProjectDocumentInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectDocumentInterface));
            this.lbl_AddDelete = new System.Windows.Forms.Label();
            this.gridView_ProjectDocsList = new System.Windows.Forms.DataGridView();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Finish = new System.Windows.Forms.Button();
            this.btn_AddDoc = new System.Windows.Forms.Button();
            this.img_AddDoc = new System.Windows.Forms.ImageList(this.components);
            this.btn_DeleteDoc = new System.Windows.Forms.Button();
            this.img_deleteDoc = new System.Windows.Forms.ImageList(this.components);
            this.btn_EditDoc = new System.Windows.Forms.Button();
            this.lbl_DocSearch = new System.Windows.Forms.Label();
            this.txt_DocSearch = new System.Windows.Forms.TextBox();
            this.img_EditDoc = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectDocsList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_AddDelete
            // 
            this.lbl_AddDelete.AutoSize = true;
            this.lbl_AddDelete.Location = new System.Drawing.Point(12, 54);
            this.lbl_AddDelete.Name = "lbl_AddDelete";
            this.lbl_AddDelete.Size = new System.Drawing.Size(346, 15);
            this.lbl_AddDelete.TabIndex = 0;
            this.lbl_AddDelete.Text = "Please add/delete all documents according to project\'s contract:";
            // 
            // gridView_ProjectDocsList
            // 
            this.gridView_ProjectDocsList.AllowUserToAddRows = false;
            this.gridView_ProjectDocsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_ProjectDocsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridView_ProjectDocsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridView_ProjectDocsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_ProjectDocsList.Location = new System.Drawing.Point(1, 89);
            this.gridView_ProjectDocsList.Name = "gridView_ProjectDocsList";
            this.gridView_ProjectDocsList.RowTemplate.Height = 25;
            this.gridView_ProjectDocsList.Size = new System.Drawing.Size(689, 279);
            this.gridView_ProjectDocsList.TabIndex = 1;
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Back.Location = new System.Drawing.Point(12, 415);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // btn_Finish
            // 
            this.btn_Finish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Finish.Location = new System.Drawing.Point(604, 415);
            this.btn_Finish.Name = "btn_Finish";
            this.btn_Finish.Size = new System.Drawing.Size(75, 23);
            this.btn_Finish.TabIndex = 3;
            this.btn_Finish.Text = "Finish";
            this.btn_Finish.UseVisualStyleBackColor = true;
            // 
            // btn_AddDoc
            // 
            this.btn_AddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AddDoc.ImageIndex = 0;
            this.btn_AddDoc.ImageList = this.img_AddDoc;
            this.btn_AddDoc.Location = new System.Drawing.Point(12, 374);
            this.btn_AddDoc.Name = "btn_AddDoc";
            this.btn_AddDoc.Size = new System.Drawing.Size(75, 23);
            this.btn_AddDoc.TabIndex = 4;
            this.btn_AddDoc.Text = "Add ";
            this.btn_AddDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddDoc.UseVisualStyleBackColor = true;
            this.btn_AddDoc.Click += new System.EventHandler(this.btn_AddDoc_Click);
            // 
            // img_AddDoc
            // 
            this.img_AddDoc.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.img_AddDoc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_AddDoc.ImageStream")));
            this.img_AddDoc.TransparentColor = System.Drawing.Color.Transparent;
            this.img_AddDoc.Images.SetKeyName(0, "green-add-button-12023.png");
            // 
            // btn_DeleteDoc
            // 
            this.btn_DeleteDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_DeleteDoc.ImageIndex = 0;
            this.btn_DeleteDoc.ImageList = this.img_deleteDoc;
            this.btn_DeleteDoc.Location = new System.Drawing.Point(254, 374);
            this.btn_DeleteDoc.Name = "btn_DeleteDoc";
            this.btn_DeleteDoc.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteDoc.TabIndex = 5;
            this.btn_DeleteDoc.Text = "Delete";
            this.btn_DeleteDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_DeleteDoc.UseVisualStyleBackColor = true;
            // 
            // img_deleteDoc
            // 
            this.img_deleteDoc.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.img_deleteDoc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_deleteDoc.ImageStream")));
            this.img_deleteDoc.TransparentColor = System.Drawing.Color.Transparent;
            this.img_deleteDoc.Images.SetKeyName(0, "delete-309165_640.png");
            // 
            // btn_EditDoc
            // 
            this.btn_EditDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_EditDoc.ImageIndex = 0;
            this.btn_EditDoc.ImageList = this.img_EditDoc;
            this.btn_EditDoc.Location = new System.Drawing.Point(133, 374);
            this.btn_EditDoc.Name = "btn_EditDoc";
            this.btn_EditDoc.Size = new System.Drawing.Size(75, 23);
            this.btn_EditDoc.TabIndex = 6;
            this.btn_EditDoc.Text = "Edit";
            this.btn_EditDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_EditDoc.UseVisualStyleBackColor = true;
            // 
            // lbl_DocSearch
            // 
            this.lbl_DocSearch.AutoSize = true;
            this.lbl_DocSearch.Location = new System.Drawing.Point(1, 18);
            this.lbl_DocSearch.Name = "lbl_DocSearch";
            this.lbl_DocSearch.Size = new System.Drawing.Size(150, 15);
            this.lbl_DocSearch.TabIndex = 8;
            this.lbl_DocSearch.Text = "Search by Document name";
            // 
            // txt_DocSearch
            // 
            this.txt_DocSearch.Location = new System.Drawing.Point(157, 15);
            this.txt_DocSearch.Name = "txt_DocSearch";
            this.txt_DocSearch.Size = new System.Drawing.Size(456, 23);
            this.txt_DocSearch.TabIndex = 7;
            this.txt_DocSearch.TextChanged += new System.EventHandler(this.txt_DocSearch_TextChanged);
            // 
            // img_EditDoc
            // 
            this.img_EditDoc.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.img_EditDoc.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_EditDoc.ImageStream")));
            this.img_EditDoc.TransparentColor = System.Drawing.Color.Transparent;
            this.img_EditDoc.Images.SetKeyName(0, "1160515.png");
            // 
            // frm_ProjectDocumentInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 451);
            this.Controls.Add(this.lbl_DocSearch);
            this.Controls.Add(this.txt_DocSearch);
            this.Controls.Add(this.btn_EditDoc);
            this.Controls.Add(this.btn_DeleteDoc);
            this.Controls.Add(this.btn_AddDoc);
            this.Controls.Add(this.btn_Finish);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.gridView_ProjectDocsList);
            this.Controls.Add(this.lbl_AddDelete);
            this.Name = "frm_ProjectDocumentInterface";
            this.Text = "Project Documents Interface";
            this.Load += new System.EventHandler(this.frm_ProjectDocumentInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectDocsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_AddDelete;
        private DataGridView gridView_ProjectDocsList;
        private Button btn_Back;
        private Button btn_Finish;
        private Button btn_AddDoc;
        private ImageList img_AddDoc;
        private Button btn_DeleteDoc;
        private Button btn_EditDoc;
        private ImageList img_deleteDoc;
        private Label lbl_DocSearch;
        private TextBox txt_DocSearch;
        private ImageList img_EditDoc;
    }
}