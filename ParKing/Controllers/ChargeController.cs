using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParKing.Controllers
{
    [RoutePrefix("Charge")]
    public class ChargeController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult ChargeAdd(ChargeInfoModel model)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@NIO",model.NIO);
            pairs.Add("@Flifelong", model.Flifelong);
            int i = DBHelper.ExecProcSQL("P_Charge_Add", pairs);
            return Json(i);
        }
        [Route("Select")]
        [HttpGet]
        public IHttpActionResult ChargeSelect(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@FID", id);
            DataTable dt = DBHelper.ExecProcDataTable("P_Charge_Select", pairs);
            return Json(dt);
        }
        [Route("Del")]
        [HttpPost]
        public IHttpActionResult ChargeDel(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@FID", id);
            int i = DBHelper.ExecProcSQL("P_Charge_Del", pairs);
            return Json(i);
        }

    }
}
