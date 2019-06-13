using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaMasiva.Entidades
{
   public class TablaCandidatos
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string image_name { get; set; }
        public int lista_id { get; set; }
        public int cargo_id { get; set; }
        public int listainterna_id { get; set; }
        public DateTime updated_at { get; set; }
    }
}
