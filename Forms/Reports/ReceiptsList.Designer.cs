namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class ReceiptsList
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayout;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupFilters;
        private TableLayoutPanel filtersLayout;
        private Label lblSearch;
        private Label lblFromDate;
        private Label lblToDate;
        private Label lblMinAmount;
        private Label lblMaxAmount;
        private TextBox txtSearch;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private NumericUpDown nudMinAmount;
        private NumericUpDown nudMaxAmount;
        private FlowLayoutPanel filterButtons;
        private Button btnSearch;
        private Button btnShowAll;

        private DataGridView dgvReceipts;

        private Panel panelFooter;
        private TableLayoutPanel footerLayout;
        private Label lblTotalTitle;
        private Label lblVouchersCount;
        private Label lblTotalAmount;
        private Label lblAverageAmount;

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
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            lblMinAmount = new Label();
            nudMinAmount = new NumericUpDown();
            lblMaxAmount = new Label();
            nudMaxAmount = new NumericUpDown();
            filterButtons = new FlowLayoutPanel();
            btnSearch = new Button();
            btnShowAll = new Button();
            dgvReceipts = new DataGridView();
            panelFooter = new Panel();
            footerLayout = new TableLayoutPanel();
            lblTotalTitle = new Label();
            lblVouchersCount = new Label();
            lblTotalAmount = new Label();
            lblAverageAmount = new Label();
            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            filtersLayout.SuspendLayout();
            filterButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReceipts).BeginInit();
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
            rootLayout.Controls.Add(dgvReceipts, 0, 2);
            rootLayout.Controls.Add(panelFooter, 0, 3);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 4;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 146F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            rootLayout.Size = new Size(1200, 720);
            rootLayout.TabIndex = 0;
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(12, 12);
            panelHeader.Margin = new Padding(3, 0, 3, 10);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(18, 10, 18, 8);
            panelHeader.Size = new Size(1176, 84);
            panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1140, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "سجل سندات القبض";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblSubtitle
            //
            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(226, 240, 232);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(1140, 26);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "عرض سندات القبض مع إمكانية البحث والترشيح";
            lblSubtitle.TextAlign = ContentAlignment.MiddleRight;
            //
            // groupFilters
            //
            groupFilters.Controls.Add(filtersLayout);
            groupFilters.Dock = DockStyle.Fill;
            groupFilters.Location = new Point(12, 106);
            groupFilters.Margin = new Padding(3, 0, 3, 10);
            groupFilters.Name = "groupFilters";
            groupFilters.Size = new Size(1176, 146);
            groupFilters.TabIndex = 1;
            groupFilters.TabStop = false;
            groupFilters.Text = "خيارات البحث";
            //
            // filtersLayout
            //
            filtersLayout.ColumnCount = 10;
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            filtersLayout.Controls.Add(lblSearch, 0, 0);
            filtersLayout.Controls.Add(txtSearch, 1, 0);
            filtersLayout.Controls.Add(lblFromDate, 2, 0);
            filtersLayout.Controls.Add(dtpFromDate, 3, 0);
            filtersLayout.Controls.Add(lblToDate, 4, 0);
            filtersLayout.Controls.Add(dtpToDate, 5, 0);
            filtersLayout.Controls.Add(lblMinAmount, 6, 0);
            filtersLayout.Controls.Add(nudMinAmount, 7, 0);
            filtersLayout.Controls.Add(lblMaxAmount, 8, 0);
            filtersLayout.Controls.Add(nudMaxAmount, 9, 0);
            filtersLayout.Controls.Add(filterButtons, 0, 1);
            filtersLayout.SetColumnSpan(filterButtons, 10);
            filtersLayout.Dock = DockStyle.Fill;
            filtersLayout.Location = new Point(15, 26);
            filtersLayout.Margin = new Padding(0);
            filtersLayout.Name = "filtersLayout";
            filtersLayout.Padding = new Padding(4, 0, 4, 8);
            filtersLayout.RowCount = 2;
            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filtersLayout.Size = new Size(1146, 108);
            filtersLayout.TabIndex = 0;
            filtersLayout.TabStop = false;
            //
            // lblSearch
            //
            lblSearch.Anchor = AnchorStyles.Right;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(87, 20);
            lblSearch.TabIndex = 0;
            lblSearch.TabStop = false;
            lblSearch.Text = "بحث";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            //
            // txtSearch
            //
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(6, 0);
            txtSearch.Margin = new Padding(3, 4, 10, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(196, 30);
            txtSearch.TabIndex = 1;
            //
            // lblFromDate
            //
            lblFromDate.Anchor = AnchorStyles.Right;
            lblFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(87, 20);
            lblFromDate.TabIndex = 2;
            lblFromDate.TabStop = false;
            lblFromDate.Text = "من تاريخ";
            lblFromDate.TextAlign = ContentAlignment.MiddleRight;
            //
            // dtpFromDate
            //
            dtpFromDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(365, 0);
            dtpFromDate.Margin = new Padding(3, 4, 10, 6);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(131, 30);
            dtpFromDate.TabIndex = 3;
            //
            // lblToDate
            //
            lblToDate.Anchor = AnchorStyles.Right;
            lblToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(87, 20);
            lblToDate.TabIndex = 4;
            lblToDate.TabStop = false;
            lblToDate.Text = "إلى تاريخ";
            lblToDate.TextAlign = ContentAlignment.MiddleRight;
            //
            // dtpToDate
            //
            dtpToDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(690, 0);
            dtpToDate.Margin = new Padding(3, 4, 10, 6);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(131, 30);
            dtpToDate.TabIndex = 5;
            //
            // lblMinAmount
            //
            lblMinAmount.Anchor = AnchorStyles.Right;
            lblMinAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMinAmount.Name = "lblMinAmount";
            lblMinAmount.Size = new Size(87, 20);
            lblMinAmount.TabIndex = 6;
            lblMinAmount.TabStop = false;
            lblMinAmount.Text = "أقل مبلغ";
            lblMinAmount.TextAlign = ContentAlignment.MiddleRight;
            //
            // nudMinAmount
            //
            nudMinAmount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudMinAmount.DecimalPlaces = 2;
            nudMinAmount.Font = new Font("Segoe UI", 10F);
            nudMinAmount.Location = new Point(1013, 0);
            nudMinAmount.Margin = new Padding(3, 4, 10, 6);
            nudMinAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMinAmount.Name = "nudMinAmount";
            nudMinAmount.Size = new Size(131, 30);
            nudMinAmount.TabIndex = 7;
            nudMinAmount.ThousandsSeparator = true;
            //
            // lblMaxAmount
            //
            lblMaxAmount.Anchor = AnchorStyles.Right;
            lblMaxAmount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMaxAmount.Name = "lblMaxAmount";
            lblMaxAmount.Size = new Size(87, 20);
            lblMaxAmount.TabIndex = 8;
            lblMaxAmount.TabStop = false;
            lblMaxAmount.Text = "أكبر مبلغ";
            lblMaxAmount.TextAlign = ContentAlignment.MiddleRight;
            //
            // nudMaxAmount
            //
            nudMaxAmount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudMaxAmount.DecimalPlaces = 2;
            nudMaxAmount.Font = new Font("Segoe UI", 10F);
            nudMaxAmount.Location = new Point(1218, 0);
            nudMaxAmount.Margin = new Padding(3, 4, 4, 6);
            nudMaxAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMaxAmount.Name = "nudMaxAmount";
            nudMaxAmount.Size = new Size(65, 30);
            nudMaxAmount.TabIndex = 9;
            nudMaxAmount.ThousandsSeparator = true;
            //
            // filterButtons
            //
            filterButtons.Controls.Add(btnSearch);
            filterButtons.Controls.Add(btnShowAll);
            filterButtons.Dock = DockStyle.Fill;
            filterButtons.FlowDirection = FlowDirection.RightToLeft;
            filterButtons.Location = new Point(4, 56);
            filterButtons.Margin = new Padding(0);
            filterButtons.Name = "filterButtons";
            filterButtons.Size = new Size(1138, 52);
            filterButtons.TabIndex = 10;
            filterButtons.WrapContents = false;
            //
            // btnSearch
            //
            btnSearch.Location = new Point(1018, 8);
            btnSearch.Margin = new Padding(6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 36);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;
            //
            // btnShowAll
            //
            btnShowAll.Location = new Point(898, 8);
            btnShowAll.Margin = new Padding(6);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(114, 36);
            btnShowAll.TabIndex = 1;
            btnShowAll.Text = "عرض الكل";
            btnShowAll.UseVisualStyleBackColor = false;
            //
            // dgvReceipts
            //
            dgvReceipts.AllowUserToAddRows = false;
            dgvReceipts.AllowUserToDeleteRows = false;
            dgvReceipts.AllowUserToResizeRows = false;
            dgvReceipts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReceipts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceipts.BackgroundColor = Color.White;
            dgvReceipts.BorderStyle = BorderStyle.None;
            dgvReceipts.ColumnHeadersHeight = 40;
            dgvReceipts.Location = new Point(12, 262);
            dgvReceipts.Margin = new Padding(3, 0, 3, 0);
            dgvReceipts.MultiSelect = false;
            dgvReceipts.Name = "dgvReceipts";
            dgvReceipts.ReadOnly = true;
            dgvReceipts.RowHeadersVisible = false;
            dgvReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceipts.Size = new Size(1176, 380);
            dgvReceipts.TabIndex = 2;
            //
            // panelFooter
            //
            panelFooter.BackColor = Color.FromArgb(238, 244, 241);
            panelFooter.Controls.Add(footerLayout);
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.Location = new Point(12, 654);
            panelFooter.Margin = new Padding(3, 0, 3, 0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1176, 66);
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
            footerLayout.Controls.Add(lblVouchersCount, 1, 0);
            footerLayout.Controls.Add(lblTotalAmount, 2, 0);
            footerLayout.Controls.Add(lblAverageAmount, 3, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(0, 0);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(10, 14, 10, 10);
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(1176, 66);
            footerLayout.TabIndex = 0;
            //
            // lblTotalTitle
            //
            lblTotalTitle.Dock = DockStyle.Fill;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(274, 42);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "الإجماليات:";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblVouchersCount
            //
            lblVouchersCount.Dock = DockStyle.Fill;
            lblVouchersCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblVouchersCount.ForeColor = Color.FromArgb(45, 55, 50);
            lblVouchersCount.Name = "lblVouchersCount";
            lblVouchersCount.Size = new Size(280, 42);
            lblVouchersCount.TabIndex = 1;
            lblVouchersCount.Text = "عدد السندات: 0";
            lblVouchersCount.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblTotalAmount
            //
            lblTotalAmount.Dock = DockStyle.Fill;
            lblTotalAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(280, 42);
            lblTotalAmount.TabIndex = 2;
            lblTotalAmount.Text = "إجمالي المبلغ: 0";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblAverageAmount
            //
            lblAverageAmount.Dock = DockStyle.Fill;
            lblAverageAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAverageAmount.ForeColor = Color.FromArgb(45, 55, 50);
            lblAverageAmount.Name = "lblAverageAmount";
            lblAverageAmount.Size = new Size(280, 42);
            lblAverageAmount.TabIndex = 3;
            lblAverageAmount.Text = "متوسط السند: 0";
            lblAverageAmount.TextAlign = ContentAlignment.MiddleRight;
            //
            // ReceiptsList
            //
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1200, 720);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1020, 640);
            Name = "ReceiptsList";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "سجل سندات القبض";
            Load += ReceiptsList_Load;
            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupFilters.ResumeLayout(false);
            filtersLayout.ResumeLayout(false);
            filterButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudMinAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReceipts).EndInit();
            panelFooter.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}