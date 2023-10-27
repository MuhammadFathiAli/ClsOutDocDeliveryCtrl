namespace ClsOutDocDeliveryCtrl
{
    partial class frm_StartUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StartUp));
            this.btn_Start = new System.Windows.Forms.Button();
            this.richTxt_Intro = new System.Windows.Forms.RichTextBox();
            this.lbl_PrjName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Start.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Start.Location = new System.Drawing.Point(277, 365);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(192, 61);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // richTxt_Intro
            // 
            this.richTxt_Intro.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTxt_Intro.Location = new System.Drawing.Point(94, 79);
            this.richTxt_Intro.Name = "richTxt_Intro";
            this.richTxt_Intro.Size = new System.Drawing.Size(582, 280);
            this.richTxt_Intro.TabIndex = 1;
            this.richTxt_Intro.Text = resources.GetString("richTxt_Intro.Text");
            // 
            // lbl_PrjName
            // 
            this.lbl_PrjName.AutoSize = true;
            this.lbl_PrjName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_PrjName.Location = new System.Drawing.Point(94, 30);
            this.lbl_PrjName.Name = "lbl_PrjName";
            this.lbl_PrjName.Size = new System.Drawing.Size(579, 32);
            this.lbl_PrjName.TabIndex = 2;
            this.lbl_PrjName.Text = "Close Out Documents Delivery Control APP\r\n";
            // 
            // frm_StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_PrjName);
            this.Controls.Add(this.richTxt_Intro);
            this.Controls.Add(this.btn_Start);
            this.Name = "frm_StartUp";
            this.Text = "StartUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Start;
        private RichTextBox richTxt_Intro;
        private Label lbl_PrjName;
    }
}