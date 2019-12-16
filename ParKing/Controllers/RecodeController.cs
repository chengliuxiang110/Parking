using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParKing.Controllers
{
    [RoutePrefix("Recode")]
    public class RecodeController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult RecodeAdd(Recode recode)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@RName", recode.RName);
            pairs.Add("@FId", recode.FId);
            int i = DBHelper.ExecProcSQL("P_Recode_Add", pairs);
            return Json(i);
        }
        [Route("SelectOne")]
        [HttpGet]
        public IHttpActionResult SelectOne(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@FId", id);
            DataTable i = DBHelper.ExecProcDataTable("P_Recode_SelectOne", pairs);
            return Json(i);
        }
        [Route("Select")]
        [HttpGet]
        public IHttpActionResult Select()
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            DataTable i = DBHelper.ExecProcDataTable("P_Recode_Select", pairs);
            return Json(i);
        }
    }
}
