﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicAPI.Models.ClassiTabelle;
using MusicAPI.Models.DAL;
using System.Data.Entity;

namespace MusicAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
                ViewBag.Title = "Home Page";

            return View();
        }
    }
}
