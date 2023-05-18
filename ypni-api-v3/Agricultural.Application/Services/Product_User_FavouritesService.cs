using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_User_Favourites;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_User_Favourites;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.Product_Image;

namespace Agricultural.Application.Services
{
    public class Product_User_FavouritesService : IProduct_User_FavouritesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Product_User_FavouritesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<IResult<IEnumerable<Product_User_FavouritesQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_User_FavouritesRepository.GetAll(x => new Product_User_FavouritesQueryDto
            { 
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,

            });

            var itemMap = _mapper.Map<IEnumerable<Product_User_FavouritesQueryDto>>(items);
            if (items == null) return await Result<IEnumerable<Product_User_FavouritesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_User_FavouritesQueryDto>>.SuccessAsync(itemMap, "Product_User_Favourites records retrieved");
        }

        public async Task<IResult<DtResult<Product_User_FavouritesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.Product_User_FavouritesRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_User_FavouritesRepository.GetAll(x => new Product_User_FavouritesQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,

            }, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_User_FavouritesRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<Product_User_FavouritesQueryDto>>(items);

            var datatableReturned = DtResult<Product_User_FavouritesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);
            if (items == null) return await Result<DtResult<Product_User_FavouritesQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_User_FavouritesQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_User_Favourites Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<Product_User_FavouritesQueryDto>>> Find(Expression<Func<Product_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_User_Favourites, bool>>>(expression);

            //var items = await _repositoryManager.Product_User_FavouritesRepository.Find(mapExpr);

            var items = await _repositoryManager.Product_User_FavouritesRepository.Find(x => new Product_User_FavouritesQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,

            }, mapExpr);

            var itemMap = _mapper.Map<IEnumerable<Product_User_FavouritesQueryDto>>(items);
            if (items == null ) return await Result<IEnumerable<Product_User_FavouritesQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<Product_User_FavouritesQueryDto>>.SuccessAsync(itemMap, "Product_User_Favourites records retrieved");
        }

        public async Task<IResult<DtResult<Product_User_FavouritesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_User_FavouritesQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product_User_Favourites, bool>>>(expression);

            //var items = await _repositoryManager.Product_User_FavouritesRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.Product_User_FavouritesRepository.Find(x => new Product_User_FavouritesQueryDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UserId = x.UserId,

            }, mapExpr, dtRequest.start, dtRequest.length);

            var totalRecord = await _repositoryManager.Product_User_FavouritesRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<Product_User_FavouritesQueryDto>>(items);

            var datatableReturned = DtResult<Product_User_FavouritesQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null ) return await Result<DtResult<Product_User_FavouritesQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<Product_User_FavouritesQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product_User_Favourites Datatable.", 200);
        }

        public async Task<IResult<IEnumerable<Product_User_FavouritesDDlLViewModels>>> GetByIdSPInfo(string UserId, CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.Product_User_FavouritesRepository.Find(x => x.UserId == UserId);
            var listserifor = new List<productdtoADDapi>();
           
            var listserifor2 = new List<Product_User_FavouritesDDlLViewModels>();
           




             foreach (var item in items)
             {

                var items2 = await _repositoryManager.ProductRepository.Find(x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = x.Current_Stock,
                    BrandId = x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,


                    Refundable = x.Refundable,
                    ServiceProviderId =x.ServiceProviderId,
                    //// SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = x.UnitId,
                    ////VideoUrl = x.VideoUrl,


                    //},x=>x.Id>0,3,2);
                }, x => x.Id == item.ProductId);
                var itemMapmm = new Product_User_FavouritesDDlLViewModels();
                itemMapmm.Id = item.Id;
                foreach (var item2 in items2)
                {
                    // var itemMapm2 = _mapper.Map<ProductQueryDto>(proinfo);
                    var itemMapm = new productdtoADDapi();
               
                 //   var maforobj = new productdtoADDapi();
                    itemMapm.Id = item2.Id;
                   // itemMapm.Id = item.ProductId;
                    itemMapm.Name = item2.Name;
                    itemMapm.Details = item2.Details;
                    itemMapm.ActivityTypeId = item2.ActivityTypeId;
                    //  itemMapm.ActivityTypeName = item.Product.ActivityType.ActivityName;
                    itemMapm.MainClassificationId =item2.MainClassificationId;
                    //  itemMapm.MainClassificationName = item.Product.MainClassification.MainClassificationName;
                    //  itemMapm.AdditionalSectionsId = item.Product.AdditionalSectionsId.Value;
                    // itemMapm.AdditionalSectionsName = item.Product.AdditionalSections.AdditionalSectionsName;
                    itemMapm.UnitPrice = item2.UnitPrice.Value;
                    itemMapm.PurchasePrice = item2.PurchasePrice.Value;
                    itemMapm.Discount = item2.Discount.Value;
                    itemMapm.DiscountType = item2.DiscountType;
                    itemMapm.UserId = item.UserId;
                    itemMapm.Current_Stock = item2.Current_Stock;
                    itemMapm.BrandId =item2.BrandId;
                    itemMapm.Code = item2.Code;
                    itemMapm.Free_Shipping = item2.Free_Shipping;
                    itemMapm.Minimum_Order_Qty = item2.Minimum_Order_Qty;
                    itemMapm.Video_Provider = item2.Video_Provider;
                    itemMapm.Video_Url = item2.Video_Url;
                    itemMapm.ProductStates = item2.ProductStates;
                    itemMapm.Min_qty =item2.Min_qty;
                    itemMapm.Negotiation = item2.Negotiation;


                    itemMapm.Refundable = item2.Refundable;
                    itemMapm.ServiceProviderId =item2.ServiceProviderId;
                    itemMapm.Thumbnail = item2.Thumbnail;
                    itemMapm.UnitId = item2.UnitId;
                   

                    var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                    {
                        Id = x.ColorId,
                        Name = x.Color.Name,
                        code = x.Color.code,

                    }, x => x.ProductId == item2.Id);
                    if (resinfo != null)
                    {
                        itemMapm.Colors = resinfo.ToList();
                    }
                    else
                    {
                        itemMapm.Colors = new List<ColorDtoApi>();
                    }
                    var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Price = x.Price,
                        SKU = x.SKU,
                        qty = x.qty,
                        ProductId = x.ProductId.Value

                    }, x => x.ProductId == item2.Id);
                    if (resinfovariation.Count() != 0)
                    {
                        itemMapm.variation = resinfovariation.ToList();
                    }
                    else
                    {
                        itemMapm.variation = new List<variation>();
                    }
                    var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                    {
                        Id = x.Id,
                        ImageUrl = x.ImageUrl,


                    }, x => x.ProductId == item2.Id);
                    if (resinfoImage != null)
                    {
                        itemMapm.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                    }
                    else
                    {
                        itemMapm.images = new List<string>();
                    }
                    var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item2.Id);
                    var attrid = 0;
                    var optoionobj = new choice_options();
                    var optoionobjlist = new List<choice_options>();
                    var getsizid = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "الحجم");
                    var gettype = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "النوع");
                    var sizb = resinfochoice_options.Where(x => x.Product_AttributeId == getsizid.FirstOrDefault().Id).ToList();
                    var Tyyp = resinfochoice_options.Where(x => x.Product_AttributeId == gettype.FirstOrDefault().Id).ToList();
                    if (sizb.Count != 0)
                    {
                        optoionobj.id = sizb.Select(x => x.Id).FirstOrDefault();
                        optoionobj.name = "الحجم";
                        optoionobj.options = sizb.Select(x => x.value).ToList();
                        optoionobjlist.Add(optoionobj);
                    }

                    optoionobj = new choice_options();
                    if (Tyyp.Count != 0)
                    {
                        optoionobj.id = Tyyp.Select(x => x.Id).FirstOrDefault(); ;
                        optoionobj.name = "النوع";
                        optoionobj.options = Tyyp.Select(x => x.value).ToList();
                        optoionobjlist.Add(optoionobj);
                    }

                    if (optoionobjlist != null)
                        itemMapm.choice_options = optoionobjlist.ToList();
                    else
                    {
                        itemMapm.choice_options = new List<choice_options>();

                    }
                  
                    listserifor.Add(itemMapm);

                }
                itemMapmm.product= listserifor.LastOrDefault();
                ////     var servicesname = await _repositoryManager.ServicesTypeRepository.GetById(proinfo.);
                //  var activityname = await _repositoryManager.ActivityTypeRepository.GetById((int)proinfo.ActivityTypeId);


                listserifor2.Add(itemMapmm);
                // listserifor.Add(itemMapm);
            }
            
            //var itemMap = _mapper.Map<IEnumerable<Product_User_FavouritesDDlLViewModels>>(listserifor2);

            return await Result<IEnumerable<Product_User_FavouritesDDlLViewModels>>.SuccessAsync(listserifor2, "SP_Product_Favourites records retrieved");
        }

        public async Task<IResult<Product_User_FavouritesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_User_FavouritesRepository.GetById(Id);

            if (item == null) return await Result<Product_User_FavouritesQueryDto>.FailAsync("GetProduct_User_FavouritesById > the given id NOT EXIEST !!!...");


            var itemMap = _mapper.Map<Product_User_FavouritesQueryDto>(item);

            return await Result<Product_User_FavouritesQueryDto>.SuccessAsync(itemMap, "Product_User_Favourites record retrieved");
        }

        public async Task<IResult<IEnumerable<Product_User_FavouritesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.Product_User_FavouritesRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<Product_User_FavouritesDDlLViewModels>>.FailAsync("GetProduct_User_FavouritesDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<Product_User_FavouritesDDLViewModel>(item);

            return await Result<IEnumerable<Product_User_FavouritesDDlLViewModels>>.SuccessAsync(item, "Product_User_Favourites DDL records retrieved");
        }
        public async Task<IResult<Product_User_FavouritesQueryDto>> Add(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<Product_User_FavouritesQueryDto>.FailAsync("AddProduct_User_Favourites > the passed entity IS NULL !!!.");

            try
            {
                var newEntity = await _repositoryManager.Product_User_FavouritesRepository.AddAndReturn(_mapper.Map<Product_User_Favourites>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<Product_User_FavouritesQueryDto>(newEntity);

                return await Result<Product_User_FavouritesQueryDto>.SuccessAsync(entityMap, "Product_User_Favourites record added");
            }
            catch (Exception exc)
            {

                return await Result<Product_User_FavouritesQueryDto>.FailAsync($"AddProduct_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }

        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_User_FavouritesRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct_User_Favourites > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.Product_User_FavouritesRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct_User_Favourites record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<Product_User_FavouritesQueryDto>> Update(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<Product_User_FavouritesQueryDto>.FailAsync($"UpdateProduct_User_Favourites > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.Product_User_FavouritesRepository.GetById(entity.Id);

            if (item == null) return await Result<Product_User_FavouritesQueryDto>.FailAsync("UpdateProduct_User_Favourites > the passed entity with the given id NOT EXIEST !!!.");
            _mapper.Map(entity, item);
            _repositoryManager.Product_User_FavouritesRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_User_FavouritesQueryDto>.SuccessAsync(_mapper.Map<Product_User_FavouritesQueryDto>(item), "Product_User_Favourites record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_User_FavouritesQueryDto>.FailAsync($"UpdateProduct_User_Favourites > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(Product_User_FavouritesDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.Product_User_FavouritesRepository.GetById(entity.Id);
            //  item.Active = !item.Active;
            _repositoryManager.Product_User_FavouritesRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<Product_User_FavouritesQueryDto>.SuccessAsync(_mapper.Map<Product_User_FavouritesQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<Product_User_FavouritesQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
