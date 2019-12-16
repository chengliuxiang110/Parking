using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Show()
        {
            return View();
        }
        
    }
}