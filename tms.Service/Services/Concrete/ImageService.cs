using Microsoft.AspNetCore.Http;
using tms.Data.UnitOfWorks.Abstract;
using tms.Entity.Entities;
using tms.Service.Extensions;
using tms.Service.Helpers;
using tms.Service.Services.Abstract;

namespace tms.Service.Services.Concrete
{
    public class ImageService: IImageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string userEmail;
        public ImageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.userEmail = httpContextAccessor.HttpContext.User.GetLoggidInUserEmail();
        }

        public async Task<Guid> AddImageAsync(Image image)
        {
            var img = new Image
            {
                Id = new Guid(),
                FileName = image.FileName,
                FileType = image.FileType,
                CreatedBy = userEmail
            };

            await unitOfWork.GetRepository<Image>().AddAsync(img);
            await unitOfWork.SaveAsync();

            return img.Id;
        }
    }
}
