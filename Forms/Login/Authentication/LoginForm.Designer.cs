
using System.Drawing;
using System.Windows.Forms;
namespace AccountingSystemForWindowsFormLast.Forms.Authentication
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUserName;
        private Label lblPassword;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            lblMessage = new Label();
            btnExit = new Button();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUserName = new TextBox();
            lblUserName = new Label();
            headerPanel = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(lblMessage);
            mainPanel.Controls.Add(btnExit);
            mainPanel.Controls.Add(btnLogin);
            mainPanel.Controls.Add(chkShowPassword);
            mainPanel.Controls.Add(txtPassword);
            mainPanel.Controls.Add(lblPassword);
            mainPanel.Controls.Add(txtUserName);
            mainPanel.Controls.Add(lblUserName);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(51, 40, 51, 40);
            mainPanel.Size = new Size(594, 827);
            mainPanel.TabIndex = 0;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMessage.ForeColor = Color.FromArgb(190, 50, 50);
            lblMessage.Location = new Point(51, 627);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(491, 60);
            lblMessage.TabIndex = 0;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(235, 235, 235);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(60, 60, 60);
            btnExit.Location = new Point(303, 540);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(240, 64);
            btnExit.TabIndex = 3;
            btnExit.Text = "خروج";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(22, 130, 83);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(51, 540);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(240, 64);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "تسجيل الدخول";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9.5F);
            chkShowPassword.ForeColor = Color.FromArgb(80, 80, 80);
            chkShowPassword.Location = new Point(51, 467);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(145, 25);
            chkShowPassword.TabIndex = 4;
            chkShowPassword.Text = "إظهار كلمة المرور";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(250, 252, 251);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(51, 413);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(491, 34);
            txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(40, 40, 40);
            lblPassword.Location = new Point(440, 384);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "كلمة المرور";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(250, 252, 251);
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(51, 307);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(491, 34);
            txtUserName.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(40, 40, 40);
            lblUserName.Location = new Point(418, 278);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(125, 25);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "اسم المستخدم";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(22, 130, 83);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(51, 40);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(492, 200);
            headerPanel.TabIndex = 7;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Bottom;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(225, 255, 240);
            lblSubtitle.Location = new Point(0, 140);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(492, 60);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "تسجيل الدخول إلى النظام";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(492, 87);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "نظام المحاسبة";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 250, 247);
            ClientSize = new Size(594, 827);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل الدخول - نظام المحاسبة";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

