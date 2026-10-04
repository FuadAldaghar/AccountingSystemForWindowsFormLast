

namespace AccountingSystemForWindowsFormLast.Forms
{
    partial class SendSmsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private TableLayoutPanel rootLayout;

        private Label lblAccountName;
        private TextBox txtAccountName;

        private Label lblBalance;
        private TextBox txtBalance;

        private Label lblDebit;
        private TextBox txtDebit;

        private Label lblCredit;
        private TextBox txtCredit;

        private Label lblDirectionTitle;
        private Label lblDirection;

        private Label lblPhone;
        private TextBox txtPhone;

        private Label lblMessage;
        private TextBox txtMessage;

        private FlowLayoutPanel buttonPanel;
        private Button btnSend;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            rootLayout = new TableLayoutPanel();
            lblAccountName = new Label();
            txtAccountName = new TextBox();
            lblBalance = new Label();
            txtBalance = new TextBox();
            lblDebit = new Label();
            txtDebit = new TextBox();
            lblCredit = new Label();
            txtCredit = new TextBox();
            lblDirectionTitle = new Label();
            lblDirection = new Label();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            buttonPanel = new FlowLayoutPanel();
            btnSend = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            rootLayout.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(64, 64, 0);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(18, 10, 18, 8);
            panelHeader.Size = new Size(650, 78);
            panelHeader.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.FromArgb(64, 64, 0);
            lblSubtitle.Dock = DockStyle.Fill;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(225, 240, 232);
            lblSubtitle.Location = new Point(18, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(614, 26);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "إرسال رصيد الحساب للعميل وتسجيل العملية في سجل الرسائل";
            lblSubtitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(64, 64, 0);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(614, 34);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "إرسال رسالة SMS";
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rootLayout
            // 
            rootLayout.BackColor = Color.FromArgb(246, 248, 247);
            rootLayout.ColumnCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(lblBalance, 0, 1);
            rootLayout.Controls.Add(lblDebit, 0, 2);
            rootLayout.Controls.Add(txtDebit, 1, 2);
            rootLayout.Controls.Add(lblCredit, 0, 3);
            rootLayout.Controls.Add(lblDirectionTitle, 0, 4);
            rootLayout.Controls.Add(lblDirection, 1, 4);
            rootLayout.Controls.Add(lblPhone, 0, 5);
            rootLayout.Controls.Add(txtPhone, 1, 5);
            rootLayout.Controls.Add(lblMessage, 0, 6);
            rootLayout.Controls.Add(txtMessage, 1, 6);
            rootLayout.Controls.Add(buttonPanel, 0, 7);
            rootLayout.Controls.Add(txtAccountName, 1, 0);
            rootLayout.Controls.Add(txtCredit, 1, 3);
            rootLayout.Controls.Add(txtBalance, 1, 1);
            rootLayout.Controls.Add(lblAccountName, 0, 0);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 78);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(16);
            rootLayout.RowCount = 8;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            rootLayout.Size = new Size(650, 601);
            rootLayout.TabIndex = 0;
            // 
            // lblAccountName
            // 
            lblAccountName.Location = new Point(531, 16);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(100, 23);
            lblAccountName.TabIndex = 0;
            lblAccountName.Text = "الحساب:";
            // 
            // txtAccountName
            // 
            txtAccountName.Location = new Point(321, 19);
            txtAccountName.Multiline = true;
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new Size(185, 36);
            txtAccountName.TabIndex = 1;
            // 
            // lblBalance
            // 
            lblBalance.Location = new Point(531, 58);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(100, 23);
            lblBalance.TabIndex = 2;
            lblBalance.Text = "الرصيد:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(321, 61);
            txtBalance.Multiline = true;
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(185, 36);
            txtBalance.TabIndex = 3;
            // 
            // lblDebit
            // 
            lblDebit.Location = new Point(531, 100);
            lblDebit.Name = "lblDebit";
            lblDebit.Size = new Size(100, 23);
            lblDebit.TabIndex = 4;
            lblDebit.Text = "عليك:";
            // 
            // txtDebit
            // 
            txtDebit.Location = new Point(321, 103);
            txtDebit.Multiline = true;
            txtDebit.Name = "txtDebit";
            txtDebit.Size = new Size(185, 36);
            txtDebit.TabIndex = 5;
            // 
            // lblCredit
            // 
            lblCredit.Location = new Point(531, 142);
            lblCredit.Name = "lblCredit";
            lblCredit.Size = new Size(100, 23);
            lblCredit.TabIndex = 6;
            lblCredit.Text = "لك:";
            // 
            // txtCredit
            // 
            txtCredit.Location = new Point(321, 145);
            txtCredit.Multiline = true;
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(185, 36);
            txtCredit.TabIndex = 7;
            // 
            // lblDirectionTitle
            // 
            lblDirectionTitle.Location = new Point(531, 184);
            lblDirectionTitle.Name = "lblDirectionTitle";
            lblDirectionTitle.Size = new Size(100, 33);
            lblDirectionTitle.TabIndex = 8;
            // 
            // lblDirection
            // 
            lblDirection.Dock = DockStyle.Fill;
            lblDirection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDirection.ForeColor = Color.FromArgb(105, 118, 112);
            lblDirection.Location = new Point(19, 184);
            lblDirection.Name = "lblDirection";
            lblDirection.Padding = new Padding(8, 0, 8, 0);
            lblDirection.Size = new Size(487, 42);
            lblDirection.TabIndex = 9;
            lblDirection.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(531, 226);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Dock = DockStyle.Fill;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(22, 232);
            txtPhone.Margin = new Padding(6);
            txtPhone.MaxLength = 30;
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "مثال: 777123456";
            txtPhone.RightToLeft = RightToLeft.No;
            txtPhone.Size = new Size(481, 36);
            txtPhone.TabIndex = 11;
            // 
            // lblMessage
            // 
            lblMessage.Location = new Point(531, 274);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(100, 23);
            lblMessage.TabIndex = 12;
            // 
            // txtMessage
            // 
            txtMessage.AcceptsReturn = true;
            txtMessage.BackColor = Color.White;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;
            txtMessage.Dock = DockStyle.Fill;
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.ForeColor = Color.FromArgb(45, 55, 50);
            txtMessage.Location = new Point(22, 280);
            txtMessage.Margin = new Padding(6);
            txtMessage.MaxLength = 2000;
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(481, 241);
            txtMessage.TabIndex = 13;
            // 
            // buttonPanel
            // 
            rootLayout.SetColumnSpan(buttonPanel, 2);
            buttonPanel.Controls.Add(btnSend);
            buttonPanel.Controls.Add(btnCancel);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonPanel.Location = new Point(19, 530);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(0, 6, 0, 0);
            buttonPanel.Size = new Size(612, 52);
            buttonPanel.TabIndex = 14;
            buttonPanel.WrapContents = false;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(46, 125, 50);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(6, 12);
            btnSend.Margin = new Padding(6);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(130, 38);
            btnSend.TabIndex = 0;
            btnSend.Text = "إرسال SMS";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += BtnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(24, 78, 58);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(24, 78, 58);
            btnCancel.Location = new Point(148, 12);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // SendSmsForm
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 247);
            CancelButton = btnCancel;
            ClientSize = new Size(650, 679);
            Controls.Add(rootLayout);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SendSmsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إرسال رسالة SMS";
            panelHeader.ResumeLayout(false);
            rootLayout.ResumeLayout(false);
            rootLayout.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureLabel(Label label, string text)
        {
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(45, 55, 50);
            label.Padding = new Padding(4, 0, 4, 0);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleRight;
        }

        private static void ConfigureReadOnlyTextBox(TextBox textBox)
        {
            textBox.BackColor = Color.FromArgb(238, 244, 241);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Dock = DockStyle.Fill;
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.ForeColor = Color.FromArgb(45, 55, 50);
            textBox.Margin = new Padding(6);
            textBox.ReadOnly = true;
            textBox.TextAlign = HorizontalAlignment.Right;
        }
    }
}
