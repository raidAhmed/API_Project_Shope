using Agricultural.Application.Common;
using Agricultural.Domain.Entity;
using Agricultural.Application.DTOs.Currency;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.Wrapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CurrencyService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IResult<CurrencyQueryDto>> Add(CurrencyDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<CurrencyQueryDto>.FailAsync("AddCurrency > the passed entity IS NULL !!!.");
            try
            {
                var newEntity = await _repositoryManager.CurrencyRepository.AddAndReturn(_mapper.Map<Currency>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<CurrencyQueryDto>(newEntity);

                return await Result<CurrencyQueryDto>.SuccessAsync(entityMap, "Currency record added");
            }
            catch (Exception exc)
            {

                return await Result<CurrencyQueryDto>.FailAsync($"AddCurrency > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public Task<IResult<IEnumerable<CurrencyQueryDto>>> Find(Expression<Func<CurrencyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<DtResult<CurrencyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CurrencyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<IEnumerable<CurrencyQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.CurrencyRepository.GetAll(x => new CurrencyQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Active=x.Active,
                
                
            });
          
            var itemMap = _mapper.Map<IEnumerable<CurrencyQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<CurrencyQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<CurrencyQueryDto>>.SuccessAsync(itemMap, "ServiceProvider records retrieved");

        }

        public Task<IResult<DtResult<CurrencyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public List<CurrencyQueryDto> GetAllmvc(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<CurrencyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CurrencyRepository.GetById(Id);
            if (item == null) return await Result<CurrencyQueryDto>.FailAsync("GetActivityTypeById > the given id NOT EXIEST !!!...");
            var itemMap = _mapper.Map<CurrencyQueryDto>(item);
            return await Result<CurrencyQueryDto>.SuccessAsync(itemMap, "ActivityType record retrieved");
        }

        public Task<IResult<IEnumerable<CurrencyDto>>> GetDDL(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CurrencyRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveCurrency > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.CurrencyRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveCurrency record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveCurrency > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<CurrencyQueryDto>> Update(CurrencyDto entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return await Result<CurrencyQueryDto>.FailAsync($"UpdateCurrency > the passed entity IS NULL!!!...");
            var item = await _repositoryManager.CurrencyRepository.GetById(entity.Id);
            if (item == null) return await Result<CurrencyQueryDto>.FailAsync("UpdateCurrency > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            try
            {
                _repositoryManager.CurrencyRepository.Update(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                return await Result<CurrencyQueryDto>.SuccessAsync(_mapper.Map<CurrencyQueryDto>(item), "Currency record updated");
            }
            catch (Exception exc)
            {
                return await Result<CurrencyQueryDto>.FailAsync($"UpdateCurrency > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(CurrencyDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.CurrencyRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.CurrencyRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<CurrencyQueryDto>.SuccessAsync(_mapper.Map<CurrencyQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<CurrencyQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
