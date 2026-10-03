
namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class StockReport
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayout;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupFilters;
        private TableLayoutPanel filtersLayout;
        private Label lblFromDate;
        private Label lblToDate;
        private Label lblItem;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private ComboBox cmbItem;
        private FlowLayoutPanel filterButtons;
        private Button btnSearch;
        private Button btnShowAll;

        private DataGridView dgvStock;

        private Panel panelFooter;
        private TableLayoutPanel footerLayout;
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
            rootLayout = new TableLayoutPanel();
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            groupFilters = new GroupBox();
            filtersLayout = new TableLayoutPanel();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            lblItem = new Label();
            cmbItem = new ComboBox();
            filterButtons = new FlowLayoutPanel();
            btnSearch = new Button();
            btnShowAll = new Button();
            dgvStock = new DataGridView();
            panelFooter = new Panel();
            footerLayout = new TableLayoutPanel();
            lblTotalTitle = new Label();
            lblTotalPurchase = new Label();
            lblTotalSales = new Label();
            lblTotalBalance = new Label();
            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            filtersLayout.SuspendLayout();
            filterButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            panelFooter.SuspendLayout();
            footerLayout.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(panelHeader, 0, 0);
            rootLayout.Controls.Add(groupFilters, 0, 1);
            rootLayout.Controls.Add(dgvStock, 0, 2);
            rootLayout.Controls.Add(panelFooter, 0, 3);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 4;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 28.8399029F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55.89012F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.2699795F));
            rootLayout.Size = new Size(1165, 700);
            rootLayout.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(15, 12);
            panelHeader.Margin = new Padding(3, 0, 3, 10);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(18, 10, 18, 8);
            panelHeader.Size = new Size(1135, 74);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(226, 240, 232);
            lblSubtitle.Location = new Point(18, 10);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(1099, 56);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "حركة الأصناف والكميات المشتراة والمباعة والرصيد";
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1099, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "تقرير كشف المخزون";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupFilters
            // 
            groupFilters.Controls.Add(filtersLayout);
            groupFilters.Dock = DockStyle.Fill;
            groupFilters.Location = new Point(15, 96);
            groupFilters.Margin = new Padding(3, 0, 3, 10);
            groupFilters.Name = "groupFilters";
            groupFilters.Size = new Size(1135, 160);
            groupFilters.TabIndex = 1;
            groupFilters.TabStop = false;
            groupFilters.Text = "خيارات التقرير";
            // 
            // filtersLayout
            // 
            filtersLayout.ColumnCount = 6;
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            filtersLayout.Controls.Add(lblFromDate, 0, 0);
            filtersLayout.Controls.Add(dtpFromDate, 1, 0);
            filtersLayout.Controls.Add(lblToDate, 2, 0);
            filtersLayout.Controls.Add(dtpToDate, 3, 0);
            filtersLayout.Controls.Add(lblItem, 4, 0);
            filtersLayout.Controls.Add(cmbItem, 5, 0);
            filtersLayout.Controls.Add(filterButtons, 0, 1);
            filtersLayout.Dock = DockStyle.Fill;
            filtersLayout.Location = new Point(3, 26);
            filtersLayout.Margin = new Padding(0);
            filtersLayout.Name = "filtersLayout";
            filtersLayout.Padding = new Padding(4, 0, 4, 8);
            filtersLayout.RowCount = 2;
            filtersLayout.RowStyles.Add(new RowStyle());
            filtersLayout.RowStyles.Add(new RowStyle());
            filtersLayout.Size = new Size(1129, 131);
            filtersLayout.TabIndex = 0;
            // 
            // lblFromDate
            // 
            lblFromDate.Anchor = AnchorStyles.Right;
            lblFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFromDate.Location = new Point(994, 10);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(125, 20);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "من تاريخ";
            lblFromDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(766, 4);
            dtpFromDate.Margin = new Padding(3, 4, 10, 6);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(222, 30);
            dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            lblToDate.Anchor = AnchorStyles.Right;
            lblToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblToDate.Location = new Point(625, 10);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(125, 20);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "إلى تاريخ";
            lblToDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            dtpToDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(397, 4);
            dtpToDate.Margin = new Padding(3, 4, 10, 6);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(222, 30);
            dtpToDate.TabIndex = 3;
            // 
            // lblItem
            // 
            lblItem.Anchor = AnchorStyles.Right;
            lblItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblItem.Location = new Point(256, 10);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(125, 20);
            lblItem.TabIndex = 4;
            lblItem.Text = "الصنف";
            lblItem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbItem
            // 
            cmbItem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Font = new Font("Segoe UI", 10F);
            cmbItem.Location = new Point(8, 4);
            cmbItem.Margin = new Padding(3, 4, 4, 6);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(242, 31);
            cmbItem.TabIndex = 5;
            // 
            // filterButtons
            // 
            filtersLayout.SetColumnSpan(filterButtons, 6);
            filterButtons.Controls.Add(btnSearch);
            filterButtons.Controls.Add(btnShowAll);
            filterButtons.Dock = DockStyle.Fill;
            filterButtons.FlowDirection = FlowDirection.RightToLeft;
            filterButtons.Location = new Point(4, 41);
            filterButtons.Margin = new Padding(0);
            filterButtons.Name = "filterButtons";
            filterButtons.Size = new Size(1121, 109);
            filterButtons.TabIndex = 6;
            filterButtons.WrapContents = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(6, 6);
            btnSearch.Margin = new Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 36);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(132, 6);
            btnShowAll.Margin = new Padding(6);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(114, 36);
            btnShowAll.TabIndex = 1;
            btnShowAll.Text = "عرض الكل";
            btnShowAll.UseVisualStyleBackColor = false;
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.AllowUserToResizeRows = false;
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.BackgroundColor = Color.White;
            dgvStock.BorderStyle = BorderStyle.None;
            dgvStock.ColumnHeadersHeight = 40;
            dgvStock.Location = new Point(15, 266);
            dgvStock.Margin = new Padding(3, 0, 3, 0);
            dgvStock.MultiSelect = false;
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.RowHeadersWidth = 51;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(1135, 330);
            dgvStock.TabIndex = 2;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(238, 244, 241);
            panelFooter.Controls.Add(footerLayout);
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.Location = new Point(15, 596);
            panelFooter.Margin = new Padding(3, 0, 3, 0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1135, 92);
            panelFooter.TabIndex = 3;
            // 
            // footerLayout
            // 
            footerLayout.ColumnCount = 4;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.Controls.Add(lblTotalTitle, 0, 0);
            footerLayout.Controls.Add(lblTotalPurchase, 1, 0);
            footerLayout.Controls.Add(lblTotalSales, 2, 0);
            footerLayout.Controls.Add(lblTotalBalance, 3, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(0, 0);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(10, 14, 10, 10);
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(1135, 92);
            footerLayout.TabIndex = 0;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Dock = DockStyle.Fill;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblTotalTitle.Location = new Point(850, 14);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(272, 68);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "الإجماليات:";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalPurchase
            // 
            lblTotalPurchase.Dock = DockStyle.Fill;
            lblTotalPurchase.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalPurchase.ForeColor = Color.FromArgb(45, 55, 50);
            lblTotalPurchase.Location = new Point(572, 14);
            lblTotalPurchase.Name = "lblTotalPurchase";
            lblTotalPurchase.Size = new Size(272, 68);
            lblTotalPurchase.TabIndex = 1;
            lblTotalPurchase.Text = "المشتريات: 0";
            lblTotalPurchase.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalSales
            // 
            lblTotalSales.Dock = DockStyle.Fill;
            lblTotalSales.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.FromArgb(45, 55, 50);
            lblTotalSales.Location = new Point(294, 14);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(272, 68);
            lblTotalSales.TabIndex = 2;
            lblTotalSales.Text = "المبيعات: 0";
            lblTotalSales.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalBalance
            // 
            lblTotalBalance.Dock = DockStyle.Fill;
            lblTotalBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalBalance.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotalBalance.Location = new Point(13, 14);
            lblTotalBalance.Name = "lblTotalBalance";
            lblTotalBalance.Size = new Size(275, 68);
            lblTotalBalance.TabIndex = 3;
            lblTotalBalance.Text = "الرصيد: 0";
            lblTotalBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StockReport
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1165, 700);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 640);
            Name = "StockReport";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تقرير كشف المخزون";
            Load += StockReport_Load;
            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupFilters.ResumeLayout(false);
            filtersLayout.ResumeLayout(false);
            filterButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            panelFooter.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}