using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.News;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public NewsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<NewsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.NewsRepository.GetAll(x => new NewsQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                Description = x.Description,
                CreatedAt= x.CreatedAt,
                DeleteAt= x.DeleteAt,
                ImageUrl= x.ImageUrl,
                MarketsId= x.MarketsId,
                MarketsName=x.Markets.Name,
                MarketsImageurl=x.Markets.ImageUrl,
                ProductId = x.ProductId,
                Active = x.Active,

            });

            var itemMap = _mapper.Map<IEnumerable<NewsQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<NewsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<NewsQueryDto>>.SuccessAsync(itemMap, "News records retrieved");
        }

        public async Task<IResult<DtResult<NewsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.NewsRepository.GetAll(x => new NewsQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                DeleteAt = x.DeleteAt,
                ImageUrl = x.ImageUrl,
                MarketsId = x.MarketsId,
                ProductId = x.ProductId,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.NewsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<NewsQueryDto>>(items);

            var datatableReturned = DtResult<NewsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);


            if (items == null) return await Result<DtResult<NewsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<NewsQueryDto>>.SuccessAsync(datatableReturned, message: "Get News Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<NewsQueryDto>>> Find(Expression<Func<NewsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<News, bool>>>(expression);

            var items = await _repositoryManager.NewsRepository.Find(x => new NewsQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                DeleteAt = x.DeleteAt,
                ImageUrl = x.ImageUrl,
                MarketsId = x.MarketsId,
                ProductId = x.ProductId,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<NewsQueryDto>>(items);

            if (items == null || items.Any() == false) return await Result<IEnumerable<NewsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<NewsQueryDto>>.SuccessAsync(itemMap, "News records retrieved");
        }

        public async Task<IResult<DtResult<NewsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<NewsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<News, bool>>>(expression);

            var items = await _repositoryManager.NewsRepository.Find(x => new NewsQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                DeleteAt = x.DeleteAt,
                ImageUrl = x.ImageUrl,
                MarketsId = x.MarketsId,
                ProductId = x.ProductId,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.NewsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<NewsQueryDto>>(items);

            var datatableReturned = DtResult<NewsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<NewsQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<NewsQueryDto>>.SuccessAsync(datatableReturned, message: "Get News Datatable.", 200);
        }


        public async Task<IResult<NewsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.NewsRepository.GetById(Id);

            if (item == null) return await Result<NewsQueryDto>.FailAsync("GetNewsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<NewsQueryDto>(item);

            return await Result<NewsQueryDto>.SuccessAsync(itemMap, "News record retrieved");
        }

        public async Task<IResult<NewsQueryDto>> Add(NewsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<NewsQueryDto>.FailAsync("AddNews > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.NewsRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<NewsQueryDto>.FailAsync("AddNews > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.NewsRepository.AddAndReturn(_mapper.Map<News>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<NewsQueryDto>(newEntity);

                return await Result<NewsQueryDto>.SuccessAsync(entityMap, "News record added");
            }
            catch (Exception exc)
            {

                return await Result<NewsQueryDto>.FailAsync($"AddNews > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.NewsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveNews > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.NewsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveNews record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveNews > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<NewsQueryDto>> Update(NewsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<NewsQueryDto>.FailAsync($"UpdateNews > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.NewsRepository.GetById(entity.Id);

            if (item == null) return await Result<NewsQueryDto>.FailAsync("UpdateNews > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.NewsRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<NewsQueryDto>.SuccessAsync(_mapper.Map<NewsQueryDto>(item), "News record updated");
            }
            catch (Exception exc)
            {
                return await Result<NewsQueryDto>.FailAsync($"UpdateNews > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(NewsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.NewsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.NewsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<NewsQueryDto>.SuccessAsync(_mapper.Map<NewsQueryDto>(item), "News record updated");
            }
            catch (Exception exc)
            {
                return await Result<NewsQueryDto>.FailAsync($"UpdateNews > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
