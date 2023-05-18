using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_AdditionalSections;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using System.Linq;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.Product;

namespace Agricultural.Application.Services
{
    public class SP_AdditionalSectionsService : ISP_AdditionalSectionsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SP_AdditionalSectionsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<List<SP_AdditionalSectionsQueryDto>>> Addlistt(List<SP_AdditionalSectionsDtoApi> entity, CancellationToken cancellationToken = default)
        {


            try
            {

                var ds = new List<SP_AdditionalSections>();
                for (var sx = 0; sx < entity.Count; sx++)
                {
                    var check = _repositoryManager.SP_AdditionalSectionsRepository.Find(x => x.AdditionalSectionsId == entity[sx].AdditionalSectionsId && x.ServiceProviderId == entity[sx].ServiceProviderId);
                    if (check.Result.Any() == false)
                    {
                        var s = new SP_AdditionalSections();
                        s.AdditionalSectionsId = entity[sx].AdditionalSectionsId;
                        s.ServiceProviderId = entity[sx].ServiceProviderId;
                        s.Active = true;
                        ds.Add(s);
                    }
                }

                var newEntity = _repositoryManager.SP_AdditionalSectionsRepository.Addlist(ds);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                var entityMap = new List<SP_AdditionalSectionsQueryDto>();
                if (ds.Count != 0)
                {
                    for (var sx = 0; sx < newEntity.Count; sx++)
                    {
                        var jnew = new SP_AdditionalSectionsQueryDto();
                        jnew.Id = newEntity[sx].Id;
                        jnew.AdditionalSectionsId = newEntity[sx].AdditionalSectionsId;
                        jnew.ServiceProviderId = newEntity[sx].ServiceProviderId;
                       
                        entityMap.Add(jnew);
                    }
                }

                return await Result<List<SP_AdditionalSectionsQueryDto>>.SuccessAsync(entityMap, "SP_AdditionalSections record added");
            }
            catch (Exception exc)
            {

                return await Result<List<SP_AdditionalSectionsQueryDto>>.FailAsync($"SP_AdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId=x.AdditionalSections.MainClassificationId,
                ParnetSectionId=x.AdditionalSections.ParnetSectionId,
            });

