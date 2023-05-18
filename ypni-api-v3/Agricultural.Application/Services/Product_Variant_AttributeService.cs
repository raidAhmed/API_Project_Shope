using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Variant_Attribute;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Variant_Attribute;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_Variant_AttributeService : IProduct_Variant_AttributeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_Variant_AttributeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<Product_Variant_AttributeQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_Variant_AttributeRepository.GetAll(x => new Product_Variant_AttributeQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Product_AttributeId =(int) x.Product_AttributeId,
                value=x.value,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_Variant_AttributeQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_Variant_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_Variant_AttributeQueryDto>>.SuccessAsync(itemMap, "Product_Variant_Attribute records retrieved");
        }

        public async Task<IResult<DtResult<Product_Variant_AttributeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_Variant_AttributeRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_Variant_AttributeRepository.GetAll(x => new Product_Variant_AttributeQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Product_AttributeId = (int)x.Product_AttributeId,
                value = x.value,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_Variant_AttributeRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_Variant_AttributeQueryDto>>(items);

            var datatableReturned = DtResult<Product_Variant_AttributeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_Variant_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_Variant_AttributeQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Variant_Attribute Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<Product_Variant_AttributeQueryDto>>> Find(Expression<Func<Product_Variant_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Variant_Attribute, bool>>>(expression);

            //var items = await _repositoryManager.Product_Variant_AttributeRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => new Product_Variant_AttributeQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Product_AttributeId = (int)x.Product_AttributeId,
                value = x.value,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_Variant_AttributeQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_Variant_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_Variant_AttributeQueryDto>>.SuccessAsync(itemMap, "Product_Variant_Attribute records retrieved");
        }

        public async Task<IResult<DtResult<Product_Variant_AttributeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_Variant_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Variant_Attribute, bool>>>(expression);

            //var items = await _repositoryManager.Product_Variant_AttributeRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => new Product_Variant_AttributeQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Product_AttributeId = (int)x.Product_AttributeId,
                value = x.value,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_Variant_AttributeRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_Variant_AttributeQueryDto>>(items);

            var datatableReturned = DtResult<Product_Variant_AttributeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_Variant_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_Variant_AttributeQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Variant_Attribute Datatable.", 200);
        }


        public async Task<IResult<Product_Variant_AttributeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_Variant_AttributeRepository.GetById(Id);

            if (item == null) return await Result<Product_Variant_AttributeQueryDto>.FailAsync("GetProduct_Variant_AttributeById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_Variant_AttributeQueryDto>(item);

            return await Result<Product_Variant_AttributeQueryDto>.SuccessAsync(itemMap, "Product_Variant_Attribute record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_Variant_AttributeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_Variant_AttributeRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_Variant_AttributeDDlLViewModels>>.FailAsync("GetProduct_Variant_AttributeDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_Variant_AttributeDDLViewModel>(item);

            return await Result<IEnumerable<Product_Variant_AttributeDDlLViewModels>>.SuccessAsync(item, "Product_Variant_Attribute DDL records retrieved");
        }
        public async Task<IResult<Product_Variant_AttributeQueryDto>> Add(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_Variant_AttributeQueryDto>.FailAsync("AddProduct_Variant_Attribute > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_Variant_AttributeRepository.AddAndReturn(_mapper.Map<Product_Variant_Attribute>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_Variant_AttributeQueryDto>(newEntity);

                return await Result<Product_Variant_AttributeQueryDto>.SuccessAsync(entityMap, "Product_Variant_Attribute record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_Variant_AttributeQueryDto>.FailAsync($"AddProduct_Variant_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_Variant_AttributeRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_Variant_Attribute > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_Variant_AttributeRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Variant_Attribute record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Variant_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_Variant_AttributeQueryDto>> Update(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_Variant_AttributeQueryDto>.FailAsync($"UpdateProduct_Variant_Attribute > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_Variant_AttributeRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_Variant_AttributeQueryDto>.FailAsync("UpdateProduct_Variant_Attribute > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_Variant_AttributeRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_Variant_AttributeQueryDto>.SuccessAsync(_mapper.Map<Product_Variant_AttributeQueryDto>(item), "Product_Variant_Attribute record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_Variant_AttributeQueryDto>.FailAsync($"UpdateProduct_Variant_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_Variant_AttributeRepository.GetById(entity.Id);
          //  item.Active = !item.Active;
            _repositoryManager.Product_Variant_AttributeRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_Variant_AttributeQueryDto>.SuccessAsync(_mapper.Map<Product_Variant_AttributeQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_Variant_AttributeQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
