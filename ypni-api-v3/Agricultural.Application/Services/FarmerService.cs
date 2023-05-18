using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Farmer;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Farmer;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public FarmerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<FarmerQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.FarmerRepository.GetAll(x => new FarmerQueryDto
            {
                Id = x.Id,
                 Active = x.Active,
                 EarthInfo = x.EarthInfo,
                 ServiceProviderId =(int) x.ServiceProviderId,
                 EarthLength=x.EarthLength,
                 EarthWidth=x.EarthWidth,
                 

            });

            var itemMap = _mapper.Map<IEnumerable<FarmerQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<FarmerQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<FarmerQueryDto>>.SuccessAsync(itemMap, "Farmer records retrieved");
        }

        public async Task<IResult<DtResult<FarmerQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.FarmerRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.FarmerRepository.GetAll(x => new FarmerQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                EarthInfo = x.EarthInfo,
                ServiceProviderId = (int)x.ServiceProviderId,
                EarthLength = x.EarthLength,
                EarthWidth = x.EarthWidth,



            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.FarmerRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<FarmerQueryDto>>(items);

            var datatableReturned = DtResult<FarmerQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<FarmerQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<FarmerQueryDto>>.SuccessAsync(datatableReturned, message: "Get Farmer Datatable.", 200);

        }


        public async Task<IResult<FarmerDto>> Find(Expression<Func<FarmerDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Farmer, bool>>>(expression);

            var items = await _repositoryManager.FarmerRepository.Find(mapExpr);

            //var items = await _repositoryManager.FarmerRepository.Find(x => new FarmerQueryDto
            //{
            //    Id = x.Id,


            //}, mapExpr);
            var recored = items.OrderBy(x => x.Id).LastOrDefault();
            var itemMap = _mapper.Map<FarmerDto>(recored);
            if (items == null ) return await Result<FarmerDto>.FailAsync("No Data");
            return await Result<FarmerDto>.SuccessAsync(itemMap, "Farmer records retrieved");
        }

        public async Task<IResult<DtResult<FarmerQueryDto>>> Find(DtRequest dtRequest, Expression<Func<FarmerQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Farmer, bool>>>(expression);

            //var items = await _repositoryManager.FarmerRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.FarmerRepository.Find(x => new FarmerQueryDto
            {
                Id = x.Id,
                Active = x.Active,
                EarthInfo = x.EarthInfo,
                ServiceProviderId = (int)x.ServiceProviderId,
                EarthLength = x.EarthLength,
                EarthWidth = x.EarthWidth,



            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.FarmerRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<FarmerQueryDto>>(items);

            var datatableReturned = DtResult<FarmerQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<FarmerQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<FarmerQueryDto>>.SuccessAsync(datatableReturned, message: "Get Farmer Datatable.", 200);
        }


        public async Task<IResult<FarmerQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.FarmerRepository.GetById(Id);

            if (item == null) return await Result<FarmerQueryDto>.FailAsync("GetFarmerById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<FarmerQueryDto>(item);

            return await Result<FarmerQueryDto>.SuccessAsync(itemMap, "Farmer record retrieved");
        }

        public async Task<IResult<IEnumerable<FarmerDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.FarmerRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<FarmerDDlLViewModels>>.FailAsync("GetFarmerDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<FarmerDDLViewModel>(item);

            return await Result<IEnumerable<FarmerDDlLViewModels>>.SuccessAsync(item, "Farmer DDL records retrieved");
        }
        public async Task<IResult<FarmerQueryDto>> Add(FarmerDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<FarmerQueryDto>.FailAsync("AddFarmer > the passed entity IS NULL !!!.");

            try
            {
                var farmer = new Farmer
                {
                    EarthWidth = entity.EarthWidth,
                    Active = Convert.ToBoolean(entity.Active),
                    EarthLength = entity.EarthLength,
                    EarthInfo = entity.EarthInfo,
                    ServiceProviderId = Convert.ToInt32(entity.ServiceProviderId),
                    Id = Convert.ToInt32(entity.Id),
                };
                var newEntity = await _repositoryManager.FarmerRepository.AddAndReturn(farmer);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<FarmerQueryDto>(newEntity);

                return await Result<FarmerQueryDto>.SuccessAsync(entityMap, "Farmer record added");
            }
            catch (Exception exc)
            {

                return await Result<FarmerQueryDto>.FailAsync($"AddFarmer > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.FarmerRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveFarmer > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.FarmerRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveFarmer record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveFarmer > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<FarmerQueryDto>> Update(FarmerDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<FarmerQueryDto>.FailAsync($"UpdateFarmer > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.FarmerRepository.GetById(Convert.ToInt32(entity.Id));

            if (item == null) return await Result<FarmerQueryDto>.FailAsync("UpdateFarmer > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.FarmerRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<FarmerQueryDto>.SuccessAsync(_mapper.Map<FarmerQueryDto>(item), "Farmer record updated");
            }
            catch (Exception exc)
            {
                return await Result<FarmerQueryDto>.FailAsync($"UpdateFarmer > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(FarmerDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.FarmerRepository.GetById(Convert.ToInt32(entity.Id));
            item.Active = !item.Active;
            _repositoryManager.FarmerRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<FarmerQueryDto>.SuccessAsync(_mapper.Map<FarmerQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<FarmerQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
