﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errors
        public ActionResult NotFound()
        {
            return View();
        }
    }
}