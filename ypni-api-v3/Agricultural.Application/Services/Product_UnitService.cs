using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Unit;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Unit;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_UnitService : IProduct_UnitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_UnitService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<Product_UnitQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_UnitRepository.GetAll(x => new Product_UnitQueryDto
            {
                Id = x.Id,
                Price = x.Price,
                ProductId = x.ProductId,
                qty=x.qty,
                UnitId=x.UnitId,
                

            });

            var itemMap = _mapper.Map<IEnumerable<Product_UnitQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_UnitQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_UnitQueryDto>>.SuccessAsync(itemMap, "Product_Unit records retrieved");
        }

        public async Task<IResult<DtResult<Product_UnitQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_UnitRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_UnitRepository.GetAll(x => new Product_UnitQueryDto
            {
                Id = x.Id,
                Price = x.Price,
                ProductId = x.ProductId,
                qty = x.qty,
                UnitId = x.UnitId,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_UnitRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_UnitQueryDto>>(items);

            var datatableReturned = DtResult<Product_UnitQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_UnitQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_UnitQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Unit Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<Product_UnitQueryDto>>> Find(Expression<Func<Product_UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Unit, bool>>>(expression);

            //var items = await _repositoryManager.Product_UnitRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_UnitRepository.Find(x => new Product_UnitQueryDto
            {
                Id = x.Id,
                Price = x.Price,
                ProductId = x.ProductId,
                qty = x.qty,
                UnitId = x.UnitId,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_UnitQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_UnitQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_UnitQueryDto>>.SuccessAsync(itemMap, "Product_Unit records retrieved");
        }

        public async Task<IResult<DtResult<Product_UnitQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Unit, bool>>>(expression);

            //var items = await _repositoryManager.Product_UnitRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_UnitRepository.Find(x => new Product_UnitQueryDto
            {
                Id = x.Id,
                Price = x.Price,
                ProductId = x.ProductId,
                qty = x.qty,
                UnitId = x.UnitId,
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_UnitRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_UnitQueryDto>>(items);

            var datatableReturned = DtResult<Product_UnitQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_UnitQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_UnitQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Unit Datatable.", 200);
        }


        public async Task<IResult<Product_UnitQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_UnitRepository.GetById(Id);

            if (item == null) return await Result<Product_UnitQueryDto>.FailAsync("GetProduct_UnitById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_UnitQueryDto>(item);

            return await Result<Product_UnitQueryDto>.SuccessAsync(itemMap, "Product_Unit record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_UnitDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_UnitRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_UnitDDlLViewModels>>.FailAsync("GetProduct_UnitDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_UnitDDLViewModel>(item);

            return await Result<IEnumerable<Product_UnitDDlLViewModels>>.SuccessAsync(item, "Product_Unit DDL records retrieved");
        }
        public async Task<IResult<Product_UnitQueryDto>> Add(Product_UnitDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_UnitQueryDto>.FailAsync("AddProduct_Unit > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_UnitRepository.AddAndReturn(_mapper.Map<Product_Unit>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_UnitQueryDto>(newEntity);

                return await Result<Product_UnitQueryDto>.SuccessAsync(entityMap, "Product_Unit record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_UnitQueryDto>.FailAsync($"AddProduct_Unit > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_UnitRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_Unit > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_UnitRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Unit record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Unit > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_UnitQueryDto>> Update(Product_UnitDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_UnitQueryDto>.FailAsync($"UpdateProduct_Unit > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_UnitRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_UnitQueryDto>.FailAsync("UpdateProduct_Unit > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_UnitRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_UnitQueryDto>.SuccessAsync(_mapper.Map<Product_UnitQueryDto>(item), "Product_Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_UnitQueryDto>.FailAsync($"UpdateProduct_Unit > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_UnitDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_UnitRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_UnitRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_UnitQueryDto>.SuccessAsync(_mapper.Map<Product_UnitQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_UnitQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
