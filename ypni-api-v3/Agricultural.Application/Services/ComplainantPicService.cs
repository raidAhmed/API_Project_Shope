using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ComplainantPic;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantPic;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ComplainantPicService : IComplainantPicService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ComplainantPicService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ComplainantPicQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ComplainantPicRepository.GetAll(x => new ComplainantPicQueryDto
            {
               Id = x.Id,
               ComplainantToPartyId =(int)x.ComplainantToPartyId,
               Image=x.Image,
                

            });

            var itemMap = _mapper.Map<IEnumerable<ComplainantPicQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ComplainantPicQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ComplainantPicQueryDto>>.SuccessAsync(itemMap, "ComplainantPic records retrieved");
        }

        public async Task<IResult<DtResult<ComplainantPicQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ComplainantPicRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ComplainantPicRepository.GetAll(x => new ComplainantPicQueryDto
            {
                Id = x.Id,
                ComplainantToPartyId = (int)x.ComplainantToPartyId,
                Image = x.Image,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ComplainantPicRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ComplainantPicQueryDto>>(items);

            var datatableReturned = DtResult<ComplainantPicQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ComplainantPicQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ComplainantPicQueryDto>>.SuccessAsync(datatableReturned, message: "Get ComplainantPic Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ComplainantPicQueryDto>>> Find(Expression<Func<ComplainantPicQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ComplainantPic, bool>>>(expression);

            //var items = await _repositoryManager.ComplainantPicRepository.Find(mapExpr);

            var items = await _repositoryManager.ComplainantPicRepository.Find(x => new ComplainantPicQueryDto
            {
                Id = x.Id,
                ComplainantToPartyId = (int)x.ComplainantToPartyId,
                Image = x.Image,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ComplainantPicQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ComplainantPicQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ComplainantPicQueryDto>>.SuccessAsync(itemMap, "ComplainantPic records retrieved");
        }

        public async Task<IResult<DtResult<ComplainantPicQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ComplainantPicQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ComplainantPic, bool>>>(expression);

            //var items = await _repositoryManager.ComplainantPicRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ComplainantPicRepository.Find(x => new ComplainantPicQueryDto
            {
                Id = x.Id,
                ComplainantToPartyId = (int)x.ComplainantToPartyId,
                Image = x.Image,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ComplainantPicRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ComplainantPicQueryDto>>(items);

            var datatableReturned = DtResult<ComplainantPicQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ComplainantPicQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ComplainantPicQueryDto>>.SuccessAsync(datatableReturned, message: "Get ComplainantPic Datatable.", 200);
        }


        public async Task<IResult<ComplainantPicQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ComplainantPicRepository.GetById(Id);

            if (item == null) return await Result<ComplainantPicQueryDto>.FailAsync("GetComplainantPicById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ComplainantPicQueryDto>(item);

            return await Result<ComplainantPicQueryDto>.SuccessAsync(itemMap, "ComplainantPic record retrieved");
        }

        public async Task<IResult<IEnumerable<ComplainantPicDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ComplainantPicRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ComplainantPicDDlLViewModels>>.FailAsync("GetComplainantPicDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ComplainantPicDDLViewModel>(item);

            return await Result<IEnumerable<ComplainantPicDDlLViewModels>>.SuccessAsync(item, "ComplainantPic DDL records retrieved");
        }
        public async Task<IResult<ComplainantPicQueryDto>> Add(ComplainantPicDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ComplainantPicQueryDto>.FailAsync("AddComplainantPic > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ComplainantPicRepository.AddAndReturn(_mapper.Map<ComplainantPic>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ComplainantPicQueryDto>(newEntity);

                return await Result<ComplainantPicQueryDto>.SuccessAsync(entityMap, "ComplainantPic record added");
            }
            catch (Exception exc)
            {

                return await Result<ComplainantPicQueryDto>.FailAsync($"AddComplainantPic > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ComplainantPicRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveComplainantPic > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ComplainantPicRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveComplainantPic record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveComplainantPic > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ComplainantPicQueryDto>> Update(ComplainantPicDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ComplainantPicQueryDto>.FailAsync($"UpdateComplainantPic > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ComplainantPicRepository.GetById(entity.Id);

            if (item == null) return await Result<ComplainantPicQueryDto>.FailAsync("UpdateComplainantPic > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ComplainantPicRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ComplainantPicQueryDto>.SuccessAsync(_mapper.Map<ComplainantPicQueryDto>(item), "ComplainantPic record updated");
            }
            catch (Exception exc)
            {
                return await Result<ComplainantPicQueryDto>.FailAsync($"UpdateComplainantPic > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ComplainantPicDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ComplainantPicRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ComplainantPicRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ComplainantPicQueryDto>.SuccessAsync(_mapper.Map<ComplainantPicQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ComplainantPicQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
