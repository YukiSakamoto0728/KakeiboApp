namespace Kakeibo2App.Pages
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblIncomeTotal;
        private Label lblExpenseTotal;

        private Panel pnlIncomeChart;
        private Panel pnlExpenseChart;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblIncomeTotal = new Label();
            lblExpenseTotal = new Label();

            pnlIncomeChart = new Panel();
            pnlExpenseChart = new Panel();

            SuspendLayout();

            //
            // lblIncomeTotal
            //
            lblIncomeTotal.AutoSize = true;

            lblIncomeTotal.Font =
                new Font(
                    "Yu Gothic UI",
                    20F,
                    FontStyle.Bold);

            lblIncomeTotal.Location =
                new Point(50, 30);

            lblIncomeTotal.Text =
                "収入合計 : ¥0";

            //
            // lblExpenseTotal
            //
            lblExpenseTotal.AutoSize = true;

            lblExpenseTotal.Font =
                new Font(
                    "Yu Gothic UI",
                    20F,
                    FontStyle.Bold);

            lblExpenseTotal.Location =
                new Point(50, 90);

            lblExpenseTotal.Text =
                "支出合計 : ¥0";

            //
            // pnlIncomeChart
            //
            pnlIncomeChart.BorderStyle =
                BorderStyle.FixedSingle;

            pnlIncomeChart.Location =
                new Point(50, 180);

            pnlIncomeChart.Size =
                new Size(500, 400);

            //
            // pnlExpenseChart
            //
            pnlExpenseChart.BorderStyle =
                BorderStyle.FixedSingle;

            pnlExpenseChart.Location =
                new Point(650, 180);

            pnlExpenseChart.Size =
                new Size(500, 400);

            //
            // HomePage
            //
            Controls.Add(lblIncomeTotal);
            Controls.Add(lblExpenseTotal);

            Controls.Add(pnlIncomeChart);
            Controls.Add(pnlExpenseChart);

            BackColor = Color.White;

            Name = "HomePage";

            Size = new Size(1400, 900);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}