using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Directorate;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Directorate;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class DirectorateService : IDirectorateService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public DirectorateService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<DirectorateQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.DirectorateRepository.GetAll(x => new DirectorateQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                
            });

            var itemMap = _mapper.Map<IEnumerable<DirectorateQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<DirectorateQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<DirectorateQueryDto>>.SuccessAsync(itemMap, "Directorate records retrieved");
        }

        public async Task<IResult<DtResult<DirectorateQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.DirectorateRepository.GetAll(x => new DirectorateQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.DirectorateRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<DirectorateQueryDto>>(items);

            var datatableReturned = DtResult<DirectorateQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);


            if (items == null) return await Result<DtResult<DirectorateQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<DirectorateQueryDto>>.SuccessAsync(datatableReturned, message: "Get Directorate Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<DirectorateQueryDto>>> Find(Expression<Func<DirectorateQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Directorate, bool>>>(expression);

            var items = await _repositoryManager.DirectorateRepository.Find(x => new DirectorateQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<DirectorateQueryDto>>(items);

            if (items == null || items.Any() == false) return await Result<IEnumerable<DirectorateQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<DirectorateQueryDto>>.SuccessAsync(itemMap, "Directorate records retrieved");
        }

        public async Task<IResult<DtResult<DirectorateQueryDto>>> Find(DtRequest dtRequest, Expression<Func<DirectorateQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Directorate, bool>>>(expression);

            var items = await _repositoryManager.DirectorateRepository.Find(x => new DirectorateQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.DirectorateRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<DirectorateQueryDto>>(items);

            var datatableReturned = DtResult<DirectorateQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null || items.Any() == false) return await Result<DtResult<DirectorateQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<DirectorateQueryDto>>.SuccessAsync(datatableReturned, message: "Get Directorate Datatable.", 200);
        }


        public async Task<IResult<DirectorateQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.DirectorateRepository.GetById(Id);

            if (item == null) return await Result<DirectorateQueryDto>.FailAsync("GetDirectorateById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<DirectorateQueryDto>(item);

            return await Result<DirectorateQueryDto>.SuccessAsync(itemMap, "Directorate record retrieved");
        }

        public async Task<IResult<IEnumerable<DirectorateDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.DirectorateRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<DirectorateDDlLViewModels>>.FailAsync("GetDirectorateDDL > ERRORS !!!...");

            return await Result<IEnumerable<DirectorateDDlLViewModels>>.SuccessAsync(item, "Directorate DDL records retrieved");
        }
        public async Task<IResult<DirectorateQueryDto>> Add(DirectorateDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<DirectorateQueryDto>.FailAsync("AddDirectorate > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.DirectorateRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<DirectorateQueryDto>.FailAsync("AddDirectorate > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.DirectorateRepository.AddAndReturn(_mapper.Map<Directorate>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<DirectorateQueryDto>(newEntity);

                return await Result<DirectorateQueryDto>.SuccessAsync(entityMap, "Directorate record added");
            }
            catch (Exception exc)
            {

                return await Result<DirectorateQueryDto>.FailAsync($"AddDirectorate > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.DirectorateRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveDirectorate > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.DirectorateRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveDirectorate record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveDirectorate > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<DirectorateQueryDto>> Update(DirectorateDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<DirectorateQueryDto>.FailAsync($"UpdateDirectorate > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.DirectorateRepository.GetById(entity.Id);

            if (item == null) return await Result<DirectorateQueryDto>.FailAsync("UpdateDirectorate > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.DirectorateRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<DirectorateQueryDto>.SuccessAsync(_mapper.Map<DirectorateQueryDto>(item), "Directorate record updated");
            }
            catch (Exception exc)
            {
                return await Result<DirectorateQueryDto>.FailAsync($"UpdateDirectorate > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(DirectorateDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.DirectorateRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.DirectorateRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<DirectorateQueryDto>.SuccessAsync(_mapper.Map<DirectorateQueryDto>(item), "Directorate record updated");
            }
            catch (Exception exc)
            {
                return await Result<DirectorateQueryDto>.FailAsync($"UpdateDirectorate > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
