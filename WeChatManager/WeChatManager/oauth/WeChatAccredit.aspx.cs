using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatSDK.Helper;
using WeChatSDK.oAuth;

namespace WeChatManager.oauth
{
    public partial class WeChatAccredit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string Code = Request.QueryString["code"].ToString();
                WeChatoAuth oauth = new WeChatoAuth();
                OAuth_Token Model = oauth.Get_Token(WeChatConfig.AppId, WeChatConfig.AppSecret, Code);
                OAuthUser OAuthUser_Model = oauth.Get_UserInfo(Model.access_token, Model.openid);
            }

        }
    }
}