using eticaret_uygulama.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaret_uygulama.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel gelen)
        {
          
            if (!ModelState.IsValid)
            {
                return View(gelen);
            }

            var result = await _signInManager.PasswordSignInAsync(gelen.UserName, gelen.Password, false, true);


            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(gelen.UserName);

                if (user.EmailConfirmed)
                {
                    return RedirectToAction("Index", "MyAccount");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "E-posta adresiniz doğrulanmamış.");
                    return View(gelen);
                }
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Hesabınız kilitlenmiş.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(gelen);
        }

    }
}
