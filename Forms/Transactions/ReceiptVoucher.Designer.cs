namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class ReceiptVoucher
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupVoucher;
        private Label lblVoucherNumber;
        private Label lblVoucherDate;
        private Label lblAccount;
        private Label lblCashAccount;
        private Label lblAmount;
        private Label lblNotes;

        private TextBox txtVoucherNumber;
        private DateTimePicker dtpVoucherDate;
        private ComboBox cmbAccount;
        private ComboBox cmbCashAccount;
        private NumericUpDown nudAmount;
        private TextBox txtNotes;

        private Panel panelFooter;
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
            groupVoucher = new GroupBox();
            lblVoucherNumber = new Label();
            lblVoucherDate = new Label();
            lblAccount = new Label();
            lblCashAccount = new Label();
            lblAmount = new Label();
            lblNotes = new Label();
            txtVoucherNumber = new TextBox();
            dtpVoucherDate = new DateTimePicker();
            cmbAccount = new ComboBox();
            cmbCashAccount = new ComboBox();
            nudAmount = new NumericUpDown();
            txtNotes = new TextBox();
            panelFooter = new Panel();
            btnNew = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
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
            panelHeader.RightToLeft = RightToLeft.Yes;
            panelHeader.Size = new Size(1331, 120);
            panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(1173, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "سند قبض";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(1027, 77);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(304, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "تسجيل المقبوضات وإنشاء القيد المحاسبي";
            // 
            // groupVoucher
            // 
            groupVoucher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupVoucher.AutoSize = true;
            groupVoucher.Controls.Add(lblVoucherNumber);
            groupVoucher.Controls.Add(lblVoucherDate);
            groupVoucher.Controls.Add(lblAccount);
            groupVoucher.Controls.Add(lblCashAccount);
            groupVoucher.Controls.Add(lblAmount);
            groupVoucher.Controls.Add(lblNotes);
            groupVoucher.Controls.Add(txtVoucherNumber);
            groupVoucher.Controls.Add(dtpVoucherDate);
            groupVoucher.Controls.Add(cmbAccount);
            groupVoucher.Controls.Add(cmbCashAccount);
            groupVoucher.Controls.Add(nudAmount);
            groupVoucher.Controls.Add(txtNotes);
            groupVoucher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupVoucher.Location = new Point(0, 120);
            groupVoucher.Margin = new Padding(3, 4, 3, 4);
            groupVoucher.Name = "groupVoucher";
            groupVoucher.Padding = new Padding(3, 4, 3, 4);
            groupVoucher.RightToLeft = RightToLeft.Yes;
            groupVoucher.Size = new Size(1331, 707);
            groupVoucher.TabIndex = 1;
            groupVoucher.TabStop = false;
            groupVoucher.Text = "بيانات سند القبض";
            // 
            // lblVoucherNumber
            // 
            lblVoucherNumber.AutoSize = true;
            lblVoucherNumber.Location = new Point(1156, 60);
            lblVoucherNumber.Name = "lblVoucherNumber";
            lblVoucherNumber.RightToLeft = RightToLeft.Yes;
            lblVoucherNumber.Size = new Size(79, 23);
            lblVoucherNumber.TabIndex = 0;
            lblVoucherNumber.Text = "رقم السند";
            // 
            // lblVoucherDate
            // 
            lblVoucherDate.AutoSize = true;
            lblVoucherDate.Location = new Point(1181, 310);
            lblVoucherDate.Name = "lblVoucherDate";
            lblVoucherDate.RightToLeft = RightToLeft.Yes;
            lblVoucherDate.Size = new Size(54, 23);
            lblVoucherDate.TabIndex = 1;
            lblVoucherDate.Text = "التاريخ";
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(1080, 122);
            lblAccount.Name = "lblAccount";
            lblAccount.RightToLeft = RightToLeft.Yes;
            lblAccount.Size = new Size(155, 23);
            lblAccount.TabIndex = 2;
            lblAccount.Text = "الحساب المستلم منه";
            // 
            // lblCashAccount
            // 
            lblCashAccount.AutoSize = true;
            lblCashAccount.Location = new Point(1128, 182);
            lblCashAccount.Name = "lblCashAccount";
            lblCashAccount.RightToLeft = RightToLeft.Yes;
            lblCashAccount.Size = new Size(107, 23);
            lblCashAccount.TabIndex = 3;
            lblCashAccount.Text = "حساب القبض";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(1183, 245);
            lblAmount.Name = "lblAmount";
            lblAmount.RightToLeft = RightToLeft.Yes;
            lblAmount.Size = new Size(52, 23);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "المبلغ";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(495, 60);
            lblNotes.Name = "lblNotes";
            lblNotes.RightToLeft = RightToLeft.Yes;
            lblNotes.Size = new Size(139, 23);
            lblNotes.TabIndex = 5;
            lblNotes.Text = "البيان / الملاحظات";
            // 
            // txtVoucherNumber
            // 
            txtVoucherNumber.BackColor = Color.White;
            txtVoucherNumber.Location = new Point(761, 60);
            txtVoucherNumber.Margin = new Padding(3, 4, 3, 4);
            txtVoucherNumber.Name = "txtVoucherNumber";
            txtVoucherNumber.ReadOnly = true;
            txtVoucherNumber.RightToLeft = RightToLeft.Yes;
            txtVoucherNumber.Size = new Size(240, 30);
            txtVoucherNumber.TabIndex = 6;
            // 
            // dtpVoucherDate
            // 
            dtpVoucherDate.Format = DateTimePickerFormat.Short;
            dtpVoucherDate.Location = new Point(761, 304);
            dtpVoucherDate.Margin = new Padding(3, 4, 3, 4);
            dtpVoucherDate.Name = "dtpVoucherDate";
            dtpVoucherDate.RightToLeft = RightToLeft.Yes;
            dtpVoucherDate.Size = new Size(241, 30);
            dtpVoucherDate.TabIndex = 7;
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(761, 114);
            cmbAccount.Margin = new Padding(3, 4, 3, 4);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.RightToLeft = RightToLeft.Yes;
            cmbAccount.Size = new Size(240, 31);
            cmbAccount.TabIndex = 8;
            // 
            // cmbCashAccount
            // 
            cmbCashAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCashAccount.Location = new Point(761, 174);
            cmbCashAccount.Margin = new Padding(3, 4, 3, 4);
            cmbCashAccount.Name = "cmbCashAccount";
            cmbCashAccount.RightToLeft = RightToLeft.Yes;
            cmbCashAccount.Size = new Size(240, 31);
            cmbCashAccount.TabIndex = 9;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(761, 238);
            nudAmount.Margin = new Padding(3, 4, 3, 4);
            nudAmount.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.RightToLeft = RightToLeft.Yes;
            nudAmount.Size = new Size(241, 30);
            nudAmount.TabIndex = 10;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(0, 98);
            txtNotes.Margin = new Padding(3, 4, 3, 4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.RightToLeft = RightToLeft.Yes;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(634, 265);
            txtNotes.TabIndex = 11;
            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFooter.BackColor = Color.FromArgb(245, 250, 245);
            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Location = new Point(45, 666);
            panelFooter.Margin = new Padding(3, 4, 3, 4);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1274, 120);
            panelFooter.TabIndex = 0;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Location = new Point(211, 29);
            btnNew.Margin = new Padding(3, 4, 3, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(149, 56);
            btnNew.TabIndex = 0;
            btnNew.Text = "سند جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(35, 120, 75);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(40, 29);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 56);
            btnSave.TabIndex = 1;
            btnSave.Text = "حفظ السند";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // ReceiptVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1331, 827);
            Controls.Add(panelFooter);
            Controls.Add(groupVoucher);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 784);
            Name = "ReceiptVoucher";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "سند قبض";
            Load += ReceiptVoucher_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupVoucher.ResumeLayout(false);
            groupVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}