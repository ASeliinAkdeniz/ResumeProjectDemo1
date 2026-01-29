using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ResumeContext _context;
        public _DefaultPortfolioComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
    {
            var values = _context.Portfolios.ToList();
            return View(values);
    }
}
}
