using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.CartDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.CartDetails;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;


namespace Agricultural.Application.Services
{
    public class CartDetailsService :ICartDetailsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CartDetailsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<CartDetailsQueryDto>> Add(CartDetailsDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<CartDetailsQueryDto>.FailAsync("AddCart > the passed entity IS NULL !!!.");


            try
            {
                var newEntity = await _repositoryManager.CartDetailsRepository.AddAndReturn(_mapper.Map<CartDetails>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<CartDetailsQueryDto>(newEntity);

                return await Result<CartDetailsQueryDto>.SuccessAsync(entityMap, "Cart record added");
            }
            catch (Exception exc)
            {

                return await Result<CartDetailsQueryDto>.FailAsync($"AddCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult<CartDetailsDto>> RemoveAndReturn(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartDetailsRepository.GetById(Id);

            if (item == null) return await Result<CartDetailsDto>.FailAsync("RemoveandReturnCart > the given id NOT EXIEST !!!.");

            try
            {
                var res = _repositoryManager.CartDetailsRepository.RemoveAndReturn(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                var itemMaP = _mapper.Map<CartDetailsDto>(res);
                return await Result<CartDetailsDto>.SuccessAsync(itemMaP, "RemoveCart record deleted");
            }
            catch (Exception exc)
            {

                return await Result<CartDetailsDto>.FailAsync($"RemoveandReturnCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult> ChangeActive(CartDetailsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartDetailsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.CartDetailsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CartDetailsQueryDto>.SuccessAsync(_mapper.Map<CartDetailsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<CartDetailsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult<IEnumerable<CartDetailsQueryDto>>> Find(Expression<Func<CartDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<CartDetails, bool>>>(expression);

            //var items = await _repositoryManager.CartRepository.Find(mapExpr);

            var items = await _repositoryManager.CartDetailsRepository.Find(x => new CartDetailsQueryDto
            {
                Id = x.Id,
                CartId = x.CartId,
                Active = x.Active,
                Price=x.Price,
                ProductId = x.ProductId,
                ServiceProviderId = x.ServiceProviderId.Value,
                UserId=x.UserId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku=x.Sku,
                State = x.State,
                Total = x.Total,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<CartDetailsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<CartDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CartDetailsQueryDto>>.SuccessAsync(itemMap, "Cart Details records retrieved");
        }

        public async Task<IResult<DtResult<CartDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CartDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<CartDetails, bool>>>(expression);

            //var items = await _repositoryManager.CartRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.CartDetailsRepository.Find(x => new CartDetailsQueryDto
            {
                Id = x.Id,
                CartId = x.CartId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                ServiceProviderId = x.ServiceProviderId.Value,
                UserId = x.UserId,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CartDetailsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<CartDetailsQueryDto>>(items);

            var datatableReturned = DtResult<CartDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<CartDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CartDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Cart Details Datatable.", 200);
        }

        public async Task<IResult<IEnumerable<CartDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CartDetailsRepository.GetAll(x => new CartDetailsQueryDto
            {
                Id = x.Id,
                CartId = x.CartId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                ServiceProviderId = x.ServiceProviderId.Value,
                UserId = x.UserId,

            });

            var itemMap = _mapper.Map<IEnumerable<CartDetailsQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<CartDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CartDetailsQueryDto>>.SuccessAsync(itemMap, "Cart Details records retrieved");
        }

        public async Task<IResult<DtResult<CartDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CartDetailsRepository.GetAll(x => new CartDetailsQueryDto
            {
                Id = x.Id,
                CartId = x.CartId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                ServiceProviderId = x.ServiceProviderId.Value,
                UserId = x.UserId,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CartDetailsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<CartDetailsQueryDto>>(items);

            var datatableReturned = DtResult<CartDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<CartDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CartDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Cart Datatable.", 200);

        }

        public async Task<IResult<CartDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartDetailsRepository.GetById(Id);

            if (item == null) return await Result<CartDetailsQueryDto>.FailAsync("GetCartById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<CartDetailsQueryDto>(item);

            return await Result<CartDetailsQueryDto>.SuccessAsync(itemMap, "Cart record retrieved");
        }

        public async Task<IResult<IEnumerable<CartdetailsDDLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartDetailsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<CartdetailsDDLViewModels>>.FailAsync("GetCartDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<CartDDLViewModel>(item);

            return await Result<IEnumerable<CartdetailsDDLViewModels>>.SuccessAsync(item, "Cart DDL records retrieved");

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CartDetailsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveCart > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.CartDetailsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveCart record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<CartDetailsQueryDto>> Update(CartDetailsDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<CartDetailsQueryDto>.FailAsync($"UpdateCart > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.CartDetailsRepository.GetById(entity.Id);

            if (item == null) return await Result<CartDetailsQueryDto>.FailAsync("UpdateCart > the passed entity with the given id NOT EXIEST !!!.");

           
            _mapper.Map(entity, item);
            _repositoryManager.CartDetailsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CartDetailsQueryDto>.SuccessAsync(_mapper.Map<CartDetailsQueryDto>(item), "Cart record updated");
            }
            catch (Exception exc)
            {
                return await Result<CartDetailsQueryDto>.FailAsync($"UpdateCart > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
    }
}
