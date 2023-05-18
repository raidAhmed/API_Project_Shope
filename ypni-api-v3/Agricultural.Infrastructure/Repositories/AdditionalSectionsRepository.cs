using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.AdditionalSections;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class AdditionalSectionsRepository : GenericRepository<AdditionalSections>,IAdditionalSectionsRepository
    {
        public AdditionalSectionsRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<AdditionalSectionsDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<AdditionalSections>().Select(x => new AdditionalSectionsDDlLViewModels
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName
            }));
        }  

    }
}
