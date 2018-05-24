using System;
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
        private WhouseinfoManager _whouseinfo = new WhouseinfoManager();
        private EmployeeManager _employee = new EmployeeManager();
        private CategoryManager _category = new CategoryManager();
        private ShopInfoManager _shopInfo = new ShopInfoManager();


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

        public ActionResult SaveShopInfo()
        {
            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.ListOfEmployees = _shopInfo.GetAllEmployees();
            return View();
        }

        [HttpPost]
        public ActionResult SaveShopInfo(ShopInfo shopInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _shopInfo.SaveShopInfo(shopInfo);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }
            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.ListOfEmployees = _shopInfo.GetAllEmployees();
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

    }
}