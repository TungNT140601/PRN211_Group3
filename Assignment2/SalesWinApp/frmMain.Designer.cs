namespace SalesWinApp
{
    partial class frmMain
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewAllProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewProductAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewProductAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHistoryOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewAllOrderAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.memberMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.memberManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewAllMemberAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewMemberAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbHello = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.lbHello});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsMenu,
            this.ordersMenu,
            this.memberMenu});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // productsMenu
            // 
            this.productsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewAllProduct,
            this.ProductManagement});
            this.productsMenu.Name = "productsMenu";
            this.productsMenu.Size = new System.Drawing.Size(180, 26);
            this.productsMenu.Text = "Products";
            // 
            // btnViewAllProduct
            // 
            this.btnViewAllProduct.Name = "btnViewAllProduct";
            this.btnViewAllProduct.Size = new System.Drawing.Size(230, 26);
            this.btnViewAllProduct.Text = "View All Product";
            this.btnViewAllProduct.Click += new System.EventHandler(this.btnViewAllProduct_Click);
            // 
            // ProductManagement
            // 
            this.ProductManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewProductAdmin,
            this.btnAddNewProductAdmin});
            this.ProductManagement.Name = "ProductManagement";
            this.ProductManagement.Size = new System.Drawing.Size(230, 26);
            this.ProductManagement.Text = "Product Management";
            // 
            // btnViewProductAdmin
            // 
            this.btnViewProductAdmin.Name = "btnViewProductAdmin";
            this.btnViewProductAdmin.Size = new System.Drawing.Size(202, 26);
            this.btnViewProductAdmin.Text = "View All Products";
            this.btnViewProductAdmin.Click += new System.EventHandler(this.btnViewProductAdmin_Click);
            // 
            // btnAddNewProductAdmin
            // 
            this.btnAddNewProductAdmin.Name = "btnAddNewProductAdmin";
            this.btnAddNewProductAdmin.Size = new System.Drawing.Size(202, 26);
            this.btnAddNewProductAdmin.Text = "Add New Product";
            this.btnAddNewProductAdmin.Click += new System.EventHandler(this.btnAddNewProductAdmin_Click);
            // 
            // ordersMenu
            // 
            this.ordersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHistoryOrder,
            this.orderManagement});
            this.ordersMenu.Name = "ordersMenu";
            this.ordersMenu.Size = new System.Drawing.Size(180, 26);
            this.ordersMenu.Text = "Orders";
            // 
            // viewHistoryOrder
            // 
            this.viewHistoryOrder.Name = "viewHistoryOrder";
            this.viewHistoryOrder.Size = new System.Drawing.Size(217, 26);
            this.viewHistoryOrder.Text = "View History Order";
            this.viewHistoryOrder.Click += new System.EventHandler(this.viewHistoryOrder_Click);
            // 
            // orderManagement
            // 
            this.orderManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewAllOrderAdmin});
            this.orderManagement.Name = "orderManagement";
            this.orderManagement.Size = new System.Drawing.Size(217, 26);
            this.orderManagement.Text = "Order Management";
            // 
            // btnViewAllOrderAdmin
            // 
            this.btnViewAllOrderAdmin.Name = "btnViewAllOrderAdmin";
            this.btnViewAllOrderAdmin.Size = new System.Drawing.Size(181, 26);
            this.btnViewAllOrderAdmin.Text = "View All Order";
            this.btnViewAllOrderAdmin.Click += new System.EventHandler(this.btnViewAllOrderAdmin_Click);
            // 
            // memberMenu
            // 
            this.memberMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberManagementToolStripMenuItem,
            this.btnLogout});
            this.memberMenu.Name = "memberMenu";
            this.memberMenu.Size = new System.Drawing.Size(180, 26);
            this.memberMenu.Text = "Member";
            // 
            // memberManagementToolStripMenuItem
            // 
            this.memberManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewAllMemberAdmin,
            this.btnAddNewMemberAdmin});
            this.memberManagementToolStripMenuItem.Name = "memberManagementToolStripMenuItem";
            this.memberManagementToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.memberManagementToolStripMenuItem.Text = "Member Management";
            // 
            // btnViewAllMemberAdmin
            // 
            this.btnViewAllMemberAdmin.Name = "btnViewAllMemberAdmin";
            this.btnViewAllMemberAdmin.Size = new System.Drawing.Size(207, 26);
            this.btnViewAllMemberAdmin.Text = "View All Members";
            this.btnViewAllMemberAdmin.Click += new System.EventHandler(this.btnViewAllMemberAdmin_Click);
            // 
            // btnAddNewMemberAdmin
            // 
            this.btnAddNewMemberAdmin.Name = "btnAddNewMemberAdmin";
            this.btnAddNewMemberAdmin.Size = new System.Drawing.Size(207, 26);
            this.btnAddNewMemberAdmin.Text = "Add New Member";
            this.btnAddNewMemberAdmin.Click += new System.EventHandler(this.btnAddNewMemberAdmin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(235, 26);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbHello
            // 
            this.lbHello.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHello.Name = "lbHello";
            this.lbHello.Size = new System.Drawing.Size(58, 25);
            this.lbHello.Text = "Hello";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 730);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem memberMenu;
        private ToolStripMenuItem productsMenu;
        private ToolStripMenuItem ordersMenu;
        private ToolStripMenuItem btnViewAllProduct;
        private ToolStripMenuItem ProductManagement;
        private ToolStripMenuItem orderManagement;
        private ToolStripMenuItem viewHistoryOrder;
        private ToolStripMenuItem memberManagementToolStripMenuItem;
        private ToolStripMenuItem btnViewAllMemberAdmin;
        private ToolStripMenuItem btnAddNewMemberAdmin;
        private ToolStripMenuItem btnLogout;
        private ToolStripMenuItem btnViewProductAdmin;
        private ToolStripMenuItem btnAddNewProductAdmin;
        private ToolStripMenuItem btnViewAllOrderAdmin;
        private ToolStripMenuItem lbHello;
    }
}