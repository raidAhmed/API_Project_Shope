using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SupportRequest;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SupportRequest;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SupportRequestService : ISupportRequestService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SupportRequestService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<SupportRequestQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SupportRequestRepository.GetAll(x => new SupportRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId =(int) x.FarmerId,
                ImageUrl = x.ImageUrl,
                OfficialPartyId =(int)x.OfficialPartyId,
                requestState = x.requestState,
                Topic=x.Topic,

            });

            var itemMap = _mapper.Map<IEnumerable<SupportRequestQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SupportRequestQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SupportRequestQueryDto>>.SuccessAsync(itemMap, "SupportRequest records retrieved");
        }

        public async Task<IResult<DtResult<SupportRequestQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SupportRequestRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SupportRequestRepository.GetAll(x => new SupportRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                ImageUrl = x.ImageUrl,
                OfficialPartyId = (int)x.OfficialPartyId,
                requestState = x.requestState,
                Topic = x.Topic,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SupportRequestRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SupportRequestQueryDto>>(items);

            var datatableReturned = DtResult<SupportRequestQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SupportRequestQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SupportRequestQueryDto>>.SuccessAsync(datatableReturned, message: "Get SupportRequest Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<SupportRequestQueryDto>>> Find(Expression<Func<SupportRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SupportRequest, bool>>>(expression);

            //var items = await _repositoryManager.SupportRequestRepository.Find(mapExpr);

            var items = await _repositoryManager.SupportRequestRepository.Find(x => new SupportRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                ImageUrl = x.ImageUrl,
                OfficialPartyId = (int)x.OfficialPartyId,
                requestState = x.requestState,
                Topic = x.Topic,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SupportRequestQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<SupportRequestQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SupportRequestQueryDto>>.SuccessAsync(itemMap, "SupportRequest records retrieved");
        }

        public async Task<IResult<DtResult<SupportRequestQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SupportRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SupportRequest, bool>>>(expression);

            //var items = await _repositoryManager.SupportRequestRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SupportRequestRepository.Find(x => new SupportRequestQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                Description = x.Description,
                FarmerId = (int)x.FarmerId,
                ImageUrl = x.ImageUrl,
                OfficialPartyId = (int)x.OfficialPartyId,
                requestState = x.requestState,
                Topic = x.Topic,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SupportRequestRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SupportRequestQueryDto>>(items);

            var datatableReturned = DtResult<SupportRequestQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<SupportRequestQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SupportRequestQueryDto>>.SuccessAsync(datatableReturned, message: "Get SupportRequest Datatable.", 200);
        }


        public async Task<IResult<SupportRequestQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SupportRequestRepository.GetById(Id);

            if (item == null) return await Result<SupportRequestQueryDto>.FailAsync("GetSupportRequestById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SupportRequestQueryDto>(item);

            return await Result<SupportRequestQueryDto>.SuccessAsync(itemMap, "SupportRequest record retrieved");
        }

        public async Task<IResult<IEnumerable<SupportRequestDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SupportRequestRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SupportRequestDDlLViewModels>>.FailAsync("GetSupportRequestDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<SupportRequestDDLViewModel>(item);

            return await Result<IEnumerable<SupportRequestDDlLViewModels>>.SuccessAsync(item, "SupportRequest DDL records retrieved");
        }
        public async Task<IResult<SupportRequestQueryDto>> Add(SupportRequestDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SupportRequestQueryDto>.FailAsync("AddSupportRequest > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.SupportRequestRepository.AddAndReturn(_mapper.Map<SupportRequest>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SupportRequestQueryDto>(newEntity);

                return await Result<SupportRequestQueryDto>.SuccessAsync(entityMap, "SupportRequest record added");
            }
            catch (Exception exc)
            {

                return await Result<SupportRequestQueryDto>.FailAsync($"AddSupportRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SupportRequestRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSupportRequest > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SupportRequestRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSupportRequest record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSupportRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SupportRequestQueryDto>> Update(SupportRequestDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SupportRequestQueryDto>.FailAsync($"UpdateSupportRequest > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SupportRequestRepository.GetById(entity.Id);

            if (item == null) return await Result<SupportRequestQueryDto>.FailAsync("UpdateSupportRequest > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SupportRequestRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SupportRequestQueryDto>.SuccessAsync(_mapper.Map<SupportRequestQueryDto>(item), "SupportRequest record updated");
            }
            catch (Exception exc)
            {
                return await Result<SupportRequestQueryDto>.FailAsync($"UpdateSupportRequest > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SupportRequestDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SupportRequestRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SupportRequestRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SupportRequestQueryDto>.SuccessAsync(_mapper.Map<SupportRequestQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SupportRequestQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
