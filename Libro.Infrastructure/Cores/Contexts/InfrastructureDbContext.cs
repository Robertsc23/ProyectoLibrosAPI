using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Proyecto.Domain.Models;
using Proyecto.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Cores.Contexts
{
    public class InfrastructureDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public InfrastructureDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitanteConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            
        }

        #region DbSets
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        #endregion
    }
}

