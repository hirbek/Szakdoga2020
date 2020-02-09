using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdoga.Models;

namespace Szakdoga.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Message
        readonly ApplicationDbContext _context;
        public NotificationController() => _context = new ApplicationDbContext();
        public ActionResult Messages()
        {
            var lattamazott = _context.Messages.Where(u => u.Lattamozott == false).Count();
            return Content(lattamazott.ToString());
        }
    }
}