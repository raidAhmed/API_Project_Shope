

namespace Agricultural.WebApi.ViewModel { 
    public class Image
    {
        public IFormFile File { get; set; }
        public string Imagedetiles { get; set; }
    }
    public class Imagedetiles
    {

        public string Type { get; set; }
        public string serverBrovider { get; set; }
    }

}
