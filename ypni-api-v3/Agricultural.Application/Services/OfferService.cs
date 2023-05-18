using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Offer;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Offer;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;

namespace Agricultural.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OfferService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
  

        public async Task<IResult<IEnumerable<OfferQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.OfferRepository.GetAll(x => new OfferQueryDto
            {
                Id = x.Id,
                ApplyTo = x.ApplyTo,
                Price = x.Price,
                PriceRequire = x.PriceRequire,
                ProductId =(int) x.ProductId,
                QtRequire = x.QtRequire,
                State = x.State,
                Type=x.Type,

            });

            var itemMap = _mapper.Map<IEnumerable<OfferQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<OfferQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OfferQueryDto>>.SuccessAsync(itemMap, "Offer records retrieved");
        }

        public async Task<IResult<DtResult<OfferQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.OfferRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OfferRepository.GetAll(x => new OfferQueryDto
            {
                Id = x.Id,
                ApplyTo = x.ApplyTo,
                Price = x.Price,
                PriceRequire = x.PriceRequire,
                ProductId = (int)x.ProductId,
                QtRequire = x.QtRequire,
                State = x.State,
                Type = x.Type,


            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OfferRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<OfferQueryDto>>(items);

            var datatableReturned = DtResult<OfferQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            if (items == null) return await Result<DtResult<OfferQueryDto>>.FailAsync("No Data");

            return await Result<DtResult<OfferQueryDto>>.SuccessAsync(datatableReturned, message: "Get Offer Datatable.", 200);

        }
        

        public async Task<IResult<IEnumerable<OfferQueryDto>>> Find(Expression<Func<OfferQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Offer, bool>>>(expression);

            //var items = await _repositoryManager.OfferRepository.Find(mapExpr);

            var items = await _repositoryManager.OfferRepository.Find(x => new OfferQueryDto
            {
                Id = x.Id,
                ApplyTo = x.ApplyTo,
                Price = x.Price,
                PriceRequire = x.PriceRequire,
                ProductId = (int)x.ProductId,
                QtRequire = x.QtRequire,
                State = x.State,
                Type = x.Type,


            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<OfferQueryDto>>(items);
            if (items == null || items.Any() == false) return await Result<IEnumerable<OfferQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<OfferQueryDto>>.SuccessAsync(itemMap, "Offer records retrieved");
        }

        public async Task<IResult<DtResult<OfferQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OfferQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Offer, bool>>>(expression);

            //var items = await _repositoryManager.OfferRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.OfferRepository.Find(x => new OfferQueryDto
            {
                Id = x.Id,
                ApplyTo = x.ApplyTo,
                Price = x.Price,
                PriceRequire = x.PriceRequire,
                ProductId = (int)x.ProductId,
                QtRequire = x.QtRequire,
                State = x.State,
                Type = x.Type,


            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.OfferRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<OfferQueryDto>>(items);

            var datatableReturned = DtResult<OfferQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<OfferQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<OfferQueryDto>>.SuccessAsync(datatableReturned, message: "Get Offer Datatable.", 200);
        }


        public async Task<IResult<OfferQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OfferRepository.GetById(Id);

            if (item == null) return await Result<OfferQueryDto>.FailAsync("GetOfferById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<OfferQueryDto>(item);

            return await Result<OfferQueryDto>.SuccessAsync(itemMap, "Offer record retrieved");
        }

        public async Task<IResult<IEnumerable<OfferDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.OfferRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<OfferDDlLViewModels>>.FailAsync("GetOfferDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<OfferDDLViewModel>(item);

            return await Result<IEnumerable<OfferDDlLViewModels>>.SuccessAsync(item, "Offer DDL records retrieved");
        }
        public async Task<IResult<OfferQueryDto>> Add(OfferDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<OfferQueryDto>.FailAsync("AddOffer > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.OfferRepository.AddAndReturn(_mapper.Map<Offer>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<OfferQueryDto>(newEntity);

                return await Result<OfferQueryDto>.SuccessAsync(entityMap, "Offer record added");
            }
            catch (Exception exc)
            {

                return await Result<OfferQueryDto>.FailAsync($"AddOffer > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OfferRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveOffer > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.OfferRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveOffer record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveOffer > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<OfferQueryDto>> Update(OfferDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<OfferQueryDto>.FailAsync($"UpdateOffer > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.OfferRepository.GetById(entity.Id);

            if (item == null) return await Result<OfferQueryDto>.FailAsync("UpdateOffer > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.OfferRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OfferQueryDto>.SuccessAsync(_mapper.Map<OfferQueryDto>(item), "Offer record updated");
            }
            catch (Exception exc)
            {
                return await Result<OfferQueryDto>.FailAsync($"UpdateOffer > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(OfferDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.OfferRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.OfferRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<OfferQueryDto>.SuccessAsync(_mapper.Map<OfferQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<OfferQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
