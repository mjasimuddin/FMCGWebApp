using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMCGWebApp.Manager;
using FMCGWebApp.Models;

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

        public ActionResult Index()
        {
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

        public ActionResult SaveItem()
        {
            ViewBag.categorys = _item.GetAllCategory();

            return View();
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
            ViewBag.employees = _shopInfo.GetAllEmployees();
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
            ViewBag.employees = _shopInfo.GetAllEmployees();

            return View();
        }

        public ActionResult SaveEmployee()
        {
            ViewBag.designations = _employee.GetDesignationList();
            ViewBag.gender = _employee.GetGenderList();

            return View();
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

            return View();
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
            ViewBag.area = _shopInfo.GetAreaList();
            ViewBag.employees = _shopInfo.GetAllEmployees();
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
            ViewBag.employees = _shopInfo.GetAllEmployees();

            return View();
        }

    }
}