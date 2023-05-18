using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SliderImages;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SliderImagesRepository : GenericRepository<SliderImages>, ISliderImagesRepository
    {
        public SliderImagesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<SliderImagesDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }

       
    }
}
