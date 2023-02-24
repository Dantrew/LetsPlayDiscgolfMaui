using LetsPlayDiscgolfMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.ViewModels
{
    internal class GamePageViewModel
    {
        public ApiWeather.Rootobject Weather { get; set; }
        public ApiWeather.List GetWeatherDescription { get; set; }
        public GamePageViewModel()
        {
            var weather = Task.Run(GetWeather);
            weather.Wait();
            Weather = weather.Result;


            
        }
        public static async Task<ApiWeather.Rootobject> GetWeather()
        {

            var client = new HttpClient();

            var apiKey = "e891df354648de9d76f64bd2fc483f7e";
            var city = "London";    //Get weather from
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q=nyk%C3%B6ping,se&appid=e891df354648de9d76f64bd2fc483f7e";

            ApiWeather.Rootobject weather = null;

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<ApiWeather.Rootobject>(responseString);
                //Console.WriteLine(content);
            }
            else
            {
                
            }

            return weather;

        }
    }
}
