using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastMileAPP
{
    internal class DatabaseCon
    {
        private static string connString =
        "Host=ep-holy-bar-a2bpx2sc-pooler.eu-central-1.aws.neon.tech;" +
        "Port=5432;" +
        "Username=neondb_owner;" +
        "Password=npg_aYC4yHnQIjV1;" +
        "Database=neondb;" +
        "SSL Mode=Require;";

        public static bool CheckLogin(string username, string password)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT 1 FROM users WHERE username=@u AND password=@p LIMIT 1";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("u", username);
                    cmd.Parameters.AddWithValue("p", password);
                    var result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }

        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(connString);
            conn.Open();
            return conn;
        }

        public static DataTable RunQuery(string sql)
        {
            using (var conn = GetConnection())
            using (var da = new NpgsqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

}


