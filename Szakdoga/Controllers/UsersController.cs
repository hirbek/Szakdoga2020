using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Szakdoga.Models;

namespace Szakdoga.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        readonly ApplicationDbContext _context;

        public UsersController() => _context = new ApplicationDbContext();
        [Authorize(Roles = RoleNevek.Admin)]
        public ActionResult UserIndex()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      TeljesNev = user.TeljesNev,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      UserId = p.UserId,
                                      TeljesNev = p.TeljesNev,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });


            return View(usersWithRoles);
        }
        public ActionResult Edit(ApplicationUser user)
        {
            if (user.Id == null)
            {
                _context.Users.Add(user);
            }
            else
            {
                var letezoUser = _context.Users.Single(u => u.Id == user.Id);
                letezoUser.TeljesNev = user.TeljesNev;
                letezoUser.Email = user.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("UserIndex");
        }
        public ActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            var letezouser = _context.Users.Find(Id);
            _context.Users.Remove(letezouser);
            _context.SaveChanges();
            return RedirectToAction("UserIndex");
        }
        
        public ActionResult UserEdit(string id)
        {

          

            if (id == null)
            {
                return HttpNotFound();
            }
            var letezoUser = _context.Users.Find(id);
            var vm = new UserViewModel()
            {
                user = letezoUser
            };
            return View("UserEdit", vm);
        }

    }
}