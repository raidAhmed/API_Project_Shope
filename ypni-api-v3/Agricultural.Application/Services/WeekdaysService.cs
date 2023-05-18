using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Weekdays;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class WeekdaysService : IWeekdaysService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WeekdaysService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<WeekdaysQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.WeekdaysRepository.GetAll(x => new WeekdaysQueryDto
            {
                Id = x.Id,
                Name = x.Name
                
                
            });

            var itemMap = _mapper.Map<IEnumerable<WeekdaysQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<WeekdaysQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<WeekdaysQueryDto>>.SuccessAsync(itemMap, "Weekdays records retrieved");
        }

        public async Task<IResult<DtResult<WeekdaysQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.WeekdaysRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WeekdaysRepository.GetAll(x => new WeekdaysQueryDto
            {
                Id = x.Id,
                Name = x.Name

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WeekdaysRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<WeekdaysQueryDto>>(items);

            var datatableReturned = DtResult<WeekdaysQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<WeekdaysQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WeekdaysQueryDto>>.SuccessAsync(datatableReturned, message: "Get Weekdays Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<WeekdaysQueryDto>>> Find(Expression<Func<WeekdaysQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Weekdays, bool>>>(expression);

            //var items = await _repositoryManager.WeekdaysRepository.Find(mapExpr);

            var items = await _repositoryManager.WeekdaysRepository.Find(x => new WeekdaysQueryDto
            {
                Id = x.Id,
                Name = x.Name


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<WeekdaysQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<WeekdaysQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<WeekdaysQueryDto>>.SuccessAsync(itemMap, "Weekdays records retrieved");
        }

        public async Task<IResult<DtResult<WeekdaysQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WeekdaysQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Weekdays, bool>>>(expression);

            //var items = await _repositoryManager.WeekdaysRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WeekdaysRepository.Find(x => new WeekdaysQueryDto
            {
                Id = x.Id,
                Name = x.Name
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WeekdaysRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<WeekdaysQueryDto>>(items);

            var datatableReturned = DtResult<WeekdaysQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any()==false) return await Result<DtResult<WeekdaysQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WeekdaysQueryDto>>.SuccessAsync(datatableReturned, message: "Get Weekdays Datatable.", 200);
        }


        public async Task<IResult<WeekdaysQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.WeekdaysRepository.GetById(Id);

            if (item == null) return await Result<WeekdaysQueryDto>.FailAsync("GetWeekdaysById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<WeekdaysQueryDto>(item);

            return await Result<WeekdaysQueryDto>.SuccessAsync(itemMap, "Weekdays record retrieved");
        }


        public async Task<IResult<WeekdaysQueryDto>> Add(WeekdaysDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<WeekdaysQueryDto>.FailAsync("AddWeekdays > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.WeekdaysRepository.AddAndReturn(_mapper.Map<Weekdays>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<WeekdaysQueryDto>(newEntity);

                return await Result<WeekdaysQueryDto>.SuccessAsync(entityMap, "Weekdays record added");
            }
            catch (Exception exc)
            {

                return await Result<WeekdaysQueryDto>.FailAsync($"AddWeekdays > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.WeekdaysRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveWeekdays > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.WeekdaysRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveWeekdays record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveWeekdays > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<WeekdaysQueryDto>> Update(WeekdaysDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<WeekdaysQueryDto>.FailAsync($"UpdateWeekdays > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.WeekdaysRepository.GetById(entity.Id);

            if (item == null) return await Result<WeekdaysQueryDto>.FailAsync("UpdateWeekdays > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.WeekdaysRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<WeekdaysQueryDto>.SuccessAsync(_mapper.Map<WeekdaysQueryDto>(item), "Weekdays record updated");
            }
            catch (Exception exc)
            {
                return await Result<WeekdaysQueryDto>.FailAsync($"UpdateWeekdays > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
    
    }
}
