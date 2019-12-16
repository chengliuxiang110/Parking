using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class RecodeController : Controller
    {
        string url = "http://localhost:6201/";
        // GET: Recode
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show(int Fid=0)
        {
            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var m in models)
            {
                Fid = m.UIDa;
            }

            url += "Recode/SelectOne?id="+Fid;
            string model = HttpClientHeper.Get(url);
            List<Recode> recodes = JsonConvert.DeserializeObject<List<Recode>>(model);
            return View(recodes);
        }
    }
}