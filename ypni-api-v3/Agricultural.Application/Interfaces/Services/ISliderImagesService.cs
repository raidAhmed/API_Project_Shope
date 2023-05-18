using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SliderImages;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SliderImages;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISliderImagesService
    {
        Task<IResult<SliderImagesDto>> Add(SliderImagesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderImagesQueryDto>>> Find(Expression<Func<SliderImagesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SliderImagesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SliderImagesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderImagesQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SliderImagesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SliderImagesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderImagesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SliderImagesQueryDto>> Update(SliderImagesDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SliderImagesDto entity, CancellationToken cancellationToken = default);
    }
}
