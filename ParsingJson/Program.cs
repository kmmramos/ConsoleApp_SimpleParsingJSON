using System;
using Newtonsoft.Json;

namespace ParsingJson
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/typicode/demo/posts";
            //am http client to send the get request
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                //read the string from the response's content
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //print the jsonResponse
                Console.WriteLine(jsonResponse);

                //deserialize the json response into a C# array of type Post[]
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                //print the array objects using a foreach loop
                foreach (var post in myPosts)
                {
                    Console.WriteLine($"{post.Id} {post.Title}");
                }
            }
            catch (Exception e)
            {

                //throw;
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Dispose of the httpClient
                httpClient.Dispose();
            }
        }
    }
}