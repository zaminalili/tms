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

		public HomeController(ICategoryService categoryService, IProductService productService, IHttpContextAccessor httpContextAccessor, IStringLocalizer<HomeController> localizer)
        {
            this.categoryService = categoryService;
            this.productService = productService;
			this.httpContextAccessor = httpContextAccessor;
			this.localizer = localizer;
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
    }
}