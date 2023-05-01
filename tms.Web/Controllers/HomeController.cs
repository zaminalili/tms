using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;
using tms.Service.Services.Abstract;
using tms.Web.Models;

namespace tms.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IStringLocalizer<HomeController> localizer;
        private readonly IAboutService aboutService;
        private readonly IBrendService brendService;
        private readonly IOfferService offerService;

		public HomeController(ICategoryService categoryService, IProductService productService, IHttpContextAccessor httpContextAccessor, IStringLocalizer<HomeController> localizer, IAboutService aboutService, IBrendService brendService, IOfferService offerService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
			this.httpContextAccessor = httpContextAccessor;
			this.localizer = localizer;
            this.aboutService = aboutService;
            this.brendService = brendService;
            this.offerService = offerService;
		}

        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 24, bool isAscending = false)
        {
            ViewBag.IsHomePage = true;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

			string currentCulture = CultureInfo.CurrentCulture.Name;

            ViewBag.CurrentLang = currentCulture;

			var products = await productService.GetProductsByPagingAsync(categoryId, currentPage, pageSize, isAscending);

            return View(products);
        }

        public async Task<IActionResult> Search(string keyword, Guid? categoryId, int currentPage = 1, int pageSize = 24, bool isAscending = false)
        {
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            var products = await productService.SearchAsync(keyword, categoryId, currentPage, pageSize, isAscending);

            return View(products);
        }

        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
             httpContextAccessor.HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> GetAbout()
        {
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            string currentCulture = CultureInfo.CurrentCulture.Name;

            ViewBag.CurrentLang = currentCulture;

            var abouts = await aboutService.GetAboutsAsync();


            return View(abouts);
        }

		public async Task<IActionResult> GetBrends()
		{
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            string currentCulture = CultureInfo.CurrentCulture.Name;

            ViewBag.CurrentLang = currentCulture;

			var brends = await brendService.GetAllBrendsAsync();

			return View(brends);
		}

		public async Task<IActionResult> GetOffer()
		{
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            string currentCulture = CultureInfo.CurrentCulture.Name;

            ViewBag.CurrentLang = currentCulture;

            var offers = await offerService.GetAllOfferAsync();

			return View(offers);
		}
	}
}