﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

namespace FMCGWebApp.Controllers
{
    public class AdminController : Controller
    {
        private CategoryManager _category = new CategoryManager();
        private WhouseinfoManager _whouseinfo = new WhouseinfoManager();

        public ActionResult SaveCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _category.SaveCategory(category);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }

            return View();
        }

        public ActionResult SaveWhouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveWhouse(W_h_info wHInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _whouseinfo.SaveWhouse(wHInfo);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }

            return View();
        }

    }
}