using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Cart;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Cart;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CartService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<CartQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CartRepository.GetAll(x => new CartQueryDto
            {
                Id = x.Id,
                Sku=x.Sku,
                State=x.State,
                Total=x.Total,
                UserId=x.UserId,
               ServiceProviderId=x.ServiceProviderId,

            });

            var itemMap = _mapper.Map<IEnumerable<CartQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<CartQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CartQueryDto>>.SuccessAsync(itemMap, "Cart records retrieved");
        }

        public async Task<IResult<DtResult<CartQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.CartRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.CartRepository.GetAll(x => new CartQueryDto
            {
                Id = x.Id,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                UserId = x.UserId,
                ServiceProviderId=x.ServiceProviderId,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CartRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<CartQueryDto>>(items);

            var datatableReturned = DtResult<CartQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<CartQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CartQueryDto>>.SuccessAsync(datatableReturned, message: "Get Cart Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<CartQueryDto>>> Find(Expression<Func<CartQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Cart, bool>>>(expression);

            //var items = await _repositoryManager.CartRepository.Find(mapExpr);
             
            var items = await _repositoryManager.CartRepository.Find(x => new CartQueryDto
            {
                Id = x.Id,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total, 
                UserId = x.UserId,
                ServiceProviderId=x.ServiceProviderId, 
                 
            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<CartQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<CartQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CartQueryDto>>.SuccessAsync(itemMap, "Cart records retrieved");
        }

        public async Task<IResult<DtResult<CartQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CartQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Cart, bool>>>(expression);

            //var items = await _repositoryManager.CartRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.CartRepository.Find(x => new CartQueryDto
            {
                Id = x.Id,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                UserId = x.UserId,
                ServiceProviderId= x.ServiceProviderId, 
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CartRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<CartQueryDto>>(items);

            var datatableReturned = DtResult<CartQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<CartQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CartQueryDto>>.SuccessAsync(datatableReturned, message: "Get Cart Datatable.", 200);
        }


        public async Task<IResult<CartQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CartRepository.GetById(Id);

            if (item == null) return await Result<CartQueryDto>.FailAsync("GetCartById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<CartQueryDto>(item);

            return await Result<CartQueryDto>.SuccessAsync(itemMap, "Cart record retrieved");
        }

        public async Task<IResult<IEnumerable<CartDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CartRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<CartDDlLViewModels>>.FailAsync("GetCartDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<CartDDLViewModel>(item);

            return await Result<IEnumerable<CartDDlLViewModels>>.SuccessAsync(item, "Cart DDL records retrieved");
        }
        public async Task<IResult<CartQueryDto>> Add(CartDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<CartQueryDto>.FailAsync("AddCart > the passed entity IS NULL !!!.");


            try
            {
                var newEntity = await _repositoryManager.CartRepository.AddAndReturn(_mapper.Map<Cart>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<CartQueryDto>(newEntity);

                return await Result<CartQueryDto>.SuccessAsync(entityMap, "Cart record added");
            }
            catch (Exception exc)
            {

                return await Result<CartQueryDto>.FailAsync($"AddCart > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }


        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveCart > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.CartRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveCart record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<CartQueryDto>> Update(CartDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<CartQueryDto>.FailAsync($"UpdateCart > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.CartRepository.GetById(entity.Id);

            if (item == null) return await Result<CartQueryDto>.FailAsync("UpdateCart > the passed entity with the given id NOT EXIEST !!!.");

            //var entityDb = await _repositoryManager.CartRepository.Find(x =>  x.Name.Contains(entity.Name) && x.Id != entity.Id);

            //if (entityDb != null && entityDb.Count() > 0) return await Result<CartQueryDto>.FailAsync("UpdateCart > the same record IS ALREADY EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.CartRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CartQueryDto>.SuccessAsync(_mapper.Map<CartQueryDto>(item), "Cart record updated");
            }
            catch (Exception exc)
            {
                return await Result<CartQueryDto>.FailAsync($"UpdateCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(CartDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.CartRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CartQueryDto>.SuccessAsync(_mapper.Map<CartQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<CartQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
