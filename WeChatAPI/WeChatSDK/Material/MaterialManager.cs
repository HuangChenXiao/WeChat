using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatSDK.Helper;

namespace WeChatSDK.Material
{
    public class MaterialManager
    {
        /// <summary>
        /// 获取素材列表
        /// </summary>
        /// <param name="type">素材的类型，图片（image）、视频（video）、语音 （voice）、图文（news）</param>
        /// <param name="offset">从全部素材的该偏移位置开始返回，0表示从第一个素材 返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        /// <returns></returns>
        public string batchget_material(string type, int offset, int count)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}", WeChatContext.Access_Token);
            string a = "{\"type\":\"" + type + "\",\"offset\":" + offset + ",\"count\":" + count + "}";
            return WeChatUtility.SendHttpRequest(url, a);
        }
    }
}
