using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKingMVC
{
    public class ViewModel
    {
        //车辆类别
        public int TID { get; set; }
        public string Tname { get; set; }
        public decimal Tmaney { get; set; }

        //用户停车记录 
        public int PID { get; set; }
        public int UIDa { get; set; }
        public int WID { get; set; }
        public string PImage { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        //用户类
        public string UImage { get; set; }
        public string Uname { get; set; }
        public string Upwd { get; set; }
        public string Uidentity { get; set; }
        public string UPhone { get; set; }
        public string USite { get; set; }
        public string Uplate { get; set; }
        public string Price { get; set; }
        public decimal Moneya { get; set; }
        public int FId { get; set; }
    }
}