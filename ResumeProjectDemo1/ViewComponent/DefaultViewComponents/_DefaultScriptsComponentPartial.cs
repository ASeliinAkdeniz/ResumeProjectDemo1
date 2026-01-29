using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    public class _DefaultScriptsComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
