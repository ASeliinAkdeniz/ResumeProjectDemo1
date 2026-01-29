using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultSkillComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;
        public _DefaultSkillComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
    }
}
