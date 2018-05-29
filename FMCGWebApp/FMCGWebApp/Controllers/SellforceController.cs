using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

namespace FMCGWebApp.Controllers
{
    public class SellForceController : Controller
    {
        // GET: SellForce

        private SellOrderManager _sellOrder = new SellOrderManager();
        private ShopInfoManager _shopInfo = new ShopInfoManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendSellOrder()
        {
            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.shop = _sellOrder.GetAllShop();
            ViewBag.category = _sellOrder.GetAllCategory();
            ViewBag.item = _sellOrder.GetAllItem();

            return View();
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
            ViewBag.shop = _sellOrder.GetAllShop();
            ViewBag.category = _sellOrder.GetAllCategory();
            ViewBag.item = _sellOrder.GetAllItem();
            return View();
        }

    }
}