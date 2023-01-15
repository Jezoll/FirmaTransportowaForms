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

        
        public SqlConnection connection;

        public Connection()
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
            string MachineName = Environment.MachineName;
            return "Server="+MachineName+";Database=Firma_Transportowa;Trusted_Connection=true";
 
        }
        

    }
}
