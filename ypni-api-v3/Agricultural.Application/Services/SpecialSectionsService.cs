using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SpecialSections;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SpecialSectionsService : ISpecialSectionsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SpecialSectionsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<SpecialSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SpecialSectionsRepository.GetAll(x => new SpecialSectionsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                AdditionalSectionsId = x.AdditionalSectionsId,
                ImageUrl = x.ImageUrl,
                Rank = x.Rank,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                MainClassificationId = x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ParnetSectionId = x.ParnetSectionId,
                ParnetSectionName = x.ToSpecialSections.SpecialSectionName,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                SpecialSectionName = x.SpecialSectionName,

            });

            var itemMap = _mapper.Map<IEnumerable<SpecialSectionsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SpecialSectionsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SpecialSectionsQueryDto>>.SuccessAsync(itemMap, "SpecialSections records retrieved");
        }

        public async Task<IResult<DtResult<SpecialSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SpecialSectionsRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SpecialSectionsRepository.GetAll(x => new SpecialSectionsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                AdditionalSectionsId = x.AdditionalSectionsId,
                ImageUrl = x.ImageUrl,
                Rank = x.Rank,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                MainClassificationId = x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ParnetSectionId = x.ParnetSectionId,
                ParnetSectionName = x.ToSpecialSections.SpecialSectionName,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                SpecialSectionName = x.SpecialSectionName,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SpecialSectionsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SpecialSectionsQueryDto>>(items);

            var datatableReturned = DtResult<SpecialSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SpecialSectionsQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SpecialSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get SpecialSections Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<SpecialSectionsQueryDto>>> Find(Expression<Func<SpecialSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SpecialSections, bool>>>(expression);

            //var items = await _repositoryManager.SpecialSectionsRepository.Find(mapExpr);

            var items = await _repositoryManager.SpecialSectionsRepository.Find(x => new SpecialSectionsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                AdditionalSectionsId = x.AdditionalSectionsId,
                ImageUrl = x.ImageUrl,
                Rank = x.Rank,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                MainClassificationId = x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ParnetSectionId = x.ParnetSectionId,
                ParnetSectionName = x.ToSpecialSections.SpecialSectionName,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                SpecialSectionName = x.SpecialSectionName,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SpecialSectionsQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SpecialSectionsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SpecialSectionsQueryDto>>.SuccessAsync(itemMap, "SpecialSections records retrieved");
        }

        public async Task<IResult<DtResult<SpecialSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SpecialSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SpecialSections, bool>>>(expression);

            //var items = await _repositoryManager.SpecialSectionsRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SpecialSectionsRepository.Find(x => new SpecialSectionsQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                AdditionalSectionsId = x.AdditionalSectionsId,
                ImageUrl = x.ImageUrl,
                Rank = x.Rank,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                MainClassificationId = x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ParnetSectionId = x.ParnetSectionId,
                ParnetSectionName = x.ToSpecialSections.SpecialSectionName,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                SpecialSectionName = x.SpecialSectionName,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SpecialSectionsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SpecialSectionsQueryDto>>(items);

            var datatableReturned = DtResult<SpecialSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SpecialSectionsQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SpecialSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get SpecialSections Datatable.", 200);
        }


        public async Task<IResult<SpecialSectionsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SpecialSectionsRepository.GetById(Id);

            if (item == null) return await Result<SpecialSectionsQueryDto>.FailAsync("GetSpecialSectionsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SpecialSectionsQueryDto>(item);

            return await Result<SpecialSectionsQueryDto>.SuccessAsync(itemMap, "SpecialSections record retrieved");
        }

        public async Task<IResult<IEnumerable<SpecialSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SpecialSectionsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SpecialSectionsDDlLViewModels>>.FailAsync("GetSpecialSectionsDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<SpecialSectionsDDLViewModel>(item);

            return await Result<IEnumerable<SpecialSectionsDDlLViewModels>>.SuccessAsync(item, "SpecialSections DDL records retrieved");
        }
        public async Task<IResult<SpecialSectionsQueryDto>> Add(SpecialSectionsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SpecialSectionsQueryDto>.FailAsync("AddSpecialSections > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.SpecialSectionsRepository.AddAndReturn(_mapper.Map<SpecialSections>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SpecialSectionsQueryDto>(newEntity);

                return await Result<SpecialSectionsQueryDto>.SuccessAsync(entityMap, "SpecialSections record added");
            }
            catch (Exception exc)
            {

                return await Result<SpecialSectionsQueryDto>.FailAsync($"AddSpecialSections > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SpecialSectionsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSpecialSections > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SpecialSectionsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSpecialSections record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSpecialSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SpecialSectionsQueryDto>> Update(SpecialSectionsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SpecialSectionsQueryDto>.FailAsync($"UpdateSpecialSections > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SpecialSectionsRepository.GetById(entity.Id);

            if (item == null) return await Result<SpecialSectionsQueryDto>.FailAsync("UpdateSpecialSections > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SpecialSectionsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SpecialSectionsQueryDto>.SuccessAsync(_mapper.Map<SpecialSectionsQueryDto>(item), "SpecialSections record updated");
            }
            catch (Exception exc)
            {
                return await Result<SpecialSectionsQueryDto>.FailAsync($"UpdateSpecialSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SpecialSectionsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SpecialSectionsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SpecialSectionsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SpecialSectionsQueryDto>.SuccessAsync(_mapper.Map<SpecialSectionsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SpecialSectionsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
