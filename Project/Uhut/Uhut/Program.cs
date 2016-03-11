using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using CommonLibrary.Web;
using log4net;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Net;

namespace Uhut
{
    class Program
    {
        private static ILog _logger = LogHandler.GetLogger("RegLog");
        private static int IntervalSecond = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntervalSecond"]);
        private static string RegPwd = System.Configuration.ConfigurationManager.AppSettings["RegPwd"];
        private static string PHPSESSID = System.Configuration.ConfigurationManager.AppSettings["PHPSESSID"];
        private static string ChannelID = System.Configuration.ConfigurationManager.AppSettings["ChannelID"];
        private static string Biztp = System.Configuration.ConfigurationManager.AppSettings["Biztp"];
        
        
        private static string Channel = "market38";

        static void Main(string[] args)
        {
            try
            {

                //uname=15616267087; PHPSESSID=vih0ctvdq28fvn8hc3rpmkc163; Hm_lvt_7d9bd6c6ed64a642886e05279f95b983=1457322717; Hm_lpvt_7d9bd6c6ed64a642886e05279f95b983=1457342589
                //cookie.Add(new System.Uri("http://mall.uhut.com"), new Cookie("SessionID", "vih0ctvdq28fvn8hc3rpmkc163"));
                string a = System.Environment.CurrentDirectory;
                DataSet DS = ExcelHelper.Excel2010ToDS(System.Environment.CurrentDirectory + "/Excel/RegList.xlsx");
                if (DS.Tables[0].Rows.Count > 0)
                {
                    _logger.Debug("请求开始，一共：" + DS.Tables[0].Rows.Count.ToString());
                    Console.WriteLine("请求开始，一共：" + DS.Tables[0].Rows.Count.ToString());
                    for (int i = 0; i < DS.Tables[0].Rows.Count; i++)//DS.Tables[0].Rows.Count
                    {
                        try
                        {
                            CookieContainer cookie = new CookieContainer();
                            cookie.Add(new System.Uri("http://mall.uhut.com"), new Cookie("PHPSESSID", PHPSESSID));
                            cookie.Add(new System.Uri("http://mall.uhut.com"), new Cookie("uname", "15616267087"));
                            cookie.Add(new System.Uri("http://mall.uhut.com"), new Cookie("Hm_lvt_7d9bd6c6ed64a642886e05279f95b983", "1457322717"));
                            cookie.Add(new System.Uri("http://mall.uhut.com"), new Cookie("Hm_lpvt_7d9bd6c6ed64a642886e05279f95b983", "1457342589"));

                            Thread.Sleep(IntervalSecond * 1000);  // 1000为一秒

                            string name = DS.Tables[0].Rows[i][0].ToString();
                            string regResponse = "失败";
                            string SendMsg = SendMsgRequest(name, ref cookie);
                            if (SendMsg == "1")
                            {
                                var regCode = GetHtml(name);//GetSendMsgRequest(name);
                                if (regCode == "nodatamsgcontentValue")//重发
                                {
                                    Thread.Sleep(IntervalSecond * 1000);  // 1000为一秒
                                    SendMsg = SendMsgRequest(name, ref cookie);
                                    if (SendMsg == "1")
                                    {
                                        regCode = GetHtml(name);
                                    }
                                }
                                regResponse = RegRequest(name, regCode, ref cookie);
                            }
                            else
                            {
                                _logger.Debug("短信发送失败Name：" + name);
                            }
                            Console.WriteLine("请求Name：" + name + " 结果:" + regResponse);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("请求异常：" + e.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("请求异常：" + ex.Message);
            }
            Console.ReadLine();
        }

        static string GetSendMsgRequest(string Name)
        {
            string formUrl = "http://123.56.230.202:8080/ReceiveSMS";
            string formData = string.Format("channelid={0}&dest={1}&biztp={2}&n", ChannelID, Name, Biztp);
            //string formData = "channelid=tiyu-e5b0-4fb9-b21c-0a6933bcd423-ty-34-16&dest=" + Name + "&biztp=999&n";

            return RequestHelper.SendRequest(formUrl, formData, "POST");
        }

        static string GetHtml(string Name)
        {
            string formUrl = string.Format("http://123.56.230.202:8080/ReceiveSMS?channelid={0}&dest={1}&biztp={2}&n", ChannelID, Name, Biztp);
            return RequestHelper.GetHtml(formUrl);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="regCode"></param>
        /// <returns></returns>
        static string RegRequest(string Name, string regCode)
        {
            string formUrl = "http://mall.uhut.com/phone/reg/ajcheck";
            string formData = "regName=" + Name + "&regPwd=" + RegPwd + "&regCode=" + regCode + "&channel=" + Channel;

            RegResult res = JsonConvert.DeserializeObject<RegResult>(RequestHelper.SendRequest(formUrl, formData, "POST"));
            var result = JsonConvert.SerializeObject(res);
            _logger.Debug("请求：Name" + Name + " regCode:" + regCode + " 结果:" + result);
            return JsonConvert.SerializeObject(result);
        }

        static string GetHtml(string Name, ref CookieContainer cookie)
        {
            string formUrl = "http://123.56.230.202:8080/ReceiveSMS";
            //string formData = "channelid=tiyu-e5b0-4fb9-b21c-0a6933bcd423-ty-34-16&dest=" + Name + "&biztp=999&n";

            string formData = string.Format("channelid={0}&dest={1}&biztp={2}&n", ChannelID, Name, Biztp);
            return RequestHelper.SendDataByGET(formUrl, formData, ref cookie);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="regCode"></param>
        /// <returns></returns>
        static string RegRequest(string Name, string regCode, ref CookieContainer cookie)
        {
            string formUrl = "http://mall.uhut.com/phone/reg/ajcheck";
            string formData = "regName=" + Name + "&regPwd=" + RegPwd + "&regCode=" + regCode + "&channel=" + Channel;

            RegResult res = JsonConvert.DeserializeObject<RegResult>(RequestHelper.SendDataByGET(formUrl, formData, ref cookie));
            
            var result = JsonConvert.SerializeObject(res);
            cookie = null;
            _logger.Debug("请求Name：" + Name + " regCode: " + regCode + " 结果: " + result);
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        static string SendMsgRequest(string Name)
        {
            string formUrl = "http://mall.uhut.com/phone/reg/sendPay";
            string formData = "mobile=" + Name;
            RegResult res = JsonConvert.DeserializeObject<RegResult>(RequestHelper.SendRequest(formUrl, formData, "POST"));

            return res.status;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        static string SendMsgRequest(string Name, ref CookieContainer cookie)
        {
            string formUrl = "http://mall.uhut.com/phone/reg/sendPay";
            string formData = "mobile=" + Name;

            RegResult res = JsonConvert.DeserializeObject<RegResult>(RequestHelper.SendDataByGET(formUrl, formData, ref cookie));
            //RegResult res = JsonConvert.DeserializeObject<RegResult>(RequestHelper.SendRequest(formUrl, formData, "POST"));

            return res.status;
        }
    }

    public class RegResult
    {
        public string status { get; set; }
        public string msg { get; set; }
    }
}
