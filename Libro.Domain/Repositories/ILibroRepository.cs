using Proyecto.Domain.Models;
using Proyecto.Domain.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Repositories
{
    public interface ILibroRepository: ICrudRepository<Libro, int>
    {
    }
}
