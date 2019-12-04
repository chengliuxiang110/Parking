using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ChargeController : Controller
    {
        //Url 路径连接
        string url = "http://localhost:6201/";
        // GET: Charge
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            url += "Charge/Select";
            string model = id.ToString();
            string i = HttpClientHeper.Post(url, model);
            List<ParkInfoModel> parks = JsonConvert.DeserializeObject<List<ParkInfoModel>>(JsonConvert.SerializeObject(i));
            return View(parks);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public void Add(ChargeInfoModel charge)
        {
            url += "Charge/Add";
            string m = JsonConvert.SerializeObject(charge);
            string i = HttpClientHeper.Post(url, m);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<><>");
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id"></param>
        public void Del(int id)
        {
            url += "Charge/Del";
            string model = id.ToString();
            string i = HttpClientHeper.Post(url, model);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<><>");
            }
        }
    }
}