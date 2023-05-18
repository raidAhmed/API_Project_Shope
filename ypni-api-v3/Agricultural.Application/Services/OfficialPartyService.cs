using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.OfficialParty;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.OfficialParty;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class OfficialPartyService : IOfficialPartyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OfficialPartyService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<OfficialPartyQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OfficialPartyRepository.GetAll(x => new OfficialPartyQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                OrganisationType = x.OrganisationType,
                ServiceProviderId=(int)x.ServiceProviderId,

            });

            var itemMap = _mapper.Map<IEnumerable<OfficialPartyQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<OfficialPartyQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OfficialPartyQueryDto>>.SuccessAsync(itemMap, "OfficialParty records retrieved");
        }

        public async Task<IResult<DtResult<OfficialPartyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.OfficialPartyRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OfficialPartyRepository.GetAll(x => new OfficialPartyQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                OrganisationType = x.OrganisationType,
                ServiceProviderId = (int)x.ServiceProviderId,



            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OfficialPartyRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<OfficialPartyQueryDto>>(items);

            var datatableReturned = DtResult<OfficialPartyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<OfficialPartyQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OfficialPartyQueryDto>>.SuccessAsync(datatableReturned, message: "Get OfficialParty Datatable.", 200);

        }


        public async Task<IResult<OfficialPartyDto>> Find(Expression<Func<OfficialPartyDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<OfficialParty, bool>>>(expression);

            //var items = await _repositoryManager.OfficialPartyRepository.Find(mapExpr);

            var items = await _repositoryManager.OfficialPartyRepository.Find(mapExpr);
            var recored = items.OrderBy(x => x.Id).LastOrDefault();

            var itemMap = _mapper.Map<OfficialPartyDto>(recored);
            if (items == null || items.Any() == false) return await Result<OfficialPartyDto>.FailAsync("No Data");
            return await Result<OfficialPartyDto>.SuccessAsync(itemMap, "OfficialParty records retrieved");
        }

        public async Task<IResult<DtResult<OfficialPartyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OfficialPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<OfficialParty, bool>>>(expression);

            //var items = await _repositoryManager.OfficialPartyRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OfficialPartyRepository.Find(x => new OfficialPartyQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                OrganisationType = x.OrganisationType,
                ServiceProviderId=(int)x.ServiceProviderId

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OfficialPartyRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<OfficialPartyQueryDto>>(items);

            var datatableReturned = DtResult<OfficialPartyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<OfficialPartyQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OfficialPartyQueryDto>>.SuccessAsync(datatableReturned, message: "Get OfficialParty Datatable.", 200);
        }


        public async Task<IResult<OfficialPartyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OfficialPartyRepository.GetById(Id);

            if (item == null) return await Result<OfficialPartyQueryDto>.FailAsync("GetOfficialPartyById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<OfficialPartyQueryDto>(item);

            return await Result<OfficialPartyQueryDto>.SuccessAsync(itemMap, "OfficialParty record retrieved");
        }

        public async Task<IResult<IEnumerable<OfficialPartyDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OfficialPartyRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<OfficialPartyDDlLViewModels>>.FailAsync("GetOfficialPartyDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<OfficialPartyDDLViewModel>(item);

            return await Result<IEnumerable<OfficialPartyDDlLViewModels>>.SuccessAsync(item, "OfficialParty DDL records retrieved");
        }
        public async Task<IResult<OfficialPartyQueryDto>> Add(OfficialPartyDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<OfficialPartyQueryDto>.FailAsync("AddOfficialParty > the passed entity IS NULL !!!.");

            try
            {
                var newob = new OfficialParty
                {
                    Id = Convert.ToInt32(entity.Id),
                    ServiceProviderId = Convert.ToInt32(entity.ServiceProviderId),
                    Active = Convert.ToBoolean(entity.Active),
                    OrganisationType = entity.OrganisationType,
                };
                var newEntity = await _repositoryManager.OfficialPartyRepository.AddAndReturn(newob);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<OfficialPartyQueryDto>(newEntity);

                return await Result<OfficialPartyQueryDto>.SuccessAsync(entityMap, "OfficialParty record added");
            }
            catch (Exception exc)
            {

                return await Result<OfficialPartyQueryDto>.FailAsync($"AddOfficialParty > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OfficialPartyRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveOfficialParty > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.OfficialPartyRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveOfficialParty record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveOfficialParty > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<OfficialPartyQueryDto>> Update(OfficialPartyDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<OfficialPartyQueryDto>.FailAsync($"UpdateOfficialParty > the passed entity IS NULL!!!...");

            // var item = await _repositoryManager.OfficialPartyRepository.GetById(Convert.ToInt32(entity.Id));

            //if (item == null) return await Result<OfficialPartyQueryDto>.FailAsync("UpdateOfficialParty > the passed entity with the given id NOT EXIEST !!!.");
            //_mapper.Map(entity, item);
            var newob = new OfficialParty
            {
                Id = Convert.ToInt32(entity.Id),
                ServiceProviderId = Convert.ToInt32(entity.ServiceProviderId),
                Active = Convert.ToBoolean(entity.Active),
                OrganisationType = entity.OrganisationType,
            };
            _repositoryManager.OfficialPartyRepository.Update(newob);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OfficialPartyQueryDto>.SuccessAsync(_mapper.Map<OfficialPartyQueryDto>(newob), "OfficialParty record updated");
            }
            catch (Exception exc)
            {
                return await Result<OfficialPartyQueryDto>.FailAsync($"UpdateOfficialParty > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(OfficialPartyDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OfficialPartyRepository.GetById(Convert.ToInt32(entity.Id));
            item.Active = !item.Active;
            _repositoryManager.OfficialPartyRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OfficialPartyQueryDto>.SuccessAsync(_mapper.Map<OfficialPartyQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<OfficialPartyQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
