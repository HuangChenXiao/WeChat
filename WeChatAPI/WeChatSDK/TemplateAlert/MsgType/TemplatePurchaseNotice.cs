using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeChatSDK.Helper;
using WeChatSDK.TemplateAlert.Model;

namespace WeChatSDK.TemplateAlert
{
    public class TemplatePurchaseNotice
    {
        /// <summary>
        /// 公众号像用户推送消息
        /// </summary>
        /// <param name="AccessToken">公众号的AccessToken</param>
        /// <param name="data">具体的消息内容为JSON格式</param>
        /// <returns></returns>
        public errInfo TemplateSendMsg(string data)
        {
            //读取模版的JSON
            string strjson = Api_set_industry(WeChatContext.Access_Token, data);
            //获取返回的Model   ok为成功
            errInfo json = JsonHelper.ParseFromJson<errInfo>(strjson);
            return json;
        }

        /// <summary>
        /// 购买通知模板
        /// </summary>
        /// <returns></returns>
        public string GetJsonString()
        {
            TemplateMainMsg p = new TemplateMainMsg();
            //用户OPENID
            p.touser = "oJ7qFxLKREZ8yrP7CUu50dqvQ3Po";
            //模板ID
            p.template_id = "U_JdsVFjPtK0ak6CpWhW34_N6kZCQFhx7z9tKpHX5bo";
            p.url = "";
            p.data = new TemplateDtlMsg
            {
                first = new FirstMsg { value = "恭喜你购买成功", color = "#173177" },
                keyword1 = new Keyword1Msg { value = "巧克力", color = "#173177" },
                keyword2 = new Keyword2Msg { value = "39.8元", color = "#173177" },
                keyword3 = new Keyword3Msg { value = "2014年9月22日", color = "#173177" },
            };
            return new JavaScriptSerializer().Serialize(p);
        }

        /// <summary>
        /// 调用模板ID直接向用户发送中奖消息
        /// </summary>
        public static string Api_set_industry(string AccessToken, string data)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}&", AccessToken);
            return WeChatUtility.SendHttpRequest(url, data);
        }
    }
}
