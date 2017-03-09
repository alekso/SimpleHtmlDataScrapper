using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace SimpleHtmlDataScrapper
{
    class WebService
    {
        static RestClient client;

        public static string SimplePostWithSession(string url, List<KeyValuePair<string, string>> payload)
        {
            client = new RestClient(url);
            GetSession();
            var request = new RestRequest(Method.POST);

            payload.ForEach(k =>
                   request.AddParameter(
                       k.Key.ToString(), k.Value.ToString()
           ));

            var response = client.Execute(request);
            var html = response.Content.Trim();

            return html;
        }

        static void GetSession()
        {
            client.CookieContainer = new CookieContainer();
            var req = new RestRequest(Method.GET);
            var res = client.Execute(req);
        }
    }
}
