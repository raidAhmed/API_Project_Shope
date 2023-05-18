using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_AdditionalDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_AdditionalDetails;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_AdditionalDetailsService : IProduct_AdditionalDetailsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_AdditionalDetailsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<Product_AdditionalDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_AdditionalDetailsRepository.GetAll(x => new Product_AdditionalDetailsQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Title = x.Title,
                Value=x.Value,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_AdditionalDetailsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_AdditionalDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_AdditionalDetailsQueryDto>>.SuccessAsync(itemMap, "Product_AdditionalDetails records retrieved");
        }

        public async Task<IResult<DtResult<Product_AdditionalDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_AdditionalDetailsRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_AdditionalDetailsRepository.GetAll(x => new Product_AdditionalDetailsQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Title = x.Title,
                Value = x.Value,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_AdditionalDetailsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_AdditionalDetailsQueryDto>>(items);

            var datatableReturned = DtResult<Product_AdditionalDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_AdditionalDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_AdditionalDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_AdditionalDetails Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<Product_AdditionalDetailsQueryDto>>> Find(Expression<Func<Product_AdditionalDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_AdditionalDetails, bool>>>(expression);

            //var items = await _repositoryManager.Product_AdditionalDetailsRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_AdditionalDetailsRepository.Find(x => new Product_AdditionalDetailsQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Title = x.Title,
                Value = x.Value,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_AdditionalDetailsQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_AdditionalDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_AdditionalDetailsQueryDto>>.SuccessAsync(itemMap, "Product_AdditionalDetails records retrieved");
        }

        public async Task<IResult<DtResult<Product_AdditionalDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_AdditionalDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_AdditionalDetails, bool>>>(expression);

            //var items = await _repositoryManager.Product_AdditionalDetailsRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_AdditionalDetailsRepository.Find(x => new Product_AdditionalDetailsQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Title = x.Title,
                Value = x.Value,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_AdditionalDetailsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_AdditionalDetailsQueryDto>>(items);

            var datatableReturned = DtResult<Product_AdditionalDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_AdditionalDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_AdditionalDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_AdditionalDetails Datatable.", 200);
        }


        public async Task<IResult<Product_AdditionalDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_AdditionalDetailsRepository.GetById(Id);

            if (item == null) return await Result<Product_AdditionalDetailsQueryDto>.FailAsync("GetProduct_AdditionalDetailsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_AdditionalDetailsQueryDto>(item);

            return await Result<Product_AdditionalDetailsQueryDto>.SuccessAsync(itemMap, "Product_AdditionalDetails record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_AdditionalDetailsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_AdditionalDetailsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_AdditionalDetailsDDlLViewModels>>.FailAsync("GetProduct_AdditionalDetailsDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_AdditionalDetailsDDLViewModel>(item);

            return await Result<IEnumerable<Product_AdditionalDetailsDDlLViewModels>>.SuccessAsync(item, "Product_AdditionalDetails DDL records retrieved");
        }
        public async Task<IResult<Product_AdditionalDetailsQueryDto>> Add(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_AdditionalDetailsQueryDto>.FailAsync("AddProduct_AdditionalDetails > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_AdditionalDetailsRepository.AddAndReturn(_mapper.Map<Product_AdditionalDetails>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_AdditionalDetailsQueryDto>(newEntity);

                return await Result<Product_AdditionalDetailsQueryDto>.SuccessAsync(entityMap, "Product_AdditionalDetails record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_AdditionalDetailsQueryDto>.FailAsync($"AddProduct_AdditionalDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_AdditionalDetailsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_AdditionalDetails > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_AdditionalDetailsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_AdditionalDetails record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_AdditionalDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_AdditionalDetailsQueryDto>> Update(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_AdditionalDetailsQueryDto>.FailAsync($"UpdateProduct_AdditionalDetails > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_AdditionalDetailsRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_AdditionalDetailsQueryDto>.FailAsync("UpdateProduct_AdditionalDetails > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_AdditionalDetailsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_AdditionalDetailsQueryDto>.SuccessAsync(_mapper.Map<Product_AdditionalDetailsQueryDto>(item), "Product_AdditionalDetails record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_AdditionalDetailsQueryDto>.FailAsync($"UpdateProduct_AdditionalDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_AdditionalDetailsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_AdditionalDetailsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_AdditionalDetailsQueryDto>.SuccessAsync(_mapper.Map<Product_AdditionalDetailsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_AdditionalDetailsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
