using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.BusinessCommercial;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.BusinessCommercial;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class BusinessCommercialService : IBusinessCommercialService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BusinessCommercialService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<BusinessCommercialQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BusinessCommercialRepository.GetAll(x => new BusinessCommercialQueryDto
            {
                Id=x.Id,
                BankAccount=x.BankAccount,
                ServiceProviderId=(int)x.ServiceProviderId,
                Active=x.Active,
                TradeRecord=x.TradeRecord,
                
            });

            var itemMap = _mapper.Map<IEnumerable<BusinessCommercialQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<BusinessCommercialQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<BusinessCommercialQueryDto>>.SuccessAsync(itemMap, "BusinessCommercial records retrieved");
        }

        public async Task<IResult<DtResult<BusinessCommercialQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.BusinessCommercialRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.BusinessCommercialRepository.GetAll(x => new BusinessCommercialQueryDto
            {
                Id = x.Id,
                BankAccount = x.BankAccount,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                TradeRecord = x.TradeRecord,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BusinessCommercialRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<BusinessCommercialQueryDto>>(items);

            var datatableReturned = DtResult<BusinessCommercialQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<BusinessCommercialQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<BusinessCommercialQueryDto>>.SuccessAsync(datatableReturned, message: "Get BusinessCommercial Datatable.", 200);

        }


        public async Task<IResult<BusinessCommercialDto>> Find(Expression<Func<BusinessCommercialDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<BusinessCommercial, bool>>>(expression);

            //var items = await _repositoryManager.BusinessCommercialRepository.Find(mapExpr);

            var items = await _repositoryManager.BusinessCommercialRepository.Find(mapExpr);
            var recored = items.OrderBy(x => x.Id).LastOrDefault();
            var itemMap = _mapper.Map<BusinessCommercialDto>(recored); 
            //if (items == null) return await Result<BusinessCommercialDto>.FailAsync( "No Data");
            return await Result<BusinessCommercialDto>.SuccessAsync(itemMap, "BusinessCommercial records retrieved");
        }

        public async Task<IResult<DtResult<BusinessCommercialQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BusinessCommercialQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<BusinessCommercial, bool>>>(expression);

            //var items = await _repositoryManager.BusinessCommercialRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.BusinessCommercialRepository.Find(x => new BusinessCommercialQueryDto
            {
                Id = x.Id,
                BankAccount = x.BankAccount,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                TradeRecord = x.TradeRecord,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BusinessCommercialRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<BusinessCommercialQueryDto>>(items);

            var datatableReturned = DtResult<BusinessCommercialQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
          //  if (items == null) return await Result<DtResult<BusinessCommercialQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<BusinessCommercialQueryDto>>.SuccessAsync(datatableReturned, message: "Get BusinessCommercial Datatable.", 200);
        }


        public async Task<IResult<BusinessCommercialQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.BusinessCommercialRepository.GetById(Id);

            if (item == null) return await Result<BusinessCommercialQueryDto>.FailAsync("GetBusinessCommercialById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<BusinessCommercialQueryDto>(item);

            return await Result<BusinessCommercialQueryDto>.SuccessAsync(itemMap, "BusinessCommercial record retrieved");
        }

        public async Task<IResult<IEnumerable<BusinessCommercialDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.BusinessCommercialRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<BusinessCommercialDDlLViewModels>>.FailAsync("GetBusinessCommercialDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<BusinessCommercialDDLViewModel>(item);

            return await Result<IEnumerable<BusinessCommercialDDlLViewModels>>.SuccessAsync(item, "BusinessCommercial DDL records retrieved");
        }
        public async Task<IResult<BusinessCommercialQueryDto>> Add(BusinessCommercialDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<BusinessCommercialQueryDto>.FailAsync("AddBusinessCommercial > the passed entity IS NULL !!!.");

            try
            {
               
                var newEntity = await _repositoryManager.BusinessCommercialRepository.AddAndReturn(_mapper.Map<BusinessCommercial>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<BusinessCommercialQueryDto>(newEntity);

                return await Result<BusinessCommercialQueryDto>.SuccessAsync(entityMap, "BusinessCommercial record added");
            }
            catch (Exception exc)
            {

                return await Result<BusinessCommercialQueryDto>.FailAsync($"AddBusinessCommercial > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BusinessCommercialRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveBusinessCommercial > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.BusinessCommercialRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveBusinessCommercial record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveBusinessCommercial > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<BusinessCommercialQueryDto>> Update(BusinessCommercialDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<BusinessCommercialQueryDto>.FailAsync($"UpdateBusinessCommercial > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.BusinessCommercialRepository.GetById(Convert.ToInt32(entity.Id));

            _mapper.Map(entity, item);

            _repositoryManager.BusinessCommercialRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BusinessCommercialQueryDto>.SuccessAsync(_mapper.Map<BusinessCommercialQueryDto>(item), "BusinessCommercial record updated");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return await Result<BusinessCommercialQueryDto>.FailAsync($"UpdateBusinessCommercial > Something went wrong !!!\n\n\n{exc.Message}");
            }


        }
        public async Task<IResult> ChangeActive(BusinessCommercialDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BusinessCommercialRepository.GetById(Convert.ToInt32(entity.Id));
            item.Active = !item.Active;
            _repositoryManager.BusinessCommercialRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BusinessCommercialQueryDto>.SuccessAsync(_mapper.Map<BusinessCommercialQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<BusinessCommercialQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
