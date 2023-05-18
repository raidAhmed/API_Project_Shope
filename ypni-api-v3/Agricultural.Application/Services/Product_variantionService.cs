using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_variantion;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_variantionService : IProduct_variantionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_variantionService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IResult<IEnumerable<Product_variantionQueryDto>>> getByProductId(int productId, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_variantionRepository.getByProductId(productId);

            if (item.Any())
            {
                var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(item);

                return await Result<IEnumerable<Product_variantionQueryDto>>.SuccessAsync(itemMap, "Product_variantion records retrieved");
            }
            return await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync("No Data");
        }


        public async Task<IResult<IEnumerable<Product_variantionQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_variantionRepository.GetAll(x => new Product_variantionQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = (int)x.ProductId,
                Price = x.Price,
                qty = x.qty,
                SKU = x.SKU,
                Type = x.Type,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_variantionQueryDto>>.SuccessAsync(itemMap, "Product_variantion records retrieved");
        }

        public async Task<IResult<DtResult<Product_variantionQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_variantionRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_variantionRepository.GetAll(x => new Product_variantionQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = (int)x.ProductId,
                Price = x.Price,
                qty = x.qty,
                SKU = x.SKU,
                Type = x.Type,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_variantionRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(items);

            var datatableReturned = DtResult<Product_variantionQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_variantionQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_variantionQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_variantion Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<Product_variantionQueryDto>>> Find(Expression<Func<Product_variantionQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            try
            {
                var mapExpr = _mapper.Map<Expression<Func<Product_variantion, bool>>>(expression);

                //var items = await _repositoryManager.Product_variantionRepository.Find(mapExpr);

                var items = await _repositoryManager.Product_variantionRepository.Find(x => new Product_variantionQueryDto
                {
                    Id = x.Id,
                    Active = x.Active,
                    ProductId = (int)x.ProductId,
                    Price = x.Price,
                    qty = x.qty,
                    SKU = x.SKU,
                    Type = x.Type,

                }, mapExpr);

                var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(items);
                if (items == null) return await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync("No Data");
                return await Result<IEnumerable<Product_variantionQueryDto>>.SuccessAsync(itemMap, "Product_variantion records retrieved");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                return  await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync($"AddProduct_variantion > Something went wrong !!!\n\n\n{ex.InnerException.Message.ToString()}");
            }
            }  
        public async Task<IResult<IEnumerable<Product_variantionQueryDto>>> Findd(int productid, CancellationToken cancellationToken = default)
        {

            try
            {
               // var mapExpr = _mapper.Map<Expression<Func<Product_variantion, bool>>>(expression);

                //var items = await _repositoryManager.Product_variantionRepository.Find(mapExpr);

                var items = await _repositoryManager.Product_variantionRepository.Find(x => new Product_variantionQueryDto
                {
                    Id = x.Id,
                    Active = x.Active,
                    ProductId = (int)x.ProductId,
                    Price = x.Price,
                    qty = x.qty,
                    SKU = x.SKU,
                    Type = x.Type,

                }, x=>x.ProductId==productid);

                var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(items);
                if (items == null) return await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync("No Data");
                return await Result<IEnumerable<Product_variantionQueryDto>>.SuccessAsync(itemMap, "Product_variantion records retrieved");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException.Message);
                return  await Result<IEnumerable<Product_variantionQueryDto>>.FailAsync($"AddProduct_variantion > Something went wrong !!!\n\n\n{ex.InnerException.Message.ToString()}");
            }
            }

        public async Task<IResult<DtResult<Product_variantionQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_variantionQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_variantion, bool>>>(expression);

            //var items = await _repositoryManager.Product_variantionRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_variantionRepository.Find(x => new Product_variantionQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = (int)x.ProductId,
                Price = x.Price,
                qty = x.qty,
                SKU = x.SKU,
                Type = x.Type,
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_variantionRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_variantionQueryDto>>(items);

            var datatableReturned = DtResult<Product_variantionQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_variantionQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_variantionQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_variantion Datatable.", 200);
        }


        public async Task<IResult<Product_variantionQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_variantionRepository.GetById(Id);

            if (item == null) return await Result<Product_variantionQueryDto>.FailAsync("GetProduct_variantionById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_variantionQueryDto>(item);

            return await Result<Product_variantionQueryDto>.SuccessAsync(itemMap, "Product_variantion record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_variantionDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_variantionRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_variantionDDlLViewModels>>.FailAsync("GetProduct_variantionDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_variantionDDLViewModel>(item);

            return await Result<IEnumerable<Product_variantionDDlLViewModels>>.SuccessAsync(item, "Product_variantion DDL records retrieved");
        }
        public async Task<IResult<Product_variantionQueryDto>> Add(Product_variantionDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_variantionQueryDto>.FailAsync("AddProduct_variantion > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_variantionRepository.AddAndReturn(_mapper.Map<Product_variantion>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_variantionQueryDto>(newEntity);

                return await Result<Product_variantionQueryDto>.SuccessAsync(entityMap, "Product_variantion record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_variantionQueryDto>.FailAsync($"AddProduct_variantion > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_variantionRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_variantion > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_variantionRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_variantion record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_variantion > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult> Removemvc(Product_variantionDto entity, CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Product_variantion>(entity);
            //            var item = await _repositoryManager.Product_variantionRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_variantion > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_variantionRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_variantion record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_variantion > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_variantionQueryDto>> Update(Product_variantionDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_variantionQueryDto>.FailAsync($"UpdateProduct_variantion > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_variantionRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_variantionQueryDto>.FailAsync("UpdateProduct_variantion > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_variantionRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_variantionQueryDto>.SuccessAsync(_mapper.Map<Product_variantionQueryDto>(item), "Product_variantion record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_variantionQueryDto>.FailAsync($"UpdateProduct_variantion > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_variantionDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_variantionRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_variantionRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_variantionQueryDto>.SuccessAsync(_mapper.Map<Product_variantionQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_variantionQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
