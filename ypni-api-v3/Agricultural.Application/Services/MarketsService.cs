using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Markets;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Markets;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class MarketsService : IMarketsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MarketsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<MarketsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.MarketsRepository.GetAll(x => new MarketsQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                DescriptionAddress= x.DescriptionAddress,
                CityId = x.CityId,
                DirectorateId= x.DirectorateId,
                Active = x.Active,
                
            });

            var itemMap = _mapper.Map<IEnumerable<MarketsQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<MarketsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<MarketsQueryDto>>.SuccessAsync(itemMap, "Markets records retrieved");
        }

        public async Task<IResult<DtResult<MarketsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.MarketsRepository.GetAll(x => new MarketsQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                DescriptionAddress = x.DescriptionAddress,
                CityId = x.CityId,
                DirectorateId = x.DirectorateId,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.MarketsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<MarketsQueryDto>>(items);

            var datatableReturned = DtResult<MarketsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);


            if (items == null) return await Result<DtResult<MarketsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<MarketsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Markets Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<MarketsQueryDto>>> Find(Expression<Func<MarketsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Markets, bool>>>(expression);

            var items = await _repositoryManager.MarketsRepository.Find(x => new MarketsQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                DescriptionAddress = x.DescriptionAddress,
                CityId = x.CityId,
                DirectorateId = x.DirectorateId,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<MarketsQueryDto>>(items);

            if (items == null || items.Any() == false) return await Result<IEnumerable<MarketsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<MarketsQueryDto>>.SuccessAsync(itemMap, "Markets records retrieved");
        }

        public async Task<IResult<DtResult<MarketsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<MarketsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Markets, bool>>>(expression);

            var items = await _repositoryManager.MarketsRepository.Find(x => new MarketsQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                DescriptionAddress = x.DescriptionAddress,
                CityId = x.CityId,
                DirectorateId = x.DirectorateId,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.MarketsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<MarketsQueryDto>>(items);

            var datatableReturned = DtResult<MarketsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<MarketsQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<MarketsQueryDto>>.SuccessAsync(datatableReturned, message: "Get Markets Datatable.", 200);
        }


        public async Task<IResult<MarketsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.MarketsRepository.GetById(Id);

            if (item == null) return await Result<MarketsQueryDto>.FailAsync("GetMarketsById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<MarketsQueryDto>(item);

            return await Result<MarketsQueryDto>.SuccessAsync(itemMap, "Markets record retrieved");
        }

        public async Task<IResult<IEnumerable<MarketsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.MarketsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<MarketsDDlLViewModels>>.FailAsync("GetMarketsDDL > ERRORS !!!...");

            return await Result<IEnumerable<MarketsDDlLViewModels>>.SuccessAsync(item, "Markets DDL records retrieved");
        }
        public async Task<IResult<MarketsQueryDto>> Add(MarketsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<MarketsQueryDto>.FailAsync("AddMarkets > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.MarketsRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<MarketsQueryDto>.FailAsync("AddMarkets > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.MarketsRepository.AddAndReturn(_mapper.Map<Markets>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<MarketsQueryDto>(newEntity);

                return await Result<MarketsQueryDto>.SuccessAsync(entityMap, "Markets record added");
            }
            catch (Exception exc)
            {

                return await Result<MarketsQueryDto>.FailAsync($"AddMarkets > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.MarketsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveMarkets > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.MarketsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveMarkets record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveMarkets > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<MarketsQueryDto>> Update(MarketsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<MarketsQueryDto>.FailAsync($"UpdateMarkets > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.MarketsRepository.GetById(entity.Id);

            if (item == null) return await Result<MarketsQueryDto>.FailAsync("UpdateMarkets > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.MarketsRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<MarketsQueryDto>.SuccessAsync(_mapper.Map<MarketsQueryDto>(item), "Markets record updated");
            }
            catch (Exception exc)
            {
                return await Result<MarketsQueryDto>.FailAsync($"UpdateMarkets > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(MarketsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.MarketsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.MarketsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<MarketsQueryDto>.SuccessAsync(_mapper.Map<MarketsQueryDto>(item), "Markets record updated");
            }
            catch (Exception exc)
            {
                return await Result<MarketsQueryDto>.FailAsync($"UpdateMarkets > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
