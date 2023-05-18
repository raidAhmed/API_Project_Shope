using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.City;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.City;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.DTOs.Directorate;

namespace Agricultural.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CityService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<CityQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.CityRepository.GetAll(x => new CityQueryDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Active = x.Active,

            //});
            var list2 = new List<CityQueryDto>();
            var items = await _repositoryManager.CityRepository.GetAll();
            foreach (var obj in items)
            {
                var list = new CityQueryDto();
                var item2 = await _repositoryManager.DirectorateRepository.Find(x => x.CityId == obj.Id);

                //  item2.FirstOrDefault().Name;
                var itemMap = _mapper.Map<IEnumerable<DirectorateQueryDto>>(item2);
                list.Id = obj.Id;
                list.Name = obj.Name;
                list.directorates = itemMap.ToList();
                list2.Add(list);
            }

            if (items == null) return await Result<IEnumerable<CityQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CityQueryDto>>.SuccessAsync(list2, "City records retrieved");
        }

        public async Task<IResult<DtResult<CityQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.CityRepository.GetAll(x => new CityQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CityRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<CityQueryDto>>(items);

            var datatableReturned = DtResult<CityQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<CityQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CityQueryDto>>.SuccessAsync(datatableReturned, message: "Get City Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<CityQueryDto>>> Find(Expression<Func<CityQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<City, bool>>>(expression);

            var items = await _repositoryManager.CityRepository.Find(x => new CityQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<CityQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<CityQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CityQueryDto>>.SuccessAsync(itemMap, "City records retrieved");
        }

        public async Task<IResult<DtResult<CityQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CityQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<City, bool>>>(expression);

            var items = await _repositoryManager.CityRepository.Find(x => new CityQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.CityRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<CityQueryDto>>(items);

            var datatableReturned = DtResult<CityQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null)  return await Result<DtResult<CityQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<CityQueryDto>>.SuccessAsync(datatableReturned, message: "Get City Datatable.", 200);
        }


        public async Task<IResult<CityQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CityRepository.GetById(Id);

            if (item == null) return await Result<CityQueryDto>.FailAsync("GetCityById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<CityQueryDto>(item);

            return await Result<CityQueryDto>.SuccessAsync(itemMap, "City record retrieved");
        }

        public async Task<IResult<IEnumerable<CityDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.CityRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<CityDDlLViewModels>>.FailAsync("GetCityDDL > ERRORS !!!...");

            return await Result<IEnumerable<CityDDlLViewModels>>.SuccessAsync(item, "City DDL records retrieved");
        }
        public async Task<IResult<CityQueryDto>> Add(CityDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<CityQueryDto>.FailAsync("AddCity > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.CityRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<CityQueryDto>.FailAsync("AddCity > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.CityRepository.AddAndReturn(_mapper.Map<City>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<CityQueryDto>(newEntity);

                return await Result<CityQueryDto>.SuccessAsync(entityMap, "City record added");
            }
            catch (Exception exc)
            {

                return await Result<CityQueryDto>.FailAsync($"AddCity > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CityRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveCity > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.CityRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveCity record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveCity > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<CityQueryDto>> Update(CityDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<CityQueryDto>.FailAsync($"UpdateCity > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.CityRepository.GetById(entity.Id);

            if (item == null) return await Result<CityQueryDto>.FailAsync("UpdateCity > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            item.Active = true;
            _repositoryManager.CityRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CityQueryDto>.SuccessAsync(_mapper.Map<CityQueryDto>(item), "City record updated");
            }
            catch (Exception exc)
            {
                return await Result<CityQueryDto>.FailAsync($"UpdateCity > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }


        public async Task<IResult> ChangeActive(CityDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CityRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.CityRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CityQueryDto>.SuccessAsync(_mapper.Map<CityQueryDto>(item), "City record updated");
            }
            catch (Exception exc)
            {
                return await Result<CityQueryDto>.FailAsync($"UpdateCity > Something went wrong !!!\n\n\n{exc.Message}");
            }



            //if (entity == null) return await Result<CityQueryDto>.FailAsync($"UpdateCity > the passed entity IS NULL!!!...");

            //var item = await _repositoryManager.CityRepository.GetById(entity.Id);

            //if (item == null) return await Result<CityQueryDto>.FailAsync("UpdateCity > the passed entity with the given id NOT EXIEST !!!.");

            //_mapper.Map(entity, item);

            //item.Active = true;
            //_repositoryManager.CityRepository.Update(item);

            //try
            //{
            //    await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

            //    return await Result<CityQueryDto>.SuccessAsync(_mapper.Map<CityQueryDto>(item), "City record updated");
            //}
            //catch (Exception exc)
            //{
            //    return await Result<CityQueryDto>.FailAsync($"UpdateCity > Something went wrong !!!\n\n\n{exc.Message}");
            //}
        }

    }
}
