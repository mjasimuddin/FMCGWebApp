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
        private EmployeeManager _employee = new EmployeeManager();
        private CategoryManager _category = new CategoryManager();

        public ActionResult AddEmployee()
        {
            ViewBag.gender = _employee.GetGenderList();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int message = _employee.AddEmployee(employee);
                    if (message > 0)
                    {
                        ViewBag.ShowMsg = "Employee Information Saved Successfully!";
                    }
                    else
                    {
                        ViewBag.ShowMsg = "Sorry! Data Not Saved! Please Try Again";
                    }
                }
                catch (Exception exception)
                {

                    ViewBag.ShowMsg = exception.Message;
                }
            }
            ViewBag.gender = _employee.GetGenderList();
            return View();
        }
        public JsonResult IsEmailExists(string email)
        {
            bool isCodeExists = _employee.IsEmailExists(email);

            if (isCodeExists)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }

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

    }
}