using Agricultural.Application.DTOs.OrderDetails;

namespace Agricultural.WebApi.ViewModel
{
    public class OrderVm
    {

        public List<OrderDetailsDto> orderDetailsDto { get; set; }
        public int Id { get; set; }
        public string? Sku { get; set; }
       // public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int State { get; set; }
        public bool Active { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int? ServiceProviderId { get; set; }
        public int? CartId { get; set; }
        public string? Created { get; set; }
        public int? paymentStatus { get; set; }
        public int? deliveryStatus { get; set; }
    }
}
