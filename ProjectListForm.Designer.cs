namespace ClsOutDocDeliveryCtrl
{
    partial class frm_ProjectList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_ProjectSearch = new System.Windows.Forms.TextBox();
            this.lbl_ProjectSearch = new System.Windows.Forms.Label();
            this.gridView_ProjectList = new System.Windows.Forms.DataGridView();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.contextMenuStrip_projects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brn_ProjectSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectList)).BeginInit();
            this.contextMenuStrip_projects.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ProjectSearch
            // 
            this.txt_ProjectSearch.Location = new System.Drawing.Point(193, 25);
            this.txt_ProjectSearch.Name = "txt_ProjectSearch";
            this.txt_ProjectSearch.Size = new System.Drawing.Size(1012, 23);
            this.txt_ProjectSearch.TabIndex = 1;
            this.txt_ProjectSearch.TextChanged += new System.EventHandler(this.txt_ProjectSearch_TextChanged);
            // 
            // lbl_ProjectSearch
            // 
            this.lbl_ProjectSearch.AutoSize = true;
            this.lbl_ProjectSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ProjectSearch.Location = new System.Drawing.Point(12, 28);
            this.lbl_ProjectSearch.Name = "lbl_ProjectSearch";
            this.lbl_ProjectSearch.Size = new System.Drawing.Size(132, 15);
            this.lbl_ProjectSearch.TabIndex = 2;
            this.lbl_ProjectSearch.Text = "Search by project name";
            // 
            // gridView_ProjectList
            // 
            this.gridView_ProjectList.AllowUserToAddRows = false;
            this.gridView_ProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView_ProjectList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridView_ProjectList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_ProjectList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridView_ProjectList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridView_ProjectList.Location = new System.Drawing.Point(1, 64);
            this.gridView_ProjectList.Name = "gridView_ProjectList";
            this.gridView_ProjectList.ReadOnly = true;
            this.gridView_ProjectList.RowTemplate.Height = 25;
            this.gridView_ProjectList.Size = new System.Drawing.Size(1333, 298);
            this.gridView_ProjectList.TabIndex = 3;
            // 
            // btn_Open
            // 
            this.btn_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Open.Location = new System.Drawing.Point(1259, 377);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 4;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Back.Location = new System.Drawing.Point(12, 377);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 5;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // contextMenuStrip_projects
            // 
            this.contextMenuStrip_projects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem,
            this.editProjectToolStripMenuItem,
            this.deleteProjectToolStripMenuItem,
            this.exportToPDFToolStripMenuItem});
            this.contextMenuStrip_projects.Name = "contextMenuStrip_projects";
            this.contextMenuStrip_projects.Size = new System.Drawing.Size(148, 92);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // editProjectToolStripMenuItem
            // 
            this.editProjectToolStripMenuItem.Name = "editProjectToolStripMenuItem";
            this.editProjectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editProjectToolStripMenuItem.Text = "Edit Project";
            this.editProjectToolStripMenuItem.Click += new System.EventHandler(this.editProjectToolStripMenuItem_Click);
            // 
            // deleteProjectToolStripMenuItem
            // 
            this.deleteProjectToolStripMenuItem.Name = "deleteProjectToolStripMenuItem";
            this.deleteProjectToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteProjectToolStripMenuItem.Text = "Delete Project";
            this.deleteProjectToolStripMenuItem.Click += new System.EventHandler(this.deleteProjectToolStripMenuItem_Click);
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            this.exportToPDFToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportToPDFToolStripMenuItem.Text = "Export to PDF";
            this.exportToPDFToolStripMenuItem.Click += new System.EventHandler(this.exportToPDFToolStripMenuItem_Click);
            // 
            // brn_ProjectSearch
            // 
            this.brn_ProjectSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brn_ProjectSearch.Location = new System.Drawing.Point(1227, 25);
            this.brn_ProjectSearch.Name = "brn_ProjectSearch";
            this.brn_ProjectSearch.Size = new System.Drawing.Size(107, 23);
            this.brn_ProjectSearch.TabIndex = 0;
            this.brn_ProjectSearch.Text = "Search";
            this.brn_ProjectSearch.UseVisualStyleBackColor = true;
            this.brn_ProjectSearch.Click += new System.EventHandler(this.brn_ProjectSearch_Click);
            // 
            // frm_ProjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 412);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.gridView_ProjectList);
            this.Controls.Add(this.lbl_ProjectSearch);
            this.Controls.Add(this.txt_ProjectSearch);
            this.Controls.Add(this.brn_ProjectSearch);
            this.Name = "frm_ProjectList";
            this.Text = "Project List";
            this.Load += new System.EventHandler(this.ProjectListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ProjectList)).EndInit();
            this.contextMenuStrip_projects.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txt_ProjectSearch;
        private Label lbl_ProjectSearch;
        private DataGridView gridView_ProjectList;
        private Button btn_Open;
        private Button btn_Back;
        private ContextMenuStrip contextMenuStrip_projects;
        private ToolStripMenuItem openProjectToolStripMenuItem;
        private ToolStripMenuItem editProjectToolStripMenuItem;
        private ToolStripMenuItem deleteProjectToolStripMenuItem;
        private ToolStripMenuItem exportToPDFToolStripMenuItem;
        private Button brn_ProjectSearch;
    }
}