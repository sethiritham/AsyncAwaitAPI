using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

public class Todo
{
    public int userId { get; set; }
    public int Id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }


}

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
            Todo myTodo = JsonSerializer.Deserialize<Todo>(responseBody);
            Console.WriteLine("Deserialized STRING....");
            Console.WriteLine(myTodo.userId);
            Console.WriteLine(myTodo.completed);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
