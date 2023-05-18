using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SliderImages;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SliderImages;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class SliderImagesService : ISliderImagesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SliderImagesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<SliderImagesQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SliderImagesRepository.GetAll(x => new SliderImagesQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Active = x.Active,
                ImageUrl = x.ImageUrl,
             
                SliderId=x.SliderId,
                Url=x.Url,
                

            });

            var itemMap = _mapper.Map<IEnumerable<SliderImagesQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SliderImagesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SliderImagesQueryDto>>.SuccessAsync(itemMap, "Slider records retrieved");
        }

        public async Task<IResult<DtResult<SliderImagesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.SliderImagesRepository.GetAll(x => new SliderImagesQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Active = x.Active,
                ImageUrl = x.ImageUrl,
                SliderId = x.SliderId,
                Url = x.Url,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SliderImagesRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SliderImagesQueryDto>>(items);

            var datatableReturned = DtResult<SliderImagesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SliderImagesQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SliderImagesQueryDto>>.SuccessAsync(datatableReturned, message: "Get Slider Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<SliderImagesQueryDto>>> Find(Expression<Func<SliderImagesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SliderImages, bool>>>(expression);

            var items = await _repositoryManager.SliderImagesRepository.Find(x => new SliderImagesQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Active = x.Active,
                ImageUrl = x.ImageUrl,
                SliderId = x.SliderId,
                Url = x.Url,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SliderImagesQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<SliderImagesQueryDto>>.FailAsync("GetAddresses > the given id NOT EXIEST !!!...");
            return await Result<IEnumerable<SliderImagesQueryDto>>.SuccessAsync(itemMap, "Slider records retrieved");
        }

        public async Task<IResult<DtResult<SliderImagesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SliderImagesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SliderImages, bool>>>(expression);

            var items = await _repositoryManager.SliderImagesRepository.Find(x => new SliderImagesQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Active = x.Active,
                ImageUrl = x.ImageUrl,
                SliderId = x.SliderId,
                Url = x.Url,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SliderImagesRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SliderImagesQueryDto>>(items);

            var datatableReturned = DtResult<SliderImagesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<SliderImagesQueryDto>>.FailAsync("GetAddresses > the given id NOT EXIEST !!!...");
            return await Result<DtResult<SliderImagesQueryDto>>.SuccessAsync(datatableReturned, message: "Get Slider Datatable.", 200);
        }


        public async Task<IResult<SliderImagesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SliderImagesRepository.GetById(Id);

            if (item == null) return await Result<SliderImagesQueryDto>.FailAsync("GetSliderById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SliderImagesQueryDto>(item);

            return await Result<SliderImagesQueryDto>.SuccessAsync(itemMap, "Slider record retrieved");
        }

        public async Task<IResult<IEnumerable<SliderImagesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SliderImagesRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SliderImagesDDlLViewModels>>.FailAsync("GetSliderDDL > ERRORS !!!...");

            return await Result<IEnumerable<SliderImagesDDlLViewModels>>.SuccessAsync(item, "Slider DDL records retrieved");
        }
        public async Task<IResult<SliderImagesDto>> Add(SliderImagesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SliderImagesDto>.FailAsync("AddSlider > the passed entity IS NULL !!!.");

            try
            {

                var newEntity = await _repositoryManager.SliderImagesRepository.AddAndReturn(_mapper.Map<SliderImages>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SliderImagesDto>(newEntity);

                return await Result<SliderImagesDto>.SuccessAsync(entityMap, "Slider record added");
            }
            catch (Exception exc)
            {

                return await Result<SliderImagesDto>.FailAsync($"AddSlider > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SliderImagesRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSlider > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SliderImagesRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSlider record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSlider > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SliderImagesQueryDto>> Update(SliderImagesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SliderImagesQueryDto>.FailAsync($"UpdateSlider > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SliderImagesRepository.GetById(entity.Id);

            if (item == null) return await Result<SliderImagesQueryDto>.FailAsync("UpdateSlider > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.SliderImagesRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SliderImagesQueryDto>.SuccessAsync(_mapper.Map<SliderImagesQueryDto>(item), "Slider record updated");
            }
            catch (Exception exc)
            {
                return await Result<SliderImagesQueryDto>.FailAsync($"UpdateSlider > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SliderImagesDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SliderImagesRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SliderImagesRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SliderImagesQueryDto>.SuccessAsync(_mapper.Map<SliderImagesQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SliderImagesQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

       
    }
}
