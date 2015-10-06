using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebCrawler.Engine
{
    public class WebCrawler
    {
        public bool GetUrlDetails(string myUri)
        {
            var webRequest = WebRequest.Create(myUri);
            var webResponse = webRequest.GetResponse();

            var streamResponse = webResponse.GetResponseStream();
            if (streamResponse == null) return false;
            var streamReader = new StreamReader(streamResponse);
            var stream = streamReader.ReadToEnd();
            var item = GetContent(stream);
            return false;
        }

        private string GetContent(string pageString)
        {
            var list = new List<LinkItem>();
            var matchCollection = Regex.Matches(pageString, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

            foreach (Match match in matchCollection)
            {
                var val = match.Groups[1].Value;
                var i = new LinkItem();

                var m2 = Regex.Match(val, @"href=\""(.*?)\""", RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                string t = Regex.Replace(val, @"\s*<.*?>\s*", "",
                RegexOptions.Singleline);
                i.Text = t;

                list.Add(i);
            }
            return string.Empty;
        }

        public class LinkItem
        {
            public string Href;
            public string Text;

            public override string ToString()
            {
                return Href + "\n\t" + Text;
            }
        }
    }
}