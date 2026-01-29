using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultExperienceComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
