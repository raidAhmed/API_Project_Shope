namespace Agricultural.WebApi.ViewModel
{
    public class ServerProviderVmodel  
    {
        public int id { get; set; }
        public string tradeName { get; set; }
        public string? logo { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string type { get; set; }
        public int natId { get; set; }
        public string description { get; set; }
        public int serviceTypeId { get; set; }
        // from user
        public string? userId { get; set; }
        // from activity type
        public int? activityTypeId { get; set; }
        public int viewPlace { get; set; }
    }
    public class ServerProviderViewModel
    {     
        //public IFormFile? File { get; set; }

        
        public string? imageUrl { get; set; }
        public string serverProviderVm { get; set; }


    }
}
