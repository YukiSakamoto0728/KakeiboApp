using Kakeibo2App.Models;
using Kakeibo2App.Services;

namespace Kakeibo2App.Pages
{
    public partial class IncomePage : UserControl
    {
        private readonly DatabaseService _databaseService;

        private List<Transaction> _transactions =
            new();

        private int _currentPage = 1;

        private const int PageSize = 10;

        public event Action? DataChanged;

        public IncomePage()
        {
            InitializeComponent();

            _databaseService =
                new DatabaseService();

            InitializeCategory();

            InitializeGrid();

            LoadData();

            btnAdd.Click += BtnAdd_Click;

            btnPrevPage.Click += BtnPrevPage_Click;
            btnNextPage.Click += BtnNextPage_Click;

            dgvIncome.CellDoubleClick +=
                DgvIncome_CellDoubleClick;

            dgvIncome.CellContentClick +=
                DgvIncome_CellContentClick;
        }

        private void InitializeCategory()
        {
            cmbCategory.Items.Add("給料");
            cmbCategory.Items.Add("副収入");
            cmbCategory.Items.Add("その他");

            cmbCategory.SelectedIndex = 0;
        }

        private void InitializeGrid()
        {
            dgvIncome.Columns.Clear();

            dgvIncome.Columns.Add(
                "Id",
                "ID");

            dgvIncome.Columns["Id"].Visible =
                false;

            dgvIncome.Columns.Add(
                "Title",
                "タイトル");

            dgvIncome.Columns.Add(
                "Category",
                "カテゴリ");

            dgvIncome.Columns.Add(
                "Amount",
                "金額");

            dgvIncome.Columns.Add(
                "Date",
                "日付");

            var deleteColumn =
                new DataGridViewButtonColumn();

            deleteColumn.Name =
                "Delete";

            deleteColumn.HeaderText =
                "";

            deleteColumn.Text =
                "削除";

            deleteColumn.UseColumnTextForButtonValue =
                true;

            dgvIncome.Columns.Add(
                deleteColumn);
        }

        private void BtnAdd_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtTitle.Text))
            {
                MessageBox.Show(
                    "タイトルを入力してください");

                return;
            }

            var transaction =
                new Transaction
                {
                    Type = "Income",
                    Title = txtTitle.Text,
                    Category = cmbCategory.Text,
                    Amount = (int)numAmount.Value,
                    Memo = txtMemo.Text,
                    Date = dtpDate.Value,
                    CreatedAt = DateTime.Now
                };

            _databaseService
                .AddTransaction(
                    transaction);

            txtTitle.Clear();
            txtMemo.Clear();

            numAmount.Value = 0;

            LoadData();
        }

        private void LoadData()
        {
            _transactions =
                _databaseService
                .GetTransactions()
                .Where(x =>
                    x.Type == "Income")
                .ToList();

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvIncome.Rows.Clear();

            var pageItems =
                _transactions
                .Skip((_currentPage - 1)
                      * PageSize)
                .Take(PageSize)
                .ToList();

            foreach (var item in pageItems)
            {
                dgvIncome.Rows.Add(
                    item.Id,
                    item.Title,
                    item.Category,
                    item.Amount.ToString("N0"),
                    item.Date.ToString(
                        "yyyy/MM/dd"));
            }

            int totalPages =
                Math.Max(
                    1,
                    (int)Math.Ceiling(
                        _transactions.Count /
                        (double)PageSize));

            lblPage.Text =
                $"{_currentPage} / {totalPages}";
        }

        private void BtnPrevPage_Click(
            object? sender,
            EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;

                RefreshGrid();
            }
        }

        private void BtnNextPage_Click(
            object? sender,
            EventArgs e)
        {
            int totalPages =
                Math.Max(
                    1,
                    (int)Math.Ceiling(
                        _transactions.Count /
                        (double)PageSize));

            if (_currentPage < totalPages)
            {
                _currentPage++;

                RefreshGrid();
            }
        }

        private void DgvIncome_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var pageItems =
                _transactions
                .Skip((_currentPage - 1)
                      * PageSize)
                .Take(PageSize)
                .ToList();

            var transaction =
                pageItems[e.RowIndex];

            using var form =
                new EditTransactionForm(
                    transaction);

            if (form.ShowDialog()
                == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DgvIncome_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvIncome.Columns[e.ColumnIndex]
                .Name != "Delete")
                return;

            var pageItems =
                _transactions
                .Skip((_currentPage - 1)
                      * PageSize)
                .Take(PageSize)
                .ToList();

            var transaction =
                pageItems[e.RowIndex];

            var result =
                MessageBox.Show(
                    "削除しますか？",
                    "確認",
                    MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            _databaseService
                .DeleteTransaction(
                    transaction.Id);

            LoadData();
        }
    }
}