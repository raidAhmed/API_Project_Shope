using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_ProFeatures;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_ProFeatures;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SP_ProFeaturesService : ISP_ProFeaturesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SP_ProFeaturesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<SP_ProFeaturesQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_ProFeaturesRepository.GetAll(x => new SP_ProFeaturesQueryDto
            {
              Id = x.Id,
              ProFeaturesId=x.ProFeaturesId,
              ServiceProviderId=x.ServiceProviderId,
              Active=x.Active,
              
            });

            var itemMap = _mapper.Map<IEnumerable<SP_ProFeaturesQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SP_ProFeaturesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SP_ProFeaturesQueryDto>>.SuccessAsync(itemMap, "SP_ProFeatures records retrieved");
        }

        public async Task<IResult<DtResult<SP_ProFeaturesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.SP_ProFeaturesRepository.GetAll(x => new SP_ProFeaturesQueryDto
            {
                Id = x.Id,
                ProFeaturesId = x.ProFeaturesId,
                ServiceProviderId = x.ServiceProviderId,
                Active = x.Active,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_ProFeaturesRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SP_ProFeaturesQueryDto>>(items);

            var datatableReturned = DtResult<SP_ProFeaturesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_ProFeaturesQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_ProFeaturesQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_ProFeatures Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<SP_ProFeaturesQueryDto>>> Find(Expression<Func<SP_ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_ProFeatures, bool>>>(expression);

            var items = await _repositoryManager.SP_ProFeaturesRepository.Find(x => new SP_ProFeaturesQueryDto
            {
                Id = x.Id,
                ProFeaturesId = x.ProFeaturesId,
                ServiceProviderId = x.ServiceProviderId,
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SP_ProFeaturesQueryDto>>(items);

            if (items == null || items.Any() == false) return await Result<IEnumerable<SP_ProFeaturesQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_ProFeaturesQueryDto>>.SuccessAsync(itemMap, "SP_ProFeatures records retrieved");
        }

        public async Task<IResult<DtResult<SP_ProFeaturesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_ProFeatures, bool>>>(expression);

            var items = await _repositoryManager.SP_ProFeaturesRepository.Find(x => new SP_ProFeaturesQueryDto
            {
                Id = x.Id,
                ProFeaturesId = x.ProFeaturesId,
                ServiceProviderId = x.ServiceProviderId,
                Active = x.Active,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_ProFeaturesRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SP_ProFeaturesQueryDto>>(items);

            var datatableReturned = DtResult<SP_ProFeaturesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<SP_ProFeaturesQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_ProFeaturesQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_ProFeatures Datatable.", 200);
        }


        public async Task<IResult<SP_ProFeaturesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_ProFeaturesRepository.GetById(Id);

            if (item == null) return await Result<SP_ProFeaturesQueryDto>.FailAsync("GetSP_ProFeaturesById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SP_ProFeaturesQueryDto>(item);

            return await Result<SP_ProFeaturesQueryDto>.SuccessAsync(itemMap, "SP_ProFeatures record retrieved");
        }

        //public async Task<IResult<IEnumerable<SP_ProFeaturesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        //{

        //    var item = await _repositoryManager.SP_ProFeaturesRepository.GetDDL();

        //    if (item == null) return await Result<IEnumerable<SP_ProFeaturesDDlLViewModels>>.FailAsync("GetSP_ProFeaturesDDL > ERRORS !!!...");

        //    return await Result<IEnumerable<SP_ProFeaturesDDlLViewModels>>.SuccessAsync(item, "SP_ProFeatures DDL records retrieved");
        //}
        public async Task<IResult<SP_ProFeaturesQueryDto>> Add(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SP_ProFeaturesQueryDto>.FailAsync("AddSP_ProFeatures > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.SP_ProFeaturesRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<SP_ProFeaturesQueryDto>.FailAsync("AddSP_ProFeatures > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.SP_ProFeaturesRepository.AddAndReturn(_mapper.Map<SP_ProFeatures>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SP_ProFeaturesQueryDto>(newEntity);

                return await Result<SP_ProFeaturesQueryDto>.SuccessAsync(entityMap, "SP_ProFeatures record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_ProFeaturesQueryDto>.FailAsync($"AddSP_ProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_ProFeaturesRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSP_ProFeatures > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SP_ProFeaturesRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSP_ProFeatures record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSP_ProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SP_ProFeaturesQueryDto>> Update(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SP_ProFeaturesQueryDto>.FailAsync($"UpdateSP_ProFeatures > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SP_ProFeaturesRepository.GetById(entity.Id);

            if (item == null) return await Result<SP_ProFeaturesQueryDto>.FailAsync("UpdateSP_ProFeatures > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.SP_ProFeaturesRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_ProFeaturesQueryDto>.SuccessAsync(_mapper.Map<SP_ProFeaturesQueryDto>(item), "SP_ProFeatures record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_ProFeaturesQueryDto>.FailAsync($"UpdateSP_ProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_ProFeaturesRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SP_ProFeaturesRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_ProFeaturesQueryDto>.SuccessAsync(_mapper.Map<SP_ProFeaturesQueryDto>(item), "SP_ProFeatures record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_ProFeaturesQueryDto>.FailAsync($"UpdateSP_ProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

        public Task<IResult<IEnumerable<SP_ProFeaturesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
