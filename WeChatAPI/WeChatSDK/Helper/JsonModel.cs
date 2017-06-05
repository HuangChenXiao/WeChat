using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WeChatSDK.Helper
{
    public class JsonModel
    {
        public int status { get; set; }
        public string msg { get; set; }
        public string data { get; set; }

        public static string GetJson(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            return returnText;
        }
    }
}
