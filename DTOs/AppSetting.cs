using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharpTraining.DTOs
{
    public class AppSetting
    {
        public static SqlConnectionStringBuilder DbConnection = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "testing",
            UserID = "sa",
            Password = "thetwaiaung"
        };
    }
}
