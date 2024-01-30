namespace socket_4;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static readonly HttpClient client = new();
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter ID to fetch a post:");
            string id = Console.ReadLine() ?? "";

            string responseBody = await GetPostAsync(id);
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine("Error: {0}", error.Message);
        }
    }

    static async Task<string> GetPostAsync(string id)
    {
        string url = $"https://jsonplaceholder.typicode.com/posts/{id}";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
}
