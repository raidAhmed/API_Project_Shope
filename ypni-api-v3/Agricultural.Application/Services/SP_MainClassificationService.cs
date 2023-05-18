using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_MainClassification;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using System.Collections.Generic;

namespace Agricultural.Application.Services
{
    public class SP_MainClassificationService : ISP_MainClassificationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SP_MainClassificationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<SP_MainClassificationQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_MainClassificationRepository.GetAll(x => new SP_MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                
            });
           // var itemss = items.Where(s=>s.ServiceProviderId==8);
            var itemMap = _mapper.Map<IEnumerable<SP_MainClassificationQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SP_MainClassificationQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_MainClassificationQueryDto>>.SuccessAsync(itemMap, "SP_MainClassification records retrieved");
        }

        public async Task<IResult<DtResult<SP_MainClassificationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SP_MainClassificationRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_MainClassificationRepository.GetAll(x => new SP_MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_MainClassificationRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SP_MainClassificationQueryDto>>(items);

            var datatableReturned = DtResult<SP_MainClassificationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_MainClassificationQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_MainClassificationQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_MainClassification Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<SP_MainClassificationQueryDto>>> Find(Expression<Func<SP_MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_MainClassification, bool>>>(expression);

            //var items = await _repositoryManager.SP_MainClassificationRepository.Find(mapExpr);

            var items = await _repositoryManager.SP_MainClassificationRepository.Find(x => new SP_MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ServiceProviderId = (int)x.ServiceProviderId,
                
                Active = x.Active,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SP_MainClassificationQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<SP_MainClassificationQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_MainClassificationQueryDto>>.SuccessAsync(itemMap, "SP_MainClassification records retrieved");
        }

        public async Task<IResult<DtResult<SP_MainClassificationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_MainClassification, bool>>>(expression);

            //var items = await _repositoryManager.SP_MainClassificationRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_MainClassificationRepository.Find(x => new SP_MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ServiceProviderId = (int)x.ServiceProviderId,
            
                Active = x.Active,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_MainClassificationRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SP_MainClassificationQueryDto>>(items);

            var datatableReturned = DtResult<SP_MainClassificationQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<SP_MainClassificationQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<SP_MainClassificationQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_MainClassification Datatable.", 200);
        }


        public async Task<IResult<SP_MainClassificationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_MainClassificationRepository.GetAll(x => new SP_MainClassificationQueryDto
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,

            });
            
             var srhasmain = items.Where(x => x.ServiceProviderId == 3); 

            if (srhasmain == null) return await Result<SP_MainClassificationQueryDto>.FailAsync("GetSP_MainClassificationById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<SP_MainClassificationQueryDto>(srhasmain);

            return await Result<SP_MainClassificationQueryDto>.SuccessAsync(itemMap, "SP_MainClassification record retrieved");
        }

        public async Task<IResult<IEnumerable<SP_MainClassificationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_MainClassificationRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SP_MainClassificationDDlLViewModels>>.FailAsync("GetSP_MainClassificationDDL > ERRORS !!!...");


            return await Result<IEnumerable<SP_MainClassificationDDlLViewModels>>.SuccessAsync(item, "SP_MainClassification DDL records retrieved");
        }
        public async Task<IResult<SP_MainClassificationQueryDto>> Add(SP_MainClassificationDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SP_MainClassificationQueryDto>.FailAsync("AddSP_MainClassification > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.SP_MainClassificationRepository.AddAndReturn(_mapper.Map<SP_MainClassification>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
               

                var entityMap = _mapper.Map<SP_MainClassificationQueryDto>(newEntity);

                return await Result<SP_MainClassificationQueryDto>.SuccessAsync(entityMap, "SP_MainClassification record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_MainClassificationQueryDto>.FailAsync($"AddSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }
           public async Task<IResult<List<SP_MainClassificationQueryDto>>> Addlistt(List<SP_MainClassificationDtoApi> entity, CancellationToken cancellationToken = default)
        {

          
            try
            {                
                var ds = new List<SP_MainClassification>();
                for (var sx = 0; sx < entity.Count; sx++)
                {
                    var check = _repositoryManager.SP_MainClassificationRepository.Find(x=>x.MainClassificationId== entity[sx].MainClassificationId &&x.ServiceProviderId == entity[sx].ServiceProviderId);
                    if (check.Result.Any()==false)
                    {
                        var s = new SP_MainClassification();
                        s.MainClassificationId = entity[sx].MainClassificationId;
                        s.ServiceProviderId = entity[sx].ServiceProviderId;
                        s.Active = true;
                        ds.Add(s);
                    }
                    
                 
                }
                  var newEntity = _repositoryManager.SP_MainClassificationRepository.Addlist(ds);
                  await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                  var entityMap = new List<SP_MainClassificationQueryDto>();
                if (ds.Count != 0)
                {

                    for (var sx = 0; sx < newEntity.Count; sx++)
                    {
                        var jnew = new SP_MainClassificationQueryDto();
                        jnew.Id = newEntity[sx].Id;
                        jnew.MainClassificationId = newEntity[sx].MainClassificationId;
                        jnew.ServiceProviderId = newEntity[sx].ServiceProviderId;

                        entityMap.Add(jnew);
                    }

                    return await Result<List<SP_MainClassificationQueryDto>>.SuccessAsync(entityMap, "SP_MainClassification record added");

                }

                return await Result<List<SP_MainClassificationQueryDto>>.SuccessAsync(entityMap, "SP_MainClassification record added");


            }
            catch (Exception exc)
            {

                return await Result<List<SP_MainClassificationQueryDto>>.FailAsync($"AddSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_MainClassificationRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSP_MainClassification > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SP_MainClassificationRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSP_MainClassification record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SP_MainClassificationQueryDto>> Update(SP_MainClassificationDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SP_MainClassificationQueryDto>.FailAsync($"UpdateSP_MainClassification > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SP_MainClassificationRepository.GetById(entity.Id);

            if (item == null) return await Result<SP_MainClassificationQueryDto>.FailAsync("UpdateSP_MainClassification > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SP_MainClassificationRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_MainClassificationQueryDto>.SuccessAsync(_mapper.Map<SP_MainClassificationQueryDto>(item), "SP_MainClassification record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_MainClassificationQueryDto>.FailAsync($"UpdateSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SP_MainClassificationDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_MainClassificationRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SP_MainClassificationRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_MainClassificationQueryDto>.SuccessAsync(_mapper.Map<SP_MainClassificationQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_MainClassificationQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

		public async Task<IResult> Addlist(List<SP_MainClassificationDto> entity, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException(); if (entity == null) return await Result<SP_MainClassificationQueryDto>.FailAsync("AddSP_MainClassification > the passed entity IS NULL !!!.");

            try
            {
                var objb=new SP_MainClassification();
                var objblist=new List<SP_MainClassification>();
                foreach (var objj in entity)
				{
                    objb = _mapper.Map<SP_MainClassification>(objj);
                    objblist.Add(objb);
                }
                var newEntity =  _repositoryManager.SP_MainClassificationRepository.Addlist(objblist);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SP_MainClassificationQueryDto>(newEntity);

                return await Result<SP_MainClassificationQueryDto>.SuccessAsync(entityMap, "SP_MainClassification record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_MainClassificationQueryDto>.FailAsync($"AddSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }
    }
}
