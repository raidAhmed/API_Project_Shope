using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.User_Bank;
using Agricultural.Application.Interfaces.Common;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class User_BankService : IUser_BankService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public User_BankService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<User_BankQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.User_BankRepository.GetAll(x => new User_BankQueryDto
            {
                Id = x.Id,
                BanksName = x.Banks.Name,
                BanksAccountNum=x.BanksAccountNum,
                UserId = x.UserId,
                BanksId=x.BanksId,
                UserName=x.User.UserName,
                Active=x.Active
                
                
            });

            var itemMap = _mapper.Map<IEnumerable<User_BankQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<User_BankQueryDto>>.FailAsync("No Activity");
            return await Result<IEnumerable<User_BankQueryDto>>.SuccessAsync(itemMap, "User_Bank records retrieved");
        }

        public async Task<IResult<DtResult<User_BankQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.User_BankRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.User_BankRepository.GetAll(x => new User_BankQueryDto
            {
                Id = x.Id,
                BanksName = x.Banks.Name,
                BanksAccountNum = x.BanksAccountNum,
                UserId = x.UserId,
                BanksId = x.BanksId,
                UserName = x.User.UserName,
                Active = x.Active
            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.User_BankRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<User_BankQueryDto>>(items);

            var datatableReturned = DtResult<User_BankQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<User_BankQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<User_BankQueryDto>>.SuccessAsync(datatableReturned, message: "Get User_Bank Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<User_BankQueryDto>>> Find(Expression<Func<User_BankQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<User_Bank, bool>>>(expression);

            //var items = await _repositoryManager.User_BankRepository.Find(mapExpr);

            var items = await _repositoryManager.User_BankRepository.Find(x => new User_BankQueryDto
            {
                Id = x.Id,
                BanksName = x.Banks.Name,
                BanksAccountNum = x.BanksAccountNum,
                UserId = x.UserId,
                BanksId = x.BanksId,
                UserName = x.User.UserName,
                Active = x.Active


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<User_BankQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<User_BankQueryDto>>.FailAsync("No activity");
            return await Result<IEnumerable<User_BankQueryDto>>.SuccessAsync(itemMap, "User_Bank records retrieved");
        }

        public async Task<IResult<DtResult<User_BankQueryDto>>> Find(DtRequest dtRequest, Expression<Func<User_BankQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<User_Bank, bool>>>(expression);

            //var items = await _repositoryManager.User_BankRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.User_BankRepository.Find(x => new User_BankQueryDto
            {
                Id = x.Id,
                BanksName = x.Banks.Name,
                BanksAccountNum = x.BanksAccountNum,
                UserId = x.UserId,
                BanksId = x.BanksId,
                UserName = x.User.UserName,
                Active = x.Active
            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.User_BankRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<User_BankQueryDto>>(items);

            var datatableReturned = DtResult<User_BankQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<User_BankQueryDto>>.FailAsync("No Activity");
            return await Result<DtResult<User_BankQueryDto>>.SuccessAsync(datatableReturned, message: "Get User_Bank Datatable.", 200);
        }


        public async Task<IResult<User_BankQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.User_BankRepository.GetById(Id);

            if (item == null) return await Result<User_BankQueryDto>.FailAsync("GetUser_BankById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<User_BankQueryDto>(item);

            return await Result<User_BankQueryDto>.SuccessAsync(itemMap, "User_Bank record retrieved");
        }

     public async Task<IResult<User_BankQueryDto>> Add(User_BankDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<User_BankQueryDto>.FailAsync("AddUser_Bank > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.User_BankRepository.AddAndReturn(_mapper.Map<User_Bank>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<User_BankQueryDto>(newEntity);

                return await Result<User_BankQueryDto>.SuccessAsync(entityMap, "User_Bank record added");
            }
            catch (Exception exc)
            {

                return await Result<User_BankQueryDto>.FailAsync($"AddUser_Bank > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.User_BankRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveUser_Bank > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.User_BankRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveUser_Bank record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveUser_Bank > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<User_BankQueryDto>> Update(User_BankDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<User_BankQueryDto>.FailAsync($"UpdateUser_Bank > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.User_BankRepository.GetById(entity.Id);

            if (item == null) return await Result<User_BankQueryDto>.FailAsync("UpdateUser_Bank > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.User_BankRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<User_BankQueryDto>.SuccessAsync(_mapper.Map<User_BankQueryDto>(item), "User_Bank record updated");
            }
            catch (Exception exc)
            {
                return await Result<User_BankQueryDto>.FailAsync($"UpdateUser_Bank > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(User_BankDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.User_BankRepository.GetById(entity.Id);
         
            _repositoryManager.User_BankRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<User_BankQueryDto>.SuccessAsync(_mapper.Map<User_BankQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<User_BankQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
