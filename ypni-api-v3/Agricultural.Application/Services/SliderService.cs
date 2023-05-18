using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Slider;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Slider;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SliderService : ISliderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SliderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<SliderQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.SliderRepository.MyGetAll();


            var itemMap = _mapper.Map<IEnumerable<SliderQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SliderQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SliderQueryDto>>.SuccessAsync(itemMap, "Slider records retrieved");



        }

        public async Task<IResult<DtResult<SliderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.SliderRepository.GetAll(x => new SliderQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details,
                Type = x.Type,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SliderRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SliderQueryDto>>(items);

            var datatableReturned = DtResult<SliderQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SliderQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SliderQueryDto>>.SuccessAsync(datatableReturned, message: "Get Slider Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<SliderQueryDto>>> Find(Expression<Func<SliderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Slider, bool>>>(expression);

            var items = await _repositoryManager.SliderRepository.Find(x => new SliderQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details,
                Type = x.Type,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,



            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SliderQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<SliderQueryDto>>.FailAsync("GetAddresses > the given id NOT EXIEST !!!...");
            return await Result<IEnumerable<SliderQueryDto>>.SuccessAsync(itemMap, "Slider records retrieved");
        }

        public async Task<IResult<DtResult<SliderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SliderQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Slider, bool>>>(expression);

            var items = await _repositoryManager.SliderRepository.Find(x => new SliderQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                Details = x.Details,
                Type = x.Type,
                ServiceProviderId = x.ServiceProviderId,
                ServiceProviderName = x.ServiceProvider.TradeName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,



            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SliderRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SliderQueryDto>>(items);

            var datatableReturned = DtResult<SliderQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<SliderQueryDto>>.FailAsync("GetSlider > the given id NOT EXIEST !!!...");
            return await Result<DtResult<SliderQueryDto>>.SuccessAsync(datatableReturned, message: "Get Slider Datatable.", 200);
        }
         

        public async Task<IResult<SliderQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SliderRepository.GetById(Id);

            if (item == null) return await Result<SliderQueryDto>.FailAsync("GetSliderById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SliderQueryDto>(item);

            return await Result<SliderQueryDto>.SuccessAsync(itemMap, "Slider record retrieved");
        }

        public async Task<IResult<IEnumerable<SliderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SliderRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SliderDDlLViewModels>>.FailAsync("GetSliderDDL > ERRORS !!!...");

            return await Result<IEnumerable<SliderDDlLViewModels>>.SuccessAsync(item, "Slider DDL records retrieved");
        }
        public async Task<IResult<SliderDto>> Add(SliderDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SliderDto>.FailAsync("AddSlider > the passed entity IS NULL !!!.");

            try
            {

                var newEntity = await _repositoryManager.SliderRepository.AddAndReturn(_mapper.Map<Slider>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SliderDto>(newEntity);

                return await Result<SliderDto>.SuccessAsync(entityMap, "Slider record added");
            }
            catch (Exception exc)
            {

                return await Result<SliderDto>.FailAsync($"AddSlider > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SliderRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSlider > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SliderRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSlider record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSlider > Something went wrong1111 !!!{exc.Message}");
            }
        }

        public async Task<IResult<SliderQueryDto>> Update(SliderDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SliderQueryDto>.FailAsync($"UpdateSlider > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SliderRepository.GetById(entity.Id);

            if (item == null) return await Result<SliderQueryDto>.FailAsync("UpdateSlider > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.SliderRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SliderQueryDto>.SuccessAsync(_mapper.Map<SliderQueryDto>(item), "Slider record updated");
            }
            catch (Exception exc)
            {
                return await Result<SliderQueryDto>.FailAsync($"UpdateSlider > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SliderDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SliderRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SliderRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SliderQueryDto>.SuccessAsync(_mapper.Map<SliderQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SliderQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

        
    }
}
