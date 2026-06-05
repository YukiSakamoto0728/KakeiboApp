using Kakeibo2App.Models;
using Kakeibo2App.Services;

namespace Kakeibo2App.Pages
{
    public partial class EditTransactionForm : Form
    {
        private readonly DatabaseService _databaseService;

        private readonly Transaction _transaction;

        public EditTransactionForm(
            Transaction transaction)
        {
            InitializeComponent();

            _databaseService =
                new DatabaseService();

            _transaction =
                transaction;

            InitializeCategory();

            LoadData();
        }

        private void InitializeCategory()
        {
            cmbCategory.Items.Clear();

            if (_transaction.Type == "Income")
            {
                cmbCategory.Items.Add("給料");
                cmbCategory.Items.Add("副収入");
                cmbCategory.Items.Add("その他");
            }
            else
            {
                cmbCategory.Items.Add("食費");
                cmbCategory.Items.Add("交通費");
                cmbCategory.Items.Add("娯楽");
                cmbCategory.Items.Add("交際費");
                cmbCategory.Items.Add("経費");
                cmbCategory.Items.Add("生活費");
                cmbCategory.Items.Add("その他");
            }
        }

        private void LoadData()
        {
            txtTitle.Text =
                _transaction.Title;

            cmbCategory.Text =
                _transaction.Category;

            numAmount.Value =
                _transaction.Amount;

            txtMemo.Text =
                _transaction.Memo;

            dtpDate.Value =
                _transaction.Date;
        }

        private void BtnSave_Click(
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

            _transaction.Title =
                txtTitle.Text;

            _transaction.Category =
                cmbCategory.Text;

            _transaction.Amount =
                (int)numAmount.Value;

            _transaction.Memo =
                txtMemo.Text;

            _transaction.Date =
                dtpDate.Value;

            _databaseService
                .UpdateTransaction(
                    _transaction);

            DialogResult =
                DialogResult.OK;

            Close();
        }
    }
}