using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class WorkingHoursRepository : GenericRepository<WorkingHours>,IWorkingHoursRepository
    {
        public WorkingHoursRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}
