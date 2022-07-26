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

        static void Main(string[] args)
        {
        // Car Ford = new Car();  // Create an object of the Car Class (this will call the constructor)
        // Console.WriteLine(Ford.model);  // Print the value of model



        String htmlFromSite = getFromUrl("http://www.casperfaerch.com").Result;

        Console.WriteLine(htmlFromSite);


        }

    }
}


