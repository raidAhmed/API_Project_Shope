using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SpecialSections;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SpecialSectionsRepository : GenericRepository<SpecialSections>,ISpecialSectionsRepository
    {
        public SpecialSectionsRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<SpecialSectionsDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<SpecialSections>().Select(x => new SpecialSectionsDDlLViewModels
            {
                Id = x.Id,
                SpecialSectionName = x.SpecialSectionName
            }));
        }
    }
}
