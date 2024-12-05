using CajemesFoodAlejandro_Aimara.Data.Models;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CajemesFoodAlejandro_Aimara.Data.Services
{
    public class PlatillosService
    {
        private AppDbContext _context;

        public PlatillosService(AppDbContext context)
        {
            _context = context;
        }

        // Agregar un nuevo Platillo
        public void AddPlatillo(PlatilloVM platillo)
        {
            var _platillo = new Platillo()
            {
                id = platillo.id,
                nombre = platillo.nombre,
                descripcion = platillo.descripcion,
                precio = platillo.precio,
                caducidad = platillo.caducidad
            };
            _context.Platillos.Add(_platillo);
            _context.SaveChanges();
        }

        // Obtener un Platillo con los Locales asociados
        public PlatilloWithLocalsVM GetPlatilloWithLocals(int platilloId)
        {
            var _platillo = _context.Platillos.Where(n => n.id == platilloId)
                .Select(n => new PlatilloWithLocalsVM()
                {
                    nombre = n.nombre,
                    Localnombre = n.Local_Platillo.Select(lp => lp.Local.nombre).ToList()
                }).FirstOrDefault();
            return _platillo;
        }
    }
}