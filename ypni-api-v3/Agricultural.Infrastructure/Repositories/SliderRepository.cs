using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Slider;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SliderDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Slider>().Select(x => new SliderDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name,
                ServiceProviderId=(int)x.ServiceProviderId

            }));
        }

       
    }
}
