using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Slider;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Slider;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISliderService
    {
        Task<IResult<SliderDto>> Add(SliderDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderQueryDto>>> Find(Expression<Func<SliderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SliderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SliderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SliderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SliderQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SliderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
      //  Task<IResult<IEnumerable<imagessliderapi>>> GetBySPIdApi(Expression<Func<SliderQueryDto, bool>> expression, CancellationToken cancellationToken = default);


        Task<IResult<SliderQueryDto>> Update(SliderDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SliderDto entity, CancellationToken cancellationToken = default);
    }
}
