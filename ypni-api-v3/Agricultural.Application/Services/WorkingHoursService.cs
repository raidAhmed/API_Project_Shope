using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.WorkingHours;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class WorkingHoursService : IWorkingHoursService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WorkingHoursService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<WorkingHoursQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.WorkingHoursRepository.GetAll(x => new WorkingHoursQueryDto
            {
                Id = x.Id,
                FromTime = x.FromTime,
                ToTime=x.ToTime,
                ServiceProviderId=x.ServiceProviderId,
                ServiceProviderName=x.ServiceProvider.TradeName,
                WeekdaysId=x.WeekdaysId,
                DayName=x.Weekdays.Name,
                WorkinPoeriodsId=x.WorkinPoeriodsId,
                PoriodName=x.WorkinPoeriods.Name,
                State=x.State,
                Active=x.Active,
                
            });

            var itemMap = _mapper.Map<IEnumerable<WorkingHoursQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<WorkingHoursQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<WorkingHoursQueryDto>>.SuccessAsync(itemMap, "WorkingHours records retrieved");
        }

        public async Task<IResult<DtResult<WorkingHoursQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.WorkingHoursRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WorkingHoursRepository.GetAll(x => new WorkingHoursQueryDto
            {
                Id = x.Id,
                FromTime = x.FromTime,
                ToTime = x.ToTime,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                WeekdaysId = x.WeekdaysId,
                DayName = x.Weekdays.Name,
                WorkinPoeriodsId = x.WorkinPoeriodsId,
                PoriodName = x.WorkinPoeriods.Name,
                State = x.State,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WorkingHoursRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<WorkingHoursQueryDto>>(items);

            var datatableReturned = DtResult<WorkingHoursQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<WorkingHoursQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WorkingHoursQueryDto>>.SuccessAsync(datatableReturned, message: "Get WorkingHours Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<WorkingHoursQueryDto>>> Find(Expression<Func<WorkingHoursQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<WorkingHours, bool>>>(expression);

            //var items = await _repositoryManager.WorkingHoursRepository.Find(mapExpr);

            var items = await _repositoryManager.WorkingHoursRepository.Find(x => new WorkingHoursQueryDto
            {
                Id = x.Id,
                FromTime = x.FromTime,
                ToTime = x.ToTime,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                WeekdaysId = x.WeekdaysId,
                DayName = x.Weekdays.Name,
                WorkinPoeriodsId = x.WorkinPoeriodsId,
                PoriodName = x.WorkinPoeriods.Name,
                State = x.State,
                Active = x.Active,

            }, mapExpr); 

            var itemMap = _mapper.Map<IEnumerable<WorkingHoursQueryDto>>(items);
          //  if (items == null) return await Result<IEnumerable<WorkingHoursQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<WorkingHoursQueryDto>>.SuccessAsync(itemMap, "WorkingHours records retrieved");
        }

        public async Task<IResult<DtResult<WorkingHoursQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WorkingHoursQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<WorkingHours, bool>>>(expression);

            //var items = await _repositoryManager.WorkingHoursRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WorkingHoursRepository.Find(x => new WorkingHoursQueryDto
            {
                Id = x.Id,
                FromTime = x.FromTime,
                ToTime = x.ToTime,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                WeekdaysId = x.WeekdaysId,
                DayName = x.Weekdays.Name,
                WorkinPoeriodsId = x.WorkinPoeriodsId,
                PoriodName = x.WorkinPoeriods.Name,
                State = x.State,
                Active = x.Active,
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WorkingHoursRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<WorkingHoursQueryDto>>(items);

            var datatableReturned = DtResult<WorkingHoursQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
           // if (items == null) return await Result<DtResult<WorkingHoursQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WorkingHoursQueryDto>>.SuccessAsync(datatableReturned, message: "Get WorkingHours Datatable.", 200);
        }


        public async Task<IResult<WorkingHoursQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.WorkingHoursRepository.GetById(Id);

            if (item == null) return await Result<WorkingHoursQueryDto>.FailAsync("GetWorkingHoursById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<WorkingHoursQueryDto>(item);

            return await Result<WorkingHoursQueryDto>.SuccessAsync(itemMap, "WorkingHours record retrieved");
        }

     public async Task<IResult<WorkingHoursQueryDto>> Add(WorkingHoursDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<WorkingHoursQueryDto>.FailAsync("AddWorkingHours > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.WorkingHoursRepository.AddAndReturn(_mapper.Map<WorkingHours>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<WorkingHoursQueryDto>(newEntity);

                return await Result<WorkingHoursQueryDto>.SuccessAsync(entityMap, "WorkingHours record added");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message.ToString());
                return await Result<WorkingHoursQueryDto>.FailAsync($"AddWorkingHours > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.WorkingHoursRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveWorkingHours > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.WorkingHoursRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveWorkingHours record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveWorkingHours > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<WorkingHoursQueryDto>> Update(WorkingHoursDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<WorkingHoursQueryDto>.FailAsync($"UpdateWorkingHours > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.WorkingHoursRepository.GetById(entity.Id);

            if (item == null) return await Result<WorkingHoursQueryDto>.FailAsync("UpdateWorkingHours > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.WorkingHoursRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<WorkingHoursQueryDto>.SuccessAsync(_mapper.Map<WorkingHoursQueryDto>(item), "WorkingHours record updated");
            }
            catch (Exception exc)
            {
                return await Result<WorkingHoursQueryDto>.FailAsync($"UpdateWorkingHours > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(WorkingHoursDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.WorkingHoursRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.WorkingHoursRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<WorkingHoursQueryDto>.SuccessAsync(_mapper.Map<WorkingHoursQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<WorkingHoursQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
