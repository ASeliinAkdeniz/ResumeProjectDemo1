using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultFeatureComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;
        public _DefaultFeatureComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            // Veri tabanındaki tüm (veya ilk 3) fotoğraf kaydını listele
            var values = _context.Features.Take(3).ToList();
            return View(values);
        }
    }
    
    }

