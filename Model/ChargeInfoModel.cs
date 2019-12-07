using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvc.Model
{
    public class ChargeInfoModel
    {
        //收费类
        public int FID { get; set; }
        public string NIO { get; set; }
        public int Flifelong { get; set; }
        public string CreateDate { get; set; }
        public string ExpireDate { get; set; }
    }
}