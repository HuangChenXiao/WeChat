using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatAPI.JS_SDK
{
    public class JS_SDKModel
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 公众号APPID
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 生成签名的时间戳
        /// </summary>
        public string timeStamp { get; set; }
        /// <summary>
        /// 生成随机串，随机串包含字母或数字
        /// </summary>
        public string nonceStr { get; set; }
        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 构造需要用SHA1算法加密的数据随机串
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
        /// </summary>
        public string package { get; set; }
        /// <summary>
        /// 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
        /// </summary>
        public string signType { get; set; }
        /// <summary>
        /// 支付签名
        /// </summary>
        public string paySign { get; set; }
    }
}