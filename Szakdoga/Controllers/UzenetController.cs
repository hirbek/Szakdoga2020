using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdoga.Models;

namespace Szakdoga.Controllers
{
    public class UzenetController : Controller
    {
        // GET: Uzenet
        readonly ApplicationDbContext _context;
        public UzenetController() => _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var message = _context.Messages.ToList().OrderByDescending(f => f.Id);
            return View(message);
        }
        public ActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Mentes(Message message)
        {
            if (!ModelState.IsValid)
            {
                var vm = new MessageModel
                {
                    Message = message
                };
                return View("New", vm);
            }

            if (message.Id == null || message.Id == 0)
            {
                message.Lattamozott = false;
                _context.Messages.Add(message);
            }
            _context.SaveChanges();
            return RedirectToAction("Calendar", "Home");
        }
    }
}