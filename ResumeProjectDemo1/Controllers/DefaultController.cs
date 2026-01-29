using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;

namespace ResumeProjectDemo1.Controllers
{
    public class DefaultController : Controller
    {
        
        private readonly ResumeContext _context;
        public DefaultController(ResumeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Arka plan resimleri (Feature Listesi)
            var features = _context.Features.ToList();

            // Senin About sınıfından tekil veriyi çekiyoruz
            var about = _context.Abouts.FirstOrDefault();

            if (about != null)
            {
                ViewBag.AboutName = about.NameSurnname; // Çift 'n'
                ViewBag.AboutImage = about.ImageUrl;
                ViewBag.AboutTitle = about.Title;
            }

            return View(features);
        }
        [HttpPost]
        public IActionResult SendMessage(Message m)
        {
            m.SendDate = DateTime.Now;
            m.IsRead = false;
            _context.Messages.Add(m);
            _context.SaveChanges();

            // Bu satır sayfayı sıfırdan yüklediği için tüm kutular bomboş gelir.
            return Redirect("/Default/Index#contact");
        }
    }
}
