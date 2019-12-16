using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
namespace ParKing.Controllers
{
    [RoutePrefix("News")]
    public class NewsController : ApiController
    {
        #region 新闻显示
        [Route("NewShow")]
        [HttpGet]
        public IHttpActionResult NewsIndex()
        {
            Dictionary<string, object> news = new Dictionary<string, object>();
            DataTable data = DBHelper.ExecProcDataTable("NewsShow", news);
            return Json(data);
        }
        #endregion

        #region 新闻显示一条
        [Route("NewSelectOne")]
        [HttpGet]
        public IHttpActionResult NewsSelectOne(int id )
        {
            Dictionary<string, object> news = new Dictionary<string, object>();
            news.Add("@id", id);
            DataTable data = DBHelper.ExecProcDataTable("NewsSelectOne",news);
            return Json(data);
        }
        #endregion

    }
}
