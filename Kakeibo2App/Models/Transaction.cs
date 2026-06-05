namespace Kakeibo2App.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Type { get; set; } = "";

        public string Title { get; set; } = "";

        public string Category { get; set; } = "";

        public int Amount { get; set; }

        public string Memo { get; set; } = "";

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}