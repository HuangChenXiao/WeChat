using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeChatSDK.Helper;

namespace WeChatSDK.Service
{
    public class WeChatService
    {
        private void service_list()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token=" + WeChatContext.Access_Token;
            string JsonData = WeChatUtility.GetData(url);
            
        }
        private void service_add(string kf_account, string nickname)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/add?access_token=" + WeChatContext.Access_Token;
            account ac = new account();
            ac.kf_account = kf_account + "@gh_19fb3de6e41f";
            ac.nickname = nickname;
            string SendJson = new JavaScriptSerializer().Serialize(ac);
            string JsonData = WeChatUtility.SendHttpRequest(url, SendJson);
           
        }
        /// <summary>
        /// 绑定客服
        /// </summary>
        /// <param name="context"></param>
        private void service_binding(string kf_account, string invite_wx)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/inviteworker?access_token=" + WeChatContext.Access_Token;
            account ac = new account();
            ac.kf_account = kf_account;
            ac.invite_wx = invite_wx;
            string SendJson = new JavaScriptSerializer().Serialize(ac);
            string JsonData = WeChatUtility.SendHttpRequest(url, SendJson);
        }
        /// <summary>
        /// 设置客服信息
        /// </summary>
        /// <param name="context"></param>
        private void service_edit(string kf_account, string nickname)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/update?access_token=" + WeChatContext.Access_Token;
            account ac = new account();
            ac.kf_account = kf_account;
            ac.nickname = nickname;
            string SendJson = new JavaScriptSerializer().Serialize(ac);
            string JsonData = WeChatUtility.SendHttpRequest(url, SendJson);
        }
        /// <summary>
        /// 删除客服信息
        /// </summary>
        /// <param name="context"></param>
        private void service_del(string kf_account)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/del?access_token=" + WeChatContext.Access_Token + "&kf_account=" + kf_account;
            account ac = new account();
            ac.kf_account = kf_account;
            string SendJson = new JavaScriptSerializer().Serialize(ac);
            string JsonData = WeChatUtility.SendHttpRequest(url, SendJson);
        }
    }
}
