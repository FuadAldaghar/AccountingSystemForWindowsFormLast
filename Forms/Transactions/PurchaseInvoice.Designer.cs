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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            groupInvoice = new GroupBox();
            lblInvoiceNumber = new Label();
            txtInvoiceNumber = new TextBox();
            lblInvoiceDate = new Label();
            dtpInvoiceDate = new DateTimePicker();
            lblPaymentType = new Label();
            cmbPaymentType = new ComboBox();
            lblAccount = new Label();
            cmbAccount = new ComboBox();
            groupDetails = new GroupBox();
            lblItem = new Label();
            cmbItem = new ComboBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            lblUnitPrice = new Label();
            nudUnitPrice = new NumericUpDown();
            lblLineTotal = new Label();
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
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1349, 113);
            panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(40, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "فاتورة مشتريات";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(43, 69);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(292, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "إدخال فاتورة مشتريات وتسجيل تفاصيلها";
            // 
            // groupInvoice
            // 
            groupInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupInvoice.Controls.Add(lblInvoiceNumber);
            groupInvoice.Controls.Add(txtInvoiceNumber);
            groupInvoice.Controls.Add(lblInvoiceDate);
            groupInvoice.Controls.Add(dtpInvoiceDate);
            groupInvoice.Controls.Add(lblPaymentType);
            groupInvoice.Controls.Add(cmbPaymentType);
            groupInvoice.Controls.Add(lblAccount);
            groupInvoice.Controls.Add(cmbAccount);
            groupInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupInvoice.Location = new Point(29, 133);
            groupInvoice.Margin = new Padding(3, 4, 3, 4);
            groupInvoice.Name = "groupInvoice";
            groupInvoice.Padding = new Padding(3, 4, 3, 4);
            groupInvoice.Size = new Size(1291, 167);
            groupInvoice.TabIndex = 2;
            groupInvoice.TabStop = false;
            groupInvoice.Text = "بيانات الفاتورة";
            // 
            // lblInvoiceNumber
            // 
            lblInvoiceNumber.AutoSize = true;
            lblInvoiceNumber.Location = new Point(1109, 47);
            lblInvoiceNumber.Name = "lblInvoiceNumber";
            lblInvoiceNumber.Size = new Size(93, 23);
            lblInvoiceNumber.TabIndex = 0;
            lblInvoiceNumber.Text = "رقم الفاتورة";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.BackColor = Color.WhiteSmoke;
            txtInvoiceNumber.Location = new Point(966, 43);
            txtInvoiceNumber.Margin = new Padding(3, 4, 3, 4);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(119, 30);
            txtInvoiceNumber.TabIndex = 1;
            txtInvoiceNumber.TabStop = false;
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Location = new Point(206, 47);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(54, 23);
            lblInvoiceDate.TabIndex = 2;
            lblInvoiceDate.Text = "التاريخ";
            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            dtpInvoiceDate.Location = new Point(4, 43);
            dtpInvoiceDate.Margin = new Padding(3, 4, 3, 4);
            dtpInvoiceDate.Name = "dtpInvoiceDate";
            dtpInvoiceDate.Size = new Size(182, 30);
            dtpInvoiceDate.TabIndex = 3;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Location = new Point(868, 47);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(78, 23);
            lblPaymentType.TabIndex = 4;
            lblPaymentType.Text = "نوع الدفع";
            // 
            // cmbPaymentType
            // 
            cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentType.Items.AddRange(new object[] { "نقد", "أجل" });
            cmbPaymentType.Location = new Point(701, 43);
            cmbPaymentType.Margin = new Padding(3, 4, 3, 4);
            cmbPaymentType.Name = "cmbPaymentType";
            cmbPaymentType.Size = new Size(143, 31);
            cmbPaymentType.TabIndex = 5;
            cmbPaymentType.SelectedIndexChanged += cmbPaymentType_SelectedIndexChanged;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(584, 49);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(64, 23);
            lblAccount.TabIndex = 6;
            lblAccount.Text = "الحساب";
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(315, 49);
            cmbAccount.Margin = new Padding(3, 4, 3, 4);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(251, 31);
            cmbAccount.TabIndex = 7;
            // 
            // groupDetails
            // 
            groupDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            groupDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupDetails.Location = new Point(29, 321);
            groupDetails.Margin = new Padding(3, 4, 3, 4);
            groupDetails.Name = "groupDetails";
            groupDetails.Padding = new Padding(3, 4, 3, 4);
            groupDetails.Size = new Size(1291, 473);
            groupDetails.TabIndex = 1;
            groupDetails.TabStop = false;
            groupDetails.Text = "تفاصيل الفاتورة";
            // 
            // lblItem
            // 
            lblItem.AutoSize = true;
            lblItem.Location = new Point(1198, 50);
            lblItem.Name = "lblItem";
            lblItem.Size = new Size(60, 23);
            lblItem.TabIndex = 0;
            lblItem.Text = "الصنف";
            // 
            // cmbItem
            // 
            cmbItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItem.Location = new Point(907, 39);
            cmbItem.Margin = new Padding(3, 4, 3, 4);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(285, 31);
            cmbItem.TabIndex = 1;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(825, 47);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(57, 23);
            lblUnit.TabIndex = 2;
            lblUnit.Text = "الوحدة";
            // 
            // txtUnit
            // 
            txtUnit.BackColor = Color.WhiteSmoke;
            txtUnit.Location = new Point(694, 43);
            txtUnit.Margin = new Padding(3, 4, 3, 4);
            txtUnit.Name = "txtUnit";
            txtUnit.ReadOnly = true;
            txtUnit.Size = new Size(125, 30);
            txtUnit.TabIndex = 3;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(621, 47);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(54, 23);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "الكمية";
            // 
            // nudQuantity
            // 
            nudQuantity.DecimalPlaces = 2;
            nudQuantity.Location = new Point(489, 45);
            nudQuantity.Margin = new Padding(3, 4, 3, 4);
            nudQuantity.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(126, 30);
            nudQuantity.TabIndex = 5;
            nudQuantity.ThousandsSeparator = true;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.ValueChanged += nudQuantity_ValueChanged;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(375, 46);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(93, 23);
            lblUnitPrice.TabIndex = 6;
            lblUnitPrice.Text = "سعر الوحدة";
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Location = new Point(250, 39);
            nudUnitPrice.Margin = new Padding(3, 4, 3, 4);
            nudUnitPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(119, 30);
            nudUnitPrice.TabIndex = 7;
            nudUnitPrice.ThousandsSeparator = true;
            // 
            // lblLineTotal
            // 
            lblLineTotal.AutoSize = true;
            lblLineTotal.Location = new Point(176, 47);
            lblLineTotal.Name = "lblLineTotal";
            lblLineTotal.Size = new Size(68, 23);
            lblLineTotal.TabIndex = 8;
            lblLineTotal.Text = "الإجمالي";
            // 
            // txtLineTotal
            // 
            txtLineTotal.BackColor = Color.WhiteSmoke;
            txtLineTotal.Location = new Point(0, 40);
            txtLineTotal.Margin = new Padding(3, 4, 3, 4);
            txtLineTotal.Name = "txtLineTotal";
            txtLineTotal.ReadOnly = true;
            txtLineTotal.Size = new Size(170, 30);
            txtLineTotal.TabIndex = 9;
            txtLineTotal.Text = "0.00";
            // 
            // btnAddRow
            // 
            btnAddRow.BackColor = Color.FromArgb(35, 125, 85);
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddRow.ForeColor = Color.White;
            btnAddRow.Location = new Point(1127, 98);
            btnAddRow.Margin = new Padding(3, 4, 3, 4);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(131, 47);
            btnAddRow.TabIndex = 10;
            btnAddRow.Text = "إضافة";
            btnAddRow.UseVisualStyleBackColor = false;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.BackColor = Color.FromArgb(190, 65, 65);
            btnRemoveRow.FlatStyle = FlatStyle.Flat;
            btnRemoveRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveRow.ForeColor = Color.White;
            btnRemoveRow.Location = new Point(991, 98);
            btnRemoveRow.Margin = new Padding(3, 4, 3, 4);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(131, 47);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 125, 85);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDetails.ColumnHeadersHeight = 38;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(220, 240, 225);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvDetails.DefaultCellStyle = dataGridViewCellStyle4;
            dgvDetails.EnableHeadersVisualStyles = false;
            dgvDetails.Location = new Point(17, 153);
            dgvDetails.Margin = new Padding(3, 4, 3, 4);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(1257, 293);
            dgvDetails.TabIndex = 12;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooter.Controls.Add(lblTotalTitle);
            panelFooter.Controls.Add(lblTotalAmount);
            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Location = new Point(29, 813);
            panelFooter.Margin = new Padding(3, 4, 3, 4);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1291, 100);
            panelFooter.TabIndex = 0;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(1074, 29);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(141, 28);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "إجمالي الفاتورة:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(35, 125, 85);
            lblTotalAmount.Location = new Point(834, 21);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(72, 37);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0.00";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(240, 210, 105);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Location = new Point(206, 20);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(163, 56);
            btnNew.TabIndex = 2;
            btnNew.Text = "جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(35, 125, 85);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(17, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(172, 56);
            btnSave.TabIndex = 3;
            btnSave.Text = "حفظ الفاتورة";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // PurchaseInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 246);
            ClientSize = new Size(1349, 960);
            Controls.Add(panelFooter);
            Controls.Add(groupDetails);
            Controls.Add(groupInvoice);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1255, 891);
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