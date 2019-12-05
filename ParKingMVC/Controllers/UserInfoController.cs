﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class UserInfoController : Controller
    {
        string url = "http://localhost:6201/";
        // GET: UserInfo

        public ActionResult Index()
        {
            return View();
        }

        #region 用户登录、注册


        #region 登录
        public ActionResult UserInfoLogon()
        {
            return View();
        }
        [HttpPost]
        public void UserInfoLogon(string Name,string Key)
        {
            UserInfoModel m = new UserInfoModel() { Uname = Name, Upwd = Key };
            url+= "Login/Login";
            string s = JsonConvert.SerializeObject(m);
            string data = HttpClientHeper.Post(url, s);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(data);
            if (list.Count > 0)
            {
                Response.Write("<script>alert('登录成功！');location.href='/Users/Show'</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败！');location.href='/Users/Show'</script>");
            }
        }

        #endregion
        #region 注册

        #endregion
        #endregion


        /// <summary>
        /// 个人信息反填
        /// </summary>
        /// <returns></returns>
        public ActionResult Show(int id=1)
        {
            url += "Login/SelectOne?id="+id;
            string model = HttpClientHeper.Get(url);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(model);
            return View(list.First());
        }
        [HttpPost]
        public void UserInfoUpt(UserInfoModel model,HttpPostedFileBase File)
        {
            url += "login/UserInfoUpt";
            if (!System.IO.Directory.Exists(Server.MapPath("/File/")))
                System.IO.Directory.CreateDirectory(Server.MapPath("/File/"));
            File.SaveAs(Server.MapPath("/File/" + File.FileName));
            model.UImage = "/File/" + File.FileName;

            string str = JsonConvert.SerializeObject(model);
            string m = HttpClientHeper.Post(url, str);
            if (Convert.ToInt32(m) > 0)
            {
                Response.Write("<script>alert('修改成功！');location.href='/UserInfo/Show'</script>");
            }
        }
    }
}