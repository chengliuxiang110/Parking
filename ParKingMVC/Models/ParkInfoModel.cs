using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKingMVC
{
    public class ParkInfoModel
    {
        //用户停车记录 
        public int PID { get; set; }
        public int UIDa { get; set; }
        public int WID { get; set; }
        public string PImage { get; set; }
        public int TID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}