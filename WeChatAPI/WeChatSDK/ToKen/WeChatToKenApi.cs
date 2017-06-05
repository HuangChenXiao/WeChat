using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using WeChatSDK.API.GetXmlModel;
using WeChatSDK.API.XmlModel;
using WeChatSDK.Helper;
using WeChatSDK.ToKen;
using WeChatSDK.WeChatLog;

namespace WeChatSDK.ToKen
{
    public class WeChatToKenApi
    {
        /// <summary>
        /// 获取post请求数据
        /// </summary>
        /// <returns></returns>
        public string PostRequestString()
        {
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            return Encoding.UTF8.GetString(b);
        }
        /// <summary>
        /// 服务器响应微信请求
        /// </summary>
        /// <param name="WeChatXml"></param>
        public string ResponseMsg(string WeChatXml,StringBuilder Content)
        {
            //定义消息管理
            string ManagerMsg = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                //读取xml字符串
                doc.LoadXml(WeChatXml);
                XmlElement Xml = doc.DocumentElement;
                //获取收到的消息类型。文本(text)，图片(image)，语音等
                XmlMsgType xmlModel = GetXmlMsgType.GetExmlModel(Xml);
                switch (xmlModel.MsgType)
                {
                    //当消息为文本时
                    case "text":
                        ManagerMsg = GetTextMsg(Xml, Content);
                        break;
                    case "event":
                        //关注与取消关注
                        ManagerMsg = GetEvenMsg(Xml, Content);
                        break;
                    case "image":
                        break;
                    case "voice":
                        break;
                    case "vedio":
                        break;
                    case "location":
                        break;
                    case "link":
                        break;
                    default:
                        break;
    
                }
            }
            catch (Exception e)
            {
                LogTextHelper.Log("异常消息：" + e.Message);
            }
            return ManagerMsg;
        }
        /// <summary>
        /// 关注/取消关注事件
        /// </summary>
        /// <param name="Xml"></param>
        /// <returns></returns>
        public string GetEvenMsg(XmlElement Xml, StringBuilder Content)
        {
            StringBuilder EvenXml =new StringBuilder();
            //获取事件Model
            XmlElementEven EvenModel = GetXmlElementEven.GetExmlModel(Xml);
            if (!string.IsNullOrEmpty(EvenModel.Event) && EvenModel.Event == "subscribe")
            {
                ObjectTypeHelper type = new ObjectTypeHelper();
                int NowTime = type.ConvertDateTimeInt(DateTime.Now);
                EvenXml.Append("<xml>");
                EvenXml.Append("<ToUserName><![CDATA[" + EvenModel.FromUserName + "]]></ToUserName>");
                EvenXml.Append("<FromUserName><![CDATA[" + EvenModel.ToUserName + "]]></FromUserName>");
                EvenXml.Append("<CreateTime>" + NowTime + "</CreateTime>");
                EvenXml.Append("<MsgType><![CDATA[text]]></MsgType>");
                EvenXml.Append("<Content><![CDATA[" + Content.ToString() + "]]></Content>");
                EvenXml.Append("<FuncFlag>0</FuncFlag>");
                EvenXml.Append("</xml>");
            }
            return EvenXml.ToString();
        }
        /// <summary>
        /// 文本消息
        /// </summary>
        /// <param name="xmlMsg"></param>
        public string GetTextMsg(XmlElement Xml,StringBuilder Content)
        {
            //获取事件Model
            XmlElementText TextModel = GetXmlElementText.GetExmlModel(Xml);
            ObjectTypeHelper obj = new ObjectTypeHelper();
            int NowTime = obj.ConvertDateTimeInt(DateTime.Now);
            StringBuilder TextXml = new StringBuilder();
            TextXml.Append("<xml>");
            TextXml.Append("<ToUserName><![CDATA[" + TextModel.FromUserName + "]]></ToUserName>");
            TextXml.Append("<FromUserName><![CDATA[" + TextModel.ToUserName + "]]></FromUserName>");
            TextXml.Append("<CreateTime>" + NowTime + "</CreateTime>");
            TextXml.Append("<MsgType><![CDATA[text]]></MsgType>");
            TextXml.Append("<Content><![CDATA[" + Content.ToString() + "]]></Content>");
            TextXml.Append("<FuncFlag>0</FuncFlag>");
            TextXml.Append("</xml>");
            return TextXml.ToString();
        }
    }
}