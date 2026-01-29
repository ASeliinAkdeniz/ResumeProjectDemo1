using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Controllers;

[Authorize]
public class DashboardController : BaseController
{
    private readonly ResumeContext _context;
    public DashboardController(ResumeContext context) : base(context)
    { _context = context; } 

public IActionResult Index()
    {
        // 1. Profil Bilgilerini Çek (About tablosu)
        var profile = _context.Abouts.FirstOrDefault();
        ViewBag.AdminFullName = profile?.NameSurnname ?? "Admin";
        ViewBag.AdminTitle = profile?.Title ?? "Yazılımcı";
        ViewBag.AdminImage = profile?.ImageUrl ?? "/img/default-user.png";

        // 2. İstatistikler
        ViewBag.MsgCount = _context.Messages.Count();
        ViewBag.SkillCount = _context.Skills.Count();
        ViewBag.EduCount = _context.Educations.Count();
        ViewBag.ProjectCount = _context.Portfolios.Count();

        // 3. Mesajları Çek
        var lastMessages = _context.Messages
                                  .OrderByDescending(x => x.MessageId)
                                  .Take(5) // Daha dolu görünmesi için 5 mesaj
                                  .ToList();

        return View(lastMessages);
    }
}