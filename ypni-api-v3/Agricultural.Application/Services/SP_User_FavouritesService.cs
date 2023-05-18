using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_User_Favourites;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_User_Favourites;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.DTOs.ServiceProvider;

namespace Agricultural.Application.Services
{
    public class SP_User_FavouritesService : ISP_User_FavouritesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SP_User_FavouritesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<SP_User_FavouritesQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_User_FavouritesRepository.GetAll(x => new SP_User_FavouritesQueryDto
            {
                Id = x.Id,
                Date = x.Date,
                ServiceProviderId = x.ServiceProviderId,
                UserId=x.UserId,

            });

            var itemMap = _mapper.Map<IEnumerable<SP_User_FavouritesQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SP_User_FavouritesQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_User_FavouritesQueryDto>>.SuccessAsync(itemMap, "SP_User_Favourites records retrieved");
        }
         public async Task<IResult<IEnumerable<ServiceProviderQueryDto>>> GetByIdSPInfo(string UserId, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_User_FavouritesRepository.Find(x => x.UserId == UserId);
            var listserifor=new List<ServiceProviderQueryDto>();
            if (items.Any())
            {

                foreach (var item in items)
                {
                    var resinfo = await _repositoryManager.ServiceProviderRepository.GetById(item.ServiceProviderId);
                    var servicesname = await _repositoryManager.ServicesTypeRepository.GetById(resinfo.ServiceTypeId);
                    var activityname = await _repositoryManager.ActivityTypeRepository.GetById(resinfo.ActivityTypeId);
                    var itemMapm = _mapper.Map<ServiceProviderQueryDto>(resinfo);
                    itemMapm.Id = item.ServiceProviderId;
                    itemMapm.idForFavo = item.Id; 
                    itemMapm.ActivityTypeName = activityname.ActivityName;
                    itemMapm.ServiceTypeName = servicesname.Name;
                    listserifor.Add(itemMapm);
                }
            }
                

                var itemMap = _mapper.Map<IEnumerable<ServiceProviderQueryDto>>(listserifor);

            return await Result<IEnumerable<ServiceProviderQueryDto>>.SuccessAsync(itemMap, "SP_User_Favourites records retrieved");
        }

        public async Task<IResult<DtResult<SP_User_FavouritesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SP_User_FavouritesRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_User_FavouritesRepository.GetAll(x => new SP_User_FavouritesQueryDto
            {
                Id = x.Id,
                Date = x.Date,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_User_FavouritesRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SP_User_FavouritesQueryDto>>(items);

            var datatableReturned = DtResult<SP_User_FavouritesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_User_FavouritesQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_User_FavouritesQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_User_Favourites Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<SP_User_FavouritesQueryDto>>> Find(Expression<Func<SP_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_User_Favourites, bool>>>(expression);

            //var items = await _repositoryManager.SP_User_FavouritesRepository.Find(mapExpr);

            var items = await _repositoryManager.SP_User_FavouritesRepository.Find(x => new SP_User_FavouritesQueryDto
            {
                Id = x.Id,
                Date = x.Date,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SP_User_FavouritesQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SP_User_FavouritesQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_User_FavouritesQueryDto>>.SuccessAsync(itemMap, "SP_User_Favourites records retrieved");
        }

        public async Task<IResult<DtResult<SP_User_FavouritesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_User_Favourites, bool>>>(expression);

            //var items = await _repositoryManager.SP_User_FavouritesRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_User_FavouritesRepository.Find(x => new SP_User_FavouritesQueryDto
            {
                Id = x.Id,
                Date = x.Date,
                ServiceProviderId = x.ServiceProviderId,
                UserId = x.UserId,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_User_FavouritesRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SP_User_FavouritesQueryDto>>(items);

            var datatableReturned = DtResult<SP_User_FavouritesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_User_FavouritesQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_User_FavouritesQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_User_Favourites Datatable.", 200);
        }


        public async Task<IResult<SP_User_FavouritesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_User_FavouritesRepository.GetById(Id);

            if (item == null) return await Result<SP_User_FavouritesQueryDto>.FailAsync("GetSP_User_FavouritesById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SP_User_FavouritesQueryDto>(item);

            return await Result<SP_User_FavouritesQueryDto>.SuccessAsync(itemMap, "SP_User_Favourites record retrieved");
        }

        public async Task<IResult<IEnumerable<SP_User_FavouritesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_User_FavouritesRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SP_User_FavouritesDDlLViewModels>>.FailAsync("GetSP_User_FavouritesDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<SP_User_FavouritesDDLViewModel>(item);

            return await Result<IEnumerable<SP_User_FavouritesDDlLViewModels>>.SuccessAsync(item, "SP_User_Favourites DDL records retrieved");
        }
        public async Task<IResult<SP_User_FavouritesQueryDto>> Add(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SP_User_FavouritesQueryDto>.FailAsync("AddSP_User_Favourites > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.SP_User_FavouritesRepository.AddAndReturn(_mapper.Map<SP_User_Favourites>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SP_User_FavouritesQueryDto>(newEntity);

                return await Result<SP_User_FavouritesQueryDto>.SuccessAsync(entityMap, "SP_User_Favourites record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_User_FavouritesQueryDto>.FailAsync($"AddSP_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_User_FavouritesRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSP_User_Favourites > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SP_User_FavouritesRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSP_User_Favourites record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSP_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SP_User_FavouritesQueryDto>> Update(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SP_User_FavouritesQueryDto>.FailAsync($"UpdateSP_User_Favourites > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SP_User_FavouritesRepository.GetById(entity.Id);

            if (item == null) return await Result<SP_User_FavouritesQueryDto>.FailAsync("UpdateSP_User_Favourites > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SP_User_FavouritesRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_User_FavouritesQueryDto>.SuccessAsync(_mapper.Map<SP_User_FavouritesQueryDto>(item), "SP_User_Favourites record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_User_FavouritesQueryDto>.FailAsync($"UpdateSP_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SP_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_User_FavouritesRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SP_User_FavouritesRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_User_FavouritesQueryDto>.SuccessAsync(_mapper.Map<SP_User_FavouritesQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_User_FavouritesQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
