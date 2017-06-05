using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatManager.API.XmlModel
{
    public class XmlElementEven
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 消息类型，event
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// 时间KEY
        /// </summary>
        public string EventKey { get; set; }
    }
}