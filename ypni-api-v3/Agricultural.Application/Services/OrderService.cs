using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Order;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<OrderQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OrderRepository.GetAll(x => new OrderQueryDto
            {
               Id = x.Id,
               OrderID = x.OrderID,
               Total = x.Total,
               Quntity= x.Quntity,
               ServiceProviderId = x.ServiceProviderId,
               UserId = x.UserId,
               CartId= x.CartId,
               State = x.State,


            });

            var itemMap = _mapper.Map<IEnumerable<OrderQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<OrderQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OrderQueryDto>>.SuccessAsync(itemMap, "Order records retrieved");
        }

        public async Task<IResult<DtResult<OrderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.OrderRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OrderRepository.GetAll(x => new OrderQueryDto
            {
                Id = x.Id,
                OrderID = x.OrderID,
                Total = x.Total,
                Quntity = x.Quntity,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                CartId = x.CartId,
                State = x.State,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OrderRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<OrderQueryDto>>(items);

            var datatableReturned = DtResult<OrderQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<OrderQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OrderQueryDto>>.SuccessAsync(datatableReturned, message: "Get Order Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<OrderQueryDto>>> Find(Expression<Func<OrderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                var mapExpr = _mapper.Map<Expression<Func<Order, bool>>>(expression);

                //var items = await _repositoryManager.OrderRepository.Find(mapExpr);

                var items = await _repositoryManager.OrderRepository.Find(x => new OrderQueryDto
                {
                    Id = x.Id,
                    OrderID = x.OrderID,
                    Total = x.Total,
                    Quntity = x.Quntity,
                    ServiceProviderId = x.ServiceProviderId,
                    UserId = x.UserId,
                    CartId = x.CartId,
                    State = x.State,

                }, mapExpr);

                var itemMap = _mapper.Map<IEnumerable<OrderQueryDto>>(items);
                if (items == null) return await Result<IEnumerable<OrderQueryDto>>.FailAsync("No Data");
                return await Result<IEnumerable<OrderQueryDto>>.SuccessAsync(itemMap, "Order records retrieved");
            }catch (Exception ex)
            {
                 return await Result<IEnumerable<OrderQueryDto>>.FailAsync($"something err in find order  {ex.Message}");

            }
        }

        public async Task<IResult<DtResult<OrderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OrderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Order, bool>>>(expression);

            //var items = await _repositoryManager.OrderRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OrderRepository.Find(x => new OrderQueryDto
            {
                Id = x.Id,
                OrderID = x.OrderID,
                Total = x.Total,
                Quntity = x.Quntity,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                CartId = x.CartId,
                State = x.State,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OrderRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<OrderQueryDto>>(items);

            var datatableReturned = DtResult<OrderQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<OrderQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OrderQueryDto>>.SuccessAsync(datatableReturned, message: "Get Order Datatable.", 200);
        }


        public async Task<IResult<OrderQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OrderRepository.GetById(Id);

            if (item == null) return await Result<OrderQueryDto>.FailAsync("GetOrderById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<OrderQueryDto>(item);

            return await Result<OrderQueryDto>.SuccessAsync(itemMap, "Order record retrieved");
        }

        public async Task<IResult<IEnumerable<OrderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OrderRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<OrderDDlLViewModels>>.FailAsync("GetOrderDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<OrderDDLViewModel>(item);

            return await Result<IEnumerable<OrderDDlLViewModels>>.SuccessAsync(item, "Order DDL records retrieved");
        }
        public async Task<IResult<OrderQueryDto>> Add(OrderDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<OrderQueryDto>.FailAsync("AddOrder > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.OrderRepository.AddAndReturn(_mapper.Map<Order>(entity));

                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<OrderQueryDto>(newEntity);

                return await Result<OrderQueryDto>.SuccessAsync(entityMap, "Order record added");
            }
            catch (Exception exc)
            {

                return await Result<OrderQueryDto>.FailAsync($"AddOrder > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveOrder > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.OrderRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveOrder record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveOrder > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<OrderQueryDto>> Update(OrderDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<OrderQueryDto>.FailAsync($"UpdateOrder > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.OrderRepository.GetById(entity.Id);

            if (item == null) return await Result<OrderQueryDto>.FailAsync("UpdateOrder > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.OrderRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OrderQueryDto>.SuccessAsync(_mapper.Map<OrderQueryDto>(item), "Order record updated");
            }
            catch (Exception exc)
            {
                return await Result<OrderQueryDto>.FailAsync($"UpdateOrder > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(OrderDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OrderRepository.GetById(entity.Id);
            item.Active = !item.Active; 
            item.State = entity.State;
            _repositoryManager.OrderRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OrderQueryDto>.SuccessAsync(_mapper.Map<OrderQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<OrderQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
