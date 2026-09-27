using System;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Forms;

namespace AccountingSystemForWindowsFormLast
{
    public partial class frm_Main : Form
    {
        private readonly Panel contentPanel;

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

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Name = "contentPanel"
            };

            Controls.Add(contentPanel);
            pnlHeader.BringToFront();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void OpenForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(form);

            form.Show();
            form.BringToFront();
        }

        private void accountTreeMenuItem_Click(object sender, EventArgs e)
        {
            if (accountsForm == null || accountsForm.IsDisposed)
            {
                accountsForm = new AccountsForm();
                OpenForm(accountsForm);
            }
            else
            {
                accountsForm.BringToFront();
            }
        }

        private void قيوداليوميهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (journalEntriesForm == null || journalEntriesForm.IsDisposed)
            {
                journalEntriesForm = new JournalEntries();
                OpenForm(journalEntriesForm);
            }
            else
            {
                journalEntriesForm.BringToFront();
            }
        }

        private void itemsMenuItem_Click(object sender, EventArgs e)
        {
            itemsForm = new ItemsForm();
            OpenForm(itemsForm);
        }

        private void purchaseInvoiceMenuItem_Click(object sender, EventArgs e)
        {
            purchaseInvoiceForm = new PurchaseInvoice();
            OpenForm(purchaseInvoiceForm);
        }

        private void salesInvoiceMenuItem_Click(object sender, EventArgs e)
        {
            salesInvoiceForm = new SalesInvoice();
            OpenForm(salesInvoiceForm);
        }

        private void stockReportMenuItem_Click(object sender, EventArgs e)
        {
            stockReportForm = new StockReport();
            OpenForm(stockReportForm);
        }

        private void accountStatementMenuItem_Click(object sender, EventArgs e)
        {
            accountStatementForm = new AccountStatement();
            OpenForm(accountStatementForm);
        }

        private void receiptVoucherMenuItem_Click(object sender, EventArgs e)
        {
            receiptVoucherForm = new ReceiptVoucher();
            OpenForm(receiptVoucherForm);
        }

        private void paymentVoucherMenuItem_Click(object sender, EventArgs e)
        {
            purchaseInvoiceForm = new PurchaseInvoice();
            OpenForm(purchaseInvoiceForm);
        }
    }
}