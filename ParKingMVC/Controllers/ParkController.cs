using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public void Add(ParkInfoModel park)
        {
            url = "Park/Add";
            string m = JsonConvert.SerializeObject(park);
            string i = HttpClientHeper.Post(url, m);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<><>");
            }
        }
    }
}