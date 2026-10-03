
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
            mainPanel.Size = new Size(576, 670);
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
            btnExit.BackColor = Color.FromArgb(192, 0, 0);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(303, 540);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(240, 52);
            btnExit.TabIndex = 3;
            btnExit.Text = "خروج";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(64, 64, 0);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(51, 540);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(251, 52);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "تسجيل الدخول";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 12F);
            chkShowPassword.ForeColor = Color.FromArgb(80, 80, 80);
            chkShowPassword.Location = new Point(51, 492);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(176, 32);
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
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(491, 46);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "admin";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(40, 40, 40);
            lblPassword.Location = new Point(440, 384);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(105, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "كلمة المرور:";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(250, 252, 251);
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Font = new Font("Segoe UI", 12F);
            txtUserName.Location = new Point(51, 307);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Multiline = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(491, 47);
            txtUserName.TabIndex = 0;
            txtUserName.Text = "admin";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(40, 40, 40);
            lblUserName.Location = new Point(418, 278);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(130, 25);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "اسم المستخدم:";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(0, 64, 0);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(51, 40);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(474, 200);
            headerPanel.TabIndex = 7;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Bottom;
            lblSubtitle.Font = new Font("Segoe UI", 14F);
            lblSubtitle.ForeColor = Color.FromArgb(0, 64, 0);
            lblSubtitle.Location = new Point(0, 140);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(474, 60);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "تسجيل الدخول إلى النظام";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 64, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(474, 87);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "اهلا بك في نظام ادارة   المبيعات والمشتريات";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 250, 247);
            ClientSize = new Size(576, 670);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل الدخول";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

