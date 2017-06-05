using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WeChatManager.API.XmlModel;

namespace WeChatManager.API.GetXmlModel
{
    public class GetXmlMsgType
    {
        public static XmlMsgType GetExmlModel(XmlElement Xml)
        {
            XmlMsgType xmlModel = new XmlMsgType()
            {
                MsgType = Xml.SelectSingleNode("MsgType").InnerText,
            };
            return xmlModel;
        }
    }
}