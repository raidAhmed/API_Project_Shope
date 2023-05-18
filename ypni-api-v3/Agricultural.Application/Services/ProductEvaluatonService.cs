using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProductEvaluaton;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProductEvaluaton;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ProductEvaluatonService : IProductEvaluatonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductEvaluatonService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ProductEvaluatonQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ProductEvaluatonRepository.GetAll(x => new ProductEvaluatonQueryDto
            {
                Id = x.Id,
                Comment = x.Comment,
                ProductId = x.ProductId,
                Rating = x.Rating,
                UserId=x.UserId,

            });

            var itemMap = _mapper.Map<IEnumerable<ProductEvaluatonQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ProductEvaluatonQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProductEvaluatonQueryDto>>.SuccessAsync(itemMap, "ProductEvaluaton records retrieved");
        }

        public async Task<IResult<DtResult<ProductEvaluatonQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ProductEvaluatonRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProductEvaluatonRepository.GetAll(x => new ProductEvaluatonQueryDto
            {
                Id = x.Id,
                Comment = x.Comment,
                ProductId = x.ProductId,
                Rating = x.Rating,
                UserId = x.UserId,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProductEvaluatonRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ProductEvaluatonQueryDto>>(items);

            var datatableReturned = DtResult<ProductEvaluatonQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ProductEvaluatonQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProductEvaluatonQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProductEvaluaton Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ProductEvaluatonQueryDto>>> Find(Expression<Func<ProductEvaluatonQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProductEvaluaton, bool>>>(expression);

            //var items = await _repositoryManager.ProductEvaluatonRepository.Find(mapExpr);

            var items = await _repositoryManager.ProductEvaluatonRepository.Find(x => new ProductEvaluatonQueryDto
            {
                Id = x.Id,
                Comment = x.Comment,
                ProductId = x.ProductId,
                Rating = x.Rating,
                UserId = x.UserId,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ProductEvaluatonQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ProductEvaluatonQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProductEvaluatonQueryDto>>.SuccessAsync(itemMap, "ProductEvaluaton records retrieved");
        }

        public async Task<IResult<DtResult<ProductEvaluatonQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProductEvaluatonQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProductEvaluaton, bool>>>(expression);

            //var items = await _repositoryManager.ProductEvaluatonRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProductEvaluatonRepository.Find(x => new ProductEvaluatonQueryDto
            {
                Id = x.Id,
                Comment = x.Comment,
                ProductId = x.ProductId,
                Rating = x.Rating,
                UserId = x.UserId,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProductEvaluatonRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ProductEvaluatonQueryDto>>(items);

            var datatableReturned = DtResult<ProductEvaluatonQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ProductEvaluatonQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProductEvaluatonQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProductEvaluaton Datatable.", 200);
        }


        public async Task<IResult<ProductEvaluatonQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProductEvaluatonRepository.GetById(Id);

            if (item == null) return await Result<ProductEvaluatonQueryDto>.FailAsync("GetProductEvaluatonById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ProductEvaluatonQueryDto>(item);

            return await Result<ProductEvaluatonQueryDto>.SuccessAsync(itemMap, "ProductEvaluaton record retrieved");
        }

        public async Task<IResult<IEnumerable<ProductEvaluatonDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProductEvaluatonRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ProductEvaluatonDDlLViewModels>>.FailAsync("GetProductEvaluatonDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ProductEvaluatonDDLViewModel>(item);

            return await Result<IEnumerable<ProductEvaluatonDDlLViewModels>>.SuccessAsync(item, "ProductEvaluaton DDL records retrieved");
        }
        public async Task<IResult<ProductEvaluatonQueryDto>> Add(ProductEvaluatonDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ProductEvaluatonQueryDto>.FailAsync("AddProductEvaluaton > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ProductEvaluatonRepository.AddAndReturn(_mapper.Map<ProductEvaluaton>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ProductEvaluatonQueryDto>(newEntity);

                return await Result<ProductEvaluatonQueryDto>.SuccessAsync(entityMap, "ProductEvaluaton record added");
            }
            catch (Exception exc)
            {

                return await Result<ProductEvaluatonQueryDto>.FailAsync($"AddProductEvaluaton > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProductEvaluatonRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProductEvaluaton > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ProductEvaluatonRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProductEvaluaton record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProductEvaluaton > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ProductEvaluatonQueryDto>> Update(ProductEvaluatonDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ProductEvaluatonQueryDto>.FailAsync($"UpdateProductEvaluaton > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ProductEvaluatonRepository.GetById(entity.Id);

            if (item == null) return await Result<ProductEvaluatonQueryDto>.FailAsync("UpdateProductEvaluaton > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ProductEvaluatonRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductEvaluatonQueryDto>.SuccessAsync(_mapper.Map<ProductEvaluatonQueryDto>(item), "ProductEvaluaton record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductEvaluatonQueryDto>.FailAsync($"UpdateProductEvaluaton > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ProductEvaluatonDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProductEvaluatonRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ProductEvaluatonRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductEvaluatonQueryDto>.SuccessAsync(_mapper.Map<ProductEvaluatonQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductEvaluatonQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
