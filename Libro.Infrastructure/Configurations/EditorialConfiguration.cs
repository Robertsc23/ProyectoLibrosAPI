using Proyecto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Configurations
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("editoriales");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Codigo).HasColumnName("codigo");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(x => x.Estado).HasColumnName("estado");
        }
    }
}
