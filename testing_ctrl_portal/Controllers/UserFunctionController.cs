using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing_ctrl_portal.Models;

namespace testing_ctrl_portal.Controllers
{
    public class UserFunctionController : Controller
    {
        private readonly CTRL_TestingContext _db;
        public UserFunctionController(CTRL_TestingContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUsername(PasswordReset p)
        {
            _db.PasswordResets.Add(p);
            _db.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult ShowUsers()
        {
            List<PasswordReset> allUsers = _db.PasswordResets.ToList();
            return View(allUsers);
        }

    }
}
