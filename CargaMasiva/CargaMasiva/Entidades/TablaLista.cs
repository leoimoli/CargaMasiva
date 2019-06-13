using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaMasiva.Entidades
{
   public class TablaLista
    {
        public string numero { get; set; }
        public string descripcion { get; set; }
        public string color { get; set; }
        public string image_name { get; set; }
        public DateTime updateAt { get; set; }
        public int orden { get; set; }       
    }
}
