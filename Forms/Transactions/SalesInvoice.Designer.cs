namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class SalesInvoice
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupInvoice;
        private Label lblInvoiceNumber;
        private Label lblInvoiceDate;
        private Label lblPaymentType;
        private Label lblAccount;

        private TextBox txtInvoiceNumber;
        private DateTimePicker dtpInvoiceDate;
        private ComboBox cmbPaymentType;
        private ComboBox cmbAccount;

        private GroupBox groupDetails;
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
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            groupInvoice = new GroupBox();
            lblInvoiceNumber = new Label();
            lblInvoiceDate = new Label();
            lblPaymentType = new Label();
            lblAccount = new Label();
            txtInvoiceNumber = new TextBox();
            dtpInvoiceDate = new DateTimePicker();
            cmbPaymentType = new ComboBox();
            cmbAccount = new ComboBox();
            groupDetails = new GroupBox();
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
            btnAddRow = new Button();
            btnRemoveRow = new Button();
            dgvDetails = new DataGridView();
            panelFooter = new Panel();
            lblTotalTitle = new Label();
            lblTotalAmount = new Label();
            btnNew = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            groupInvoice.SuspendLayout();
            groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1331, 113);
            panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(40, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(213, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "فاتورة مبيعات";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(43, 69);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(342, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "تسجيل فاتورة البيع وتحديث المخزون والحسابات";
            // 
            // groupInvoice
            // 
            groupInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupInvoice.Controls.Add(lblInvoiceNumber);
            groupInvoice.Controls.Add(lblInvoiceDate);
            groupInvoice.Controls.Add(lblPaymentType);
            groupInvoice.Controls.Add(lblAccount);
            groupInvoice.Controls.Add(txtInvoiceNumber);
            groupInvoice.Controls.Add(dtpInvoiceDate);
            groupInvoice.Controls.Add(cmbPaymentType);
            groupInvoice.Controls.Add(cmbAccount);
            groupInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupInvoice.Location = new Point(29, 133);
            groupInvoice.Margin = new Padding(3, 4, 3, 4);
            groupInvoice.Name = "groupInvoice";
            groupInvoice.Padding = new Padding(3, 4, 3, 4);
            groupInvoice.Size = new Size(1274, 167);
            groupInvoice.TabIndex = 2;
            groupInvoice.TabStop = false;
            groupInvoice.Text = "بيانات الفاتورة";
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.AutoSize = true;
            lblInvoiceNumber.Location = new Point(1151, 93);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(93, 23);
            lblInvoiceNumber.TabIndex = 0;
            lblInvoiceNumber.Text = "رقم الفاتورة";
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Location = new Point(283, 93);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(54, 23);
            lblInvoiceDate.TabIndex = 1;
            lblInvoiceDate.Text = "التاريخ";
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Location = new Point(883, 93);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(72, 23);
            lblPaymentType.TabIndex = 2;
            lblPaymentType.Text = "نوع البيع";
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(580, 93);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(64, 23);
            lblAccount.TabIndex = 3;
            lblAccount.Text = "الحساب";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.BackColor = Color.White;
            txtInvoiceNumber.Location = new Point(982, 86);
            txtInvoiceNumber.Margin = new Padding(3, 4, 3, 4);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(138, 30);
            txtInvoiceNumber.TabIndex = 4;
            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            dtpInvoiceDate.Location = new Point(15, 87);
            dtpInvoiceDate.Margin = new Padding(3, 4, 3, 4);
            dtpInvoiceDate.Name = "dtpInvoiceDate";
            dtpInvoiceDate.Size = new Size(262, 30);
            dtpInvoiceDate.TabIndex = 5;
            // 
            // cmbPaymentType
            // 
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Items.AddRange(new object[] { "نقد", "أجل" });
            cmbPaymentType.Location = new Point(650, 85);
            cmbPaymentType.Margin = new Padding(3, 4, 3, 4);
            cmbPaymentType.Name = "cmbPaymentType";
            cmbPaymentType.Size = new Size(217, 31);
            cmbPaymentType.TabIndex = 6;
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(369, 85);
            cmbAccount.Margin = new Padding(3, 4, 3, 4);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(205, 31);
            cmbAccount.TabIndex = 7;
            // 
            // groupDetails
            // 
            groupDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupDetails.Controls.Add(lblItem);
            groupDetails.Controls.Add(lblUnit);
            groupDetails.Controls.Add(lblQuantity);
            groupDetails.Controls.Add(lblUnitPrice);
            groupDetails.Controls.Add(lblLineTotal);
            groupDetails.Controls.Add(cmbItem);
            groupDetails.Controls.Add(txtUnit);
            groupDetails.Controls.Add(nudQuantity);
            groupDetails.Controls.Add(nudUnitPrice);
            groupDetails.Controls.Add(txtLineTotal);
            groupDetails.Controls.Add(btnAddRow);
            groupDetails.Controls.Add(btnRemoveRow);
            groupDetails.Controls.Add(dgvDetails);
            groupDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDetails.Location = new Point(29, 310);
            groupDetails.Margin = new Padding(3, 4, 3, 4);
            groupDetails.Name = "groupDetails";
            groupDetails.Padding = new Padding(3, 4, 3, 4);
            groupDetails.Size = new Size(1274, 480);
            groupDetails.TabIndex = 1;
            groupDetails.TabStop = false;
            groupDetails.Text = "تفاصيل الفاتورة";
            // 
            // lblItem
            // 
            lblItem.AutoSize = true;
            lblItem.Location = new Point(1166, 90);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(60, 23);
            lblItem.TabIndex = 0;
            lblItem.Text = "الصنف";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(968, 93);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(57, 23);
            lblUnit.TabIndex = 1;
            lblUnit.Text = "الوحدة";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(754, 90);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(54, 23);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "الكمية";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(527, 90);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(78, 23);
            lblUnitPrice.TabIndex = 3;
            lblUnitPrice.Text = "سعر البيع";
            // 
            // lblLineTotal
            // 
            lblLineTotal.AutoSize = true;
            lblLineTotal.Location = new Point(269, 90);
            lblLineTotal.Name = "lblLineTotal";
            lblLineTotal.Size = new Size(68, 23);
            lblLineTotal.TabIndex = 4;
            lblLineTotal.Text = "الإجمالي";
            // 
            // cmbItem
            // 
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Location = new Point(1042, 87);
            cmbItem.Margin = new Padding(3, 4, 3, 4);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(118, 31);
            cmbItem.TabIndex = 5;
            // 
            // txtUnit
            // 
            txtUnit.BackColor = Color.White;
            txtUnit.Location = new Point(814, 83);
            txtUnit.Margin = new Padding(3, 4, 3, 4);
            txtUnit.Name = "txtUnit";
            txtUnit.ReadOnly = true;
            txtUnit.Size = new Size(148, 30);
            txtUnit.TabIndex = 6;
            // 
            // nudQuantity
            // 
            nudQuantity.DecimalPlaces = 2;
            nudQuantity.Location = new Point(611, 83);
            nudQuantity.Margin = new Padding(3, 4, 3, 4);
            nudQuantity.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(137, 30);
            nudQuantity.TabIndex = 7;
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Location = new Point(359, 88);
            nudUnitPrice.Margin = new Padding(3, 4, 3, 4);
            nudUnitPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(160, 30);
            nudUnitPrice.TabIndex = 8;
            // 
            // txtLineTotal
            // 
            txtLineTotal.BackColor = Color.White;
            txtLineTotal.Location = new Point(78, 87);
            txtLineTotal.Margin = new Padding(3, 4, 3, 4);
            txtLineTotal.Name = "txtLineTotal";
            txtLineTotal.ReadOnly = true;
            txtLineTotal.Size = new Size(159, 30);
            txtLineTotal.TabIndex = 9;
            txtLineTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAddRow
            // 
            btnAddRow.BackColor = Color.FromArgb(35, 120, 75);
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAddRow.ForeColor = Color.White;
            btnAddRow.Location = new Point(1101, 163);
            btnAddRow.Margin = new Padding(3, 4, 3, 4);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(116, 43);
            btnAddRow.TabIndex = 10;
            btnAddRow.Text = "اضافة";
            btnAddRow.UseVisualStyleBackColor = false;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.BackColor = Color.FromArgb(190, 70, 60);
            btnRemoveRow.FlatStyle = FlatStyle.Flat;
            btnRemoveRow.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRemoveRow.ForeColor = Color.White;
            btnRemoveRow.Location = new Point(937, 163);
            btnRemoveRow.Margin = new Padding(3, 4, 3, 4);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(129, 43);
            btnRemoveRow.TabIndex = 11;
            btnRemoveRow.Text = "حذف";
            btnRemoveRow.UseVisualStyleBackColor = false;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.ColumnHeadersHeight = 35;
            dgvDetails.Location = new Point(40, 215);
            dgvDetails.Margin = new Padding(3, 4, 3, 4);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1177, 226);
            dgvDetails.TabIndex = 12;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooter.BackColor = Color.FromArgb(245, 250, 245);
            panelFooter.Controls.Add(lblTotalTitle);
            panelFooter.Controls.Add(lblTotalAmount);
            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Location = new Point(29, 813);
            panelFooter.Margin = new Padding(3, 4, 3, 4);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1274, 120);
            panelFooter.TabIndex = 0;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(937, 40);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(141, 28);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "إجمالي الفاتورة:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotalAmount.Location = new Point(743, 33);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(64, 35);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0.00";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Location = new Point(211, 24);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(162, 61);
            btnNew.TabIndex = 2;
            btnNew.Text = "فاتورة جديدة";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(35, 120, 75);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(36, 24);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 61);
            btnSave.TabIndex = 3;
            btnSave.Text = "حفظ الفاتورة";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // SalesInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1331, 973);
            Controls.Add(panelFooter);
            Controls.Add(groupDetails);
            Controls.Add(groupInvoice);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 851);
            Name = "SalesInvoice";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "فاتورة مبيعات";
            Load += SalesInvoice_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupInvoice.ResumeLayout(false);
            groupInvoice.PerformLayout();
            groupDetails.ResumeLayout(false);
            groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }
    }
}