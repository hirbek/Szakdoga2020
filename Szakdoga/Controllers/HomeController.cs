using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdoga.Models;

namespace Szakdolgozat.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext _context;

        public HomeController() => _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {


            return View();
        }
        public ActionResult Event()
        {

            var events = _context.FoNaptar.ToList();
            return View("Event", events);
        }
        public JsonResult GetEvents()
        {

            var events = _context.FoNaptar.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult SaveEvent(MainCalendar e)
        {
            var status = false;
            {
                if (e.EventId > 0)
                {
                    
                    var v = _context.FoNaptar.Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;

                    }
                }
                else
                {
                    _context.FoNaptar.Add(e);
                }

                _context.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult Edit(MainCalendarViewModel Event)
        {
            if (Event.events.EventId == 0)
            {
                _context.FoNaptar.Add(Event.events);
            }
            else
            {
                var letezoEvent = _context.FoNaptar.Single(m => m.EventId == Event.events.EventId);
                letezoEvent.Subject = Event.events.Subject;
                letezoEvent.Description = Event.events.Description;
                letezoEvent.Start = Event.events.Start;
                letezoEvent.End = Event.events.End;
            }
            _context.SaveChanges();
            return RedirectToAction("Calendar");
        }
        public ActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return HttpNotFound();
            }
            var letezoEvent = _context.FoNaptar.Find(Id);
            _context.FoNaptar.Remove(letezoEvent);
            _context.SaveChanges();
            return RedirectToAction("Event");
        }
        public ActionResult EventEdit(int id)
        {

            if (id == 0)
            {
                return HttpNotFound();
            }
            var letezoEvent = _context.FoNaptar.Find(id);
            var vm = new MainCalendarViewModel()
            {
                events = letezoEvent
            };
            return View("EventEdit", vm);
        }


    }
}