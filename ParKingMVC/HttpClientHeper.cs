using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ParKingMVC
{
    /// <summary>
    /// 封装函数 
    /// Get和Post请求方式
    /// </summary>
    public class HttpClientHeper
    {
        /// <summary>
        /// Get请求封装
        /// 静态可以直接使用
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage httpResponse = Client.GetAsync(url).Result;
            string model = httpResponse.Content.ReadAsStringAsync().Result;
            return model;
        }
        /// <summary>
        /// Post请求方式
        /// 静态直引用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static string Post(string url, string goods)
        {
            HttpClient Client = new HttpClient();
            HttpContent context = new StringContent(goods);
            context.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponse = Client.PostAsync(url, context).Result;
            string model = httpResponse.Content.ReadAsStringAsync().Result;
            return model;
        }
    }
}