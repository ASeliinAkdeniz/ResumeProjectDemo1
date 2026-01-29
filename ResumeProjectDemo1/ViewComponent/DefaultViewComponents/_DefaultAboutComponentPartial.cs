using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Models;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;
        public _DefaultAboutComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var viewModel = new AboutEducationViewModel
            {
                Abouts = _context.Abouts.ToList(),
                Educations = _context.Educations.ToList()
            };

            return View(viewModel);
        }
    }
}
