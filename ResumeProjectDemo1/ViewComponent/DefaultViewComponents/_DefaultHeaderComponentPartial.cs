using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents 
{
    public class _DefaultHeaderComponentPartial: Microsoft.AspNetCore.Mvc.ViewComponent
    {
    public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