          //  var itemss = items.Where(s => s.ServiceProviderId == 8);
            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");
        } 
        public async Task<IResult<IEnumerable<SP_AdditionalSectionsDto>>> GetAllForCertainSP(int ServiceProviderId, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId =(int) x.AdditionalSections.ParnetSectionId,

            });

            var itemss = items.Where(s => s.ServiceProviderId == ServiceProviderId);
            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsDto>>(itemss);
            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SP_AdditionalSectionsDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");
        }

        public async Task<IResult<DtResult<SP_AdditionalSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_AdditionalSectionsRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(items);

            var datatableReturned = DtResult<SP_AdditionalSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SP_AdditionalSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_AdditionalSections Datatable.", 200);

        }
        public async Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetByIdSPInfo(int ServId, CancellationToken cancellationToken = default)
        {
            var listserifor = new List<MainAndAdditionalClassificationDtoApi>();
            
            var items = await _repositoryManager.SP_MainClassificationRepository.Find(x => new MainClassificationDtoApi
            {
                Id = x.Id,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                ImageUrl = x.MainClassification.ImageUrl,
                serviceProviderId = (int)x.ServiceProviderId,



            }, x => x.ServiceProviderId == ServId);


            if (items.Any())
            {

                foreach (var item in items)
                {
                    var maforobj = new List<AdditionalSectionsDto2>();
                    var maforobj22 = new MainAndAdditionalClassificationDtoApi();
                   
                    var resinfo = await _repositoryManager.SP_AdditionalSectionsRepository.Find(x => new AdditionalSectionsDtoApi
                    {
                        Id = x.Id,
                        AdditionalSectionsId = x.AdditionalSections.Id,
                        AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                        ImageUrl = x.AdditionalSections.ImageUrl,
                         
                        ParnetSectionId = x.AdditionalSections.ParnetSectionId
                    }, x => x.AdditionalSections.MainClassificationId == item.MainClassificationId && x.ServiceProviderId == ServId);

                    maforobj22.Id = item.Id; 
                    maforobj22.MainClassificationId = item.MainClassificationId;
                    maforobj22.MainClassificationName = item.MainClassificationName;
                    maforobj22.ImageUrl = item.ImageUrl;
                    maforobj22.serviceProviderId = item.serviceProviderId;

                   
                    if (resinfo.Any())
                    {

                        foreach (var obj in resinfo) 
                        {
                            var maforobj2 = new AdditionalSectionsDto2();
                            var resinfo2 = await _repositoryManager.SpecialSectionsRepository.Find(x => new SpecialSectionsDtoApi
                            {
                                Id = x.Id,
                                 SpecialSectionName=x.SpecialSectionName,
                                AdditionalSectionsId = x.AdditionalSections.Id,
                                 serviceProviderId = item.serviceProviderId,
                                  MainClassificationId  = item.MainClassificationId,
                                   Rank = x.Rank,
                                ImageUrl = x.ImageUrl
                            }, x => x.AdditionalSections.Id == obj.AdditionalSectionsId && x.ServiceProviderId == ServId);

                            maforobj2.Id = obj.Id;
                            maforobj2.AdditionalSectionsId = obj.AdditionalSectionsId;
                            maforobj2.ImageUrl = obj.ImageUrl;
                            maforobj2.serviceProviderId = item.serviceProviderId;
                            maforobj2.AdditionalSectionsName=obj.AdditionalSectionsName; 
                          
                          

                            if (resinfo2.Count() != 0)
                            {
                                maforobj2.specialSectionsDto = resinfo2.ToList();

                            }
                            else
                            {

                                maforobj2.specialSectionsDto = new List<SpecialSectionsDtoApi>();
                            }

                            maforobj.Add(maforobj2);

                            

                        }
                    }


            


                    if (resinfo.Count() != 0)
                    {
                        //    maforobj.AdditionalSectionsDto = resinfo.ToList();
                        maforobj22.AdditionalSectionsDto = maforobj.ToList();
                    }
                    else
                    {

                        maforobj22.AdditionalSectionsDto = new List<AdditionalSectionsDto2>();
                    }

                    

                    listserifor.Add(maforobj22);
                }
            }


            //   var itemMap = _mapper.Map<IEnumerable<ServiceProviderQueryDto>>(listserifor);

            return await Result<IEnumerable<MainAndAdditionalClassificationDtoApi>>.SuccessAsync(listserifor, "SP_User_Favourites records retrieved");
        }
             public async Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetByIdSPInfoAll( CancellationToken cancellationToken = default)
        {
            var listserifor = new List<MainAndAdditionalClassificationDtoApi>();
            var items = await _repositoryManager.MainClassificationRepository.GetAll(x => new MainClassificationDtoApi
            {
                Id = x.Id,
                MainClassificationId=x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl



            });


            if (items.Any())
            {

                foreach (var item in items)
                {
                    var maforobj = new MainAndAdditionalClassificationDtoApi();
                    var resinfo = await _repositoryManager.AdditionalSectionsRepository.Find(x => new AdditionalSectionsDto2
                    {
                        Id = x.Id,
                        AdditionalSectionsId = x.Id,
                        AdditionalSectionsName = x.AdditionalSectionsName,
                        ImageUrl = x.ImageUrl,
                        ParnetSectionId = x.ParnetSectionId
                    }, x => x.MainClassificationId == item.Id );

                    maforobj.Id = item.Id;
                    maforobj.MainClassificationId = item.Id;
                    maforobj.MainClassificationName = item.MainClassificationName;
                    maforobj.ImageUrl = item.ImageUrl;
      


                    if (resinfo.Count() != 0)
                    {
                        maforobj.AdditionalSectionsDto = resinfo.ToList();

                    }
                    else
                    {

                        maforobj.AdditionalSectionsDto = new List<AdditionalSectionsDto2>();
                    }

                    listserifor.Add(maforobj);
                }
            }


            //   var itemMap = _mapper.Map<IEnumerable<ServiceProviderQueryDto>>(listserifor);

            return await Result<IEnumerable<MainAndAdditionalClassificationDtoApi>>.SuccessAsync(listserifor, "SP_User_Favourites records retrieved");
        }


        public async Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> Find(Expression<Func<SP_AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_AdditionalSections, bool>>>(expression);

            //var items = await _repositoryManager.SP_AdditionalSectionsRepository.Find(mapExpr);

            var items = await _repositoryManager.SP_AdditionalSectionsRepository.Find(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");
        }

        public async Task<IResult<DtResult<SP_AdditionalSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<SP_AdditionalSections, bool>>>(expression);

            //var items = await _repositoryManager.SP_AdditionalSectionsRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.SP_AdditionalSectionsRepository.Find(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.SP_AdditionalSectionsRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(items);

            var datatableReturned = DtResult<SP_AdditionalSectionsQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<SP_AdditionalSectionsQueryDto>>.SuccessAsync(datatableReturned, message: "Get SP_AdditionalSections Datatable.", 200);
        }


        public async Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetByIdParnt(int ServiceProviderId, int AdditionId, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,

            });
            var sd = items.Where(x => x.ParnetSectionId == AdditionId&&x.ServiceProviderId==ServiceProviderId);
            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(sd);

            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");

        }
        public async Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetByMainClassficationId( int ServiceProviderId, int AdditionId, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,

            });
            var sd = items.Where(x => x.MainClassificationId == AdditionId&&x.ServiceProviderId==ServiceProviderId);
            var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(sd);

            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");

        }
        public async Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetById(int Id, CancellationToken cancellationToken = default)
        {
            //var itemm = await _repositoryManager.SP_AdditionalSectionsRepository.FindAllwinclude(x=>x.ServiceProviderId==3, includes: q => q.Include(x => x.AdditionalSections));
            //var itemnew = new SP_AdditionalSectionsQueryDto();
            //var itemnewb = new List<SP_AdditionalSectionsQueryDto>();
            //foreach (var obj in itemm)
            //{
            //    itemnew.AdditionalSectionsId =(int)obj.AdditionalSectionsId;
            //    itemnew.AdditionalSectionsName =obj.AdditionalSections.AdditionalSectionsName;
            //    itemnewb.Add(itemnew);
            //}
            var items = await _repositoryManager.SP_AdditionalSectionsRepository.GetAll(x => new SP_AdditionalSectionsQueryDto
            {
                Id = x.Id,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                ServiceProviderId = (int)x.ServiceProviderId,
                Active = x.Active,
                MainClassificationId = x.AdditionalSections.MainClassificationId,
                ParnetSectionId = (int)x.AdditionalSections.ParnetSectionId,

            });
            var sd = items.Where(x=>x.MainClassificationId== Id);
            //    var itemMap = _mapper.Map<IEnumerable<SP_AdditionalSectionsQueryDto>>(itemm.);
            ////   var expression = Expression <Func<SP_AdditionalSectionsQueryDto, bool> > expression;
            //Expression<Func<SP_AdditionalSectionsQueryDto, bool>> expression;
            //var mapExpr = _mapper.Map<Expression<Func<SP_AdditionalSections, bool>>>(expression);
            //var itemmv = await _repositoryManager.SP_AdditionalSectionsRepository.Find(x => new SP_AdditionalSectionsQueryDto
            //{     Id=x.Id,        
            //},);

            //new AdditionalSectionsQueryDto
            //{

            //} 
            //(x => new AdditionalSectionsQueryDto
            //{
            //    Id = x.Id,
            //    AdditionalSectionsName = x.AdditionalSectionsName,
            //    Rank = x.Rank,
            //    ImageUrl = x.ImageUrl,
            //    ParnetSectionId = x.ParnetSectionId,
            //    MainClassificationId = (int)x.MainClassificationId,
            //    MainClassificationName = x.MainClassification.MainClassificationName,
            //    MainClassificationImageUrl = x.MainClassification.ImageUrl,

            //});

            //var item =  itemm.Where(x=>x.AdditionalSections.MainClassificationId==Id);
            //             
            //var listt=new List<AdditionalSections>();
            //         foreach (var itemDto in itemm)
            //         {
            //             var item = await _repositoryManager.AdditionalSectionsRepository.GetById(Convert.ToInt32(itemDto.AdditionalSectionsId));
            //             if(item.ParnetSectionId == 0&&item.MainClassificationId==Id)
            //             {
            //                 listt.Add(item);

            //             }
            //             if(item.ParnetSectionId !=0)
            //             {
            //                 var ite = await _repositoryManager.AdditionalSectionsRepository.GetById(Convert.ToInt32(item.ParnetSectionId));
            //                 if (ite.ParnetSectionId != 0)
            //                 {
            //                     ite = await _repositoryManager.AdditionalSectionsRepository.GetById(Convert.ToInt32(ite.ParnetSectionId));
            //                 }
            //                 }
            //         }


            // if (itemm == null) return await Result<SP_AdditionalSectionsQueryDto>.FailAsync("GetSP_AdditionalSectionsById > the given id NOT EXIEST !!!...");

            
            var itemMap = _mapper.Map< IEnumerable<SP_AdditionalSectionsQueryDto>>(sd);

            if (items == null) return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.FailAsync("No Data");

            return await Result<IEnumerable<SP_AdditionalSectionsQueryDto>>.SuccessAsync(itemMap, "SP_AdditionalSections records retrieved");

          //  return await Result<SP_AdditionalSectionsQueryDto>.SuccessAsync(itemMap, "SP_AdditionalSections record retrieved");
        }

        public async Task<IResult<IEnumerable<SP_AdditionalSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.SP_AdditionalSectionsRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<SP_AdditionalSectionsDDlLViewModels>>.FailAsync("GetSP_AdditionalSectionsDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<SP_AdditionalSectionsDDLViewModel>(item);

            return await Result<IEnumerable<SP_AdditionalSectionsDDlLViewModels>>.SuccessAsync(item, "SP_AdditionalSections DDL records retrieved");
        }
        public async Task<IResult<SP_AdditionalSectionsQueryDto>> Add(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<SP_AdditionalSectionsQueryDto>.FailAsync("AddSP_AdditionalSections > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.SP_AdditionalSectionsRepository.AddAndReturn(_mapper.Map<SP_AdditionalSections>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SP_AdditionalSectionsQueryDto>(newEntity);

                return await Result<SP_AdditionalSectionsQueryDto>.SuccessAsync(entityMap, "SP_AdditionalSections record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_AdditionalSectionsQueryDto>.FailAsync($"AddSP_AdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_AdditionalSectionsRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveSP_AdditionalSections > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.SP_AdditionalSectionsRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveSP_AdditionalSections record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveSP_AdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<SP_AdditionalSectionsQueryDto>> Update(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<SP_AdditionalSectionsQueryDto>.FailAsync($"UpdateSP_AdditionalSections > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.SP_AdditionalSectionsRepository.GetById(entity.Id);

            if (item == null) return await Result<SP_AdditionalSectionsQueryDto>.FailAsync("UpdateSP_AdditionalSections > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.SP_AdditionalSectionsRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_AdditionalSectionsQueryDto>.SuccessAsync(_mapper.Map<SP_AdditionalSectionsQueryDto>(item), "SP_AdditionalSections record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_AdditionalSectionsQueryDto>.FailAsync($"UpdateSP_AdditionalSections > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.SP_AdditionalSectionsRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.SP_AdditionalSectionsRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<SP_AdditionalSectionsQueryDto>.SuccessAsync(_mapper.Map<SP_AdditionalSectionsQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<SP_AdditionalSectionsQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }

		public async Task<IResult> Addlist(List<SP_AdditionalSectionsDto> entity, CancellationToken cancellationToken = default)
		{
            //throw new NotImplementedException(); if (entity == null) return await Result<SP_AdditionalSectionsQueryDto>.FailAsync("AddSP_MainClassification > the passed entity IS NULL !!!.");
            throw new NotImplementedException(); if (entity == null) return await Result<SP_AdditionalSectionsDto>.FailAsync("AddSP_MainClassification > the passed entity IS NULL !!!.");
            try
            {
                var objb = new SP_AdditionalSections();
                var objblist = new List<SP_AdditionalSections>();
                foreach (var objj in entity)
                {
                    objb = _mapper.Map<SP_AdditionalSections>(objj);
                    objblist.Add(objb);
                }
                var newEntity = _repositoryManager.SP_AdditionalSectionsRepository.Addlist(objblist);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<SP_AdditionalSectionsQueryDto>(newEntity);

                return await Result<SP_AdditionalSectionsQueryDto>.SuccessAsync(entityMap, "SP_MainClassification record added");
            }
            catch (Exception exc)
            {

                return await Result<SP_AdditionalSectionsQueryDto>.FailAsync($"AddSP_MainClassification > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
	}
}
