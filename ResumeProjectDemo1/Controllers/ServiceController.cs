using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    [Authorize]
    public class ServiceController : BaseController
    {
        private readonly ResumeContext _context;

        public ServiceController(ResumeContext context) : base(context)
        {
            _context = context;
        }

        // 1. Hizmetleri Listeleme (Kart Tasarımı İçin)
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return View(values);
        }

        // 2. Yeni Hizmet Ekleme (Sayfayı Açma)
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        // 3. Yeni Hizmet Ekleme (Kaydetme)
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            // Veritabanına ekle ve kaydet
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        // 4. Hizmet Silme
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value != null)
            {
                _context.Services.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("ServiceList");
        }

        // 5. Hizmet Güncelleme (Verileri Sayfaya Taşıma)
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            {
                return RedirectToAction("ServiceList");
            }
            return View(value);
        }

        // 6. Hizmet Güncelleme (Değişiklikleri Kaydetme)
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            // Entity Framework Update metodu ile tüm modeli güncelliyoruz
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}
