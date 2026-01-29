using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
