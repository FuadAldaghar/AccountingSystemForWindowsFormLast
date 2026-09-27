namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class JournalEntries
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblEntryNumber;
        private Label lblEntryDate;
        private Label lblDescription;

        private TextBox txtEntryNumber;
        private DateTimePicker dtpEntryDate;
        private TextBox txtDescription;

        private Button btnNew;
        private Button btnSave;
        private Button btnDelete;

        private ComboBox cmbAccount;
        private Button btnAddRow;
        private Button btnRemoveRow;

        private DataGridView dgvDetails;
        private DataGridView dgvEntries;

        private Label lblTotalDebit;
        private Label lblTotalCredit;
        private Label lblDifference;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblEntryNumber = new Label();
            lblEntryDate = new Label();
            lblDescription = new Label();
            txtEntryNumber = new TextBox();
            dtpEntryDate = new DateTimePicker();
            txtDescription = new TextBox();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            cmbAccount = new ComboBox();
            btnAddRow = new Button();
            btnRemoveRow = new Button();
            dgvDetails = new DataGridView();
            dgvEntries = new DataGridView();
            lblTotalDebit = new Label();
            lblTotalCredit = new Label();
            lblDifference = new Label();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).BeginInit();
            SuspendLayout();
            // 
            // lblEntryNumber
            // 
            lblEntryNumber.AutoSize = true;
            lblEntryNumber.Location = new Point(1040, 25);
            lblEntryNumber.Name = "lblEntryNumber";
            lblEntryNumber.Size = new Size(74, 23);
            lblEntryNumber.TabIndex = 0;
            lblEntryNumber.Text = "رقم القيد";
            // 
            // lblEntryDate
            // 
            lblEntryDate.AutoSize = true;
            lblEntryDate.Location = new Point(790, 25);
            lblEntryDate.Name = "lblEntryDate";
            lblEntryDate.Size = new Size(54, 23);
            lblEntryDate.TabIndex = 2;
            lblEntryDate.Text = "التاريخ";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(585, 25);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(47, 23);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "البيان";
            // 
            // txtEntryNumber
            // 
            txtEntryNumber.Location = new Point(850, 20);
            txtEntryNumber.Name = "txtEntryNumber";
            txtEntryNumber.ReadOnly = true;
            txtEntryNumber.Size = new Size(170, 30);
            txtEntryNumber.TabIndex = 1;
            // 
            // dtpEntryDate
            // 
            dtpEntryDate.Format = DateTimePickerFormat.Short;
            dtpEntryDate.Location = new Point(650, 20);
            dtpEntryDate.Name = "dtpEntryDate";
            dtpEntryDate.Size = new Size(120, 30);
            dtpEntryDate.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(300, 20);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(270, 30);
            txtDescription.TabIndex = 5;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(1050, 70);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 38);
            btnNew.TabIndex = 6;
            btnNew.Text = "جديد";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(930, 70);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 38);
            btnSave.TabIndex = 7;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(810, 70);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 38);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.Location = new Point(700, 130);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(300, 31);
            cmbAccount.TabIndex = 9;
            // 
            // btnAddRow
            // 
            btnAddRow.Location = new Point(590, 128);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(90, 35);
            btnAddRow.TabIndex = 10;
            btnAddRow.Text = "إضافة";
            btnAddRow.UseVisualStyleBackColor = true;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Location = new Point(490, 128);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(90, 35);
            btnRemoveRow.TabIndex = 11;
            btnRemoveRow.Text = "حذف السطر";
            btnRemoveRow.UseVisualStyleBackColor = true;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = SystemColors.Window;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvDetails.Location = new Point(40, 180);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.Size = new Size(1110, 230);
            dgvDetails.TabIndex = 12;
            // 
            // dgvEntries
            // 
            dgvEntries.AllowUserToAddRows = false;
            dgvEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntries.BackgroundColor = SystemColors.Window;
            dgvEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntries.Location = new Point(40, 470);
            dgvEntries.Name = "dgvEntries";
            dgvEntries.RowHeadersWidth = 51;
            dgvEntries.Size = new Size(1110, 180);
            dgvEntries.TabIndex = 16;
            // 
            // lblTotalDebit
            // 
            lblTotalDebit.AutoSize = true;
            lblTotalDebit.Location = new Point(850, 425);
            lblTotalDebit.Name = "lblTotalDebit";
            lblTotalDebit.Size = new Size(149, 23);
            lblTotalDebit.TabIndex = 13;
            lblTotalDebit.Text = "إجمالي المدين: 0.00";
            // 
            // lblTotalCredit
            // 
            lblTotalCredit.AutoSize = true;
            lblTotalCredit.Location = new Point(600, 425);
            lblTotalCredit.Name = "lblTotalCredit";
            lblTotalCredit.Size = new Size(143, 23);
            lblTotalCredit.TabIndex = 14;
            lblTotalCredit.Text = "إجمالي الدائن: 0.00";
            // 
            // lblDifference
            // 
            lblDifference.AutoSize = true;
            lblDifference.Location = new Point(350, 425);
            lblDifference.Name = "lblDifference";
            lblDifference.Size = new Size(89, 23);
            lblDifference.TabIndex = 15;
            lblDifference.Text = "الفرق: 0.00";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // JournalEntries
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(lblEntryNumber);
            Controls.Add(txtEntryNumber);
            Controls.Add(lblEntryDate);
            Controls.Add(dtpEntryDate);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(cmbAccount);
            Controls.Add(btnAddRow);
            Controls.Add(btnRemoveRow);
            Controls.Add(dgvDetails);
            Controls.Add(lblTotalDebit);
            Controls.Add(lblTotalCredit);
            Controls.Add(lblDifference);
            Controls.Add(dgvEntries);
            Font = new Font("Segoe UI", 10F);
            Name = "JournalEntries";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "قيد اليومية العام";
            Load += JournalEntries_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}