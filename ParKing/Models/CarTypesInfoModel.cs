using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParKing
{
    public class CarTypesInfoModel
    {
        //车辆类别
        public int TID { get; set; }
        public string Tname { get; set; }
        public DateTime CreateDate { get; set; }
    }
}