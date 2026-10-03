
namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class AccountStatement
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayout;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupFilters;
        private TableLayoutPanel filtersLayout;
        private Label lblAccount;
        private Label lblFromDate;
        private Label lblToDate;
        private ComboBox cmbAccount;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private FlowLayoutPanel filterButtons;
        private Button btnSearch;
        private Button btnShowAll;

        private DataGridView dgvStatement;

        private Panel panelFooter;
        private TableLayoutPanel footerLayout;
        private Label lblOpeningTitle;
        private Label lblOpeningBalance;
        private Label lblDebitTitle;
        private Label lblDebitTotal;
        private Label lblCreditTitle;
        private Label lblCreditTotal;
        private Label lblBalanceTitle;
        private Label lblFinalBalance;

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
            lblAccount = new Label();
            cmbAccount = new ComboBox();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            filterButtons = new FlowLayoutPanel();
            btnSearch = new Button();
            btnShowAll = new Button();
            dgvStatement = new DataGridView();
            panelFooter = new Panel();
            footerLayout = new TableLayoutPanel();
            lblOpeningTitle = new Label();
            lblOpeningBalance = new Label();
            lblDebitTitle = new Label();
            lblDebitTotal = new Label();
            lblCreditTitle = new Label();
            lblCreditTotal = new Label();
            lblBalanceTitle = new Label();
            lblFinalBalance = new Label();
            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            filtersLayout.SuspendLayout();
            filterButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatement).BeginInit();
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
            rootLayout.Controls.Add(dgvStatement, 0, 2);
            rootLayout.Controls.Add(panelFooter, 0, 3);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 4;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 138F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
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
            lblSubtitle.Text = "حركة الحساب والرصيد الافتتاحي والختامي";
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
            lblTitle.Text = "كشف حساب";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupFilters
            // 
            groupFilters.Controls.Add(filtersLayout);
            groupFilters.Dock = DockStyle.Fill;
            groupFilters.Location = new Point(15, 96);
            groupFilters.Margin = new Padding(3, 0, 3, 10);
            groupFilters.Name = "groupFilters";
            groupFilters.Size = new Size(1135, 128);
            groupFilters.TabIndex = 1;
            groupFilters.TabStop = false;
            groupFilters.Text = "خيارات التقرير";
            // 
            // filtersLayout
            // 
            filtersLayout.ColumnCount = 6;
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
            filtersLayout.Controls.Add(lblAccount, 0, 0);
            filtersLayout.Controls.Add(cmbAccount, 1, 0);
            filtersLayout.Controls.Add(lblFromDate, 2, 0);
            filtersLayout.Controls.Add(dtpFromDate, 3, 0);
            filtersLayout.Controls.Add(lblToDate, 4, 0);
            filtersLayout.Controls.Add(dtpToDate, 5, 0);
            filtersLayout.Controls.Add(filterButtons, 0, 1);
            filtersLayout.Dock = DockStyle.Fill;
            filtersLayout.Location = new Point(3, 26);
            filtersLayout.Margin = new Padding(0);
            filtersLayout.Name = "filtersLayout";
            filtersLayout.Padding = new Padding(4, 0, 4, 8);
            filtersLayout.RowCount = 2;
            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filtersLayout.Size = new Size(1129, 99);
            filtersLayout.TabIndex = 0;
            // 
            // lblAccount
            // 
            lblAccount.Anchor = AnchorStyles.Right;
            lblAccount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccount.Location = new Point(994, 18);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(125, 20);
            lblAccount.TabIndex = 0;
            lblAccount.Text = "الحساب";
            lblAccount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbAccount
            // 
            cmbAccount.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Font = new Font("Segoe UI", 10F);
            cmbAccount.Location = new Point(732, 11);
            cmbAccount.Margin = new Padding(3, 4, 10, 6);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(256, 31);
            cmbAccount.TabIndex = 1;
            // 
            // lblFromDate
            // 
            lblFromDate.Anchor = AnchorStyles.Right;
            lblFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFromDate.Location = new Point(613, 18);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(103, 20);
            lblFromDate.TabIndex = 2;
            lblFromDate.Text = "من تاريخ";
            lblFromDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(419, 12);
            dtpFromDate.Margin = new Padding(3, 4, 10, 6);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(188, 30);
            dtpFromDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            lblToDate.Anchor = AnchorStyles.Right;
            lblToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblToDate.Location = new Point(300, 18);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(103, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "إلى تاريخ";
            lblToDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            dtpToDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(8, 12);
            dtpToDate.Margin = new Padding(3, 4, 4, 6);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(286, 30);
            dtpToDate.TabIndex = 5;
            // 
            // filterButtons
            // 
            filtersLayout.SetColumnSpan(filterButtons, 6);
            filterButtons.Controls.Add(btnSearch);
            filterButtons.Controls.Add(btnShowAll);
            filterButtons.Dock = DockStyle.Fill;
            filterButtons.FlowDirection = FlowDirection.RightToLeft;
            filterButtons.Location = new Point(4, 56);
            filterButtons.Margin = new Padding(0);
            filterButtons.Name = "filterButtons";
            filterButtons.Size = new Size(1121, 35);
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
            // dgvStatement
            // 
            dgvStatement.AllowUserToAddRows = false;
            dgvStatement.AllowUserToDeleteRows = false;
            dgvStatement.AllowUserToResizeRows = false;
            dgvStatement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStatement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatement.BackgroundColor = Color.White;
            dgvStatement.BorderStyle = BorderStyle.None;
            dgvStatement.ColumnHeadersHeight = 40;
            dgvStatement.Location = new Point(15, 234);
            dgvStatement.Margin = new Padding(3, 0, 3, 0);
            dgvStatement.MultiSelect = false;
            dgvStatement.Name = "dgvStatement";
            dgvStatement.ReadOnly = true;
            dgvStatement.RowHeadersVisible = false;
            dgvStatement.RowHeadersWidth = 51;
            dgvStatement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatement.Size = new Size(1135, 388);
            dgvStatement.TabIndex = 2;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(238, 244, 241);
            panelFooter.Controls.Add(footerLayout);
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.Location = new Point(15, 622);
            panelFooter.Margin = new Padding(3, 0, 3, 0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1135, 66);
            panelFooter.TabIndex = 3;
            // 
            // footerLayout
            // 
            footerLayout.ColumnCount = 4;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            footerLayout.Controls.Add(lblOpeningTitle, 0, 0);
            footerLayout.Controls.Add(lblOpeningBalance, 1, 0);
            footerLayout.Controls.Add(lblDebitTitle, 2, 0);
            footerLayout.Controls.Add(lblDebitTotal, 3, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(0, 0);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(10, 14, 10, 10);
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(1135, 66);
            footerLayout.TabIndex = 0;
            // 
            // lblOpeningTitle
            // 
            lblOpeningTitle.Dock = DockStyle.Fill;
            lblOpeningTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOpeningTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblOpeningTitle.Location = new Point(850, 14);
            lblOpeningTitle.Name = "lblOpeningTitle";
            lblOpeningTitle.Size = new Size(272, 42);
            lblOpeningTitle.TabIndex = 0;
            lblOpeningTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOpeningBalance
            // 
            lblOpeningBalance.Dock = DockStyle.Fill;
            lblOpeningBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOpeningBalance.ForeColor = Color.FromArgb(45, 55, 50);
            lblOpeningBalance.Location = new Point(572, 14);
            lblOpeningBalance.Name = "lblOpeningBalance";
            lblOpeningBalance.Size = new Size(272, 42);
            lblOpeningBalance.TabIndex = 1;
            lblOpeningBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDebitTitle
            // 
            lblDebitTitle.Dock = DockStyle.Fill;
            lblDebitTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDebitTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblDebitTitle.Location = new Point(294, 14);
            lblDebitTitle.Name = "lblDebitTitle";
            lblDebitTitle.Size = new Size(272, 42);
            lblDebitTitle.TabIndex = 2;
            lblDebitTitle.Text = "الرصيد النهائي:";
            lblDebitTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDebitTotal
            // 
            lblDebitTotal.Dock = DockStyle.Fill;
            lblDebitTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDebitTotal.ForeColor = Color.FromArgb(45, 55, 50);
            lblDebitTotal.Location = new Point(13, 14);
            lblDebitTotal.Name = "lblDebitTotal";
            lblDebitTotal.Size = new Size(275, 42);
            lblDebitTotal.TabIndex = 3;
            lblDebitTotal.Text = "0.00";
            lblDebitTotal.TextAlign = ContentAlignment.MiddleRight;
            lblDebitTotal.Click += lblDebitTotal_Click;
            // 
            // lblCreditTitle
            // 
            lblCreditTitle.Dock = DockStyle.Fill;
            lblCreditTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCreditTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblCreditTitle.Location = new Point(0, 0);
            lblCreditTitle.Name = "lblCreditTitle";
            lblCreditTitle.Size = new Size(265, 42);
            lblCreditTitle.TabIndex = 4;
            lblCreditTitle.Text = "إجمالي الدائن:";
            lblCreditTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCreditTotal
            // 
            lblCreditTotal.Dock = DockStyle.Fill;
            lblCreditTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCreditTotal.ForeColor = Color.FromArgb(45, 55, 50);
            lblCreditTotal.Location = new Point(0, 0);
            lblCreditTotal.Name = "lblCreditTotal";
            lblCreditTotal.Size = new Size(265, 42);
            lblCreditTotal.TabIndex = 5;
            lblCreditTotal.Text = "0.00";
            lblCreditTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.Dock = DockStyle.Fill;
            lblBalanceTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBalanceTitle.ForeColor = Color.FromArgb(24, 78, 58);
            lblBalanceTitle.Location = new Point(0, 0);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(265, 42);
            lblBalanceTitle.TabIndex = 6;
            lblBalanceTitle.Text = "الرصيد النهائي:";
            lblBalanceTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFinalBalance
            // 
            lblFinalBalance.Dock = DockStyle.Fill;
            lblFinalBalance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinalBalance.ForeColor = Color.FromArgb(35, 120, 75);
            lblFinalBalance.Location = new Point(0, 0);
            lblFinalBalance.Name = "lblFinalBalance";
            lblFinalBalance.Size = new Size(265, 42);
            lblFinalBalance.TabIndex = 7;
            lblFinalBalance.Text = "0.00";
            lblFinalBalance.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AccountStatement
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1165, 700);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 640);
            Name = "AccountStatement";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "كشف حساب";
            Load += AccountStatement_Load;
            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupFilters.ResumeLayout(false);
            filtersLayout.ResumeLayout(false);
            filterButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStatement).EndInit();
            panelFooter.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}