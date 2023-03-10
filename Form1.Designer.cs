
namespace Banking_Management_System
{
    partial class Form_Parent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadingPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginsignUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAgentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerNewAgentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginSignUpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingPageToolStripMenuItem,
            this.manageAgentsToolStripMenuItem,
            this.manageCustomerToolStripMenuItem,
            this.mainMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadingPageToolStripMenuItem
            // 
            this.loadingPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginsignUpToolStripMenuItem,
            this.loginSignUpToolStripMenuItem1});
            this.loadingPageToolStripMenuItem.Name = "loadingPageToolStripMenuItem";
            this.loadingPageToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.loadingPageToolStripMenuItem.Text = "Userform";
            // 
            // loginsignUpToolStripMenuItem
            // 
            this.loginsignUpToolStripMenuItem.Name = "loginsignUpToolStripMenuItem";
            this.loginsignUpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginsignUpToolStripMenuItem.Text = "Loading screen";
            // 
            // manageAgentsToolStripMenuItem
            // 
            this.manageAgentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerNewAgentsToolStripMenuItem});
            this.manageAgentsToolStripMenuItem.Name = "manageAgentsToolStripMenuItem";
            this.manageAgentsToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.manageAgentsToolStripMenuItem.Text = "Manage agents ";
            // 
            // registerNewAgentsToolStripMenuItem
            // 
            this.registerNewAgentsToolStripMenuItem.Name = "registerNewAgentsToolStripMenuItem";
            this.registerNewAgentsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.registerNewAgentsToolStripMenuItem.Text = "Register New agents ";
            // 
            // manageCustomerToolStripMenuItem
            // 
            this.manageCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewCustomerToolStripMenuItem});
            this.manageCustomerToolStripMenuItem.Name = "manageCustomerToolStripMenuItem";
            this.manageCustomerToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.manageCustomerToolStripMenuItem.Text = "Manage customer ";
            // 
            // addNewCustomerToolStripMenuItem
            // 
            this.addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            this.addNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewCustomerToolStripMenuItem.Text = "Add new Customer ";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.transactionToolStripMenuItem});
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(22, 20);
            this.mainMenuToolStripMenuItem.Text = " ";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.accountToolStripMenuItem.Text = "Account ";
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transactionToolStripMenuItem.Text = "Transaction ";
            // 
            // loginSignUpToolStripMenuItem1
            // 
            this.loginSignUpToolStripMenuItem1.Name = "loginSignUpToolStripMenuItem1";
            this.loginSignUpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loginSignUpToolStripMenuItem1.Text = "Login/Sign up ";
            // 
            // Form_Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Parent";
            this.Text = "Parentform";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadingPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsignUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAgentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerNewAgentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginSignUpToolStripMenuItem1;
    }
}

