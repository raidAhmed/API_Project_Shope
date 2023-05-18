using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_Address;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_Address;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SP_AddressService : ISP_AddressService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SP_AddressService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IResult<IEnumerable<SP_AddressQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_AddressRepository.GetAll(x => new SP_AddressQueryDto
            {
                Id = x.Id,
                DirectorateId=x.DirectorateId,
                //CityName=x.City.Name,
                Description=x.Description,
                UserId = x.UserId,
                State =x.State,
                Street=x.Street,
                
            });

            var itemMap = _mapper.Map<IEnumerable<SP_AddressQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SP_AddressQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_AddressQueryDto>>.SuccessAsync(itemMap, "SP_Address records retrieved");
        }

        public async Task<IResult<DtResult<SP_AddressQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SP_AddressRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_AddressRepository.GetAll(x => new SP_AddressQueryDto
            {
                Id = x.Id,
                DirectorateId = x.DirectorateId,
              //  CityName = x.City.Name,
                Description = x.Description,
                UserId = x.UserId, 
                State = x.State,
                Street = x.Street,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_AddressRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SP_AddressQueryDto>>(items);

            var datatableReturned = DtResult<SP_AddressQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_AddressQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_AddressQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_Address Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<SP_AddressDto>>> Find(Expression<Func<SP_AddressDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<SP_Address, bool>>>(expression);

            

            var items = await _repositoryManager.SP_AddressRepository.Find(mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SP_AddressDto>>(items);
            if (items == null) return await Result<IEnumerable<SP_AddressDto>>.FailAsync("GetAddresses > the given id NOT EXIEST !!!...");
            return await Result<IEnumerable<SP_AddressDto>>.SuccessAsync(itemMap, "SP_Address records retrieved");
        }   
        public async Task<IResult<IEnumerable<SP_AddressQueryDto>>> FindByServicePro(Expression<Func<SP_AddressDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            var mapExpr = _mapper.Map<Expression<Func<SP_Address, bool>>>(expression) ;

            //var items = await _repositoryManager.SP_AddressRepository.Find(mapExpr);

            var items = await _repositoryManager.SP_AddressRepository.Find(X => new SP_AddressQueryDto
            {
                Id = X.Id,
                CityName = X.Directorate.City.Name,
                CityId = (int) X.Directorate.CityId,
                 DirectorateId = X.DirectorateId,
                 DirectorateName=X.Directorate.Name,    
                Description = X.Description,
                UserId = X.UserId,
                Street = X.Street
            }, mapExpr);
            var itemMap = _mapper.Map<IEnumerable<SP_AddressQueryDto>>(items);
            return await Result <IEnumerable <SP_AddressQueryDto>>.SuccessAsync(itemMap, "SP_Address records retrieved");
        }

        public async Task<IResult<DtResult<SP_AddressQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_AddressQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_Address, bool>>>(expression);

            //var items = await _repositoryManager.SP_AddressRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_AddressRepository.Find(X => new SP_AddressQueryDto
            {
                Id = X.Id,
                CityName = X.Directorate.City.Name,
                CityId = (int)X.Directorate.CityId,
                DirectorateId = X.DirectorateId,
                DirectorateName = X.Directorate.Name,
                Description = X.Description,
                UserId = X.UserId,
                Street = X.Street


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_AddressRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SP_AddressQueryDto>>(items);

            var datatableReturned = DtResult<SP_AddressQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SP_AddressQueryDto>>.FailAsync("GetAddresses > the given id NOT EXIEST !!!...");
            return await Result<DtResult<SP_AddressQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_Address Datatable.", 200);
        }


        public async Task<IResult<SP_AddressDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_AddressRepository.GetById(Id);

            if (item == null) return await Result<SP_AddressDto>.FailAsync("GetSP_AddressById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SP_AddressDto>(item);

            return await Result<SP_AddressDto>.SuccessAsync(itemMap, "SP_Address record retrieved");
        }

        public async Task<IResult<IEnumerable<SP_AddressDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_AddressRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SP_AddressDDlLViewModels>>.FailAsync("GetSP_AddressDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<SP_AddressDDLViewModel>(item);

            return await Result<IEnumerable<SP_AddressDDlLViewModels>>.SuccessAsync(item, "SP_Address DDL records retrieved");
        }
        public async Task<IResult<SP_AddressQueryDto>> Add(SP_AddressDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<SP_AddressQueryDto>.FailAsync("SP_Address > the passed entity IS NULL !!!.");
            try
            {
                var newEntity = await _repositoryManager.SP_AddressRepository.AddAndReturn(_mapper.Map<SP_Address>(entity));
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                var entityMap = _mapper.Map<SP_AddressQueryDto>(newEntity);
                return await Result<SP_AddressQueryDto>.SuccessAsync(entityMap, "SP_Address record added");
            }
            catch (Exception exc)
            {
                return await Result<SP_AddressQueryDto>.FailAsync($"SP_Address > Something went wrong !!!\n\n\n");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_AddressRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSP_Address > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SP_AddressRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSP_Address record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSP_Address > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SP_AddressQueryDto>> Update(SP_AddressDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SP_AddressQueryDto>.FailAsync($"UpdateSP_Address > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SP_AddressRepository.GetById(entity.Id);

            if (item == null) return await Result<SP_AddressQueryDto>.FailAsync("UpdateSP_Address > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SP_AddressRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_AddressQueryDto>.SuccessAsync(_mapper.Map<SP_AddressQueryDto>(item), "SP_Address record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_AddressQueryDto>.FailAsync($"UpdateSP_Address > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SP_AddressDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_AddressRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SP_AddressRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_AddressQueryDto>.SuccessAsync(_mapper.Map<SP_AddressQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_AddressQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
