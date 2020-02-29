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

        public ActionResult NewShow()//首页
        {
            return View();
        }
        public ActionResult Newpartner()//合作案例
        {
            return View();
        }

        public ActionResult Newconsult()//咨询车库
        {
            return View();
        }
        public ActionResult WachCar()//免费洗车
        {
            return View();
        }
        public ActionResult about()//关于我们
        {
            return View();
        }
        public ActionResult GaoJi()//高级车库
        {
            return View();
        }
        public ActionResult ZhongJi()//中级车库
        {
            return View();
        }
        public ActionResult PuTong()//普通车库
        {
            return View();
        }
        public ActionResult DaRunFa()//大润发详情
        {
            return View();
        }
        public ActionResult WanDa()//万达详情
        {
            return View();
        }
        public ActionResult Luan()//乱停车详情
        {
            return View();
        }
        public ActionResult FaDan()//罚单详情
        {
            return View();
        }
        public ActionResult Zhuang()//装修详情
        {
            return View();
        }
        public ActionResult NewMap()//地图
        {
            return View();
        }

        public ActionResult Contact()//联系我们
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
            return View(NewSelectOne);
        }
        #endregion
    }
}