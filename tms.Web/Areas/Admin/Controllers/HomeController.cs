using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tms.Entity.DTOs.BrendDtos;
using tms.Entity.DTOs.OfferDtos;
using tms.Entity.Entities;
using tms.Service.Helpers;
using tms.Service.Services.Abstract;
using tms.Service.Services.Concrete;

namespace tms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly IBrendService brendService;
        private readonly IImageHelper imageHelper;
        private readonly IImageService ımageService;
        private readonly IOfferService offerService;
		public HomeController(IAboutService aboutService, IBrendService brendService, IImageHelper imageHelper, IImageService ımageService, IOfferService offerService)
        {
            this.aboutService = aboutService;
            this.brendService = brendService;
            this.imageHelper = imageHelper;
            this.ımageService = ımageService;
            this.offerService = offerService;

		}

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAbout()
        {
            var abouts = await aboutService.GetAboutsAsync();
            return View(abouts);
        }

        public async Task<IActionResult> UpdateAbout(Guid id)
        {
            var about = await aboutService.GetAboutAsync(id);

            return View(about);
        }

        [HttpPost]
		public async Task<IActionResult> UpdateAbout(About about)
		{
			await aboutService.UpdateAboutAsync(about);

			return RedirectToAction("GetAbout", "Home");
		}

        public async Task<IActionResult> GetBrends()
        {
            var brends = await brendService.GetAllBrendsAsync();
            return View(brends);
        }

        public IActionResult AddBrend()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> AddBrend(BrendDto model)
		{
			var image = await imageHelper.UploadAsync(model.ImageFile);

            var imageId = await ımageService.AddImageAsync(image);

			var Brend = new Brend
            {
                Name = model.Name,
                ImageId = imageId,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
            };

            await brendService.AddBrendAsync(Brend);

			return RedirectToAction("GetBrends");
		}

        public async Task<IActionResult> DeleteBrend(Guid id)
        {
            await brendService.DeleteBrendAsync(id);

            return RedirectToAction("GetBrends");
        }


        public async Task<IActionResult> GetOffer()
        {
            var offers = await offerService.GetAllOfferAsync();

            return View(offers);
        }

        public IActionResult AddOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer(OfferDto model)
        {
            var image = await imageHelper.UploadAsync(model.ImageFile);

            var imageId = await ımageService.AddImageAsync(image);

            var offer = new Offer
            {
                Title_AZ = model.Title_AZ,
                Title_EN = model.Title_EN,
                Title_RU = model.Title_RU,
                Description_AZ = model.Description_AZ,
                Description_EN = model.Description_EN,
                Description_RU = model.Description_RU,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                ImageId = imageId,
            };

            await offerService.AddOfferAsync(offer);

            return RedirectToAction("GetOffer");
        }

        public async Task<IActionResult> DeleteOffer(Guid id)
        {
            await offerService.DeleteOfferAsync(id);
            return RedirectToAction("GetOffer");
        }

    }
}
