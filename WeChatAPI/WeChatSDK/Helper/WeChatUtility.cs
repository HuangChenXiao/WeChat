using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Text;

namespace WeChatSDK.Helper
{
    public static class WeChatUtility
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static string GetData(string url)
        {
            return SendGetHttpRequest(url, "application/x-www-form-urlencoded");
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static string PostData(string url)
        {
            return SendPostHttpRequest(url, "application/x-www-form-urlencoded");
        }
        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string SendHttpRequest(string url, string data)
        {
            return SendPostHttpRequest(url, "application/x-www-form-urlencoded", data);
        }
        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="contentType">请求类型</param>
        /// <param name="requestData">请求数据</param>
        /// <returns>返回资源字符串</returns>
        public static string SendPostHttpRequest(string url, string contentType, string requestData)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            byte[] postBytes = null;
            request.ContentType = contentType;
            postBytes = Encoding.UTF8.GetBytes(requestData);
            request.ContentLength = postBytes.Length;
            using (Stream outstream = request.GetRequestStream())
            {
                outstream.Write(postBytes, 0, postBytes.Length);
            }
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }

                }
            }
            return result;
        }
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="ContentType">请求类型</param>
        /// <returns>返回资源字符串</returns>
        public static string SendGetHttpRequest(string url, string ContentType)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = ContentType;
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="ContentType">请求类型</param>
        /// <returns>返回资源字符串</returns>
        public static string SendPostHttpRequest(string url, string ContentType)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = ContentType;
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
    }
}