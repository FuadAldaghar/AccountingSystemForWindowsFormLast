namespace AccountingSystemForWindowsFormLast
{
    partial class frm_Main
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mainMenuStrip;

        private System.Windows.Forms.ToolStripMenuItem systemMenu;
        private System.Windows.Forms.ToolStripMenuItem accountTreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsMenuItem;

        private System.Windows.Forms.ToolStripMenuItem vouchersMenu;
        private System.Windows.Forms.ToolStripMenuItem receiptVoucherMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentVoucherMenuItem;

        private System.Windows.Forms.ToolStripMenuItem invoicesMenu;
        private System.Windows.Forms.ToolStripMenuItem purchaseInvoiceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInvoiceMenuItem;

        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem stockReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountStatementMenuItem;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            mainMenuStrip = new MenuStrip();
            systemMenu = new ToolStripMenuItem();
            accountTreeMenuItem = new ToolStripMenuItem();
            itemsMenuItem = new ToolStripMenuItem();
            vouchersMenu = new ToolStripMenuItem();
            receiptVoucherMenuItem = new ToolStripMenuItem();
            paymentVoucherMenuItem = new ToolStripMenuItem();
            invoicesMenu = new ToolStripMenuItem();
            purchaseInvoiceMenuItem = new ToolStripMenuItem();
            salesInvoiceMenuItem = new ToolStripMenuItem();
            reportsMenu = new ToolStripMenuItem();
            stockReportMenuItem = new ToolStripMenuItem();
            accountStatementMenuItem = new ToolStripMenuItem();
            قيوداليوميهToolStripMenuItem = new ToolStripMenuItem();
            قيوداليوميهToolStripMenuItem1 = new ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1269, 60);
            pnlHeader.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = Color.White;
            mainMenuStrip.Font = new Font("Tahoma", 10F);
            mainMenuStrip.ForeColor = Color.FromArgb(35, 35, 35);
            mainMenuStrip.ImageScalingSize = new Size(22, 22);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { systemMenu, vouchersMenu, invoicesMenu, reportsMenu });
            mainMenuStrip.Location = new Point(0, 60);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(10, 5, 10, 5);
            mainMenuStrip.RightToLeft = RightToLeft.Yes;
            mainMenuStrip.Size = new Size(1269, 35);
            mainMenuStrip.TabIndex = 1;
            // 
            // systemMenu
            // 
            systemMenu.DropDownItems.AddRange(new ToolStripItem[] { accountTreeMenuItem, itemsMenuItem });
            systemMenu.Name = "systemMenu";
            systemMenu.Size = new Size(65, 25);
            systemMenu.Text = "الدليل";
            // 
            // accountTreeMenuItem
            // 
            accountTreeMenuItem.Name = "accountTreeMenuItem";
            accountTreeMenuItem.Size = new Size(198, 26);
            accountTreeMenuItem.Text = "دليل الحسابات";
            accountTreeMenuItem.Click += accountTreeMenuItem_Click;
            // 
            // itemsMenuItem
            // 
            itemsMenuItem.Name = "itemsMenuItem";
            itemsMenuItem.Size = new Size(198, 26);
            itemsMenuItem.Text = "دليل الأصناف";
            itemsMenuItem.Click += itemsMenuItem_Click;
            // 
            // vouchersMenu
            // 
            vouchersMenu.DropDownItems.AddRange(new ToolStripItem[] { receiptVoucherMenuItem, paymentVoucherMenuItem });
            vouchersMenu.Name = "vouchersMenu";
            vouchersMenu.Size = new Size(84, 25);
            vouchersMenu.Text = "السندات";
            // 
            // receiptVoucherMenuItem
            // 
            receiptVoucherMenuItem.Name = "receiptVoucherMenuItem";
            receiptVoucherMenuItem.Size = new Size(224, 26);
            receiptVoucherMenuItem.Text = "سند قبض";
            receiptVoucherMenuItem.Click += receiptVoucherMenuItem_Click;
            // 
            // paymentVoucherMenuItem
            // 
            paymentVoucherMenuItem.Name = "paymentVoucherMenuItem";
            paymentVoucherMenuItem.Size = new Size(224, 26);
            paymentVoucherMenuItem.Text = "سند صرف";
            paymentVoucherMenuItem.Click += paymentVoucherMenuItem_Click;
            // 
            // invoicesMenu
            // 
            invoicesMenu.DropDownItems.AddRange(new ToolStripItem[] { purchaseInvoiceMenuItem, salesInvoiceMenuItem });
            invoicesMenu.Name = "invoicesMenu";
            invoicesMenu.Size = new Size(72, 25);
            invoicesMenu.Text = "الفواتير";
            // 
            // purchaseInvoiceMenuItem
            // 
            purchaseInvoiceMenuItem.Name = "purchaseInvoiceMenuItem";
            purchaseInvoiceMenuItem.Size = new Size(202, 26);
            purchaseInvoiceMenuItem.Text = "فاتورة مشتريات";
            purchaseInvoiceMenuItem.Click += purchaseInvoiceMenuItem_Click;
            // 
            // salesInvoiceMenuItem
            // 
            salesInvoiceMenuItem.Name = "salesInvoiceMenuItem";
            salesInvoiceMenuItem.Size = new Size(202, 26);
            salesInvoiceMenuItem.Text = "فاتورة مبيعات";
            salesInvoiceMenuItem.Click += salesInvoiceMenuItem_Click;
            // 
            // reportsMenu
            // 
            reportsMenu.DropDownItems.AddRange(new ToolStripItem[] { stockReportMenuItem, accountStatementMenuItem, قيوداليوميهToolStripMenuItem, قيوداليوميهToolStripMenuItem1 });
            reportsMenu.Name = "reportsMenu";
            reportsMenu.Size = new Size(71, 25);
            reportsMenu.Text = "التقارير";
            // 
            // stockReportMenuItem
            // 
            stockReportMenuItem.Name = "stockReportMenuItem";
            stockReportMenuItem.Size = new Size(236, 26);
            stockReportMenuItem.Text = "تقرير مخزون الأصناف";
            stockReportMenuItem.Click += stockReportMenuItem_Click;
            // 
            // accountStatementMenuItem
            // 
            accountStatementMenuItem.Name = "accountStatementMenuItem";
            accountStatementMenuItem.Size = new Size(236, 26);
            accountStatementMenuItem.Text = "كشف حساب";
            accountStatementMenuItem.Click += accountStatementMenuItem_Click;
            // 
            // قيوداليوميهToolStripMenuItem
            // 
            قيوداليوميهToolStripMenuItem.Name = "قيوداليوميهToolStripMenuItem";
            قيوداليوميهToolStripMenuItem.Size = new Size(236, 26);
            قيوداليوميهToolStripMenuItem.Text = "قيود اليوميه";
            قيوداليوميهToolStripMenuItem.Click += قيوداليوميهToolStripMenuItem_Click;
            // 
            // قيوداليوميهToolStripMenuItem1
            // 
            قيوداليوميهToolStripMenuItem1.Name = "قيوداليوميهToolStripMenuItem1";
            قيوداليوميهToolStripMenuItem1.Size = new Size(236, 26);
            قيوداليوميهToolStripMenuItem1.Text = "قيود اليوميه";
            // 
            // frm_Main
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1269, 854);
            Controls.Add(mainMenuStrip);
            Controls.Add(pnlHeader);
            Font = new Font("Tahoma", 10F);
            MainMenuStrip = mainMenuStrip;
            MinimumSize = new Size(900, 550);
            Name = "frm_Main";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "نظام المحاسبة";
            Load += frm_Main_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

            // =========================================================
            // Events
            // =========================================================


        }

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
            Receipt,
            Payment,
            Purchase,
            Sales,
            Stock,
            Statement
        }

        // =============================================================
        // Create Menu Icon
        // =============================================================

        private Bitmap CreateMenuIcon(MenuIconType type)
        {
            Bitmap bitmap =
                new Bitmap(22, 22);

            using (Graphics g =
                Graphics.FromImage(bitmap))
            {
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.Clear(Color.Transparent);

                Color gold =
                    Color.FromArgb(190, 145, 25);

                Color dark =
                    Color.FromArgb(70, 70, 70);

                using Pen pen =
                    new Pen(gold, 1.8F);

                using Pen darkPen =
                    new Pen(dark, 1.4F);

                using Brush brush =
                    new SolidBrush(gold);

                // =====================================================
                // دليل
                // =====================================================

                if (type == MenuIconType.Book)
                {
                    g.DrawRectangle(
                        pen,
                        3,
                        3,
                        7,
                        16
                    );

                    g.DrawRectangle(
                        pen,
                        11,
                        3,
                        8,
                        16
                    );

                    g.DrawLine(
                        darkPen,
                        11,
                        4,
                        11,
                        19
                    );
                }

                // =====================================================
                // الحسابات
                // =====================================================

                else if (type == MenuIconType.Accounts)
                {
                    g.DrawRectangle(
                        pen,
                        3,
                        3,
                        16,
                        17
                    );

                    g.DrawLine(
                        pen,
                        6,
                        8,
                        16,
                        8
                    );

                    g.DrawLine(
                        pen,
                        6,
                        12,
                        16,
                        12
                    );

                    g.DrawLine(
                        pen,
                        6,
                        16,
                        14,
                        16
                    );
                }

                // =====================================================
                // الأصناف
                // =====================================================

                else if (type == MenuIconType.Items)
                {
                    g.DrawRectangle(
                        pen,
                        3,
                        5,
                        16,
                        14
                    );

                    g.DrawLine(
                        pen,
                        3,
                        9,
                        19,
                        9
                    );

                    g.DrawLine(
                        pen,
                        8,
                        9,
                        8,
                        19
                    );
                }

                // =====================================================
                // السندات
                // =====================================================

                else if (type == MenuIconType.Money)
                {
                    g.DrawEllipse(
                        pen,
                        3,
                        3,
                        16,
                        16
                    );

                    g.DrawString(
                        "$",
                        new Font(
                            "Tahoma",
                            10F,
                            FontStyle.Bold
                        ),
                        brush,
                        new PointF(7, 3)
                    );
                }

                // =====================================================
                // سند قبض
                // =====================================================

                else if (type == MenuIconType.Receipt)
                {
                    g.DrawRectangle(
                        pen,
                        4,
                        2,
                        14,
                        18
                    );

                    g.DrawLine(
                        pen,
                        7,
                        7,
                        15,
                        7
                    );

                    g.DrawLine(
                        pen,
                        7,
                        11,
                        15,
                        11
                    );

                    g.DrawLine(
                        pen,
                        7,
                        15,
                        13,
                        15
                    );
                }

                // =====================================================
                // سند صرف
                // =====================================================

                else if (type == MenuIconType.Payment)
                {
                    g.DrawEllipse(
                        pen,
                        3,
                        3,
                        16,
                        16
                    );

                    g.DrawLine(
                        pen,
                        6,
                        11,
                        16,
                        11
                    );

                    g.DrawLine(
                        pen,
                        11,
                        6,
                        11,
                        16
                    );
                }

                // =====================================================
                // الفواتير
                // =====================================================

                else if (type == MenuIconType.Invoice)
                {
                    Point[] points =
                    {
                        new Point(4, 2),
                        new Point(18, 2),
                        new Point(18, 19),
                        new Point(15, 17),
                        new Point(12, 19),
                        new Point(9, 17),
                        new Point(6, 19),
                        new Point(4, 17)
                    };

                    g.DrawPolygon(
                        pen,
                        points
                    );

                    g.DrawLine(
                        pen,
                        7,
                        7,
                        15,
                        7
                    );

                    g.DrawLine(
                        pen,
                        7,
                        11,
                        15,
                        11
                    );

                    g.DrawLine(
                        pen,
                        7,
                        15,
                        13,
                        15
                    );
                }

                // =====================================================
                // مشتريات
                // =====================================================

                else if (type == MenuIconType.Purchase)
                {
                    g.DrawRectangle(
                        pen,
                        4,
                        4,
                        14,
                        12
                    );

                    g.DrawLine(
                        pen,
                        4,
                        8,
                        18,
                        8
                    );

                    g.DrawLine(
                        pen,
                        8,
                        8,
                        8,
                        16
                    );

                    g.DrawLine(
                        pen,
                        11,
                        11,
                        16,
                        11
                    );
                }

                // =====================================================
                // مبيعات
                // =====================================================

                else if (type == MenuIconType.Sales)
                {
                    g.DrawRectangle(
                        pen,
                        4,
                        3,
                        14,
                        17
                    );

                    g.DrawLine(
                        pen,
                        7,
                        8,
                        15,
                        8
                    );

                    g.DrawLine(
                        pen,
                        7,
                        12,
                        15,
                        12
                    );

                    g.DrawLine(
                        pen,
                        7,
                        16,
                        13,
                        16
                    );
                }

                // =====================================================
                // التقارير
                // =====================================================

                else if (type == MenuIconType.Report)
                {
                    g.DrawRectangle(
                        pen,
                        3,
                        3,
                        16,
                        16
                    );

                    g.FillRectangle(
                        brush,
                        6,
                        13,
                        3,
                        4
                    );

                    g.FillRectangle(
                        brush,
                        10,
                        10,
                        3,
                        7
                    );

                    g.FillRectangle(
                        brush,
                        14,
                        6,
                        3,
                        11
                    );
                }

                // =====================================================
                // المخزون
                // =====================================================

                else if (type == MenuIconType.Stock)
                {
                    g.DrawRectangle(
                        pen,
                        3,
                        5,
                        16,
                        14
                    );

                    g.DrawLine(
                        pen,
                        3,
                        9,
                        19,
                        9
                    );

                    g.DrawLine(
                        pen,
                        8,
                        5,
                        8,
                        19
                    );

                    g.DrawLine(
                        pen,
                        14,
                        5,
                        14,
                        19
                    );
                }

                // =====================================================
                // كشف الحساب
                // =====================================================

                else if (type == MenuIconType.Statement)
                {
                    g.DrawRectangle(
                        pen,
                        4,
                        2,
                        14,
                        18
                    );

                    g.DrawLine(
                        pen,
                        7,
                        7,
                        15,
                        7
                    );

                    g.DrawLine(
                        pen,
                        7,
                        11,
                        15,
                        11
                    );

                    g.DrawLine(
                        pen,
                        7,
                        15,
                        15,
                        15
                    );
                }
            }

            return bitmap;
        }

        private ToolStripMenuItem قيوداليوميهToolStripMenuItem;
        private ToolStripMenuItem قيوداليوميهToolStripMenuItem1;
    }
}