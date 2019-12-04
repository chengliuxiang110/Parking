using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ShowController : Controller
    {
        //Index停车场样式
        // GET: Show
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            return View();
        }
    }
}