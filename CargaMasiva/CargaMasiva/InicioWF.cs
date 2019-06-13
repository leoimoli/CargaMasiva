using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaMasiva
{
    public partial class InicioWF : Form
    {
        public InicioWF()
        {
            InitializeComponent();
        }
        private void btnCargarLista_Click(object sender, EventArgs e)
        {
            CargaMasivaListaWF _lista = new CargaMasivaListaWF();
            _lista.Show();
            Hide();
        }

        private void btnListasInternas_Click(object sender, EventArgs e)
        {
            CargaMasivaListaInternaWF _lista = new CargaMasivaListaInternaWF();
            _lista.Show();
            Hide();
        }

        private void btnCandidatos_Click(object sender, EventArgs e)
        {
            CargarCandidatosWF _cargar = new CargarCandidatosWF();
            _cargar.Show();
            Hide();
        }
    }
}
