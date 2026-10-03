
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Models;
using AccountingSystemForWindowsFormLast.Services;


namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class SalesInvoice : Form
    {
        private readonly InvoiceService _invoiceService;
        private readonly AccountService _accountService;
        private readonly ItemService _itemService;
        private List<AccountItem> _accounts = new List<AccountItem>();
        private int selectedRowIndex = -1;

        public SalesInvoice()
        {
            InitializeComponent();

            UiTheme.Apply(this);
            UiTheme.StyleButton(btnSave, Accent.Primary);
            UiTheme.StyleButton(btnNew, Accent.Neutral);
            UiTheme.StyleButton(btnAddRow, Accent.Primary);
            UiTheme.StyleButton(btnRemoveRow, Accent.Danger);

            _invoiceService = new InvoiceService();
            _accountService = new AccountService();
            _itemService = new ItemService();

            cmbItem.SelectedIndexChanged += cmbItem_SelectedIndexChanged;
            cmbPaymentType.SelectedIndexChanged += cmbPaymentType_SelectedIndexChanged;
            nudQuantity.ValueChanged += CalculateLineTotal;
            nudUnitPrice.ValueChanged += CalculateLineTotal;

            btnAddRow.Click += btnAddRow_Click;
            btnRemoveRow.Click += btnRemoveRow_Click;
            btnNew.Click += btnNew_Click;
            btnSave.Click += btnSave_Click;

            dgvDetails.CellClick += dgvDetails_CellClick;
        }

        private void SalesInvoice_Load(object? sender, EventArgs e)
        {
            PrepareGrid();

            if (cmbPaymentType.Items.Count > 0)
                cmbPaymentType.SelectedIndex = 0;

            LoadAccounts();
            LoadItems();

            NewInvoice();
        }

        private void PrepareGrid()
        {
            dgvDetails.Columns.Clear();

            dgvDetails.Columns.Add("ItemId", "ItemId");
            dgvDetails.Columns.Add("ItemName", "الصنف");
            dgvDetails.Columns.Add("Unit", "الوحدة");
            dgvDetails.Columns.Add("Quantity", "الكمية");
            dgvDetails.Columns.Add("UnitPrice", "سعر الوحدة");
            dgvDetails.Columns.Add("Total", "الإجمالي");
            dgvDetails.Columns["ItemId"].Visible = false;

            dgvDetails.Columns["ItemName"].FillWeight = 35;
            dgvDetails.Columns["Unit"].FillWeight = 15;
            dgvDetails.Columns["Quantity"].FillWeight = 15;
            dgvDetails.Columns["UnitPrice"].FillWeight = 17;
            dgvDetails.Columns["Total"].FillWeight = 18;
        }

        private void LoadAccounts()
        {
            try
            {
                List<AccountItem> accounts = _accountService.GetLeafAccounts();
                _accounts = accounts;

                cmbAccount.DataSource = null;
                cmbAccount.DisplayMember = "DisplayText";
                cmbAccount.ValueMember = "AccountId";
                cmbAccount.DataSource = accounts;
                cmbAccount.SelectedIndex = -1;

                ApplyDefaultAccount();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل الحسابات:\n{ex.Message}", "خطأ");
            }
        }

        private void cmbPaymentType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyDefaultAccount();
        }

        private void ApplyDefaultAccount()
        {
            if (_accounts.Count == 0 || cmbPaymentType.SelectedIndex < 0)
                return;

            string accountNumber = cmbPaymentType.Text.Trim() == InvoiceService.CashPaymentType
                ? InvoiceService.CashAccountNumber
                : InvoiceService.CustomersAccountNumber;

            int index = _accounts.FindIndex(x => x.AccountNumber == accountNumber);
            cmbAccount.SelectedIndex = index;
        }

        private void LoadItems()
        {
            try
            {
                List<Item> items = _itemService.GetAll();

                cmbItem.DataSource = null;
                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemId";
                cmbItem.DataSource = items;
                cmbItem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل الأصناف:\n{ex.Message}", "خطأ");
            }
        }

        private void cmbItem_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is Item item)
            {
                txtUnit.Text = item.Unit;
            }
            else
            {
                txtUnit.Text = "";
            }

            CalculateLineTotal(sender, e);
        }

        private void CalculateLineTotal(object? sender, EventArgs e)
        {
            decimal total = nudQuantity.Value * nudUnitPrice.Value;
            txtLineTotal.Text = total.ToString("N2");
        }

        private void btnAddRow_Click(object? sender, EventArgs e)
        {
            if (cmbItem.SelectedItem is not Item item)
            {
                MessageHelper.ShowWarning("اختر صنفاً أولاً.", "تنبيه");
                cmbItem.Focus();
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageHelper.ShowWarning("الكمية يجب أن تكون أكبر من صفر.", "تنبيه");
                nudQuantity.Focus();
                return;
            }

            if (nudUnitPrice.Value < 0)
            {
                MessageHelper.ShowWarning("سعر الوحدة لا يمكن أن يكون سالباً.", "تنبيه");
                nudUnitPrice.Focus();
                return;
            }

            decimal availableStock = _invoiceService.GetAvailableStock(item.ItemId);
            decimal existingQtyInGrid = 0;

            foreach (DataGridViewRow r in dgvDetails.Rows)
            {
                if (r.IsNewRow) continue;
                if (r.Cells["ItemId"].Value != null &&
                    Convert.ToInt32(r.Cells["ItemId"].Value) == item.ItemId)
                {
                    existingQtyInGrid += Convert.ToDecimal(r.Cells["Quantity"].Value);
                }
            }

            if ((existingQtyInGrid + nudQuantity.Value) > availableStock)
            {
                MessageHelper.ShowWarning(
                    $"الكمية المطلوبة غير متوفرة في المخزون.\n" +
                    $"المتاح حالياً: {availableStock:N2}\n" +
                    $"المطلوب: {(existingQtyInGrid + nudQuantity.Value):N2}",
                    "تنبيه المخزون");
                return;
            }

            decimal total = nudQuantity.Value * nudUnitPrice.Value;

            dgvDetails.Rows.Add(
                item.ItemId,
                item.ItemName,
                item.Unit,
                nudQuantity.Value.ToString("N2"),
                nudUnitPrice.Value.ToString("N2"),
                total.ToString("N2"));

            CalculateInvoiceTotal();
            ClearDetailFields();
        }

        private void btnRemoveRow_Click(object? sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dgvDetails.Rows.Count)
            {
                MessageHelper.ShowWarning("اختر سطراً لحذفه.", "تنبيه");
                return;
            }

            dgvDetails.Rows.RemoveAt(selectedRowIndex);
            selectedRowIndex = -1;
            CalculateInvoiceTotal();
        }

        private void dgvDetails_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedRowIndex = e.RowIndex;
        }

        private void CalculateInvoiceTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (decimal.TryParse(row.Cells["Total"].Value?.ToString(), out decimal lineTotal))
                {
                    total += lineTotal;
                }
            }

            lblTotalAmount.Text = total.ToString("N2");
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInvoice())
                return;

            object? selectedAccount = cmbAccount.SelectedValue;
            int accountId = selectedAccount == null || selectedAccount == DBNull.Value
                ? 0
                : Convert.ToInt32(selectedAccount);
            string paymentType = cmbPaymentType.Text.Trim();
            string invoiceNumber = txtInvoiceNumber.Text.Trim();
            DateTime invoiceDate = dtpInvoiceDate.Value.Date;

            List<InvoiceItem> items = new List<InvoiceItem>();
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                if (row.IsNewRow)
                    continue;

                items.Add(new InvoiceItem
                {
                    ItemId = Convert.ToInt32(row.Cells["ItemId"].Value),
                    ItemName = row.Cells["ItemName"].Value?.ToString() ?? "",
                    Unit = row.Cells["Unit"].Value?.ToString() ?? "",
                    Quantity = Convert.ToDecimal(row.Cells["Quantity"].Value),
                    UnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value)
                });
            }

            try
            {
                _invoiceService.SaveSalesInvoice(
                    invoiceNumber,
                    invoiceDate,
                    paymentType,
                    accountId,
                    items);

                MessageHelper.ShowInfo("تم حفظ فاتورة المبيعات وترحيل القيود المحاسبية بنجاح.", "نجاح");
                NewInvoice();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء حفظ فاتورة المبيعات:\n{ex.Message}", "خطأ");
            }
        }

        private bool ValidateInvoice()
        {
            if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
            {
                MessageHelper.ShowWarning("رقم الفاتورة مطلوب.", "تنبيه");
                return false;
            }

            if (cmbPaymentType.SelectedIndex < 0)
            {
                MessageHelper.ShowWarning("يرجى اختيار نوع الدفع: نقد أو أجل.", "تنبيه");
                cmbPaymentType.Focus();
                return false;
            }

            if (cmbPaymentType.Text.Trim() != InvoiceService.CashPaymentType &&
                (cmbAccount.SelectedIndex < 0 || cmbAccount.SelectedValue == null))
            {
                MessageHelper.ShowWarning("يرجى اختيار حساب العميل في حالة البيع الآجل.", "تنبيه");
                cmbAccount.Focus();
                return false;
            }

            if (dgvDetails.Rows.Count == 0 || (dgvDetails.Rows.Count == 1 && dgvDetails.Rows[0].IsNewRow))
            {
                MessageHelper.ShowWarning("يجب إضافة صنف واحد على الأقل.", "تنبيه");
                return false;
            }

            return true;
        }

        private void btnNew_Click(object? sender, EventArgs e)
        {
            NewInvoice();
        }

        private void NewInvoice()
        {
            try
            {
                txtInvoiceNumber.Text = _invoiceService.GetNextSalesInvoiceNumber();
            }
            catch
            {
                txtInvoiceNumber.Text = "1";
            }

            dtpInvoiceDate.Value = DateTime.Today;

            cmbAccount.SelectedIndex = -1;

            if (cmbPaymentType.Items.Count > 0)
                cmbPaymentType.SelectedIndex = 0;

            ApplyDefaultAccount();

            ClearDetailFields();

            dgvDetails.Rows.Clear();
            selectedRowIndex = -1;

            CalculateInvoiceTotal();
        }

        private void ClearDetailFields()
        {
            cmbItem.SelectedIndex = -1;
            txtUnit.Clear();
            nudQuantity.Value = 1;
            nudUnitPrice.Value = 0;
            txtLineTotal.Text = "0.00";
        }
    }
}