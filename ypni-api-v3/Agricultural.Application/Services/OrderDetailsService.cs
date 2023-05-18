using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.OrderDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<OrderDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderDetailsRepository.GetAll(x => new OrderDetailsQueryDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,

            });

            var itemMap = _mapper.Map<IEnumerable<OrderDetailsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<OrderDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OrderDetailsQueryDto>>.SuccessAsync(itemMap, "OrderDetails records retrieved");
        }

        public async Task<IResult<DtResult<OrderDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.OrderDetailsRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OrderDetailsRepository.GetAll(x => new OrderDetailsQueryDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,



            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OrderDetailsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<OrderDetailsQueryDto>>(items);

            var datatableReturned = DtResult<OrderDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<OrderDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OrderDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get OrderDetails Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<OrderDetailsQueryDto>>> Find(Expression<Func<OrderDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<OrderDetails, bool>>>(expression);

            //var items = await _repositoryManager.OrderDetailsRepository.Find(mapExpr);

            var items = await _repositoryManager.OrderDetailsRepository.Find(x => new OrderDetailsQueryDto
            {
                Id = x.Id,
                //OrderId = x.OrderId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                OrderId = x.OrderId,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,
                

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<OrderDetailsQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<OrderDetailsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OrderDetailsQueryDto>>.SuccessAsync(itemMap, "OrderDetails records retrieved");
        }
        
        public async Task<IResult<DtResult<OrderDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OrderDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<OrderDetails, bool>>>(expression);

            //var items = await _repositoryManager.OrderDetailsRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OrderDetailsRepository.Find(x => new OrderDetailsQueryDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                Active = x.Active,
                Price = x.Price,
                ProductId = x.ProductId,
                Product_variantionId = x.Product_variantionId,
                Quantity = (int)x.Quantity,
                Sku = x.Sku,
                State = x.State,
                Total = x.Total,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OrderDetailsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<OrderDetailsQueryDto>>(items);

            var datatableReturned = DtResult<OrderDetailsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<OrderDetailsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OrderDetailsQueryDto>>.SuccessAsync(datatableReturned, message: "Get OrderDetails Datatable.", 200);
        }


        public async Task<IResult<OrderDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OrderDetailsRepository.GetById(Id);

            if (item == null) return await Result<OrderDetailsQueryDto>.FailAsync("GetOrderDetailsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<OrderDetailsQueryDto>(item);

            return await Result<OrderDetailsQueryDto>.SuccessAsync(itemMap, "OrderDetails record retrieved");
        }

        public async Task<IResult<IEnumerable<OrderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OrderDetailsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<OrderDDlLViewModels>>.FailAsync("GetOrderDetailsDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<OrderDetailsDDLViewModel>(item);

            return await Result<IEnumerable<OrderDDlLViewModels>>.SuccessAsync(item, "OrderDetails DDL records retrieved");
        }
        public async Task<IResult<OrderDetailsQueryDto>> Add(OrderDetailsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<OrderDetailsQueryDto>.FailAsync("AddOrderDetails > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.OrderDetailsRepository.AddAndReturn(_mapper.Map<OrderDetails>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<OrderDetailsQueryDto>(newEntity);

                return await Result<OrderDetailsQueryDto>.SuccessAsync(entityMap, "OrderDetails record added");
            }
            catch (Exception exc)
            {

                return await Result<OrderDetailsQueryDto>.FailAsync($"AddOrderDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderDetailsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveOrderDetails > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.OrderDetailsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveOrderDetails record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveOrderDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<OrderDetailsQueryDto>> Update(OrderDetailsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<OrderDetailsQueryDto>.FailAsync($"UpdateOrderDetails > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.OrderDetailsRepository.GetById(entity.Id);

            if (item == null) return await Result<OrderDetailsQueryDto>.FailAsync("UpdateOrderDetails > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.OrderDetailsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OrderDetailsQueryDto>.SuccessAsync(_mapper.Map<OrderDetailsQueryDto>(item), "OrderDetails record updated");
            }
            catch (Exception exc)
            {
                return await Result<OrderDetailsQueryDto>.FailAsync($"UpdateOrderDetails > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(OrderDetailsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderDetailsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.OrderDetailsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OrderDetailsQueryDto>.SuccessAsync(_mapper.Map<OrderDetailsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<OrderDetailsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
