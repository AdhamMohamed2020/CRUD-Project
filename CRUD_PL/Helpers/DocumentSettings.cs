using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CRUD_PL.Helpers
{
    public static class DocumentSettings
    {

        public static async Task<string> UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            if (file == null)
                return null;


            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);

           await file.CopyToAsync(fs);

            return fileName;

        }


        public static void DeleteFile(string FileName, string FolderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            string filePath = Path.Combine(folderPath, FileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
