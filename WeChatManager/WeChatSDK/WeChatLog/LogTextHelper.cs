using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatSDK.WeChatLog
{
    public static class LogTextHelper
    {
        public static void Log(string msg)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            if (!Directory.Exists(Path + @"\WeChatLog\"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Path + @"\WeChatLog\");
                directoryInfo.Create();
            }
            string Serviceslog = Path + @"\WeChatLog\Log——" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            StreamWriter sw2 = File.AppendText(Serviceslog);
            string w2 = "";
            if (!string.IsNullOrEmpty(msg))
            {
                w2 = msg + "\r\n" + DateTime.Now + "\r\n\r\n";
            }
            sw2.Write(w2);
            sw2.Close();
        }
    }
}