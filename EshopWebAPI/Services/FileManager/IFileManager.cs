namespace EshopWebAPI.Services.FileManager
{
    public interface IFileManager
    {
        string SaveFile(IFormFile file, string savePath); 
    }
}
