namespace Agricultural.WebApi.ViewModel
{
    public class SPAddressVm
    {
        public int Id { get; set; }
        public int DirectorateId { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; } 
        public bool? State { get; set; }
         
    }
}
