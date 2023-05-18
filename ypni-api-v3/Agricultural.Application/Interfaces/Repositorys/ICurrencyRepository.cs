using Agricultural.Application.Interfaces.Common;
using Agricultural.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface  ICurrencyRepository : IGenericRepository<Currency>
    {
        Task<IEnumerable<Currency>> GetDDL();
    }
}
