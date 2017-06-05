using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSDK.Helper
{
    public class OAuth_Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
}