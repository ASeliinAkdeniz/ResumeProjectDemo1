using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    // EKSİK OLAN KISIM: ": Controller" eklenmeli
    [Authorize]
    public class SkillController : BaseController
    {
        private readonly ResumeContext _context;
        public SkillController(ResumeContext context) : base(context)
        {
            _context = context;
        }

        // Metot isimlerini ve çekilen verileri Skill olarak güncelledim
        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            if (value != null)
            {
                _context.Skills.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}