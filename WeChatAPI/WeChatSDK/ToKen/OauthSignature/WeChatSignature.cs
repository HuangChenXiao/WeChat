using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WeChatSDK.Helper;
using WeChatSDK.WeChatLog;

namespace WeChatSDK.ToKen.OauthSignature
{
    public static class WeChatSignature
    {
        /// <summary>
        /// 成为开发者的第一步，验证并相应服务器的数据
        /// </summary>
        public static void Auth(string Token)
        {
            string token = Token;//从配置文件获取Token
            if (string.IsNullOrEmpty(token))
            {
                LogTextHelper.Log(string.Format("WeixinToken 配置项没有配置！"));
            }

            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echoString))
                {
                    HttpContext.Current.Response.Write(echoString);
                    HttpContext.Current.Response.End();
                }
            }
        }
        /// <summary>
        /// 验证微信签名
        /// </summary>
        public static bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] ArrTmp = { token, timestamp, nonce };

            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}