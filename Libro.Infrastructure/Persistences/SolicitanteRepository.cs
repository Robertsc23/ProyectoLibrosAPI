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
    public class SolicitanteRepository : CrudRepository<Solicitante, int>, ISolicitanteRepository
    {
        public SolicitanteRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
