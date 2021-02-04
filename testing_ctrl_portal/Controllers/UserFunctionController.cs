using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _db.PasswordReset.Add(p);
            _db.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult ShowUsers()
        {
            List<PasswordReset> allUsers = _db.PasswordReset.ToList();
            return View(allUsers);
        }

        [HttpPost]
        public IActionResult SendCode()
        {
            int stringLength = 6;
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                Random random = new Random();
                string num = random.Next(0, 10).ToString();
                char alpha = (char)random.Next('a', 'z'); //if I make the set 'A', 'z' to try to incl. caps and lower, I get special char too
                if (random.Next() % 2 == 0)
                {
                    stringBuilder.Append(num);
                }
                else
                {
                    stringBuilder.Append(alpha);
                }
            }
            ViewBag.ResetCode = stringBuilder.ToString();

            return View("index");
        }
        [HttpPost]
        public IActionResult SaveCode(string email)
        {

            PersistCode entry = new PersistCode();
            entry.Email = email;
            entry.ResetCode = GetCode();
            entry.Expiration = DateTime.Now.AddMinutes(10);


            _db.PersistCode.Add(entry);
            _db.SaveChanges();

            ViewBag.Confirmation = $"your reset code has been sent to {email}";

            return View("index");
        }
        public static string GetCode()
        {
            int stringLength = 6;
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                Random random = new Random();
                string num = random.Next(0, 10).ToString();
                char alpha = (char)random.Next('a', 'z'); //if I make the set 'A', 'z' to try to incl. caps and lower, I get special char too
                if (random.Next() % 2 == 0)
                {
                    stringBuilder.Append(num);
                }
                else
                {
                    stringBuilder.Append(alpha);
                }
            }
           string code = stringBuilder.ToString();

            return code;
        }
        [HttpPost]
        public IActionResult ValidateCode(string code)
        {
            string response = "";

            List<PersistCode> validCode = _db.PersistCode.Where(x => x.ResetCode == code)
                                           .Where(x => x.Expiration > DateTime.Now).ToList();

            if (validCode.Count == 1)
            {
                response = "this code is valid for resetting your password";
            }    

            if (validCode.Count < 1)
            {
                response = "this code is no longer valid.  Please request a new one";

            }


            ViewBag.CodeResponse = $"{response}";


           
            return View("index");
        }
    }
}
