using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tms.Service.Services.Abstract;

namespace tms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
           var products = await productService.GetAllProductsAsync();

            return View(products);
        }
    }
}
