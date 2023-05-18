using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.AdditionalSections;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.DTOs.Product;

namespace Agricultural.Application.Services
{
    public class AdditionalSectionsService : IAdditionalSectionsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AdditionalSectionsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetlistMainWithAdd(CancellationToken cancellationToken = default)
        {
            var listserifor = new List<MainAndAdditionalClassificationDtoApi>();
            var items = await _repositoryManager.MainClassificationRepository.GetAll(x => new MainClassificationDtoApi
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl,

            });
            if (items.Any())
            {
                foreach (var item in items)
                {
                    var maforobj = new MainAndAdditionalClassificationDtoApi();
                    var resinfo = await _repositoryManager.AdditionalSectionsRepository.Find(x => new AdditionalSectionsDto2
                    {
                        Id = x.Id,
                        AdditionalSectionsName = x.AdditionalSectionsName,
                        ImageUrl = x.ImageUrl,
                        ParnetSectionId = x.ParnetSectionId
                    }, x => x.MainClassificationId == item.Id);

                    maforobj.Id = item.Id;
                    maforobj.MainClassificationName = item.MainClassificationName;
                    maforobj.ImageUrl = item.ImageUrl;
                    if (resinfo.Count() != 0)
                    {
                        maforobj.AdditionalSectionsDto = resinfo.ToList();
                    }
                    else
                    {
                        maforobj.AdditionalSectionsDto = new List<AdditionalSectionsDto2>();
                    }
                    listserifor.Add(maforobj);
                }
            }
            return await Result<IEnumerable<MainAndAdditionalClassificationDtoApi>>.SuccessAsync(listserifor, "SP_User_Favourites records retrieved");
        }

        public async Task<IResult<IEnumerable<AdditionalSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.AdditionalSectionsRepository.GetAll(x => new AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName,
                Rank = x.Rank,
                ImageUrl = x.ImageUrl,
                ParnetSectionId = x.ParnetSectionId,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                MainClassificationImageUrl = x.MainClassification.ImageUrl,
                Active = x.Active,

            });
            var itemMap = _mapper.Map<IEnumerable<AdditionalSectionsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<AdditionalSectionsQueryDto>>.FailAsync("No Additional Sections");
            return await Result<IEnumerable<AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "AdditionalSections records retrieved");
        }

        public async Task<IResult<DtResult<AdditionalSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.AdditionalSectionsRepository.GetAll(x => new AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName,
                Rank = x.Rank,
                ImageUrl = x.ImageUrl,
                ParnetSectionId = (int)x.ParnetSectionId,
                MainClassificationId = (int)x.MainClassificationId,
                Active = x.Active,
                MainClassificationImageUrl = x.MainClassification.ImageUrl,
                MainClassificationName = x.MainClassification.MainClassificationName,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.AdditionalSectionsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<AdditionalSectionsQueryDto>>(items);

            var datatableReturned = DtResult<AdditionalSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<AdditionalSectionsQueryDto>>.FailAsync("No Additional Sections");

            return await Result<DtResult<AdditionalSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get AdditionalSections Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<AdditionalSectionsQueryDto>>> Find(Expression<Func<AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<AdditionalSections, bool>>>(expression);

            var items = await _repositoryManager.AdditionalSectionsRepository.Find(x => new AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName,
                Rank = x.Rank,
                ImageUrl = x.ImageUrl,
                ParnetSectionId = (int)x.ParnetSectionId,
                MainClassificationId = (int)x.MainClassificationId,
                Active = x.Active,
                MainClassificationImageUrl = x.MainClassification.ImageUrl,
                MainClassificationName = x.MainClassification.MainClassificationName,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<AdditionalSectionsQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<AdditionalSectionsQueryDto>>.FailAsync("No");
            return await Result<IEnumerable<AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "AdditionalSections records retrieved");
        }

        public async Task<IResult<DtResult<AdditionalSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<AdditionalSections, bool>>>(expression);

            var items = await _repositoryManager.AdditionalSectionsRepository.Find(x => new AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName,
                Rank = x.Rank,
                ImageUrl = x.ImageUrl,
                ParnetSectionId = (int)x.ParnetSectionId,
                MainClassificationId = (int)x.MainClassificationId,
                Active = x.Active,
                MainClassificationImageUrl = x.MainClassification.ImageUrl,
                MainClassificationName = x.MainClassification.MainClassificationName,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.AdditionalSectionsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<AdditionalSectionsQueryDto>>(items);

            var datatableReturned = DtResult<AdditionalSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<AdditionalSectionsQueryDto>>.FailAsync("No Additional Sections");
            return await Result<DtResult<AdditionalSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get AdditionalSections Datatable.", 200);
        }


        public async Task<IResult<AdditionalSectionsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.AdditionalSectionsRepository.GetById(Id);

            if (item == null) return await Result<AdditionalSectionsQueryDto>.FailAsync("GetAdditionalSectionsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<AdditionalSectionsQueryDto>(item);

            return await Result<AdditionalSectionsQueryDto>.SuccessAsync(itemMap, "AdditionalSections record retrieved");
        }

        public async Task<IResult<IEnumerable<AdditionalSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.AdditionalSectionsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<AdditionalSectionsDDlLViewModels>>.FailAsync("GetAdditionalSectionsDDL > ERRORS !!!...");

            return await Result<IEnumerable<AdditionalSectionsDDlLViewModels>>.SuccessAsync(item, "AdditionalSections DDL records retrieved");
        }
        public async Task<IResult<AdditionalSectionsQueryDto>> Add(AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<AdditionalSectionsQueryDto>.FailAsync("AddAdditionalSections > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.AdditionalSectionsRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<AdditionalSectionsQueryDto>.FailAsync("AddAdditionalSections > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.AdditionalSectionsRepository.AddAndReturn(_mapper.Map<AdditionalSections>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<AdditionalSectionsQueryDto>(newEntity);

                return await Result<AdditionalSectionsQueryDto>.SuccessAsync(entityMap, "AdditionalSections record added");
            }
            catch (Exception exc)
            {

                return await Result<AdditionalSectionsQueryDto>.FailAsync($"AddAdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AdditionalSectionsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveAdditionalSections > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.AdditionalSectionsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveAdditionalSections record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveAdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<AdditionalSectionsQueryDto>> Update(AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<AdditionalSectionsQueryDto>.FailAsync($"UpdateAdditionalSections > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.AdditionalSectionsRepository.GetById(entity.Id);

            if (item == null) return await Result<AdditionalSectionsQueryDto>.FailAsync("UpdateAdditionalSections > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.AdditionalSectionsRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<AdditionalSectionsQueryDto>.SuccessAsync(_mapper.Map<AdditionalSectionsQueryDto>(item), "AdditionalSections record updated");
            }
            catch (Exception exc)
            {
                return await Result<AdditionalSectionsQueryDto>.FailAsync($"UpdateAdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.AdditionalSectionsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.AdditionalSectionsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<AdditionalSectionsQueryDto>.SuccessAsync(_mapper.Map<AdditionalSectionsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<AdditionalSectionsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
