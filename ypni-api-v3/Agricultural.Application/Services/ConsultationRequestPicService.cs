using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ConsultationRequestPic;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequestPic;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ConsultationRequestPicService : IConsultationRequestPicService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ConsultationRequestPicService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<ConsultationRequestPicQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ConsultationRequestPicRepository.GetAll(x => new ConsultationRequestPicQueryDto
            {
                Id = x.Id,
                Image = x.Image,
                ConsultationRequestId=(int)x.ConsultationRequestId,
                
                
            });

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestPicQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ConsultationRequestPicQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ConsultationRequestPicQueryDto>>.SuccessAsync(itemMap, "ConsultationRequestPic records retrieved");
        }

        public async Task<IResult<DtResult<ConsultationRequestPicQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ConsultationRequestPicRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ConsultationRequestPicRepository.GetAll(x => new ConsultationRequestPicQueryDto
            {
                Id = x.Id,
                Image = x.Image,
                ConsultationRequestId = (int)x.ConsultationRequestId,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ConsultationRequestPicRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestPicQueryDto>>(items);

            var datatableReturned = DtResult<ConsultationRequestPicQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ConsultationRequestPicQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ConsultationRequestPicQueryDto>>.SuccessAsync(datatableReturned, message: "Get ConsultationRequestPic Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<ConsultationRequestPicQueryDto>>> Find(Expression<Func<ConsultationRequestPicQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ConsultationRequestPic, bool>>>(expression);

            //var items = await _repositoryManager.ConsultationRequestPicRepository.Find(mapExpr);

            var items = await _repositoryManager.ConsultationRequestPicRepository.Find(x => new ConsultationRequestPicQueryDto
            {
                Id = x.Id,
                Image = x.Image,
                ConsultationRequestId = (int)x.ConsultationRequestId,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestPicQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ConsultationRequestPicQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ConsultationRequestPicQueryDto>>.SuccessAsync(itemMap, "ConsultationRequestPic records retrieved");
        }

        public async Task<IResult<DtResult<ConsultationRequestPicQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ConsultationRequestPicQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ConsultationRequestPic, bool>>>(expression);

            //var items = await _repositoryManager.ConsultationRequestPicRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ConsultationRequestPicRepository.Find(x => new ConsultationRequestPicQueryDto
            {
                Id = x.Id,
                Image = x.Image,
                ConsultationRequestId = (int)x.ConsultationRequestId,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ConsultationRequestPicRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ConsultationRequestPicQueryDto>>(items);

            var datatableReturned = DtResult<ConsultationRequestPicQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ConsultationRequestPicQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ConsultationRequestPicQueryDto>>.SuccessAsync(datatableReturned, message: "Get ConsultationRequestPic Datatable.", 200);
        }


        public async Task<IResult<ConsultationRequestPicQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ConsultationRequestPicRepository.GetById(Id);

            if (item == null) return await Result<ConsultationRequestPicQueryDto>.FailAsync("GetConsultationRequestPicById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ConsultationRequestPicQueryDto>(item);

            return await Result<ConsultationRequestPicQueryDto>.SuccessAsync(itemMap, "ConsultationRequestPic record retrieved");
        }

        public async Task<IResult<IEnumerable<ConsultationRequestPicDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ConsultationRequestPicRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ConsultationRequestPicDDlLViewModels>>.FailAsync("GetConsultationRequestPicDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ConsultationRequestPicDDLViewModel>(item);

            return await Result<IEnumerable<ConsultationRequestPicDDlLViewModels>>.SuccessAsync(item, "ConsultationRequestPic DDL records retrieved");
        }
        public async Task<IResult<ConsultationRequestPicQueryDto>> Add(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ConsultationRequestPicQueryDto>.FailAsync("AddConsultationRequestPic > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ConsultationRequestPicRepository.AddAndReturn(_mapper.Map<ConsultationRequestPic>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ConsultationRequestPicQueryDto>(newEntity);

                return await Result<ConsultationRequestPicQueryDto>.SuccessAsync(entityMap, "ConsultationRequestPic record added");
            }
            catch (Exception exc)
            {

                return await Result<ConsultationRequestPicQueryDto>.FailAsync($"AddConsultationRequestPic > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ConsultationRequestPicRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveConsultationRequestPic > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ConsultationRequestPicRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveConsultationRequestPic record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveConsultationRequestPic > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ConsultationRequestPicQueryDto>> Update(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ConsultationRequestPicQueryDto>.FailAsync($"UpdateConsultationRequestPic > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ConsultationRequestPicRepository.GetById(entity.Id);

            if (item == null) return await Result<ConsultationRequestPicQueryDto>.FailAsync("UpdateConsultationRequestPic > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ConsultationRequestPicRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ConsultationRequestPicQueryDto>.SuccessAsync(_mapper.Map<ConsultationRequestPicQueryDto>(item), "ConsultationRequestPic record updated");
            }
            catch (Exception exc)
            {
                return await Result<ConsultationRequestPicQueryDto>.FailAsync($"UpdateConsultationRequestPic > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ConsultationRequestPicRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ConsultationRequestPicRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ConsultationRequestPicQueryDto>.SuccessAsync(_mapper.Map<ConsultationRequestPicQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ConsultationRequestPicQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
