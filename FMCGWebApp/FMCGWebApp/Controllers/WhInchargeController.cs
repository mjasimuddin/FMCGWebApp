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
    public class WhInchargeController : Controller
    {
        // GET: WhIncharge
        private StockoutManager _stockOut = new StockoutManager();
        private StockInManager _stockIn = new StockInManager();
        private ItemManager _item = new ItemManager();
        private SellOrderManager _sellOrder = new SellOrderManager();
        private ReportManager _report = new ReportManager();
        private PasswordAndDesignationManager _passwordAndDesignation = new PasswordAndDesignationManager();
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

        public ActionResult Stockout()
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
                if (loginInfo.UserTypeId == 3)
                {
                    UserTypeId = 3;
                }
            }
            if (UserTypeId == 3)
            {
                ViewBag.orderId = _stockOut.SellOrderList();

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

        }
        [HttpPost]
        public ActionResult Stockout(Stockout stockout)
        {
            stockout.Status = "Ok";
            ViewBag.msg = _stockOut.ConfirmSellOrder(stockout);

            ViewBag.orderId = _stockOut.SellOrderList();

            return View();
        }

        public JsonResult GetSelOrderInfoById(int departmentId)
        {
            IEnumerable<SellOrderInfo> sellorder = _stockOut.GetAllSellOrder(departmentId);
            return Json(sellorder.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveStockin()
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
                if (loginInfo.UserTypeId == 3)
                {
                    UserTypeId = 3;
                }
            }
            if (UserTypeId == 3)
            {
                ViewBag.categorys = _item.GetAllCategory();
               // ViewBag.item = _sellOrder.GetAllItem();

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

        }

        [HttpPost]
        public ActionResult SaveStockin(StockIn stockIn)
        {
            stockIn.EntryDate = DateTime.Now;
            stockIn.EmployeeId = (int)Session["user"];

            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _stockIn.SaveStockin(stockIn);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }
            ViewBag.categorys = _item.GetAllCategory();
           // ViewBag.item = _sellOrder.GetAllItem();

            return View();
        }

        public ActionResult CompareOrderandStock()
        {
            List<CompareOrderandStock> CompareOrderandStock = _report.GetNeedandStockInfo();
            return View(CompareOrderandStock);
        }

        public JsonResult GetItemByCategoryId(int deptId)
        {
            var courses = _sellOrder.GetAllItem(deptId);
            return Json(courses.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}