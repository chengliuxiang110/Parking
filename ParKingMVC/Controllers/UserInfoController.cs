using Newtonsoft.Json;
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


        #region 注册
        [HttpPost]
        public void UserInfoLogin(UserInfoModel model, HttpPostedFileBase fileBase)
        {
            if (!System.IO.Directory.Exists(Server.MapPath("/Img/")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("/Img/"));
            }
            fileBase.SaveAs(Server.MapPath("/Img/") + fileBase.FileName);
            model.UImage = "/Img/" + fileBase.FileName;

            url += "login/Add";
            string s = JsonConvert.SerializeObject(model);
            string i = HttpClientHeper.Post(url, s);
            
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<script>alert('注册成功！');location.href='/UserInfo/UserInfoLogin'</script>");
            }
            else
            {
                Response.Write("<script>alert('注册失败！');location.href='/UserInfo/UserInfoLogin'</script>");
            }
        }
        #endregion

        #region 登录
        public ActionResult UserInfoLogon()
        {
            return View();
        }
        [HttpPost]
        public void UserInfoLogon(string Name,string Key)
        {
            url += "/Login/Login";
            UserInfoModel m = new UserInfoModel() { Uname = Name, Upwd = Key };

            string s = JsonConvert.SerializeObject(m);
            string data = HttpClientHeper.Post(url, s);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(data);
           
            if (list.Count > 0)
            {
                Session["ID"] = list.First().UIDa;
                int ids = Convert.ToInt32(Session["ID"]);
                Response.Write("<script>alert('登录成功！')</script>");
                Response.Redirect($"http://localhost:7652/UserInfo/Show/?id={ids}");
            }
            else
            {
                Response.Write("<script>alert('登录失败！');location.href='/UsersInfo/Show'</script>");
            }
        }

        #endregion


        #endregion


        /// <summary>
        /// 个人信息反填
        /// </summary>
        /// <returns></returns>
        public ActionResult Show(int id)
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

        public ActionResult UserInfoUpt(int id)
        {
            url += "Login/SelectOne?id=" + id;
            string model = HttpClientHeper.Get(url);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(model);
            return View(list.First());
        }
        [HttpPost]
        public void UserInfoUpt(UserInfoModel user)
        {
            url += "login/Upt";
            string s = JsonConvert.SerializeObject(url);
            string model = HttpClientHeper.Post(url, s);
            if (Convert.ToInt32(model) > 0)
            {
                int ids = Convert.ToInt32(Session["ID"]);
                Response.Write("<script>alert('修改成功！')</script>");
                Response.Redirect($"http://localhost:7652/UserInfo/Show/?id={ids}");
            }
        }
    }
}