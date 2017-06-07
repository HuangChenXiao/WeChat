using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatManager.Helper;

namespace WeChatManager.WeChatTemplate
{
    public partial class TemplateSendMsg1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //读取文本
            //FileStream fs1 = new FileStream(Server.MapPath(".") + "\\sendmsg.txt", FileMode.Open);
            //StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("UTF-8"));
            //string data = sr.ReadToEnd();
            //sr.Close();
            //fs1.Close();

            Api_set_industry1(GetJsonString1());
        }

        public string GetJsonString1()
        {
            TemplateMsg p = new TemplateMsg();
            p.touser = "oJ7qFxLKREZ8yrP7CUu50dqvQ3Po";
            p.template_id = "U_JdsVFjPtK0ak6CpWhW34_N6kZCQFhx7z9tKpHX5bo";
            p.url = "";
            p.data = new TemplateDtlMsg 
            {
                first = new FirstMsg { value = "恭喜你购买成功", color="#173177" },
                keyword1 = new Keyword1Msg { value = "巧克力", color = "#173177" },
                keyword2 = new Keyword2Msg { value = "39.8元", color = "#173177" },
                keyword3 = new Keyword3Msg { value = "2014年9月22日", color = "#173177" },
            };
            return new JavaScriptSerializer().Serialize(p);
        }

        /// <summary>
        /// 调用模板ID直接向用户发送中奖消息
        /// </summary>
        public static void Api_set_industry1(string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}&", WxContext.AccessToken);
            HttpWxUtility.SendHttpRequest(url, data);
        }
    }
}