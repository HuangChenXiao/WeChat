using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WeChatManager.API.XmlModel;

namespace WeChatManager.API.GetXmlModel
{
    public class GetXmlElementText
    {
        /// <summary>
        /// 消息文本获取model
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public static XmlElementText GetExmlModel(XmlElement Xml)
        {
            XmlElementText xmlModel = new XmlElementText()
            {
                FromUserName = Xml.SelectSingleNode("FromUserName").InnerText,
                ToUserName = Xml.SelectSingleNode("ToUserName").InnerText,
                CreateTime = Xml.SelectSingleNode("CreateTime").InnerText,
                MsgType = Xml.SelectSingleNode("MsgType").InnerText,
                Content = Xml.SelectSingleNode("Content").InnerText,
                MsgId = Xml.SelectSingleNode("MsgId").InnerText,
            };
            return xmlModel;
        }
    }
}