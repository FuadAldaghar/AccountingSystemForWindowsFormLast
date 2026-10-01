namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class AccountsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            grpAccountData = new GroupBox();
            dataLayout = new TableLayoutPanel();
            btnEdit = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            lblAccountNumber = new Label();
            txtAccountNumber = new TextBox();
            lblAccountName = new Label();
            txtAccountName = new TextBox();
            cmbAccountType = new ComboBox();
            txtAccountNature = new TextBox();
            chkIsGroup = new CheckBox();
            lblAccountType = new Label();
            btnAdd = new Button();
            lblAccountNature = new Label();
            lblParentAccount = new Label();
            cmbParentAccount = new ComboBox();
            contentLayout = new TableLayoutPanel();
            grpAccountsList = new GroupBox();
            dgvAccounts = new DataGridView();
            grpAccountTree = new GroupBox();
            treeAccounts = new TreeView();
            rootLayout.SuspendLayout();
            grpAccountData.SuspendLayout();
            dataLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            grpAccountsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            grpAccountTree.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.AutoSize = true;
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(grpAccountData, 0, 0);
            rootLayout.Controls.Add(contentLayout, 0, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 32.1428566F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 67.85714F));
            rootLayout.Size = new Size(1082, 780);
            rootLayout.TabIndex = 0;
            // 
            // grpAccountData
            // 
            grpAccountData.Controls.Add(dataLayout);
            grpAccountData.Dock = DockStyle.Fill;
            grpAccountData.Location = new Point(15, 12);
            grpAccountData.Margin = new Padding(3, 0, 3, 10);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.Size = new Size(1052, 233);
            grpAccountData.TabIndex = 1;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "بيانات الحساب";
            // 
            // dataLayout
            // 
            dataLayout.ColumnCount = 6;
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.43629F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2947979F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0289021F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.4555988F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1312742F));
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.6370659F));
            dataLayout.Controls.Add(btnEdit, 0, 2);
            dataLayout.Controls.Add(btnDelete, 0, 2);
            dataLayout.Controls.Add(btnNew, 0, 2);
            dataLayout.Controls.Add(lblAccountNumber, 0, 0);
            dataLayout.Controls.Add(txtAccountNumber, 1, 0);
            dataLayout.Controls.Add(lblAccountName, 2, 0);
            dataLayout.Controls.Add(txtAccountName, 3, 0);
            dataLayout.Controls.Add(cmbAccountType, 5, 0);
            dataLayout.Controls.Add(txtAccountNature, 3, 1);
            dataLayout.Controls.Add(chkIsGroup, 4, 1);
            dataLayout.Controls.Add(lblAccountType, 4, 0);
            dataLayout.Controls.Add(btnAdd, 3, 2);
            dataLayout.Controls.Add(lblAccountNature, 2, 1);
            dataLayout.Controls.Add(lblParentAccount, 0, 1);
            dataLayout.Controls.Add(cmbParentAccount, 1, 1);
            dataLayout.Dock = DockStyle.Fill;
            dataLayout.Location = new Point(3, 26);
            dataLayout.Margin = new Padding(0);
            dataLayout.Name = "dataLayout";
            dataLayout.Padding = new Padding(4, 0, 4, 8);
            dataLayout.RowCount = 3;
            dataLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            dataLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            dataLayout.RowStyles.Add(new RowStyle());
            dataLayout.Size = new Size(1046, 204);
            dataLayout.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(618, 150);
            btnEdit.Margin = new Padding(6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(141, 40);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "حفظ التعديل";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(911, 150);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 40);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "حذف الحساب";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(773, 150);
            btnNew.Margin = new Padding(6);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(124, 40);
            btnNew.TabIndex = 11;
            btnNew.Text = "حساب جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.Anchor = AnchorStyles.Right;
            lblAccountNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccountNumber.Location = new Point(906, 13);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(131, 46);
            lblAccountNumber.TabIndex = 0;
            lblAccountNumber.Text = "رقم الحساب:";
            lblAccountNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAccountNumber.BackColor = Color.White;
            txtAccountNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtAccountNumber.Location = new Point(775, 20);
            txtAccountNumber.Margin = new Padding(3, 4, 10, 6);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.ReadOnly = true;
            txtAccountNumber.Size = new Size(125, 30);
            txtAccountNumber.TabIndex = 1;
            txtAccountNumber.TabStop = false;
            // 
            // lblAccountName
            // 
            lblAccountName.Anchor = AnchorStyles.Right;
            lblAccountName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccountName.Location = new Point(612, 13);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(142, 46);
            lblAccountName.TabIndex = 2;
            lblAccountName.Text = "اسم الحساب:";
            lblAccountName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAccountName
            // 
            txtAccountName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAccountName.Font = new Font("Segoe UI", 10F);
            txtAccountName.Location = new Point(428, 20);
            txtAccountName.Margin = new Padding(3, 4, 10, 6);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new Size(178, 30);
            txtAccountName.TabIndex = 3;
            // 
            // cmbAccountType
            // 
            cmbAccountType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbAccountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountType.Font = new Font("Segoe UI", 10F);
            cmbAccountType.FormattingEnabled = true;
            cmbAccountType.Items.AddRange(new object[] { "أصل", "خصم", "حقوق ملكية", "إيراد", "مصروف" });
            cmbAccountType.Location = new Point(8, 19);
            cmbAccountType.Margin = new Padding(3, 4, 4, 6);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.Size = new Size(261, 31);
            cmbAccountType.TabIndex = 5;
            // 
            // txtAccountNature
            // 
            txtAccountNature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAccountNature.BackColor = Color.White;
            txtAccountNature.Font = new Font("Segoe UI", 10F);
            txtAccountNature.Location = new Point(428, 76);
            txtAccountNature.Margin = new Padding(3, 4, 10, 6);
            txtAccountNature.Name = "txtAccountNature";
            txtAccountNature.ReadOnly = true;
            txtAccountNature.Size = new Size(178, 30);
            txtAccountNature.TabIndex = 10;
            txtAccountNature.TabStop = false;
            txtAccountNature.TextAlign = HorizontalAlignment.Center;
            // 
            // chkIsGroup
            // 
            chkIsGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkIsGroup.AutoSize = true;
            dataLayout.SetColumnSpan(chkIsGroup, 2);
            chkIsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkIsGroup.ForeColor = Color.FromArgb(45, 55, 50);
            chkIsGroup.Location = new Point(7, 75);
            chkIsGroup.Name = "chkIsGroup";
            chkIsGroup.RightToLeft = RightToLeft.Yes;
            chkIsGroup.Size = new Size(139, 27);
            chkIsGroup.TabIndex = 8;
            chkIsGroup.Text = "حساب مجموعة";
            chkIsGroup.UseVisualStyleBackColor = true;
            // 
            // lblAccountType
            // 
            lblAccountType.Anchor = AnchorStyles.Right;
            lblAccountType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccountType.Location = new Point(275, 14);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(138, 44);
            lblAccountType.TabIndex = 4;
            lblAccountType.Text = "نوع الحساب:";
            lblAccountType.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(439, 150);
            btnAdd.Margin = new Padding(6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(164, 40);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "إضافة الحساب";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblAccountNature
            // 
            lblAccountNature.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAccountNature.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccountNature.Location = new Point(612, 72);
            lblAccountNature.Name = "lblAccountNature";
            lblAccountNature.Size = new Size(142, 55);
            lblAccountNature.TabIndex = 9;
            lblAccountNature.Text = "طبيعة الحساب:";
            lblAccountNature.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblParentAccount
            // 
            lblParentAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblParentAccount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblParentAccount.Location = new Point(906, 72);
            lblParentAccount.Name = "lblParentAccount";
            lblParentAccount.Size = new Size(105, 55);
            lblParentAccount.TabIndex = 6;
            lblParentAccount.Text = "الحساب الأب:";
            lblParentAccount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbParentAccount
            // 
            cmbParentAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbParentAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentAccount.Font = new Font("Segoe UI", 10F);
            cmbParentAccount.FormattingEnabled = true;
            cmbParentAccount.Location = new Point(775, 76);
            cmbParentAccount.Margin = new Padding(3, 4, 10, 6);
            cmbParentAccount.Name = "cmbParentAccount";
            cmbParentAccount.Size = new Size(125, 31);
            cmbParentAccount.TabIndex = 7;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.581234F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.418766F));
            contentLayout.Controls.Add(grpAccountsList, 0, 0);
            contentLayout.Controls.Add(grpAccountTree, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(12, 255);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.Padding = new Padding(0, 4, 0, 0);
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(1058, 513);
            contentLayout.TabIndex = 3;
            // 
            // grpAccountsList
            // 
            grpAccountsList.Controls.Add(dgvAccounts);
            grpAccountsList.Dock = DockStyle.Fill;
            grpAccountsList.Location = new Point(445, 4);
            grpAccountsList.Margin = new Padding(3, 0, 6, 3);
            grpAccountsList.Name = "grpAccountsList";
            grpAccountsList.Size = new Size(610, 506);
            grpAccountsList.TabIndex = 6;
            grpAccountsList.TabStop = false;
            grpAccountsList.Text = "قائمة الحسابات";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.AllowUserToResizeRows = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.None;
            dgvAccounts.ColumnHeadersHeight = 38;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.Location = new Point(3, 26);
            dgvAccounts.Margin = new Padding(0);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(604, 477);
            dgvAccounts.TabIndex = 0;
            // 
            // grpAccountTree
            // 
            grpAccountTree.AutoSize = true;
            grpAccountTree.Controls.Add(treeAccounts);
            grpAccountTree.Dock = DockStyle.Fill;
            grpAccountTree.Location = new Point(3, 4);
            grpAccountTree.Margin = new Padding(6, 0, 3, 3);
            grpAccountTree.Name = "grpAccountTree";
            grpAccountTree.Size = new Size(430, 506);
            grpAccountTree.TabIndex = 7;
            grpAccountTree.TabStop = false;
            grpAccountTree.Text = "شجرة الحسابات";
            // 
            // treeAccounts
            // 
            treeAccounts.BorderStyle = BorderStyle.None;
            treeAccounts.Dock = DockStyle.Fill;
            treeAccounts.Font = new Font("Segoe UI", 10F);
            treeAccounts.HideSelection = false;
            treeAccounts.ItemHeight = 26;
            treeAccounts.Location = new Point(3, 26);
            treeAccounts.Name = "treeAccounts";
            treeAccounts.RightToLeft = RightToLeft.Yes;
            treeAccounts.RightToLeftLayout = true;
            treeAccounts.Size = new Size(424, 477);
            treeAccounts.TabIndex = 0;
            treeAccounts.AfterSelect += treeAccounts_AfterSelect;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(246, 248, 247);
            ClientSize = new Size(1082, 780);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 700);
            Name = "AccountsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "دليل الحسابات";
            Load += AccountsForm_Load;
            rootLayout.ResumeLayout(false);
            grpAccountData.ResumeLayout(false);
            dataLayout.ResumeLayout(false);
            dataLayout.PerformLayout();
            contentLayout.ResumeLayout(false);
            contentLayout.PerformLayout();
            grpAccountsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            grpAccountTree.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel rootLayout;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox grpAccountData;
        private TableLayoutPanel dataLayout;
        private Label lblAccountNumber;
        private Label lblAccountName;
        private Label lblParentAccount;
        private Label lblAccountNature;

        private TextBox txtAccountNumber;
        private TextBox txtAccountName;
        private TextBox txtAccountNature;
        private ComboBox cmbParentAccount;

        private TableLayoutPanel contentLayout;
        private GroupBox grpAccountsList;

        private GroupBox grpAccountTree;
        private TreeView treeAccounts;
        private DataGridView dgvAccounts;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnNew;
        private Button btnAdd;
        private ComboBox cmbAccountType;
        private CheckBox chkIsGroup;
        private Label lblAccountType;
    }
}