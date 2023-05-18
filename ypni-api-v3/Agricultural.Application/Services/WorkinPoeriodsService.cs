using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.WorkinPoeriods;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class WorkinPoeriodsService : IWorkinPoeriodsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WorkinPoeriodsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<WorkinPoeriodsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.WorkinPoeriodsRepository.GetAll(x => new WorkinPoeriodsQueryDto
            {
                Id = x.Id,
                Name = x.Name


            });

            var itemMap = _mapper.Map<IEnumerable<WorkinPoeriodsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<WorkinPoeriodsQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<WorkinPoeriodsQueryDto>>.SuccessAsync(itemMap, "WorkinPoeriods records retrieved");
        }

        public async Task<IResult<DtResult<WorkinPoeriodsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.WorkinPoeriodsRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WorkinPoeriodsRepository.GetAll(x => new WorkinPoeriodsQueryDto
            {
                Id = x.Id,
                Name = x.Name

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WorkinPoeriodsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<WorkinPoeriodsQueryDto>>(items);

            var datatableReturned = DtResult<WorkinPoeriodsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<WorkinPoeriodsQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WorkinPoeriodsQueryDto>>.SuccessAsync(datatableReturned, message: "Get WorkinPoeriods Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<WorkinPoeriodsQueryDto>>> Find(Expression<Func<WorkinPoeriodsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<WorkinPoeriods, bool>>>(expression);

            //var items = await _repositoryManager.WorkinPoeriodsRepository.Find(mapExpr);

            var items = await _repositoryManager.WorkinPoeriodsRepository.Find(x => new WorkinPoeriodsQueryDto
            {
                Id = x.Id,
                Name = x.Name


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<WorkinPoeriodsQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<WorkinPoeriodsQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<WorkinPoeriodsQueryDto>>.SuccessAsync(itemMap, "WorkinPoeriods records retrieved");
        }

        public async Task<IResult<DtResult<WorkinPoeriodsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WorkinPoeriodsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<WorkinPoeriods, bool>>>(expression);

            //var items = await _repositoryManager.WorkinPoeriodsRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.WorkinPoeriodsRepository.Find(x => new WorkinPoeriodsQueryDto
            {
                Id = x.Id,
                Name = x.Name
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.WorkinPoeriodsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<WorkinPoeriodsQueryDto>>(items);

            var datatableReturned = DtResult<WorkinPoeriodsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<WorkinPoeriodsQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<WorkinPoeriodsQueryDto>>.SuccessAsync(datatableReturned, message: "Get WorkinPoeriods Datatable.", 200);
        }


        public async Task<IResult<WorkinPoeriodsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.WorkinPoeriodsRepository.GetById(Id);

            if (item == null) return await Result<WorkinPoeriodsQueryDto>.FailAsync("GetWorkinPoeriodsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<WorkinPoeriodsQueryDto>(item);

            return await Result<WorkinPoeriodsQueryDto>.SuccessAsync(itemMap, "WorkinPoeriods record retrieved");
        }


        public async Task<IResult<WorkinPoeriodsQueryDto>> Add(WorkinPoeriodsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<WorkinPoeriodsQueryDto>.FailAsync("AddWorkinPoeriods > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.WorkinPoeriodsRepository.AddAndReturn(_mapper.Map<WorkinPoeriods>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<WorkinPoeriodsQueryDto>(newEntity);

                return await Result<WorkinPoeriodsQueryDto>.SuccessAsync(entityMap, "WorkinPoeriods record added");
            }
            catch (Exception exc)
            {

                return await Result<WorkinPoeriodsQueryDto>.FailAsync($"AddWorkinPoeriods > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.WorkinPoeriodsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveWorkinPoeriods > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.WorkinPoeriodsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveWorkinPoeriods record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveWorkinPoeriods > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<WorkinPoeriodsQueryDto>> Update(WorkinPoeriodsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<WorkinPoeriodsQueryDto>.FailAsync($"UpdateWorkinPoeriods > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.WorkinPoeriodsRepository.GetById(entity.Id);

            if (item == null) return await Result<WorkinPoeriodsQueryDto>.FailAsync("UpdateWorkinPoeriods > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.WorkinPoeriodsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<WorkinPoeriodsQueryDto>.SuccessAsync(_mapper.Map<WorkinPoeriodsQueryDto>(item), "WorkinPoeriods record updated");
            }
            catch (Exception exc)
            {
                return await Result<WorkinPoeriodsQueryDto>.FailAsync($"UpdateWorkinPoeriods > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

    }
}
