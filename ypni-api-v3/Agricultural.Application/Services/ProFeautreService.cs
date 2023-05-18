using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProFeatures;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProFeatures;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ProFeaturesService : IProFeaturesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProFeaturesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<ProFeaturesQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ProFeaturesRepository.GetAll(x => new ProFeaturesQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            });

            var itemMap = _mapper.Map<IEnumerable<ProFeaturesQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ProFeaturesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProFeaturesQueryDto>>.SuccessAsync(itemMap, "ProFeatures records retrieved");
        }

        public async Task<IResult<DtResult<ProFeaturesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.ProFeaturesRepository.GetAll(x => new ProFeaturesQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProFeaturesRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ProFeaturesQueryDto>>(items);

            var datatableReturned = DtResult<ProFeaturesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ProFeaturesQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProFeaturesQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProFeatures Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<ProFeaturesQueryDto>>> Find(Expression<Func<ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProFeatures, bool>>>(expression);

            var items = await _repositoryManager.ProFeaturesRepository.Find(x => new ProFeaturesQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ProFeaturesQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ProFeaturesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProFeaturesQueryDto>>.SuccessAsync(itemMap, "ProFeatures records retrieved");
        }

        public async Task<IResult<DtResult<ProFeaturesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ProFeatures, bool>>>(expression);

            var items = await _repositoryManager.ProFeaturesRepository.Find(x => new ProFeaturesQueryDto
            {
                Id= x.Id,
                Name= x.Name,
                Active= x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ProFeaturesRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ProFeaturesQueryDto>>(items);

            var datatableReturned = DtResult<ProFeaturesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ProFeaturesQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProFeaturesQueryDto>>.SuccessAsync(datatableReturned, message: "Get ProFeatures Datatable.", 200);
        }


        public async Task<IResult<ProFeaturesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProFeaturesRepository.GetById(Id);

            if (item == null) return await Result<ProFeaturesQueryDto>.FailAsync("GetProFeaturesById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ProFeaturesQueryDto>(item);

            return await Result<ProFeaturesQueryDto>.SuccessAsync(itemMap, "ProFeatures record retrieved");
        }

        //public async Task<IResult<IEnumerable<ProFeautreDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        //{

        //    var item = await _repositoryManager.ProFeaturesRepository.GetDDL();

        //    if (item == null) return await Result<IEnumerable<ProFeautreDDlLViewModels>>.FailAsync("GetProFeaturesDDL > ERRORS !!!...");

        //    return await Result<IEnumerable<ProFeautreDDlLViewModels>>.SuccessAsync(item, "ProFeatures DDL records retrieved");
        //}
        public async Task<IResult<ProFeaturesQueryDto>> Add(ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ProFeaturesQueryDto>.FailAsync("AddProFeatures > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.ProFeaturesRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<ProFeaturesQueryDto>.FailAsync("AddProFeatures > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.ProFeaturesRepository.AddAndReturn(_mapper.Map<ProFeatures>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ProFeaturesQueryDto>(newEntity);

                return await Result<ProFeaturesQueryDto>.SuccessAsync(entityMap, "ProFeatures record added");
            }
            catch (Exception exc)
            {

                return await Result<ProFeaturesQueryDto>.FailAsync($"AddProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProFeaturesRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProFeatures > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ProFeaturesRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProFeatures record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ProFeaturesQueryDto>> Update(ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ProFeaturesQueryDto>.FailAsync($"UpdateProFeatures > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ProFeaturesRepository.GetById(entity.Id);

            if (item == null) return await Result<ProFeaturesQueryDto>.FailAsync("UpdateProFeatures > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.ProFeaturesRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProFeaturesQueryDto>.SuccessAsync(_mapper.Map<ProFeaturesQueryDto>(item), "ProFeatures record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProFeaturesQueryDto>.FailAsync($"UpdateProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ProFeaturesDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProFeaturesRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ProFeaturesRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProFeaturesQueryDto>.SuccessAsync(_mapper.Map<ProFeaturesQueryDto>(item), "ProFeatures record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProFeaturesQueryDto>.FailAsync($"UpdateProFeatures > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

        public Task<IResult<IEnumerable<ProFeaturesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
