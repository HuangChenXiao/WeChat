using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSDK.TemplateAlert.Model
{

    public class TemplateMainMsg
    {
        public string touser { get; set; }
        public string template_id { get; set; }
        public string url { get; set; }

        public TemplateDtlMsg data { get; set; }
    }
    public class TemplateDtlMsg
    {
        public FirstMsg first { get; set; }
        public Keyword1Msg keyword1 { get; set; }
        public Keyword2Msg keyword2 { get; set; }
        public Keyword3Msg keyword3 { get; set; }
    }
    public class FirstMsg
    {
        public string value { get; set; }
        public string color { get; set; }
    }
    public class Keyword1Msg
    {
        public string value { get; set; }
        public string color { get; set; }
    }
    public class Keyword2Msg
    {
        public string value { get; set; }
        public string color { get; set; }
    }
    public class Keyword3Msg
    {
        public string value { get; set; }
        public string color { get; set; }
    }
}