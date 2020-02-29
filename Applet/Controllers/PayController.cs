using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Applet.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            return View();
        }
        //支付界面
        public ActionResult Pay(decimal maney)
        {
            ViewBag.time = maney;
            return View();
        }
        //查看车辆信息
        public ActionResult Details()
        {
           
            return View();
        }
    }
}