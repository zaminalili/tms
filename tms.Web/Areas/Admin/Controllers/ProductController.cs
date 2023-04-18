using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tms.Entity.DTOs.PriceDtos;
using tms.Entity.DTOs.ProductDtos;
using tms.Entity.Entities;
using tms.Service.Helpers;
using tms.Service.Services.Abstract;

namespace tms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IImageHelper imageHelper;
        private readonly IImageService imageService;
        public ProductController(IProductService productService, ICategoryService categoryService, IImageHelper imageHelper, IImageService imageService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.imageHelper = imageHelper;
            this.imageService = imageService;

        }
        public async Task<IActionResult> Index()
        {
           var products = await productService.GetAllProductsAsync();

            return View(products);
        }

        public async Task<IActionResult> AddProduct() 
        {
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductAddDto model) 
        { 
            
            var image = await imageHelper.UploadAsync(model.ImageFile);

            var imageId = await imageService.AddImageAsync(image);

            await productService.CreateProductAsync(model, imageId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProduct(Guid id)
        {
            var product = await productService.GetProductByIdAsync(id);

			ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

			return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductAddDto model)
        {
            Guid imageId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            if(model.ImageFile != null)
            {
                var image = await imageHelper.UploadAsync(model.ImageFile);

                imageId = await imageService.AddImageAsync(image);
            }
                

            await productService.UpdateProductAsync(model, imageId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await productService.SafeDeleteProductAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletedProduct()
        {
            var products = await productService.GetAllDeletedProductsAsync();

            return View(products);
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await productService.DeleteProductAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RestoreProduct(Guid id)
        {
            await productService.ChangeStatusProductAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductPrices(int minValue = 0, int? maxValue = null, Guid? categoryId = null)
        {

            var product = await productService.GetProductPricesAsync(minValue, maxValue, categoryId);
            ViewBag.Categories = await categoryService.GetAllCategoriesAsync();

            ViewBag.MinValue = minValue;
            ViewBag.MaxValue = maxValue != null ? maxValue : 0;
            ViewBag.CategoryId = categoryId;

            ViewBag.IsPriceViewActive = await productService.GetPriceViewStatus();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrice(int Unit, float Type, float Variation, Guid CategoryId)
        {

            await productService.UpdateProductPriceAsync(Unit, Type, Variation, CategoryId);

            return RedirectToAction("ProductPrices");
        }

        public async Task<IActionResult> ChangePriceViewStatus()
        {
            await productService.ChangePriceViewAsync();

            return RedirectToAction("ProductPrices");
        }
    }
}
