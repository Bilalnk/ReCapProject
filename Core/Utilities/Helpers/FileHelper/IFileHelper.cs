#region info

// Bilal Karataş20220329

#endregion

using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile formFile, string rootPath);
        string Update(IFormFile formFile, string filePath, string rootPath);
        void Delete(string filePath);
    }
}