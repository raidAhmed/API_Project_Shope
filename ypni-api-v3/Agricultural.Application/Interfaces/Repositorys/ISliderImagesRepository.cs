using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SliderImages;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISliderImagesRepository : IGenericRepository<SliderImages>
    {
       
        Task<IEnumerable<SliderImagesDDlLViewModels>> GetDDL();
    }
}
