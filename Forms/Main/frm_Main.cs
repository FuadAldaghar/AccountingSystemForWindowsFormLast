using System;
using System.Drawing;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Forms;
using AccountingSystemForWindowsFormLast.Forms.Authentication;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Helpers.users;
using AccountingSystemForWindowsFormLast.Services;
namespace AccountingSystemForWindowsFormLast
{
    public partial class frm_Main : Form
    {// الحسابات
        private AccountsForm accountsForm;
        private JournalEntries journalEntriesForm;
        private ItemsForm itemsForm;
        private PurchaseInvoice purchaseInvoiceForm;
        private SalesInvoice salesInvoiceForm;
        private AccountStatement accountStatementForm;
        private StockReport stockReportForm;
        private ReceiptVoucher receiptVoucherForm;
        private PaymentVoucher paymentVoucherForm;
        private PurchasesList purchasesListForm;
        private SalesList salesListForm;
        private PaymentsList paymentsListForm;
        private ReceiptsList receiptsListForm;

        public frm_Main()
        {
            InitializeComponent();

            // contentPanel يتم إنشاؤه داخل Designer وترتيبه مع Dock بشكل صحيح.
            // لذلك لا نضيفه هنا حتى لا يتغير ترتيب الـ Dock.
            // contentPanel.SendToBack();
            // mainMenuStrip.BringToFront();
            // pnlHeader.BringToFront();
            //contentPanel.BringToFront();
            InitializeMenuIcons();
            //  ApplyPermissions();
            UiTheme.Apply(this);


        }

        private void InitializeMenuIcons()
        {
            systemMenu.Image = CreateMenuIcon(MenuIconType.Book);
            accountTreeMenuItem.Image = CreateMenuIcon(MenuIconType.Accounts);
            itemsMenuItem.Image = CreateMenuIcon(MenuIconType.Items);
            usersMenuItem.Image = CreateMenuIcon(MenuIconType.Users);

            vouchersMenu.Image = CreateMenuIcon(MenuIconType.Money);
            receiptVoucherMenuItem.Image = CreateMenuIcon(MenuIconType.Receipt);
            paymentVoucherMenuItem.Image = CreateMenuIcon(MenuIconType.Payment);

            invoicesMenu.Image = CreateMenuIcon(MenuIconType.Invoice);
            purchaseInvoiceMenuItem.Image = CreateMenuIcon(MenuIconType.Purchase);
            salesInvoiceMenuItem.Image = CreateMenuIcon(MenuIconType.Sales);

            reportsMenu.Image = CreateMenuIcon(MenuIconType.Report);
            stockReportMenuItem.Image = CreateMenuIcon(MenuIconType.Stock);
            accountStatementMenuItem.Image = CreateMenuIcon(MenuIconType.Statement);
            قيوداليوميهToolStripMenuItem.Image = CreateMenuIcon(MenuIconType.Report);
        }

        //اعدادات قاعدة البيانات
        //private DatabaseSettingsForm databaseSettingsForm;
        //ربط قاعدة البيانات
        private void connectionMenuItem_Click_1(object sender, EventArgs e)
        {
            //  OpenDatabaseSettingsForm();
        }
        //private void connectionMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}

       
        //private void backupMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}
      
        //private void restoreMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}

        //private void OpenDatabaseSettingsForm()
        //{
        //    if (databaseSettingsForm == null || databaseSettingsForm.IsDisposed)
        //        databaseSettingsForm = new DatabaseSettingsForm();

        //    databaseSettingsForm.ShowDialog(this);
        //}
        //----------------------------------------------------نهاية اعداد قاعدة البيانات


        private void frm_Main_Load(object sender, EventArgs e)
        {
            // Keep the content area responsive to the main window size.
            //mainMenuStrip.BringToFront();
            // pnlHeader.BringToFront();
        }
        // =========================================================
        // الصلاحيات
        // =========================================================
        private void ApplyPermissions()
        {
            bool canAccounts = CurrentUser.HasPermission("Accounts");
            bool canItems = CurrentUser.HasPermission("Items");

            bool canReceipt = CurrentUser.HasPermission("Receipt");
            bool canPayment = CurrentUser.HasPermission("Payment");

            bool canPurchase = CurrentUser.HasPermission("Purchase");
            bool canSales = CurrentUser.HasPermission("Sales");

            bool canReports = CurrentUser.HasPermission("Reports");
            bool canJournal = CurrentUser.HasPermission("Journal");

            bool canSettings = CurrentUser.HasPermission("Settings");
            bool canUsers = CurrentUser.HasPermission("Users");


            // =========================
            // دليل الحسابات والأصناف
            // =========================

            accountTreeMenuItem.Visible = canAccounts;
            itemsMenuItem.Visible = canItems;

            usersMenuItem.Visible = canUsers;

            systemMenu.Visible =
                canAccounts || canItems || canUsers;


            // =========================
            // السندات
            // =========================

            receiptVoucherMenuItem.Visible = canReceipt;
            paymentVoucherMenuItem.Visible = canPayment;

            vouchersMenu.Visible =
                canReceipt || canPayment;


            // =========================
            // الفواتير
            // =========================

            purchaseInvoiceMenuItem.Visible = canPurchase;
            salesInvoiceMenuItem.Visible = canSales;

            invoicesMenu.Visible =
                canPurchase || canSales;


            // =========================
            // التقارير
            // =========================

            stockReportMenuItem.Visible = canReports;
            accountStatementMenuItem.Visible = canReports;
            قيوداليوميهToolStripMenuItem.Visible = canJournal;

            reportsMenu.Visible =
                canReports || canJournal;


            // =========================
            // إعدادات قاعدة البيانات
            // =========================

            databaseMenu.Visible = canSettings;
        }
        //private void ApplyPermissions()
        //{
        //    // =========================
        //    // دليل الحسابات والأصناف
        //    // =========================

