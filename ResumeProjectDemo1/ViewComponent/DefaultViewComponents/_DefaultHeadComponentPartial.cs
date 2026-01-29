using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemo1.ViewComponent.DefaultViewComponents
{
    // "ViewComponent" kelimesinin sonundaki 't' harfine ve büyük/küçük harfe dikkat edin
    public class _DefaultHeadComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
