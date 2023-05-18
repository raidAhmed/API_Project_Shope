using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ActivityType;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ActivityTypeRepository : GenericRepository<ActivityType>,IActivityTypeRepository
    {
        public ActivityTypeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ActivityTypeDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ActivityType>().Select(x => new ActivityTypeDDlLViewModels
            {
                Id = x.Id,
                ActivityName = x.ActivityName
            }));
        }
    }
}
