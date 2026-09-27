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
            lblTitle = new Label();
            grpAccountData = new GroupBox();
            chkIsGroup = new CheckBox();
            cmbParentAccount = new ComboBox();
            cmbAccountType = new ComboBox();
            txtAccountName = new TextBox();
            txtAccountNumber = new TextBox();
            lblParentAccount = new Label();
            lblAccountType = new Label();
            lblAccountName = new Label();
            lblAccountNumber = new Label();
            btnNew = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            grpAccountsList = new GroupBox();
            dgvAccounts = new DataGridView();
            grpAccountTree = new GroupBox();
            treeAccounts = new TreeView();
            grpAccountData.SuspendLayout();
            grpAccountsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            grpAccountTree.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(1060, 107);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "دليل الحسابات";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpAccountData
            // 
            grpAccountData.Controls.Add(chkIsGroup);
            grpAccountData.Controls.Add(cmbParentAccount);
            grpAccountData.Controls.Add(cmbAccountType);
            grpAccountData.Controls.Add(txtAccountName);
            grpAccountData.Controls.Add(txtAccountNumber);
            grpAccountData.Controls.Add(lblParentAccount);
            grpAccountData.Controls.Add(lblAccountType);
            grpAccountData.Controls.Add(lblAccountName);
            grpAccountData.Controls.Add(lblAccountNumber);
            grpAccountData.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountData.Location = new Point(33, 136);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.RightToLeft = RightToLeft.Yes;
            grpAccountData.Size = new Size(837, 160);
            grpAccountData.TabIndex = 1;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "بيانات الحساب";
            // 
            // chkIsGroup
            // 
            chkIsGroup.AutoSize = true;
            chkIsGroup.Location = new Point(690, 127);
            chkIsGroup.Name = "chkIsGroup";
            chkIsGroup.RightToLeft = RightToLeft.Yes;
            chkIsGroup.Size = new Size(139, 27);
            chkIsGroup.TabIndex = 8;
            chkIsGroup.Text = "حساب مجموعة";
            chkIsGroup.UseVisualStyleBackColor = true;
            // 
            // cmbParentAccount
            // 
            cmbParentAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentAccount.FormattingEnabled = true;
            cmbParentAccount.Location = new Point(70, 79);
            cmbParentAccount.Name = "cmbParentAccount";
            cmbParentAccount.RightToLeft = RightToLeft.Yes;
            cmbParentAccount.Size = new Size(220, 31);
            cmbParentAccount.TabIndex = 7;
            // 
            // cmbAccountType
            // 
            cmbAccountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountType.FormattingEnabled = true;
            cmbAccountType.Items.AddRange(new object[] { "أصل", "خصم", "حقوق ملكية", "إيراد", "مصروف" });
            cmbAccountType.Location = new Point(70, 38);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.RightToLeft = RightToLeft.Yes;
            cmbAccountType.Size = new Size(220, 31);
            cmbAccountType.TabIndex = 5;
            // 
            // txtAccountName
            // 
            txtAccountName.Location = new Point(450, 79);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.RightToLeft = RightToLeft.Yes;
            txtAccountName.Size = new Size(220, 30);
            txtAccountName.TabIndex = 3;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Location = new Point(450, 38);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.RightToLeft = RightToLeft.Yes;
            txtAccountNumber.Size = new Size(220, 30);
            txtAccountNumber.TabIndex = 1;
            // 
            // lblParentAccount
            // 
            lblParentAccount.AutoSize = true;
            lblParentAccount.Location = new Point(310, 83);
            lblParentAccount.Name = "lblParentAccount";
            lblParentAccount.Size = new Size(104, 23);
            lblParentAccount.TabIndex = 6;
            lblParentAccount.Text = "الحساب الأب:";
            // 
            // lblAccountType
            // 
            lblAccountType.AutoSize = true;
            lblAccountType.Location = new Point(310, 42);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(99, 23);
            lblAccountType.TabIndex = 4;
            lblAccountType.Text = "نوع الحساب:";
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Location = new Point(690, 83);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(102, 23);
            lblAccountName.TabIndex = 2;
            lblAccountName.Text = "اسم الحساب:";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Location = new Point(690, 42);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(99, 23);
            lblAccountNumber.TabIndex = 0;
            lblAccountNumber.Text = "رقم الحساب:";
            // 
            // btnNew
            // 
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Location = new Point(666, 302);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(190, 42);
            btnNew.TabIndex = 2;
            btnNew.Text = "جديد";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(460, 302);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(190, 42);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "إضافة";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.Location = new Point(249, 302);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(190, 42);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "تعديل";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(40, 302);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(190, 42);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // grpAccountsList
            // 
            grpAccountsList.Controls.Add(dgvAccounts);
            grpAccountsList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountsList.Location = new Point(20, 350);
            grpAccountsList.Name = "grpAccountsList";
            grpAccountsList.RightToLeft = RightToLeft.Yes;
            grpAccountsList.Size = new Size(853, 388);
            grpAccountsList.TabIndex = 6;
            grpAccountsList.TabStop = false;
            grpAccountsList.Text = "قائمة الحسابات";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.Location = new Point(3, 26);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RightToLeft = RightToLeft.Yes;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(847, 359);
            dgvAccounts.TabIndex = 0;
            // 
            // grpAccountTree
            // 
            grpAccountTree.Controls.Add(treeAccounts);
            grpAccountTree.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountTree.Location = new Point(945, 168);
            grpAccountTree.Name = "grpAccountTree";
            grpAccountTree.RightToLeft = RightToLeft.Yes;
            grpAccountTree.Size = new Size(405, 557);
            grpAccountTree.TabIndex = 7;
            grpAccountTree.TabStop = false;
            grpAccountTree.Text = "شجرة الحسابات";
            // 
            // treeAccounts
            // 
            treeAccounts.Dock = DockStyle.Fill;
            treeAccounts.Location = new Point(3, 26);
            treeAccounts.Name = "treeAccounts";
            treeAccounts.RightToLeft = RightToLeft.Yes;
            treeAccounts.RightToLeftLayout = true;
            treeAccounts.Size = new Size(399, 528);
            treeAccounts.TabIndex = 0;
            treeAccounts.AfterSelect += treeAccounts_AfterSelect;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 750);
            Controls.Add(grpAccountTree);
            Controls.Add(grpAccountsList);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnNew);
            Controls.Add(grpAccountData);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 650);
            Name = "AccountsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "دليل الحسابات";
            grpAccountData.ResumeLayout(false);
            grpAccountData.PerformLayout();
            grpAccountsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            grpAccountTree.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;

        private GroupBox grpAccountData;
        private Label lblAccountNumber;
        private Label lblAccountName;
        private Label lblAccountType;
        private Label lblParentAccount;

        private TextBox txtAccountNumber;
        private TextBox txtAccountName;
        private ComboBox cmbAccountType;
        private ComboBox cmbParentAccount;
        private CheckBox chkIsGroup;

        private Button btnNew;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private GroupBox grpAccountsList;
        private DataGridView dgvAccounts;

        private GroupBox grpAccountTree;
        private TreeView treeAccounts;
    }
}