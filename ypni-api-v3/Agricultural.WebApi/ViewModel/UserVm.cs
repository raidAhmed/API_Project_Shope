namespace Agricultural.WebApi.ViewModel
{
    public class UserVm
    {
        public string? id { get; set; }
        public string username { get; set; }


        public string firstName { get; set; }


        public string lastName { get; set; }


        public string email { get; set; }


        public string phoneNumber { get; set; }


        public string? image { get; set; }


        public string password { get; set; }
        public string? confeirmPassword { get; set; }


        public byte userType { get; set; }


        public byte state { get; set; }
        public bool status { get; set; }


        public bool active { get; set; }

        public class UserViewModel  
        {
        //    public IFormFile? File { get; set; }
            public string? imageUrl { get; set; }

            public string userVm { get; set; }
        


        }
    }
}
