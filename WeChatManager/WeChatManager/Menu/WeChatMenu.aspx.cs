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

namespace WeChatManager.Menu
{
    public partial class WeChatMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuManager m = new MenuManager();
            FileStream fs = new FileStream(Server.MapPath("") + @"\menu.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string data = sr.ReadToEnd();
            m.WeChatCreateMenu(data);
            fs.Dispose();
            sr.Dispose();
        }
    }
}