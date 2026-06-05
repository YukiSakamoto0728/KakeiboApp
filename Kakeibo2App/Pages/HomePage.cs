using Kakeibo2App.Models;
using Kakeibo2App.Services;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace Kakeibo2App.Pages
{
    public partial class HomePage : UserControl
    {
        private readonly DatabaseService _databaseService;

        public HomePage()
        {
            InitializeComponent();

            _databaseService =
                new DatabaseService();

            RefreshDashboard();
        }

        public void RefreshDashboard()
        {
            var transactions =
                _databaseService
                .GetTransactions();

            int incomeTotal =
                transactions
                .Where(x => x.Type == "Income")
                .Sum(x => x.Amount);

            int expenseTotal =
                transactions
                .Where(x => x.Type == "Expense")
                .Sum(x => x.Amount);

            lblIncomeTotal.Text =
                $"収入合計 : ¥{incomeTotal:N0}";

            lblExpenseTotal.Text =
                $"支出合計 : ¥{expenseTotal:N0}";

            DrawIncomeChart(transactions);

            DrawExpenseChart(transactions);
        }

        private void DrawIncomeChart(
            List<Transaction> transactions)
        {
            pnlIncomeChart.Controls.Clear();

            var incomeData =
                transactions
                .Where(x => x.Type == "Income")
                .GroupBy(x => x.Category)
                .Select(x => new
                {
                    Category = x.Key,
                    Amount = x.Sum(y => y.Amount)
                })
                .ToList();

            var chart =
                new CartesianChart
                {
                    Dock = DockStyle.Fill,

                    Series =
                    new ISeries[]
                    {
                        new ColumnSeries<int>
                        {
                            Values =
                                incomeData
                                .Select(x => x.Amount)
                                .ToArray()
                        }
                    },

                    XAxes =
                    new Axis[]
                    {
                        new Axis
                        {
                            Labels =
                                incomeData
                                .Select(x => x.Category)
                                .ToArray()
                        }
                    }
                };

            pnlIncomeChart.Controls.Add(chart);
        }

        private void DrawExpenseChart(
            List<Transaction> transactions)
        {
            pnlExpenseChart.Controls.Clear();

            var expenseData =
                transactions
                .Where(x => x.Type == "Expense")
                .GroupBy(x => x.Category)
                .Select(x => new
                {
                    Category = x.Key,
                    Amount = x.Sum(y => y.Amount)
                })
                .ToList();

            var chart =new PieChart
                {
                    Dock = DockStyle.Fill,

                    Series = expenseData.Select(x => new PieSeries<int>
                    {
                        Values = new[] { x.Amount },

                        Name = x.Category
                })
                    .ToArray()
        };

            pnlExpenseChart.Controls.Add(chart);
        }
    }
}