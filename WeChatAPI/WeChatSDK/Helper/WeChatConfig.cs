using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeChatSDK.Helper
{
    public class WeChatConfig
    {
        /// <summary>
        /// Token令牌
        /// </summary>
        public static string Token = ConfigurationManager.AppSettings["Token"];
        /// <summary>
        /// EncodingAESKey(消息加解密密钥)
        /// </summary>
        public static string EncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];
        /// <summary>
        /// appid，应用ID， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppId = ConfigurationManager.AppSettings["AppId"];
        /// <summary>
        /// appsecret ，应用密钥， 在微信公众平台中 “开发者中心”栏目可以查看到
        /// </summary>
        public static string AppSecret = ConfigurationManager.AppSettings["AppSecret"];
        /// <summary>
        /// 支付商户号
        /// </summary>
        public static string MCHID = ConfigurationManager.AppSettings["MCHID"];
        /// <summary>
        /// 支付KEY
        /// </summary>
        public static string KEY = ConfigurationManager.AppSettings["KEY"];
    }
}