﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_PassCenter.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}