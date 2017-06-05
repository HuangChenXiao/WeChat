using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeChatSDK.Helper;

namespace WeChatSDK
{
    public class WeChatContext
    {
        /// <summary>
        /// 存取Token时间
        /// </summary>
        private static DateTime GetAccessToken_Time;
        /// <summary>
        /// 过期时间
        /// </summary>
        private static int Expires_Period = 7200;
        /// <summary>
        /// 存取Token
        /// </summary>
        private static string mAccessToken;

        public static string Access_Token
        {
            get
            {
                if (string.IsNullOrEmpty(mAccessToken) || HasExpired())
                {
                    mAccessToken = GetAccessToken(WeChatConfig.AppId, WeChatConfig.AppSecret);
                }
                return mAccessToken;
            }
        }
        public static string GetAccessToken(string AppId, string AppSecret)
        {
            //根据AppId跟Secret来获取access_token
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
            string result = WeChatUtility.GetData(url);
            OAuth_Token omodel = JsonHelper.ParseFromJson<OAuth_Token>(result);
            if (omodel != null)
            {
                GetAccessToken_Time = DateTime.Now;
                Expires_Period = Convert.ToInt32(omodel.expires_in);
                return omodel.access_token;
            }
            return null;
        }
        /// <summary>
        /// 判断token是否过期
        /// </summary>
        /// <returns></returns>
        private static bool HasExpired()
        {
            if (GetAccessToken_Time != null)
            {
                if (DateTime.Now > GetAccessToken_Time.AddSeconds(Expires_Period).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }

    }
}