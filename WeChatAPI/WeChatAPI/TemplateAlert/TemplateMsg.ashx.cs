using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatSDK.Helper;
using WeChatSDK.TemplateAlert;
using WeChatSDK.TemplateAlert.Model;


namespace WeChatAPI.TemplateAlert
{
    /// <summary>
    /// TemplateMsg 的摘要说明
    /// </summary>
    public class TemplateMsg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            TemplatePurchaseNotice notice = new TemplatePurchaseNotice();
            string Msg = notice.TemplateSendMsg(GetJsonString()).errmsg;
            context.Response.Write("<script>alert('" + Msg + "')</script>");
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}