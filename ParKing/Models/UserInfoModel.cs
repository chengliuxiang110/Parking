using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKing
{
    public class UserInfoModel
    {
        //用户类
        public int UIDa { get; set; }
        public string UImage { get; set; }
        public string Uname { get; set; }
        public string Upwd { get; set; }
        public string Uidentity { get; set; }
        public string UPhone { get; set; }
        public string USite { get; set; }
        public string Uplate { get; set; }
        public string TID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Price { get; set; }
        public decimal Moneya { get; set; }
        public int FId { get; set; }


    }
}