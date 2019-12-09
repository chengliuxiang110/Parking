using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParKing.Controllers
{
    [RoutePrefix("CarType")]
    public class CarTypeController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult CarTypesAdd(CarTypesInfoModel car)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@Tname", car.Tname);
            int i = DBHelper.ExecProcSQL("P_CarTypes_Add", pairs);
            return Json(i);
        }
        [Route("Select")]
        [HttpGet]
        public IHttpActionResult CarSelect()
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            DataTable dt = DBHelper.ExecProcDataTable("P_CarTypes_Select", pairs);
            return Json(dt);
        }
        [Route("Upt")]
        [HttpGet]
        public IHttpActionResult CarTypeUpt(int id)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@TId", id);
            DataTable dt = DBHelper.ExecProcDataTable("P_CarType_Upt", pairs);
            return Json(dt);
        }
    }
}
