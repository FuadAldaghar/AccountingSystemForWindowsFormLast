namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class AccountStatement
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupFilters;
        private Label lblAccount;
        private Label lblFromDate;
        private Label lblToDate;

        private ComboBox cmbAccount;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;

        private Button btnSearch;
        private Button btnShowAll;

        private DataGridView dgvStatement;

        private Panel panelFooter;
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
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            groupFilters = new GroupBox();
            lblAccount = new Label();
            lblFromDate = new Label();
            lblToDate = new Label();

            cmbAccount = new ComboBox();
            dtpFromDate = new DateTimePicker();
            dtpToDate = new DateTimePicker();

            btnSearch = new Button();
            btnShowAll = new Button();

            dgvStatement = new DataGridView();

            panelFooter = new Panel();
            lblOpeningTitle = new Label();
            lblOpeningBalance = new Label();
            lblDebitTitle = new Label();
            lblDebitTotal = new Label();
            lblCreditTitle = new Label();
            lblCreditTotal = new Label();
            lblBalanceTitle = new Label();
            lblFinalBalance = new Label();

            panelHeader.SuspendLayout();
            groupFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatement).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(46, 125, 50);
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
            lblTitle.Text = "كشف حساب";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(38, 53);
            lblSubtitle.Text = "حركة الحساب والرصيد الافتتاحي والختامي";

            // 
            // groupFilters
            // 
            groupFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left |
                                  AnchorStyles.Right;
            groupFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupFilters.Location = new Point(25, 100);
            groupFilters.Size = new Size(1115, 115);
            groupFilters.Text = "خيارات التقرير";

            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(850, 35);
            lblAccount.Text = "الحساب";

            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(600, 30);
            cmbAccount.Size = new Size(235, 28);

            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(530, 35);
            lblFromDate.Text = "من";

            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(370, 30);
            dtpFromDate.Size = new Size(145, 27);

            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(290, 35);
            lblToDate.Text = "إلى";

            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(130, 30);
            dtpToDate.Size = new Size(145, 27);

            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(46, 125, 50);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(20, 72);
            btnSearch.Size = new Size(120, 32);
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;

            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.FromArgb(255, 235, 130);
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.ForeColor = Color.Black;
            btnShowAll.Location = new Point(150, 72);
            btnShowAll.Size = new Size(120, 32);
            btnShowAll.Text = "عرض الكل";
            btnShowAll.UseVisualStyleBackColor = false;

            groupFilters.Controls.Add(lblAccount);
            groupFilters.Controls.Add(cmbAccount);
            groupFilters.Controls.Add(lblFromDate);
            groupFilters.Controls.Add(dtpFromDate);
            groupFilters.Controls.Add(lblToDate);
            groupFilters.Controls.Add(dtpToDate);
            groupFilters.Controls.Add(btnSearch);
            groupFilters.Controls.Add(btnShowAll);

            // 
            // dgvStatement
            // 
            dgvStatement.AllowUserToAddRows = false;
            dgvStatement.AllowUserToDeleteRows = false;
            dgvStatement.AllowUserToResizeRows = false;
            dgvStatement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                                  AnchorStyles.Left | AnchorStyles.Right;
            dgvStatement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatement.BackgroundColor = Color.White;
            dgvStatement.BorderStyle = BorderStyle.Fixed3D;
            dgvStatement.ColumnHeadersHeight = 40;
            dgvStatement.Location = new Point(25, 230);
            dgvStatement.MultiSelect = false;
            dgvStatement.ReadOnly = true;
            dgvStatement.RowHeadersVisible = false;
            dgvStatement.RowTemplate.Height = 35;
            dgvStatement.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvStatement.Size = new Size(1115, 355);

            // 
            // panelFooter
            // 
            panelFooter.Anchor = AnchorStyles.Bottom |
                                  AnchorStyles.Left |
                                  AnchorStyles.Right;
            panelFooter.BackColor = Color.FromArgb(245, 248, 245);
            panelFooter.BorderStyle = BorderStyle.FixedSingle;
            panelFooter.Location = new Point(25, 600);
            panelFooter.Size = new Size(1115, 65);

            // 
            // lblOpeningTitle
            // 
            lblOpeningTitle.AutoSize = true;
            lblOpeningTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOpeningTitle.Location = new Point(1000, 10);
            lblOpeningTitle.Text = "الافتتاحي";

            // 
            // lblOpeningBalance
            // 
            lblOpeningBalance.AutoSize = true;
            lblOpeningBalance.Location = new Point(1000, 34);
            lblOpeningBalance.Text = "0.00";

            // 
            // lblDebitTitle
            // 
            lblDebitTitle.AutoSize = true;
            lblDebitTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDebitTitle.Location = new Point(750, 10);
            lblDebitTitle.Text = "إجمالي المدين";

            // 
            // lblDebitTotal
            // 
            lblDebitTotal.AutoSize = true;
            lblDebitTotal.Location = new Point(750, 34);
            lblDebitTotal.Text = "0.00";

            // 
            // lblCreditTitle
            // 
            lblCreditTitle.AutoSize = true;
            lblCreditTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCreditTitle.Location = new Point(500, 10);
            lblCreditTitle.Text = "إجمالي الدائن";

            // 
            // lblCreditTotal
            // 
            lblCreditTotal.AutoSize = true;
            lblCreditTotal.Location = new Point(500, 34);
            lblCreditTotal.Text = "0.00";

            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBalanceTitle.Location = new Point(250, 10);
            lblBalanceTitle.Text = "الرصيد النهائي";

            // 
            // lblFinalBalance
            // 
            lblFinalBalance.AutoSize = true;
            lblFinalBalance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFinalBalance.Location = new Point(250, 34);
            lblFinalBalance.Text = "0.00";

            panelFooter.Controls.Add(lblOpeningTitle);
            panelFooter.Controls.Add(lblOpeningBalance);
            panelFooter.Controls.Add(lblDebitTitle);
            panelFooter.Controls.Add(lblDebitTotal);
            panelFooter.Controls.Add(lblCreditTitle);
            panelFooter.Controls.Add(lblCreditTotal);
            panelFooter.Controls.Add(lblBalanceTitle);
            panelFooter.Controls.Add(lblFinalBalance);

            // 
            // AccountStatement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1165, 690);
            Controls.Add(panelFooter);
            Controls.Add(dgvStatement);
            Controls.Add(groupFilters);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(1000, 600);
            Name = "AccountStatement";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "كشف حساب";
            Load += AccountStatement_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupFilters.ResumeLayout(false);
            groupFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatement).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
        }
    }
}