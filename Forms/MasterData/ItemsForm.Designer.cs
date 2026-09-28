namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class ItemsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupBoxData;

        private Label lblItemNumber;
        private Label lblItemName;
        private Label lblUnit;

        private TextBox txtItemNumber;
        private TextBox txtItemName;
        private ComboBox cmbUnit;

        private Button btnNew;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private DataGridView dgvItems;

        private Panel panelButtons;
        private Panel panelGridHeader;
        private Label lblItemsList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            groupBoxData = new GroupBox();
            lblItemNumber = new Label();
            txtItemNumber = new TextBox();
            lblItemName = new Label();
            txtItemName = new TextBox();
            lblUnit = new Label();
            cmbUnit = new ComboBox();
            btnNew = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            panelButtons = new Panel();
            panelGridHeader = new Panel();
            lblItemsList = new Label();
            dgvItems = new DataGridView();
            panelHeader.SuspendLayout();
            groupBoxData.SuspendLayout();
            panelButtons.SuspendLayout();
            panelGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 116, 82);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 85);
            panelHeader.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(850, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(208, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "دليل الأصناف";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(225, 245, 235);
            lblSubtitle.Location = new Point(780, 52);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(199, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "إدارة بيانات الأصناف والوحدات";
            // 
            // groupBoxData
            // 
            groupBoxData.BackColor = Color.White;
            groupBoxData.Controls.Add(lblItemNumber);
            groupBoxData.Controls.Add(txtItemNumber);
            groupBoxData.Controls.Add(lblItemName);
            groupBoxData.Controls.Add(txtItemName);
            groupBoxData.Controls.Add(lblUnit);
            groupBoxData.Controls.Add(cmbUnit);
            groupBoxData.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxData.ForeColor = Color.FromArgb(35, 116, 82);
            groupBoxData.Location = new Point(35, 105);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(1030, 170);
            groupBoxData.TabIndex = 6;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "بيانات الصنف";
            // 
            // lblItemNumber
            // 
            lblItemNumber.AutoSize = true;
            lblItemNumber.Font = new Font("Segoe UI", 10F);
            lblItemNumber.ForeColor = Color.FromArgb(45, 45, 45);
            lblItemNumber.Location = new Point(900, 45);
            lblItemNumber.Name = "lblItemNumber";
            lblItemNumber.Size = new Size(90, 23);
            lblItemNumber.TabIndex = 0;
            lblItemNumber.Text = "رقم الصنف";
            // 
            // txtItemNumber
            // 
            txtItemNumber.BackColor = Color.FromArgb(250, 252, 251);
            txtItemNumber.BorderStyle = BorderStyle.FixedSingle;
            txtItemNumber.Font = new Font("Segoe UI", 11F);
            txtItemNumber.Location = new Point(650, 40);
            txtItemNumber.Name = "txtItemNumber";
            txtItemNumber.Size = new Size(230, 32);
            txtItemNumber.TabIndex = 0;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Font = new Font("Segoe UI", 10F);
            lblItemName.ForeColor = Color.FromArgb(45, 45, 45);
            lblItemName.Location = new Point(550, 45);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(93, 23);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "اسم الصنف";
            // 
            // txtItemName
            // 
            txtItemName.BackColor = Color.FromArgb(250, 252, 251);
            txtItemName.BorderStyle = BorderStyle.FixedSingle;
            txtItemName.Font = new Font("Segoe UI", 11F);
            txtItemName.Location = new Point(275, 40);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(260, 32);
            txtItemName.TabIndex = 1;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 10F);
            lblUnit.ForeColor = Color.FromArgb(45, 45, 45);
            lblUnit.Location = new Point(195, 45);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(57, 23);
            lblUnit.TabIndex = 2;
            lblUnit.Text = "الوحدة";
            // 
            // cmbUnit
            // 
            cmbUnit.BackColor = Color.White;
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.Font = new Font("Segoe UI", 10F);
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Items.AddRange(new object[] { "قطعة", "كرتون", "كيلو", "جرام", "متر", "لتر", "علبة", "حبة" });
            cmbUnit.Location = new Point(35, 40);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(145, 31);
            cmbUnit.TabIndex = 2;
            cmbUnit.SelectedIndexChanged += cmbUnit_SelectedIndexChanged;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(245, 194, 70);
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.FromArgb(45, 45, 45);
            btnNew.Location = new Point(895, 5);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(120, 42);
            btnNew.TabIndex = 0;
            btnNew.Text = "جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(35, 116, 82);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(760, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 42);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "إضافة";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(70, 145, 110);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(625, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 42);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "تعديل";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(190, 70, 65);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(490, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 42);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(btnNew);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Location = new Point(35, 290);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1030, 55);
            panelButtons.TabIndex = 5;
            // 
            // panelGridHeader
            // 
            panelGridHeader.BackColor = Color.White;
            panelGridHeader.Controls.Add(lblItemsList);
            panelGridHeader.Location = new Point(35, 360);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Size = new Size(1030, 45);
            panelGridHeader.TabIndex = 4;
            // 
            // lblItemsList
            // 
            lblItemsList.AutoSize = true;
            lblItemsList.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblItemsList.ForeColor = Color.FromArgb(35, 116, 82);
            lblItemsList.Location = new Point(900, 10);
            lblItemsList.Name = "lblItemsList";
            lblItemsList.Size = new Size(124, 25);
            lblItemsList.TabIndex = 0;
            lblItemsList.Text = "قائمة الأصناف";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItems.ColumnHeadersHeight = 42;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.GridColor = Color.FromArgb(225, 230, 227);
            dgvItems.Location = new Point(35, 405);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.RowTemplate.Height = 38;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(1030, 230);
            dgvItems.TabIndex = 3;
            dgvItems.CellContentClick += dgvItems_CellContentClick;
            // 
            // ItemsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 246);
            ClientSize = new Size(1100, 680);
            Controls.Add(dgvItems);
            Controls.Add(panelGridHeader);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxData);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ItemsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "دليل الأصناف";
            Load += ItemsForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelGridHeader.ResumeLayout(false);
            panelGridHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }
    }
}