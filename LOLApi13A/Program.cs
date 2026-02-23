
using LOLApi13A.models;
using System.Text.Json;

namespace LOLApi13A
{
    public class Program
    {
        public static string version = "1.0";
        public static List<Champion> champions = new List<Champion>();
        static async Task Main(string[] args)
        {
            await LoadVersion();
            Console.WriteLine(version);
            await LoadChampions();

        }
        public static async Task LoadChampions(string language ="en_US")
        {
            try
            {

                using(HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    string url = $"https://ddragon.leagueoflegends.com/cdn/{version}/data/{language}/champion.json";
                    ;
                    var responseAPI = await client.GetStringAsync(url);
                    var response = JsonSerializer.Deserialize<ChampionData>(responseAPI);
                    champions = response.Data.Values.ToList();
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Kapcsolódási hiba: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON feldolgozási hiba: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

        public static async Task LoadVersion()
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    string url = "https://ddragon.leagueoflegends.com/api/versions.json";
                    var responseAPI = await client.GetStringAsync(url);
                    string[] response = JsonSerializer.Deserialize<string[]>(responseAPI);
                     version = response[0];
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Kapcsolódási hiba: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON feldolgozási hiba: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }
        
    }
}
