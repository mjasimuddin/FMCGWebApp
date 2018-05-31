using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;
using FMCGWebApp.ViewModels;

namespace FMCGWebApp.Controllers
{
    public class SellForceController : Controller
    {
        // GET: SellForce

        private SellOrderManager _sellOrder = new SellOrderManager();
        private ShopInfoManager _shopInfo = new ShopInfoManager();
        private AccountManager _account = new AccountManager();

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Account");
                ;
            }

            return View();
        }

        public ActionResult SendSellOrder()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Home", "Account");
                ;
            }

            int employeeId = (int)Session["user"];
            List<LoginInfo> userRole = _account.GetUserRole(employeeId);
            int UserTypeId = 0;
            foreach (var loginInfo in userRole)
            {
                if (loginInfo.UserTypeId == 4)
                {
                    UserTypeId = 4;
                }
            }
            if (UserTypeId == 4)
            {
                ViewBag.area = _shopInfo.GetAreaList();
                ViewBag.category = _sellOrder.GetAllCategory();
              //  ViewBag.item = _sellOrder.GetAllItem();

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

        }
        [HttpPost]
        public ActionResult SendSellOrder(SellOrder sellOrder)
        {
            sellOrder.EntryDate = DateTime.Now;
            sellOrder.Status = "Ordered";
            sellOrder.EmployeeId = (int)Session["user"];

            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _sellOrder.SendSellOrder(sellOrder);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }

            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.category = _sellOrder.GetAllCategory();
           // ViewBag.item = _sellOrder.GetAllItem();
            return View();
        }

        public JsonResult GetShopByAreaId(int deptId)
        {
            var courses = _sellOrder.GetAllShop(deptId);
            return Json(courses.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemByCategoryId(int deptId)
        {
            var courses = _sellOrder.GetAllItem(deptId);
            return Json(courses.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}