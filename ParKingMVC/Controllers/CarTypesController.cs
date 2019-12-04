using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class CarTypesController : Controller
    {
        //Url 路径连接
        string url = "http://localhost:6201/";
        // GET: CarTypes
        /// <summary>
        /// 显示方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            url += "CarType/Select";
            string model = HttpClientHeper.Get(url);
            List<CarTypesInfoModel> list = JsonConvert.DeserializeObject<List<CarTypesInfoModel>>(model);
            return View(list);
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
        public void Add(ChargeInfoModel model)
        {
            url += "/CarType/Add";
            string m = JsonConvert.SerializeObject(model);
            string i = HttpClientHeper.Post(url, m);
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<><>");
            }
        }
    }
}