using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tms.Entity.Entities;
using tms.Service.Services.Abstract;

namespace tms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAboutService aboutService;
        public HomeController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
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
	}
}
