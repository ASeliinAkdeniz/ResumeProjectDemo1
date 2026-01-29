using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    [Authorize]
    public class EducationController : BaseController
    {
        private readonly ResumeContext _context;
        

        public EducationController(ResumeContext context) : base(context)
        {
            _context = context;
        }

        // Eğitim Listesi
        public IActionResult EducationList()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        // Yeni Eğitim Ekleme (Sayfayı Açma)
        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        // Yeni Eğitim Ekleme (Kaydetme)
        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        // Eğitim Silme
        public IActionResult DeleteEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value != null)
            {
                _context.Educations.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("EducationList");
        }

        // Eğitim Güncelleme (Sayfayı Açma)
        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null)
            {
                return RedirectToAction("EducationList");
            }
            return View(value);
        }

        // Eğitim Güncelleme (Kaydetme)
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}