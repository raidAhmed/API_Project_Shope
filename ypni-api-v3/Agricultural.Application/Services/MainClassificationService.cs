using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.MainClassification;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class MainClassificationService : IMainClassificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MainClassificationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<MainClassificationQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.MainClassificationRepository.GetAll(x => new MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationName=x.MainClassificationName,
                ImageUrl=x.ImageUrl,
                ActivityTypeId=(int)x.ActivityTypeId,
                Active=x.Active,
                ActivityName=x.ActivityType.ActivityName,
                
            });

            var itemMap = _mapper.Map<IEnumerable<MainClassificationQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<MainClassificationQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<MainClassificationQueryDto>>.SuccessAsync(itemMap, "MainClassification records retrieved");
        }

        public async Task<IResult<DtResult<MainClassificationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.MainClassificationRepository.GetAll(x => new MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl,
                ActivityTypeId = (int)x.ActivityTypeId,
                Active = x.Active,
                ActivityName = x.ActivityType.ActivityName,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.MainClassificationRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<MainClassificationQueryDto>>(items);

            var datatableReturned = DtResult<MainClassificationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<MainClassificationQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<MainClassificationQueryDto>>.SuccessAsync(datatableReturned, message: "Get MainClassification Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<MainClassificationQueryDto>>> Find(Expression<Func<MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<MainClassification, bool>>>(expression);

            var items = await _repositoryManager.MainClassificationRepository.Find(x => new MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl,
                ActivityTypeId = (int)x.ActivityTypeId,
                Active = x.Active,
                ActivityName = x.ActivityType.ActivityName,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<MainClassificationQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<MainClassificationQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<MainClassificationQueryDto>>.SuccessAsync(itemMap, "MainClassification records retrieved");
        }

        public async Task<IResult<DtResult<MainClassificationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<MainClassification, bool>>>(expression);

            var items = await _repositoryManager.MainClassificationRepository.Find(x => new MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl,
                ActivityTypeId = (int)x.ActivityTypeId,
                Active = x.Active,
                ActivityName = x.ActivityType.ActivityName,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.MainClassificationRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<MainClassificationQueryDto>>(items);

            var datatableReturned = DtResult<MainClassificationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<MainClassificationQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<MainClassificationQueryDto>>.SuccessAsync(datatableReturned, message: "Get MainClassification Datatable.", 200);
        }


        public async Task<IResult<MainClassificationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.MainClassificationRepository.GetById(Id);

            if (item == null) return await Result<MainClassificationQueryDto>.FailAsync("GetMainClassificationById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<MainClassificationQueryDto>(item);

            return await Result<MainClassificationQueryDto>.SuccessAsync(itemMap, "MainClassification record retrieved");
        }


            public async Task<IResult<IEnumerable<MainClassificationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.MainClassificationRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<MainClassificationDDlLViewModels>>.FailAsync("GetMainClassificationDDL > ERRORS !!!...");

            return await Result<IEnumerable<MainClassificationDDlLViewModels>>.SuccessAsync(item, "MainClassification DDL records retrieved");
        }
        public async Task<IResult<MainClassificationQueryDto>> Add(MainClassificationDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<MainClassificationQueryDto>.FailAsync("AddMainClassification > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.MainClassificationRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<MainClassificationQueryDto>.FailAsync("AddMainClassification > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.MainClassificationRepository.AddAndReturn(_mapper.Map<MainClassification>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<MainClassificationQueryDto>(newEntity);

                return await Result<MainClassificationQueryDto>.SuccessAsync(entityMap, "MainClassification record added");
            }
            catch (Exception exc)
            {

                return await Result<MainClassificationQueryDto>.FailAsync($"AddMainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }
       
        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.MainClassificationRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveMainClassification > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.MainClassificationRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveMainClassification record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveMainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<MainClassificationQueryDto>> Update(MainClassificationDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<MainClassificationQueryDto>.FailAsync($"UpdateMainClassification > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.MainClassificationRepository.GetById(entity.Id);

            if (item == null) return await Result<MainClassificationQueryDto>.FailAsync("UpdateMainClassification > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.MainClassificationRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<MainClassificationQueryDto>.SuccessAsync(_mapper.Map<MainClassificationQueryDto>(item), "MainClassification record updated");
            }
            catch (Exception exc)
            {
                return await Result<MainClassificationQueryDto>.FailAsync($"UpdateMainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
            public async Task<IResult> ChangeActive(MainClassificationDto entity, CancellationToken cancellationToken = default)
            {
                var item = await _repositoryManager.MainClassificationRepository.GetById(entity.Id);
                item.Active = !item.Active;
                _repositoryManager.MainClassificationRepository.Update(item);
                try
                {
                    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                    return await Result<MainClassificationQueryDto>.SuccessAsync(_mapper.Map<MainClassificationQueryDto>(item), "Unit record updated");
                }
                catch (Exception exc)
                {
                    return await Result<MainClassificationQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
                }



            
        }
    }
}
