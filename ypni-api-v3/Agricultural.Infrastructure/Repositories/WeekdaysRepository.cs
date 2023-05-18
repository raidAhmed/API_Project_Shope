using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class WeekdaysRepository : GenericRepository<Weekdays>,IWeekdaysRepository
    {
        public WeekdaysRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}
