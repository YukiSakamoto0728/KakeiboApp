namespace Kakeibo2App.Pages
{
    partial class IncomePage
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;

        private Label lblCategory;
        private ComboBox cmbCategory;

        private Label lblAmount;
        private NumericUpDown numAmount;

        private Label lblMemo;
        private TextBox txtMemo;

        private Label lblDate;
        private DateTimePicker dtpDate;

        private Button btnAdd;

        private DataGridView dgvIncome;

        private Button btnPrevPage;
        private Button btnNextPage;
        private Label lblPage;

        protected override void Dispose(bool disposing)
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
            lblTitle = new Label();
            txtTitle = new TextBox();

            lblCategory = new Label();
            cmbCategory = new ComboBox();

            lblAmount = new Label();
            numAmount = new NumericUpDown();

            lblMemo = new Label();
            txtMemo = new TextBox();

            lblDate = new Label();
            dtpDate = new DateTimePicker();

            btnAdd = new Button();

            dgvIncome = new DataGridView();

            btnPrevPage = new Button();
            btnNextPage = new Button();
            lblPage = new Label();

            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIncome).BeginInit();

            SuspendLayout();

            //
            // タイトル
            //
            lblTitle.Text = "タイトル";
            lblTitle.Location = new Point(20, 20);

            txtTitle.Location = new Point(20, 45);
            txtTitle.Size = new Size(180, 27);

            //
            // カテゴリ
            //
            lblCategory.Text = "カテゴリ";
            lblCategory.Location = new Point(220, 20);

            cmbCategory.Location = new Point(220, 45);
            cmbCategory.Size = new Size(150, 28);

            //
            // 金額
            //
            lblAmount.Text = "金額";
            lblAmount.Location = new Point(390, 20);

            numAmount.Location = new Point(390, 45);
            numAmount.Maximum = 999999999;

            //
            // メモ
            //
            lblMemo.Text = "メモ";
            lblMemo.Location = new Point(560, 20);

            txtMemo.Location = new Point(560, 45);
            txtMemo.Size = new Size(250, 27);

            //
            // 日付
            //
            lblDate.Text = "日付";
            lblDate.Location = new Point(830, 20);

            dtpDate.Location = new Point(830, 45);
            dtpDate.Size = new Size(200, 27);

            //
            // 登録ボタン
            //
            btnAdd.Text = "追加";
            btnAdd.Location = new Point(1060, 40);
            btnAdd.Size = new Size(120, 35);

            //
            // DataGridView
            //
            dgvIncome.Location = new Point(20, 110);
            dgvIncome.Size = new Size(1200, 600);

            dgvIncome.AllowUserToAddRows = false;
            dgvIncome.ReadOnly = true;
            dgvIncome.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvIncome.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            //
            // ページング
            //
            btnPrevPage.Text = "前へ";
            btnPrevPage.Location = new Point(900, 730);

            lblPage.Text = "1 / 1";
            lblPage.AutoSize = true;
            lblPage.Location = new Point(1020, 738);

            btnNextPage.Text = "次へ";
            btnNextPage.Location = new Point(1080, 730);

            //
            // IncomePage
            //
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);

            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);

            Controls.Add(lblAmount);
            Controls.Add(numAmount);

            Controls.Add(lblMemo);
            Controls.Add(txtMemo);

            Controls.Add(lblDate);
            Controls.Add(dtpDate);

            Controls.Add(btnAdd);

            Controls.Add(dgvIncome);

            Controls.Add(btnPrevPage);
            Controls.Add(lblPage);
            Controls.Add(btnNextPage);

            Name = "IncomePage";
            Size = new Size(1400, 900);

            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIncome).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}