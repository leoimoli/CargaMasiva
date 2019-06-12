using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaMasiva.Entidades
{
   public class TablaVotos
    {
        public int Votos { get; set; }
        public string Usuario { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public string Visible { get; set; }
        public int Mesa_id { get; set; }
        public int Candidato_id { get; set; }
    }
}
