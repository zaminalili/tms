using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using tms.Service.Services.Abstract;
using tms.Service.Services.Concrete;

namespace tms.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }

        public async Task<IActionResult> GetProduct(Guid id)
        {
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();
            

            string currentCulture = CultureInfo.CurrentCulture.Name;
            
            ViewBag.CurrentLang = currentCulture;

            var product = await productService.GetProductAsync(id);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory(string categoryname, Guid? categoryId, int currentPage = 1, int pageSize = 24, bool isAscending = false)
        {
            ViewBag.IsHomePage = false;
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();


            string currentCulture = CultureInfo.CurrentCulture.Name;

            ViewBag.CurrentLang = currentCulture;

            var products = await productService.GetProductsByCategoryNameAsync(categoryname, categoryId, currentPage, pageSize, isAscending);

            return View(products);
        }
    }
}
