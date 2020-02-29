using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

        public ActionResult show()
        {
            return View();
        }

        public ActionResult ming()
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
            if (Server.MapPath("/Img/") == null)
            {
                fileBase.SaveAs(Server.MapPath("/Img/") + fileBase.FileName);
                model.UImage = "/Img/" + fileBase.FileName;

                url += "login/Add";
                if (model.Upwd == model.Upwd2)
                {
                    string s = JsonConvert.SerializeObject(model);
                    string i = HttpClientHeper.Post(url, s);

                    if (Convert.ToInt32(i) > 0)
                    {
                        Response.Write("<script>alert('注册成功,请登录！');location.href='/UserInfo/UserInfoLogon'</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('注册失败！');location.href='/UserInfo/UserInfoLogon'</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('密码不一致，请重新输入!');location.href='/UserInfo/UserInfoLogon'</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('文件为空！请重新添加');location.href='/UserInfo/UserInfoLogon'</script>");
            }
            
        }
        #endregion

        #region 登录
        public ActionResult UserInfoLogon()
        {
            ParKingMVC.UserInfoModel model = new UserInfoModel();
            return View(model);
        }
        [HttpPost]
        public void UserInfoLogon(string Name, string Key)
        {
            url += "/Login/Login";
            UserInfoModel m = new UserInfoModel() { Uname = Name, Upwd = Key };

            string s = JsonConvert.SerializeObject(m);
            string data = HttpClientHeper.Post(url, s);
            List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(data);

            if (list.Count > 0)
            {
                //Cooke事件
                HttpCookie cookie = new HttpCookie("User");
                //给Cooke赋值
                cookie.Value = list.First().Uname;
                //给Cooke设置过期时间
                cookie.Expires = DateTime.Now.AddMinutes(20);
                //添加到服务器
                Response.AppendCookie(cookie);

                HttpCookie http = new HttpCookie("Cooke");
                //Cooke传入并编码
                http.Value = HttpUtility.UrlEncode(data, Encoding.GetEncoding("UTF-8"));
                http.Expires = DateTime.Now.AddMinutes(20);
                Response.AppendCookie(http);


                Session["ID"] = list.First().UIDa;
                int ids = Convert.ToInt32(Session["ID"]);
                Response.Write("<script>alert('登录成功！');location.href='/News/NewIndex'</script>");
            }
            else
            {
                Response.Write("<script>alert('用户名错误，或密码错误！');location.href='/UserInfo/UserInfoLogon'</script>");
            }
        }

        #endregion

        #region 修改
        public ActionResult UserInfoLoginUpdate(int id = 0)
        {
            try
            {
                HttpCookie http = Request.Cookies["Cooke"];
                //Cooke解码
                string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
                //反序列化
                List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
                foreach (var m in models)
                {
                    id = m.UIDa;
                }
                url += "Login/SelectOne?id=" + id;
                string model = HttpClientHeper.Get(url);
                List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(model);
                return View(list.First());
            }
            catch (Exception)
            {
                Response.Write("<script>alert('请去登入再做以下操作谢谢!');location.href='/UserInfo/UserInfoLogon'</script>");
                return null;
            }
        }
        [HttpPost]
        public void UserInfoLoginUpdate(UserInfoModel model, int id)
        {
            url += "login/Upt";

            model.UIDa = id;
            string s = JsonConvert.SerializeObject(model);
            string i = HttpClientHeper.Post(url, s);
            // List<UserInfoModel> a = JsonConvert.DeserializeObject<List<UserInfoModel>>(i);
            //if (model.Upwd == model.Upwd2)
            //{
            if (Convert.ToInt32(i) > 0)
            {
                Response.Write("<script>alert('修改成功！请重新登录。');location.href='/UserInfo/UserInfoLogon'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');location.href='/UserInfo/UserInfoLogon'</script>");
            }
        }
        //else
        //{
        //    Response.Write("<script>alert('密码不一致！');location.href='/UserInfo/UserInfoLogon'</script>");
        //}
        //}


        #endregion
        #endregion

        #region 个人信息反填

        
        /// <summary>
        /// 个人信息反填
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Show(int id = 0)
        {
            try
            {
                HttpCookie http = Request.Cookies["Cooke"];
                //Cooke解码
                string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
                //反序列化
                List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
                foreach (var m in models)
                {
                    id = m.UIDa;
                }
                url += "Login/SelectOne?id=" + id;
                string model = HttpClientHeper.Get(url);
                List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(model);
                return View(list.First());
            }
            catch (Exception)
            {
                Response.Write("<script>alert('请登入之后继续操作!');location.href='/UserInfo/UserInfoLogon'</script>");
                return null;
            }
        }
        [HttpPost]
        public void UserInfoUpt(UserInfoModel model, HttpPostedFileBase File)
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
                Response.Write("<script>alert('修改个人信息成功！');location.href='/News/NewIndex'</script>");
            }
        }

        //public ActionResult UserInfoUpt(int id)
        //{
        //    url += "Login/SelectOne?id=" + id;
        //    string model = HttpClientHeper.Get(url);
        //    List<UserInfoModel> list = JsonConvert.DeserializeObject<List<UserInfoModel>>(model);
        //    return View(list.First());
        //}
        //[HttpPost]
        //public void UserInfoUpt(UserInfoModel user)
        //{
        //    url += "login/Upt";
        //    string s = JsonConvert.SerializeObject(url);
        //    string model = HttpClientHeper.Post(url, s);
        //    if (Convert.ToInt32(model) > 0)
        //    {
        //        int ids = Convert.ToInt32(Session["ID"]);
        //        Response.Write("<script>alert('修改成功！')</script>");
        //        Response.Redirect($"http://localhost:7652/UserInfo/Show/?id={ids}");
        //    }
        //}
        #endregion
    }
}