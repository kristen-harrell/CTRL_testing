using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing_ctrl_portal.Models;

namespace testing_ctrl_portal.Controllers
{
    public class UserController : Controller
    {
        private readonly CTRL_TestingContext _db;
        public UserController(CTRL_TestingContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(PasswordReset p)
        {
            _db.PasswordResets.Add(p);
            _db.SaveChanges();
            return View("Index");
        }

    }
}
