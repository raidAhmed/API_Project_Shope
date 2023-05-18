using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Slider;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISliderRepository : IGenericRepository<Slider>
    {
       
        Task<IEnumerable<SliderDDlLViewModels>> GetDDL();
    }
}
