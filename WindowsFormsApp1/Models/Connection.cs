using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Models
{
    public class  Connection
    {

        private string connectionString;
        private SqlConnection connection;

        private Connection()
        {
            connection = new SqlConnection();
        }
        public void Connect()
        {
            connection = new SqlConnection(GetConnectionString());
            connection.Open();
        }
        private string GetConnectionString()
        {
            return "Server=DESKTOP-MS2A1CD;Database=Firma_Transportowa;Trusted_Connection=true";
        }


    }
}
