using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Entities;
using ResumeProjectDemo1.Context;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ResumeProjectDemo1.Controllers
{
    // Bu sayfanın herkese açık olması şart, yoksa giriş kapısı kilitli kalır
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ResumeContext _context;

        public LoginController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Arka plan resimlerini çekiyoruz
            ViewBag.BackgroundImages = _context.Features.Select(x => x.ImageUrl).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            // Kullanıcıyı veritabanında arıyoruz
            var datavalue = _context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Oturumu başlatıyoruz (Program.cs ile uyumlu)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                // DİKKAT: Artık AdminLayout'a değil, yeni Dashboard'a yönlendiriyoruz!
                return RedirectToAction("Index", "Dashboard");
            }

            // Hatalı girişte resimleri tekrar gönderiyoruz ki arka plan boş kalmasın
            ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre!";
            ViewBag.BackgroundImages = _context.Features.Select(x => x.ImageUrl).ToList();
            return View();
        }

        // Çıkış yapınca login ekranına geri döner
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}