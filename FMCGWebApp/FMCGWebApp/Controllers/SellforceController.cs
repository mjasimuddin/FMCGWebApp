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
                List<SellOrderInfo> sellOrders = new List<SellOrderInfo>()
                {
                    new SellOrderInfo(){Id = 0, AreaName = "Null", CategoryName = "Null", ItemName = "Null", ShopName = "Null", Quentity = 0}
                };
                ViewBag.orderLists = sellOrders;
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

            _sellOrder.AddSellOrder(sellOrder);

            var sellOrders = _sellOrder.GetAllOrder();


            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.category = _sellOrder.GetAllCategory();
            ViewBag.orderLists = sellOrders;
            // ViewBag.item = _sellOrder.GetAllItem();
            return View();
        }

        public ActionResult SendOrder(SellOrder sellOrder)
        {

            var sendSellOrders = _sellOrder.GetAllSellOrder();

            try
            {
                foreach (var order in sendSellOrders)
                {
                    sellOrder.EntryDate = DateTime.Now;
                    sellOrder.Status = "Ordered";
                    sellOrder.EmployeeId = (int)Session["user"];
                    sellOrder.AreaId = order.AreaId;
                    sellOrder.ShopId = order.ShopId;
                    sellOrder.CategoryId = order.CategoryId;
                    sellOrder.ItemId = order.ItemId;
                    sellOrder.Quantity = order.Quantity;

                    _sellOrder.SendSellOrder(sellOrder);
                }

                _sellOrder.ClearHistory();

            }
            catch (Exception exception)
            {
                ViewBag.ShowMsg = exception.Message;
            }


            return RedirectToAction("SendSellOrder");
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