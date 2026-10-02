using System.Drawing.Drawing2D;

namespace AccountingSystemForWindowsFormLast
{
    partial class frm_Main
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mainMenuStrip;

        private System.Windows.Forms.ToolStripMenuItem systemMenu;
        private System.Windows.Forms.ToolStripMenuItem accountTreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersMenuItem;

        private System.Windows.Forms.ToolStripMenuItem vouchersMenu;
        private System.Windows.Forms.ToolStripMenuItem receiptVoucherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptRegisterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentVoucherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentRegisterMenuItem;

        private System.Windows.Forms.ToolStripMenuItem invoicesMenu;
        private System.Windows.Forms.ToolStripMenuItem purchaseInvoiceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseRegisterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInvoiceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesRegisterMenuItem;

        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem stockReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountStatementMenuItem;

        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem loginMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordMenuItem;

        private System.Windows.Forms.ToolStripMenuItem databaseMenu;
        private System.Windows.Forms.ToolStripMenuItem connectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreMenuItem;

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlHeaderAccent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblBrand;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            contentPanel = new Panel();
            pnlHeader = new Panel();
            lblBrand = new Label();
            lblSubTitle = new Label();
            lblTitle = new Label();
            pnlHeaderAccent = new Panel();
            mainMenuStrip = new MenuStrip();
            loginMenu = new ToolStripMenuItem();
            loginMenuItem = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            changePasswordMenuItem = new ToolStripMenuItem();
            databaseMenu = new ToolStripMenuItem();
            connectionMenuItem = new ToolStripMenuItem();
            backupMenuItem = new ToolStripMenuItem();
            restoreMenuItem = new ToolStripMenuItem();
            systemMenu = new ToolStripMenuItem();
            accountTreeMenuItem = new ToolStripMenuItem();
            itemsMenuItem = new ToolStripMenuItem();
            usersMenuItem = new ToolStripMenuItem();
            vouchersMenu = new ToolStripMenuItem();
            receiptVoucherMenuItem = new ToolStripMenuItem();
            receiptRegisterMenuItem = new ToolStripMenuItem();
            paymentVoucherMenuItem = new ToolStripMenuItem();
            paymentRegisterMenuItem = new ToolStripMenuItem();
            invoicesMenu = new ToolStripMenuItem();
            purchaseInvoiceMenuItem = new ToolStripMenuItem();
            purchaseRegisterMenuItem = new ToolStripMenuItem();
            salesInvoiceMenuItem = new ToolStripMenuItem();
            salesRegisterMenuItem = new ToolStripMenuItem();
            reportsMenu = new ToolStripMenuItem();
            stockReportMenuItem = new ToolStripMenuItem();
            accountStatementMenuItem = new ToolStripMenuItem();
            قيوداليوميهToolStripMenuItem = new ToolStripMenuItem();
            قيوداليوميهToolStripMenuItem1 = new ToolStripMenuItem();
            pnlHeader.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(246, 248, 247);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 123);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(10);
            contentPanel.Size = new Size(1390, 731);
            contentPanel.TabIndex = 2;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 78, 58);
            pnlHeader.Controls.Add(lblBrand);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(pnlHeaderAccent);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1390, 78);
            pnlHeader.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.Dock = DockStyle.Right;
            lblBrand.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(230, 240, 235);
            lblBrand.Location = new Point(1180, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Padding = new Padding(0, 0, 24, 0);
            lblBrand.Size = new Size(210, 74);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "Accounting System";
            lblBrand.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Font = new Font("Segoe UI", 9F);
            lblSubTitle.ForeColor = Color.FromArgb(205, 225, 215);
            lblSubTitle.Location = new Point(24, 43);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(650, 24);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "إدارة الحسابات والفواتير والسندات والتقارير المالية";
            lblSubTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(650, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "نظام المحاسبة";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHeaderAccent
            // 
            pnlHeaderAccent.BackColor = Color.FromArgb(214, 170, 54);
            pnlHeaderAccent.Dock = DockStyle.Bottom;
            pnlHeaderAccent.Location = new Point(0, 74);
            pnlHeaderAccent.Name = "pnlHeaderAccent";
            pnlHeaderAccent.Size = new Size(1390, 4);
            pnlHeaderAccent.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = Color.White;
            mainMenuStrip.Font = new Font("Segoe UI", 10F);
            mainMenuStrip.ForeColor = Color.FromArgb(45, 45, 45);
            mainMenuStrip.ImageScalingSize = new Size(24, 24);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { loginMenu, databaseMenu, systemMenu, vouchersMenu, invoicesMenu, reportsMenu });
            mainMenuStrip.Location = new Point(0, 78);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(16, 7, 16, 7);
            mainMenuStrip.RightToLeft = RightToLeft.Yes;
            mainMenuStrip.Size = new Size(1390, 45);
            mainMenuStrip.TabIndex = 1;
            // 
            // loginMenu
            // 
            loginMenu.DropDownItems.AddRange(new ToolStripItem[] { loginMenuItem, logoutMenuItem, changePasswordMenuItem });
            loginMenu.Name = "loginMenu";
            loginMenu.Padding = new Padding(10, 2, 10, 2);
            loginMenu.Size = new Size(135, 31);
            loginMenu.Text = "تسجيل الدخول";
            // 
            // loginMenuItem
            // 
            loginMenuItem.Name = "loginMenuItem";
            loginMenuItem.Size = new Size(215, 28);
            loginMenuItem.Text = "تسجيل الدخول";
            loginMenuItem.Click += loginMenuItem_Click;
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(215, 28);
            logoutMenuItem.Text = "تسجيل الخروج";
            logoutMenuItem.Click += logoutMenuItem_Click;
            // 
            // changePasswordMenuItem
            // 
            changePasswordMenuItem.Name = "changePasswordMenuItem";
            changePasswordMenuItem.Size = new Size(215, 28);
            changePasswordMenuItem.Text = "تغيير كلمة المرور";
            changePasswordMenuItem.Click += changePasswordMenuItem_Click;
            // 
            // databaseMenu
            // 
            databaseMenu.DropDownItems.AddRange(new ToolStripItem[] { connectionMenuItem, backupMenuItem, restoreMenuItem });
            databaseMenu.Name = "databaseMenu";
            databaseMenu.Padding = new Padding(10, 2, 10, 2);
            databaseMenu.Size = new Size(193, 31);
            databaseMenu.Text = "إعدادات قاعدة البيانات";
            // 
            // connectionMenuItem
            // 
            connectionMenuItem.Name = "connectionMenuItem";
            connectionMenuItem.Size = new Size(253, 28);
            connectionMenuItem.Text = "ربط قاعدة البيانات";
            connectionMenuItem.Click += connectionMenuItem_Click_1;
            // 
            // backupMenuItem
            // 
            backupMenuItem.Name = "backupMenuItem";
            backupMenuItem.Size = new Size(253, 28);
            backupMenuItem.Text = "نسخ احتياطي";
            backupMenuItem.Click += backupMenuItem_Click_1;
            // 
            // restoreMenuItem
            // 
            restoreMenuItem.Name = "restoreMenuItem";
            restoreMenuItem.Size = new Size(253, 28);
            restoreMenuItem.Text = "استعادة قاعدة البيانات";
            restoreMenuItem.Click += restoreMenuItem_Click_1;
            // 
            // systemMenu
            // 
            systemMenu.DropDownItems.AddRange(new ToolStripItem[] { accountTreeMenuItem, itemsMenuItem, usersMenuItem });
            systemMenu.Name = "systemMenu";
            systemMenu.Padding = new Padding(10, 2, 10, 2);
            systemMenu.Size = new Size(76, 31);
            systemMenu.Text = "الدليل";
            // 
            // accountTreeMenuItem
            // 
            accountTreeMenuItem.Name = "accountTreeMenuItem";
            accountTreeMenuItem.Size = new Size(217, 28);
            accountTreeMenuItem.Text = "دليل الحسابات";
            accountTreeMenuItem.Click += accountTreeMenuItem_Click;
            // 
            // itemsMenuItem
            // 
            itemsMenuItem.Name = "itemsMenuItem";
            itemsMenuItem.Size = new Size(217, 28);
            itemsMenuItem.Text = "دليل الأصناف";
            itemsMenuItem.Click += itemsMenuItem_Click;
            // 
            // usersMenuItem
            // 
            usersMenuItem.Name = "usersMenuItem";
            usersMenuItem.Size = new Size(217, 28);
            usersMenuItem.Text = "إدارة المستخدمين";
            usersMenuItem.Click += usersMenuItem_Click;
            // 
            // vouchersMenu
            // 
            vouchersMenu.DropDownItems.AddRange(new ToolStripItem[] { receiptVoucherMenuItem, receiptRegisterMenuItem, paymentVoucherMenuItem, paymentRegisterMenuItem });
            vouchersMenu.Name = "vouchersMenu";
            vouchersMenu.Padding = new Padding(10, 2, 10, 2);
            vouchersMenu.Size = new Size(93, 31);
            vouchersMenu.Text = "السندات";
            // 
            // receiptVoucherMenuItem
            // 
            receiptVoucherMenuItem.Name = "receiptVoucherMenuItem";
            receiptVoucherMenuItem.Size = new Size(237, 28);
            receiptVoucherMenuItem.Text = "سند قبض";
            receiptVoucherMenuItem.Click += receiptVoucherMenuItem_Click;
            // 
            // receiptRegisterMenuItem
            // 
            receiptRegisterMenuItem.Name = "receiptRegisterMenuItem";
            receiptRegisterMenuItem.Size = new Size(237, 28);
            receiptRegisterMenuItem.Text = "سجل سندات القبض";
            // 
            // paymentVoucherMenuItem
            // 
            paymentVoucherMenuItem.Name = "paymentVoucherMenuItem";
            paymentVoucherMenuItem.Size = new Size(237, 28);
            paymentVoucherMenuItem.Text = "سند صرف";
            paymentVoucherMenuItem.Click += paymentVoucherMenuItem_Click;
            // 
            // paymentRegisterMenuItem
            // 
            paymentRegisterMenuItem.Name = "paymentRegisterMenuItem";
            paymentRegisterMenuItem.Size = new Size(237, 28);
            paymentRegisterMenuItem.Text = "سجل سندات الصرف";
            // 
            // invoicesMenu
            // 
            invoicesMenu.DropDownItems.AddRange(new ToolStripItem[] { purchaseInvoiceMenuItem, purchaseRegisterMenuItem, salesInvoiceMenuItem, salesRegisterMenuItem });
            invoicesMenu.Name = "invoicesMenu";
            invoicesMenu.Padding = new Padding(10, 2, 10, 2);
            invoicesMenu.Size = new Size(85, 31);
            invoicesMenu.Text = "الفواتير";
            // 
            // purchaseInvoiceMenuItem
            // 
            purchaseInvoiceMenuItem.Name = "purchaseInvoiceMenuItem";
            purchaseInvoiceMenuItem.Size = new Size(224, 28);
            purchaseInvoiceMenuItem.Text = "فاتورة مشتريات";
            purchaseInvoiceMenuItem.Click += purchaseInvoiceMenuItem_Click;
            // 
            // purchaseRegisterMenuItem
            // 
            purchaseRegisterMenuItem.Name = "purchaseRegisterMenuItem";
            purchaseRegisterMenuItem.Size = new Size(224, 28);
            purchaseRegisterMenuItem.Text = "سجل المشتريات";
            // 
            // salesInvoiceMenuItem
            // 
            salesInvoiceMenuItem.Name = "salesInvoiceMenuItem";
            salesInvoiceMenuItem.Size = new Size(224, 28);
            salesInvoiceMenuItem.Text = "فاتورة مبيعات";
            salesInvoiceMenuItem.Click += salesInvoiceMenuItem_Click;
            // 
            // salesRegisterMenuItem
            // 
            salesRegisterMenuItem.Name = "salesRegisterMenuItem";
            salesRegisterMenuItem.Size = new Size(224, 28);
            salesRegisterMenuItem.Text = "سجل المبيعات";
            salesRegisterMenuItem.Click += salesRegisterMenuItem_Click;
            // 
            // reportsMenu
            // 
            reportsMenu.DropDownItems.AddRange(new ToolStripItem[] { stockReportMenuItem, accountStatementMenuItem, قيوداليوميهToolStripMenuItem });
            reportsMenu.Name = "reportsMenu";
            reportsMenu.Padding = new Padding(10, 2, 10, 2);
            reportsMenu.Size = new Size(84, 31);
            reportsMenu.Text = "التقارير";
            // 
            // stockReportMenuItem
            // 
            stockReportMenuItem.Name = "stockReportMenuItem";
            stockReportMenuItem.Size = new Size(244, 28);
            stockReportMenuItem.Text = "تقرير مخزون الأصناف";
            stockReportMenuItem.Click += stockReportMenuItem_Click;
            // 
            // accountStatementMenuItem
            // 
            accountStatementMenuItem.Name = "accountStatementMenuItem";
            accountStatementMenuItem.Size = new Size(244, 28);
            accountStatementMenuItem.Text = "كشف حساب";
            accountStatementMenuItem.Click += accountStatementMenuItem_Click;
            // 
            // قيوداليوميهToolStripMenuItem
            // 
            قيوداليوميهToolStripMenuItem.Name = "قيوداليوميهToolStripMenuItem";
            قيوداليوميهToolStripMenuItem.Size = new Size(244, 28);
            قيوداليوميهToolStripMenuItem.Text = "قيود اليومية";
            قيوداليوميهToolStripMenuItem.Click += قيوداليوميهToolStripMenuItem_Click;
            // 
            // قيوداليوميهToolStripMenuItem1
            // 
            قيوداليوميهToolStripMenuItem1.Name = "قيوداليوميهToolStripMenuItem1";
            قيوداليوميهToolStripMenuItem1.Size = new Size(240, 30);
            قيوداليوميهToolStripMenuItem1.Text = "قيود اليومية";
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1390, 854);
            Controls.Add(contentPanel);
            Controls.Add(mainMenuStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            MainMenuStrip = mainMenuStrip;
            MinimumSize = new Size(1000, 650);
            Name = "frm_Main";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "نظام المحاسبة";
            Load += frm_Main_Load;
            pnlHeader.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // =============================================================
        // Icon Types
        // =============================================================

        private enum MenuIconType
        {
            Book,
            Money,
            Invoice,
            Report,
            Accounts,
            Items,
            Users,
            Receipt,
            Payment,
            Purchase,
            Sales,
            Stock,
            Statement,
            Login,
            Logout,
            Password,
            Database,
            Connection,
            Backup,
            Restore,
            Register,
            Journal
        }

        // =============================================================
        // Create Menu Icon
        // =============================================================

        private Bitmap CreateMenuIcon(MenuIconType type)
        {
            Bitmap bitmap = new Bitmap(22, 22);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Accounting system palette: deep green + light gold.
                Color green = Color.FromArgb(24, 78, 58);
                Color gold = Color.FromArgb(214, 170, 54);
                Color lightGold = Color.FromArgb(238, 211, 125);
                Color dark = Color.FromArgb(70, 70, 70);

                using Pen greenPen = new Pen(green, 1.8F);
                using Pen goldPen = new Pen(gold, 1.8F);
                using Pen darkPen = new Pen(dark, 1.4F);
                using Brush greenBrush = new SolidBrush(green);
                using Brush goldBrush = new SolidBrush(gold);
                using Brush lightGoldBrush = new SolidBrush(lightGold);

                // General / existing icons
                if (type == MenuIconType.Book)
                {
                    g.DrawRectangle(greenPen, 3, 3, 7, 16);
                    g.DrawRectangle(greenPen, 11, 3, 8, 16);
                    g.DrawLine(darkPen, 11, 4, 11, 19);
                }
                else if (type == MenuIconType.Accounts)
                {
                    g.DrawRectangle(greenPen, 3, 3, 16, 17);
                    g.DrawLine(goldPen, 6, 8, 16, 8);
                    g.DrawLine(goldPen, 6, 12, 16, 12);
                    g.DrawLine(goldPen, 6, 16, 14, 16);
                }
                else if (type == MenuIconType.Items)
                {
                    g.DrawRectangle(greenPen, 3, 5, 16, 14);
                    g.DrawLine(goldPen, 3, 9, 19, 9);
                    g.DrawLine(goldPen, 8, 9, 8, 19);
                }
                else if (type == MenuIconType.Users)
                {
                    g.DrawEllipse(greenPen, 3, 3, 7, 7);
                    g.DrawEllipse(greenPen, 12, 3, 7, 7);
                    g.DrawArc(goldPen, 2, 9, 9, 9, 180, 180);
                    g.DrawArc(goldPen, 11, 9, 9, 9, 180, 180);
                }
                else if (type == MenuIconType.Money)
                {
                    g.FillEllipse(lightGoldBrush, 3, 3, 16, 16);
                    g.DrawEllipse(greenPen, 3, 3, 16, 16);
                    g.DrawString("$", new Font("Tahoma", 10F, FontStyle.Bold), greenBrush, new PointF(7, 3));
                }
                else if (type == MenuIconType.Receipt)
                {
                    g.FillRectangle(lightGoldBrush, 4, 2, 14, 18);
                    g.DrawRectangle(greenPen, 4, 2, 14, 18);
                    g.DrawLine(goldPen, 7, 7, 15, 7);
                    g.DrawLine(goldPen, 7, 11, 15, 11);
                    g.DrawLine(goldPen, 7, 15, 13, 15);
                }
                else if (type == MenuIconType.Payment)
                {
                    g.FillEllipse(lightGoldBrush, 3, 3, 16, 16);
                    g.DrawEllipse(greenPen, 3, 3, 16, 16);
                    g.DrawLine(goldPen, 6, 11, 16, 11);
                    g.DrawLine(goldPen, 11, 6, 11, 16);
                }
                else if (type == MenuIconType.Invoice)
                {
                    Point[] points =
                    {
                        new Point(4, 2), new Point(18, 2), new Point(18, 19),
                        new Point(15, 17), new Point(12, 19), new Point(9, 17),
                        new Point(6, 19), new Point(4, 17)
                    };
                    g.FillPolygon(lightGoldBrush, points);
                    g.DrawPolygon(greenPen, points);
                    g.DrawLine(goldPen, 7, 7, 15, 7);
                    g.DrawLine(goldPen, 7, 11, 15, 11);
                    g.DrawLine(goldPen, 7, 15, 13, 15);
                }
                else if (type == MenuIconType.Purchase)
                {
                    g.FillRectangle(lightGoldBrush, 4, 4, 14, 12);
                    g.DrawRectangle(greenPen, 4, 4, 14, 12);
                    g.DrawLine(goldPen, 4, 8, 18, 8);
                    g.DrawLine(goldPen, 8, 8, 8, 16);
                    g.DrawLine(goldPen, 11, 11, 16, 11);
                }
                else if (type == MenuIconType.Sales)
                {
                    g.FillRectangle(lightGoldBrush, 4, 3, 14, 17);
                    g.DrawRectangle(greenPen, 4, 3, 14, 17);
                    g.DrawLine(goldPen, 7, 8, 15, 8);
                    g.DrawLine(goldPen, 7, 12, 15, 12);
                    g.DrawLine(goldPen, 7, 16, 13, 16);
                }
                else if (type == MenuIconType.Report)
                {
                    g.DrawRectangle(greenPen, 3, 3, 16, 16);
                    g.FillRectangle(goldBrush, 6, 13, 3, 4);
                    g.FillRectangle(goldBrush, 10, 10, 3, 7);
                    g.FillRectangle(goldBrush, 14, 6, 3, 11);
                }
                else if (type == MenuIconType.Stock)
                {
                    g.FillRectangle(lightGoldBrush, 3, 5, 16, 14);
                    g.DrawRectangle(greenPen, 3, 5, 16, 14);
                    g.DrawLine(goldPen, 3, 9, 19, 9);
                    g.DrawLine(goldPen, 8, 5, 8, 19);
                    g.DrawLine(goldPen, 14, 5, 14, 19);
                }
                else if (type == MenuIconType.Statement)
                {
                    g.FillRectangle(lightGoldBrush, 4, 2, 14, 18);
                    g.DrawRectangle(greenPen, 4, 2, 14, 18);
                    g.DrawLine(goldPen, 7, 7, 15, 7);
                    g.DrawLine(goldPen, 7, 11, 15, 11);
                    g.DrawLine(goldPen, 7, 15, 15, 15);
                }
                // New icons
                else if (type == MenuIconType.Login)
                {
                    DrawRoundedRectangle(g, greenPen, 3, 3, 13, 16, 3);
                    g.FillPolygon(goldBrush, new[] {
                        new Point(11, 8), new Point(17, 8),
                        new Point(17, 5), new Point(20, 11),
                        new Point(17, 17), new Point(17, 14),
                        new Point(11, 14)
                    });
                }
                else if (type == MenuIconType.Logout)
                {
                    DrawRoundedRectangle(g, greenPen, 4, 3, 12, 16, 3);
                    g.FillPolygon(goldBrush, new[] {
                        new Point(10, 8), new Point(16, 8),
                        new Point(16, 5), new Point(20, 11),
                        new Point(16, 17), new Point(16, 14),
                        new Point(10, 14)
                    });
                }
                else if (type == MenuIconType.Password)
                {
                    g.FillRectangle(lightGoldBrush, 4, 9, 14, 10);
                    g.DrawRectangle(greenPen, 4, 9, 14, 10);
                    g.DrawArc(greenPen, 7, 3, 8, 10, 180, 180);
                    g.FillEllipse(goldBrush, 10, 12, 3, 3);
                }
                else if (type == MenuIconType.Database)
                {
                    g.FillEllipse(lightGoldBrush, 3, 3, 16, 6);
                    g.DrawEllipse(greenPen, 3, 3, 16, 6);
                    g.DrawLine(greenPen, 3, 6, 3, 17);
                    g.DrawLine(greenPen, 19, 6, 19, 17);
                    g.DrawArc(greenPen, 3, 14, 16, 6, 0, 180);
                }
                else if (type == MenuIconType.Connection)
                {
                    g.DrawEllipse(greenPen, 3, 7, 7, 7);
                    g.DrawEllipse(greenPen, 12, 7, 7, 7);
                    g.DrawLine(goldPen, 9, 10, 13, 10);
                    g.DrawLine(goldPen, 9, 12, 13, 12);
                }
                else if (type == MenuIconType.Backup)
                {
                    g.DrawRectangle(greenPen, 3, 3, 16, 15);
                    g.FillPolygon(goldBrush, new[] {
                        new Point(8, 11), new Point(11, 14),
                        new Point(14, 11), new Point(12, 11),
                        new Point(12, 6), new Point(10, 6),
                        new Point(10, 11)
                    });
                }
                else if (type == MenuIconType.Restore)
                {
                    g.DrawRectangle(greenPen, 3, 3, 16, 15);
                    g.FillPolygon(goldBrush, new[] {
                        new Point(14, 11), new Point(11, 8),
                        new Point(8, 11), new Point(10, 11),
                        new Point(10, 16), new Point(12, 16),
                        new Point(12, 11)
                    });
                }
                else if (type == MenuIconType.Register)
                {
                    g.DrawRectangle(greenPen, 4, 2, 14, 18);
                    g.DrawLine(goldPen, 7, 7, 15, 7);
                    g.DrawLine(goldPen, 7, 11, 15, 11);
                    g.DrawLine(goldPen, 7, 15, 12, 15);
                    g.FillEllipse(goldBrush, 15, 13, 5, 5);
                }
                else if (type == MenuIconType.Journal)
                {
                    g.DrawRectangle(greenPen, 3, 3, 16, 16);
                    g.DrawLine(goldPen, 6, 7, 16, 7);
                    g.DrawLine(goldPen, 6, 11, 16, 11);
                    g.DrawLine(goldPen, 6, 15, 13, 15);
                }
            }

            return bitmap;
        }

        private void DrawRoundedRectangle(Graphics g, Pen pen, int x, int y, int width, int height, int radius)
        {
            using GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(x, y, d, d, 180, 90);
            path.AddArc(x + width - d, y, d, d, 270, 90);
            path.AddArc(x + width - d, y + height - d, d, d, 0, 90);
            path.AddArc(x, y + height - d, d, d, 90, 90);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }

        private ToolStripMenuItem قيوداليوميهToolStripMenuItem;
        private ToolStripMenuItem قيوداليوميهToolStripMenuItem1;
    }
}
