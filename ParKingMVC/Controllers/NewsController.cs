using ParKingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace ParKingMVC.Controllers
{
    public class NewsController : Controller
    {
        // GET: News

        //Url 新闻api路径
        string url = "http://localhost:6201/";


        #region 新闻模板页
        public ActionResult NewShow()
        {
            return View();
        }
        #endregion

        #region 新闻显示
        public ActionResult NewIndex()
        {
            url += "/News/NewShow";
            string model = HttpClientHeper.Get(url);
            List<NewsModel> news = JsonConvert.DeserializeObject<List<NewsModel>>(model);
            return View(news);
        }
        #endregion


        #region 新闻查询一条
        public ActionResult NewSelectOnes(int id=4)
        {
            url += $"/News/NewSelectOne?id={id}";
            string model = HttpClientHeper.Get(url);
            List<NewsModel> NewSelectOne = JsonConvert.DeserializeObject<List<NewsModel>>(model);
            return View(model);
        }
        #endregion
    }
}