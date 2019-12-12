using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ShowController : Controller
    {
        string url = "http://localhost:6201/";
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
        //车牌号添加
        public void License()
        {
            List<string> str1 = new List<string>() { "京", "津", "冀", "晋", "蒙", "辽", "吉",
            "黑", "沪", "苏", "浙", "皖", "闽", "赣", "鲁", "豫", "鄂", "湘", "粤", "桂", "琼", "渝", "川", "贵", "云", "藏", "陕"
            , "甘", "青", "宁", "新", "学" };
            ViewBag.Date = str1;
            ViewBag.list = new SelectList("ID","Name",str1);
        }
        public ActionResult LicenseAdd()
        {
            License();
            return View();
        }
        [HttpPost]
        public void LicenseAdd(UserInfoModel model)
        {
            string name = Request["Six"];
            string License = Request["ID"] + name;

            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var m in models)
            {
                model.UIDa = m.UIDa;
            }

            model.Uplate = License;
            url += "Login/LicenseAdd";
            string mm = JsonConvert.SerializeObject(model);
            string i = HttpClientHeper.Post(url, mm);
            if(Convert.ToInt32(i)>0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
        }
    }
}