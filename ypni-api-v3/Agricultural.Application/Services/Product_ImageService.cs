using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Image;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class Product_ImageService : IProduct_ImageService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_ImageService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<Product_ImageQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_ImageRepository.GetAll(x => new Product_ImageQueryDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ProductId = x.ProductId,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_ImageQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_ImageQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_ImageQueryDto>>.SuccessAsync(itemMap, "Product_Image records retrieved");
        }

        public async Task<IResult<DtResult<Product_ImageQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_ImageRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_ImageRepository.GetAll(x => new Product_ImageQueryDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ProductId = x.ProductId,



            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_ImageRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_ImageQueryDto>>(items);

            var datatableReturned = DtResult<Product_ImageQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_ImageQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_ImageQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Image Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<Product_ImageQueryDto>>> Find(Expression<Func<Product_ImageQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Image, bool>>>(expression);

            //var items = await _repositoryManager.Product_ImageRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageQueryDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ProductId = x.ProductId,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_ImageQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<Product_ImageQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_ImageQueryDto>>.SuccessAsync(itemMap, "Product_Image records retrieved");
        }

        public async Task<IResult<DtResult<Product_ImageQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_ImageQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_Image, bool>>>(expression);

            //var items = await _repositoryManager.Product_ImageRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageQueryDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ProductId = x.ProductId,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_ImageRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_ImageQueryDto>>(items);

            var datatableReturned = DtResult<Product_ImageQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<Product_ImageQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_ImageQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_Image Datatable.", 200);
        }


        public async Task<IResult<Product_ImageQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_ImageRepository.GetById(Id);

            if (item == null) return await Result<Product_ImageQueryDto>.FailAsync("GetProduct_ImageById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_ImageQueryDto>(item);

            return await Result<Product_ImageQueryDto>.SuccessAsync(itemMap, "Product_Image record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_ImageDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_ImageRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_ImageDDlLViewModels>>.FailAsync("GetProduct_ImageDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_ImageDDLViewModel>(item);

            return await Result<IEnumerable<Product_ImageDDlLViewModels>>.SuccessAsync(item, "Product_Image DDL records retrieved");
        }
        public async Task<IResult<Product_ImageQueryDto>> Add(Product_ImageDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_ImageQueryDto>.FailAsync("AddProduct_Image > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_ImageRepository.AddAndReturn(_mapper.Map<Product_Image>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_ImageQueryDto>(newEntity);

                return await Result<Product_ImageQueryDto>.SuccessAsync(entityMap, "Product_Image record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_ImageQueryDto>.FailAsync($"AddProduct_Image > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_ImageRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_Image > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_ImageRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Image record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Image > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> Removemvc(Product_ImageDto entity, CancellationToken cancellationToken = default)
        {
            var item = _mapper.Map<Product_Image>(entity);

            if (item == null) return await Result.FailAsync("RemoveProduct_Image > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_ImageRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_Image record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_Image > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_ImageQueryDto>> Update(Product_ImageDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_ImageQueryDto>.FailAsync($"UpdateProduct_Image > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_ImageRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_ImageQueryDto>.FailAsync("UpdateProduct_Image > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_ImageRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_ImageQueryDto>.SuccessAsync(_mapper.Map<Product_ImageQueryDto>(item), "Product_Image record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_ImageQueryDto>.FailAsync($"UpdateProduct_Image > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_ImageDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_ImageRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.Product_ImageRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_ImageQueryDto>.SuccessAsync(_mapper.Map<Product_ImageQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_ImageQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
