
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.WebApi.Controllers.BaseApi;
using Microsoft.AspNetCore.Mvc;

namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainClassificationController : BaseApiController
    {
        private readonly IWebHostEnvironment _env;
        public const string ProjectUploadPath = "Upload";

        public MainClassificationController(IWebHostEnvironment environment)
        {
            _env = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await ServiceManager.MainClassificationService.GetAll();

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        // POST: api/ActivityType/GetDt

        [HttpPost("GetDt")]
        public async Task<IActionResult> GetDt([FromBody] DtRequest dtRequest)
        {
            var result = await ServiceManager.MainClassificationService.GetAll(dtRequest);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        // GET ActivityType/GetDDL

        [HttpGet("GetDDL")]
        public async Task<IActionResult> GetDDL()
        {
            var result = await ServiceManager.MainClassificationService.GetDDL();

            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }

        // GET api/ActivityType/5

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await ServiceManager.MainClassificationService.GetById(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        //private async Task <string> UploadFileAsBase64(IFormFile Image, string SubFolder)
        //{
        //    List<string> imageName = new List<string>();
        //    if (Image == null)
        //    {
        //        return "Erorr: Can't Upload File";
        //    }

        //    try
        //    {
        //        string ext = Image.FileName.Split(".").Last();


        //        if (ext == "jpg" || ext == "png")
        //        {



        //            if (Image.Length > 3 * 1024 * 1024)
        //            {
        //                return "over";
        //            }
        //            string uniqueFileName = null;

        //            string uploadsFolder = Path.Combine(_env.WebRootPath, ProjectUploadPath);
        //            var subFolder = Path.Combine(uploadsFolder, SubFolder);


        //            if (!System.IO.Directory.Exists(uploadsFolder))
        //            {
        //                System.IO.Directory.CreateDirectory(uploadsFolder);

        //            }

        //            if (!System.IO.Directory.Exists(subFolder))
        //            {
        //                System.IO.Directory.CreateDirectory(subFolder);
        //            }
        //            while (true)
        //            {




        //                uniqueFileName = Guid.NewGuid().ToString() + "." + Image.FileName.Split(".").Last();

        //                if (!System.IO.File.Exists(subFolder))
        //                {


        //                    break;
        //                }
        //                if (!System.IO.File.Exists(Path.Combine(subFolder, uniqueFileName)))
        //                {


        //                    break;
        //                }


        //            }
        //            string filePath = Path.Combine(subFolder, uniqueFileName);
        //            using (FileStream str = new FileStream(filePath, FileMode.Create))
        //            {
        //               Image.CopyTo(str);
        //            }



        //            return uniqueFileName;


        //        }
        //        else
        //        {

        //            Console.WriteLine($"the image exten condition false ==> {ext}");
        //            return "NotImage";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string uploadsFolder = Path.Combine(_env.WebRootPath, ProjectUploadPath);
        //        return "Erro Occured" + uploadsFolder;
        //    }


        //}
        //// POST api/ActivityType

        [HttpPost("AddMainClassification")]
        public async Task<IActionResult> AddMainClassification([FromForm] MainClassificationDto entity)
        {
            Console.WriteLine($"wwwwwwww fromApsssssssssssssssss" );
            Console.WriteLine($"wwwwwwww fromApi    {entity.MainClassificationName} " );
            var message = new Message
            {
                message="null data",
                code=123
            };
            // return BadRequest(message);

            if (entity == null) return BadRequest(message);


            Console.WriteLine($"ImageUrl {entity.ImageUrl }  ==========FileName {entity.File.FileName}");
            var result = await ServiceManager.MainClassificationService.Add(entity);


            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] MainClassificationDto entity)
        {

            if (entity == null) return BadRequest("null");


            var result = await ServiceManager.MainClassificationService.Update(entity);


            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }


        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await ServiceManager.MainClassificationService.Remove(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Status);
            }
        }
    }
}
