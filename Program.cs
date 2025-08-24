using System;




class Program
{

    private static readonly HttpClient client = new HttpClient();
    async static Task Main(string[] args)
    {
        Console.WriteLine("Fetching Data from the API....");

        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}