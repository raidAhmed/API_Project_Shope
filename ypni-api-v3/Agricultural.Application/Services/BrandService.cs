using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Brand;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Brand;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BrandService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IResult<IEnumerable<BrandQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.BrandRepository.GetAll(x => new BrandQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ManufactureCompanyId = x.ManufactureCompanyId,
                ManufactureCompanyName=x.ManufactureCompany.Name,
                ImageUrl=x.ImageUrl,
                Active=x.Active,
                

            });

            var itemMap = _mapper.Map<IEnumerable<BrandQueryDto>>(items);
         //   if (items == null || items.Any() == false) return await Result<IEnumerable<BrandQueryDto>>.FailAsync("No Brands");
            return await Result<IEnumerable<BrandQueryDto>>.SuccessAsync(itemMap, "Brand records retrieved");
        }

        public async Task<IResult<DtResult<BrandQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {

            var items = await _repositoryManager.BrandRepository.GetAll(x => new BrandQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ManufactureCompanyId = x.ManufactureCompanyId,
                ManufactureCompanyName = x.ManufactureCompany.Name,
                Active=x.Active

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BrandRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<BrandQueryDto>>(items);

            var datatableReturned = DtResult<BrandQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<BrandQueryDto>>.FailAsync("No brands");
            return await Result<DtResult<BrandQueryDto>>.SuccessAsync(datatableReturned, message: "Get Brand Datatable.", 200);

        }

        public async Task<IResult<IEnumerable<BrandQueryDto>>> Find(Expression<Func<BrandQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Brand, bool>>>(expression);

            var items = await _repositoryManager.BrandRepository.Find(x => new BrandQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ManufactureCompanyId = x.ManufactureCompanyId,
                ManufactureCompanyName = x.ManufactureCompany.Name,
                Active = x.Active

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<BrandQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<BrandQueryDto>>.FailAsync("No Data"); 
            return await Result<IEnumerable<BrandQueryDto>>.SuccessAsync(itemMap, "Brand records retrieved");
        }

        public async Task<IResult<DtResult<BrandQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BrandQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Brand, bool>>>(expression);

            var items = await _repositoryManager.BrandRepository.Find(x => new BrandQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                ManufactureCompanyId = x.ManufactureCompanyId,
                ManufactureCompanyName = x.ManufactureCompany.Name,
                Active = x.Active

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.BrandRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<BrandQueryDto>>(items);

            var datatableReturned = DtResult<BrandQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<BrandQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<BrandQueryDto>>.SuccessAsync(datatableReturned, message: "Get Brand Datatable.", 200);
        }


        public async Task<IResult<BrandQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.BrandRepository.GetById(Id);

            if (item == null) return await Result<BrandQueryDto>.FailAsync("GetBrandById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<BrandQueryDto>(item);

            return await Result<BrandQueryDto>.SuccessAsync(itemMap, "Brand record retrieved");
        }

        public async Task<IResult<IEnumerable<BrandDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.BrandRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<BrandDDlLViewModels>>.FailAsync("GetBrandDDL > ERRORS !!!...");

            return await Result<IEnumerable<BrandDDlLViewModels>>.SuccessAsync(item, "Brand DDL records retrieved");
        }
        public async Task<IResult<BrandQueryDto>> Add(BrandDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<BrandQueryDto>.FailAsync("AddBrand > the passed entity IS NULL !!!.");

            //entity.Id = 0;

            //var entityDb = await _repositoryManager.BrandRepository.Find(x => x.Name.Contains(entity.Name));

            //if (entityDb != null) return await Result<BrandQueryDto>.FailAsync("AddBrand > the same record IS ALREADY EXIEST !!!.");

            try
            {
                var newEntity = await _repositoryManager.BrandRepository.AddAndReturn(_mapper.Map<Brand>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<BrandQueryDto>(newEntity);

                return await Result<BrandQueryDto>.SuccessAsync(entityMap, "Brand record added");
            }
            catch (Exception exc)
            {

                return await Result<BrandQueryDto>.FailAsync($"AddBrand > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BrandRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveBrand > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.BrandRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveBrand record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveBrand > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<BrandQueryDto>> Update(BrandDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<BrandQueryDto>.FailAsync($"UpdateBrand > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.BrandRepository.GetById(entity.Id);

            if (item == null) return await Result<BrandQueryDto>.FailAsync("UpdateBrand > the passed entity with the given id NOT EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.BrandRepository.Update(item);

            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BrandQueryDto>.SuccessAsync(_mapper.Map<BrandQueryDto>(item), "Brand record updated");
            }
            catch (Exception exc)
            {
                return await Result<BrandQueryDto>.FailAsync($"UpdateBrand > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(BrandDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.BrandRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.BrandRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<BrandQueryDto>.SuccessAsync(_mapper.Map<BrandQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<BrandQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
