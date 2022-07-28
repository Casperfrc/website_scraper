using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using HtmlAgilityPack;

namespace Program
{
    class Scraper
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        public static async Task<String> getFromUrl(String Url)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try	
            {
                // Creating client and calling URL asynchronously
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(Url);
                
                return response;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ", e.Message);

                return "Message :{0} " + e.Message;
            }
        }


        public static async void writeStringToFile(String fileName, String customString)
        {
            await File.WriteAllTextAsync(fileName, customString);
        }


        public static String readStringFromFile(String fileName)
        {
            return System.IO.File.ReadAllText(@"C:\coding_projects\C#_training\website_scraper\temp_data\" + fileName);
        }


        //public static String[] getHtmlElementByTag(){
        public static List<string> getHtmlElementByTag(String html, String tag){
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            List<HtmlNode> htmlNodes = htmlDoc.DocumentNode
                .SelectNodes("//" + tag)
                .ToList();

            List<string> listOfTexts = new List<string>(htmlNodes.Select(x => x.InnerText));


            return listOfTexts;
        }
        


        static void Main(string[] args)
        {
        // // Setting up data as to not spam
        //String html = getFromUrl("https://da.wikipedia.org/wiki/Flodhest").Result;
        // writeStringToFile("temp_data/flodhest_wiki.txt", html);

        
        String html = readStringFromFile("flodhest_wiki.txt");

        List<string> result = getHtmlElementByTag(html, "p");

        Console.WriteLine("Amount of p tag texts: " + result.Count());
        Console.WriteLine("First p tag text: " + result[0]);
        

        }

    }
}


