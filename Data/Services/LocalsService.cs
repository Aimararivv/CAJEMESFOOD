using CajemesFoodAlejandro_Aimara.Data.Models;
using CajemesFoodAlejandro_Aimara.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CajemesFoodAlejandro_Aimara.Data.Services
{
    public class LocalsService
    {
            private AppDbContext _context;

            public LocalsService(AppDbContext context)
            {
                _context = context;
            }

            // Agregar un nuevo Local con Platillos
            public void AddLocalWithPlatillos(LocalVM local)
            {
                var _local = new Local()
                {
                    id = local.id,
                    nombre = local.nombre,
                    direccion = local.direccion,
                    telefono = local.telefono,
                    Administradorid = local.Administradorid
                };
                _context.Locals.Add(_local);
                _context.SaveChanges();

                // Agregar los Platillos asociados a este Local
                foreach (var id in local.PlatillosIDs)
                {
                    var _localPlatillo = new Local_Platillo()
                    {
                        Localid = _local.id,
                        Platilloid = id
                    };
                    _context.Local_Platillo.Add(_localPlatillo);
                }
                _context.SaveChanges();
            }

            // Obtener todos los Locales
            public List<Local> GetAllLocals() => _context.Locals.ToList();

            // Obtener un Local por su ID
            public Local GetLocalById(int localid) => _context.Locals.FirstOrDefault(n => n.id == localid);

            // Actualizar un Local existente
            public Local UpdateLocalByID(int localid, LocalVM local)
            {
                var _local = _context.Locals.FirstOrDefault(n => n.id == localid);
                if (_local != null)
                {
                    _local.nombre = local.nombre;
                    _local.direccion = local.direccion;
                    _local.telefono = local.telefono;
                    _local.Administradorid = local.Administradorid;

                    _context.SaveChanges();
                }
                return _local;
            }

            // Eliminar un Local
            public void DeleteLocalById(int localid)
            {
                var _local = _context.Locals.FirstOrDefault(n => n.id == localid);
                if (_local != null)
                {
                    _context.Locals.Remove(_local);
                    _context.SaveChanges();
                }
            }
        }
    }
