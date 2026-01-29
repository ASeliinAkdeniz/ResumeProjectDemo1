using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultCategoryComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;
        public _DefaultCategoryComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values =_context.Categories.ToList();
            return View(values);
        }
    }
   
}
