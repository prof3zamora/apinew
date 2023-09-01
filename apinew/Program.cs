// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    //RequestUri = new Uri("https://pokedex2.p.rapidapi.com/pokedex/usa/pikachu"),
    /*Headers =
    {
        { "X-RapidAPI-Key", "8b612b5078msheef33a9277fb744p1dbfddjsne0206765bd88" },
        { "X-RapidAPI-Host", "pokedex2.p.rapidapi.com" },
    },*/
    RequestUri = new Uri("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0")
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    string body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
    JObject jsonObject = JsonConvert.DeserializeObject<JObject>(body);

    JArray resultsArray = (JArray)jsonObject["results"];

    foreach (JObject result in resultsArray)
    {
        string nombre = (string)result["name"];

        Console.WriteLine($"Nombre: {nombre}");
    }
}

