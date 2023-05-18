using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Attribute;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Attribute;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_AttributeService : IProduct_AttributeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_AttributeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<Product_AttributeQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_AttributeRepository.GetAll(x => new Product_AttributeQueryDto
            {
                Id = x.Id,
                Name=x.Name,
                Active=x.Active,
                
            });

            var itemMap = _mapper.Map<IEnumerable<Product_AttributeQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_AttributeQueryDto>>.SuccessAsync(itemMap, "Product_Attribute records retrieved");
        }

        public async Task<IResult<DtResult<Product_AttributeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_AttributeRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_AttributeRepository.GetAll(x => new Product_AttributeQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_AttributeRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_AttributeQueryDto>>(items);

            var datatableReturned = DtResult<Product_AttributeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_AttributeQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Attribute Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<Product_AttributeQueryDto>>> Find(Expression<Func<Product_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Attribute, bool>>>(expression);

            //var items = await _repositoryManager.Product_AttributeRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_AttributeRepository.Find(x => new Product_AttributeQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_AttributeQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_AttributeQueryDto>>.SuccessAsync(itemMap, "Product_Attribute records retrieved");
        }

        public async Task<IResult<DtResult<Product_AttributeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Attribute, bool>>>(expression);

            //var items = await _repositoryManager.Product_AttributeRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_AttributeRepository.Find(x => new Product_AttributeQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_AttributeRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_AttributeQueryDto>>(items);

            var datatableReturned = DtResult<Product_AttributeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_AttributeQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_AttributeQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Attribute Datatable.", 200);
        }


        public async Task<IResult<Product_AttributeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_AttributeRepository.GetById(Id);

            if (item == null) return await Result<Product_AttributeQueryDto>.FailAsync("GetProduct_AttributeById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_AttributeQueryDto>(item);

            return await Result<Product_AttributeQueryDto>.SuccessAsync(itemMap, "Product_Attribute record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_AttributeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_AttributeRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_AttributeDDlLViewModels>>.FailAsync("GetProduct_AttributeDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_AttributeDDLViewModel>(item);

            return await Result<IEnumerable<Product_AttributeDDlLViewModels>>.SuccessAsync(item, "Product_Attribute DDL records retrieved");
        }
        public async Task<IResult<Product_AttributeQueryDto>> Add(Product_AttributeDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_AttributeQueryDto>.FailAsync("AddProduct_Attribute > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_AttributeRepository.AddAndReturn(_mapper.Map<Product_Attribute>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_AttributeQueryDto>(newEntity);

                return await Result<Product_AttributeQueryDto>.SuccessAsync(entityMap, "Product_Attribute record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_AttributeQueryDto>.FailAsync($"AddProduct_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_AttributeRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_Attribute > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_AttributeRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Attribute record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_AttributeQueryDto>> Update(Product_AttributeDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_AttributeQueryDto>.FailAsync($"UpdateProduct_Attribute > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_AttributeRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_AttributeQueryDto>.FailAsync("UpdateProduct_Attribute > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_AttributeRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_AttributeQueryDto>.SuccessAsync(_mapper.Map<Product_AttributeQueryDto>(item), "Product_Attribute record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_AttributeQueryDto>.FailAsync($"UpdateProduct_Attribute > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_AttributeDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_AttributeRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_AttributeRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_AttributeQueryDto>.SuccessAsync(_mapper.Map<Product_AttributeQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_AttributeQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
