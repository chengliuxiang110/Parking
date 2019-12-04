using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKingMVC
{
    public class StallInfoModel
    {
        //车位类
        public int WID { get; set; }
        public string Place { get; set; }
        public int Situation { get; set; }
        public string Content { get; set; }
    }
}