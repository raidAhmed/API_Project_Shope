using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ConsultationRequest;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequest;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ConsultationRequestService : IConsultationRequestService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ConsultationRequestService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ConsultationRequestQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ConsultationRequestRepository.GetAll(x => new ConsultationRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                RequestState = x.RequestState,
                ServiceProviderId =(int) x.ServiceProviderId,
                Topic=x.Topic,

            });

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ConsultationRequestQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ConsultationRequestQueryDto>>.SuccessAsync(itemMap, "ConsultationRequest records retrieved");
        }

        public async Task<IResult<DtResult<ConsultationRequestQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ConsultationRequestRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ConsultationRequestRepository.GetAll(x => new ConsultationRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                RequestState = x.RequestState,
                ServiceProviderId = (int)x.ServiceProviderId,
                Topic = x.Topic,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ConsultationRequestRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestQueryDto>>(items);

            var datatableReturned = DtResult<ConsultationRequestQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ConsultationRequestQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ConsultationRequestQueryDto>>.SuccessAsync(datatableReturned, message: "Get ConsultationRequest Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ConsultationRequestQueryDto>>> Find(Expression<Func<ConsultationRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ConsultationRequest, bool>>>(expression);

            //var items = await _repositoryManager.ConsultationRequestRepository.Find(mapExpr);

            var items = await _repositoryManager.ConsultationRequestRepository.Find(x => new ConsultationRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                RequestState = x.RequestState,
                ServiceProviderId = (int)x.ServiceProviderId,
                Topic = x.Topic,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ConsultationRequestQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ConsultationRequestQueryDto>>.SuccessAsync(itemMap, "ConsultationRequest records retrieved");
        }

        public async Task<IResult<DtResult<ConsultationRequestQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ConsultationRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ConsultationRequest, bool>>>(expression);

            //var items = await _repositoryManager.ConsultationRequestRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ConsultationRequestRepository.Find(x => new ConsultationRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                RequestState = x.RequestState,
                ServiceProviderId = (int)x.ServiceProviderId,
                Topic = x.Topic,



            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ConsultationRequestRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestQueryDto>>(items);

            var datatableReturned = DtResult<ConsultationRequestQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ConsultationRequestQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ConsultationRequestQueryDto>>.SuccessAsync(datatableReturned, message: "Get ConsultationRequest Datatable.", 200);
        }


        public async Task<IResult<ConsultationRequestQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ConsultationRequestRepository.GetById(Id);

            if (item == null) return await Result<ConsultationRequestQueryDto>.FailAsync("GetConsultationRequestById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ConsultationRequestQueryDto>(item);

            return await Result<ConsultationRequestQueryDto>.SuccessAsync(itemMap, "ConsultationRequest record retrieved");
        }

        public async Task<IResult<IEnumerable<ConsultationRequestDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ConsultationRequestRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ConsultationRequestDDlLViewModels>>.FailAsync("GetConsultationRequestDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ConsultationRequestDDLViewModel>(item);

            return await Result<IEnumerable<ConsultationRequestDDlLViewModels>>.SuccessAsync(item, "ConsultationRequest DDL records retrieved");
        }
        public async Task<IResult<ConsultationRequestQueryDto>> Add(ConsultationRequestDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ConsultationRequestQueryDto>.FailAsync("AddConsultationRequest > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ConsultationRequestRepository.AddAndReturn(_mapper.Map<ConsultationRequest>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ConsultationRequestQueryDto>(newEntity);

                return await Result<ConsultationRequestQueryDto>.SuccessAsync(entityMap, "ConsultationRequest record added");
            }
            catch (Exception exc)
            {

                return await Result<ConsultationRequestQueryDto>.FailAsync($"AddConsultationRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ConsultationRequestRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveConsultationRequest > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ConsultationRequestRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveConsultationRequest record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveConsultationRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ConsultationRequestQueryDto>> Update(ConsultationRequestDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ConsultationRequestQueryDto>.FailAsync($"UpdateConsultationRequest > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ConsultationRequestRepository.GetById(entity.Id);

            if (item == null) return await Result<ConsultationRequestQueryDto>.FailAsync("UpdateConsultationRequest > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ConsultationRequestRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ConsultationRequestQueryDto>.SuccessAsync(_mapper.Map<ConsultationRequestQueryDto>(item), "ConsultationRequest record updated");
            }
            catch (Exception exc)
            {
                return await Result<ConsultationRequestQueryDto>.FailAsync($"UpdateConsultationRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ConsultationRequestDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ConsultationRequestRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ConsultationRequestRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ConsultationRequestQueryDto>.SuccessAsync(_mapper.Map<ConsultationRequestQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ConsultationRequestQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
