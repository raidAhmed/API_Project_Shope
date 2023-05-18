using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class WorkinPoeriodsRepository : GenericRepository<WorkinPoeriods>,IWorkinPoeriodsRepository
    {
        public WorkinPoeriodsRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}
