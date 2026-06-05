using static System.Net.Mime.MediaTypeNames;

namespace Kakeibo2App.Pages
{
    partial class EditTransactionForm
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

        private Button btnSave;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
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

            btnSave = new Button();

            ((System.ComponentModel.ISupportInitialize)
                numAmount).BeginInit();

            SuspendLayout();

            lblTitle.Text = "タイトル";
            lblTitle.Location =
                new Point(20, 20);

            txtTitle.Location =
                new Point(20, 45);

            txtTitle.Size =
                new Size(250, 27);

            lblCategory.Text =
                "カテゴリ";

            lblCategory.Location =
                new Point(20, 90);

            cmbCategory.Location =
                new Point(20, 115);

            cmbCategory.Size =
                new Size(250, 28);

            lblAmount.Text =
                "金額";

            lblAmount.Location =
                new Point(20, 160);

            numAmount.Location =
                new Point(20, 185);

            numAmount.Maximum =
                999999999;

            lblMemo.Text =
                "メモ";

            lblMemo.Location =
                new Point(20, 230);

            txtMemo.Location =
                new Point(20, 255);

            txtMemo.Size =
                new Size(350, 27);

            lblDate.Text =
                "日付";

            lblDate.Location =
                new Point(20, 300);

            dtpDate.Location =
                new Point(20, 325);

            btnSave.Text =
                "保存";

            btnSave.Location =
                new Point(20, 380);

            btnSave.Size =
                new Size(120, 35);

            btnSave.Click +=
                BtnSave_Click;

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

            Controls.Add(btnSave);

            ClientSize =
                new Size(450, 460);

            Text =
                "取引編集";

            ((System.ComponentModel.ISupportInitialize)
                numAmount).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}