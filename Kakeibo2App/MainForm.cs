using Kakeibo2App.Pages;

namespace Kakeibo2App
{
    public partial class MainForm : Form
    {
        private bool _menuExpanded = true;
        private HomePage? _homePage;
        public MainForm()
        {
            InitializeComponent();

            ShowHomePage();

            btnMenu.Click += BtnMenu_Click;
            btnHome.Click += BtnHome_Click;
            btnIncome.Click += BtnIncome_Click;
            btnExpense.Click += BtnExpense_Click;
        }

        private void BtnMenu_Click(
            object? sender,
            EventArgs e)
        {
            if (_menuExpanded)
            {
                panelMenu.Width = 60;

                btnHome.Text = "";
                btnIncome.Text = "";
                btnExpense.Text = "";

                _menuExpanded = false;
            }
            else
            {
                panelMenu.Width = 220;

                btnHome.Text = "ホーム";
                btnIncome.Text = "収入一覧";
                btnExpense.Text = "支出一覧";

                _menuExpanded = true;
            }
        }

        private void BtnHome_Click(
            object? sender,
            EventArgs e)
        {
            ShowHomePage();
        }

        private void BtnIncome_Click(
            object? sender,
            EventArgs e)
        {
            ShowPage(
                new IncomePage());
        }

        private void BtnExpense_Click(
            object? sender,
            EventArgs e)
        {
            ShowPage(
                new ExpensePage());
        }

        private void ShowHomePage()
        {
            if (_homePage == null)
            {
                _homePage =
                    new HomePage();
            }

            _homePage.RefreshDashboard();

            _homePage.Dock =
                DockStyle.Fill;

            panelContainer.Controls.Clear();

            panelContainer.Controls.Add(
                _homePage);
        }

        private void ShowPage(
            UserControl page)
        {
            page.Dock =
                DockStyle.Fill;

            panelContainer.Controls.Clear();

            panelContainer.Controls.Add(page);
        }
    }
}