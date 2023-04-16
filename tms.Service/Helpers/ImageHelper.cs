using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using tms.Entity.Entities;

namespace tms.Service.Helpers
{
    public class ImageHelper: IImageHelper
    {
        private readonly string wwwroot;

        private readonly IHostingEnvironment env;
        private const string folderName = "images";

        public ImageHelper(IHostingEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }

        public async Task<Image> UploadAsync(IFormFile file)
        {
            if (!Directory.Exists($"{wwwroot}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{folderName}");
            };

            var path = Path.Combine($"{wwwroot}/{folderName}", file.FileName);

            //var time = DateTime.Now;

            string FullName = $"{folderName}/{file.FileName}";
            string fileExtension = Path.GetExtension(file.FileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(stream);

            await stream.FlushAsync();

            Image image = new Image()
            {
                FileName = FullName,
                FileType = file.ContentType
            };

            return image;
        }
    }
}
