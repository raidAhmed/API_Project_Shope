
using Agricultural.Application.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;
using Agricultural.Application.Constants;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Agricultural.Infrastructure.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment _environment;

        public UploadFileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public bool DeleteImageFile(string fileNameWithPath)
        {
            if (File.Exists(fileNameWithPath) == false)
            {
                return false;
            }

            try
            {
                File.Delete(fileNameWithPath);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool DeleteImageFile(string fileNameWithPath, string folderName)
        {
            var ufolder = Path.Combine(_environment.WebRootPath, ProjectConstants.ProjectUploadPath,folderName, fileNameWithPath);

          //  var subFolder = Path.Combine(ufolder, folderName);
          //  var path = Path.Combine(subFolder, fileNameWithPath);
            Console.WriteLine("path=>  " + ufolder);
            if (File.Exists(ufolder) == false)
            {


                Console.WriteLine("the file path not exsit =>  " + ufolder);
                return false;
            }
            File.Delete(ufolder);

            Console.WriteLine("Image deleted successFully");
            return true;


        }
        public bool CopyImageFile(string ImageName, string SourefolderName, string DestinationfolderName)
        {
            var ufolder = Path.Combine(_environment.WebRootPath, SourefolderName);
            var newfolder = Path.Combine(_environment.WebRootPath, DestinationfolderName, ImageName);
            System.IO.File.Copy(ufolder, newfolder);
            return true;
        }
        public string ImageResize(Image img,int Maxwidth,int MaxHeight)
        {
            if(img.Width>Maxwidth ||img.Height>MaxHeight)
            {
                double widthhratio = (double)img.Width / (double)Maxwidth;
                double heighthratio = (double)img.Height / (double)MaxHeight;
                double ratio=Math.Max(widthhratio, heighthratio);
                int newwidth = (int)(img.Width/ratio);
                int newheight = (int)(img.Height/ratio);
                return newheight.ToString() + "," + newwidth.ToString();
            }
            return img.Height.ToString()+","+img.Width.ToString();
        }
        public string UploadFile(IFormFile obj,string FolderName)
        {

            //string path = "";
            //try
            //{
            //    if (obj.Length > 0)
            //    {
            //        path = Path.s("UploadedFiles");
            //        if (!Directory.Exists(path))
            //        {
            //            Directory.CreateDirectory(path);
            //        }
            //        using (var fileStream = new FileStream(Path.Combine(path,FolderName, obj.FileName), FileMode.Create))
            //        {
            //             obj.CopyTo(fileStream);
            //        }
            //        return path;
            //    }
            //    else
            //    {
            //        return path;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("File Copy Failed", ex);
            //}

            string ext = obj.FileName.Split(".").Last();
            // var encode = Encoder.Quality;
            //if (ext == "jpg" || ext == "png")
            //{
            //    if (obj.Length > 3 * 1024 * 1024)
            //    {
            //        //err.Add("over");
            //        return "err";
            //    }
            //}

            string path = Path.Combine(_environment.WebRootPath, ProjectConstants.ProjectUploadPath);

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }
            string subpath = Path.Combine(path, FolderName);

            if (!System.IO.Directory.Exists(subpath))
            {
                System.IO.Directory.CreateDirectory(subpath); //Create directory if it doesn't exist
            }
            if (obj != null)
            {
                Guid guid = Guid.NewGuid();

                string newfileName = guid.ToString();

                string fileextention = Path.GetExtension(obj.FileName);

                string fileName = newfileName + fileextention;
                string uploads = Path.Combine(subpath, fileName);
                using (var image = Image.Load(obj.OpenReadStream()))
                {
                    string newsize = ImageResize(image, 600, 600);
                    string[] sizearray = newsize.Split(",");
                    image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                    image.Save(uploads);
                }
                //   System.IO.FileStream filePath = new FileStream(uploads, FileMode.Create);
                //   obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
                //   filePath.Close();
                return ProjectConstants.ProjectUploadPath + "/"+ FolderName + "/" + fileName;

            }
            //  System.IO.FileStream filePath = new FileStream(path, FileMode.Create);
            // obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
            //string uniqueFileName = null;
            //if (obj != null)
            //{
            //    string uploads = Path.Combine(_environment.WebRootPath, ProjectConstants.ProjectUploadPath, obj.FileName);
            //    System.IO.FileStream filePath = new FileStream(uploads, FileMode.Create);
            //    obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
            //    filePath.Close();
            //    return FileName;
            //}
            return path;
        }      
        public string UploadFileProduct(IFormFile obj,string FolderName, string SubFolderName)
        {
            string ext = obj.FileName.Split(".").Last();

            //if (ext == "jpg" || ext == "png")
            //{
            //    if (obj.Length > 3 * 1024 * 1024)
            //    {
            //        //err.Add("over");
            //        return "err";
            //    }
            //}

            string path = Path.Combine(_environment.WebRootPath, ProjectConstants.ProjectUploadPath);
          
            if (!System.IO.Directory.Exists(path))
                      {
                           System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }
            string subpathh = Path.Combine(path, FolderName);

            if (!System.IO.Directory.Exists(subpathh))
            {
                System.IO.Directory.CreateDirectory( subpathh); //Create directory if it doesn't exist
            }
            string subpath = Path.Combine(subpathh, SubFolderName);
            if (!System.IO.Directory.Exists(subpath))
            {
                System.IO.Directory.CreateDirectory( subpath); //Create directory if it doesn't exist
            }
            if (obj != null)
            {
                Guid guid = Guid.NewGuid();

                string newfileName = guid.ToString();

                string fileextention = Path.GetExtension(obj.FileName);

                string fileName = newfileName + fileextention;
                string uploads = Path.Combine(subpath, fileName);
                using (var image = Image.Load(obj.OpenReadStream()))
                {
                    string newsize = ImageResize(image, 600, 600);
                    string[] sizearray = newsize.Split(",");
                    image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                    image.Save(uploads);
                }
               // System.IO.FileStream filePath = new FileStream(uploads, FileMode.Create);
               //   obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
               // filePath.Close();
                var pathwithnwme = ProjectConstants.ProjectUploadPath + "/" + FolderName + "/" + SubFolderName + "/" + fileName;
                   return pathwithnwme;

            }
            //  System.IO.FileStream filePath = new FileStream(path, FileMode.Create);
            // obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
            //string uniqueFileName = null;
            //if (obj != null)
            //{
            //    string uploads = Path.Combine(_environment.WebRootPath, ProjectConstants.ProjectUploadPath, obj.FileName);
            //    System.IO.FileStream filePath = new FileStream(uploads, FileMode.Create);
            //    obj.CopyTo(System.IO.FileStream.Synchronized(filePath));
            //    filePath.Close();
            //    return FileName;
            //}
            return path;
        }
        public string UploadImageAsBase64(string base64image, string imageName, string fileExtension = ".png")
        {
            if (imageName == null) imageName = string.Empty;

            try
            {
                if (fileExtension == null || fileExtension.Length == 0) fileExtension = ".png";

                var imagename = string.Empty;

                //    if (base64image != null && base64image.Length > 1)
                //    {
                //        string path = Path.Combine(_environment.WebRootPath , ProjectConstants.ProjectUploadPath);

                //        //Check if directory exist
                //        if (!System.IO.Directory.Exists(path))
                //        {
                //            System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                //        }


                //        if (imageName != null && imageName.Length > 4 && File.Exists(Path.Combine(path , imageName)))
                //        {
                //            imagename = imageName;
                //        }
                //        else
                //        {
                //            var f = Path.GetFileNameWithoutExtension(imageName);

                //            imagename = (f != null && f.Length > 10 ? "temp_" : f) + System.DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss") + Guid.NewGuid();
                //        }

                //        var fExtension = Path.GetExtension(imagename);

                //        if (fExtension == null || fExtension.Length == 0 || fExtension.Length > 5)
                //        {
                //            var fex = Path.GetFileNameWithoutExtension(imagename);

                //            //if (!fileImageExtension.Contains(fExtension.ToLower()))
                //            //{
                //            //    imagename += ".png";
                //            //}else
                //            //{
                //            //    imagename += fileExtension;

                //            //}

                //            imagename = fex + fileExtension;// ".png";

                //        }

                //        //set the image path
                //        string imgPath = Path.Combine(path, imagename);


                //        byte[] imageBytes = Convert.FromBase64String(base64image);

                //        File.WriteAllBytes(imgPath, imageBytes);

                //        return Path.Combine(ProjectConstants.ProjectUploadPath,imagename);
                //    }
                //}
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
