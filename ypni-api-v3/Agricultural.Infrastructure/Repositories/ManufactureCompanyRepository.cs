using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ManufactureCompany;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ManufactureCompanyRepository : GenericRepository<ManufactureCompany>,IManufactureCompanyRepository
    {
        public ManufactureCompanyRepository(ApplicationDbContext context) : base(context)
        {
        }



        public async Task<IEnumerable<ManufactureCompanyDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ManufactureCompany>().Select(x => new ManufactureCompanyDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}
