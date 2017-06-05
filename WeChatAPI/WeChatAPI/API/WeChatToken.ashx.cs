using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WeChatSDK.API.GetXmlModel;
using WeChatSDK.API.XmlModel;
using WeChatSDK.Helper;
using WeChatSDK.ToKen;
using WeChatSDK.ToKen.OauthSignature;
using WeChatSDK.WeChatLog;

namespace WeChatAPI.API
{
    /// <summary>
    /// WeChatToken1 的摘要说明
    /// </summary>
    public class WeChatToken1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //POST为微信发出消息
            if (context.Request.HttpMethod == "POST")
            {
                WeChatToKenApi api = new WeChatToKenApi();
                string WeChatXml = api.PostRequestString();
                LogTextHelper.Log(WeChatXml);
                context.Response.Write(ResponseMsg(WeChatXml));
            }
            else
            {
                WeChatSignature.Auth(WeChatConfig.Token);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 服务器响应微信请求
        /// </summary>
        /// <param name="WeChatXml"></param>
        public string ResponseMsg(string WeChatXml)
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
                        ManagerMsg = GetServicesMsg(Xml);
                        break;
                    //关注与取消关注
                    case "event":
                        ManagerMsg = GetEvenMsg(Xml);
                        break;
                    case "image":
                        ManagerMsg = GetServicesMsg(Xml);
                        break;
                    case "voice":
                        ManagerMsg = GetServicesMsg(Xml);
                        break;
                    case "vedio":
                        ManagerMsg = GetServicesMsg(Xml);
                        break;
                    case "location":
                        ManagerMsg = GetServicesMsg(Xml);
                        break;
                    case "link":
                        ManagerMsg = GetServicesMsg(Xml);
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
        private string GetEvenMsg(XmlElement Xml)
        {
            StringBuilder EvenXml = new StringBuilder();
            //获取事件Model
            XmlElementEven EvenModel = GetXmlElementEven.GetExmlModel(Xml);
            if (!string.IsNullOrEmpty(EvenModel.Event) && EvenModel.Event == "subscribe")
            {
                //订阅事件回复内容
                StringBuilder Content = new StringBuilder();
                Content.Append("您好，感谢关注！\n");
                Content.Append("我颠覆了整个天地，只为了摆正你的倒影。\n");
                Content.Append("我逆转了整个苍穹，只为了那天，遮不住你要睁开的双眼。\n");
                Content.Append("我轰开了无穷虚无，只为了打开一条路……让你找到回家的方向。");
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
            if (EvenModel.EventKey == "My_SuCai")
            {
                //图文消息
                ObjectTypeHelper type = new ObjectTypeHelper();
                int NowTime = type.ConvertDateTimeInt(DateTime.Now);
                EvenXml.Append("<xml>");
                EvenXml.Append("<ToUserName><![CDATA[" + EvenModel.FromUserName + "]]></ToUserName>");
                EvenXml.Append("<FromUserName><![CDATA[" + EvenModel.ToUserName + "]]></FromUserName>");
                EvenXml.Append("<CreateTime>" + NowTime + "</CreateTime>");
                EvenXml.Append("<MsgType><![CDATA[news]]></MsgType>");
                EvenXml.Append("<ArticleCount>2</ArticleCount>");
                EvenXml.Append("<Articles>");
                EvenXml.Append("<item>");
                EvenXml.Append("<Title><![CDATA[我是标题]]></Title> ");
                EvenXml.Append("<Description><![CDATA[我是描述]]></Description>");
                EvenXml.Append("<PicUrl><![CDATA[http://www.51fdc.com/imageshome/upload/201407170627106992.jpg]]></PicUrl>");
                EvenXml.Append("<Url><![CDATA[www.baidu.com]]></Url>");
                EvenXml.Append("</item>");
                EvenXml.Append("<item>");
                EvenXml.Append("<Title><![CDATA[我是二标题]]></Title> ");
                EvenXml.Append("<Description><![CDATA[我是二描述]]></Description>");
                EvenXml.Append("<PicUrl><![CDATA[http://img3.fengniao.com/forum/attachpics/851/67/34013207_1024.jpg]]></PicUrl>");
                EvenXml.Append("<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzI0NDQ3NDkwMQ==&mid=100000027&idx=1&sn=9dfc09b88f74a97c06420defe5b4e88d&chksm=695c74615e2bfd7709bae70c2edfc61ddcbbf392d4e62d2651ec85c1a84ed3c923946cded0c1&scene=18#wechat_redirect]]></Url>");
                EvenXml.Append("</item>");
                EvenXml.Append("</Articles>");
                EvenXml.Append("</xml>");
            }
            if (EvenModel.EventKey == "My_MediaId")
            {
                //图片消息
                ObjectTypeHelper type = new ObjectTypeHelper();
                int NowTime = type.ConvertDateTimeInt(DateTime.Now);
                EvenXml.Append("<xml>");
                EvenXml.Append("<ToUserName><![CDATA[" + EvenModel.FromUserName + "]]></ToUserName>");
                EvenXml.Append("<FromUserName><![CDATA[" + EvenModel.ToUserName + "]]></FromUserName>");
                EvenXml.Append("<CreateTime>" + NowTime + "</CreateTime>");
                EvenXml.Append("<MsgType><![CDATA[image]]></MsgType>");
                EvenXml.Append("<Image>");
                EvenXml.Append("<MediaId><![CDATA[dSqdqKXPv82mkBeBvf3kjePuRqHnOU1TLWsZs21XCjg]]></MediaId>");
                EvenXml.Append("</Image>");
                EvenXml.Append("</xml>");
            }
            if (EvenModel.EventKey == "My_Link")
            {
                //链接消息
                ObjectTypeHelper type = new ObjectTypeHelper();
                int NowTime = type.ConvertDateTimeInt(DateTime.Now);
                EvenXml.Append("<xml>");
                EvenXml.Append("<ToUserName><![CDATA[" + EvenModel.FromUserName + "]]></ToUserName>");
                EvenXml.Append("<FromUserName><![CDATA[" + EvenModel.ToUserName + "]]></FromUserName>");
                EvenXml.Append("<CreateTime>" + NowTime + "</CreateTime>");
                EvenXml.Append("<MsgType><![CDATA[link]]></MsgType>");
                EvenXml.Append("<Title><![CDATA[公众平台官网链接]]></Title>");
                EvenXml.Append("<Description><![CDATA[公众平台官网链接]]></Description>");
                EvenXml.Append("<Url><![CDATA[www.baidu.com]]></Url>");
                EvenXml.Append("<MsgId>6349021361213152058</MsgId>");
                EvenXml.Append("</xml>");
            }
            return EvenXml.ToString();
        }
        /// <summary>
        /// 自动回复消息
        /// </summary>
        /// <param name="xmlMsg"></param>
        private string GetTextMsg(XmlElement Xml)
        {
            //自动回复消息
            StringBuilder Content = new StringBuilder();
            Content.Append("您好，我是小怪机器人！");
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
            TextXml.Append("<MsgId>" + TextModel.MsgId + "</MsgId>");
            TextXml.Append("</xml>");

            LogTextHelper.Log(TextXml.ToString());
            return TextXml.ToString();
        }

        /// <summary>
        /// 自动回复消息
        /// </summary>
        /// <param name="xmlMsg"></param>
        private string GetServicesMsg(XmlElement Xml)
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
            TextXml.Append("<MsgType><![CDATA[transfer_customer_service]]></MsgType>");
            TextXml.Append("</xml>");
            return TextXml.ToString();
        }

    }
}