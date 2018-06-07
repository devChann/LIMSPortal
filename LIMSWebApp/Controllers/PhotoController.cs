using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using LIMSInfrastructure.Identity;

namespace AuthWithPhoto.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly UserManager<ApplicationUser> _userManager;

        public PhotoController(IMemoryCache cache, UserManager<ApplicationUser> usermanager)
        {
            _cache = cache;
            _userManager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var id = _userManager.GetUserId(User);
            byte[] photo = null;
            if (!string.IsNullOrEmpty(id) && !_cache.TryGetValue(id, out photo))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null && user.Photo.Length > 0)
                {
                    photo = user.Photo;
                    _cache.Set(id, photo);
                }
            }
            if (photo != null)
            {
                return File(photo, "image/png");
            } else {
                return File(Url.Content("~/images/blank.png"), "image/png");
            }

        }
    }
}