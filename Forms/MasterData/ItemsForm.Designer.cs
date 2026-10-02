
namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class ItemsForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayout;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private GroupBox groupBoxData;
        private TableLayoutPanel dataLayout;
        private Label lblItemNumber;
        private Label lblItemName;
        private Label lblUnit;
        private TextBox txtItemNumber;
        private TextBox txtItemName;

        private FlowLayoutPanel panelButtons;
        private Button btnNew;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private Panel panelGridHeader;
        private Label lblItemsList;

        private DataGridView dgvItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            groupBoxData = new GroupBox();
            dataLayout = new TableLayoutPanel();
            lblItemNumber = new Label();
            txtItemNumber = new TextBox();
            lblItemName = new Label();
            txtItemName = new TextBox();
            cmbUnit = new ComboBox();
            lblUnit = new Label();
            panelButtons = new FlowLayoutPanel();
            btnNew = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            panelGridHeader = new Panel();
            lblItemsList = new Label();
            dgvItems = new DataGridView();
            rootLayout.SuspendLayout();
            panelHeader.SuspendLayout();
            groupBoxData.SuspendLayout();
            dataLayout.SuspendLayout();
            panelButtons.SuspendLayout();
            panelGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(panelHeader, 0, 0);
            rootLayout.Controls.Add(groupBoxData, 0, 1);
            rootLayout.Controls.Add(panelButtons, 0, 2);
            rootLayout.Controls.Add(panelGridHeader, 0, 3);
            rootLayout.Controls.Add(dgvItems, 0, 4);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(12);
            rootLayout.RowCount = 5;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(1100, 700);
            rootLayout.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(35, 116, 82);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(15, 12);
            panelHeader.Margin = new Padding(3, 0, 3, 10);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(18, 10, 18, 8);
            panelHeader.Size = new Size(1070, 74);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(225, 245, 235);
            lblSubtitle.Location = new Point(18, 10);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.RightToLeft = RightToLeft.No;
            lblSubtitle.Size = new Size(1034, 56);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "إدارة بيانات الأصناف والوحدات";
            lblSubtitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1034, 56);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "دليل الأصناف";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(dataLayout);
            groupBoxData.Location = new Point(125, 96);
            groupBoxData.Margin = new Padding(3, 0, 3, 10);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(960, 114);
            groupBoxData.TabIndex = 1;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "بيانات الصنف";
            // 
            // dataLayout
            // 
            dataLayout.AutoSize = true;
            dataLayout.ColumnCount = 6;
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle());
            dataLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            dataLayout.Controls.Add(lblItemNumber, 0, 0);
            dataLayout.Controls.Add(txtItemNumber, 1, 0);
            dataLayout.Controls.Add(lblItemName, 2, 0);
            dataLayout.Controls.Add(txtItemName, 3, 0);
            dataLayout.Controls.Add(cmbUnit, 5, 0);
            dataLayout.Controls.Add(lblUnit, 4, 0);
            dataLayout.Dock = DockStyle.Right;
            dataLayout.Location = new Point(20, 26);
            dataLayout.Margin = new Padding(0);
            dataLayout.Name = "dataLayout";
            dataLayout.Padding = new Padding(4, 0, 4, 8);
            dataLayout.RowCount = 1;
            dataLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dataLayout.Size = new Size(937, 85);
            dataLayout.TabIndex = 0;
            // 
            // lblItemNumber
            // 
            lblItemNumber.Anchor = AnchorStyles.Right;
            lblItemNumber.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblItemNumber.Location = new Point(793, 15);
            lblItemNumber.Name = "lblItemNumber";
            lblItemNumber.Size = new Size(137, 47);
            lblItemNumber.TabIndex = 0;
            lblItemNumber.Text = "رقم الصنف";
            lblItemNumber.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtItemNumber
            // 
            txtItemNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtItemNumber.Font = new Font("Segoe UI", 10F);
            txtItemNumber.Location = new Point(583, 17);
            txtItemNumber.Margin = new Padding(3, 4, 10, 8);
            txtItemNumber.Multiline = true;
            txtItemNumber.Name = "txtItemNumber";
            txtItemNumber.Size = new Size(204, 39);
            txtItemNumber.TabIndex = 0;
            // 
            // lblItemName
            // 
            lblItemName.Anchor = AnchorStyles.Right;
            lblItemName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblItemName.Location = new Point(454, 21);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(116, 35);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "اسم الصنف";
            lblItemName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtItemName
            // 
            txtItemName.Anchor = AnchorStyles.Left;
            txtItemName.Font = new Font("Segoe UI", 10F);
            txtItemName.Location = new Point(237, 17);
            txtItemName.Margin = new Padding(3, 4, 10, 8);
            txtItemName.Multiline = true;
            txtItemName.Name = "txtItemName";
            txtItemName.RightToLeft = RightToLeft.No;
            txtItemName.Size = new Size(211, 38);
            txtItemName.TabIndex = 1;
            txtItemName.TextAlign = HorizontalAlignment.Right;
            // 
            // cmbUnit
            // 
            cmbUnit.Anchor = AnchorStyles.Left;
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.FlatStyle = FlatStyle.Popup;
            cmbUnit.Font = new Font("Segoe UI", 10F);
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Items.AddRange(new object[] { "قطعة", "كرتون", "كيلو", "جرام", "متر", "لتر", "علبة", "حبة" });
            cmbUnit.Location = new Point(8, 21);
            cmbUnit.Margin = new Padding(3, 4, 4, 8);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new Size(112, 31);
            cmbUnit.TabIndex = 2;
            cmbUnit.SelectedIndexChanged += cmbUnit_SelectedIndexChanged;
            // 
            // lblUnit
            // 
            lblUnit.Anchor = AnchorStyles.Right;
            lblUnit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUnit.Location = new Point(126, 28);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(98, 20);
            lblUnit.TabIndex = 2;
            lblUnit.Text = "الوحدة";
            lblUnit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnNew);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(15, 220);
            panelButtons.Margin = new Padding(3, 0, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.RightToLeft = RightToLeft.No;
            panelButtons.Size = new Size(1070, 56);
            panelButtons.TabIndex = 2;
            panelButtons.WrapContents = false;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(946, 6);
            btnNew.Margin = new Padding(6);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(118, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "جديد";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(816, 6);
            btnAdd.Margin = new Padding(6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "إضافة";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(686, 6);
            btnEdit.Margin = new Padding(6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "تعديل";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(556, 6);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panelGridHeader
            // 
            panelGridHeader.Controls.Add(lblItemsList);
            panelGridHeader.Dock = DockStyle.Fill;
            panelGridHeader.Location = new Point(15, 280);
            panelGridHeader.Margin = new Padding(3, 0, 3, 0);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Size = new Size(1070, 40);
            panelGridHeader.TabIndex = 3;
            // 
            // lblItemsList
            // 
            lblItemsList.Dock = DockStyle.Fill;
            lblItemsList.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblItemsList.ForeColor = Color.FromArgb(35, 116, 82);
            lblItemsList.Location = new Point(0, 0);
            lblItemsList.Name = "lblItemsList";
            lblItemsList.RightToLeft = RightToLeft.No;
            lblItemsList.Size = new Size(1070, 40);
            lblItemsList.TabIndex = 0;
            lblItemsList.Text = "قائمة الأصناف";
            lblItemsList.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvItems.ColumnHeadersHeight = 38;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.Location = new Point(15, 320);
            dgvItems.Margin = new Padding(3, 0, 3, 0);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(1070, 368);
            dgvItems.TabIndex = 4;
            dgvItems.CellContentClick += dgvItems_CellContentClick;
            // 
            // ItemsForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 248, 246);
            ClientSize = new Size(1100, 700);
            Controls.Add(rootLayout);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 620);
            Name = "ItemsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "دليل الأصناف";
            Load += ItemsForm_Load;
            rootLayout.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            dataLayout.ResumeLayout(false);
            dataLayout.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelGridHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
        }

        private ComboBox cmbUnit;
    }
}