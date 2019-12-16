using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKingMVC.Models
{
    public class NewsModel
    {
        //新闻类
        public int NID { get; set; }
        public string Nname { get; set; }
        public string Nnei { get; set; }
        public string Npicture { get; set; }
        public DateTime Ndate { get; set; }
        public int Lui { get; set; }
    }
}