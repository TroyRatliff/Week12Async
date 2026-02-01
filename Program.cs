using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching Pokémon...\n");

        using HttpClient client = new HttpClient();

        // Call the PokéAPI and use await
        string url = "https://pokeapi.co/api/v2/pokemon";
        string response = await client.GetStringAsync(url);

        // Deserialize JSON response from api
        PokemonResponse? pokemonData = JsonSerializer.Deserialize<PokemonResponse>(response);

        if (pokemonData?.results == null)
        {
           Console.WriteLine("Failed to load Pokémon data.");
            return;
        }

        // Display Pokémon names in a list
        foreach (var pokemon in pokemonData.results)
        {
            Console.WriteLine(pokemon.name);
        }

        Console.WriteLine("\nHere's a list of Pokemon!");
    }
}

// Models
public class PokemonResponse
{
    public List<Pokemon>? results { get; set; }
}

public class Pokemon
{
    public string? name { get; set; }
    public string? url { get; set; }
}
