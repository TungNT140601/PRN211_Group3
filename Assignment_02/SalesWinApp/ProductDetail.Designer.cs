namespace SalesWinApp
{
    partial class ProductDetail
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
            this.lbProductID = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbCategogyId = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.lbUnitPrice = new System.Windows.Forms.Label();
            this.lbUnitslnStock = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategogyId = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtUnitslnStock = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbProductID
            // 
            this.lbProductID.AutoSize = true;
            this.lbProductID.Location = new System.Drawing.Point(108, 32);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(59, 15);
            this.lbProductID.TabIndex = 0;
            this.lbProductID.Text = "ProductId";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Location = new System.Drawing.Point(108, 77);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(81, 15);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "ProductName";
            // 
            // lbCategogyId
            // 
            this.lbCategogyId.AutoSize = true;
            this.lbCategogyId.Location = new System.Drawing.Point(108, 119);
            this.lbCategogyId.Name = "lbCategogyId";
            this.lbCategogyId.Size = new System.Drawing.Size(68, 15);
            this.lbCategogyId.TabIndex = 2;
            this.lbCategogyId.Text = "CategogyId";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(343, 32);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(45, 15);
            this.lbWeight.TabIndex = 3;
            this.lbWeight.Text = "Weight";
            // 
            // lbUnitPrice
            // 
            this.lbUnitPrice.AutoSize = true;
            this.lbUnitPrice.Location = new System.Drawing.Point(343, 77);
            this.lbUnitPrice.Name = "lbUnitPrice";
            this.lbUnitPrice.Size = new System.Drawing.Size(55, 15);
            this.lbUnitPrice.TabIndex = 4;
            this.lbUnitPrice.Text = "UnitPrice";
            // 
            // lbUnitslnStock
            // 
            this.lbUnitslnStock.AutoSize = true;
            this.lbUnitslnStock.Location = new System.Drawing.Point(343, 119);
            this.lbUnitslnStock.Name = "lbUnitslnStock";
            this.lbUnitslnStock.Size = new System.Drawing.Size(73, 15);
            this.lbUnitslnStock.TabIndex = 5;
            this.lbUnitslnStock.Text = "UnitslnStock";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(108, 191);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(308, 191);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(178, 32);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(110, 23);
            this.txtProductID.TabIndex = 8;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(193, 72);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(110, 23);
            this.txtProductName.TabIndex = 9;
            // 
            // txtCategogyId
            // 
            this.txtCategogyId.Location = new System.Drawing.Point(193, 119);
            this.txtCategogyId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategogyId.Name = "txtCategogyId";
            this.txtCategogyId.Size = new System.Drawing.Size(110, 23);
            this.txtCategogyId.TabIndex = 10;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(397, 32);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(110, 23);
            this.txtWeight.TabIndex = 11;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(408, 75);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(110, 23);
            this.txtUnitPrice.TabIndex = 12;
            // 
            // txtUnitslnStock
            // 
            this.txtUnitslnStock.Location = new System.Drawing.Point(427, 117);
            this.txtUnitslnStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnitslnStock.Name = "txtUnitslnStock";
            this.txtUnitslnStock.Size = new System.Drawing.Size(110, 23);
            this.txtUnitslnStock.TabIndex = 13;
            // 
            // ProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.txtUnitslnStock);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtCategogyId);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbUnitslnStock);
            this.Controls.Add(this.lbUnitPrice);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lbCategogyId);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbProductID);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductDetail";
            this.Text = "ProductDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbProductID;
        private Label lbProductName;
        private Label lbCategogyId;
        private Label lbWeight;
        private Label lbUnitPrice;
        private Label lbUnitslnStock;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private TextBox txtCategogyId;
        private TextBox txtWeight;
        private TextBox txtUnitPrice;
        private TextBox txtUnitslnStock;
    }
}