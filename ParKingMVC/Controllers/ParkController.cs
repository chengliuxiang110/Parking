using Newtonsoft.Json;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ParKingMVC.Controllers
{
    public class ParkController : Controller
    {
        //Url 路径连接
        string url = "http://localhost:6201/";
        // GET: Park
        public ActionResult Index(int id = 0)
        {

            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var m in models)
            {
                id = m.UIDa;
            }
            url += "Park/SelectOne?id=" + id;
            string model = HttpClientHeper.Get(url);
            List<ParkViewModel> parks = JsonConvert.DeserializeObject<List<ParkViewModel>>(model);
            return View(parks);
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int id)
        {
            ////Cooke获取值
            //HttpCookie cookie = Request.Cookies["User"];
            ////Cooke获取Value值
            //ViewBag.Name = cookie.Value;

            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var m in models)
            {
                ViewBag.Id = m.UIDa;
                ViewBag.Name = m.Uname;
                ViewBag.Plate = m.Uplate;
                Session["Plate"] = m.Uplate;
            }

            url += "CarType/Upt?id=" + id;
            string model = HttpClientHeper.Get(url);
            List<ViewModel> list = JsonConvert.DeserializeObject<List<ViewModel>>(model);
            return View(list.First());
        }
        [HttpPost]
        public void Add(ParkInfoModel park, HttpPostedFileBase File)
        {
          
            if (!System.IO.Directory.Exists(Server.MapPath("/Img/")))
                System.IO.Directory.CreateDirectory(Server.MapPath("/Img/"));

            park.PImage = Server.MapPath("/Img/") + File.FileName;
            park.TID = Convert.ToInt32(Request["TID"]);
            Session["TID"] = park.TID;
            HttpCookie http = Request.Cookies["Cooke"];
            //Cooke解码
            string str = HttpUtility.UrlDecode(http.Value, Encoding.GetEncoding("UTF-8"));
            //反序列化
            List<ViewModel> models = JsonConvert.DeserializeObject<List<ViewModel>>(str);
            foreach (var a in models)
            {
                park.UIDa = a.UIDa;
            }
            url += "Park/Add";
            string m = JsonConvert.SerializeObject(park);
            string i = HttpClientHeper.Post(url, m);
            if (Convert.ToInt32(i) > 0)
            {
                #region 语言播报
                ////获取进入车辆的车牌号
                //string phrase = Session["Plate"].ToString()+"欢迎进入";
                ////语言播报的功能
                //SpeechSynthesizer speech = new SpeechSynthesizer();
                //CultureInfo keyboardCulture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("zh-cn");
                //InstalledVoice neededVoice = speech.GetInstalledVoices(keyboardCulture).LastOrDefault();
                //if (neededVoice == null)
                //{
                //    phrase = "Unsupported Language";
                //}
                //else if (!neededVoice.Enabled)
                //{
                //    phrase = "Voice Disabled";
                //}
                //else
                //{
                //    speech.SelectVoice(neededVoice.VoiceInfo.Name);
                //}

                //speech.Speak(phrase);



                //// using System.Speech.Synthesis;
                //SpeechSynthesizer synth = new SpeechSynthesizer();
                //// Configure the audio output.   
                //synth.SetOutputToDefaultAudioDevice();

                //synth.Speak("请说一句话");
                //synth.Speak(Session["Plate"].ToString() + "欢迎进入");

                //// Speak a string.  
                //synth.Speak("This example demonstrates a basic use of Speech Synthesizer");

                //Console.WriteLine();
                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
                #endregion
                //MVC 
                SpVoice speech = new SpVoice();//new一个
                int speechRate = 1; //语音朗读速度
                int volume = 100; //音量
                bool paused = false;//是否暂停

                string testspeech = Session["Plate"].ToString() + "欢迎进入";//测试朗读内容

                if (paused)
                {
                    speech.Resume();
                    paused = false;
                }
                else
                {
                    speech.Rate = speechRate;
                    speech.Volume = volume;
                    speech.Speak(testspeech, SpeechVoiceSpeakFlags.SVSFlagsAsync);//开始语音朗读
                }
                #region 明细

                Recode recode = new Recode();
                string text = Session["Plate"].ToString() + "驶入汽车";
                recode.RName = text;
                List<ViewModel> modelsa = JsonConvert.DeserializeObject<List<ViewModel>>(str);
                foreach (var t in models)
                {
                    recode.FId = t.UIDa;
                }
                string urll= "http://localhost:6201/Recode/Add";
                string y = JsonConvert.SerializeObject(recode);
                string model = HttpClientHeper.Post(urll, y);
                if (Convert.ToInt32(model) > 0)
                {
                    Response.Redirect("");
                }
                #endregion



                Response.Write("<script>alert('驶入成功！');location.href='/USerInfo/Show'</script>");
            }
        }
        public void RecodeAdd(Recode recode)
        {
            
        }
        public void Away(int id)
        {
            url += "Park/Away";
            DateTime Leave = System.DateTime.Now;
            ParkInfoModel parks = new ParkInfoModel();
            parks.ExpireDate = Leave;
            parks.PID = id;
            string model = JsonConvert.SerializeObject(parks);
            string m = HttpClientHeper.Post(url, model);
            if (Convert.ToInt32(m) > 0)
            {
                //MVC 
                SpVoice speech = new SpVoice();//new一个
                int speechRate = 1; //语音朗读速度
                int volume = 100; //音量
                bool paused = false;//是否暂停

                string testspeech = "感谢车牌号为"+ Session["Plate"].ToString() + "的客户停车，祝您一路顺风";//测试朗读内容

                if (paused)
                {
                    speech.Resume();
                    paused = false;
                }
                else
                {
                    speech.Rate = speechRate;
                    speech.Volume = volume;
                    speech.Speak(testspeech, SpeechVoiceSpeakFlags.SVSFlagsAsync);//开始语音朗读
                }
                DateTime Puttime = parks.CreateDate;
                DateTime Gettime = parks.ExpireDate;
                TimeSpan a = Gettime - Puttime;
                double b = a.Minutes/60;
                int i = (int)Math.Ceiling(b);
                int ids =Convert.ToInt32( Session["TID"]);
                string urls = $"http://localhost:6201/CarType/CarSelectOne?id={ids}"  ;
                string o = HttpClientHeper.Get(urls);
                List<CarTypesInfoModel> list = JsonConvert.DeserializeObject< List<CarTypesInfoModel>>(o);
                decimal de = list.First().Tmaney;
                int price = Convert.ToInt32(de);
                int sum = i * price;
                Response.Write("<script>alert('谢谢您的本次停车！')</script>");
                Response.Redirect("http://localhost:7652/Payment/QRcode?text=" + sum);

            }
        }

    }
}