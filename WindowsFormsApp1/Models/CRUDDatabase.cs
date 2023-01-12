using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Models
{
    public  class CRUDDatabase 
    {
        private SqlConnection connection;


        public CRUDDatabase()
        {
            connection = new SqlConnection();
        }

        public string GetConncetionString()
        {
            return "Server=DESKTOP-MS2A1CD;Database=Firma_Transportowa;Trusted_Connection=true";
        }

        public void Connect()
        {
            connection = new SqlConnection(GetConncetionString());
            connection.Open();
        }

    }
}
