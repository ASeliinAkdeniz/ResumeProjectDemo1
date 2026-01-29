using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    // EKSİK OLAN KISIM: ": Controller" eklenmeli
    [Authorize]
    public class AboutController : BaseController
    {
        private readonly ResumeContext _context;
        public AboutController(ResumeContext context): base(context)
        {
            _context = context;
        }

        // Metot isimlerini ve çekilen verileri Skill olarak güncelledim
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }

        public IActionResult AboutSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutSkill(About About)
        {
            _context.Abouts.Add(About);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
            {
                // Eğer veri yoksa listeye geri gönder veya hata verme
                return RedirectToAction("AboutList");
            }
            return View(value); // Buradaki parantez içine 'value' yazdığından emin ol!
        }

        [HttpPost]
        public IActionResult UpdateAbout(About About)
        {
            _context.Abouts.Update(About);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}