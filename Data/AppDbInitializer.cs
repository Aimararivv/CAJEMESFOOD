using CajemesFoodAlejandro_Aimara.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CajemesFoodAlejandro_Aimara.Data
{
    public class AppDbInitializer
    {
        // Método que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Verificamos si ya hay datos en la base de datos
                if (!context.Locals.Any())
                {
                    // Agregar algunos administradores (si no existen)
                    var admin1 = new Administrador()
                    {
                        nombre = "Administrador 1"
                    };

                    var admin2 = new Administrador()
                    {
                        nombre = "Administrador 2"
                    };

                    context.Administradores.AddRange(admin1, admin2);
                    context.SaveChanges();

                    // Agregar algunos locales
                    var local1 = new Local()
                    {
                        nombre = "Local 1",
                        direccion = "Calle 123",
                        telefono = "1234567890",
                        Administradorid = admin1.id  // Relación con el administrador
                    };

                    var local2 = new Local()
                    {
                        nombre = "Local 2",
                        direccion = "Avenida 456",
                        telefono = "0987654321",
                        Administradorid = admin2.id  // Relación con el administrador
                    };

                    context.Locals.AddRange(local1, local2);
                    context.SaveChanges();

                    // Agregar algunos platillos
                    var platillo1 = new Platillo()
                    {
                        nombre = "Platillo 1",
                        descripcion = "Deliciosa comida",
                        precio = 10,
                        caducidad = DateTime.Now.AddMonths(1)
                    };

                    var platillo2 = new Platillo()
                    {
                        nombre = "Platillo 2",
                        descripcion = "Comida sabrosa",
                        precio = 12,
                        caducidad = DateTime.Now.AddMonths(2)
                    };

                    context.Platillos.AddRange(platillo1, platillo2);
                    context.SaveChanges();

                    // Relacionar platillos con locales a través de Local_Platillo
                    var localPlatillo1 = new Local_Platillo()
                    {
                        Localid = local1.id,
                        Platilloid = platillo1.id
                    };

                    var localPlatillo2 = new Local_Platillo()
                    {
                        Localid = local2.id,
                        Platilloid = platillo2.id
                    };

                    context.Local_Platillo.AddRange(localPlatillo1, localPlatillo2);
                    context.SaveChanges();
                }
            }
        }
    }
}
