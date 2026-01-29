using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResumeProjectDemo1.Context;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    // DİKKAT: Bu sınıf direkt Controller'dan türüyor
    public class BaseController : Controller
    {
        protected readonly ResumeContext _context;

        public BaseController(ResumeContext context)
        {
            _context = context;
        }

        // OnActionExecuting: Sayfa yüklenmeden hemen önce devreye girer
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Mesaj tablandaki IsRead alanına göre okunmamışları sayıyoruz
            ViewBag.UnreadMsgCount = _context.Messages.Count(x => x.IsRead == false);

            // İstersen Navbar'daki ismi de buradan tek seferde gönderebilirsin
            var admin = _context.Abouts.Select(x => x.NameSurnname).FirstOrDefault();
            ViewBag.AdminName = admin ?? "Aslı Selin Akdeniz";

            base.OnActionExecuting(context);
        }
    }
}