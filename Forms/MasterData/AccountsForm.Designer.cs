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
            txtAccountNature = new TextBox();
            lblAccountNature = new Label();
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
            lblTitle.ForeColor = Color.FromArgb(25, 105, 65);
            lblTitle.Location = new Point(1059, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "دليل الحسابات";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpAccountData
            // 
            grpAccountData.BackColor = Color.FromArgb(248, 252, 249);
            grpAccountData.Controls.Add(chkIsGroup);
            grpAccountData.Controls.Add(txtAccountNature);
            grpAccountData.Controls.Add(lblAccountNature);
            grpAccountData.Controls.Add(cmbParentAccount);
            grpAccountData.Controls.Add(cmbAccountType);
            grpAccountData.Controls.Add(txtAccountName);
            grpAccountData.Controls.Add(txtAccountNumber);
            grpAccountData.Controls.Add(lblParentAccount);
            grpAccountData.Controls.Add(lblAccountType);
            grpAccountData.Controls.Add(lblAccountName);
            grpAccountData.Controls.Add(lblAccountNumber);
            grpAccountData.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountData.Location = new Point(20, 30);
            grpAccountData.Name = "grpAccountData";
            grpAccountData.RightToLeft = RightToLeft.Yes;
            grpAccountData.Size = new Size(900, 210);
            grpAccountData.TabIndex = 1;
            grpAccountData.TabStop = false;
            grpAccountData.Text = "بيانات الحساب";
            // 
            // chkIsGroup
            // 
            chkIsGroup.AutoSize = true;
            chkIsGroup.Location = new Point(690, 164);
            chkIsGroup.Name = "chkIsGroup";
            chkIsGroup.RightToLeft = RightToLeft.Yes;
            chkIsGroup.Size = new Size(139, 27);
            chkIsGroup.TabIndex = 8;
            chkIsGroup.Text = "حساب مجموعة";
            chkIsGroup.UseVisualStyleBackColor = true;
            // 
            // txtAccountNature
            // 
            txtAccountNature.BackColor = SystemColors.Control;
            txtAccountNature.Location = new Point(70, 116);
            txtAccountNature.Name = "txtAccountNature";
            txtAccountNature.ReadOnly = true;
            txtAccountNature.RightToLeft = RightToLeft.Yes;
            txtAccountNature.Size = new Size(220, 30);
            txtAccountNature.TabIndex = 10;
            txtAccountNature.TabStop = false;
            // 
            // lblAccountNature
            // 
            lblAccountNature.AutoSize = true;
            lblAccountNature.Location = new Point(310, 120);
            lblAccountNature.Name = "lblAccountNature";
            lblAccountNature.Size = new Size(119, 23);
            lblAccountNature.TabIndex = 9;
            lblAccountNature.Text = "طبيعة الحساب:";
            // 
            // cmbParentAccount
            // 
            cmbParentAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentAccount.FormattingEnabled = true;
            cmbParentAccount.Location = new Point(70, 75);
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
            cmbAccountType.Location = new Point(70, 34);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.RightToLeft = RightToLeft.Yes;
            cmbAccountType.Size = new Size(220, 31);
            cmbAccountType.TabIndex = 5;
            // 
            // txtAccountName
            // 
            txtAccountName.Location = new Point(450, 75);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.RightToLeft = RightToLeft.Yes;
            txtAccountName.Size = new Size(220, 30);
            txtAccountName.TabIndex = 3;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.BackColor = SystemColors.Control;
            txtAccountNumber.Location = new Point(450, 34);
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.ReadOnly = true;
            txtAccountNumber.RightToLeft = RightToLeft.Yes;
            txtAccountNumber.Size = new Size(220, 30);
            txtAccountNumber.TabIndex = 1;
            txtAccountNumber.TabStop = false;
            // 
            // lblParentAccount
            // 
            lblParentAccount.AutoSize = true;
            lblParentAccount.Location = new Point(310, 79);
            lblParentAccount.Name = "lblParentAccount";
            lblParentAccount.Size = new Size(104, 23);
            lblParentAccount.TabIndex = 6;
            lblParentAccount.Text = "الحساب الأب:";
            // 
            // lblAccountType
            // 
            lblAccountType.AutoSize = true;
            lblAccountType.Location = new Point(310, 38);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(99, 23);
            lblAccountType.TabIndex = 4;
            lblAccountType.Text = "نوع الحساب:";
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Location = new Point(690, 79);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(102, 23);
            lblAccountName.TabIndex = 2;
            lblAccountName.Text = "اسم الحساب:";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Location = new Point(690, 38);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(99, 23);
            lblAccountNumber.TabIndex = 0;
            lblAccountNumber.Text = "رقم الحساب:";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(25, 105, 65);
            btnNew.Cursor = Cursors.Hand;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(707, 255);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(200, 44);
            btnNew.TabIndex = 2;
            btnNew.Text = "حساب جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 125, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(492, 255);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(200, 44);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "إضافة الحساب";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(224, 170, 45);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(277, 255);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(200, 44);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "حفظ التعديل";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(185, 60, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(62, 255);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 44);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "حذف الحساب";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // grpAccountsList
            // 
            grpAccountsList.BackColor = Color.FromArgb(248, 252, 249);
            grpAccountsList.Controls.Add(dgvAccounts);
            grpAccountsList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountsList.Location = new Point(20, 305);
            grpAccountsList.Name = "grpAccountsList";
            grpAccountsList.RightToLeft = RightToLeft.Yes;
            grpAccountsList.Size = new Size(905, 360);
            grpAccountsList.TabIndex = 6;
            grpAccountsList.TabStop = false;
            grpAccountsList.Text = "قائمة الحسابات";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.None;
            dgvAccounts.ColumnHeadersHeight = 38;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.Location = new Point(3, 26);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RightToLeft = RightToLeft.Yes;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 34;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(899, 331);
            dgvAccounts.TabIndex = 0;
            // 
            // grpAccountTree
            // 
            grpAccountTree.BackColor = Color.FromArgb(248, 252, 249);
            grpAccountTree.Controls.Add(treeAccounts);
            grpAccountTree.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAccountTree.Location = new Point(943, 87);
            grpAccountTree.Name = "grpAccountTree";
            grpAccountTree.RightToLeft = RightToLeft.Yes;
            grpAccountTree.Size = new Size(439, 557);
            grpAccountTree.TabIndex = 7;
            grpAccountTree.TabStop = false;
            grpAccountTree.Text = "شجرة الحسابات";
            // 
            // treeAccounts
            // 
            treeAccounts.Dock = DockStyle.Fill;
            treeAccounts.Font = new Font("Segoe UI", 10F);
            treeAccounts.HideSelection = false;
            treeAccounts.Location = new Point(3, 26);
            treeAccounts.Name = "treeAccounts";
            treeAccounts.RightToLeft = RightToLeft.Yes;
            treeAccounts.RightToLeftLayout = true;
            treeAccounts.Size = new Size(433, 528);
            treeAccounts.TabIndex = 0;
            treeAccounts.AfterSelect += treeAccounts_AfterSelect;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
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
            MinimumSize = new Size(1150, 700);
            Name = "AccountsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "دليل الحسابات";
            Load += AccountsForm_Load;
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
        private Label lblAccountNature;

        private TextBox txtAccountNumber;
        private TextBox txtAccountName;
        private TextBox txtAccountNature;
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
