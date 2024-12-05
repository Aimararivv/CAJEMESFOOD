using System.Collections.Generic;

namespace CajemesFoodAlejandro_Aimara.Data.Models
{
    public class Local
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        //Propiedades de navegación (En esta parte es donde "mapeamos")
        public int Administradorid { get; set; }
        public Administrador Administrador { get; set; }
        public List<Local_Platillo> Local_Platillo { get; set; }
    }
}