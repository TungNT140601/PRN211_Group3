namespace SalesWinApp
{
    partial class frmProductDetails
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
            this.lbCategoryId = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.lbUnitPrice = new System.Windows.Forms.Label();
            this.lbUnitslnStock = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtUnitslnStock = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProductID
            // 
            this.lbProductID.AutoSize = true;
            this.lbProductID.Location = new System.Drawing.Point(82, 30);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(77, 20);
            this.lbProductID.TabIndex = 0;
            this.lbProductID.Text = "ProductId ";
            this.lbProductID.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Location = new System.Drawing.Point(82, 86);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(100, 20);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "ProductName";
            // 
            // lbCategoryId
            // 
            this.lbCategoryId.AutoSize = true;
            this.lbCategoryId.Location = new System.Drawing.Point(82, 151);
            this.lbCategoryId.Name = "lbCategoryId";
            this.lbCategoryId.Size = new System.Drawing.Size(82, 20);
            this.lbCategoryId.TabIndex = 2;
            this.lbCategoryId.Text = "CategoryId";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(482, 30);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(56, 20);
            this.lbWeight.TabIndex = 3;
            this.lbWeight.Text = "Weight";
            // 
            // lbUnitPrice
            // 
            this.lbUnitPrice.AutoSize = true;
            this.lbUnitPrice.Location = new System.Drawing.Point(482, 86);
            this.lbUnitPrice.Name = "lbUnitPrice";
            this.lbUnitPrice.Size = new System.Drawing.Size(68, 20);
            this.lbUnitPrice.TabIndex = 4;
            this.lbUnitPrice.Text = "UnitPrice";
            // 
            // lbUnitslnStock
            // 
            this.lbUnitslnStock.AutoSize = true;
            this.lbUnitslnStock.Location = new System.Drawing.Point(488, 151);
            this.lbUnitslnStock.Name = "lbUnitslnStock";
            this.lbUnitslnStock.Size = new System.Drawing.Size(90, 20);
            this.lbUnitslnStock.TabIndex = 5;
            this.lbUnitslnStock.Text = "UnitslnStock";
            this.lbUnitslnStock.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(198, 30);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(125, 27);
            this.txtProductID.TabIndex = 6;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(198, 83);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(125, 27);
            this.txtProductName.TabIndex = 7;
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(198, 144);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(125, 27);
            this.txtCategoryId.TabIndex = 8;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(585, 27);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(125, 27);
            this.txtWeight.TabIndex = 9;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(585, 83);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(125, 27);
            this.txtUnitPrice.TabIndex = 10;
            this.txtUnitPrice.Text = "0";
            // 
            // txtUnitslnStock
            // 
            this.txtUnitslnStock.Location = new System.Drawing.Point(585, 144);
            this.txtUnitslnStock.Name = "txtUnitslnStock";
            this.txtUnitslnStock.Size = new System.Drawing.Size(125, 27);
            this.txtUnitslnStock.TabIndex = 11;
            this.txtUnitslnStock.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(198, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(488, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUnitslnStock);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lbUnitslnStock);
            this.Controls.Add(this.lbUnitPrice);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lbCategoryId);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbProductID);
            this.Name = "frmProductDetails";
            this.Text = "frmProductDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbProductID;
        private Label lbProductName;
        private Label lbCategoryId;
        private Label lbWeight;
        private Label lbUnitPrice;
        private Label lbUnitslnStock;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private TextBox txtCategoryId;
        private TextBox txtWeight;
        private TextBox txtUnitPrice;
        private TextBox txtUnitslnStock;
        private Button btnSave;
        private Button btnCancel;
    }
}