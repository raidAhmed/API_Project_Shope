using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Color;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ColorRepository : GenericRepository<Color>,IColorRepository
    {
        public ColorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

  

        public async Task<IEnumerable<ColorDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Color>().Select(x => new ColorDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}
