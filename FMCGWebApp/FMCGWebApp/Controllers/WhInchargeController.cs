using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

namespace FMCGWebApp.Controllers
{
    public class WhInchargeController : Controller
    {
        // GET: WhIncharge

        private WhInchargeManager _incharge = new WhInchargeManager();
        public ActionResult StockOut()
        {
            ViewBag.order = _incharge.SellOrderList();
            return View();
        }
        [HttpPost]
        public ActionResult StockOut(Stockout stockout)
        {

            ViewBag.order = _incharge.SellOrderList();
            return View();
        }

    }
}