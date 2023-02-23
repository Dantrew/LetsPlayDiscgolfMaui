using LetsPlayDiscgolfMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal class StartPageViewModel
    {
        public static async Task<ApiWeather.Rootobject> GetWeather()
        {

            var client = new HttpClient();

            var apiKey = "e891df354648de9d76f64bd2fc483f7e";
            var city = "London";    //Get weather from
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
            // https://pro.openweathermap.org/data/2.5/forecast/hourly?q={city}&appid={apiKey}
            //https://pro.openweathermap.org/data/2.5/forecast/hourly?q=London&appid=e891df354648de9d76f64bd2fc483f7e

            ApiWeather.Rootobject weather = null;

            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                weather = JsonSerializer.Deserialize<ApiWeather.Rootobject>(content);
                //Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Failed to get weather data. Error: {response.ReasonPhrase}");
            }

            return weather;

        }
    }
}
