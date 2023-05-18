using Agricultural.Application.DTOs.Order;
using Agricultural.Application.DTOs.OrderDetails;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels;
using Agricultural.Application.Wrapper;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        [HttpGet("GetByServiceProviderId/{serviceProviderId}")]
        public async Task<IActionResult> GetByServiceProviderId(int serviceProviderId)
        {


            try
            {
                var orderDetailsQurayVmList = new List<OrderDetailsQurayVm>();

                var order = await ServiceManager.OrderService.Find(c => c.ServiceProviderId == serviceProviderId);
                if (order.Succeeded)
                {

                    foreach (var orderItem in order.Data)
                    {

                        var orderDetailsQurayVm = new OrderDetailsQurayVm();
                        orderDetailsQurayVm.product = new List<ProductQueryDto>();
                        orderDetailsQurayVm.serverProviderVm = new List<ServerProviderVm>();
                        orderDetailsQurayVm.orderDetailsQueryDto = new List<OrderDetailsQueryDto>();
                        orderDetailsQurayVm.orderVm = new OrderVm
                        {
                            Active = orderItem.Active,
                            CartId = orderItem.CartId,
                            Id = orderItem.Id,
                            OrderId = orderItem.OrderID ??= 0,
                            Quantity = 0,
                            //State = orderItem.State,
                            State = orderItem.State,
                            Total = orderItem.Total,
                            UserId = orderItem.UserId,
                            ServiceProviderId = orderItem.ServiceProviderId,
                            Created = "2022-03-16T22:53:43.000000Z",
                            deliveryStatus = 0,
                            paymentStatus = 0,

                        };





                        var OrderDetails = await ServiceManager.OrderDetailsService.Find(c => c.OrderId == orderItem.Id);

                        if (OrderDetails.Succeeded)
                        {
                            foreach (var OderDetailsItem in OrderDetails.Data)
                            {
                                orderDetailsQurayVm.orderDetailsQueryDto.Add(OderDetailsItem);
                                var product = await ServiceManager.ProductService.GetById(OderDetailsItem.ProductId);

                                if (product.Succeeded)
                                {
                                    if (OderDetailsItem.Product_variantionId != null)
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


                                    orderDetailsQurayVm.product.Add(product.Data);
                                }
                                else
                                {
                                    return BadRequest(product.Status);
                                }

                            }

                        }///end cardDetails if

                        // user information
                        var userInfo = await ServiceManager.UserService.GetById(orderItem.UserId);
                        if (userInfo.Succeeded)
                        {
                            orderDetailsQurayVm.userInformationVm = new UserInformationVm
                            {
                                Id = userInfo.Data.Id,
                                FirstName = userInfo.Data.FirstName,
                                LastName = userInfo.Data.LastName,
                                Image = userInfo.Data.Image,
                                PhoneNumber = userInfo.Data.PhoneNumber,
                                Email = userInfo.Data.Email,
                            };

                        }
                        else
                        {
                            return Ok(userInfo.Status);
                        }

                        var serverProvider = await ServiceManager.ServiceProviderService.GetById(orderItem.ServiceProviderId.Value);
                        if (serverProvider.Succeeded)
                        {
                            orderDetailsQurayVm.serverProviderVm.Add(new ServerProviderVm
                            {
                                serverName = serverProvider.Data.TradeName,
                                serverProviderId = serverProvider.Data.Id
                            });
                        }
                        else
                        {
                            return Ok(serverProvider.Status);

                        }


                        orderDetailsQurayVmList.Add(orderDetailsQurayVm);
                    }
                    var res = new Result<List<OrderDetailsQurayVm>>
                    {
                        Data = orderDetailsQurayVmList,
                        Status = order.Status,
                        Succeeded = order.Succeeded
                    };
                    return Ok(res);
                }
                return BadRequest(order.Status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Get/{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            // return BadRequest("jjjjjjjjjjjjjjjjjjjjjjjjjj");


            /*                var orderDetailsQurayVm = new  OrderDetailsQurayVm();
            */
            var orderDetailsQurayVmList = new List<OrderDetailsQurayVm>();
            /*   var orderDetailsQurayVm = new OrderDetailsQurayVm();
              orderDetailsQurayVm.product = new List<ProductQueryDto>();
               orderDetailsQurayVm.serverProviderVm = new List<ServerProviderVm>();
               orderDetailsQurayVm.orderDetailsQueryDto = new List<OrderDetailsQueryDto>();
               orderDetailsQurayVm.orderVm = new OrderVm();*/
            var Cart = await ServiceManager.OrderService.Find(c => c.UserId == userId);

            if (Cart.Succeeded)
            {

                foreach (var orderItem in Cart.Data)
                {

                    var orderDetailsQurayVm = new OrderDetailsQurayVm();
                    orderDetailsQurayVm.product = new List<ProductQueryDto>();
                    orderDetailsQurayVm.serverProviderVm = new List<ServerProviderVm>();
                    orderDetailsQurayVm.orderDetailsQueryDto = new List<OrderDetailsQueryDto>();
                    orderDetailsQurayVm.orderVm = new OrderVm
                    {
                        Active = orderItem.Active,
                        CartId = orderItem.CartId,
                        Id = orderItem.Id,
                        OrderId = orderItem.OrderID ??= 0,
                        Quantity = 0,
                        // State = orderItem.State, 
                        State = orderItem.State,
                        Total = orderItem.Total,
                        UserId = userId,
                        ServiceProviderId = orderItem.ServiceProviderId,
                       // Created = orderItem.CreatedAt.ToString(),
                        Created = "2022-03-16T22:53:43.000000Z",
                        paymentStatus = 0,
                        deliveryStatus = 0,


                    };


                    Console.WriteLine($"orderId =====================================   {orderItem.Id}");


                    var OrderDetails = await ServiceManager.OrderDetailsService.Find(o => o.OrderId == orderItem.Id);

                    if (OrderDetails.Succeeded)
                    {
                        foreach (var OderDetailsItem in OrderDetails.Data)
                        {
                            orderDetailsQurayVm.orderDetailsQueryDto.Add(OderDetailsItem);
                            var product = await ServiceManager.ProductService.GetById(OderDetailsItem.ProductId);

                            if (product.Succeeded)
                            {
                                if (OderDetailsItem.Product_variantionId != null)
                                {

                                    var product_variantion = await ServiceManager.Product_variantionService.getByProductId(product.Data.Id);
                                    //  return Ok(product_variantion);

                                    if (product_variantion.Data.Count()!=0)
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


                                orderDetailsQurayVm.product.Add(product.Data);
                            }
                            else
                            {
                                return BadRequest(product.Status);
                            }

                        }

                    }///end cardDetails if

                    var serverProvider = await ServiceManager.ServiceProviderService.GetById(orderItem.ServiceProviderId.Value);
                    if (serverProvider.Succeeded)
                    {
                        orderDetailsQurayVm.serverProviderVm.Add(new ServerProviderVm
                        {
                            serverName = serverProvider.Data.TradeName,
                            serverProviderId = serverProvider.Data.Id
                        });
                    }
                    else
                    {
                        return Ok(serverProvider.Status);

                    }

                    orderDetailsQurayVmList.Add(orderDetailsQurayVm);
                }
                var res = new Result<List<OrderDetailsQurayVm>>
                {
                    Data = orderDetailsQurayVmList,
                    Status = Cart.Status,
                    Succeeded = Cart.Succeeded
                };
                return Ok(res);
            }
            return BadRequest(Cart.Status);




        }


        //[HttpPost("Post")]
        //public async Task<IActionResult> Post([FromBody]  OrderVm entity)
        //{
        //    var temp = entity.orderDetailsDto;
        //    if (entity == null) return BadRequest("null");
        //    /// var cheack=await ServiceManager.OrderService.Find(o=>o.UserId==entity.UserId) ;
        //    var orderDto = new OrderDto
        //    {
        //        Active = false,
        //        CartId = entity.CartId,
        //        //    Id = entity.Id,
        //        OrderID = entity.OrderId,
        //        Quntity = (int)entity.Quantity,
        //        ServiceProviderId = entity.ServiceProviderId,
        //        State = false,

        //        Total = entity.Total,
        //        UserId = entity.UserId,

        //    };
        //    var order = await ServiceManager.OrderService.Add(orderDto);
        //    if (order.Succeeded)
        //    {

        //        bool res = false;
        //        foreach (var item in temp)
        //        {
        //            var orderDetailsDto = new OrderDetailsDto
        //            {

        //                Active = false,
        //                Price = item.Price,
        //                UserId = item.UserId,
        //                Total = item.Total,
        //                State = false,
        //                OrderId = order.Data.Id,
        //                ProductId = item.ProductId,
        //                Quantity = item.Quantity,
        //                CreatedAt=DateTime.Now,

        //                ServiceProviderId = item.ServiceProviderId,
        //                Sku = item.Sku,
        //            };


        //            var orderDetailse = await ServiceManager.OrderDetailsService.Add(orderDetailsDto);


        //            res = orderDetailse.Succeeded;

        //        }
        //        if(entity.CartId != null)
        //        {
        //                var cartDetailse  = await ServiceManager.CartDetailsService.Find(x=>x.CartId==entity.CartId);
        //                if (cartDetailse != null)
        //                    foreach (var item in cartDetailse.Data)
        //                    {
        //                        var removcartDetailse = await ServiceManager.CartDetailsService.Remove(item.Id);
        //                    }

        //        }

        //        if (res)
        //        {
        //            return Ok(order);

        //        }
        //        else
        //        {
        //            order.Succeeded = false;
        //            order.Status.message = "error!! in add order details ";

        //            return BadRequest(order.Status);
        //        }








        //    }
        //    return BadRequest(order.Status);
        //}


        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] OrderVm entity)
        {
            
            var temp = entity.orderDetailsDto;
            if (entity == null) return BadRequest("null");
            /// var cheack=await ServiceManager.OrderService.Find(o=>o.UserId==entity.UserId) ;
            var orderDto = new OrderDto
            {
                Active = false,
                CartId = entity.CartId,
                //    Id = entity.Id,
                OrderID = entity.OrderId,
                Quntity = (int)entity.Quantity,
                ServiceProviderId = entity.ServiceProviderId,
                State = 1,
                CreatedAt = DateTime.Now,
                Total = entity.Total,
                UserId = entity.UserId,

            };
            var order = await ServiceManager.OrderService.Add(orderDto);
            if (order.Succeeded)
            {

                bool res = false;
                foreach (var item in temp)
                {
                    var orderDetailsDto = new OrderDetailsDto
                    {
                        Id = item.Id,
                        Active = false,
                        Price = item.Price,
                        UserId = item.UserId,
                        Total = item.Total,
                        State = false,
                        OrderId = order.Data.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        CreatedAt = DateTime.Now,
                        Product_variantionId = item.Product_variantionId,
                        ServiceProviderId = item.ServiceProviderId,
                        Sku = item.Sku,
                    };


                    var orderDetailse = await ServiceManager.OrderDetailsService.Add(orderDetailsDto);


                    res = orderDetailse.Succeeded;

                }
                if (entity.CartId != null)
                {
                    var cartDetailse = await ServiceManager.CartDetailsService.Find(x => x.CartId == entity.CartId);
                    if (cartDetailse != null)
                        foreach (var item in cartDetailse.Data)
                        {
                            var removcartDetailse = await ServiceManager.CartDetailsService.Remove(item.Id);
                        }

                }

                if (res)
                {
                    return Ok(order);

                }
                else
                {
                    order.Succeeded = false;
                    order.Status.message = "error!! in add order details ";

                    return BadRequest(order.Status);
                }








            }   
            return BadRequest(order.Status);
        }
        [HttpGet("SpIndex/{userId}")]
        public async Task<IActionResult> SpIndex(string userId)
        {
            var m = await IndexDetailssSp(userId);
            return Ok(m);
        }
        [HttpGet("IndexDetails/{userId}")]
        public async Task<ActionResult> IndexDetails(string userId)
        {
            var scx = await OrderDetailsListForSeller(userId);

            return Ok(scx);


        }
        private async Task<List<OrderDetailsDtoViewSELSp>> IndexDetailssSp(string userId)
        {
            var reuser = await ServiceManager.UserService.GetById(userId);
            var ressD = await ServiceManager.ServiceProviderService.Find(x => x.UserId == reuser.Data.Id);
            var cares = new List<OrderDetailsDtoViewSp>();
            var caresmm = new List<OrderDetailsDto>();
            var caresSel = new List<OrderDetailsDtoViewSELSp>();
            var seridd = new List<string>();
            var checksers = "";
            var ress = await ServiceManager.OrderService.Find(x => x.ServiceProviderId == ressD.Data.FirstOrDefault().Id);
            if (ress.Succeeded)
            {
                foreach (var item in ress.Data)
                {
                    // var cartidd = 0;
                    var caresobj = new OrderDetailsDtoViewSp();
                    var caresobjobj = new OrderDetailsDtoViewSELSp();
                    if (checksers != item.UserId)
                    {
                        if (!seridd.Contains(item.UserId))
                        {
                            caresobjobj = await getallcardwithsameserruser((int)item.ServiceProviderId, item.UserId);
                            seridd.Add(item.UserId);
                            caresSel.Add(caresobjobj);
                        }
                    }
                    checksers = item.UserId;



                    // caresobj.Productname=
                }
                return caresSel;
            }
            else
            {
                return caresSel;
            }

        }
        private async Task<List<OrderDetailsDtoViewSEL>> OrderDetailsListForSeller(string userId)
        {
            ///var reuser = await ServiceManager.UserService.GetById(userId);

            var cares = new List<OrderDetailsDtoView>();
            var caresSel = new List<OrderDetailsDtoViewSEL>();
            var seridd = new List<int>();

            var ress = await ServiceManager.OrderService.Find(x => x.UserId == userId);
            if (ress.Succeeded)
            {
                Console.WriteLine("1111111111111111111111111111111111111111111111111111");
                foreach (var item in ress.Data)
                {
                    // var cartidd = 0;
                    var caresobj = new OrderDetailsDtoView();
                    var caresobjobj = new OrderDetailsDtoViewSEL();

                    if (!seridd.Contains((int)item.ServiceProviderId))
                    {
                        caresobjobj = await getallcardwithsameser(item.ServiceProviderId.Value, userId);
                        seridd.Add((int)item.ServiceProviderId);
                        caresSel.Add(caresobjobj);
                    }
                }
                //    checksers = (int)item.ServiceProviderId;


                return caresSel;
            }
            else
            {
                Console.WriteLine("22222222222222222222222222222222222222222222222");

                return caresSel;
            }


        }
        //  [Authorize(Roles = "Admin,User")]
        private async Task<OrderDetailsDtoViewSELSp> getallcardwithsameserruser(int serid, string userid)
        {
            var cares = new List<OrderDetailsDtoViewSp>();
            var caresobjobj = new OrderDetailsDtoViewSELSp();
            var ress = await ServiceManager.OrderDetailsService.Find(x => x.ServiceProviderId == serid && x.UserId == userid);
            var resscart = await ServiceManager.UserService.GetById(userid);
            caresobjobj.Id = resscart.Data.Id;
            caresobjobj.PhoneNumber = resscart.Data.PhoneNumber;
            caresobjobj.FirstName = resscart.Data.FirstName;
            caresobjobj.LastName = resscart.Data.LastName;
            caresobjobj.Email = resscart.Data.Email;
            caresobjobj.Username = resscart.Data.UserName;
            if (ress.Succeeded)
            {
                foreach (var item in ress.Data)
                {
                    var caresobj = new OrderDetailsDtoViewSp();
                    caresobj.Id = item.Id;
                    var prodres = await ServiceManager.ProductService.GetById(item.ProductId);
                    caresobj.ProductId = item.ProductId;
                    caresobj.Id = item.Id;
                    caresobj.Total = item.Total;
                    caresobj.Product_variantionId = item.Product_variantionId;
                    caresobj.Productname = prodres.Data.Name;
                    caresobj.Productimage = prodres.Data.Thumbnail;
                    caresobj.Price = item.Price;
                    caresobj.Quantity = item.Quantity;
                    caresobj.Sku = item.Sku;
                    caresobj.UserId = item.UserId;
                    caresobj.State = item.State;
                    caresobj.Active = item.Active;
                    caresobj.ServiceProviderId = prodres.Data.ServiceProviderId;
                    cares.Add(caresobj);
                }

            }
            caresobjobj.OrderDetails = cares.ToList();

            return caresobjobj;
        }
        private async Task<OrderDetailsDtoViewSEL> getallcardwithsameser(int serid, string userid)
        {
            var cares = new List<OrderDetailsDtoView>();
            var caresobjobj = new OrderDetailsDtoViewSEL();
            var ress = await ServiceManager.OrderDetailsService.Find(x => x.ServiceProviderId == serid && x.UserId == userid);
            var resscart = await ServiceManager.ServiceProviderService.GetById(serid);
            caresobjobj.ServiceProviderId = resscart.Data.Id;
            caresobjobj.ServiceProviderName = resscart.Data.TradeName;
            if (ress.Succeeded)
            {
                foreach (var item in ress.Data)
                {
                    var caresobj = new OrderDetailsDtoView();
                    caresobj.Id = item.Id;
                    var prodres = await ServiceManager.ProductService.GetById(item.ProductId);
                    caresobj.ProductId = item.ProductId;
                    caresobj.Id = item.Id;
                    caresobj.Total = item.Total;
                    caresobj.Product_variantionId = item.Product_variantionId;
                    caresobj.Productname = prodres.Data.Name;
                    caresobj.Productimage = prodres.Data.Thumbnail;
                    caresobj.Price = item.Price;
                    caresobj.Quantity = item.Quantity;
                    caresobj.Sku = item.Sku;
                    caresobj.UserId = item.UserId;
                    caresobj.State = item.State;
                    caresobj.Active = item.Active;
                    caresobj.ServiceProviderId = prodres.Data.ServiceProviderId;
                    cares.Add(caresobj);
                }

            }
            caresobjobj.OrderDetails = cares.ToList();

            return caresobjobj;
        }
        //   [Authorize(Roles = "Admin,ServiceProvider")]
        [HttpGet("ChangeStat/{Id}")]
        public async Task<IActionResult> ChangeStat(int Id)
        {
            var obj = new Result<OrderDetailsQueryDto>();


            OrderDetailsQueryDto data = await GetTable(Id);
            OrderDetailsDto modal = new OrderDetailsDto()
            {
                Id = data.Id,
                Sku = data.Sku,
                Price = data.Price,
                Quantity = data.Quantity,
                Total = data.Total,
                ProductId = data.ProductId,
                Product_variantionId = data.Product_variantionId,
                UserId = data.UserId,
                OrderId = data.OrderId,
                ServiceProviderId = data.ServiceProviderId,
                State = true,
                Active = data.Active,
            };
            if (data.Active == false)
            {
                var result = await ServiceManager.OrderDetailsService.ChangeActive(modal);
                if (result.Succeeded)
                {

                    obj.Status = new Message();
                    obj.Status = result.Status;
                    obj.Succeeded = result.Succeeded;
                    obj.Data = new OrderDetailsQueryDto();
                }
                else
                {

                    obj.Status = new Message();
                    obj.Status = result.Status;
                    obj.Succeeded = result.Succeeded;
                    obj.Data = new OrderDetailsQueryDto();
                }
            }
            return Ok(obj);


        }
        // [Authorize(Roles = "Admin,ServiceProvider")]
        [HttpPost("ChangeState")]
        public async Task<IActionResult> ChangeState(ChangeStateForOrderVM changeStateForOrderVM)
        {
            //var obj = new Result<OrderDetailsQueryDto>();

            //OrderDetailsQueryDto data = await GetTable(changeStateForOrderVM.Id);
            //OrderDetailsDto modal = new OrderDetailsDto()
            //{
            //    Id = data.Id,
            //    Sku = data.Sku,
            //    Price = data.Price,
            //    Quantity = data.Quantity,
            //    Total = data.Total,
            //    ProductId = data.ProductId,
            //    Product_variantionId = data.Product_variantionId,
            //    UserId = data.UserId,
            //    OrderId = data.OrderId,
            //    ServiceProviderId = data.ServiceProviderId,
            //    State = changeStateForOrderVM.State ==1?true:false,
            //    Active = true,
            //};
            //if (data.State == false)
            //{
            //    var result = await ServiceManager.OrderDetailsService.ChangeActive(modal);
            //    if (result.Succeeded)
            //    {
            //        obj.Status = new Message();
            //        obj.Status = result.Status;
            //        obj.Succeeded = result.Succeeded;
            //        obj.Data = new OrderDetailsQueryDto();
            //    }
            //    else
            //    {

            //        obj.Status = new Message();
            //        obj.Status = result.Status;
            //        obj.Succeeded = result.Succeeded;
            //        obj.Data = new OrderDetailsQueryDto();
            //    }
            //}

            var g = new OrderDto();
            g.Id = changeStateForOrderVM.Id;
            g.State = changeStateForOrderVM.State;
            var result = await ServiceManager.OrderService.ChangeActive(g);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return Ok();
          //  return Ok(obj);


        }
          [HttpGet("ordertry")]
        public async Task<ActionResult > ordertry(int Id)
        {
            var g=new OrderDto();   
            g.Id= Id;
            var result = await ServiceManager.OrderService.ChangeActive(g);
            //   OrderDetailsQueryDto cityDto = result.Data;
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return Ok();
        }
        //  [Authorize(Roles = "Admin,User")]
        private async Task<OrderDetailsQueryDto> GetTable(int Id)
        {
            var result = await ServiceManager.OrderDetailsService.GetById(Id);
            OrderDetailsQueryDto cityDto = result.Data;

            return cityDto;
        }

    }
}
