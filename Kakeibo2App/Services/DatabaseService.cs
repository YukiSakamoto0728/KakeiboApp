using System.Data.SQLite;
using Kakeibo2App.Models;

namespace Kakeibo2App.Services
{
    public class DatabaseService
    {
        private const string ConnectionString =
            "Data Source=kakeibo2.db";

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
            @"
            CREATE TABLE IF NOT EXISTS Transactions
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,

                Type TEXT NOT NULL,

                Title TEXT NOT NULL,

                Category TEXT NOT NULL,

                Amount INTEGER NOT NULL,

                Memo TEXT,

                Date TEXT NOT NULL,

                CreatedAt TEXT NOT NULL
            );
            ";

            using var command =
                new SQLiteCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        public void AddTransaction(
            Transaction transaction)
        {
            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
            @"
            INSERT INTO Transactions
            (
                Type,
                Title,
                Category,
                Amount,
                Memo,
                Date,
                CreatedAt
            )
            VALUES
            (
                @Type,
                @Title,
                @Category,
                @Amount,
                @Memo,
                @Date,
                @CreatedAt
            );
            ";

            using var command =
                new SQLiteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Type",
                transaction.Type);

            command.Parameters.AddWithValue(
                "@Title",
                transaction.Title);

            command.Parameters.AddWithValue(
                "@Category",
                transaction.Category);

            command.Parameters.AddWithValue(
                "@Amount",
                transaction.Amount);

            command.Parameters.AddWithValue(
                "@Memo",
                transaction.Memo);

            command.Parameters.AddWithValue(
                "@Date",
                transaction.Date);

            command.Parameters.AddWithValue(
                "@CreatedAt",
                transaction.CreatedAt);

            command.ExecuteNonQuery();
        }

        public List<Transaction> GetTransactions()
        {
            var list =
                new List<Transaction>();

            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
                "SELECT * FROM Transactions ORDER BY Date DESC";

            using var command =
                new SQLiteCommand(sql, connection);

            using var reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Transaction
                {
                    Id =
                        Convert.ToInt32(
                            reader["Id"]),

                    Type =
                        reader["Type"]
                        .ToString()!,

                    Title =
                        reader["Title"]
                        .ToString()!,

                    Category =
                        reader["Category"]
                        .ToString()!,

                    Amount =
                        Convert.ToInt32(
                            reader["Amount"]),

                    Memo =
                        reader["Memo"]
                        .ToString()!,

                    Date =
                        DateTime.Parse(
                            reader["Date"]
                            .ToString()!),

                    CreatedAt =
                        DateTime.Parse(
                            reader["CreatedAt"]
                            .ToString()!)
                });
            }

            return list;
        }

        public void DeleteTransaction(
            int id)
        {
            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
                "DELETE FROM Transactions WHERE Id=@Id";

            using var command =
                new SQLiteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Id",
                id);

            command.ExecuteNonQuery();
        }

        public void UpdateTransaction(
            Transaction transaction)
        {
            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
            @"
            UPDATE Transactions
            SET
                Title=@Title,
                Category=@Category,
                Amount=@Amount,
                Memo=@Memo,
                Date=@Date
            WHERE
                Id=@Id
            ";

            using var command =
                new SQLiteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Id",
                transaction.Id);

            command.Parameters.AddWithValue(
                "@Title",
                transaction.Title);

            command.Parameters.AddWithValue(
                "@Category",
                transaction.Category);

            command.Parameters.AddWithValue(
                "@Amount",
                transaction.Amount);

            command.Parameters.AddWithValue(
                "@Memo",
                transaction.Memo);

            command.Parameters.AddWithValue(
                "@Date",
                transaction.Date);

            command.ExecuteNonQuery();
        }

        public Transaction? GetTransactionById(
    int id)
        {
            using var connection =
                new SQLiteConnection(ConnectionString);

            connection.Open();

            string sql =
                "SELECT * FROM Transactions WHERE Id=@Id";

            using var command =
                new SQLiteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@Id",
                id);

            using var reader =
                command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Transaction
            {
                Id =
                    Convert.ToInt32(
                        reader["Id"]),

                Type =
                    reader["Type"]
                    .ToString()!,

                Title =
                    reader["Title"]
                    .ToString()!,

                Category =
                    reader["Category"]
                    .ToString()!,

                Amount =
                    Convert.ToInt32(
                        reader["Amount"]),

                Memo =
                    reader["Memo"]
                    .ToString()!,

                Date =
                    DateTime.Parse(
                        reader["Date"]
                        .ToString()!),

                CreatedAt =
                    DateTime.Parse(
                        reader["CreatedAt"]
                        .ToString()!)
            };
        }
    }
}