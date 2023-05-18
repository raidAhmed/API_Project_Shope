using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Infrastructure.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Currency>> GetDDL()
        {

            return await Task.FromResult(_context.Set<Currency>().Select(x => new Currency
            {
                Id =x.Id,
                Name = x.Name,
            }));
        }
    }
}
