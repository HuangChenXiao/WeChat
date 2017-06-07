using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WeChatSDK.API.XmlModel;

namespace WeChatSDK.API.GetXmlModel
{
    public static class GetXmlElementEven
    {
        /// <summary>
        /// 关注，取消关注获取model
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public static XmlElementEven GetExmlModel(XmlElement Xml)
        {
            XmlElementEven xmlModel = new XmlElementEven()
            {
                FromUserName = Xml.SelectSingleNode("FromUserName").InnerText,
                ToUserName = Xml.SelectSingleNode("ToUserName").InnerText,
                CreateTime = Xml.SelectSingleNode("CreateTime").InnerText,
                MsgType = Xml.SelectSingleNode("MsgType").InnerText,
                Event = Xml.SelectSingleNode("Event").InnerText,
                EventKey = Xml.SelectSingleNode("EventKey").InnerText
            };
            return xmlModel;
        }
    }
}