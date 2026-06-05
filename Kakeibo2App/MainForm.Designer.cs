namespace Kakeibo2App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelMenu;
        private Panel panelContainer;

        private Button btnMenu;
        private Button btnHome;
        private Button btnIncome;
        private Button btnExpense;

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
            panelMenu = new Panel();
            panelContainer = new Panel();

            btnMenu = new Button();
            btnHome = new Button();
            btnIncome = new Button();
            btnExpense = new Button();

            panelMenu.SuspendLayout();

            SuspendLayout();

            //
            // panelMenu
            //
            panelMenu.BackColor =
                Color.FromArgb(
                    45,
                    45,
                    48);

            panelMenu.Dock =
                DockStyle.Left;

            panelMenu.Width = 220;

            //
            // btnMenu
            //
            btnMenu.Text = "☰";

            btnMenu.Font =
                new Font(
                    "Yu Gothic UI",
                    16F,
                    FontStyle.Bold);

            btnMenu.Location =
                new Point(10, 10);

            btnMenu.Size =
                new Size(40, 40);

            //
            // btnHome
            //
            btnHome.Text = "ホーム";

            btnHome.Location =
                new Point(0, 80);

            btnHome.Size =
                new Size(220, 50);

            btnHome.FlatStyle =
                FlatStyle.Flat;

            btnHome.ForeColor =
                Color.White;

            //
            // btnIncome
            //
            btnIncome.Text = "収入一覧";

            btnIncome.Location =
                new Point(0, 130);

            btnIncome.Size =
                new Size(220, 50);

            btnIncome.FlatStyle =
                FlatStyle.Flat;

            btnIncome.ForeColor =
                Color.White;

            //
            // btnExpense
            //
            btnExpense.Text = "支出一覧";

            btnExpense.Location =
                new Point(0, 180);

            btnExpense.Size =
                new Size(220, 50);

            btnExpense.FlatStyle =
                FlatStyle.Flat;

            btnExpense.ForeColor =
                Color.White;

            //
            // panelContainer
            //
            panelContainer.Dock =
                DockStyle.Fill;

            panelContainer.BackColor =
                Color.WhiteSmoke;

            //
            // panelMenu Controls
            //
            panelMenu.Controls.Add(btnMenu);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Controls.Add(btnIncome);
            panelMenu.Controls.Add(btnExpense);

            //
            // MainForm
            //
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1600, 900);

            Controls.Add(panelContainer);
            Controls.Add(panelMenu);

            Name = "MainForm";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text = "Kakeibo2App";

            WindowState =
                FormWindowState.Maximized;

            panelMenu.ResumeLayout(false);

            ResumeLayout(false);
        }
    }
}