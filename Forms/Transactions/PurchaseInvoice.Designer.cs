

namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class PurchaseInvoice
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayout;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupInvoice;
        private TableLayoutPanel invoiceLayout;
        private Label lblInvoiceNumber;
        private Label lblInvoiceDate;
        private Label lblPaymentType;
        private Label lblAccount;

        private TextBox txtInvoiceNumber;
        private DateTimePicker dtpInvoiceDate;
        private ComboBox cmbPaymentType;
        private ComboBox cmbAccount;

        private GroupBox groupDetails;
        private TableLayoutPanel detailsLayout;
        private TableLayoutPanel itemLayout;

        private Label lblItem;
        private Label lblUnit;
        private Label lblQuantity;
        private Label lblUnitPrice;
        private Label lblLineTotal;

        private ComboBox cmbItem;
        private TextBox txtUnit;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudUnitPrice;
        private TextBox txtLineTotal;

        private Button btnAddRow;
        private Button btnRemoveRow;

        private DataGridView dgvDetails;

        private Panel panelFooter;
        private TableLayoutPanel footerLayout;
        private FlowLayoutPanel totalPanel;
        private Label lblTotalTitle;
        private Label lblTotalAmount;
        private Button btnNew;
        private Button btnSave;

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
            groupInvoice = new GroupBox();
            invoiceLayout = new TableLayoutPanel();
            lblInvoiceNumber = new Label();
            lblInvoiceDate = new Label();
            lblPaymentType = new Label();
            lblAccount = new Label();
            txtInvoiceNumber = new TextBox();
            dtpInvoiceDate = new DateTimePicker();
            cmbPaymentType = new ComboBox();
            cmbAccount = new ComboBox();
            groupDetails = new GroupBox();
            detailsLayout = new TableLayoutPanel();
            itemLayout = new TableLayoutPanel();
            btnRemoveRow = new Button();
            btnAddRow = new Button();
            lblItem = new Label();
            lblUnit = new Label();
            lblQuantity = new Label();
            lblUnitPrice = new Label();
            lblLineTotal = new Label();
            cmbItem = new ComboBox();
            txtUnit = new TextBox();
            nudQuantity = new NumericUpDown();
            nudUnitPrice = new NumericUpDown();
            txtLineTotal = new TextBox();
            dgvDetails = new DataGridView();
            panelFooter = new Panel();
            footerLayout = new TableLayoutPanel();
            btnSave = new Button();
            btnNew = new Button();
            totalPanel = new FlowLayoutPanel();
            lblTotalTitle = new Label();
            lblTotalAmount = new Label();
            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupInvoice.SuspendLayout();
            invoiceLayout.SuspendLayout();
            groupDetails.SuspendLayout();
            detailsLayout.SuspendLayout();
            itemLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            panelFooter.SuspendLayout();
            footerLayout.SuspendLayout();
            totalPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(panelHeader, 0, 0);
            rootLayout.Controls.Add(groupInvoice, 0, 1);
            rootLayout.Controls.Add(groupDetails, 0, 2);
            rootLayout.Controls.Add(panelFooter, 0, 3);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 4;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            rootLayout.Size = new Size(1507, 941);
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
            panelHeader.Size = new Size(1477, 74);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(226, 240, 232);
            lblSubtitle.Location = new Point(18, 10);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.RightToLeft = RightToLeft.No;
            lblSubtitle.Size = new Size(1441, 56);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "إدخال فاتورة مشتريات وتسجيل تفاصيلها";
            lblSubtitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1441, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "فاتورة مشتريات";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupInvoice
            // 
            groupInvoice.Controls.Add(invoiceLayout);
            groupInvoice.Dock = DockStyle.Fill;
            groupInvoice.Location = new Point(15, 96);
            groupInvoice.Margin = new Padding(3, 0, 3, 10);
            groupInvoice.Name = "groupInvoice";
            groupInvoice.Size = new Size(1477, 118);
            groupInvoice.TabIndex = 1;
            groupInvoice.TabStop = false;
            groupInvoice.Text = "بيانات الفاتورة";
            // 
            // invoiceLayout
            // 
            invoiceLayout.ColumnCount = 4;
            invoiceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
            invoiceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            invoiceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            invoiceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            invoiceLayout.Controls.Add(lblInvoiceNumber, 0, 0);
            invoiceLayout.Controls.Add(lblInvoiceDate, 1, 0);
            invoiceLayout.Controls.Add(lblPaymentType, 2, 0);
            invoiceLayout.Controls.Add(lblAccount, 3, 0);
            invoiceLayout.Controls.Add(txtInvoiceNumber, 0, 1);
            invoiceLayout.Controls.Add(dtpInvoiceDate, 1, 1);
            invoiceLayout.Controls.Add(cmbPaymentType, 2, 1);
            invoiceLayout.Controls.Add(cmbAccount, 3, 1);
            invoiceLayout.Dock = DockStyle.Fill;
            invoiceLayout.Location = new Point(3, 26);
            invoiceLayout.Margin = new Padding(0);
            invoiceLayout.Name = "invoiceLayout";
            invoiceLayout.Padding = new Padding(4, 0, 4, 6);
            invoiceLayout.RowCount = 2;
            invoiceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            invoiceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            invoiceLayout.Size = new Size(1471, 89);
            invoiceLayout.TabIndex = 0;
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.Dock = DockStyle.Fill;
            lblInvoiceNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInvoiceNumber.Location = new Point(1090, 0);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.RightToLeft = RightToLeft.No;
            lblInvoiceNumber.Size = new Size(374, 41);
            lblInvoiceNumber.TabIndex = 0;
            lblInvoiceNumber.Text = "رقم الفاتورة";
            lblInvoiceNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.Dock = DockStyle.Fill;
            lblInvoiceDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblInvoiceDate.Location = new Point(739, 0);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.RightToLeft = RightToLeft.No;
            lblInvoiceDate.Size = new Size(345, 41);
            lblInvoiceDate.TabIndex = 1;
            lblInvoiceDate.Text = "التاريخ";
            lblInvoiceDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentType
            // 
            lblPaymentType.Dock = DockStyle.Fill;
            lblPaymentType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPaymentType.Location = new Point(374, 0);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.RightToLeft = RightToLeft.No;
            lblPaymentType.Size = new Size(359, 41);
            lblPaymentType.TabIndex = 2;
            lblPaymentType.Text = "نوع الدفع";
            lblPaymentType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAccount
            // 
            lblAccount.Dock = DockStyle.Fill;
            lblAccount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccount.Location = new Point(7, 0);
            lblAccount.Name = "lblAccount";
            lblAccount.RightToLeft = RightToLeft.No;
            lblAccount.Size = new Size(361, 41);
            lblAccount.TabIndex = 3;
            lblAccount.Text = "الحساب المقابل";
            lblAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Dock = DockStyle.Fill;
            txtInvoiceNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtInvoiceNumber.Location = new Point(1095, 45);
            txtInvoiceNumber.Margin = new Padding(3, 4, 8, 8);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.RightToLeft = RightToLeft.No;
            txtInvoiceNumber.Size = new Size(369, 30);
            txtInvoiceNumber.TabIndex = 4;
            txtInvoiceNumber.Text = "1";
            txtInvoiceNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Dock = DockStyle.Fill;
            dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            dtpInvoiceDate.Location = new Point(744, 45);
            dtpInvoiceDate.Margin = new Padding(3, 4, 8, 8);
            dtpInvoiceDate.Name = "dtpInvoiceDate";
            dtpInvoiceDate.RightToLeft = RightToLeft.No;
            dtpInvoiceDate.Size = new Size(340, 30);
            dtpInvoiceDate.TabIndex = 5;
            // 
            // cmbPaymentType
            // 
            cmbPaymentType.Dock = DockStyle.Fill;
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Font = new Font("Segoe UI", 10F);
            cmbPaymentType.Items.AddRange(new object[] { "نقد", "أجل" });
            cmbPaymentType.Location = new Point(379, 45);
            cmbPaymentType.Margin = new Padding(3, 4, 8, 8);
            cmbPaymentType.Name = "cmbPaymentType";
            cmbPaymentType.RightToLeft = RightToLeft.No;
            cmbPaymentType.Size = new Size(354, 31);
            cmbPaymentType.TabIndex = 6;
            cmbPaymentType.SelectedIndexChanged += cmbPaymentType_SelectedIndexChanged;
            // 
            // cmbAccount
            // 
            cmbAccount.Dock = DockStyle.Fill;
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Font = new Font("Segoe UI", 10F);
            cmbAccount.Location = new Point(8, 45);
            cmbAccount.Margin = new Padding(3, 4, 4, 8);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.RightToLeft = RightToLeft.No;
            cmbAccount.Size = new Size(360, 31);
            cmbAccount.TabIndex = 7;
            // 
            // groupDetails
            // 
            groupDetails.Controls.Add(detailsLayout);
            groupDetails.Dock = DockStyle.Fill;
            groupDetails.Location = new Point(15, 224);
            groupDetails.Margin = new Padding(3, 0, 3, 10);
            groupDetails.Name = "groupDetails";
            groupDetails.Size = new Size(1477, 619);
            groupDetails.TabIndex = 2;
            groupDetails.TabStop = false;
            groupDetails.Text = "تفاصيل الفاتورة";
            // 
            // detailsLayout
            // 
            detailsLayout.ColumnCount = 1;
            detailsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            detailsLayout.Controls.Add(itemLayout, 0, 0);
            detailsLayout.Controls.Add(dgvDetails, 0, 1);
            detailsLayout.Dock = DockStyle.Fill;
            detailsLayout.Location = new Point(3, 26);
            detailsLayout.Margin = new Padding(0);
            detailsLayout.Name = "detailsLayout";
            detailsLayout.Padding = new Padding(4, 0, 4, 6);
            detailsLayout.RowCount = 2;
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 22F));
            detailsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 78F));
            detailsLayout.Size = new Size(1471, 590);
            detailsLayout.TabIndex = 0;
            // 
            // itemLayout
            // 
            itemLayout.ColumnCount = 6;
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            itemLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            itemLayout.Controls.Add(btnRemoveRow, 5, 1);
            itemLayout.Controls.Add(btnAddRow, 5, 0);
            itemLayout.Controls.Add(lblItem, 0, 0);
            itemLayout.Controls.Add(lblUnit, 1, 0);
            itemLayout.Controls.Add(lblQuantity, 2, 0);
            itemLayout.Controls.Add(lblUnitPrice, 3, 0);
            itemLayout.Controls.Add(lblLineTotal, 4, 0);
            itemLayout.Controls.Add(cmbItem, 0, 1);
            itemLayout.Controls.Add(txtUnit, 1, 1);
            itemLayout.Controls.Add(nudQuantity, 2, 1);
            itemLayout.Controls.Add(nudUnitPrice, 3, 1);
            itemLayout.Controls.Add(txtLineTotal, 4, 1);
            itemLayout.Dock = DockStyle.Fill;
            itemLayout.Location = new Point(4, 0);
            itemLayout.Margin = new Padding(0);
            itemLayout.Name = "itemLayout";
            itemLayout.RowCount = 2;
            itemLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            itemLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            itemLayout.Size = new Size(1463, 128);
            itemLayout.TabIndex = 0;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRemoveRow.AutoSize = true;
            btnRemoveRow.BackColor = Color.Red;
            btnRemoveRow.Location = new Point(0, 70);
            btnRemoveRow.Margin = new Padding(3, 6, 0, 6);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(146, 52);
            btnRemoveRow.TabIndex = 1;
            btnRemoveRow.Text = "حذف";
            btnRemoveRow.UseVisualStyleBackColor = false;
            // 
            // btnAddRow
            // 
            btnAddRow.Dock = DockStyle.Fill;
            btnAddRow.Location = new Point(6, 6);
            btnAddRow.Margin = new Padding(3, 6, 6, 6);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(140, 52);
            btnAddRow.TabIndex = 0;
            btnAddRow.Text = "إضافة";
            btnAddRow.UseVisualStyleBackColor = false;
            // 
            // lblItem
            // 
            lblItem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblItem.Location = new Point(1320, 0);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(140, 64);
            lblItem.TabIndex = 0;
            lblItem.Text = "الصنف";
            lblItem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnit
            // 
            lblUnit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUnit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUnit.Location = new Point(1028, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(286, 64);
            lblUnit.TabIndex = 1;
            lblUnit.Text = "الوحدة";
            lblUnit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblQuantity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuantity.Location = new Point(736, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(286, 64);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "الكمية";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUnitPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUnitPrice.Location = new Point(444, 0);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(286, 64);
            lblUnitPrice.TabIndex = 3;
            lblUnitPrice.Text = "سعر الشراء";
            lblUnitPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLineTotal
            // 
            lblLineTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLineTotal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLineTotal.Location = new Point(152, 0);
            lblLineTotal.Name = "lblLineTotal";
            lblLineTotal.Size = new Size(286, 64);
            lblLineTotal.TabIndex = 4;
            lblLineTotal.Text = "إجمالي السطر";
            lblLineTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbItem
            // 
            cmbItem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Font = new Font("Segoe UI", 10F);
            cmbItem.Location = new Point(1325, 68);
            cmbItem.Margin = new Padding(3, 4, 8, 4);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(135, 31);
            cmbItem.TabIndex = 5;
            // 
            // txtUnit
            // 
            txtUnit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUnit.BackColor = Color.White;
            txtUnit.Font = new Font("Segoe UI", 10F);
            txtUnit.Location = new Point(1033, 68);
            txtUnit.Margin = new Padding(3, 4, 8, 4);
            txtUnit.Name = "txtUnit";
            txtUnit.ReadOnly = true;
            txtUnit.Size = new Size(281, 30);
            txtUnit.TabIndex = 6;
            txtUnit.Text = "-";
            txtUnit.TextAlign = HorizontalAlignment.Center;
            // 
            // nudQuantity
            // 
            nudQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nudQuantity.Font = new Font("Segoe UI", 10F);
            nudQuantity.Location = new Point(741, 68);
            nudQuantity.Margin = new Padding(3, 4, 8, 4);
            nudQuantity.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(281, 30);
            nudQuantity.TabIndex = 7;
            nudQuantity.ThousandsSeparator = true;
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Font = new Font("Segoe UI", 10F);
            nudUnitPrice.Location = new Point(449, 68);
            nudUnitPrice.Margin = new Padding(3, 4, 8, 4);
            nudUnitPrice.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(281, 30);
            nudUnitPrice.TabIndex = 8;
            nudUnitPrice.ThousandsSeparator = true;
            // 
            // txtLineTotal
            // 
            txtLineTotal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLineTotal.BackColor = Color.White;
            txtLineTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtLineTotal.ForeColor = Color.FromArgb(35, 120, 75);
            txtLineTotal.Location = new Point(157, 68);
            txtLineTotal.Margin = new Padding(3, 4, 8, 4);
            txtLineTotal.Name = "txtLineTotal";
            txtLineTotal.ReadOnly = true;
            txtLineTotal.Size = new Size(281, 30);
            txtLineTotal.TabIndex = 9;
            txtLineTotal.Text = "0.00";
            txtLineTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.ColumnHeadersHeight = 36;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(4, 128);
            dgvDetails.Margin = new Padding(3, 0, 0, 0);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RightToLeft = RightToLeft.Yes;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1460, 456);
            dgvDetails.TabIndex = 1;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(238, 244, 241);
            panelFooter.Controls.Add(footerLayout);
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.Location = new Point(15, 853);
            panelFooter.Margin = new Padding(3, 0, 3, 0);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1477, 76);
            panelFooter.TabIndex = 3;
            // 
            // footerLayout
            // 
            footerLayout.ColumnCount = 3;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            footerLayout.Controls.Add(btnSave, 0, 0);
            footerLayout.Controls.Add(btnNew, 1, 0);
            footerLayout.Controls.Add(totalPanel, 2, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(0, 0);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.Padding = new Padding(10, 12, 10, 12);
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(1477, 76);
            footerLayout.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(1323, 12);
            btnSave.Margin = new Padding(3, 0, 6, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 52);
            btnSave.TabIndex = 0;
            btnSave.Text = "حفظ الفاتورة";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Fill;
            btnNew.Location = new Point(1173, 12);
            btnNew.Margin = new Padding(3, 0, 6, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(141, 52);
            btnNew.TabIndex = 1;
            btnNew.Text = "فاتورة جديدة";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // totalPanel
            // 
            totalPanel.Controls.Add(lblTotalTitle);
            totalPanel.Controls.Add(lblTotalAmount);
            totalPanel.Dock = DockStyle.Fill;
            totalPanel.FlowDirection = FlowDirection.RightToLeft;
            totalPanel.Location = new Point(13, 12);
            totalPanel.Margin = new Padding(3, 0, 3, 0);
            totalPanel.Name = "totalPanel";
            totalPanel.Size = new Size(1151, 52);
            totalPanel.TabIndex = 0;
            totalPanel.WrapContents = false;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(45, 55, 50);
            lblTotalTitle.Location = new Point(3, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(141, 28);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "إجمالي الفاتورة:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotalAmount.Location = new Point(150, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(72, 37);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0.00";
            // 
            // PurchaseInvoice
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1507, 941);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1040, 720);
            Name = "PurchaseInvoice";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "فاتورة مشتريات";
            Load += PurchaseInvoice_Load;
            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupInvoice.ResumeLayout(false);
            invoiceLayout.ResumeLayout(false);
            invoiceLayout.PerformLayout();
            groupDetails.ResumeLayout(false);
            detailsLayout.ResumeLayout(false);
            itemLayout.ResumeLayout(false);
            itemLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            panelFooter.ResumeLayout(false);
            footerLayout.ResumeLayout(false);
            totalPanel.ResumeLayout(false);
            totalPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
