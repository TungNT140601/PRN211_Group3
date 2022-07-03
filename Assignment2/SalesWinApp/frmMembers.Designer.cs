namespace SalesWinApp
{
    partial class frmMembers
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
            this.dgvMember = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMember
            // 
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Location = new System.Drawing.Point(399, 12);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.RowTemplate.Height = 25;
            this.dgvMember.Size = new System.Drawing.Size(643, 570);
            this.dgvMember.TabIndex = 0;
            // 
            // frmMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 594);
            this.Controls.Add(this.dgvMember);
            this.Name = "frmMembers";
            this.Text = "frmMembers";
            this.Load += new System.EventHandler(this.frmMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvMember;
    }
}