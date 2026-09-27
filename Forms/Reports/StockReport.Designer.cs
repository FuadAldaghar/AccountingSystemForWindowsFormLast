namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class StockReport
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupFilters;
        private Label lblFromDate;
        private Label lblToDate;
        private Label lblItem;

        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private ComboBox cmbItem;

        private Button btnSearch;
        private Button btnShowAll;

        private DataGridView dgvStock;

        private Panel panelFooter;
        private Label lblTotalTitle;
        private Label lblTotalPurchase;
        private Label lblTotalSales;
        private Label lblTotalBalance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            groupFilters = new GroupBox();
            lblFromDate = new Label();
            lblToDate = new Label();
            lblItem = new Label();

            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            cmbItem = new ComboBox();

            btnSearch = new Button();
            btnShowAll = new Button();

            dgvStock = new DataGridView();

            panelFooter = new Panel();
            lblTotalTitle = new Label();
            lblTotalPurchase = new Label();
            lblTotalSales = new Label();
            lblTotalBalance = new Label();

            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(46, 125, 50);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 85;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 12);
            lblTitle.Text = "تقرير كشف المخزون";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(38, 53);
            lblSubtitle.Text = "حركة الأصناف والكميات المشتراة والمباعة والرصيد";

            // 
            // groupFilters
            // 
            groupFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupFilters.Location = new Point(25, 100);
            groupFilters.Size = new Size(1115, 115);
            groupFilters.Text = "خيارات التقرير";

            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(850, 35);
            lblFromDate.Text = "من تاريخ";

            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(690, 30);
            dtpFromDate.Size = new Size(145, 27);

            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(610, 35);
            lblToDate.Text = "إلى تاريخ";

            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(450, 30);
            dtpToDate.Size = new Size(145, 27);

            // 
            // lblItem
            // 
            lblItem.AutoSize = true;
            lblItem.Location = new Point(370, 35);
            lblItem.Text = "الصنف";

            // 
            // cmbItem
            // 
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.FormattingEnabled = true;
            cmbItem.Location = new Point(170, 30);
            cmbItem.Size = new Size(185, 28);

            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(46, 125, 50);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(20, 72);
            btnSearch.Size = new Size(120, 32);
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;

            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.FromArgb(255, 235, 130);
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.ForeColor = Color.Black;
            btnShowAll.Location = new Point(150, 72);
            btnShowAll.Size = new Size(120, 32);
            btnShowAll.Text = "عرض الكل";
            btnShowAll.UseVisualStyleBackColor = false;

            groupFilters.Controls.Add(lblFromDate);
            groupFilters.Controls.Add(dtpFromDate);
            groupFilters.Controls.Add(lblToDate);
            groupFilters.Controls.Add(dtpToDate);
            groupFilters.Controls.Add(lblItem);
            groupFilters.Controls.Add(cmbItem);
            groupFilters.Controls.Add(btnSearch);
            groupFilters.Controls.Add(btnShowAll);

            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.AllowUserToResizeRows = false;
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                              AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.BackgroundColor = Color.White;
            dgvStock.BorderStyle = BorderStyle.Fixed3D;
            dgvStock.ColumnHeadersHeight = 40;
            dgvStock.Location = new Point(25, 230);
            dgvStock.MultiSelect = false;
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.RowTemplate.Height = 35;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(1115, 355);

            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom |
                                  AnchorStyles.Left |
                                  AnchorStyles.Right;
            panelFooter.BackColor = Color.FromArgb(245, 248, 245);
            panelFooter.BorderStyle = BorderStyle.FixedSingle;
            panelFooter.Location = new Point(25, 600);
            panelFooter.Size = new Size(1115, 65);

            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(900, 21);
            lblTotalTitle.Text = "الإجماليات:";

            // 
            // lblTotalPurchase
            // 
            lblTotalPurchase.AutoSize = true;
            lblTotalPurchase.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalPurchase.Location = new Point(650, 21);
            lblTotalPurchase.Text = "المشتريات: 0";

            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalSales.Location = new Point(410, 21);
            lblTotalSales.Text = "المبيعات: 0";

            // 
            // lblTotalBalance
            // 
            lblTotalBalance.AutoSize = true;
            lblTotalBalance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalBalance.Location = new Point(150, 21);
            lblTotalBalance.Text = "الرصيد: 0";

            panelFooter.Controls.Add(lblTotalTitle);
            panelFooter.Controls.Add(lblTotalPurchase);
            panelFooter.Controls.Add(lblTotalSales);
            panelFooter.Controls.Add(lblTotalBalance);

            // 
            // StockReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1165, 690);
            Controls.Add(panelFooter);
            Controls.Add(dgvStock);
            Controls.Add(groupFilters);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(1000, 600);
            Name = "StockReport";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "كشف المخزون";
            Load += StockReport_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupFilters.ResumeLayout(false);
            groupFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }
    }
}