using System.Collections.Generic;

namespace CajemesFoodAlejandro_Aimara.Data.Models
{
    public class Administrador
    {
        public int id { get; set; }
        public string nombre { get; set; }

        //Propiedades de navegación
        public List<Local> Local { get; set; }
    }
}
