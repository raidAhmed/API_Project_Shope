using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Color;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ColorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<ColorQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ColorRepository.GetAll(x => new ColorQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                code = x.code,
                Active=x.Active,
            });

            var itemMap = _mapper.Map<IEnumerable<ColorQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ColorQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ColorQueryDto>>.SuccessAsync(itemMap, "Color records retrieved");
        }

        public async Task<IResult<DtResult<ColorQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.ColorRepository.GetAll(x => new ColorQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                code = x.code,
                Active=x.Active,
            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ColorRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ColorQueryDto>>(items);

            var datatableReturned = DtResult<ColorQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ColorQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ColorQueryDto>>.SuccessAsync(datatableReturned, message: "Get Color Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<ColorQueryDto>>> Find(Expression<Func<ColorQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Color, bool>>>(expression);

            var items = await _repositoryManager.ColorRepository.Find(x => new ColorQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                code = x.code,
                Active=x.Active,
            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ColorQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ColorQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ColorQueryDto>>.SuccessAsync(itemMap, "Color records retrieved");
        }

        public async Task<IResult<DtResult<ColorQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ColorQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Color, bool>>>(expression);

            var items = await _repositoryManager.ColorRepository.Find(x => new ColorQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                code = x.code,
                Active=x.Active
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ColorRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ColorQueryDto>>(items);

            var datatableReturned = DtResult<ColorQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ColorQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ColorQueryDto>>.SuccessAsync(datatableReturned, message: "Get Color Datatable.", 200);
        }


        public async Task<IResult<ColorQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ColorRepository.GetById(Id);

            if (item == null) return await Result<ColorQueryDto>.FailAsync("GetColorById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ColorQueryDto>(item);

            return await Result<ColorQueryDto>.SuccessAsync(itemMap, "Color record retrieved");
        }

        public async Task<IResult<IEnumerable<ColorDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ColorRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ColorDDlLViewModels>>.FailAsync("GetColorDDL > ERRORS !!!...");

            return await Result<IEnumerable<ColorDDlLViewModels>>.SuccessAsync(item, "Color DDL records retrieved");
        }
        public async Task<IResult<ColorQueryDto>> Add(ColorDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ColorQueryDto>.FailAsync("AddColor > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.ColorRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<ColorQueryDto>.FailAsync("AddColor > the same record IS ALREADY EXIEST !!!.");

            try
            {
                //var ob = new Color();
                // ob.Name = entity.Name;
                // ob.code = entity.code;
                //var newEntity = await _repositoryManager.ColorRepository.AddAndReturn(ob);
                var newEntity = await _repositoryManager.ColorRepository.AddAndReturn(_mapper.Map<Color>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ColorQueryDto>(newEntity);

                return await Result<ColorQueryDto>.SuccessAsync(entityMap, "Color record added");
            }
            catch (Exception exc)
            {

                return await Result<ColorQueryDto>.FailAsync($"AddColor > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }
       
        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ColorRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveColor > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ColorRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveColor record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveColor > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ColorQueryDto>> Update(ColorDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ColorQueryDto>.FailAsync($"UpdateColor > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ColorRepository.GetById(entity.Id);

            if (item == null) return await Result<ColorQueryDto>.FailAsync("UpdateColor > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.ColorRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ColorQueryDto>.SuccessAsync(_mapper.Map<ColorQueryDto>(item), "Color record updated");
            }
            catch (Exception exc)
            {
                return await Result<ColorQueryDto>.FailAsync($"UpdateColor > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ColorDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ColorRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ColorRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ColorQueryDto>.SuccessAsync(_mapper.Map<ColorQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ColorQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
