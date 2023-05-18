using System.Linq.Expressions;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product;
using AutoMapper;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.DTOs.Product_Colors;

namespace Agricultural.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        } 

        public async Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProById(Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {
            try
            {
                var mapExpr = _mapper.Map<Expression<Func<Product, bool>>>(expression);
                var listserifor = new List<productdtoADDapi>();
                var items = await _repositoryManager.ProductRepository.Find(x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = (int)x.Current_Stock,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = (int)x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    Active=x.Active,
                    ////VideoUrl = x.VideoUrl,


                    //},x=>x.Id>0,3,2); 
                }, mapExpr);
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                        if (proeval.Count() != 0)
                        {
                            var ratt = proeval.Sum(x => x.Rating);
                            var ratmt = proeval.Count();
                            item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                        }
                        else
                        {
                            item.RatingPro = "0";

                        }
                        var maforobj = new productdtoADDapi();
                        var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                        {
                            Id = x.ColorId,
                            Name = x.Color.Name,
                            code = x.Color.code,

                        }, x => x.ProductId == item.Id);
                        if (resinfo != null)
                        {
                            maforobj.Colors = resinfo.ToList();
                        }
                        else
                        {
                            maforobj.Colors = new List<ColorDtoApi>();
                        }
                        var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                        {
                            Id = x.Id,
                            Type = x.Type,
                            Price = x.Price,
                            SKU = x.SKU,
                            qty = x.qty,
                            ProductId = x.ProductId.Value

                        }, x => x.ProductId == item.Id);
                        if (resinfovariation != null)
                        {
                            maforobj.variation = resinfovariation.ToList();
                        }
                        else
                        {
                            maforobj.variation = new List<variation>();
                        }
                        var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl,


                        }, x => x.ProductId == item.Id);
                        if (resinfoImage != null)
                        {
                            maforobj.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                        }
                        else
                        {
                            maforobj.images = new List<string>();
                        }
                        var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item.Id);
                        var attrid = 0;
                        var optoionobj = new choice_options();
                        var optoionobjlist = new List<choice_options>();
                        var getsizid = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "Size"||x.Name=="الحجم");
                        var gettype = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "Type"||x.Name=="النوع");
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
                            maforobj.choice_options = optoionobjlist.ToList();
                        else
                        {
                            maforobj.choice_options = new List<choice_options>();
                        }
                        maforobj.Id = item.Id;
                        maforobj.Name = item.Name;
                        maforobj.Details = item.Details;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.Thumbnail = item.Thumbnail;
                        maforobj.ActivityTypeId = item.ActivityTypeId;
                        maforobj.ActivityTypeName = item.ActivityTypeName;
                        maforobj.MainClassificationId = item.MainClassificationId;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.AdditionalSectionsId = item.AdditionalSectionsId;
                        maforobj.AdditionalSectionsName = item.AdditionalSectionsName;
                        maforobj.Discount = item.Discount;
                        maforobj.Min_qty = item.Min_qty;
                        maforobj.Minimum_Order_Qty = item.Minimum_Order_Qty;
                        maforobj.Current_Stock = item.Current_Stock;
                        maforobj.DiscountType = item.DiscountType;
                        maforobj.UnitPrice = item.UnitPrice;
                        maforobj.PurchasePrice = item.PurchasePrice;
                        maforobj.BrandId = item.BrandId;
                        maforobj.ServiceProviderId = item.ServiceProviderId;
                        maforobj.SpecialSectionsId= item.SpecialSectionsId;
                        maforobj.Code = item.Code;
                        maforobj.Video_Url = item.Video_Url;
                        maforobj.Video_Provider = item.Video_Provider;
                        maforobj.UnitId = item.UnitId;
                        maforobj.UserId = item.UserId;
                        maforobj.Active = item.Active;
                        maforobj.RatingPro = item.RatingPro;
                        listserifor.Add(maforobj); 
                    }
                }
                return await Result<IEnumerable<productdtoADDapi>>.SuccessAsync(listserifor, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<IEnumerable<productdtoADDapi>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }
        }
       public async Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProPagination(Expression<Func<ProductQueryDto, bool>> expression, int skip, int take, CancellationToken cancellationToken = default)
        {
            try
            {
                var mapExpr = _mapper.Map<Expression<Func<Product, bool>>>(expression);

                var listserifor = new List<productdtoADDapi>();
                var items = await _repositoryManager.ProductRepository.Find(x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = (int)x.Current_Stock,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = (int)x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    //// SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    Active =x.Active,
                ////VideoUrl = x.VideoUrl,


                //},x=>x.Id>0,3,2);
            },mapExpr,skip,take);
                if (items.Any()) 
                {
                    foreach (var item in items)
                    {
                        var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                        if (proeval.Count() != 0)
                        {
                            var ratt = proeval.Sum(x => x.Rating);
                            var ratmt = proeval.Count();
                            item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                        }
                        else
                        {
                            item.RatingPro = "0";

                        }
                        var maforobj = new productdtoADDapi();
                        var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                        {
                            Id = x.ColorId,
                            Name = x.Color.Name,
                            code = x.Color.code,

                        }, x => x.ProductId == item.Id);
                        if (resinfo != null)
                        {
                            maforobj.Colors = resinfo.ToList();
                        }
                        else
                        {
                            maforobj.Colors = new List<ColorDtoApi>();
                        }
                        var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                        {
                            Id = x.Id,
                            Type = x.Type,
                            Price = x.Price,
                            SKU = x.SKU,
                            qty = x.qty,
                            ProductId = x.ProductId.Value

                        }, x => x.ProductId == item.Id);
                        if (resinfovariation != null)
                        {
                            maforobj.variation = resinfovariation.ToList();
                        }
                        else
                        {
                            maforobj.variation = new List<variation>();
                        }
                        var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl,


                        }, x => x.ProductId == item.Id);
                        if (resinfoImage != null)
                        {
                            maforobj.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                        }
                        else
                        {
                            maforobj.images = new List<string>();
                        }
                        var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item.Id);
                        var attrid = 0;
                        var optoionobj = new choice_options();
                        var optoionobjlist = new List<choice_options>();
                        var getsizid = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "Size"||x.Name== "الحجم");
                        var gettype = await _repositoryManager.Product_AttributeRepository.Find(x => x.Name == "Type"||x.Name== "النوع");
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
                            maforobj.choice_options = optoionobjlist.ToList();
                        else
                        {
                            maforobj.choice_options = new List<choice_options>();
                        }
                        maforobj.Id = item.Id;
                        maforobj.Name = item.Name;
                        maforobj.Details = item.Details;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.Thumbnail = item.Thumbnail;
                        maforobj.ActivityTypeId = item.ActivityTypeId;
                        maforobj.ActivityTypeName = item.ActivityTypeName;
                        maforobj.MainClassificationId = item.MainClassificationId;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.AdditionalSectionsId = item.AdditionalSectionsId;
                        maforobj.AdditionalSectionsName = item.AdditionalSectionsName;
                        maforobj.Discount = item.Discount;
                        maforobj.DiscountType = item.DiscountType;
                        maforobj.UnitPrice = item.UnitPrice;
                        maforobj.PurchasePrice = item.PurchasePrice;
                        maforobj.BrandId = item.BrandId;
                        maforobj.ServiceProviderId = item.ServiceProviderId;
                        maforobj.Code = item.Code;
                        maforobj.Video_Url = item.Video_Url;
                        maforobj.Video_Provider = item.Video_Provider;
                        maforobj.UnitId = item.UnitId;
                        maforobj.UserId = item.UserId;
                        maforobj.Active = item.Active;
                        maforobj.Min_qty = item.Min_qty;
                        maforobj.Minimum_Order_Qty = item.Minimum_Order_Qty;
                        maforobj.Current_Stock = item.Current_Stock;
                        maforobj.RatingPro = item.RatingPro;
                        listserifor.Add(maforobj);
                    }
                }
                return await Result<IEnumerable<productdtoADDapi>>.SuccessAsync(listserifor, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<IEnumerable<productdtoADDapi>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProApi(CancellationToken cancellationToken = default)
        {
            try
            {
                var listserifor = new List<productdtoADDapi>();
                var items = await _repositoryManager.ProductRepository.GetAll(x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = (int)x.Current_Stock,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = (int)x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                     
                 
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    Active=x.Active,
                    ////VideoUrl = x.VideoUrl,

                     
                    //},x=>x.Id>0,3,2);
                });
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                        if (proeval.Count() != 0)
                        {
                            var ratt = proeval.Sum(x => x.Rating);
                            var ratmt = proeval.Count();
                            item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                        }
                        else
                        {
                            item.RatingPro = "0";

                        }
                        var maforobj = new productdtoADDapi();
                        var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                        {
                            Id = x.ColorId,
                            Name = x.Color.Name,
                            code = x.Color.code,

                        }, x => x.ProductId == item.Id);
                        if (resinfo != null)
                        {
                            maforobj.Colors = resinfo.ToList();
                        }
                        else
                        {
                            maforobj.Colors = new List<ColorDtoApi>();
                        }
                        var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                        {
                            Id = x.Id,
                            Type = x.Type,
                            Price = x.Price,
                            SKU = x.SKU,
                            qty = x.qty,
                            ProductId = x.ProductId.Value

                        }, x => x.ProductId == item.Id);
                        if (resinfovariation != null)
                        {
                            maforobj.variation = resinfovariation.ToList();
                        }
                        else
                        {
                            maforobj.variation = new List<variation>();
                        }
                        var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl,


                        }, x => x.ProductId == item.Id);
                        if (resinfoImage != null)
                        {
                            maforobj.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                        }
                        else
                        {
                            maforobj.images = new List<string>();
                        }
                        var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item.Id);
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
                            maforobj.choice_options = optoionobjlist.ToList();
                        else
                        {
                            maforobj.choice_options = new List<choice_options>();
                        }
                        maforobj.Id = item.Id;
                        maforobj.Name = item.Name;
                        maforobj.Details = item.Details;
                     
                        maforobj.Thumbnail = item.Thumbnail;
                        maforobj.ActivityTypeId = item.ActivityTypeId;
                        maforobj.ActivityTypeName = item.ActivityTypeName;
                        maforobj.MainClassificationId = item.MainClassificationId;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.AdditionalSectionsId = item.AdditionalSectionsId;
                        maforobj.AdditionalSectionsName = item.AdditionalSectionsName;
                        maforobj.Discount = item.Discount;
                        maforobj.DiscountType = item.DiscountType;
                        maforobj.UnitPrice = item.UnitPrice;
                        maforobj.PurchasePrice = item.PurchasePrice;
                        maforobj.BrandId = item.BrandId;
                        maforobj.Min_qty=item.Min_qty;
                        maforobj.Minimum_Order_Qty= item.Minimum_Order_Qty;
                        maforobj.Current_Stock=item.Current_Stock;
                        maforobj.ServiceProviderId = item.ServiceProviderId;
                        maforobj.Code = item.Code;
                        maforobj.Video_Url = item.Video_Url;
                        maforobj.Video_Provider = item.Video_Provider;
                        maforobj.UnitId = item.UnitId;
                        maforobj.UserId = item.UserId;
                        maforobj.Active = item.Active;
                        maforobj.RatingPro = item.RatingPro;
                        //     maforobj.Current_Stock = (int)item.Current_Stock;
                        //     maforobj.Min_qty = (int)item.Min_qty;
                        //     maforobj.Minimum_Order_Qty = (int)item.Minimum_Order_Qty;


                        listserifor.Add(maforobj);
                    }
                }
                return await Result<IEnumerable<productdtoADDapi>>.SuccessAsync(listserifor, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<IEnumerable<productdtoADDapi>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }  
        public async Task<IResult<IEnumerable<productdtoADDapi>>> GetAllByServiceProviderIdAndMainClassificationId(int mainClassificationId, int serviceProviderId, CancellationToken cancellationToken = default)
        {
            try
            {
                var listserifor = new List<productdtoADDapi>();
                var items = await _repositoryManager.ProductRepository.Find( x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = (int)x.Current_Stock,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = (int)x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    //// SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    ////VideoUrl = x.VideoUrl,


                    //},x=>x.Id>0,3,2);
                }, p => p.ServiceProviderId == serviceProviderId && p.MainClassificationId == mainClassificationId && p.ProductStates == true && p.Active == false);
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                        if (proeval.Count() != 0)
                        {
                            var ratt = proeval.Sum(x => x.Rating);
                            var ratmt = proeval.Count();
                            item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                        }
                        else
                        {
                            item.RatingPro = "0";

                        }
                        var maforobj = new productdtoADDapi();
                        var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                        {
                            Id = x.ColorId,
                            Name = x.Color.Name,
                            code = x.Color.code,

                        }, x => x.ProductId == item.Id);
                        if (resinfo != null)
                        {
                            maforobj.Colors = resinfo.ToList();
                        }
                        else
                        {
                            maforobj.Colors = new List<ColorDtoApi>();
                        }
                        var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                        {
                            Id = x.Id,
                            Type = x.Type,
                            Price = x.Price,
                            SKU = x.SKU,
                            qty = x.qty,
                            ProductId = x.ProductId.Value

                        }, x => x.ProductId == item.Id);
                        if (resinfovariation != null)
                        {
                            maforobj.variation = resinfovariation.ToList();
                        }
                        else
                        {
                            maforobj.variation = new List<variation>();
                        }
                        var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl,


                        }, x => x.ProductId == item.Id);
                        if (resinfoImage != null)
                        {
                            maforobj.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                        }
                        else
                        {
                            maforobj.images = new List<string>();
                        }
                        var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item.Id);
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
                            maforobj.choice_options = optoionobjlist.ToList();
                        else
                        {
                            maforobj.choice_options = new List<choice_options>();
                        }
                        maforobj.Id = item.Id;
                        maforobj.Name = item.Name;
                        maforobj.Details = item.Details;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.Thumbnail = item.Thumbnail;
                        maforobj.ActivityTypeId = item.ActivityTypeId;
                        maforobj.ActivityTypeName = item.ActivityTypeName;
                        maforobj.MainClassificationId = item.MainClassificationId;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.AdditionalSectionsId = item.AdditionalSectionsId;
                        maforobj.AdditionalSectionsName = item.AdditionalSectionsName;
                        maforobj.Discount = item.Discount;
                        maforobj.DiscountType = item.DiscountType;
                        maforobj.UnitPrice = item.UnitPrice;
                        maforobj.PurchasePrice = item.PurchasePrice;
                        maforobj.BrandId = item.BrandId;
                        maforobj.ServiceProviderId = item.ServiceProviderId;
                        maforobj.Code = item.Code;
                        maforobj.Video_Url = item.Video_Url;
                        maforobj.Video_Provider = item.Video_Provider;
                        maforobj.UnitId = item.UnitId;
                        maforobj.UserId = item.UserId;
                        maforobj.RatingPro = item.RatingPro;
                        listserifor.Add(maforobj);
                    }
                }
                return await Result<IEnumerable<productdtoADDapi>>.SuccessAsync(listserifor, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<IEnumerable<productdtoADDapi>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }
        }
        public async Task<IResult<IEnumerable<productdtoADDapi>>> GetAllByServiceProviderIdAndAdditionalSectionsId(int additionalSectionsId, int serviceProviderId, CancellationToken cancellationToken = default)
        {
            try
            {
                var listserifor = new List<productdtoADDapi>();
                var items = await _repositoryManager.ProductRepository.Find( x => new productdtoADDapi
                {
                    Id = x.Id,
                    Name = x.Name,
                    Details = x.Details,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    AdditionalSectionsId = x.AdditionalSectionsId.Value,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    UnitPrice = x.UnitPrice.Value,
                    PurchasePrice = x.PurchasePrice.Value,
                    Discount = x.Discount.Value,
                    DiscountType = x.DiscountType,
                    UserId = x.UserId,
                    Current_Stock = (int)x.Current_Stock,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Free_Shipping = x.Free_Shipping,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,
                    ProductStates = x.ProductStates,
                    Min_qty = (int)x.Min_qty,
                    ////Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    //// SpecialSectionsId = (int)x.SpecialSectionsId,
                    ////SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    ////VideoUrl = x.VideoUrl,


                    //},x=>x.Id>0,3,2);
                }, p => p.ServiceProviderId == serviceProviderId && p.AdditionalSectionsId == additionalSectionsId && p.ProductStates == true && p.Active == false);
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                        if (proeval.Count() != 0)
                        {
                            var ratt = proeval.Sum(x => x.Rating);
                            var ratmt = proeval.Count();
                            item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                        }
                        else
                        {
                            item.RatingPro = "0";

                        }
                        var maforobj = new productdtoADDapi();
                        var resinfo = await _repositoryManager.Product_ColorsRepository.Find(x => new ColorDtoApi
                        {
                            Id = x.ColorId,
                            Name = x.Color.Name,
                            code = x.Color.code,

                        }, x => x.ProductId == item.Id);
                        if (resinfo != null)
                        {
                            maforobj.Colors = resinfo.ToList();
                        }
                        else
                        {
                            maforobj.Colors = new List<ColorDtoApi>();
                        }
                        var resinfovariation = await _repositoryManager.Product_variantionRepository.Find(x => new variation
                        {
                            Id = x.Id,
                            Type = x.Type,
                            Price = x.Price,
                            SKU = x.SKU,
                            qty = x.qty,
                            ProductId = x.ProductId.Value

                        }, x => x.ProductId == item.Id);
                        if (resinfovariation != null)
                        {
                            maforobj.variation = resinfovariation.ToList();
                        }
                        else
                        {
                            maforobj.variation = new List<variation>();
                        }
                        var resinfoImage = await _repositoryManager.Product_ImageRepository.Find(x => new Product_ImageDto
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl,


                        }, x => x.ProductId == item.Id);
                        if (resinfoImage != null)
                        {
                            maforobj.images = resinfoImage.Select(x => x.ImageUrl).ToList();
                        }
                        else
                        {
                            maforobj.images = new List<string>();
                        }
                        var resinfochoice_options = await _repositoryManager.Product_Variant_AttributeRepository.Find(x => x.ProductId == item.Id);
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
                            maforobj.choice_options = optoionobjlist.ToList();
                        else
                        {
                            maforobj.choice_options = new List<choice_options>();
                        }
                        maforobj.Id = item.Id;
                        maforobj.Name = item.Name;
                        maforobj.Details = item.Details;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.Thumbnail = item.Thumbnail;
                        maforobj.ActivityTypeId = item.ActivityTypeId;
                        maforobj.ActivityTypeName = item.ActivityTypeName;
                        maforobj.MainClassificationId = item.MainClassificationId;
                        maforobj.MainClassificationName = item.MainClassificationName;
                        maforobj.AdditionalSectionsId = item.AdditionalSectionsId;
                        maforobj.AdditionalSectionsName = item.AdditionalSectionsName;
                        maforobj.Discount = item.Discount;
                        maforobj.DiscountType = item.DiscountType;
                        maforobj.UnitPrice = item.UnitPrice;
                        maforobj.PurchasePrice = item.PurchasePrice;
                        maforobj.BrandId = item.BrandId;
                        maforobj.ServiceProviderId = item.ServiceProviderId;
                        maforobj.Code = item.Code;
                        maforobj.Video_Url = item.Video_Url;
                        maforobj.Video_Provider = item.Video_Provider;
                        maforobj.UnitId = item.UnitId;
                        maforobj.UserId = item.UserId;
                        maforobj.RatingPro = item.RatingPro;
                        listserifor.Add(maforobj);
                    }
                }
                return await Result<IEnumerable<productdtoADDapi>>.SuccessAsync(listserifor, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<IEnumerable<productdtoADDapi>>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<IEnumerable<ProductQueryDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var items = await _repositoryManager.ProductRepository.GetAll(x => new ProductQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                PurchasePrice = x.PurchasePrice,
                Active = x.Active,
                ActivityTypeId = (int)x.ActivityTypeId,
                ActivityTypeName = x.ActivityType.ActivityName,
                UserId = x.UserId,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                Add_By = x.Add_By,
                BrandId = (int)x.BrandId,
                Code = x.Code,
                Current_Stock = (int)x.Current_Stock,
                Details = x.Details,
                Discount = (int)x.Discount,
                DiscountType = x.DiscountType,
                Free_Shipping = x.Free_Shipping,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                Min_qty = (int)x.Min_qty,
                Multiply_Qty = x.Multiply_Qty,
                Negotiation = x.Negotiation,
                ProductStates = x.ProductStates,
                Refundable = x.Refundable,
                ServiceProviderId = (int)x.ServiceProviderId,
                SpecialSectionsId = (int)x.SpecialSectionsId,
                SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                Thumbnail = x.Thumbnail,
                UnitId = (int)x.UnitId,

                Video_Provider = x.Video_Provider,
                Video_Url = x.Video_Url,

            });
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.Rating);
                        var ratmt = proeval.Count();
                        item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                    }
                    else
                    {
                        item.RatingPro = "0";

                    }

                }
            }
            var itemMap = _mapper.Map<IEnumerable<ProductQueryDto>>(items);

            if (items == null) return await Result<IEnumerable<ProductQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProductQueryDto>>.SuccessAsync(itemMap, "Product records retrieved");
        }

        public async Task<IResult<DtResult<ProductQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ProductRepository.GetAll(dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProductRepository.GetAll(x => new ProductQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                PurchasePrice = x.PurchasePrice,
                Active = x.Active,
                ActivityTypeId = (int)x.ActivityTypeId,
                ActivityTypeName = x.ActivityType.ActivityName,
                UserId = x.UserId,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                Add_By = x.Add_By,
                BrandId = (int)x.BrandId,
                Code = x.Code,
                Current_Stock = (int)x.Current_Stock,
                Details = x.Details,
                Discount = (int)x.Discount,
                DiscountType = x.DiscountType,
                Free_Shipping = x.Free_Shipping,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                Min_qty = (int)x.Min_qty,
                Multiply_Qty = x.Multiply_Qty,
                Negotiation = x.Negotiation,
                ProductStates = x.ProductStates,
                Refundable = x.Refundable,
                ServiceProviderId = (int)x.ServiceProviderId,
                SpecialSectionsId = (int)x.SpecialSectionsId,
                SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                Thumbnail = x.Thumbnail,
                UnitId = (int)x.UnitId,
                VideoUrl = x.VideoUrl,
                Video_Provider = x.Video_Provider,
                Video_Url = x.Video_Url,

            }, dtRequest.start, dtRequest.length);
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.Rating);
                        var ratmt = proeval.Count();
                        item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                    }
                    else
                    {
                        item.RatingPro = "0";

                    }

                }
            }
            var totalRecord = await _repositoryManager.ProductRepository.Entities.CountAsync();

            var itemMap = _mapper.Map<IEnumerable<ProductQueryDto>>(items);

            var datatableReturned = DtResult<ProductQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, totalRecord, itemMap, string.Empty);

            return await Result<DtResult<ProductQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product Datatable.", 200);

        }
        public async Task<IResult<listgetprodict>> GetAlllistforAdd(CancellationToken cancellationToken = default)
        {
            //var items = await _repositoryManager.ProductRepository.GetAll(dtRequest.start,dtRequest.length);
            listgetprodict newobjj = new listgetprodict();

            var items = await _repositoryManager.BrandRepository.GetAll(x => new BrandDtoApi
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
            });
            var sc = new List<BrandDtoApi>();
            foreach (var item in items)
            {
                sc.Add(item);
            }
            var itemsmain = await _repositoryManager.MainClassificationRepository.GetAll(x => new MainClassificationDtoApi
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName,
                ImageUrl = x.ImageUrl,
            });
            var scm = new List<MainClassificationDtoApi>();
            foreach (var item in itemsmain)
            {
                scm.Add(item);
            }
            var itemsw = await _repositoryManager.AdditionalSectionsRepository.GetAll(x => new AdditionalSectionsDtoApi
            {
                Id = x.Id,
                AdditionalSectionsName = x.AdditionalSectionsName,
                ImageUrl = x.ImageUrl,
                Rank = x.Rank,
                ParnetSectionId = x.ParnetSectionId,
            });
            var scn = new List<AdditionalSectionsDtoApi>();
            foreach (var item in itemsw)
            {
                scn.Add(item);
            }
            //var itemsnw = await _repositoryManager.AdditionalSectionsRepository.GetAll(x => new AdditionalSectionsQueryDto
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
            //var scne = new List<MainAndAdditionalClassificationDtoApi>();
            //var scneobjj = new MainAndAdditionalClassificationDtoApi();
            //foreach (var item in itemsnw)
            //{
            //    scneobjj.MainClassificationDto.Id=(int)item.MainClassificationId,
            //    scneobjj.MainClassificationDto.MainClassificationName=item.MainClassificationName,
            //    scneobjj.MainClassificationDto.ImageUrl=item.MainClassificationImageUrl,
            //    scn.Add(item);
            //}
            newobjj.BrandDto = sc;
            newobjj.UnitDto = new List<UnitDtoApi>();
            newobjj.MainClassificationDto = scm;
            newobjj.AdditionalSectionsDto = scn;
            newobjj.Attribute = new List<AttributeApi>();
            newobjj.ColorDto = new List<ColorDtoApi>();
            newobjj.MainAndAdditionalDtoApi = new List<MainAndAdditionalClassificationDtoApi>();
            var itemMap = _mapper.Map<listgetprodict>(newobjj);

            return await Result<listgetprodict>.SuccessAsync(itemMap, "Product record retrieved");
            //    return await Result<DtResult<listgetprodict>>.SuccessAsync(newobjj, message: "Get Product Datatable.", 200);

        }


        public async Task<IResult<IEnumerable<ProductQueryDto>>> Find(Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product, bool>>>(expression);

            //var items = await _repositoryManager.ProductRepository.Find(mapExpr);

            var items = await _repositoryManager.ProductRepository.Find(x => new ProductQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                PurchasePrice = x.PurchasePrice,
                Active = x.Active,
                ActivityTypeId = (int)x.ActivityTypeId,
                ActivityTypeName = x.ActivityType.ActivityName,
                UserId = x.UserId,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                Add_By = x.Add_By,
                BrandId = (int)x.BrandId,
                Code = x.Code,
                Current_Stock = (int)x.Current_Stock,
                Details = x.Details,
                Discount = (int)x.Discount,
                DiscountType = x.DiscountType,
                Free_Shipping = x.Free_Shipping,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                Min_qty = (int)x.Min_qty,
                Multiply_Qty = x.Multiply_Qty,
                Negotiation = x.Negotiation,
                ProductStates = x.ProductStates,
                Refundable = x.Refundable,
                ServiceProviderId = (int)x.ServiceProviderId,
                SpecialSectionsId = (int)x.SpecialSectionsId,
                SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                Thumbnail = x.Thumbnail,
                UnitId = (int)x.UnitId,
                VideoUrl = x.VideoUrl,
                Video_Provider = x.Video_Provider,
                Video_Url = x.Video_Url,

            }, mapExpr);
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.Rating);
                        var ratmt = proeval.Count();
                        item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                    }
                    else
                    {
                        item.RatingPro = "0";

                    }

                }
            }

            var itemMap = _mapper.Map<IEnumerable<ProductQueryDto>>(items);
            
            if (items == null || items.Any() == false) return await Result<IEnumerable<ProductQueryDto>>.FailAsync("No Data");
            return await Result<IEnumerable<ProductQueryDto>>.SuccessAsync(itemMap, "Product records retrieved");
        }

        public async Task<IResult<DtResult<ProductQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default)
        {

            var mapExpr = _mapper.Map<Expression<Func<Product, bool>>>(expression);

            //var items = await _repositoryManager.ProductRepository.Find(mapExpr,dtRequest.start,dtRequest.length);

            var items = await _repositoryManager.ProductRepository.Find(x => new ProductQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                PurchasePrice = x.PurchasePrice,
                Active = x.Active,
                ActivityTypeId = (int)x.ActivityTypeId,
                ActivityTypeName = x.ActivityType.ActivityName,
                UserId = x.UserId,
                AdditionalSectionsId = (int)x.AdditionalSectionsId,
                AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                Add_By = x.Add_By,
                BrandId = (int)x.BrandId,
                Code = x.Code,
                Current_Stock = (int)x.Current_Stock,
                Details = x.Details,
                Discount = (int)x.Discount,
                DiscountType = x.DiscountType,
                Free_Shipping = x.Free_Shipping,
                MainClassificationId = (int)x.MainClassificationId,
                MainClassificationName = x.MainClassification.MainClassificationName,
                Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                Min_qty = (int)x.Min_qty,
                Multiply_Qty = x.Multiply_Qty,
                Negotiation = x.Negotiation,
                ProductStates = x.ProductStates,
                Refundable = x.Refundable,
                ServiceProviderId = (int)x.ServiceProviderId,
                SpecialSectionsId = (int)x.SpecialSectionsId,
                SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                Thumbnail = x.Thumbnail,
                UnitId = (int)x.UnitId,
                VideoUrl = x.VideoUrl,
                Video_Provider = x.Video_Provider,
                Video_Url = x.Video_Url,

            }, mapExpr, dtRequest.start, dtRequest.length);
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                    if (proeval.Count() != 0)
                    {
                        var ratt = proeval.Sum(x => x.Rating);
                        var ratmt = proeval.Count();
                        item.RatingPro = Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));
                    }
                    else
                    {
                        item.RatingPro = "0";

                    }

                }
            }
            var totalRecord = await _repositoryManager.ProductRepository.Entities.CountAsync();

            var filteredRecord = items.Count();

            var itemMap = _mapper.Map<IEnumerable<ProductQueryDto>>(items);

            var datatableReturned = DtResult<ProductQueryDto>.DataTableFactory(dtRequest.draw, totalRecord, filteredRecord, itemMap, string.Empty);
            if (items == null || items.Any() == false) return await Result<DtResult<ProductQueryDto>>.FailAsync("No Data");
            return await Result<DtResult<ProductQueryDto>>.SuccessAsync(datatableReturned, message: "Get Product Datatable.", 200);
        }


        public async Task<IResult<ProductQueryDto>> GetById(int Id, CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProductRepository.GetById(Id);

            if (item == null) return await Result<ProductQueryDto>.FailAsync("GetProductById > the given id NOT EXIEST !!!...");
            string srt = "0";
            if (item != null)
            {
                var proeval = await _repositoryManager.ProductEvaluatonRepository.Find(x => x.ProductId == item.Id);
                if (proeval.Count() != 0)
                {
                    var ratt = proeval.Sum(x => x.Rating);
                    var ratmt = proeval.Count();
                    srt =Convert.ToString(Convert.ToDouble(ratt) / Convert.ToDouble(ratmt));

                }



            }

            var itemMap = _mapper.Map<ProductQueryDto>(item);
            itemMap.RatingPro = srt;
            return await Result<ProductQueryDto>.SuccessAsync(itemMap, "Product record retrieved");
        }
        public async Task<IResult<ProductQueryDto>> GetByIdMvc(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _repositoryManager.ProductRepository.Find(x => new ProductQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    PurchasePrice = x.PurchasePrice,
                    Active = x.Active,
                    ActivityTypeId = (int)x.ActivityTypeId,
                    ActivityTypeName = x.ActivityType.ActivityName,
                    UserId = x.UserId,
                    AdditionalSectionsId = (int)x.AdditionalSectionsId,
                    AdditionalSectionsName = x.AdditionalSections.AdditionalSectionsName,
                    Add_By = x.Add_By,
                    BrandId = (int)x.BrandId,
                    Code = x.Code,
                    Current_Stock = (int)x.Current_Stock,
                    Details = x.Details,
                    Discount = (int)x.Discount,
                    DiscountType = x.DiscountType,
                    Free_Shipping = x.Free_Shipping,
                    MainClassificationId = (int)x.MainClassificationId,
                    MainClassificationName = x.MainClassification.MainClassificationName,
                    Minimum_Order_Qty = (int)x.Minimum_Order_Qty,
                    Min_qty = (int)x.Min_qty,
                    Multiply_Qty = x.Multiply_Qty,
                    Negotiation = x.Negotiation,
                    ProductStates = x.ProductStates,
                    Refundable = x.Refundable,
                    ServiceProviderId = (int)x.ServiceProviderId,
                    SpecialSectionsId = (int)x.SpecialSectionsId,
                    SpecialSectionsName = x.SpecialSections.SpecialSectionName,
                    Thumbnail = x.Thumbnail,
                    UnitId = (int)x.UnitId,
                    VideoUrl = x.VideoUrl,
                    Video_Provider = x.Video_Provider,
                    Video_Url = x.Video_Url,

                }, x => x.Id == Id);
                var hhm = new ProductQueryDto();
                var itemMap = _mapper.Map<IEnumerable<ProductQueryDto>>(items);
                foreach (var s in itemMap)
                {
                    hhm = s;
                }
                var coonamm = await _repositoryManager.Product_ColorsRepository.Find(x => x.ProductId == hhm.Id);
                var vartrRes = await _repositoryManager.Product_variantionRepository.Find(x => x.ProductId == hhm.Id);

                var colorss = new List<Product_ColorsDtoapi>();
                var newvarit = new List<Product_variantionDto>();
                var newvarimage = new List<Product_Image>();
                foreach (var s in vartrRes)
                {
                    newvarit.Add(new Product_variantionDto { Id = s.Id, SKU = s.SKU, Price = s.Price, Type = s.Type, qty = s.qty,Active=s.Active });
                }
                //foreach (var s in newvarimage)
                //{
                //    newvarimage.Add(new Product_Image { Id = s.Id, ImageUrl = s.ImageUrl });
                //}

                foreach (var s in coonamm)
                {
                    var m = await _repositoryManager.ColorRepository.GetById(s.ColorId);
                    colorss.Add(new Product_ColorsDtoapi { Id = s.Id,ColorId=s.ColorId, ColorName = m.Name, Colorcode = m.code});
                }
                hhm.Product_variantionDtoList = newvarit;
                hhm.Colorlist = colorss;

                var msc = await _repositoryManager.Product_ImageRepository.Find(x => x.ProductId == hhm.Id);
                var mms = _mapper.Map<IEnumerable<Product_ImageDto>>(msc);
                hhm.Product_ImageDtoList = mms.ToList();
                //     var itemMap = _mapper.Map<ProductQueryDto>(hhm);
                return await Result<ProductQueryDto>.SuccessAsync(hhm, "Product record retrieved");
            }
            catch (Exception exc)
            {
                Console.WriteLine("****************************************************");
                //Console.WriteLine(exc.ToString());
                return await Result<ProductQueryDto>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.InnerException.Message}");
            }
        }

        public async Task<IResult<IEnumerable<ProductDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default)
        {

            var item = await _repositoryManager.ProductRepository.GetDDL();

            if (item == null) return await Result<IEnumerable<ProductDDlLViewModels>>.FailAsync("GetProductDDL > ERRORS !!!...");


            //var itemMap = _mapper.Map<ProductDDLViewModel>(item);

            return await Result<IEnumerable<ProductDDlLViewModels>>.SuccessAsync(item, "Product DDL records retrieved");
        }
        public async Task<IResult<productdtoADDapi>> AddApi(productdtoADDapi entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<productdtoADDapi>.FailAsync("AddProduct > the passed entity IS NULL !!!.");


            try
            {
                Product obj = new Product();
                obj.Name = entity.Name;
                obj.Details = entity.Details;
                obj.UnitPrice = entity.UnitPrice;
                obj.PurchasePrice = entity.PurchasePrice;
                obj.Discount = entity.Discount;
                obj.UserId = entity.UserId;
                obj.DiscountType = entity.DiscountType;
                obj.Current_Stock = entity.Current_Stock;
                obj.UnitId = entity.UnitId;
                obj.BrandId = entity.BrandId;
                obj.VideoUrl = entity.Video_Url;
                obj.Video_Provider = entity.Video_Provider;
                obj.ProductStates = entity.ProductStates;
                obj.Min_qty = entity.Min_qty;
                obj.Negotiation = entity.Negotiation;
                obj.Refundable = entity.Refundable;
                obj.ServiceProviderId = entity.ServiceProviderId;
                obj.Code = entity.Code;
                obj.Free_Shipping = entity.Free_Shipping;
                obj.Minimum_Order_Qty = entity.Minimum_Order_Qty;
                obj.MainClassificationId = entity.MainClassificationId;
                obj.AdditionalSectionsId = entity.AdditionalSectionsId;
                obj.ActivityTypeId = entity.ActivityTypeId;
                obj.Thumbnail = entity.Thumbnail;

                var newEntity = await _repositoryManager.ProductRepository.AddAndReturn(_mapper.Map<Product>(entity));
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                var newobjproapi = _mapper.Map<productdtoADDapi>(newEntity);
                if (newEntity != null)
                {
                    if (entity.Colors != null)
                    {
                        var newprocolor = new List<Product_Colors>();
                        foreach (var i in entity.Colors)
                        {
                            var newobjprocolor = new Product_Colors();
                            newobjprocolor.ColorId = i.Id;
                            newobjprocolor.ProductId = newEntity.Id;
                            newprocolor.Add(newobjprocolor);
                        }
                        var rescol = _repositoryManager.Product_ColorsRepository.Addlist(newprocolor);
                        await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    }

                    if (entity.choice_options != null)
                    {

                        var newprocolor = new List<Product_Variant_Attribute>();


                        foreach (var i in entity.choice_options)
                        {
                            foreach (var j in i.options)
                            {
                                var newobjprocolor = new Product_Variant_Attribute();
                                newobjprocolor.value = j;
                                newobjprocolor.Product_AttributeId = i.id;
                                newobjprocolor.ProductId = newEntity.Id;
                                newprocolor.Add(newobjprocolor);
                            }


                        }
                        var rescol = _repositoryManager.Product_Variant_AttributeRepository.Addlist(newprocolor);
                        await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);


                        //var newprocolor = new List<Product_Variant_Attribute>();
                        //foreach (var i in entity.choice_options)
                        //{


                        //    var newobjprocolor = new Product_Variant_Attribute();
                        //    newobjprocolor.value = i.name;
                        //    newobjprocolor.Product_AttributeId = i.id;
                        //    newobjprocolor.ProductId = newEntity.Id;
                        //    newprocolor.Add(newobjprocolor);
                        //}
                        //var rescol = _repositoryManager.Product_Variant_AttributeRepository.Addlist(newprocolor);
                        //await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    }
                    if (entity.images != null)
                    {
                        var newprocolor = new List<Product_Image>();
                        foreach (var i in entity.images)
                        {
                            var newobjprocolor = new Product_Image();
                            newobjprocolor.ImageUrl = i;
                            newobjprocolor.ProductId = newEntity.Id;
                            newprocolor.Add(newobjprocolor);
                        }
                        var rescol = _repositoryManager.Product_ImageRepository.Addlist(newprocolor);
                        await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    }
                    if (entity.variation != null)
                    {
                        var newprocolor = new List<Product_variantion>();
                        //   newprocolor = entity.variation.ToList();
                        foreach (var i in entity.variation)
                        {
                            var newobjprocolor = new Product_variantion();
                            newobjprocolor.Type = i.Type;
                            newobjprocolor.Price = i.Price.Value;
                            newobjprocolor.SKU = i.SKU;
                            newobjprocolor.ProductId = newEntity.Id;
                            newobjprocolor.qty = i.qty;
                            newprocolor.Add(newobjprocolor);
                        }
                        var rescol = _repositoryManager.Product_variantionRepository.Addlist(newprocolor);
                        await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);
                    }

                }

                entity.Id = newEntity.Id;
                return await Result<productdtoADDapi>.SuccessAsync(entity, "Product record added");
            }
            catch (Exception exc)
            {
                if (exc.InnerException != null)
                {
                    Console.WriteLine($"=====InnerEXp: {exc.InnerException.Message}");
                }
                return await Result<productdtoADDapi>.FailAsync($"AddProduct > Something went wrong !!!/n{exc.Message}");
            }

        }

        public async Task<IResult<ProductQueryDto>> Add(ProductDto entity, CancellationToken cancellationToken = default)
        {

            if (entity == null) return await Result<ProductQueryDto>.FailAsync("AddProduct > the passed entity IS NULL !!!.");


            try
            {
                var newEntity = await _repositoryManager.ProductRepository.AddAndReturn(_mapper.Map<Product>(entity));

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                var entityMap = _mapper.Map<ProductQueryDto>(newEntity);

                return await Result<ProductQueryDto>.SuccessAsync(entityMap, "Product record added");
            }
            catch (Exception exc)
            {

                return await Result<ProductQueryDto>.FailAsync($"AddProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }

        }


        public async Task<IResult> Remove(int Id, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProductRepository.GetById(Id);

            if (item == null) return await Result.FailAsync("RemoveProduct > the given id NOT EXIEST !!!.");

            try
            {
                _repositoryManager.ProductRepository.Remove(item);

                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result.SuccessAsync("RemoveProduct record deleted");
            }
            catch (Exception exc)
            {

                return await Result.FailAsync($"RemoveProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }

        public async Task<IResult<ProductQueryDto>> Update(ProductDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ProductQueryDto>.FailAsync($"UpdateProduct > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ProductRepository.GetById(entity.Id);

            if (item == null) return await Result<ProductQueryDto>.FailAsync("UpdateProduct > the passed entity with the given id NOT EXIEST !!!.");

            //var entityDb = await _repositoryManager.ProductRepository.Find(x =>  x.Name.Contains(entity.Name) && x.Id != entity.Id);

            //if (entityDb != null && entityDb.Count() > 0) return await Result<ProductQueryDto>.FailAsync("UpdateProduct > the same record IS ALREADY EXIEST !!!.");

            _mapper.Map(entity, item);
            _repositoryManager.ProductRepository.Update(item);

            try
            {

                //_repositoryManager.UnitOfWork.GetContext().Entry(item).State = EntityState.Modified;
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductQueryDto>.SuccessAsync(_mapper.Map<ProductQueryDto>(item), "Product record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductQueryDto>.FailAsync($"UpdateProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult<ProductQueryDto>> Updatemvc(ProductQueryDto entity, CancellationToken cancellationToken = default)
        {


            if (entity == null) return await Result<ProductQueryDto>.FailAsync($"UpdateProduct > the passed entity IS NULL!!!...");

            var item = await _repositoryManager.ProductRepository.GetById(entity.Id);


            try
            {
                _mapper.Map(entity, item);
                _repositoryManager.ProductRepository.Update(item);
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductQueryDto>.SuccessAsync(_mapper.Map<ProductQueryDto>(item), "Product record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductQueryDto>.FailAsync($"UpdateProduct > Something went wrong !!!\n\n\n{exc.Message}");
            }
        }
        public async Task<IResult> ChangeActive(ProductDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProductRepository.GetById(entity.Id);
            item.Active = !item.Active;
            _repositoryManager.ProductRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductQueryDto>.SuccessAsync(_mapper.Map<ProductQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        } 
        public async Task<IResult> ChangeStateForProduct(ProductDto entity, CancellationToken cancellationToken = default)
        {
            var item = await _repositoryManager.ProductRepository.GetById(entity.Id);
            item.ProductStates = !item.ProductStates;
            _repositoryManager.ProductRepository.Update(item);
            try
            {
                await _repositoryManager.UnitOfWork.CompleteAsync(cancellationToken);

                return await Result<ProductQueryDto>.SuccessAsync(_mapper.Map<ProductQueryDto>(item), "Unit record updated");
            }
            catch (Exception exc)
            {
                return await Result<ProductQueryDto>.FailAsync($"UpdateUnit > Something went wrong !!!\n\n\n{exc.Message}");
            }



        }
    }
}
 