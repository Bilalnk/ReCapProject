#region info

// Bilal Karataş20220329

#endregion

using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Upload(IFormFile formFile, string rootPath)
        {
            if (formFile.Length <= 0)
            {
                return null;
            }

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            string extension = Path.GetExtension(formFile.FileName);
            string guid = Guid.NewGuid().ToString();

            string filePath = guid + extension;

            using (FileStream fileStream = File.Create(rootPath + filePath))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }

            ;
        }

        public string Update(IFormFile formFile, string filePath, string rootPath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Upload(formFile, rootPath);
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}