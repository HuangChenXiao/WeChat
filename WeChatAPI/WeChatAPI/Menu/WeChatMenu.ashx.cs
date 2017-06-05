using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatSDK.Helper;
using WeChatSDK.Menu;

namespace WeChatAPI.Menu
{
    /// <summary>
    /// WeChatMenu1 的摘要说明
    /// </summary>
    public class WeChatMenu1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var path = context.Server.MapPath("");
            MenuManager m = new MenuManager();
            FileStream fs = new FileStream(path + @"\menu.json", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string data = sr.ReadToEnd();
            m.WeChatCreateMenu(data);
            fs.Dispose();
            sr.Dispose();
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