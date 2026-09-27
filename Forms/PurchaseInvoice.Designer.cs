namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class PurchaseInvoice
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
            {
                components.Dispose();
            }

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

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 125, 85);
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
            lblTitle.Text = "فاتورة مشتريات";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(38, 52);
            lblSubtitle.Text = "إدخال فاتورة مشتريات وتسجيل تفاصيلها";

            // 
            // groupInvoice
            // 
            groupInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupInvoice.Location = new Point(25, 100);
            groupInvoice.Size = new Size(1130, 125);
            groupInvoice.Text = "بيانات الفاتورة";

            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.AutoSize = true;
            lblInvoiceNumber.Location = new Point(970, 35);
            lblInvoiceNumber.Text = "رقم الفاتورة";

            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(720, 32);
            txtInvoiceNumber.Size = new Size(230, 27);
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.BackColor = Color.WhiteSmoke;
            txtInvoiceNumber.TabStop = false;

            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Location = new Point(650, 35);
            lblInvoiceDate.Text = "التاريخ";

            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            dtpInvoiceDate.Location = new Point(470, 32);
            dtpInvoiceDate.Size = new Size(160, 27);

            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Location = new Point(400, 35);
            lblPaymentType.Text = "نوع الدفع";

            // 
            // cmbPaymentType
            // 
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Location = new Point(220, 32);
            cmbPaymentType.Size = new Size(160, 28);
            cmbPaymentType.Items.AddRange(new object[]
            {
                "نقد",
                "أجل"
            });

            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(970, 80);
            lblAccount.Text = "الحساب";

            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(220, 77);
            cmbAccount.Size = new Size(730, 28);

            // 
            // groupInvoice controls
            // 
            groupInvoice.Controls.Add(lblInvoiceNumber);
            groupInvoice.Controls.Add(txtInvoiceNumber);
            groupInvoice.Controls.Add(lblInvoiceDate);
            groupInvoice.Controls.Add(dtpInvoiceDate);
            groupInvoice.Controls.Add(lblPaymentType);
            groupInvoice.Controls.Add(cmbPaymentType);
            groupInvoice.Controls.Add(lblAccount);
            groupInvoice.Controls.Add(cmbAccount);

            // 
            // groupDetails
            // 
            groupDetails.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            groupDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDetails.Location = new Point(25, 240);
            groupDetails.Size = new Size(1130, 355);
            groupDetails.Text = "تفاصيل الفاتورة";

            // 
            // lblItem
            // 
            lblItem.AutoSize = true;
            lblItem.Location = new Point(1020, 35);
            lblItem.Text = "الصنف";

            // 
            // cmbItem
            // 
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Location = new Point(750, 32);
            cmbItem.Size = new Size(250, 28);

            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(705, 35);
            lblUnit.Text = "الوحدة";

            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(575, 32);
            txtUnit.Size = new Size(110, 27);
            txtUnit.ReadOnly = true;
            txtUnit.BackColor = Color.WhiteSmoke;

            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(520, 35);
            lblQuantity.Text = "الكمية";

            // 
            // nudQuantity
            // 
            nudQuantity.DecimalPlaces = 2;
            nudQuantity.Minimum = 0.01M;
            nudQuantity.Maximum = 100000000;
            nudQuantity.Value = 1;
            nudQuantity.Location = new Point(390, 32);
            nudQuantity.Size = new Size(110, 27);
            nudQuantity.ThousandsSeparator = true;

            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(330, 35);
            lblUnitPrice.Text = "سعر الوحدة";

            // 
            // nudUnitPrice
            // 
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Minimum = 0;
            nudUnitPrice.Maximum = 1000000000;
            nudUnitPrice.Location = new Point(185, 32);
            nudUnitPrice.Size = new Size(120, 27);
            nudUnitPrice.ThousandsSeparator = true;

            // 
            // lblLineTotal
            // 
            lblLineTotal.AutoSize = true;
            lblLineTotal.Location = new Point(120, 35);
            lblLineTotal.Text = "الإجمالي";

            // 
            // txtLineTotal
            // 
            txtLineTotal.Location = new Point(15, 32);
            txtLineTotal.Size = new Size(90, 27);
            txtLineTotal.ReadOnly = true;
            txtLineTotal.BackColor = Color.WhiteSmoke;
            txtLineTotal.Text = "0.00";

            // 
            // btnAddRow
            // 
            btnAddRow.Text = "إضافة سطر";
            btnAddRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddRow.BackColor = Color.FromArgb(35, 125, 85);
            btnAddRow.ForeColor = Color.White;
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Location = new Point(865, 68);
            btnAddRow.Size = new Size(115, 35);

            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Text = "حذف سطر";
            btnRemoveRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveRow.BackColor = Color.FromArgb(190, 65, 65);
            btnRemoveRow.ForeColor = Color.White;
            btnRemoveRow.FlatStyle = FlatStyle.Flat;
            btnRemoveRow.Location = new Point(735, 68);
            btnRemoveRow.Size = new Size(115, 35);

            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.AllowUserToResizeRows = false;
            dgvDetails.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.BorderStyle = BorderStyle.FixedSingle;
            dgvDetails.ColumnHeadersHeight = 38;
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.Location = new Point(15, 115);
            dgvDetails.MultiSelect = false;
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1100, 220);

            dgvDetails.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 125, 85);

            dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDetails.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvDetails.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvDetails.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 240, 225);

            dgvDetails.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            // 
            // groupDetails controls
            // 
            groupDetails.Controls.Add(lblItem);
            groupDetails.Controls.Add(cmbItem);
            groupDetails.Controls.Add(lblUnit);
            groupDetails.Controls.Add(txtUnit);
            groupDetails.Controls.Add(lblQuantity);
            groupDetails.Controls.Add(nudQuantity);
            groupDetails.Controls.Add(lblUnitPrice);
            groupDetails.Controls.Add(nudUnitPrice);
            groupDetails.Controls.Add(lblLineTotal);
            groupDetails.Controls.Add(txtLineTotal);
            groupDetails.Controls.Add(btnAddRow);
            groupDetails.Controls.Add(btnRemoveRow);
            groupDetails.Controls.Add(dgvDetails);

            // 
            // panelFooter
            // 
            panelFooter.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            panelFooter.Location = new Point(25, 610);
            panelFooter.Size = new Size(1130, 75);

            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(940, 22);
            lblTotalTitle.Text = "إجمالي الفاتورة:";

            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 125, 85);
            lblTotalAmount.Location = new Point(730, 16);
            lblTotalAmount.Text = "0.00";

            // 
            // btnNew
            // 
            btnNew.Text = "جديد";
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.BackColor = Color.FromArgb(240, 210, 105);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Location = new Point(180, 15);
            btnNew.Size = new Size(120, 42);

            // 
            // btnSave
            // 
            btnSave.Text = "حفظ الفاتورة";
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.BackColor = Color.FromArgb(35, 125, 85);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(35, 15);
            btnSave.Size = new Size(130, 42);

            // 
            // panelFooter controls
            // 
            panelFooter.Controls.Add(lblTotalTitle);
            panelFooter.Controls.Add(lblTotalAmount);
            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);

            // 
            // PurchaseInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 246);
            ClientSize = new Size(1180, 720);
            Controls.Add(panelFooter);
            Controls.Add(groupDetails);
            Controls.Add(groupInvoice);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1100, 680);
            Name = "PurchaseInvoice";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "فاتورة مشتريات";

            Load += PurchaseInvoice_Load;

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