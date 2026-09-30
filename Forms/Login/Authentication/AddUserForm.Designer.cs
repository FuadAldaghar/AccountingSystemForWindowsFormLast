using static System.Net.Mime.MediaTypeNames;

namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;

        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.CheckBox chkIsActive;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblTitle = new Label();
            lblUserName = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblRole = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            cmbRole = new ComboBox();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(34, 139, 94);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(573, 93);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(573, 93);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة مستخدم جديد";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            lblUserName.Location = new Point(35, 124);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(120, 18);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "اسم المستخدم:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(56, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 18);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "كلمة المرور:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(17, 246);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 18);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "تأكيد كلمة المرور:";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            lblRole.Location = new Point(102, 303);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(46, 18);
            lblRole.TabIndex = 7;
            lblRole.Text = "الدور:";
            // 
            // txtUserName
            // 
            txtUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtUserName.Location = new Point(169, 121);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(331, 30);
            txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new Point(169, 173);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(331, 30);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(169, 239);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(331, 30);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(169, 295);
            cmbRole.Margin = new Padding(3, 4, 3, 4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(331, 31);
            cmbRole.TabIndex = 8;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            chkIsActive.Location = new Point(40, 393);
            chkIsActive.Margin = new Padding(3, 4, 3, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(131, 22);
            chkIsActive.TabIndex = 9;
            chkIsActive.Text = "مستخدم نشط";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(34, 139, 94);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(309, 520);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(223, 56);
            btnSave.TabIndex = 11;
            btnSave.Text = "حفظ المستخدم";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(40, 520);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(223, 56);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Font = new System.Drawing.Font("Tahoma", 9F, FontStyle.Bold);
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Location = new Point(40, 440);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(491, 60);
            lblMessage.TabIndex = 10;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(573, 637);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblMessage);
            Controls.Add(chkIsActive);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblUserName);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUserForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "إضافة مستخدم جديد";
            Load += AddUserForm_Load;
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}