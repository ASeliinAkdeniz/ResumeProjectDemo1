using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Models; // Context sınıfının klasör adı (Gerekirse güncelle)
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    [Authorize]
    public class AdminLayoutController : BaseController
    {
        // Veritabanı bağlantısı için readonly (sadece okunur) alan
       
        private readonly ResumeContext _context;

        // Controller çalıştığında context'i enjekte ediyoruz
        public AdminLayoutController(ResumeContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Senin Message sınıfındaki 'IsRead' property'sine göre filtreliyoruz
            // IsRead == false (yani okunmamış) olan mesajların sayısı
            ViewBag.UnreadMsgCount = _context.Messages.Count(x => x.IsRead == false);

            // Dashboard'daki diğer veriler...
            var lastMessages = _context.Messages
                                      .OrderByDescending(x => x.MessageId)
                                      .Take(5)
                                      .ToList();

            // Navbar'da görünecek diğer bilgiler (Opsiyonel)
            var profile = _context.Abouts.FirstOrDefault();
            ViewBag.AdminFullName = profile?.NameSurnname;

            return View(lastMessages);
        }
    }
}