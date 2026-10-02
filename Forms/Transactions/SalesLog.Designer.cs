
namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class SalesLog
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
        private Label lblInvoiceNumber;
        private Label lblItem;
        private Label lblAccount;
        private Label lblPaymentType;

        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private TextBox txtInvoiceNumber;
        private ComboBox cmbItem;
        private ComboBox cmbAccount;
        private ComboBox cmbPaymentType;

        private Button btnSearch;
        private Button btnClear;

        private GroupBox groupResults;
        private DataGridView dgvSales;

        private Panel panelFooter;
        private TableLayoutPanel footerLayout;
        private Label lblCountTitle;
        private Label lblCount;
        private Label lblTotalTitle;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            rootLayout = new TableLayoutPanel();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            groupFilters = new GroupBox();
            filtersLayout = new TableLayoutPanel();

            lblFromDate = new Label();
            lblToDate = new Label();
            lblInvoiceNumber = new Label();
            lblItem = new Label();
            lblAccount = new Label();
            lblPaymentType = new Label();

            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();
            txtInvoiceNumber = new TextBox();
            cmbItem = new ComboBox();
            cmbAccount = new ComboBox();
            cmbPaymentType = new ComboBox();

            btnSearch = new Button();
            btnClear = new Button();

            groupResults = new GroupBox();
            dgvSales = new DataGridView();

            panelFooter = new Panel();
            footerLayout = new TableLayoutPanel();
            lblCountTitle = new Label();
            lblCount = new Label();
            lblTotalTitle = new Label();
            lblTotal = new Label();

            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            filtersLayout.SuspendLayout();
            groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            panelFooter.SuspendLayout();
            footerLayout.SuspendLayout();
            SuspendLayout();

            // rootLayout
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.RowCount = 4;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 172F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Padding = new Padding(12);
            rootLayout.Controls.Add(panelHeader, 0, 0);
            rootLayout.Controls.Add(groupFilters, 0, 1);
            rootLayout.Controls.Add(groupResults, 0, 2);
            rootLayout.Controls.Add(panelFooter, 0, 3);

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Padding = new Padding(18, 8, 18, 8);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);

            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 38;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = "سجل المبيعات";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;

            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(226, 240, 232);
            lblSubtitle.Text = "عرض فواتير المبيعات وتفاصيل الأصناف مع إمكانية البحث والفلترة";
            lblSubtitle.TextAlign = ContentAlignment.MiddleRight;

            // groupFilters
            groupFilters.Dock = DockStyle.Fill;
            groupFilters.Text = "خيارات البحث والفلترة";
            groupFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupFilters.Padding = new Padding(10);

            filtersLayout.Dock = DockStyle.Fill;
            filtersLayout.ColumnCount = 8;
            filtersLayout.RowCount = 2;

            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            filtersLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));

            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            filtersLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));

            filtersLayout.Controls.Add(lblFromDate, 0, 0);
            filtersLayout.Controls.Add(dtpFromDate, 1, 0);
            filtersLayout.Controls.Add(lblToDate, 2, 0);
            filtersLayout.Controls.Add(dtpToDate, 3, 0);
            filtersLayout.Controls.Add(lblInvoiceNumber, 4, 0);
            filtersLayout.Controls.Add(txtInvoiceNumber, 5, 0);
            filtersLayout.Controls.Add(btnSearch, 6, 0);
            filtersLayout.Controls.Add(btnClear, 7, 0);

            filtersLayout.Controls.Add(lblItem, 0, 1);
            filtersLayout.Controls.Add(cmbItem, 1, 1);
            filtersLayout.SetColumnSpan(cmbItem, 2);

            filtersLayout.Controls.Add(lblAccount, 3, 1);
            filtersLayout.Controls.Add(cmbAccount, 4, 1);
            filtersLayout.SetColumnSpan(cmbAccount, 2);

            filtersLayout.Controls.Add(lblPaymentType, 6, 1);
            filtersLayout.Controls.Add(cmbPaymentType, 7, 1);

            groupFilters.Controls.Add(filtersLayout);

            // lblFromDate
            lblFromDate.Dock = DockStyle.Fill;
            lblFromDate.TextAlign = ContentAlignment.MiddleRight;
            lblFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFromDate.ForeColor = Color.FromArgb(45, 55, 50);
            lblFromDate.Margin = new Padding(4);
            lblFromDate.Text = "من تاريخ";

            // lblToDate
            lblToDate.Dock = DockStyle.Fill;
            lblToDate.TextAlign = ContentAlignment.MiddleRight;
            lblToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblToDate.ForeColor = Color.FromArgb(45, 55, 50);
            lblToDate.Margin = new Padding(4);
            lblToDate.Text = "إلى تاريخ";

            // lblInvoiceNumber
            lblInvoiceNumber.Dock = DockStyle.Fill;
            lblInvoiceNumber.TextAlign = ContentAlignment.MiddleRight;
            lblInvoiceNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInvoiceNumber.ForeColor = Color.FromArgb(45, 55, 50);
            lblInvoiceNumber.Margin = new Padding(4);
            lblInvoiceNumber.Text = "رقم الفاتورة";

            // lblItem
            lblItem.Dock = DockStyle.Fill;
            lblItem.TextAlign = ContentAlignment.MiddleRight;
            lblItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblItem.ForeColor = Color.FromArgb(45, 55, 50);
            lblItem.Margin = new Padding(4);
            lblItem.Text = "الصنف";

            // lblAccount
            lblAccount.Dock = DockStyle.Fill;
            lblAccount.TextAlign = ContentAlignment.MiddleRight;
            lblAccount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccount.ForeColor = Color.FromArgb(45, 55, 50);
            lblAccount.Margin = new Padding(4);
            lblAccount.Text = "الحساب";

            // lblPaymentType
            lblPaymentType.Dock = DockStyle.Fill;
            lblPaymentType.TextAlign = ContentAlignment.MiddleRight;
            lblPaymentType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPaymentType.ForeColor = Color.FromArgb(45, 55, 50);
            lblPaymentType.Margin = new Padding(4);
            lblPaymentType.Text = "نوع البيع";

            // filter controls
            dtpFromDate.Dock = DockStyle.Fill;
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Margin = new Padding(4, 10, 4, 10);

            dtpToDate.Dock = DockStyle.Fill;
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Margin = new Padding(4, 10, 4, 10);

            txtInvoiceNumber.Dock = DockStyle.Fill;
            txtInvoiceNumber.Margin = new Padding(4, 10, 4, 10);
            txtInvoiceNumber.Font = new Font("Segoe UI", 10F);

            cmbItem.Dock = DockStyle.Fill;
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Margin = new Padding(4, 10, 4, 10);
            cmbItem.Font = new Font("Segoe UI", 10F);

            cmbAccount.Dock = DockStyle.Fill;
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Margin = new Padding(4, 10, 4, 10);
            cmbAccount.Font = new Font("Segoe UI", 10F);

            cmbPaymentType.Dock = DockStyle.Fill;
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Margin = new Padding(4, 10, 4, 10);
            cmbPaymentType.Font = new Font("Segoe UI", 10F);
            cmbPaymentType.Items.AddRange(new object[] { "الكل", "نقد", "أجل" });

            btnSearch.Dock = DockStyle.Fill;
            btnSearch.Text = "بحث";
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.Margin = new Padding(4, 8, 4, 8);
            btnSearch.UseVisualStyleBackColor = false;

            btnClear.Dock = DockStyle.Fill;
            btnClear.Text = "مسح الفلاتر";
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.Margin = new Padding(4, 8, 4, 8);
            btnClear.UseVisualStyleBackColor = false;

            // groupResults
            groupResults.Dock = DockStyle.Fill;
            groupResults.Text = "نتائج المبيعات";
            groupResults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupResults.Padding = new Padding(8);

            dgvSales.Dock = DockStyle.Fill;
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AllowUserToDeleteRows = false;
            dgvSales.AllowUserToResizeRows = false;
            dgvSales.AutoGenerateColumns = true;
            dgvSales.BackgroundColor = Color.White;
            dgvSales.BorderStyle = BorderStyle.None;
            dgvSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSales.ColumnHeadersHeight = 42;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSales.EnableHeadersVisualStyles = false;
            dgvSales.MultiSelect = false;
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersVisible = false;
            dgvSales.RowTemplate.Height = 36;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.RightToLeft = RightToLeft.Yes;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            groupResults.Controls.Add(dgvSales);

            // footer
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.BackColor = Color.White;
            panelFooter.Padding = new Padding(8, 4, 8, 4);

            footerLayout.Dock = DockStyle.Fill;
            footerLayout.ColumnCount = 4;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            footerLayout.Controls.Add(lblCountTitle, 0, 0);
            footerLayout.Controls.Add(lblCount, 1, 0);
            footerLayout.Controls.Add(lblTotalTitle, 2, 0);
            footerLayout.Controls.Add(lblTotal, 3, 0);

            // lblCountTitle
            lblCountTitle.Dock = DockStyle.Fill;
            lblCountTitle.TextAlign = ContentAlignment.MiddleRight;
            lblCountTitle.Margin = new Padding(4);
            lblCountTitle.Text = "عدد النتائج:";

            // lblCount
            lblCount.Dock = DockStyle.Fill;
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            lblCount.Margin = new Padding(4);
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCount.Text = "0";

            // lblTotalTitle
            lblTotalTitle.Dock = DockStyle.Fill;
            lblTotalTitle.TextAlign = ContentAlignment.MiddleRight;
            lblTotalTitle.Margin = new Padding(4);
            lblTotalTitle.Text = "إجمالي المبيعات:";

            // lblTotal
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Margin = new Padding(4);
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotal.Text = "0.00";

            panelFooter.Controls.Add(footerLayout);

            // SalesLog
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1450, 850);
            MinimumSize = new Size(1050, 700);
            Name = "SalesLog";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "سجل المبيعات";

            Load += SalesLog_Load;
            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            txtInvoiceNumber.KeyDown += txtInvoiceNumber_KeyDown;

            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupFilters.ResumeLayout(false);
            filtersLayout.ResumeLayout(false);
            groupResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            panelFooter.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
