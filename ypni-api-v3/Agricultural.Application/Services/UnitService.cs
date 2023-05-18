using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Unit;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Unit;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UnitService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<UnitQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.UnitRepository.GetAll(x => new UnitQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                value = x.value,
                Active = x.Active,
                
            });

            var itemMap = _mapper.Map<IEnumerable<UnitQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<UnitQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<UnitQueryDto>>.SuccessAsync(itemMap, "Unit records retrieved");
        }

        public async Task<IResult<DtResult<UnitQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.UnitRepository.GetAll(x => new UnitQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                value = x.value,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.UnitRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<UnitQueryDto>>(items);

            var datatableReturned = DtResult<UnitQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);


            if (items == null) return await Result<DtResult<UnitQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<UnitQueryDto>>.SuccessAsync(datatableReturned, message: "Get Unit Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<UnitQueryDto>>> Find(Expression<Func<UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Unit, bool>>>(expression);

            var items = await _repositoryManager.UnitRepository.Find(x => new UnitQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                value = x.value,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<UnitQueryDto>>(items);

            if (items == null || items.Any() == false) return await Result<IEnumerable<UnitQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<UnitQueryDto>>.SuccessAsync(itemMap, "Unit records retrieved");
        }

        public async Task<IResult<DtResult<UnitQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Unit, bool>>>(expression);

            var items = await _repositoryManager.UnitRepository.Find(x => new UnitQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                value = x.value,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.UnitRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<UnitQueryDto>>(items);

            var datatableReturned = DtResult<UnitQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<UnitQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<UnitQueryDto>>.SuccessAsync(datatableReturned, message: "Get Unit Datatable.", 200);
        }


        public async Task<IResult<UnitQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.UnitRepository.GetById(Id);

            if (item == null) return await Result<UnitQueryDto>.FailAsync("GetUnitById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<UnitQueryDto>(item);

            return await Result<UnitQueryDto>.SuccessAsync(itemMap, "Unit record retrieved");
        }

        public async Task<IResult<IEnumerable<UnitDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.UnitRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<UnitDDlLViewModels>>.FailAsync("GetUnitDDL > ERRORS !!!...");

            return await Result<IEnumerable<UnitDDlLViewModels>>.SuccessAsync(item, "Unit DDL records retrieved");
        }
        public async Task<IResult<UnitQueryDto>> Add(UnitDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<UnitQueryDto>.FailAsync("AddUnit > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.UnitRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<UnitQueryDto>.FailAsync("AddUnit > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.UnitRepository.AddAndReturn(_mapper.Map<Unit>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<UnitQueryDto>(newEntity);

                return await Result<UnitQueryDto>.SuccessAsync(entityMap, "Unit record added");
            }
            catch (Exception exc)
            {

                return await Result<UnitQueryDto>.FailAsync($"AddUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.UnitRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveUnit > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.UnitRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveUnit record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<UnitQueryDto>> Update(UnitDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<UnitQueryDto>.FailAsync($"UpdateUnit > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.UnitRepository.GetById(entity.Id);

            if (item == null) return await Result<UnitQueryDto>.FailAsync("UpdateUnit > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.UnitRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<UnitQueryDto>.SuccessAsync(_mapper.Map<UnitQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<UnitQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(UnitDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.UnitRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.UnitRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<UnitQueryDto>.SuccessAsync(_mapper.Map<UnitQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<UnitQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
