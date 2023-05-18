using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProviderEvaluation;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProviderEvaluation;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ProviderEvaluationService : IProviderEvaluationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProviderEvaluationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ProviderEvaluationQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ProviderEvaluationRepository.GetAll(x => new ProviderEvaluationQueryDto
            {
                Id = x.Id,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                value=x.value,
                

            });

            var itemMap = _mapper.Map<IEnumerable<ProviderEvaluationQueryDto>>(items);

            return await Result<IEnumerable<ProviderEvaluationQueryDto>>.SuccessAsync(itemMap, "ProviderEvaluation records retrieved");
        }

        public async Task<IResult<DtResult<ProviderEvaluationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ProviderEvaluationRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProviderEvaluationRepository.GetAll(x => new ProviderEvaluationQueryDto
            {
                Id = x.Id,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                value = x.value,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProviderEvaluationRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ProviderEvaluationQueryDto>>(items);

            var datatableReturned = DtResult<ProviderEvaluationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ProviderEvaluationQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProviderEvaluationQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProviderEvaluation Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ProviderEvaluationQueryDto>>> Find(Expression<Func<ProviderEvaluationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProviderEvaluation, bool>>>(expression);

            //var items = await _repositoryManager.ProviderEvaluationRepository.Find(mapExpr);

            var items = await _repositoryManager.ProviderEvaluationRepository.Find(x => new ProviderEvaluationQueryDto
            {
                Id = x.Id,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                value = x.value,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ProviderEvaluationQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ProviderEvaluationQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProviderEvaluationQueryDto>>.SuccessAsync(itemMap, "ProviderEvaluation records retrieved");
        }

        public async Task<IResult<DtResult<ProviderEvaluationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProviderEvaluationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProviderEvaluation, bool>>>(expression);

            //var items = await _repositoryManager.ProviderEvaluationRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProviderEvaluationRepository.Find(x => new ProviderEvaluationQueryDto
            {
                Id = x.Id,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,
                value = x.value,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProviderEvaluationRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ProviderEvaluationQueryDto>>(items);

            var datatableReturned = DtResult<ProviderEvaluationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ProviderEvaluationQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProviderEvaluationQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProviderEvaluation Datatable.", 200);
        }


        public async Task<IResult<ProviderEvaluationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProviderEvaluationRepository.GetById(Id);

            if (item == null) return await Result<ProviderEvaluationQueryDto>.FailAsync("GetProviderEvaluationById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ProviderEvaluationQueryDto>(item);

            return await Result<ProviderEvaluationQueryDto>.SuccessAsync(itemMap, "ProviderEvaluation record retrieved");
        }

        public async Task<IResult<IEnumerable<ProviderEvaluationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProviderEvaluationRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ProviderEvaluationDDlLViewModels>>.FailAsync("GetProviderEvaluationDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ProviderEvaluationDDLViewModel>(item);

            return await Result<IEnumerable<ProviderEvaluationDDlLViewModels>>.SuccessAsync(item, "ProviderEvaluation DDL records retrieved");
        }
        public async Task<IResult<ProviderEvaluationQueryDto>> Add(ProviderEvaluationDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ProviderEvaluationQueryDto>.FailAsync("AddProviderEvaluation > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ProviderEvaluationRepository.AddAndReturn(_mapper.Map<ProviderEvaluation>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ProviderEvaluationQueryDto>(newEntity);

                return await Result<ProviderEvaluationQueryDto>.SuccessAsync(entityMap, "ProviderEvaluation record added");
            }
            catch (Exception exc)
            {

                return await Result<ProviderEvaluationQueryDto>.FailAsync($"AddProviderEvaluation > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProviderEvaluationRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProviderEvaluation > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ProviderEvaluationRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProviderEvaluation record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProviderEvaluation > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ProviderEvaluationQueryDto>> Update(ProviderEvaluationDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ProviderEvaluationQueryDto>.FailAsync($"UpdateProviderEvaluation > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ProviderEvaluationRepository.GetById(entity.Id);

            if (item == null) return await Result<ProviderEvaluationQueryDto>.FailAsync("UpdateProviderEvaluation > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ProviderEvaluationRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProviderEvaluationQueryDto>.SuccessAsync(_mapper.Map<ProviderEvaluationQueryDto>(item), "ProviderEvaluation record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProviderEvaluationQueryDto>.FailAsync($"UpdateProviderEvaluation > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ProviderEvaluationDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProviderEvaluationRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ProviderEvaluationRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProviderEvaluationQueryDto>.SuccessAsync(_mapper.Map<ProviderEvaluationQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProviderEvaluationQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
