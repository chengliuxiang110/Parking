using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParKing.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        //用户登入
        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(UserInfoModel m)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@Uname", m.Uname);
            pairs.Add("@Upwd", m.Upwd);
            DataTable i = DBHelper.ExecProcDataTable("P_UserInfo_Login", pairs);
            return Json(i);
        }
        //修改密码
        [Route("Upt")]
        [HttpPost]
        public IHttpActionResult LoginUpt(UserInfoModel user)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@UIDa", user.UIDa);
            pairs.Add("@Uname", user.Uname);
            pairs.Add("@Upwd", user.Upwd);
            DataTable i = DBHelper.ExecProcDataTable("P_UserInfo_UptLogin", pairs);
            return Json(i);
        }
        //用户注册
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult UserInfoAdd(UserInfoModel u)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@UImage", u.UImage);
            pairs.Add("@Uname ", u.Uname);
            pairs.Add("@UPwd ", u.Upwd);
            pairs.Add("@UPhone ", u.UPhone);
            pairs.Add("@Uidentity", u.Uidentity);//身份证
            pairs.Add("@USite ", u.USite);//地址
            int i = DBHelper.ExecProcSQL("P_UserInfoAdd", pairs);
            return Json(i);
        }
        //修改个人中心信息
        [Route("UserInfoUpt")]
        [HttpPost]
        public IHttpActionResult UserInfoUpt(UserInfoModel u)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@Uida",u.UIDa );
            pairs.Add("@UImage", u.UImage);
            pairs.Add("@Uname", u.Uname);
            pairs.Add("@UPhone",u.UPhone );
            pairs.Add("@Uidentity", u.Uidentity);
            pairs.Add("@USite", u.USite);

            int i = DBHelper.ExecProcSQL("P_UserInfoUptU", pairs);
            return Json(i);
        }
        [Route("SelectOne")]
        [HttpGet]
        public IHttpActionResult UserInfoSelect(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@Uida", id);
            DataTable i = DBHelper.ExecProcDataTable("P_UserInfo_SelectOne", pairs);
            return Json(i);
        }
        [Route("LicenseAdd")]
        [HttpPost]
        public IHttpActionResult LicenseAdd(UserInfoModel model)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@UId", model.UIDa);
            pairs.Add("@License", model.Uplate); ;
            int i = DBHelper.ExecProcSQL("P_LicenseAdd", pairs);
            return Json(i);
        }

    }
}
