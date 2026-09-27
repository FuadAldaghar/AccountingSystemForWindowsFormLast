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
            components = new System.ComponentModel.Container();

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

            // =========================
            // Header
            // =========================

            panelHeader.BackColor = Color.FromArgb(35, 120, 75);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 90;

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold);

            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 12);
            lblTitle.Text = "سند قبض";

            // lblSubtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font(
                "Segoe UI",
                10F);

            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(38, 55);
            lblSubtitle.Text =
                "تسجيل المقبوضات وإنشاء القيد المحاسبي";

            // =========================
            // Voucher Group
            // =========================

            groupVoucher.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            groupVoucher.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

            groupVoucher.Location = new Point(25, 110);
            groupVoucher.Size = new Size(1115, 360);

            groupVoucher.Text = "بيانات سند القبض";

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

            // =========================
            // Labels
            // =========================

            lblVoucherNumber.AutoSize = true;
            lblVoucherNumber.Location =
                new Point(900, 45);
            lblVoucherNumber.Text =
                "رقم السند";

            lblVoucherDate.AutoSize = true;
            lblVoucherDate.Location =
                new Point(600, 45);
            lblVoucherDate.Text =
                "التاريخ";

            lblAccount.AutoSize = true;
            lblAccount.Location =
                new Point(300, 45);
            lblAccount.Text =
                "الحساب المستلم منه";

            lblCashAccount.AutoSize = true;
            lblCashAccount.Location =
                new Point(30, 45);
            lblCashAccount.Text =
                "حساب القبض";

            lblAmount.AutoSize = true;
            lblAmount.Location =
                new Point(900, 140);
            lblAmount.Text =
                "المبلغ";

            lblNotes.AutoSize = true;
            lblNotes.Location =
                new Point(600, 140);
            lblNotes.Text =
                "البيان / الملاحظات";

            // =========================
            // Voucher Number
            // =========================

            txtVoucherNumber.Location =
                new Point(760, 72);

            txtVoucherNumber.Size =
                new Size(300, 27);

            txtVoucherNumber.ReadOnly = true;
            txtVoucherNumber.BackColor = Color.White;

            // =========================
            // Date
            // =========================

            dtpVoucherDate.Location =
                new Point(470, 72);

            dtpVoucherDate.Size =
                new Size(230, 27);

            dtpVoucherDate.Format =
                DateTimePickerFormat.Short;

            // =========================
            // Account
            // =========================

            cmbAccount.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbAccount.Location =
                new Point(235, 72);

            cmbAccount.Size =
                new Size(190, 28);

            // =========================
            // Cash Account
            // =========================

            cmbCashAccount.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCashAccount.Location =
                new Point(30, 72);

            cmbCashAccount.Size =
                new Size(180, 28);

            // =========================
            // Amount
            // =========================

            nudAmount.DecimalPlaces = 2;

            nudAmount.Maximum =
                1000000000000M;

            nudAmount.Minimum = 0;

            nudAmount.Location =
                new Point(760, 167);

            nudAmount.Size =
                new Size(300, 27);

            // =========================
            // Notes
            // =========================

            txtNotes.Location =
                new Point(30, 167);

            txtNotes.Size =
                new Size(670, 100);

            txtNotes.Multiline = true;
            txtNotes.ScrollBars =
                ScrollBars.Vertical;

            // =========================
            // Footer
            // =========================

            panelFooter.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            panelFooter.BackColor =
                Color.FromArgb(245, 250, 245);

            panelFooter.Location =
                new Point(25, 500);

            panelFooter.Size =
                new Size(1115, 90);

            panelFooter.Controls.Add(btnNew);
            panelFooter.Controls.Add(btnSave);

            // =========================
            // New Button
            // =========================

            btnNew.BackColor = Color.White;

            btnNew.FlatStyle =
                FlatStyle.Flat;

            btnNew.Location =
                new Point(185, 22);

            btnNew.Size =
                new Size(130, 42);

            btnNew.Text =
                "سند جديد";

            btnNew.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            // =========================
            // Save Button
            // =========================

            btnSave.BackColor =
                Color.FromArgb(35, 120, 75);

            btnSave.ForeColor =
                Color.White;

            btnSave.FlatStyle =
                FlatStyle.Flat;

            btnSave.Location =
                new Point(35, 22);

            btnSave.Size =
                new Size(130, 42);

            btnSave.Text =
                "حفظ السند";

            btnSave.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btnSave.UseVisualStyleBackColor =
                false;

            // =========================
            // Form
            // =========================

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.White;

            ClientSize =
                new Size(1165, 620);

            Controls.Add(panelFooter);
            Controls.Add(groupVoucher);
            Controls.Add(panelHeader);

            Font =
                new Font(
                    "Segoe UI",
                    9F);

            MinimumSize =
                new Size(1000, 600);

            Name =
                "ReceiptVoucher";

            RightToLeft =
                RightToLeft.Yes;

            RightToLeftLayout =
                true;

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "سند قبض";

            Load += ReceiptVoucher_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();

            groupVoucher.ResumeLayout(false);
            groupVoucher.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                nudAmount).EndInit();

            panelFooter.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}