using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Colors;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_ColorsService : IProduct_ColorsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_ColorsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<Product_ColorsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_ColorsRepository.GetAll(x => new Product_ColorsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = x.ProductId,
                ColorId = x.ColorId,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_ColorsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_ColorsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_ColorsQueryDto>>.SuccessAsync(itemMap, "Product_Colors records retrieved");
        }

        public async Task<IResult<DtResult<Product_ColorsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.Product_ColorsRepository.GetAll(x => new Product_ColorsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = x.ProductId,
                ColorId = x.ColorId,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_ColorsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_ColorsQueryDto>>(items);

            var datatableReturned = DtResult<Product_ColorsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_ColorsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_ColorsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Colors Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<Product_ColorsQueryDto>>> Find(Expression<Func<Product_ColorsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Colors, bool>>>(expression);

            var items = await _repositoryManager.Product_ColorsRepository.Find(x => new Product_ColorsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = x.ProductId,
                ColorId = x.ColorId,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_ColorsQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_ColorsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_ColorsQueryDto>>.SuccessAsync(itemMap, "Product_Colors records retrieved");
        }

        public async Task<IResult<DtResult<Product_ColorsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_ColorsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Colors, bool>>>(expression);

            var items = await _repositoryManager.Product_ColorsRepository.Find(x => new Product_ColorsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                ProductId = x.ProductId,
                ColorId = x.ColorId,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_ColorsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_ColorsQueryDto>>(items);

            var datatableReturned = DtResult<Product_ColorsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_ColorsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_ColorsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Colors Datatable.", 200);
        }


        public async Task<IResult<Product_ColorsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_ColorsRepository.GetById(Id);

            if (item == null) return await Result<Product_ColorsQueryDto>.FailAsync("GetProduct_ColorsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_ColorsQueryDto>(item);

            return await Result<Product_ColorsQueryDto>.SuccessAsync(itemMap, "Product_Colors record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_ColorsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_ColorsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_ColorsDDlLViewModels>>.FailAsync("GetProduct_ColorsDDL > ERRORS !!!...");

            return await Result<IEnumerable<Product_ColorsDDlLViewModels>>.SuccessAsync(item, "Product_Colors DDL records retrieved");
        }
        public async Task<IResult<Product_ColorsQueryDto>> Add(Product_ColorsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_ColorsQueryDto>.FailAsync("AddProduct_Colors > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.Product_ColorsRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<Product_ColorsQueryDto>.FailAsync("AddProduct_Colors > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_ColorsRepository.AddAndReturn(_mapper.Map<Product_Colors>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_ColorsQueryDto>(newEntity);

                return await Result<Product_ColorsQueryDto>.SuccessAsync(entityMap, "Product_Colors record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_ColorsQueryDto>.FailAsync($"AddProduct_Colors > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_ColorsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_Colors > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_ColorsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Colors record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Colors > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> Removemvc(Product_ColorsDto entity, CancellationToken cancellationToken = default)
        {
            //  var item = await _repositoryManager.Product_ColorsRepository.GetById(Id);

            if (entity == null) return await Result.FailAsync("RemoveProduct_Colors > the given id NOT EXIEST !!!.");

            try
            {
                var item = _mapper.Map<Product_Colors>(entity);
                _repositoryManager.Product_ColorsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Colors record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Colors > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_ColorsQueryDto>> Update(Product_ColorsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_ColorsQueryDto>.FailAsync($"UpdateProduct_Colors > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_ColorsRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_ColorsQueryDto>.FailAsync("UpdateProduct_Colors > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.Product_ColorsRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_ColorsQueryDto>.SuccessAsync(_mapper.Map<Product_ColorsQueryDto>(item), "Product_Colors record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_ColorsQueryDto>.FailAsync($"UpdateProduct_Colors > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_ColorsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_ColorsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_ColorsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_ColorsQueryDto>.SuccessAsync(_mapper.Map<Product_ColorsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_ColorsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
