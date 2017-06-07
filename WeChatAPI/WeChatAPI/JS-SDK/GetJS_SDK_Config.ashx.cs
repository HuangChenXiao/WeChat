using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WxPayAPI;
using Newtonsoft.Json;
using WeChatSDK.Helper;
using WeChatSDK.WeChatLog;
using System.Text;

namespace WeChatAPI.JS_SDK
{
    /// <summary>
    /// GetJS_SDK_Config 的摘要说明
    /// </summary>
    public class GetJS_SDK_Config : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request["action"];
            switch (action)
            {
                case "SDK_Config":
                    SDK_Config(context);
                    break;
                case "SDK_Pay":
                    SDK_Pay(context);
                    break;
            }


        }
        private static void SDK_Pay(HttpContext context)
        {
            JS_SDKModel model = new JS_SDKModel();
            try
            {
                var total_fee =Convert.ToInt32(Math.Round(Convert.ToDecimal(context.Request["total_fee"]),2)*100);
                var openid = context.Request["openid"];
                WxPayData jsApiParam = new WxPayData();
                //构造需要用SHA1算法加密的数据
                WxPayData data = new WxPayData();
                data.SetValue("body", "test");
                data.SetValue("attach", "test");
                data.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());
                data.SetValue("total_fee", total_fee);
                data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
                data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
                data.SetValue("goods_tag", "test");
                data.SetValue("trade_type", "JSAPI");
                data.SetValue("openid", openid);

                WxPayData result = WxPayApi.UnifiedOrder(data);


                model.appId = WeChatConfig.AppId;
                WxPayData signData = new WxPayData();
                signData.SetValue("appId", model.appId);
                signData.SetValue("timeStamp", WxPayApi.GenerateTimeStamp());
                signData.SetValue("nonceStr", WxPayApi.GenerateNonceStr());
                signData.SetValue("package", "prepay_id=" + result.GetValue("prepay_id").ToString());
                signData.SetValue("signType", "MD5");
                signData.SetValue("paySign", signData.MakeSign());

                model.nonceStr = signData.GetValue("nonceStr").ToString();
                model.package = signData.GetValue("package").ToString();
                model.paySign = signData.GetValue("paySign").ToString();
                model.timeStamp = signData.GetValue("timeStamp").ToString();
                model.status = 1;
                model.msg = "成功";
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.msg = ex.Message;
            }
            context.Response.Write(JsonConvert.SerializeObject(model));
        }
        private static void SDK_Config(HttpContext context)
        {
            JS_SDKModel model = new JS_SDKModel();
            try
            {
                var windowurl = context.Request["windowurl"];
                var action = context.Request["action"];
                LogTextHelper.Log("action:" + action + " windowurl:" + windowurl + "post:" + context.Request["windowurl"]);
                WxPayData jsApiParam = new WxPayData();
                model.appId = WeChatConfig.AppId;
                model.timeStamp = WxPayApi.GenerateTimeStamp();
                model.nonceStr = WxPayApi.GenerateNonceStr();
                model.ticket = string.Empty;
                //获取jsapi_ticket
                if (HttpRuntime.Cache["JsApiTicket"] == null)
                {
                    model.ticket = WxPayApi.initJSAPITicket();
                }
                model.ticket = HttpRuntime.Cache["JsApiTicket"] as string;
                if (string.IsNullOrEmpty(model.ticket))
                {
                    model.ticket = WxPayApi.initJSAPITicket();
                }
                //构造需要用SHA1算法加密的数据
                WxPayData signData = new WxPayData();
                signData.SetValue("noncestr", model.nonceStr);
                signData.SetValue("jsapi_ticket", model.ticket);
                signData.SetValue("timestamp", model.timeStamp);
                signData.SetValue("url", windowurl);
                string param = signData.ToUrl();
                model.signature = FormsAuthentication.HashPasswordForStoringInConfigFile(param, "SHA1");
                
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.msg =ex.Message;
                LogTextHelper.Log(ex.ToString());
            }
            context.Response.Write(JsonConvert.SerializeObject(model));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}