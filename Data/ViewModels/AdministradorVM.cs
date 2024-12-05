using System.Collections.Generic;

namespace CajemesFoodAlejandro_Aimara.Data.ViewModels
{
    public class AdministradorVM
    {
        public string nombre { get; set; }
    }

    public class AdministradorWithLocalsVM
    {
        public string nombre { get; set; }
        public List<string> Locales { get; set; }  // Listado de nombres de los Locales asociados a este Administrador
    }
}
