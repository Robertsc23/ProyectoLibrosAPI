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
    public class EditorialRepository : CrudRepository<Editorial, int>, IEditorialRepository
    {
        public EditorialRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
