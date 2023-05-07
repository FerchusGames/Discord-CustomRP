using System.Net.Http;
using HtmlAgilityPack;

namespace CustomRPC
{
    public class WebPageHelper
    {
        public static string GetFirstImageUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send a GET request to the webpage
                HttpResponseMessage response = client.GetAsync(url).Result;

                // Read the response content as a string
                string htmlContent = response.Content.ReadAsStringAsync().Result;

                // Create an HtmlDocument object with the webpage content
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                // Find the first image tag in the HTML
                HtmlNode imgTag = doc.DocumentNode.SelectSingleNode("//img");

                if (imgTag != null)
                {
                    // Extract the 'src' attribute of the image tag
                    string imgUrl = imgTag.GetAttributeValue("src", "");
                    return imgUrl;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}