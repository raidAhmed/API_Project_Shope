using System.ComponentModel.DataAnnotations;

namespace Agricultural.WebApi.ViewModel
{
    public class changepasswordVm 
    {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfeirmPassword { get; set; }


    }
}
