using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WeChatSDK;
using WeChatSDK.Helper;
using WeChatSDK.Material;
using WeChatSDK.WeChatLog;

namespace WeChatAPI
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaterialManager m = new MaterialManager();
            m.batchget_material("image",0,1);
        }

    }
}