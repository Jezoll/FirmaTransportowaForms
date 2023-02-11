using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class DeparturesPanel : Form
    {
        public DeparturesPanel()
        {
            InitializeComponent();
            RenderDepartures();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RenderDepartures()
        {
            List<Departures> departure = new List<Departures>();
            
            List<DeparturesDTO> dto = new List<DeparturesDTO>();
            Departures dep = new Departures();
            departure = dep.GetTrasy();
            foreach(var item in departure)
            {
                DeparturesDTO depDTO = new DeparturesDTO(item.Id_trasy, item.Miejsce_załadunku, item.Miejsca_rozładunku, item.Długość_trasy, item.Id_klient, item.Id_kierowcy, item.Id_pojazdu, item.Id_ładunku, item.Id_przyczepy, item.Wykonana);
                dto.Add(depDTO);
            }
            dataGridView1.DataSource = dto;

        }
    }
}
