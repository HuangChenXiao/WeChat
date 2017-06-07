using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WeChatSDK.Helper;

namespace WeChatSDK.Menu
{
    public class MenuManager
    {
        /// <summary>
        /// 用AccessToken和JSON字符来创建公众号菜单
        /// </summary>
        /// <param name="AccessToken">获取的access_token</param>
        /// <param name="data">菜单</param>
        public void WeChatCreateMenu(string data) 
        {
            GetMenu(WeChatContext.Access_Token);
            CreateMenu(WeChatContext.Access_Token, data);
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        public static string GetMenu(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", AccessToken);
            return WeChatUtility.GetData(url);
        }
        /// <summary>
        /// 创建菜单
        /// </summary>
        public static void CreateMenu(string AccessToken,string menu)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", AccessToken);
            WeChatUtility.SendHttpRequest(url, menu);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        public static void DeleteMenu(string AccessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", AccessToken);
            WeChatUtility.GetData(url);
        }
    }
}