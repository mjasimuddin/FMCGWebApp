using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.ViewModels;

namespace FMCGWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private AccountManager _account = new AccountManager();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                ;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(LoginInfo login)
        {
            try
            {
                List<LoginInfo> status = _account.AdminLogin(login);
                if (status.Count != 0)
                {
                    if (status.Count() > 0)
                    {
                        var name = status[0].EmployeeName;
                        Session["Admin"] = "Admin";
                        Session["User1"] = name;
                        Session["user"] = status[0].Id;
                        Session["status"] = true;
                        Session["userTypeId"] = status[0].UserTypeId;
                        if (status[0].UserTypeId == 1)
                        {
                            return RedirectToAction("../Admin/Index");

                        }

                    }

                }
                else
                {
                    ViewBag.Msg = "User name or passwoer mismatch!";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.Message;
            }
            return View();
        }

        public ActionResult AssistantLogin()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                ;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AssistantLogin(LoginInfo login)
        {
            try
            {
                List<LoginInfo> status = _account.AssistantLogin(login);
                if (status.Count != 0)
                {
                    if (status.Count() > 0)
                    {
                        var name = status[0].EmployeeName;
                        Session["Admin"] = "Admin";
                        Session["User1"] = name;
                        Session["user"] = status[0].Id;
                        Session["status"] = true;
                        if (status[0].UserTypeId == 2)
                        {
                            return RedirectToAction("../OfficeAssistant/Index");

                        }

                    }

                }
                else
                {
                    ViewBag.Msg = "User name or passwoer mismatch!";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.Message;
            }
            return View();
        }

        public ActionResult WhInchargeLogin()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                ;
            }
            return View();
        }

        [HttpPost]
        public ActionResult WhInchargeLogin(LoginInfo login)
        {
            try
            {
                List<LoginInfo> status = _account.WhInchargeLogin(login);
                if (status.Count != 0)
                {
                    if (status.Count() > 0)
                    {
                        var name = status[0].EmployeeName;
                        Session["Admin"] = "Admin";
                        Session["User1"] = name;
                        Session["user"] = status[0].Id;
                        Session["status"] = true;
                        if (status[0].UserTypeId == 3)
                        {
                            return RedirectToAction("../WhIncharge/Index");

                        }

                    }

                }
                else
                {
                    ViewBag.Msg = "User name or passwoer mismatch!";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.Message;
            }
            return View();
        }

        public ActionResult SellForceLogin()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                ;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SellForceLogin(LoginInfo login)
        {
            try
            {
                List<LoginInfo> status = _account.SellForceLogin(login);
                if (status.Count != 0)
                {
                    if (status.Count() > 0)
                    {
                        var name = status[0].EmployeeName;
                        Session["Admin"] = "Admin";
                        Session["User1"] = name;
                        Session["user"] = status[0].Id;
                        Session["status"] = true;
                        if (status[0].UserTypeId == 4)
                        {
                            return RedirectToAction("../SellForce/Index");

                        }

                    }

                }
                else
                {
                    ViewBag.Msg = "User name or passwoer mismatch!";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.Message;
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Home");
        }

    }
}