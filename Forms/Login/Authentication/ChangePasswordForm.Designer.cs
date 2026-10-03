using static System.Net.Mime.MediaTypeNames;

namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
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
            lblCurrentPassword = new Label();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnChangePassword = new Button();
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
            headerPanel.Size = new Size(553, 93);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(553, 93);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "تغيير كلمة المرور";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCurrentPassword.Location = new Point(48, 140);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(146, 23);
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "كلمة المرور الحالية:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNewPassword.Location = new Point(40, 200);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(154, 23);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "كلمة المرور الجديدة:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(40, 253);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(135, 23);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "تأكيد كلمة المرور:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtCurrentPassword.Location = new Point(218, 137);
            txtCurrentPassword.Margin = new Padding(3, 4, 3, 4);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '●';
            txtCurrentPassword.Size = new Size(319, 30);
            txtCurrentPassword.TabIndex = 2;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNewPassword.Location = new Point(218, 193);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(319, 30);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(218, 246);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(319, 30);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(0, 64, 0);
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(286, 420);
            btnChangePassword.Margin = new Padding(3, 4, 3, 4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(223, 56);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "تغيير كلمة المرور";
            btnChangePassword.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(192, 0, 0);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Transparent;
            btnCancel.Location = new Point(57, 420);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(223, 56);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.ForeColor = Color.Firebrick;
            lblMessage.Location = new Point(40, 340);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(469, 60);
            lblMessage.TabIndex = 7;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(553, 553);
            Controls.Add(btnCancel);
            Controls.Add(btnChangePassword);
            Controls.Add(lblMessage);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تغيير كلمة المرور";
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}