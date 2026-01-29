using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Context;
using ResumeProjectDemo1.Entities;
using System;
using System.Linq;

namespace ResumeProjectDemo1.Controllers
{
    // Controller adın tekil olduğu için yönlendirmeyi sağlama alıyoruz
    [Authorize]
    public class MessageController : BaseController
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context) : base(context)
        {
            _context = context;
        }

        // Adres: /Message/MessageList
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            // Klasörün adı "Message" olduğu için yolu net belirtelim (Garanti olsun)
            return View("~/Views/Message/MessageList.cshtml", values);
        }

        // MessageController.cs içindeki metotlar:

        public IActionResult Details(int id) // Buradaki 'id' ismi asp-route-id ile eşleşir
        {
            var message = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (message == null) return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }
            return View("~/Views/Message/Details.cshtml", message);
        }

        public IActionResult Delete(int id)
        {
            var value = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("MessageList");
        }
    }
}