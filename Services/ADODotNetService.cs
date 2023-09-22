using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CSharpTraining.Services
{
    public class ADODotNetService
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public ADODotNetService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }
        public string GetConnection() { return _sqlConnectionStringBuilder.ConnectionString; }


        public int Execute(string query)
        {
            SqlConnection connection = new SqlConnection(GetConnection());
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public DataTable Query(string query)
        {
            SqlConnection dconnection = new SqlConnection(GetConnection());
            dconnection.Open();

            SqlCommand cmd = new SqlCommand(query, dconnection);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dconnection.Close();
            return dt;
        }
    }
}
