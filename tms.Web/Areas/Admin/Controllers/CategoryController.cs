using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tms.Entity.DTOs.CategoryDTOs;
using tms.Service.Services.Abstract;

namespace tms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            return View(categories);
        }

        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto category)
        {
            await categoryService.CreateCategoryAsync(category);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await categoryService.GetAllDeletedCategoriesAsync();

            return View(categories);
        }

        
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("DeletedCategory");
        }

        public async Task<IActionResult> RestoreCategory(Guid id)
        {
            await categoryService.ChangeStatusCategoryAsync(id);

            return RedirectToAction("DeletedCategory");
        }

        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryAddDto category)
        {
            await categoryService.UpdateCategoryAsync(category);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            await categoryService.SafeDeleteCategoryAsync(id);

            return RedirectToAction("Index");
        }
    }
}
