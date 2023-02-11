using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Insurance
    {
        private int id_ubezpieczenia
        { get; set; }
        private decimal składka
          { get; set; }
        private DateTime data_rozpoczęcia_ubezpieczenia;
        private DateTime data_zakończenia_ubezpieczenia;
        private bool oplacone;
        
        public void AddInsurance()
        {
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {

            }
        }
    }
}
