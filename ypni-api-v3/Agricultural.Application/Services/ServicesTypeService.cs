using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ServicesType;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ServicesType;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ServicesTypeService : IServicesTypeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServicesTypeService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<ServicesTypeQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ServicesTypeRepository.GetAll(x => new ServicesTypeQueryDto
            {
                Id = x.Id,
                Name = x.Name,


            });

            var itemMap = _mapper.Map<IEnumerable<ServicesTypeQueryDto>>(items);

            return await Result<IEnumerable<ServicesTypeQueryDto>>.SuccessAsync(itemMap, "ServicesType records retrieved");
        }

        public async Task<IResult<DtResult<ServicesTypeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.ServicesTypeRepository.GetAll(x => new ServicesTypeQueryDto
            {
                Id = x.Id,
                Name = x.Name,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ServicesTypeRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ServicesTypeQueryDto>>(items);

            var datatableReturned = DtResult<ServicesTypeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            return await Result<DtResult<ServicesTypeQueryDto>>.SuccessAsync(datatableReturned, message: "Get ServicesType Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<ServicesTypeQueryDto>>> Find(Expression<Func<ServicesTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ServicesType, bool>>>(expression);

            var items = await _repositoryManager.ServicesTypeRepository.Find(mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ServicesTypeQueryDto>>(items);

            return await Result<IEnumerable<ServicesTypeQueryDto>>.SuccessAsync(itemMap, "ServicesType records retrieved");
        }

        public async Task<IResult<DtResult<ServicesTypeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ServicesTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ServicesType, bool>>>(expression);

            var items = await _repositoryManager.ServicesTypeRepository.Find(x => new ServicesTypeQueryDto
            {



            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ServicesTypeRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ServicesTypeQueryDto>>(items);

            var datatableReturned = DtResult<ServicesTypeQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            return await Result<DtResult<ServicesTypeQueryDto>>.SuccessAsync(datatableReturned, message: "Get ServicesType Datatable.", 200);
        }


        public async Task<IResult<ServicesTypeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ServicesTypeRepository.GetById(Id);

            if (item == null) return await Result<ServicesTypeQueryDto>.FailAsync("GetServicesTypeById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ServicesTypeQueryDto>(item);

            return await Result<ServicesTypeQueryDto>.SuccessAsync(itemMap, "ServicesType record retrieved");
        }

        public async Task<IResult<IEnumerable<ServicesTypeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ServicesTypeRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ServicesTypeDDlLViewModels>>.FailAsync("GetServicesTypeDDL > ERRORS !!!...");

            return await Result<IEnumerable<ServicesTypeDDlLViewModels>>.SuccessAsync(item, "ServicesType DDL records retrieved");
        }
        public async Task<IResult<ServicesTypeQueryDto>> Add(ServicesTypeDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ServicesTypeQueryDto>.FailAsync("AddServicesType > the passed entity IS NULL !!!.");

            try
            {

                var newEntity = await _repositoryManager.ServicesTypeRepository.AddAndReturn(_mapper.Map<ServicesType>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ServicesTypeQueryDto>(newEntity);

                return await Result<ServicesTypeQueryDto>.SuccessAsync(entityMap, "ServicesType record added");
            }
            catch (Exception exc)
            {

                return await Result<ServicesTypeQueryDto>.FailAsync($"AddServicesType > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ServicesTypeRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveServicesType > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ServicesTypeRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveServicesType record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveServicesType > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ServicesTypeQueryDto>> Update(ServicesTypeDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ServicesTypeQueryDto>.FailAsync($"UpdateServicesType > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ServicesTypeRepository.GetById(entity.Id);

            if (item == null) return await Result<ServicesTypeQueryDto>.FailAsync("UpdateServicesType > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.ServicesTypeRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ServicesTypeQueryDto>.SuccessAsync(_mapper.Map<ServicesTypeQueryDto>(item), "ServicesType record updated");
            }
            catch (Exception exc)
            {
                return await Result<ServicesTypeQueryDto>.FailAsync($"UpdateServicesType > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ServicesTypeDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ServicesTypeRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ServicesTypeRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ServicesTypeQueryDto>.SuccessAsync(_mapper.Map<ServicesTypeQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ServicesTypeQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
