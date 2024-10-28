﻿using Microsoft.AspNetCore.Mvc;
using ThiThucHanh.Models;

namespace ThucHanhWebMVC.Controllers
{
    public class AccessController : Controller
    {
        TestThContext db;

        public AccessController(TestThContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.Users.FirstOrDefault(us => us.Username.Equals(user.Username) && us.Password.Equals(user.Password));
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login");
        }
    }
}