using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.CheckOut;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.CheckOut;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CheckOutService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<CheckOutQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CheckOutRepository.GetAll(x => new CheckOutQueryDto
            {
              


            });

            var itemMap = _mapper.Map<IEnumerable<CheckOutQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<CheckOutQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CheckOutQueryDto>>.SuccessAsync(itemMap, "CheckOut records retrieved");
        }

        public async Task<IResult<DtResult<CheckOutQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.CheckOutRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.CheckOutRepository.GetAll(x => new CheckOutQueryDto
            {
                
                

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CheckOutRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<CheckOutQueryDto>>(items);

            var datatableReturned = DtResult<CheckOutQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<CheckOutQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CheckOutQueryDto>>.SuccessAsync(datatableReturned, message: "Get CheckOut Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<CheckOutQueryDto>>> Find(Expression<Func<CheckOutQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<CheckOut, bool>>>(expression);

            //var items = await _repositoryManager.CheckOutRepository.Find(mapExpr);

            var items = await _repositoryManager.CheckOutRepository.Find(x => new CheckOutQueryDto
            {
               
               

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<CheckOutQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<CheckOutQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CheckOutQueryDto>>.SuccessAsync(itemMap, "CheckOut records retrieved");
        }

        public async Task<IResult<DtResult<CheckOutQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CheckOutQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<CheckOut, bool>>>(expression);

            //var items = await _repositoryManager.CheckOutRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.CheckOutRepository.Find(x => new CheckOutQueryDto
            {
                
                

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CheckOutRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<CheckOutQueryDto>>(items);

            var datatableReturned = DtResult<CheckOutQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<CheckOutQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<CheckOutQueryDto>>.SuccessAsync(datatableReturned, message: "Get CheckOut Datatable.", 200);
        }


        public async Task<IResult<CheckOutQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CheckOutRepository.GetById(Id);

            if (item == null) return await Result<CheckOutQueryDto>.FailAsync("GetCheckOutById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<CheckOutQueryDto>(item);

            return await Result<CheckOutQueryDto>.SuccessAsync(itemMap, "CheckOut record retrieved");
        }

        public async Task<IResult<IEnumerable<CheckOutDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CheckOutRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<CheckOutDDlLViewModels>>.FailAsync("GetCheckOutDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<CheckOutDDLViewModel>(item);

            return await Result<IEnumerable<CheckOutDDlLViewModels>>.SuccessAsync(item, "CheckOut DDL records retrieved");
        }
        public async Task<IResult<CheckOutQueryDto>> Add(CheckOutDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<CheckOutQueryDto>.FailAsync("AddCheckOut > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.CheckOutRepository.AddAndReturn(_mapper.Map<CheckOut>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<CheckOutQueryDto>(newEntity);

                return await Result<CheckOutQueryDto>.SuccessAsync(entityMap, "CheckOut record added");
            }
            catch (Exception exc)
            {

                return await Result<CheckOutQueryDto>.FailAsync($"AddCheckOut > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CheckOutRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveCheckOut > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.CheckOutRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveCheckOut record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveCheckOut > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<CheckOutQueryDto>> Update(CheckOutDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<CheckOutQueryDto>.FailAsync($"UpdateCheckOut > the passed entity IS NULL!!!...");

          //  var item = await _repositoryManager.CheckOutRepository.GetById(entity.Id);

          //  if (item == null) return await Result<CheckOutQueryDto>.FailAsync("UpdateCheckOut > the passed entity with the given id NOT EXIEST !!!.");
         //   _mapper.Map(entity, item);
         //   _repositoryManager.CheckOutRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
               // await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return await Result<CheckOutQueryDto>.FailAsync($"UpdateCheckOut > Something went wrong !!!\n\n\n");
                //  return await Result<CheckOutQueryDto>.SuccessAsync(_mapper.Map<CheckOutQueryDto>(item), "CheckOut record updated");
            }
            catch (Exception exc)
            {
                return await Result<CheckOutQueryDto>.FailAsync($"UpdateCheckOut > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(CheckOutDto entity, CancellationToken cancellationToken = default)
        {
           // var item = await _repositoryManager.CheckOutRepository.GetById(entity.Id);
         //   item.Active = !item.Active;
           // _repositoryManager.CheckOutRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return await Result<CheckOutQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n");
             //   return await Result<CheckOutQueryDto>.SuccessAsync(_mapper.Map<CheckOutQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<CheckOutQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
