namespace Agricultural.WebApi.ViewModel
{
   
    public class CartCreateVm
    {

    //    public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Total { get; set; }
        public String UserId { get; set; }
        public bool State { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public bool Active { get; set; }
        public int ProductId { get; set; }
        public int ServiceProviderId { get; set; }
        public int? Product_variantionId { get; set; }
        public int CartId { get; set; }
    }
}
