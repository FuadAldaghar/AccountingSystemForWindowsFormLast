using System;
using System.Drawing;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Forms;

namespace AccountingSystemForWindowsFormLast
{
    public partial class frm_Main : Form
    {
        private AccountsForm accountsForm;
        private JournalEntries journalEntriesForm;
        private ItemsForm itemsForm;

        private PurchaseInvoice purchaseInvoiceForm;
        private SalesInvoice salesInvoiceForm;
        private AccountStatement accountStatementForm;

        private StockReport stockReportForm;
        private ReceiptVoucher receiptVoucherForm;
        private PaymentVoucher paymentVoucherForm;

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
        }

        private void InitializeMenuIcons()
        {
            systemMenu.Image = CreateMenuIcon(MenuIconType.Book);
            accountTreeMenuItem.Image = CreateMenuIcon(MenuIconType.Accounts);
            itemsMenuItem.Image = CreateMenuIcon(MenuIconType.Items);

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
        private DatabaseSettingsForm databaseSettingsForm;
        //ربط قاعدة البيانات
        private void connectionMenuItem_Click_1(object sender, EventArgs e)
        {
          //  OpenDatabaseSettingsForm();
        }
        //private void connectionMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}

        private void backupMenuItem_Click_1(object sender, EventArgs e)
        {
           // OpenDatabaseSettingsForm();
        }
        //private void backupMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}
        private void restoreMenuItem_Click_1(object sender, EventArgs e)
        {
          //  OpenDatabaseSettingsForm();
        }
        //private void restoreMenuItem_Click(object? sender, EventArgs e)
        //{
        //    OpenDatabaseSettingsForm();
        //}

        private void OpenDatabaseSettingsForm()
        {
            if (databaseSettingsForm == null || databaseSettingsForm.IsDisposed)
                databaseSettingsForm = new DatabaseSettingsForm();

            databaseSettingsForm.ShowDialog(this);
        }
        //----------------------------------------------------نهاية اعداد قاعدة البيانات


        private void frm_Main_Load(object sender, EventArgs e)
        {
            // Keep the content area responsive to the main window size.
            //mainMenuStrip.BringToFront();
            // pnlHeader.BringToFront();
        }

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

     
    }
}
