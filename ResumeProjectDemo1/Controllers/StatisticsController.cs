using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Context;

namespace ResumeProjectDemo1.Controllers
{
    [Authorize]
    public class StatisticsController : BaseController
    {
        private readonly ResumeContext _context;
        public StatisticsController(ResumeContext context): base(context)
        {
            _context = context; // EĞER BU SATIRI UNUTURSAN NULL HATASI ALIRSIN!
        }
        public IActionResult Index()
        {
            ViewBag.v1 = _context.Messages.Count();
            ViewBag.v2 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.v4 = _context.Messages.Where(x=>x.MessageId==1).Select(y=>y.NameSurname).FirstOrDefault();

            return View();
        }        
    }
}
