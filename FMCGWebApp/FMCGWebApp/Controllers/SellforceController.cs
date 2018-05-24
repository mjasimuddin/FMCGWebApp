using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

namespace FMCGWebApp.Controllers
{
    public class SellforceController : Controller
    {
        // GET: Sellforce
        private SellOrderManager _sellOrder = new SellOrderManager();

        public ActionResult SendSellOrder()
        {
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
            //sellOrder.EmployeeId = (int) Session["user"];
            //sellOrder.AreaId = (int)Session["areaId"];
            sellOrder.EmployeeId = 2;
            sellOrder.AreaId = 1;

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

            ViewBag.shop = _sellOrder.GetAllShop();
            ViewBag.category = _sellOrder.GetAllCategory();
            ViewBag.item = _sellOrder.GetAllItem();
            return View();
        }
    }
}