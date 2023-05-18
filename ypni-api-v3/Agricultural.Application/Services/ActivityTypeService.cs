using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ActivityType;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ActivityTypeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ActivityTypeQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ActivityTypeRepository.GetAll(x => new ActivityTypeQueryDto
            {
                Id = x.Id,
                ActivityName = x.ActivityName,
                Active=x.Active,
                
                
            });

            var itemMap = _mapper.Map<IEnumerable<ActivityTypeQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ActivityTypeQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<ActivityTypeQueryDto>>.SuccessAsync(itemMap, "ActivityType records retrieved");
        }

        public async Task<IResult<DtResult<ActivityTypeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ActivityTypeRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ActivityTypeRepository.GetAll(x => new ActivityTypeQueryDto
            {
                Id = x.Id,
                ActivityName = x.ActivityName,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ActivityTypeRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ActivityTypeQueryDto>>(items);

            var datatableReturned = DtResult<ActivityTypeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ActivityTypeQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<ActivityTypeQueryDto>>.SuccessAsync(datatableReturned, message: "Get ActivityType Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ActivityTypeQueryDto>>> Find(Expression<Func<ActivityTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ActivityType, bool>>>(expression);

            //var items = await _repositoryManager.ActivityTypeRepository.Find(mapExpr);

            var items = await _repositoryManager.ActivityTypeRepository.Find(x => new ActivityTypeQueryDto
            {
                Id = x.Id,
                ActivityName = x.ActivityName,
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ActivityTypeQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ActivityTypeQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<ActivityTypeQueryDto>>.SuccessAsync(itemMap, "ActivityType records retrieved");
        }

        public async Task<IResult<DtResult<ActivityTypeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ActivityTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ActivityType, bool>>>(expression);

            //var items = await _repositoryManager.ActivityTypeRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ActivityTypeRepository.Find(x => new ActivityTypeQueryDto
            {
                Id = x.Id,
                ActivityName = x.ActivityName,
                Active = x.Active,
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ActivityTypeRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ActivityTypeQueryDto>>(items);

            var datatableReturned = DtResult<ActivityTypeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any()==false) return await Result<DtResult<ActivityTypeQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<ActivityTypeQueryDto>>.SuccessAsync(datatableReturned, message: "Get ActivityType Datatable.", 200);
        }


        public async Task<IResult<ActivityTypeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ActivityTypeRepository.GetById(Id);

            if (item == null) return await Result<ActivityTypeQueryDto>.FailAsync("GetActivityTypeById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ActivityTypeQueryDto>(item);

            return await Result<ActivityTypeQueryDto>.SuccessAsync(itemMap, "ActivityType record retrieved");
        }

        public async Task<IResult<IEnumerable<ActivityTypeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ActivityTypeRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ActivityTypeDDlLViewModels>>.FailAsync("GetActivityTypeDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ActivityTypeDDLViewModel>(item);

            return await Result<IEnumerable<ActivityTypeDDlLViewModels>>.SuccessAsync(item, "ActivityType DDL records retrieved");
        }
        public async Task<IResult<ActivityTypeQueryDto>> Add(ActivityTypeDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ActivityTypeQueryDto>.FailAsync("AddActivityType > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ActivityTypeRepository.AddAndReturn(_mapper.Map<ActivityType>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ActivityTypeQueryDto>(newEntity);

                return await Result<ActivityTypeQueryDto>.SuccessAsync(entityMap, "ActivityType record added");
            }
            catch (Exception exc)
            {

                return await Result<ActivityTypeQueryDto>.FailAsync($"AddActivityType > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ActivityTypeRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveActivityType > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ActivityTypeRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveActivityType record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveActivityType > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ActivityTypeQueryDto>> Update(ActivityTypeDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ActivityTypeQueryDto>.FailAsync($"UpdateActivityType > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ActivityTypeRepository.GetById(entity.Id);

            if (item == null) return await Result<ActivityTypeQueryDto>.FailAsync("UpdateActivityType > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ActivityTypeRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ActivityTypeQueryDto>.SuccessAsync(_mapper.Map<ActivityTypeQueryDto>(item), "ActivityType record updated");
            }
            catch (Exception exc)
            {
                return await Result<ActivityTypeQueryDto>.FailAsync($"UpdateActivityType > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ActivityTypeDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ActivityTypeRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ActivityTypeRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ActivityTypeQueryDto>.SuccessAsync(_mapper.Map<ActivityTypeQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ActivityTypeQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
