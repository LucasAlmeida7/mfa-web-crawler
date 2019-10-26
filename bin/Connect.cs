
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;

namespace CrawlerConsultaRAB {
    public class Connect
    {        
        Utils _utils = new Utils();

        public HtmlDocument RequestGET(Uri url)
        {
            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = false;

            HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
            string html = new StreamReader(webResponse.GetResponseStream(), EncodingInfo.UTF7).ReadToEnd();
            HtmlDocument htmlDoc = _utils.ParseToHtmlDocument(html);

            return htmlDoc;
        }
    }    
}
