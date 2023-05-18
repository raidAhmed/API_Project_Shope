using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Common
{
    public interface IUploadFileService
    {
        string UploadImageAsBase64(string base64image, string imageName, string fileExtension = ".png");
        bool DeleteImageFile(string fileNameWithPath);
        string UploadFile(IFormFile obj, string FolderName);
        string UploadFileProduct(IFormFile obj, string FolderName,string SubFolderName);
        bool DeleteImageFile(string fileNameWithPath, string folderName);
        bool CopyImageFile(string fileNameWithPath, string folderName, string DestinationfolderName);
    }
}
