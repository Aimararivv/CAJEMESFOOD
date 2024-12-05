using CajemesFoodAlejandro_Aimara.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace CajemesFoodAlejandro_Aimara.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación entre Local y Platillo a través de Local_Platillo
            modelBuilder.Entity<Local_Platillo>()
                .HasOne(lp => lp.Local)  // Local_Platillo tiene una relación con Local
                .WithMany(l => l.Local_Platillo)  // Un Local puede tener varios Local_Platillo
                .HasForeignKey(lp => lp.Localid);  // La clave foránea en Local_Platillo

            modelBuilder.Entity<Local_Platillo>()
                .HasOne(lp => lp.Platillo)  // Local_Platillo tiene una relación con Platillo
                .WithMany(p => p.Local_Platillo)  // Un Platillo puede estar en varios Local_Platillo
                .HasForeignKey(lp => lp.Platilloid);  // La clave foránea en Local_Platillo
        }

        // Utilizaremos este método para obtener y enviar datos a la BD
        public DbSet<Local> Locals { get; set; }  // Renombrado de 'Books' a 'Locals'
        public DbSet<Platillo> Platillos { get; set; }  // Renombrado de 'Authors' a 'Platillos'
        public DbSet<Local_Platillo> Local_Platillo { get; set; }  // Renombrado de 'Book_Authors' a 'Local_Platillo'
        public DbSet<Administrador> Administradores { get; set; }  // Renombrado de 'Publishers' a 'Administradores'
    }
}
