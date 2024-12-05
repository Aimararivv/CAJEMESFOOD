using System.Collections.Generic;
using System;

namespace CajemesFoodAlejandro_Aimara.Data.Models
{
    public class Platillo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public DateTime caducidad { get; set; }


        //Propiedades de navegación
        public List<Local_Platillo> Local_Platillo { get; set; }
    }
}
