using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.ViewModels.ServiceProvider;
using Agricultural.Application.Wrapper;
using Agricultural.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        public ServiceProviderService(IUserManager userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IResult<UserUpdateDto>> UpdateUserStatus(string Id, CancellationToken cancellationToken = default)
        {

            var user = await _userManager.FindByIdUserUpdateDto(Id);
            return await Result<UserUpdateDto>.SuccessAsync(user.Data, "UserUpdateDto record added"); ;
        }
        public async Task<IResult<ServiceProviderDto>> Add(ServiceProviderDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<ServiceProviderDto>.FailAsync("AddServiceProvider > the passed entity IS NULL !!!.");
            try
            { 

                var newEntity = await _repositoryManager.ServiceProviderRepository.AddAndReturn(_mapper.Map<ServiceProvider>(entity));
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                var entityMap = _mapper.Map<ServiceProviderDto>(newEntity);
                return await Result<ServiceProviderDto>.SuccessAsync(entityMap, "ServiceProvider record added");
            }
            catch (Exception exc)
            {
                return await Result<ServiceProviderDto>.FailAsync($"AddServiceProvider > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }
        }

        public async Task<IResult> ChangeActive(ServiceProviderDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ServiceProviderRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ServiceProviderRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ServiceProviderQueryDto>.SuccessAsync(_mapper.Map<ServiceProviderQueryDto>(item), "ServiceProvider record updated");
            }
            catch (Exception exc)
            {
                return await Result<ServiceProviderQueryDto>.FailAsync($"UpdateServiceProvider > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<IEnumerable<ServiceProviderQueryDto>>> Find(Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<ServiceProvider, bool>>>(expression);
            //var items = await _repositoryManager.ActivityTypeRepository.Find(mapExpr);
            var items = await _repositoryManager.ServiceProviderRepository.Find(x => new ServiceProviderQueryDto
            {
                Id = x.Id,
                TradeName = x.TradeName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                ServiceTypeName = x.ServiceType.Name,
                ActivityTypeName = x.ActivityType.ActivityName,
                ActivityTypeId = x.ActivityTypeId,
                ServiceTypeId = x.ServiceTypeId,
                Logo = x.Logo,
                Active = x.Active,
                Description = x.Description,
                NatId = x.NatId,
                Type = x.Type,
                UserId = x.UserId,
                ViewPlace = x.ViewPlace,

            }, mapExpr);
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProviderEvaluationRepository.Find(x => x.ServiceProviderId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.value);
                        var ratmt = proeval.Count();
                        item.Rating = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));


                    }
                    else
                    {
                        item.Rating = "0.0";

                    }

                }
            }
            var itemMap = _mapper.Map<IEnumerable<ServiceProviderQueryDto>>(items);

            if (items == null ) return await Result<IEnumerable<ServiceProviderQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ServiceProviderQueryDto>>.SuccessAsync(itemMap, "ServiceProvider records retrieved");
        }
        public Task<IResult<DtResult<ServiceProviderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public async Task<IResult<IEnumerable<ServiceProviderQueryDto>>> FindAll(Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<ServiceProvider, bool>>>(expression);
            //var items = await _repositoryManager.ActivityTypeRepository.Find(mapExpr);
            var items = await _repositoryManager.ServiceProviderRepository.Find(x => new ServiceProviderQueryDto
            {
                Id = x.Id,
                TradeName = x.TradeName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                ServiceTypeName = x.ServiceType.Name,
                ActivityTypeName = x.ActivityType.ActivityName,
                ActivityTypeId = x.ActivityTypeId,
                ServiceTypeId = x.ServiceTypeId,
                Logo = x.Logo,
                Active = x.Active,
                Description = x.Description,
                NatId = x.NatId,
                Type = x.Type,
                UserId = x.UserId,
                ViewPlace = x.ViewPlace,
            }, mapExpr);
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProviderEvaluationRepository.Find(x => x.ServiceProviderId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.value);
                        var ratmt = proeval.Count();
                        item.Rating = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));


                    }
                    else
                    {
                        item.Rating = "0.0";

                    }

                }
            }
            if (items == null ) return await Result<IEnumerable<ServiceProviderQueryDto>>.FailAsync("No data");
            return await Result<IEnumerable<ServiceProviderQueryDto>>.SuccessAsync(items, "ServiceProvider records retrieved");
        }
        public async Task<IResult<IEnumerable<ServiceProviderQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ServiceProviderRepository.GetAll(x => new ServiceProviderQueryDto
            {
                Id = x.Id,
                TradeName = x.TradeName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                ServiceTypeName = x.ServiceType.Name,
                ActivityTypeName = x.ActivityType.ActivityName,
                ActivityTypeId = x.ActivityTypeId,
                ServiceTypeId = x.ServiceTypeId,
                Logo = x.Logo,
                Active = x.Active,
                Description = x.Description,
                NatId = x.NatId,
                Type = x.Type,
                UserId = x.UserId,
                ViewPlace = x.ViewPlace,
            });
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProviderEvaluationRepository.Find(x => x.ServiceProviderId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.value);
                        var ratmt = proeval.Count();
                        item.Rating = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));


                    }
                    else
                    {
                        item.Rating = "0.0";

                    }

                }
            }
            var itemMap = _mapper.Map<IEnumerable<ServiceProviderQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<ServiceProviderQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ServiceProviderQueryDto>>.SuccessAsync(itemMap, "ServiceProvider records retrieved");
            //   var itemMap = _mapper.Map<IEnumerable<AdditionalSectionsQueryDto>>(items);
        }
        public Task<IResult<DtResult<ServiceProviderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<ServiceProviderDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ServiceProviderRepository.GetById(Id);
            ServiceProviderDto newobject = new ServiceProviderDto();
            newobject.ActivityTypeId = item.ActivityTypeId;
          //  newobject.ActivityTypeName = item.ActivityType.ActivityName; 
            newobject.NatId = item.NatId;
            newobject.Logo = item.Logo;
            newobject.Description = item.Description;
            newobject.PhoneNumber = item.PhoneNumber;
            newobject.ServiceTypeId = item.ServiceTypeId;
            newobject.Id = item.Id;
            newobject.Type = item.Type;
            newobject.ViewPlace = item.ViewPlace;
            newobject.Email = item.Email;
             //newobject.ServiceTypeName = item.Type;
            newobject.TradeName = item.TradeName;
            newobject.UserId = item.UserId;
            if (item == null) return await Result<ServiceProviderDto>.FailAsync("GetServiceProviderId > the given id NOT EXIEST !!!...");
            return await Result<ServiceProviderDto>.SuccessAsync(newobject, "GetServiceProviderId record retrieved");
        }
        public async Task<IResult<ServiceProviderDto>> GetByIdd(int Id, CancellationToken cancellationToken = default) 
        {
            var item = await _repositoryManager.ServiceProviderRepository.GetById(Id);
            ServiceProviderDto newobject = new ServiceProviderDto();
            newobject.ActivityTypeId = item.ActivityTypeId;
            //  newobject.ActivityTypeName = item.ActivityType.ActivityName; 
            newobject.NatId = item.NatId;
            newobject.Logo = item.Logo;
            newobject.Description = item.Description;
            newobject.PhoneNumber = item.PhoneNumber;
            newobject.ServiceTypeId = item.ServiceTypeId;
            newobject.Id = item.Id;
            newobject.Type = item.Type;
            newobject.ViewPlace = item.ViewPlace;
            newobject.Email = item.Email; 
            newobject.ServiceTypeName = item.Type;
            newobject.TradeName = item.TradeName;
            newobject.UserId = item.UserId;
            if (item == null) return await Result<ServiceProviderDto>.FailAsync("GetServiceProviderId > the given id NOT EXIEST !!!...");
            return await Result<ServiceProviderDto>.SuccessAsync(newobject, "GetServiceProviderId record retrieved");
        }


        public Task<IResult<IEnumerable<ServiceProviderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        //public async Task<IResult<ServiceProviderDto>> RemoveAfter(ServiceProviderDto entity, CancellationToken cancellationToken = default)
        //  {
        //      if (entity == null) return await Result<ServiceProviderDto>.FailAsync("RemoveAfter ServiceProvider > the passed entity IS NULL !!!.");
        //      try
        //      {

        //          _repositoryManager.ServiceProviderRepository.Remove(_mapper.Map<ServiceProvider>(entity));
        //          await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

        //          return await Result<ServiceProviderDto>.SuccessAsync("RemoveAfter ServiceProvider record Remove");
        //      }
        //      catch (Exception exc)
        //      {
        //          return await Result<ServiceProviderDto>.FailAsync($"AddServiceProvider > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
        //      }
        //  }
        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ServiceProviderRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveServiceProvider > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ServiceProviderRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveServiceProvider record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveServiceProvider > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ServiceProviderQueryDto>> Update(ServiceProviderDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<ServiceProviderQueryDto>.FailAsync($"UpdateServiceProvider > the passed entity IS NULL!!!...");
            var item = await _repositoryManager.ServiceProviderRepository.GetById(entity.Id);
            if (item == null) return await Result<ServiceProviderQueryDto>.FailAsync("UpdateServiceProvider > the passed entity with the given id NOT EXIEST !!!.");
            var updatee = _mapper.Map(entity, item);
            try
            {
                _repositoryManager.ServiceProviderRepository.Update(updatee);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return await Result<ServiceProviderQueryDto>.SuccessAsync(_mapper.Map<ServiceProviderQueryDto>(item), "Currency record updated");
            }
            catch (Exception exc) 
            { 
                return await Result<ServiceProviderQueryDto>.FailAsync($"UpdateCurrency > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
    }
}
