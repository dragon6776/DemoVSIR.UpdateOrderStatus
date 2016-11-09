using Demo.UpdateOrderStatus.XinhCaNgay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.UpdateOrderStatus.XinhCaNgay.Controllers
{
    public class HomeController : Controller
    {
        private readonly UpdateXCNOrderStatusService _updateStatusService = new UpdateXCNOrderStatusService();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Cập nhật trạng thái đơn hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateXCNOrderStatus()
        {
            var list = new List<string>();

            _updateStatusService.UpdateOrderStatus();

            return Content("Success");
        }
    }
}