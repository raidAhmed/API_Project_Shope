using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Banks;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class BanksService : IBanksService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BanksService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<BanksQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BanksRepository.GetAll(x => new BanksQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Active=x.Active,
                
                
            });

            var itemMap = _mapper.Map<IEnumerable<BanksQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<BanksQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<BanksQueryDto>>.SuccessAsync(itemMap, "Banks records retrieved");
        }

        public async Task<IResult<DtResult<BanksQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.BanksRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.BanksRepository.GetAll(x => new BanksQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BanksRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<BanksQueryDto>>(items);

            var datatableReturned = DtResult<BanksQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<BanksQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<BanksQueryDto>>.SuccessAsync(datatableReturned, message: "Get Banks Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<BanksQueryDto>>> Find(Expression<Func<BanksQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Banks, bool>>>(expression);

            //var items = await _repositoryManager.BanksRepository.Find(mapExpr);

            var items = await _repositoryManager.BanksRepository.Find(x => new BanksQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<BanksQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<BanksQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<BanksQueryDto>>.SuccessAsync(itemMap, "Banks records retrieved");
        }

        public async Task<IResult<DtResult<BanksQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BanksQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Banks, bool>>>(expression);

            //var items = await _repositoryManager.BanksRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.BanksRepository.Find(x => new BanksQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Active = x.Active,
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BanksRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<BanksQueryDto>>(items);

            var datatableReturned = DtResult<BanksQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any()==false) return await Result<DtResult<BanksQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<BanksQueryDto>>.SuccessAsync(datatableReturned, message: "Get Banks Datatable.", 200);
        }


        public async Task<IResult<BanksQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.BanksRepository.GetById(Id);

            if (item == null) return await Result<BanksQueryDto>.FailAsync("GetBanksById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<BanksQueryDto>(item);

            return await Result<BanksQueryDto>.SuccessAsync(itemMap, "Banks record retrieved");
        }

   
        public async Task<IResult<BanksQueryDto>> Add(BanksDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<BanksQueryDto>.FailAsync("AddBanks > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.BanksRepository.AddAndReturn(_mapper.Map<Banks>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<BanksQueryDto>(newEntity);

                return await Result<BanksQueryDto>.SuccessAsync(entityMap, "Banks record added");
            }
            catch (Exception exc)
            {

                return await Result<BanksQueryDto>.FailAsync($"AddBanks > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BanksRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveBanks > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.BanksRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveBanks record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveBanks > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }
        }

        public async Task<IResult<BanksQueryDto>> Update(BanksDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<BanksQueryDto>.FailAsync($"UpdateBanks > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.BanksRepository.GetById(entity.Id);

            if (item == null) return await Result<BanksQueryDto>.FailAsync("UpdateBanks > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.BanksRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BanksQueryDto>.SuccessAsync(_mapper.Map<BanksQueryDto>(item), "Banks record updated");
            }
            catch (Exception exc)
            {
                return await Result<BanksQueryDto>.FailAsync($"UpdateBanks > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(BanksDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BanksRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.BanksRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BanksQueryDto>.SuccessAsync(_mapper.Map<BanksQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<BanksQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