        //    accountTreeMenuItem.Visible =
        //        CurrentUser.HasPermission("Accounts");

        //    itemsMenuItem.Visible =
        //        CurrentUser.HasPermission("Items");

        //    systemMenu.Visible =
        //        accountTreeMenuItem.Visible ||
        //        itemsMenuItem.Visible;


        //    // =========================
        //    // السندات
        //    // =========================

        //    receiptVoucherMenuItem.Visible =
        //        CurrentUser.HasPermission("Receipt");

        //    paymentVoucherMenuItem.Visible =
        //        CurrentUser.HasPermission("Payment");

        //    vouchersMenu.Visible =
        //        receiptVoucherMenuItem.Visible ||
        //        paymentVoucherMenuItem.Visible;


        //    // =========================
        //    // الفواتير
        //    // =========================

        //    purchaseInvoiceMenuItem.Visible =
        //        CurrentUser.HasPermission("Purchase");

        //    salesInvoiceMenuItem.Visible =
        //        CurrentUser.HasPermission("Sales");

        //    invoicesMenu.Visible =
        //        purchaseInvoiceMenuItem.Visible ||
        //        salesInvoiceMenuItem.Visible;


        //    // =========================
        //    // التقارير
        //    // =========================

        //    stockReportMenuItem.Visible =
        //        CurrentUser.HasPermission("Reports");

        //    accountStatementMenuItem.Visible =
        //        CurrentUser.HasPermission("Reports");

        //    قيوداليوميهToolStripMenuItem.Visible =
        //        CurrentUser.HasPermission("Journal");

        //    reportsMenu.Visible =
        //        stockReportMenuItem.Visible ||
        //        accountStatementMenuItem.Visible ||
        //        قيوداليوميهToolStripMenuItem.Visible;


        //    // =========================
        //    // إعدادات النظام
        //    // =========================

        //    databaseMenu.Visible =
        //        CurrentUser.HasPermission("Settings");


        //    MessageBox.Show(
        //    "Accounts Permission = " + CurrentUser.HasPermission("Accounts") + "\n" +
        //    "Account Item Visible = " + accountTreeMenuItem.Visible + "\n" +
        //    "Items Permission = " + CurrentUser.HasPermission("Items") + "\n" +
        //    "Items Item Visible = " + itemsMenuItem.Visible + "\n\n" +
        //    "System Menu Visible = " + systemMenu.Visible,
        //    "DEBUG",
        //    MessageBoxButtons.OK,
        //    MessageBoxIcon.Information);
        //}
        //فتح الواجهات الفرعية داخل الفورم الرئيسي
        private void OpenForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Margin = Padding.Empty;

            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(form);

