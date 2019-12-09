using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ParkController : Controller
    {
        //Url 路径连接
        string url = "http://localhost:6201/";
        // GET: Park
        public ActionResult Index()
        {
            url += "Park/Select";
            string model =  HttpClientHeper.Get(url);
            List<ParkInfoModel> parks = JsonConvert.DeserializeObject<List<ParkInfoModel>>(JsonConvert.SerializeObject(model));
            return View(parks);
        }
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id">传入的Id</param>
        public void Del(int id)
        {
            url += "Park/Del";
            string model = id.ToString();
            string i = HttpClientHeper.Post(url, model);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<><>");
            }
        }
        /// <summary>
        /// 反填查询一条
        /// </summary>
        /// <param name="id">传入的ID</param>
        /// <returns></returns>
        public ActionResult SelectOne(int id)
        {
            url += "Park/Del";
            string model = id.ToString();
            string i = HttpClientHeper.Post(url, model);
            List<ParkInfoModel> parks = JsonConvert.DeserializeObject<List<ParkInfoModel>>(JsonConvert.SerializeObject(i));
            return View(parks);
        }
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int id)
        {
            ////Cooke获取值
            //HttpCookie cookie = Request.Cookies["User"];
            ////Cooke获取Value值
            //ViewBag.Name = cookie.Value;

            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var m in models)
            {
                ViewBag.Id = m.UIDa;
                ViewBag.Name = m.Uname;
            }





            url += "CarType/Upt?id=" + id;
            string model = HttpClientHeper.Get(url);
            List<ViewModel> list = JsonConvert.DeserializeObject<List<ViewModel>>(model);
            return View(list.First());
        }
        [HttpPost]
        public void Add(ParkInfoModel park)
        {
            park.UIDa =Convert.ToInt32(Session["ID"]);
            url = "Park/Add";
            string m = JsonConvert.SerializeObject(park);
            string i = HttpClientHeper.Post(url, m);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<script>alter('添加成功！')</script>");
            }
        }

    }
}