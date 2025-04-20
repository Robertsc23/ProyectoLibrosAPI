using Proyecto.Domain.Models;
using Proyecto.Domain.Repositories;
using Proyecto.Infrastructure.Cores.Contexts;
using Proyecto.Infrastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Persistences
{
    public class PrestamoRepository : CrudRepository<Prestamo, int>, IPrestamoRepository
    {
        public PrestamoRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
