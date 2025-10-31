using System;
using System.Data;
using Npgsql;

namespace LastMileAPP
{
    internal static class DatabaseCon
    {
        // ✅ Move your Neon connection string here (same as before)
        private static readonly string connString =
            "Host=ep-holy-bar-a2bpx2sc-pooler.eu-central-1.aws.neon.tech;" +
            "Port=5432;" +
            "Username=neondb_owner;" +
            "Password=npg_aYC4yHnQIjV1;" +
            "Database=neondb;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true;";  // avoids cert mismatch on some Neon setups

        // ✅ LOGIN CHECK
        public static bool CheckLogin(string username, string password)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            const string sql = "SELECT 1 FROM users WHERE username=@u AND password=@p LIMIT 1";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("u", username);
            cmd.Parameters.AddWithValue("p", password);

            return cmd.ExecuteScalar() != null;
        }

        // ✅ GENERIC OPEN CONNECTION
        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        // ✅ GENERIC QUERY → DataTable
        public static DataTable RunQuery(string sql)
        {
            using var conn = GetConnection();
            using var da = new NpgsqlDataAdapter(sql, conn);

            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ✅ CATEGORY QUERY for your TreeView
        public static DataTable GetCategories()
        {
            const string sql = @"
                SELECT DISTINCT hlavna_kategoria, nazov_tabulky
                FROM produkty p
                LEFT JOIN produkt_class pc ON p.id = pc.produkt_id
                LEFT JOIN class c ON pc.class_id = c.id
                WHERE hlavna_kategoria IS NOT NULL
                ORDER BY hlavna_kategoria, nazov_tabulky;
            ";

            return RunQuery(sql);
        }
    }
}
