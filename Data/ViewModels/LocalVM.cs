using System.Collections.Generic;

namespace CajemesFoodAlejandro_Aimara.Data.ViewModels
{
    public class LocalVM
    {
        public int id { get; set; }  // Cambié Titulo por id
        public string nombre { get; set; }  // Cambié Titulo por nombre
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int Administradorid { get; set; }
        public List<int> PlatillosIDs { get; set; }  // Lista de IDs de Platillos que están en el Local
    }

    public class LocalWithPlatillosVM
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public List<string> Platillos { get; set; }  // Listado de nombres de Platillos asociados
    }
}