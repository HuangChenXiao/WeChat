using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatSDK.Helper;

namespace WeChatSDK.oAuth
{
    public class WeChatoAuth
    {
        /// <summary>
        /// 根据Code来获取ToKen
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public OAuth_Token Get_Token(string AppId, string AppSecret, string Code)
        {
            string Str = JsonModel.GetJson(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",AppId,AppSecret,Code));
            OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
            return Oauth_Token_Model;
        }
        /// <summary>
        /// 根据access_token和OPENID来获取用户信息
        /// </summary>
        /// <param name="REFRESH_TOKEN"></param>
        /// <param name="OPENID"></param>
        /// <returns></returns>
        public OAuthUser Get_UserInfo(string Access_Token, string OpenId)
        {
            string Str = JsonModel.GetJson(string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", Access_Token, OpenId));

            OAuthUser OAuthUser_Model = JsonHelper.ParseFromJson<OAuthUser>(Str);
            return OAuthUser_Model;
        }
    }
}
