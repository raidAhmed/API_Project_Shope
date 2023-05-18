using Agricultural.Application.Common;
using Agricultural.Application.DTOs.News;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface INewsService
    {
        Task<IResult<NewsQueryDto>> Add(NewsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<NewsQueryDto>>> Find(Expression<Func<NewsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<NewsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<NewsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<NewsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<NewsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<NewsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
      
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<NewsQueryDto>> Update(NewsDto entity, CancellationToken cancellationToken = default);

         Task<IResult> ChangeActive(NewsDto entity,CancellationToken cancellationToken=default);
    }
}
