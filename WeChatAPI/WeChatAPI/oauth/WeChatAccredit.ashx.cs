using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatSDK.Helper;
using WeChatSDK.oAuth;

namespace WeChatAPI.oauth
{
    /// <summary>
    /// WeChatAccredit1 的摘要说明
    /// </summary>
    public class WeChatAccredit1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["code"]))
            {
                string Code = context.Request.QueryString["code"].ToString();
                WeChatoAuth oauth = new WeChatoAuth();
                OAuth_Token Model = oauth.Get_Token(WeChatConfig.AppId, WeChatConfig.AppSecret, Code);
                OAuthUser OAuthUser_Model = oauth.Get_UserInfo(Model.access_token, Model.openid);
                context.Response.Write(JsonConvert.SerializeObject(OAuthUser_Model));
            }
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