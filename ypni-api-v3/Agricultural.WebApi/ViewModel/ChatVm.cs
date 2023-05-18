namespace Agricultural.WebApi.ViewModel
{
    public class ChatVm
    {
        public int id { get; set; }
        public string topic { get; set; }
        public string? image { get; set; }
        public string senderId { get; set; }
        public string reciverId { get; set; }
        public bool requestState { get; set; }
        public int serviceType { get; set; }
        public bool active { get; set; }

        public class ChatModel  
        {
             // public IFormFile? File { get; set; }

            public string? imageUrl { get; set; }
            public string chatVm { get; set; } 
        


        }
    }
}
