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
            components = new System.ComponentModel.Container();

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

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 85;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 12);
            lblTitle.Text = "فاتورة مبيعات";

            // lblSubtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(38, 52);
            lblSubtitle.Text = "تسجيل فاتورة البيع وتحديث المخزون والحسابات";

            // groupInvoice
            groupInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupInvoice.Location = new Point(25, 100);
            groupInvoice.Size = new Size(1115, 125);
            groupInvoice.Text = "بيانات الفاتورة";
            groupInvoice.Controls.Add(lblInvoiceNumber);
            groupInvoice.Controls.Add(lblInvoiceDate);
            groupInvoice.Controls.Add(lblPaymentType);
            groupInvoice.Controls.Add(lblAccount);
            groupInvoice.Controls.Add(txtInvoiceNumber);
            groupInvoice.Controls.Add(dtpInvoiceDate);
            groupInvoice.Controls.Add(cmbPaymentType);
            groupInvoice.Controls.Add(cmbAccount);

            // labels
            lblInvoiceNumber.AutoSize = true;
            lblInvoiceNumber.Location = new Point(900, 35);
            lblInvoiceNumber.Text = "رقم الفاتورة";

            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Location = new Point(610, 35);
            lblInvoiceDate.Text = "التاريخ";

            lblPaymentType.AutoSize = true;
            lblPaymentType.Location = new Point(320, 35);
            lblPaymentType.Text = "نوع البيع";

            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(30, 35);
            lblAccount.Text = "الحساب";

            // txtInvoiceNumber
            txtInvoiceNumber.Location = new Point(760, 62);
            txtInvoiceNumber.Size = new Size(300, 27);
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.BackColor = Color.White;

            // dtpInvoiceDate
            dtpInvoiceDate.Location = new Point(470, 62);
            dtpInvoiceDate.Size = new Size(230, 27);
            dtpInvoiceDate.Format = DateTimePickerFormat.Short;

            // cmbPaymentType
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Location = new Point(235, 62);
            cmbPaymentType.Size = new Size(190, 28);
            cmbPaymentType.Items.AddRange(new object[]
            {
                "نقد",
                "أجل"
            });

            // cmbAccount
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(30, 62);
            cmbAccount.Size = new Size(180, 28);

            // groupDetails
            groupDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                                   AnchorStyles.Left | AnchorStyles.Right;
            groupDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDetails.Location = new Point(25, 240);
            groupDetails.Size = new Size(1115, 360);
            groupDetails.Text = "تفاصيل الفاتورة";

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

            // labels
            lblItem.AutoSize = true;
            lblItem.Location = new Point(890, 35);
            lblItem.Text = "الصنف";

            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(720, 35);
            lblUnit.Text = "الوحدة";

            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(560, 35);
            lblQuantity.Text = "الكمية";

            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(390, 35);
            lblUnitPrice.Text = "سعر البيع";

            lblLineTotal.AutoSize = true;
            lblLineTotal.Location = new Point(210, 35);
            lblLineTotal.Text = "الإجمالي";

            // cmbItem
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Location = new Point(820, 62);
            cmbItem.Size = new Size(240, 28);

            // txtUnit
            txtUnit.Location = new Point(665, 62);
            txtUnit.Size = new Size(130, 27);
            txtUnit.ReadOnly = true;
            txtUnit.BackColor = Color.White;

            // nudQuantity
            nudQuantity.DecimalPlaces = 2;
            nudQuantity.Maximum = 100000000;
            nudQuantity.Minimum = 0;
            nudQuantity.Location = new Point(510, 62);
            nudQuantity.Size = new Size(120, 27);

            // nudUnitPrice
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Maximum = 1000000000;
            nudUnitPrice.Minimum = 0;
            nudUnitPrice.Location = new Point(335, 62);
            nudUnitPrice.Size = new Size(140, 27);

            // txtLineTotal
            txtLineTotal.Location = new Point(170, 62);
            txtLineTotal.Size = new Size(140, 27);
            txtLineTotal.ReadOnly = true;
            txtLineTotal.BackColor = Color.White;
            txtLineTotal.TextAlign = HorizontalAlignment.Right;

            // btnAddRow
            btnAddRow.BackColor = Color.FromArgb(35, 120, 75);
            btnAddRow.ForeColor = Color.White;
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Location = new Point(30, 60);
            btnAddRow.Size = new Size(60, 32);
            btnAddRow.Text = "+";
            btnAddRow.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAddRow.UseVisualStyleBackColor = false;

            // btnRemoveRow
            btnRemoveRow.BackColor = Color.FromArgb(190, 70, 60);
            btnRemoveRow.ForeColor = Color.White;
            btnRemoveRow.FlatStyle = FlatStyle.Flat;
            btnRemoveRow.Location = new Point(95, 60);
            btnRemoveRow.Size = new Size(60, 32);
            btnRemoveRow.Text = "−";
            btnRemoveRow.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRemoveRow.UseVisualStyleBackColor = false;

            // dgvDetails
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                                AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.BorderStyle = BorderStyle.FixedSingle;
            dgvDetails.ColumnHeadersHeight = 35;
            dgvDetails.Location = new Point(30, 105);
            dgvDetails.MultiSelect = false;
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1030, 225);

            // panelFooter
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left |
                                 AnchorStyles.Right;
            panelFooter.BackColor = Color.FromArgb(245, 250, 245);
            panelFooter.Height = 90;
            panelFooter.Location = new Point(25, 610);
            panelFooter.Size = new Size(1115, 90);

            panelFooter.Controls.Add(lblTotalTitle);
            panelFooter.Controls.Add(lblTotalAmount);
            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);

            // lblTotalTitle
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(820, 30);
            lblTotalTitle.Text = "إجمالي الفاتورة:";

            // lblTotalAmount
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 120, 75);
            lblTotalAmount.Location = new Point(650, 25);
            lblTotalAmount.Text = "0.00";

            // btnNew
            btnNew.BackColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Location = new Point(185, 22);
            btnNew.Size = new Size(130, 42);
            btnNew.Text = "فاتورة جديدة";
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // btnSave
            btnSave.BackColor = Color.FromArgb(35, 120, 75);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(35, 22);
            btnSave.Size = new Size(130, 42);
            btnSave.Text = "حفظ الفاتورة";
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.UseVisualStyleBackColor = false;

            // SalesInvoice
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1165, 730);
            Controls.Add(panelFooter);
            Controls.Add(groupDetails);
            Controls.Add(groupInvoice);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 650);
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