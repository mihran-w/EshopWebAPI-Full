namespace EshopWebAPI.Services.FileManager
{
    public class FileManagerService : IFileManager
    {
        public string SaveFile(IFormFile file, string savePath)
        {
            if (file == null)
                throw new Exception("مقدار ورودی فایل خالی است");

            var filename = $"{Guid.NewGuid()}{file.FileName}";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/","\\"));

            if(!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, filename);
            using var fs = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(fs);

            return filename;
        }
    }
}
