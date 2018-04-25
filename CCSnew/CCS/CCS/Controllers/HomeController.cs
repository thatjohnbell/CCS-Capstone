﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;

        public HomeController(UserManager<User> usrMgr)
        {
            userManager = usrMgr;

        }

        public IActionResult Index()
        {
            return File("~/Index.html", "text/html");
            
        }

        public IActionResult memberMessageList()
        {
            string s = "";
            foreach (User u in userManager.Users.ToList())
            {
                s+= "\"" + u.UserName + "\",";
            }
            s = s.Remove(s.Length-1);
            return View("memberMessageList",s);
        }
    }
}