using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantToParty;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ComplainantToPartyService : IComplainantToPartyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        public ComplainantToPartyService(IUserManager userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<IResult<IEnumerable<Complminttopartyapi>>> GetAlll(string useridd , CancellationToken cancellationToken = default)
        {

           // var mapExpr = _mapper.Map<Expression<Func<ComplainantToParty, bool>>>(user);
            
            var items = await _repositoryManager.ComplainantToPartyRepository.Find(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                TypeofMesseage = x.TypeofMesseage,
                SenderId = x.SenderId,
                ReciverId = x.ReciverId,
                requestState = x.requestState,
                ServiceType = x.ServiceType,
                 CreatedAt = x.CreatedAt,
                Active = x.Active,
            }, x => x.ReciverId == useridd || x.SenderId == useridd);
            var userchat = new List<string>();
            var userchatb = new List<Complminttopartyapi>();
            foreach (var item in items)
            {
                if (item.SenderId != useridd)
                    if (!userchat.Contains(item.SenderId))
                        userchat.Add(item.SenderId);
                if (item.ReciverId != useridd)
                    if (!userchat.Contains(item.ReciverId))
                        userchat.Add(item.ReciverId);
            }
            foreach (var item in userchat)
            {
                var sv = new Complminttopartyapi();


                var eew = await _userManager.FindByIdAsync(item);
                if (eew.Data != null)
                { 

                    
                    // var xx=_mapper.Map<Complminttopartyapi>(eew.Data);
                  //  if (!eew.Data.Status)
                    if (!eew.Succeeded)
                    {
                        var eewwm = await _repositoryManager.ServiceProviderRepository.Find(w => w.UserId == item);
                        var eeww = eewwm.FirstOrDefault();
                        sv.Id = eeww.UserId;
                        sv.Username = eeww.TradeName;
                        sv.Image = eeww.Logo;
                        sv.ServiceTypeName = eeww.Type;
                        sv.ActivityTypeName = eeww.Type;
                        sv.Email = eeww.Email;
                        sv.PhoneNumber = eeww.PhoneNumber;
                        // sv.Status = eew.Data.Status;
                        var useridm = items.Where(x => x.SenderId == item || x.ReciverId == item);
                        sv.ComplainantToPartyDto = useridm.ToList();
                        userchatb.Add(sv);
                    }
                    else
                    {
                        sv.Id = eew.Data.Id;
                        sv.Username = eew.Data.UserName;
                        sv.Image = eew.Data.Image;
                        sv.ServiceTypeName = "";
                        sv.ActivityTypeName = "";
                        sv.Email = eew.Data.Email;
                        sv.PhoneNumber = eew.Data.PhoneNumber;
                        // sv.Status = eew.Data.Status;
                        var useridm = items.Where(x => x.SenderId == item || x.ReciverId == item);
                        sv.ComplainantToPartyDto = useridm.ToList();
                        userchatb.Add(sv);
                    }
            }
            }

            return await Result<IEnumerable<Complminttopartyapi>>.SuccessAsync(userchatb, "ComplainantToParty records retrieved");
        }
        public async Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ComplainantToPartyRepository.GetAll(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,


            });

            var itemMap = _mapper.Map<IEnumerable<ComplainantToPartyQueryDto>>(items);

            return await Result<IEnumerable<ComplainantToPartyQueryDto>>.SuccessAsync(itemMap, "ComplainantToParty records retrieved");
        }

        public async Task<IResult<DtResult<ComplainantToPartyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ComplainantToPartyRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ComplainantToPartyRepository.GetAll(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ComplainantToPartyRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ComplainantToPartyQueryDto>>(items);

            var datatableReturned = DtResult<ComplainantToPartyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            return await Result<DtResult<ComplainantToPartyQueryDto>>.SuccessAsync(datatableReturned, message: "Get ComplainantToParty Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> Find(Expression<Func<ComplainantToPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ComplainantToParty, bool>>>(expression);

            //var items = await _repositoryManager.ComplainantToPartyRepository.Find(mapExpr);

            var items = await _repositoryManager.ComplainantToPartyRepository.Find(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                TypeofMesseage = x.TypeofMesseage,
                SenderId = x.SenderId,
                ReciverId = x.ReciverId,
                requestState = x.requestState,
                ServiceType=x.ServiceType,
                Active = x.Active,
                CreatedAt=x.CreatedAt,
            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ComplainantToPartyQueryDto>>(items);

            return await Result<IEnumerable<ComplainantToPartyQueryDto>>.SuccessAsync(itemMap, "ComplainantToParty records retrieved");
        }

        public async Task<IResult<DtResult<ComplainantToPartyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ComplainantToPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ComplainantToParty, bool>>>(expression);

            //var items = await _repositoryManager.ComplainantToPartyRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ComplainantToPartyRepository.Find(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ComplainantToPartyRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ComplainantToPartyQueryDto>>(items);

            var datatableReturned = DtResult<ComplainantToPartyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);

            return await Result<DtResult<ComplainantToPartyQueryDto>>.SuccessAsync(datatableReturned, message: "Get ComplainantToParty Datatable.", 200);
        }


        public async Task<IResult<ComplainantToPartyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ComplainantToPartyRepository.GetById(Id);

            if (item == null) return await Result<ComplainantToPartyQueryDto>.FailAsync("GetComplainantToPartyById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ComplainantToPartyQueryDto>(item);

            return await Result<ComplainantToPartyQueryDto>.SuccessAsync(itemMap, "ComplainantToParty record retrieved");
        }

        public async Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ComplainantToPartyRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ComplainantToPartyQueryDto>>.FailAsync("GetComplainantToPartyDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ComplainantToPartyDDLViewModel>(item);

            return await Result<IEnumerable<ComplainantToPartyQueryDto>>.SuccessAsync(item, "ComplainantToParty DDL records retrieved");
        }
        public async Task<IResult<ComplainantToPartyQueryDto>> Add(ComplainantToPartyDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ComplainantToPartyQueryDto>.FailAsync("AddComplainantToParty > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.ComplainantToPartyRepository.AddAndReturn(_mapper.Map<ComplainantToParty>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ComplainantToPartyQueryDto>(newEntity);

                return await Result<ComplainantToPartyQueryDto>.SuccessAsync(entityMap, "ComplainantToParty record added");
            }
            catch (Exception exc)
            {

                return await Result<ComplainantToPartyQueryDto>.FailAsync($"AddComplainantToParty > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ComplainantToPartyRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveComplainantToParty > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ComplainantToPartyRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveComplainantToParty record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveComplainantToParty > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ComplainantToPartyQueryDto>> Update(ComplainantToPartyQueryDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ComplainantToPartyQueryDto>.FailAsync($"UpdateComplainantToParty > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ComplainantToPartyRepository.GetById(entity.Id);

            if (item == null) return await Result<ComplainantToPartyQueryDto>.FailAsync("UpdateComplainantToParty > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.ComplainantToPartyRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ComplainantToPartyQueryDto>.SuccessAsync(_mapper.Map<ComplainantToPartyQueryDto>(item), "ComplainantToParty record updated");
            }
            catch (Exception exc)
            {
                return await Result<ComplainantToPartyQueryDto>.FailAsync($"UpdateComplainantToParty > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ComplainantToPartyDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ComplainantToPartyRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ComplainantToPartyRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ComplainantToPartyQueryDto>.SuccessAsync(_mapper.Map<ComplainantToPartyQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ComplainantToPartyQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
