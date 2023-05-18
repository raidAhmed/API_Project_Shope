using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Agricultural.Application.Interfaces.Common;

namespace Agricultural.WebMvc.Controllers.BaseMvc
{
    public class MvcBaseController : Controller
    {
        private IServiceManager _serviceManager { get; set;}

        protected IServiceManager ServiceManager => _serviceManager ??= HttpContext.RequestServices.GetRequiredService<IServiceManager>();
        public string UploadJobImage(IFormFile Image, string folderName)//notic how to make it dynamic function to all controller
        {
            string img = ServiceManager.UploadFileService.UploadFile(Image, folderName);

            return img;


        }  
        public string UploadProImage(IFormFile Image, string folderName,string subfolderName)//notic how to make it dynamic function to all controller
        {
            string img = ServiceManager.UploadFileService.UploadFileProduct(Image, folderName, subfolderName);

            return img;


        }  
        public bool UploadJobImagedelet(string Image, string folderName)//notic how to make it dynamic function to all controller
        {
            bool img = ServiceManager.UploadFileService.DeleteImageFile(Image, folderName);

            return img;


        }
        public bool CopyImageFile(string ImageName, string SourefolderName, string DestinationfolderName)//notic how to make it dynamic function to all controller
        {
            bool img = ServiceManager.UploadFileService.CopyImageFile(ImageName, SourefolderName, DestinationfolderName);

            return img;


        }
    }
    }
