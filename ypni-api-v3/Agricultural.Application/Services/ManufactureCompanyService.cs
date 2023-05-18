using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ManufactureCompany;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ManufactureCompany;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class ManufactureCompanyService : IManufactureCompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ManufactureCompanyService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<ManufactureCompanyQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ManufactureCompanyRepository.GetAll(x => new ManufactureCompanyQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                CompanyInfo = x.CompanyInfo,
                Active=x.Active,
                

            });

            var itemMap = _mapper.Map<IEnumerable<ManufactureCompanyQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<ManufactureCompanyQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ManufactureCompanyQueryDto>>.SuccessAsync(itemMap, "ManufactureCompany records retrieved");
        }

        public async Task<IResult<DtResult<ManufactureCompanyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ManufactureCompanyRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ManufactureCompanyRepository.GetAll(x => new ManufactureCompanyQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                CompanyInfo = x.CompanyInfo,
                Active = x.Active,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ManufactureCompanyRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ManufactureCompanyQueryDto>>(items);

            var datatableReturned = DtResult<ManufactureCompanyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<ManufactureCompanyQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ManufactureCompanyQueryDto>>.SuccessAsync(datatableReturned, message: "Get ManufactureCompany Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<ManufactureCompanyQueryDto>>> Find(Expression<Func<ManufactureCompanyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ManufactureCompany, bool>>>(expression);

            //var items = await _repositoryManager.ManufactureCompanyRepository.Find(mapExpr);

            var items = await _repositoryManager.ManufactureCompanyRepository.Find(x => new ManufactureCompanyQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                CompanyInfo = x.CompanyInfo,
                Active = x.Active,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<ManufactureCompanyQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<ManufactureCompanyQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ManufactureCompanyQueryDto>>.SuccessAsync(itemMap, "ManufactureCompany records retrieved");
        }

        public async Task<IResult<DtResult<ManufactureCompanyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ManufactureCompanyQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<ManufactureCompany, bool>>>(expression);

            //var items = await _repositoryManager.ManufactureCompanyRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ManufactureCompanyRepository.Find(x => new ManufactureCompanyQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                CompanyInfo = x.CompanyInfo,
                Active = x.Active,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.ManufactureCompanyRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ManufactureCompanyQueryDto>>(items);

            var datatableReturned = DtResult<ManufactureCompanyQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ManufactureCompanyQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ManufactureCompanyQueryDto>>.SuccessAsync(datatableReturned, message: "Get ManufactureCompany Datatable.", 200);
        }


        public async Task<IResult<ManufactureCompanyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ManufactureCompanyRepository.GetById(Id);

            if (item == null) return await Result<ManufactureCompanyQueryDto>.FailAsync("GetManufactureCompanyById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<ManufactureCompanyQueryDto>(item);

            return await Result<ManufactureCompanyQueryDto>.SuccessAsync(itemMap, "ManufactureCompany record retrieved");
        }

        public async Task<IResult<IEnumerable<ManufactureCompanyDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ManufactureCompanyRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ManufactureCompanyDDlLViewModels>>.FailAsync("GetManufactureCompanyDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ManufactureCompanyDDLViewModel>(item);

            return await Result<IEnumerable<ManufactureCompanyDDlLViewModels>>.SuccessAsync(item, "ManufactureCompany DDL records retrieved");
        }
        public async Task<IResult<ManufactureCompanyQueryDto>> Add(ManufactureCompanyDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ManufactureCompanyQueryDto>.FailAsync("AddManufactureCompany > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.ManufactureCompanyRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<ManufactureCompanyQueryDto>.FailAsync("AddManufactureCompany > the same record IS ALREADY EXIEST !!!.");

            try
            {
                
                var newEntity = await _repositoryManager.ManufactureCompanyRepository.AddAndReturn(_mapper.Map<ManufactureCompany>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ManufactureCompanyQueryDto>(newEntity);

                return await Result<ManufactureCompanyQueryDto>.SuccessAsync(entityMap, "ManufactureCompany record added");
            }
            catch (Exception exc)
            {

                return await Result<ManufactureCompanyQueryDto>.FailAsync($"AddManufactureCompany > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }
        //public async Task<IResult<ManufactureCompanyQueryDto>> Add(ManufactureCompanyDto entity, CancellationToken cancellationToken = default)
        //{

        //    if (entity == null) return await Result<ManufactureCompanyQueryDto>.FailAsync("AddManufactureCompany > the passed entity IS NULL !!!.");

        //    //entity.Id = 0;

        //    //var entityDb = await _repositoryManager.ManufactureCompanyRepository.Find(x => x.Name.Contains(entity.Name));

        //    //if (entityDb != null) return await Result<ManufactureCompanyQueryDto>.FailAsync("AddManufactureCompany > the same record IS ALREADY EXIEST !!!.");

        //    try
        //    {
        //        Console.WriteLine("===========before========");
        //        var ob = new ManufactureCompany();
        //        ob.ActivityName = entity.ActivityName;
        //      //  var newEntity = await _repositoryManager.ManufactureCompanyRepository.AddAndReturn(_mapper.Map<ManufactureCompany>(entity));
        //        var newEntity = await _repositoryManager.ManufactureCompanyRepository.AddAndReturn(ob);

        //        Console.WriteLine("=====after==============");

        //         await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
        //       // var entityMap = _mapper.Map<ManufactureCompanyQueryDto>(newEntity);
        //        var entityt = new ManufactureCompanyQueryDto();

        //        // var entityMap = _mapper.Map<ManufactureCompanyQueryDto>(newEntity);
        //        entityt.Id = newEntity.Id;
        //        entityt.ActivityName = newEntity.ActivityName;
        //        Console.WriteLine("===========before========");
        //        Console.WriteLine(entityt.ActivityName);
        //        return await Result<ManufactureCompanyQueryDto>.SuccessAsync(entityt, "ManufactureCompany record added");
        //    }
        //    catch (Exception exc)
        //    {



        //          Console.WriteLine("===================");
        //          Console.WriteLine(exc.ToString());
        //        return await Result<ManufactureCompanyQueryDto>.FailAsync($"AddManufactureCompany > Something went wrong !!!\n\n\n{exc.Message}");
        //    }

        //}

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ManufactureCompanyRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveManufactureCompany > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ManufactureCompanyRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveManufactureCompany record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveManufactureCompany > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ManufactureCompanyQueryDto>> Update(ManufactureCompanyDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ManufactureCompanyQueryDto>.FailAsync($"UpdateManufactureCompany > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ManufactureCompanyRepository.GetById(entity.Id);

            if (item == null) return await Result<ManufactureCompanyQueryDto>.FailAsync("UpdateManufactureCompany > the passed entity with the given id NOT EXIEST !!!.");

            //var entityDb = await _repositoryManager.ManufactureCompanyRepository.Find(x =>  x.Name.Contains(entity.Name) && x.Id != entity.Id);

            //if (entityDb != null && entityDb.Count() > 0) return await Result<ManufactureCompanyQueryDto>.FailAsync("UpdateManufactureCompany > the same record IS ALREADY EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.ManufactureCompanyRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ManufactureCompanyQueryDto>.SuccessAsync(_mapper.Map<ManufactureCompanyQueryDto>(item), "ManufactureCompany record updated");
            }
            catch (Exception exc)
            {
                return await Result<ManufactureCompanyQueryDto>.FailAsync($"UpdateManufactureCompany > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ManufactureCompanyDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ManufactureCompanyRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ManufactureCompanyRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ManufactureCompanyQueryDto>.SuccessAsync(_mapper.Map<ManufactureCompanyQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ManufactureCompanyQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
