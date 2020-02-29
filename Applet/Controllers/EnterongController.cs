using Applet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Applet.Controllers
{
    public class EnterongController : Controller
    {
        // GET: Enterong
        public ActionResult Index()
        {
            return View();
        }
        //功能界面
        public ActionResult Show(string key="")
        {
            string name;
            //判断传进来的车牌号是否为空
            //if (key != null)
            //{
                
            //}
            HttpCookie cookie = Request.Cookies["Lucky"];
            if (cookie == null)
            {
                cookie = new HttpCookie("Lucky");
                Session["Key"] = key;
                name = Session["Key"].ToString();
                cookie.Value = HttpUtility.UrlEncode(name, Encoding.GetEncoding("UTF-8"));
            }
            else
            {
                if (string.IsNullOrEmpty(cookie.Value))
                {
                    Session["Key"] = key;
                    name = Session["Key"].ToString();
                    cookie.Value = HttpUtility.UrlEncode(name, Encoding.GetEncoding("UTF-8"));
                }
                else
                {
                    string str = HttpUtility.UrlDecode(cookie.Value, Encoding.GetEncoding("UTF-8"));
                    cookie.Value = HttpUtility.UrlEncode(str, Encoding.GetEncoding("UTF-8"));
                }
            }
            
            cookie.Expires= DateTime.Now.AddDays(1);
            Response.AppendCookie(cookie);
            
            return View();
        }
        //车库显示
        public ActionResult Make()
        {
            DataTable dt = DBHelper.ExecDataTable("P_Cw_Select");
            List<CarTypeStall> list = JsonConvert.DeserializeObject<List<CarTypeStall>>(JsonConvert.SerializeObject(dt));

            
           
            return View(list);
        }
        //预约界面
        public ActionResult Particulars(decimal money)
        {
            ViewBag.Maney = money;
            HttpCookie http = Request.Cookies["Lucky"];
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            ViewBag.Key = str;
            string dt = DateTime.Now.AddHours(2).ToString("HH:mm");
            ViewBag.Time = dt;
            return View();
        }

    }
}