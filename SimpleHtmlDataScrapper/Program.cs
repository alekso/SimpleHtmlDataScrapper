using CsQuery;
using System;
using System.Collections.Generic;

namespace SimpleHtmlDataScrapper
{
    class Program
    {
        static string _address = "http://www.etis.ford.com//vehicleSelection.do";
        static CQ dom;

        static void Main(string[] args)
        {
            var html = MakeRequest();
            dom = CQ.Create(html);
            var features = HtmlParser.ExtractFeatures(dom);
            var minorFeatures = HtmlParser.ExtractMinorFeatures(dom);

            PrintFeatures(features);
            PrintMinorFeatures(minorFeatures);

            Console.ReadKey();
        }
        static string MakeRequest()
        {
            var fields = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("vin", "X9FPXXEEDPAR25608"),
                    new KeyValuePair<string, string>("lookupType","vin"),
                };

            var html = WebService.SimplePostWithSession(_address, fields);

            return html;
        }

        static void PrintFeatures(Dictionary<string, string> features)
        {

            Console.WriteLine("Features: ");

            foreach (var item in features)
            {
                Console.WriteLine("{0}\t{1}", item.Key, item.Value);
            }
        }

        static void PrintMinorFeatures(List<string> minorFeatures)
        {

            Console.WriteLine("Minor Features: ");

            foreach (var item in minorFeatures)
            {
                Console.WriteLine(" - {0}", item.ToString());
            }
        }
    }
}
