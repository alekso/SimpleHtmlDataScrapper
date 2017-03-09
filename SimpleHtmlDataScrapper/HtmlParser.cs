using CsQuery;
using System.Collections.Generic;

namespace SimpleHtmlDataScrapper
{
    class HtmlParser
    {
        static string featuresHtmlCssPath = "div#pfcSummary>table>tbody tr";
        static string titleCssContainer = "span.summaryPrompt";
        static string contentCssContainer = "span.summaryContent";

        static string minorFeaturesCssPath = "ul.mfcList li";

        public static Dictionary<string, string> ExtractFeatures(CQ dom)
        {
            var features = new Dictionary<string, string>();


            var tr = dom[featuresHtmlCssPath];

            tr.Each(e =>
            {
                var title = e.Cq().Find(titleCssContainer).Text();
                var content = e.Cq().Find(contentCssContainer).Text();

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
                {
                    features.Add(title.Trim(), content.Trim());
                }
            });

            return features;
        }

        public static List<string> ExtractMinorFeatures(CQ dom)
        {
            var minorFeatures = new List<string>();
            var ul = dom[minorFeaturesCssPath];

            ul.Each(e =>
            {
                var content = e.Cq().Find("span").Text();
                if (!string.IsNullOrEmpty(content))
                {
                    minorFeatures.Add(content.Trim());
                }
            });

            return minorFeatures;
        }
    }
}
