using CajemesFoodAlejandro_Aimara.Data.Models;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using System;
using System.Linq;

namespace CajemesFoodAlejandro_Aimara.Data.Services
{
    public class AdministradoresService
    {
            private AppDbContext _context;

            public AdministradoresService(AppDbContext context)
            {
                _context = context;
            }

            // Agregar un nuevo Administrador
            public Administrador AddAdministrador(AdministradorVM administrador)
            {
                var _administrador = new Administrador()
                {
                    nombre = administrador.nombre
                };
                _context.Administradores.Add(_administrador);
                _context.SaveChanges();
                return _administrador;
            }

            // Obtener un Administrador por su ID
            public Administrador GetAdministradorByID(int id) => _context.Administradores.FirstOrDefault(n => n.id == id);

            // Obtener los Locales asociados a un Administrador
            public AdministradorWithLocalsVM GetAdministradorLocals(int id)
            {
                var _administrador = _context.Administradores.Where(n => n.id == id)
                    .Select(n => new AdministradorWithLocalsVM()
                    {
                        nombre = n.nombre,
                        Locales = n.Local.Select(l => l.nombre).ToList()
                    }).FirstOrDefault();
                return _administrador;
            }

            // Eliminar un Administrador por su ID
            public void DeleteAdministradorById(int id)
            {
                var _administrador = _context.Administradores.FirstOrDefault(n => n.id == id);
                if (_administrador != null)
                {
                    _context.Administradores.Remove(_administrador);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"El Administrador con el id {id} no existe.");
                }
            }
        }
    }