            form.Show();
            form.BringToFront();
        }


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //عمل نسخ احطياطي
        private async void backupMenuItem_Click_1(object sender, EventArgs e)
        {

            var service = new DatabaseBackupService();
            string defaultFileName = service.GetDefaultBackupFileName();

            using SaveFileDialog dlg = new SaveFileDialog
            {
                Title = "حفظ النسخة الاحتياطية",
                Filter = "ملف نسخة احتياطية (*.bak)|*.bak",
                FileName = defaultFileName,
                DefaultExt = "bak",
                OverwritePrompt = true
            };

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            string backupPath = dlg.FileName;

            Cursor = Cursors.WaitCursor;
            backupMenuItem.Enabled = false;
            restoreMenuItem.Enabled = false;

            try
            {
                await Task.Run(() => service.Backup(backupPath));

                MessageBox.Show(
                    $"تم حفظ النسخة الاحتياطية بنجاح:\n{backupPath}",
                    "نسخ احتياطي",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء النسخ الاحتياطي:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                backupMenuItem.Enabled = true;
                restoreMenuItem.Enabled = true;
            }

            // OpenDatabaseSettingsForm();
        }

        //استعادة قاعدة البيانات
        private  async void restoreMenuItem_Click_1(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog
            {
                Title = "اختر ملف النسخة الاحتياطية للاستعادة",
                Filter = "ملف نسخة احتياطية (*.bak)|*.bak",
                DefaultExt = "bak",
                CheckFileExists = true
            };

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            string backupPath = dlg.FileName;

            DialogResult confirm = MessageBox.Show(
                $"سيتم استعادة قاعدة البيانات من الملف التالي وستُفقد جميع البيانات الحالية:\n{backupPath}\n\nهل أنت متأكد؟",
                "تأكيد الاستعادة",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            backupMenuItem.Enabled = false;
            restoreMenuItem.Enabled = false;

            try
            {
                await Task.Run(() => new DatabaseBackupService().Restore(backupPath));

                MessageBox.Show(
                    "تمت استعادة قاعدة البيانات بنجاح.\nسيتم إغلاق البرنامج لتطبيق التغييرات.",
                    "استعادة ناجحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Close the application so the next launch picks up the restored DB.
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"حدث خطأ أثناء الاستعادة:\n{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                backupMenuItem.Enabled = true;
                restoreMenuItem.Enabled = true;
            }

            //  OpenDatabaseSettingsForm();
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void accountTreeMenuItem_Click(object sender, EventArgs e)
        {
            if (accountsForm == null || accountsForm.IsDisposed)
                accountsForm = new AccountsForm();

            OpenForm(accountsForm);
        }

        private void قيوداليوميهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (journalEntriesForm == null || journalEntriesForm.IsDisposed)
                journalEntriesForm = new JournalEntries();

            OpenForm(journalEntriesForm);
        }

        private void itemsMenuItem_Click(object sender, EventArgs e)
        {
            if (itemsForm == null || itemsForm.IsDisposed)
                itemsForm = new ItemsForm();

            OpenForm(itemsForm);
        }

        private void purchaseInvoiceMenuItem_Click(object sender, EventArgs e)
        {
            if (purchaseInvoiceForm == null || purchaseInvoiceForm.IsDisposed)
                purchaseInvoiceForm = new PurchaseInvoice();

            OpenForm(purchaseInvoiceForm);
        }

        private void salesInvoiceMenuItem_Click(object sender, EventArgs e)
        {
            if (salesInvoiceForm == null || salesInvoiceForm.IsDisposed)
                salesInvoiceForm = new SalesInvoice();

            OpenForm(salesInvoiceForm);
        }


        private void stockReportMenuItem_Click(object sender, EventArgs e)
        {
            if (stockReportForm == null || stockReportForm.IsDisposed)
                stockReportForm = new StockReport();

            OpenForm(stockReportForm);
        }

        private void accountStatementMenuItem_Click(object sender, EventArgs e)
        {
            if (accountStatementForm == null || accountStatementForm.IsDisposed)
                accountStatementForm = new AccountStatement();

            OpenForm(accountStatementForm);
        }

        private void receiptVoucherMenuItem_Click(object sender, EventArgs e)
        {
            if (receiptVoucherForm == null || receiptVoucherForm.IsDisposed)
                receiptVoucherForm = new ReceiptVoucher();

            OpenForm(receiptVoucherForm);
        }

        private void paymentVoucherMenuItem_Click(object sender, EventArgs e)
        {
            if (paymentVoucherForm == null || paymentVoucherForm.IsDisposed)
                paymentVoucherForm = new PaymentVoucher();

            OpenForm(paymentVoucherForm);
        }

        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    ApplyPermissions();
                }
            }

        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "هل تريد تسجيل الخروج؟",
     "تسجيل الخروج",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            CurrentUser.Logout();

            Hide();

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    ApplyPermissions();
                    Show();
                }
                else
                {
                    Close();
                }
            }

        }

        private void changePasswordMenuItem_Click(object sender, EventArgs e)
        {

            using (ChangePasswordForm form = new ChangePasswordForm())
            {
                form.ShowDialog(this);
            }
        }

        private void usersMenuItem_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.HasPermission("Users"))
            {
                MessageBox.Show(
                    "ليس لديك صلاحية للوصول إلى إدارة المستخدمين.",
                    "صلاحية غير متاحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (AddUserForm form = new AddUserForm())
            {
                form.ShowDialog(this);
            }
        }
        /// <summary>
        /// /////////////////////////////////////////
        /// </summary>


        private void purchaseRegisterMenuItem_Click(object sender, EventArgs e)
        {
            if (purchasesListForm == null || purchasesListForm.IsDisposed)
                purchasesListForm = new PurchasesList();

            OpenForm(purchasesListForm);
        }

        private void salesRegisterMenuItem_Click(object sender, EventArgs e)
        {
            if (salesListForm == null || salesListForm.IsDisposed)
                salesListForm = new SalesList();

            OpenForm(salesListForm);
        }

        private void receiptRegisterMenuItem_Click(object sender, EventArgs e)
        {
            if (receiptsListForm == null || receiptsListForm.IsDisposed)
                receiptsListForm = new ReceiptsList();

            OpenForm(receiptsListForm);
        }

        private void paymentRegisterMenuItem_Click(object sender, EventArgs e)
        {

            if (paymentsListForm == null || paymentsListForm.IsDisposed)
                paymentsListForm = new PaymentsList();

            OpenForm(paymentsListForm);
       

        }
    }
}
