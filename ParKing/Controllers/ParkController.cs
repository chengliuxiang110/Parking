using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParKing.Controllers
{
    [RoutePrefix("Park")]
    public class ParkController : ApiController
    {
        [Route("select")]
        [HttpGet]
        public IHttpActionResult ParkShow()
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            DataTable dt = DBHelper.ExecProcDataTable("P_Park_Select", pairs);
            return Json(dt);
        }
        [Route("Del")]
        [HttpPost]
        public IHttpActionResult ParkDel(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@PID", id);
            int i = DBHelper.ExecProcSQL("P_Park_Del", pairs);
            return Json(i);
        }
        [Route("SelectOne")]
        [HttpPost]
        public IHttpActionResult ParkSelectOne(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@PID", id);
            DataTable dt = DBHelper.ExecProcDataTable("P_Park_SelectOne", pairs);
            return Json(dt);
        }
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult ParkAdd(ViewModel park)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@WID", park.WID);
            pairs.Add("@UIDa", park.UIDa);
            pairs.Add("@PImage", park.PImage);
            pairs.Add("@TID", park.TID);
            pairs.Add("@ExpireDate", park.ExpireDate);
            int i = DBHelper.ExecProcSQL("P_Park_Add", pairs);
            return Json(i);
        }

    }
}
