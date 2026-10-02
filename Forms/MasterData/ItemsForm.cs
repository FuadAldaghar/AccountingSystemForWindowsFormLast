using System;
using System.Data;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Helpers;
using AccountingSystemForWindowsFormLast.Services;
using AccountingSystemForWindowsFormLast.Models;

namespace AccountingSystemForWindowsFormLast.Forms
{
    public partial class ItemsForm : Form
    {
        private readonly ItemService _itemService;
        private int selectedItemId = 0;

        public ItemsForm()
        {
            InitializeComponent();

            UiTheme.Apply(this);
            UiTheme.StyleButton(btnAdd, Accent.Primary);
            UiTheme.StyleButton(btnEdit, Accent.Warning);
            UiTheme.StyleButton(btnDelete, Accent.Danger);
            UiTheme.StyleButton(btnNew, Accent.Neutral);

            _itemService = new ItemService();

            btnNew.Click += btnNew_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            txtItemNumber.ReadOnly = true;

            dgvItems.CellClick += dgvItems_CellClick;

            txtItemName.TextChanged += InputFields_TextChanged;
            cmbUnit.SelectedIndexChanged += InputFields_TextChanged;

            UpdateButtonsState();
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            LoadItems();
            GenerateItemNumber();
            UpdateButtonsState();
        }

        // =========================
        // تحميل الأصناف
        // =========================
        private void LoadItems()
        {
            try
            {
                DataTable table = _itemService.GetDataTable();
                dgvItems.DataSource = table;

                if (dgvItems.Columns.Count > 0)
                {
                    if (dgvItems.Columns["ItemId"] != null)
                        dgvItems.Columns["ItemId"].Visible = false;

                    if (dgvItems.Columns["ItemNumber"] != null)
                    {
                        dgvItems.Columns["ItemNumber"].HeaderText = "رقم الصنف";
                        dgvItems.Columns["ItemNumber"].FillWeight = 25;
                    }

                    if (dgvItems.Columns["ItemName"] != null)
                    {
                        dgvItems.Columns["ItemName"].HeaderText = "اسم الصنف";
                        dgvItems.Columns["ItemName"].FillWeight = 50;
                    }

                    if (dgvItems.Columns["Unit"] != null)
                    {
                        dgvItems.Columns["Unit"].HeaderText = "الوحدة";
                        dgvItems.Columns["Unit"].FillWeight = 25;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تحميل الأصناف:\n{ex.Message}", "خطأ");
            }
        }

        // =========================
        // توليد رقم صنف جديد
        // =========================
        private void GenerateItemNumber()
        {
            try
            {
                txtItemNumber.Text = _itemService.GetNextItemNumber();
            }
            catch
            {
                txtItemNumber.Text = "1";
            }
        }

        private void InputFields_TextChanged(object? sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool fieldsFilled =
                !string.IsNullOrWhiteSpace(txtItemName.Text) &&
                cmbUnit.SelectedIndex >= 0;

            bool itemSelected = selectedItemId > 0;

            btnAdd.Enabled = fieldsFilled && !itemSelected;
            btnEdit.Enabled = fieldsFilled && itemSelected;
            btnDelete.Enabled = itemSelected;
        }

        private void dgvItems_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvItems.Rows[e.RowIndex];

            if (row.Cells["ItemId"].Value == null)
                return;

            selectedItemId = Convert.ToInt32(row.Cells["ItemId"].Value);
            txtItemNumber.Text = row.Cells["ItemNumber"].Value?.ToString() ?? "";
            txtItemName.Text = row.Cells["ItemName"].Value?.ToString() ?? "";

            string unit = row.Cells["Unit"].Value?.ToString() ?? "";
            int unitIndex = cmbUnit.Items.IndexOf(unit);

            if (unitIndex >= 0)
            {
                cmbUnit.SelectedIndex = unitIndex;
            }
            else
            {
                cmbUnit.Text = unit;
            }

            UpdateButtonsState();
        }

        private void btnNew_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        // =========================
        // إضافة صنف
        // =========================
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageHelper.ShowWarning("يرجى إدخال اسم الصنف.", "تنبيه");
                txtItemName.Focus();
                return;
            }

            if (cmbUnit.SelectedIndex < 0 && string.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                MessageHelper.ShowWarning("يرجى اختيار الوحدة.", "تنبيه");
                cmbUnit.Focus();
                return;
            }

            try
            {
                Item item = new Item
                {
                    ItemNumber = txtItemNumber.Text.Trim(),
                    ItemName = txtItemName.Text.Trim(),
                    Unit = cmbUnit.Text.Trim()
                };

                _itemService.Add(item);

                MessageHelper.ShowInfo("تمت إضافة الصنف بنجاح.", "نجاح");

                LoadItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء إضافة الصنف:\n{ex.Message}", "خطأ");
            }
        }

        // =========================
        // تعديل صنف
        // =========================
        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (selectedItemId <= 0)
            {
                MessageHelper.ShowWarning("يرجى تحديد صنف للتعديل.", "تنبيه");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageHelper.ShowWarning("يرجى إدخال اسم الصنف.", "تنبيه");
                txtItemName.Focus();
                return;
            }

            if (cmbUnit.SelectedIndex < 0 && string.IsNullOrWhiteSpace(cmbUnit.Text))
            {
                MessageHelper.ShowWarning("يرجى اختيار الوحدة.", "تنبيه");
                cmbUnit.Focus();
                return;
            }

            try
            {
                Item item = new Item
                {
                    ItemId = selectedItemId,
                    ItemNumber = txtItemNumber.Text.Trim(),
                    ItemName = txtItemName.Text.Trim(),
                    Unit = cmbUnit.Text.Trim()
                };

                _itemService.Update(item);

                MessageHelper.ShowInfo("تم تعديل بيانات الصنف بنجاح.", "نجاح");

                LoadItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء تعديل الصنف:\n{ex.Message}", "خطأ");
            }
        }

        // =========================
        // حذف صنف
        // =========================
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedItemId <= 0)
            {
                MessageHelper.ShowWarning("يرجى تحديد صنف للحذف.", "تنبيه");
                return;
            }

            if (!MessageHelper.Confirm("هل أنت متأكد من حذف هذا الصنف؟", "تأكيد الحذف"))
                return;

            try
            {
                _itemService.Delete(selectedItemId);

                MessageHelper.ShowInfo("تم حذف الصنف بنجاح.", "نجاح");

                LoadItems();
                ClearFields();
            }
            catch (InvalidOperationException ex)
            {
                MessageHelper.ShowWarning(ex.Message, "لا يمكن الحذف");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"حدث خطأ أثناء حذف الصنف:\n{ex.Message}", "خطأ");
            }
        }

        private void ClearFields()
        {
            selectedItemId = 0;
            txtItemName.Clear();
            cmbUnit.SelectedIndex = -1;
            cmbUnit.Text = "";

            GenerateItemNumber();
            UpdateButtonsState();
            txtItemName.Focus();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}