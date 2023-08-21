﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EWT_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "EasyWatchTicketing - Movie Ticket Booking";

            return View();
        }

        public ActionResult Movies()
        {
            ViewBag.Title = "Movies Page";

            return View();
        }
    }
}