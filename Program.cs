using System.Net.Http;

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
                HttpResponseMessage response = await client.GetAsync(Url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                
                return responseBody;
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


        


        static void Main(string[] args)
        {
        // // Setting up data as to not spam
        // String htmlFromSite = getFromUrl("https://da.wikipedia.org/wiki/Flodhest").Result;
        // writeStringToFile("temp_data/flodhest_wiki.txt", htmlFromSite);

        

        Console.WriteLine(readStringFromFile("flodhest_wiki.txt"));

        }

    }
}


