using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("libros");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Isbn).HasColumnName("isbn");
            builder.Property(x => x.Titulo).HasColumnName("titulo");
            builder.Property(x => x.Autores).HasColumnName("autores");
            builder.Property(x => x.Edicion).HasColumnName("edicion");
            builder.Property(x => x.Anio).HasColumnName("anio");
            builder.Property(x => x.IdEditorial).HasColumnName("id_editorial");
            builder.Property(x => x.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(x => x.Estado).HasColumnName("estado");

            // Relación con Editorial
            builder.HasOne(x => x.Editorial)
                   .WithMany(x => x.Libros)
                   .HasForeignKey(x => x.IdEditorial);
        }
    }
}
