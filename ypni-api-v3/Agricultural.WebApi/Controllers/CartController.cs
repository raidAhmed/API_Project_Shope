
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.Application.DTOs.Cart;
using Agricultural.Application.Wrapper;
using Agricultural.Application.Constants;
using Agricultural.Application.Constants.Permissions;
using Agricultural.Application.Common;
using FluentValidation.Results;
using System.Text;
using Agricultural.WebApi.ViewModel;
using Agricultural.Application.DTOs.CartDetails;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.Product_variantion;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseApiController
    {
        [HttpGet("Get/{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            // return BadRequest("jjjjjjjjjjjjjjjjjjjjjjjjjj");
            try
            {
                var CartDetailsVm = new CartDetailsQurayVm();
                CartDetailsVm.product = new List<ProductQueryDto>();
                CartDetailsVm.serverProviderVm = new List<ServerProviderVm>();
                CartDetailsVm.CartDetails = new List<CartDetailsQueryDto>();
                var Cart = await ServiceManager.CartService.Find(c => c.UserId == userId);

                if (Cart.Succeeded)
                {
                    CartDetailsVm.total = Cart.Data.Last().Total;
                    
                    foreach (var CartItem in Cart.Data)
                    {
                        var CartDetails = await ServiceManager.CartDetailsService.Find(c => c.CartId == CartItem.Id);

                        if (CartDetails.Succeeded)
                        if (CartDetails.Data.Count()!=0)
                        {
                            CartDetailsVm.price = CartDetails.Data.First().Price;
                            foreach (var CartDetailsItem in CartDetails.Data)
                            {
                                CartDetailsVm.CartDetails.Add(CartDetailsItem);
                                var product = await ServiceManager.ProductService.GetById(CartDetailsItem.ProductId);

                                if (product.Succeeded)
                                {
                                    if (CartDetailsItem.Product_variantionId != null)
                                    {

                                        var product_variantion = await ServiceManager.Product_variantionService.getByProductId(product.Data.Id);
                                        //  return Ok(product_variantion);

                                        if (product_variantion.Data.Any())
                                        {

                                            if (product_variantion.Succeeded)
                                            {
                                                product.Data.Product_variantionDtoList = new List<Product_variantionDto>();
                                                foreach (var variant in product_variantion.Data)
                                                {
                                                    var p = new Product_variantionDto
                                                    {
                                                        ProductId = variant.ProductId,
                                                        Active = variant.Active,
                                                        Id = variant.Id,
                                                        Price = variant.Price,
                                                        qty = variant.qty,
                                                        Type = variant.Type,
                                                        SKU = variant.SKU,
                                                    };
                                                    product.Data.Product_variantionDtoList.Add(p);
                                                    product.Data.Product_variantionDtoList.Where(v => v.ProductId == product.Data.Id).ToList();
                                                }
                                            }
                                        }


                                        }
                                        else
                                        {
                                            product.Data.Product_variantionDtoList=new List<Product_variantionDto>();
                                        }


                                    CartDetailsVm.product.Add(product.Data);
                                }
                                else
                                {
                                    CartDetailsVm.product = new List<ProductQueryDto>();
                                   // return BadRequest(product.Status);
                                }

                            }

                        }
                        else
                        {
                            CartDetailsVm.cartDetailsQueryDtos=new List<CartDetailsQueryDto>();
                        }///end cardDetails if
                        if (CartDetailsVm.CartDetails.Count() != 0)
                        {
                            var serverProvider = await ServiceManager.ServiceProviderService.GetById(CartItem.ServiceProviderId);
                            if (serverProvider.Succeeded)
                            {
                                CartDetailsVm.serverProviderVm.Add(new ServerProviderVm
                                {
                                    serverName = serverProvider.Data.TradeName,
                                    serverProviderId = serverProvider.Data.Id
                                });
                            }
                            else
                            {
                                CartDetailsVm.serverProviderVm = new List<ServerProviderVm>();
                                //   return Ok(serverProvider.Status);

                            }
                        }
                    }
                    var res = new Result<CartDetailsQurayVm>
                    {
                        Data = CartDetailsVm,
                        Status = Cart.Status,
                        Succeeded = Cart.Succeeded
                    };
                    return Ok(res);
                }

                return Ok(CartDetailsVm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"errrrrrrrrrrorrrrrrrr  {ex.Message}");
                return BadRequest(ex.Message);
            }


        }

        // POST: api/ActivityType/GetDt

        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.CartService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }

        }

        // GET ActivityType/GetDDL

        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.CartService.GetDDL();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        // GET api/ActivityType/5

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await ServiceManager.CartService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }



        // POST api/ActivityType

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartCreateVm entity)
        {

            if (entity == null)
                return BadRequest("null");
            var check = await ServiceManager.CartService.Find(c => c.UserId == entity.UserId && c.ServiceProviderId == entity.ServiceProviderId);
            if (check.Succeeded)
            {
                //   var cartDtoResByProductId = await ServiceManager.CartDetailsService.Find(p => p.ProductId == entity.ProductId );
                var cartDtoResByProductId = await ServiceManager.CartDetailsService.Find(p => p.ProductId == entity.ProductId && p.UserId == entity.UserId);
                if (cartDtoResByProductId.Data.Any())
                {
                    if (entity.Product_variantionId != null)
                    {
                        var resultdb = cartDtoResByProductId.Data.Where(p => p.ProductId == entity.ProductId && p.Product_variantionId == entity.Product_variantionId && p.UserId == entity.UserId);
                        if (resultdb.Any())
                        {
                            Console.WriteLine("11111111111111111111111111111111");
                            var notNullRes = resultdb.First();
                            var resUpdate = new CartDetailsDto
                            {
                                Id = notNullRes.Id,
                                Price = entity.Price,
                                Total = check.Data.First().Total,
                                State = notNullRes.State,
                                Sku = notNullRes.Sku,
                                ProductId = notNullRes.ProductId,
                                Active = notNullRes.Active,
                                Product_variantionId = notNullRes.Product_variantionId,
                                CartId = notNullRes.CartId,
                                Quantity = entity.Quantity, 
                                 ServiceProviderId=entity.ServiceProviderId,
                                  UserId=entity.UserId,
                                 
                            }; 

                            var updateCartDetails = await ServiceManager.CartDetailsService.Update(resUpdate);
                            if (updateCartDetails.Succeeded)
                            {
                                return Ok(updateCartDetails);
                            }
                            else
                            {
                                return BadRequest(updateCartDetails.Status);

                            }
                        }
                        else
                        {
                            var res1 = new CartDetailsDto
                            {
                                Price = entity.Price,
                                Total = check.Data.First().Total,
                                State = true,//result.Data.State,
                                Sku = check.Data.First().Sku,
                                ProductId = entity.ProductId,
                                Active = entity.Active,
                                Product_variantionId = entity.Product_variantionId,
                                CartId = check.Data.First().Id,
                                Quantity = entity.Quantity,
                                ServiceProviderId = entity.ServiceProviderId,
                                UserId = entity.UserId
                            };
                            var cartDtoRes1 = await ServiceManager.CartDetailsService.Add(res1);
                            if (cartDtoRes1.Succeeded)
                            {
                                return Ok(cartDtoRes1);
                            }
                            else
                            {
                                return BadRequest(cartDtoRes1.Status);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                        var resEdit = new CartDetailsDto
                        {Id= cartDtoResByProductId.Data.First().Id,
                            Price = entity.Price,
                            Total = cartDtoResByProductId.Data.First().Total,
                            State = true,//result.Data.State,
                            Sku = cartDtoResByProductId.Data.First().Sku,
                            ProductId = entity.ProductId,
                            Active = entity.Active,
                            Product_variantionId = entity.Product_variantionId,
                            CartId = cartDtoResByProductId.Data.First().CartId,
                            Quantity = entity.Quantity,
                            ServiceProviderId = entity.ServiceProviderId,
                            UserId = entity.UserId
                        };
                        var cartDtoRes3 = await ServiceManager.CartDetailsService.Update(resEdit);
                        if (cartDtoRes3.Succeeded)
                        {
                            return Ok(cartDtoRes3);
                        }
                        else
                        {
                            return BadRequest(cartDtoRes3.Status);
                        }
                    }
                }
                var obj = new CartDetailsDto
                {
                    Price = entity.Price,
                    Total = check.Data.First().Total,
                    State = true,//result.Data.State,
                    Sku = check.Data.First().Sku,
                    ProductId = entity.ProductId,
                    Active = entity.Active,
                    Product_variantionId = entity.Product_variantionId,
                    CartId = check.Data.First().Id,
                    Quantity = entity.Quantity,
                    ServiceProviderId = entity.ServiceProviderId,
                    UserId = entity.UserId
                };
                var cartDtoRes = await ServiceManager.CartDetailsService.Add(obj);



                if (cartDtoRes.Succeeded)
                {
                    return Ok(cartDtoRes);
                }
                else
                {
                    return BadRequest(cartDtoRes.Status);
                }
            }
            else
            {
                var cartDto = new CartDto
                {
                    Sku = entity.Sku,
                    State = entity.State,
                    Total = entity.Total,
                    UserId = entity.UserId,
                    ServiceProviderId = entity.ServiceProviderId,
                };


                var result = await ServiceManager.CartService.Add(cartDto);


                if (result.Succeeded)
                {
                    var res = new CartDetailsDto
                    {
                        Price = entity.Price,
                        Total = result.Data.Total,
                        //  State = result.Data.State,
                        Sku = result.Data.Sku,
                        ProductId = entity.ProductId,
                        Active = entity.Active,
                        Product_variantionId = entity.Product_variantionId,
                        CartId = result.Data.Id,
                        Quantity = entity.Quantity,
                    };
                    var cartDtoRes = await ServiceManager.CartDetailsService.Add(res);



                    if (cartDtoRes.Succeeded)
                    {
                        return Ok(cartDtoRes);
                    }
                    else
                    {
                        return BadRequest(cartDtoRes.Status);
                    }

                }

                return BadRequest(result.Status);
            }
        }



        [HttpPost("ChangeQuantity")]
        public async Task<IActionResult> ChangeQuantity([FromBody] ChangeQuantityVm entity)
        {
         
            if (entity == null) return BadRequest("null");

            var cartRes = await ServiceManager.CartDetailsService.GetById(entity.Id);
            if (cartRes.Succeeded)
            {
                
                var obj = new CartDetailsDto
                {
                    Id = entity.Id,
                    Active=cartRes.Data.Active,
                    Sku = cartRes.Data.Sku,
                    CartId=cartRes.Data.CartId,
                    Quantity = entity.Quantity,
                    Price = cartRes.Data.Price,
                    
                    ProductId = cartRes.Data.ProductId,
                    Product_variantionId = cartRes.Data.Product_variantionId,
                    ServiceProviderId = cartRes.Data.ServiceProviderId, 
                    State = cartRes.Data.State, 
                    Total = cartRes.Data.Total, 
                    UserId = cartRes.Data.UserId,    
                    


                };

                var res = await ServiceManager.CartDetailsService.Update(obj);
                if (res.Succeeded)
                {
                    return Ok(res);
                }
                return BadRequest(res.Status);
            }
            return BadRequest(cartRes.Status);




        }


        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.CartDetailsService.RemoveAndReturn(Id);

            if (result.Succeeded)
            {
                var res=await ServiceManager.CartService.Remove(result.Data.CartId);
                if (res.Succeeded)
                {
                    return Ok(result);

                }
                return BadRequest(result.Status);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }
    }
}
