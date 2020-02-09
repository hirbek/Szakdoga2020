using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdoga.Models;

namespace Szakdoga.Controllers
{
    public class IntezoController : Controller
    {
        // GET: MessageShow
        readonly ApplicationDbContext _context;
        public IntezoController() => _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var messages = _context.Messages.ToList().OrderByDescending(f => f.Id);
            return View(messages);
        }
        public ActionResult Torles(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null) return HttpNotFound();
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}