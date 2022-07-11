namespace SalesWinApp
{
    partial class frmSearchProduct
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
            this.lbTypeSearch = new System.Windows.Forms.Label();
            this.cmbTypeSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTypeSearch
            // 
            this.lbTypeSearch.AutoSize = true;
            this.lbTypeSearch.Location = new System.Drawing.Point(77, 42);
            this.lbTypeSearch.Name = "lbTypeSearch";
            this.lbTypeSearch.Size = new System.Drawing.Size(88, 20);
            this.lbTypeSearch.TabIndex = 0;
            this.lbTypeSearch.Text = "Type Search";
            // 
            // cmbTypeSearch
            // 
            this.cmbTypeSearch.FormattingEnabled = true;
            this.cmbTypeSearch.Location = new System.Drawing.Point(223, 42);
            this.cmbTypeSearch.Name = "cmbTypeSearch";
            this.cmbTypeSearch.Size = new System.Drawing.Size(151, 28);
            this.cmbTypeSearch.TabIndex = 1;
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(105, 109);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(125, 27);
            this.txtSearch1.TabIndex = 2;
            // 
            // txtSearch2
            // 
            this.txtSearch2.Location = new System.Drawing.Point(345, 109);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(125, 27);
            this.txtSearch2.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(234, 185);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmSearchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch2);
            this.Controls.Add(this.txtSearch1);
            this.Controls.Add(this.cmbTypeSearch);
            this.Controls.Add(this.lbTypeSearch);
            this.Name = "frmSearchProduct";
            this.Text = "frmSearchProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbTypeSearch;
        private ComboBox cmbTypeSearch;
        private TextBox txtSearch1;
        private TextBox txtSearch2;
        private Button btnSearch;
    }
}