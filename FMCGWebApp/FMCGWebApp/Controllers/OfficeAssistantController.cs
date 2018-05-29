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
    public class OfficeAssistantController : Controller
    {
        // GET: OfficeAssistant

        private CategoryManager _category = new CategoryManager();
        private ItemManager _item = new ItemManager();
        private WhouseinfoManager _whouseinfo = new WhouseinfoManager();
        private EmployeeManager _employee = new EmployeeManager();
        private ShopInfoManager _shopInfo = new ShopInfoManager();
        private StockInManager _stockIn = new StockInManager();
        private SellOrderManager _sellOrder = new SellOrderManager();
        private AreaManager _area = new AreaManager();
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

        public ActionResult SaveCategory()
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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }
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

        public ActionResult SaveItem()
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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {

                ViewBag.categorys = _item.GetAllCategory();

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

        }
        [HttpPost]
        public ActionResult SaveItem(Item item)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _item.SaveItem(item);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }

            ViewBag.categorys = _item.GetAllCategory();
            return View();
        }

        public ActionResult SaveWhouse()
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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {

                ViewBag.employees = _shopInfo.GetAllEmployees();
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

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
            ViewBag.employees = _shopInfo.GetAllEmployees();

            return View();
        }

        public ActionResult SaveEmployee()
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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {

                ViewBag.designations = _employee.GetDesignationList();
                ViewBag.gender = _employee.GetGenderList();

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }

        }
        [HttpPost]
        public ActionResult SaveEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _employee.SaveEmployee(employee);

                }
                catch (Exception exception)
                {
                    ViewBag.ShowMsg = exception.Message;
                }
            }

            ViewBag.designations = _employee.GetDesignationList();
            ViewBag.gender = _employee.GetGenderList();

            return View();
        }

        public ActionResult SaveArea()
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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }
        }

        [HttpPost]
        public ActionResult SaveArea(Area area)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    ViewBag.ShowMsg = _area.SaveArea(area);

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
                if (loginInfo.UserTypeId == 2)
                {
                    UserTypeId = 2;
                }
            }
            if (UserTypeId == 2)
            {
                ViewBag.area = _shopInfo.GetAreaList();
                ViewBag.employees = _shopInfo.GetAllEmployees();
                return View();
            }
            else
            {
                return RedirectToAction("Home", "Account");
            }
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
            ViewBag.employees = _shopInfo.GetAllEmployees();

            return View();
        }

    }
}