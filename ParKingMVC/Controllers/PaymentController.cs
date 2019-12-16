﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.QrCode;

namespace ParKingMVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成二维码方法
        /// </summary>
        /// <param name="text">输入的字符串</param>
        /// <param name="width">二维码宽度</param>
        /// <param name="height">二维码高度</param>
        /// <returns></returns>
        public ActionResult QRcode(string text, string width = "300", string height = "300")
        {
            //string Response = "";
            try
            {
                text = "请支付金额￥" + text + "元";
                BarcodeWriter writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                options.DisableECI = true;
                //设置内容编码
                options.CharacterSet = "UTF-8";
                //将传来的值赋给二维码的宽度和高度
                options.Width = Convert.ToInt32(width);
                options.Height = Convert.ToInt32(height);
                //设置二维码的边距,单位不是固定像素
                options.Margin = 1;
                writer.Options = options;

                Bitmap map = writer.Write(text);
                string di = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                //二维码会显示在桌面(你也想显示在桌面的话,要改一下路径)
                string path = Path.Combine("D:\\小实训2\\Api\\ParKingMVC\\Moeny", di);
                map.Save(path, ImageFormat.Png);
                string m = "/Moeny/" + di;
                ViewBag.Img = m;
                map.Dispose();
                //Response = "二维码生成成功！";
            }
            catch (Exception)
            {
                //Response = "二维码生成失败！";
            }
            return View();
        }
    }
}