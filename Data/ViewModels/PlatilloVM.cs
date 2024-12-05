using System.Collections.Generic;
using System;

namespace CajemesFoodAlejandro_Aimara.Data.ViewModels
{
    public class PlatilloVM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public DateTime caducidad { get; set; }
    }

    public class PlatilloWithLocalsVM
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public DateTime caducidad { get; set; }
        public List<string> Localnombre { get; set; }  // Lista de nombres de los Locales asociados
    }
}