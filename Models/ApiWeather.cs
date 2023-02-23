﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Models
{
    internal class ApiWeather
    {
        public class Rootobject
        {
            [JsonPropertyName("cod")]
            public string Cod { get; set; }

            [JsonPropertyName("message")]
            public int Message { get; set; }

            [JsonPropertyName("cnt")]
            public int Cnt { get; set; }

            [JsonPropertyName("list")]
            public List[] List { get; set; }

            [JsonPropertyName("city")]
            public City City { get; set; }
        }

        public class City
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("coord")]
            public Coord Coord { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("population")]
            public int Population { get; set; }

            [JsonPropertyName("timezone")]
            public int Timezone { get; set; }

            [JsonPropertyName("sunrise")]
            public int Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public int Sunset { get; set; }
        }

        public class Coord
        {
            [JsonPropertyName("lat")]
            public float Lat { get; set; }

            [JsonPropertyName("lon")]
            public float Lon { get; set; }
        }

        public class List
        {
            [JsonPropertyName("dt")]
            public int Dt { get; set; }

            [JsonPropertyName("main")]
            public Main Main { get; set; }

            [JsonPropertyName("weather")]
            public Weather[] Weather { get; set; }

            [JsonPropertyName("clouds")]
            public Clouds Clouds { get; set; }

            [JsonPropertyName("wind")]
            public Wind Wind { get; set; }

            [JsonPropertyName("visibility")]
            public int Visibility { get; set; }

            [JsonPropertyName("pop")]
            public float Pop { get; set; }

            [JsonPropertyName("snow")]
            public Snow Snow { get; set; }

            [JsonPropertyName("sys")]
            public Sys Sys { get; set; }

            [JsonPropertyName("dt_txt")]
            public string DtTxt { get; set; }
        }

        public class Main
        {
            [JsonPropertyName("temp")]
            public float Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public float FeelsLike { get; set; }

            [JsonPropertyName("temp_min")]
            public float TempMin { get; set; }

            [JsonPropertyName("temp_max")]
            public float TempMax { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("sea_level")]
            public int SeaLevel { get; set; }

            [JsonPropertyName("grnd_level")]
            public int GrndLevel { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("temp_kf")]
            public float TempKf { get; set; }
        }

        public class Clouds
        {
            [JsonPropertyName("all")]
            public int All { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public float Speed { get; set; }

            [JsonPropertyName("deg")]
            public int Deg { get; set; }

            [JsonPropertyName("gust")]
            public float Gust { get; set; }
        }

        public class Snow
        {
            [JsonPropertyName("_3h")]
            public float ThreeHour { get; set; }
        }

        public class Sys
        {
            [JsonPropertyName("pod")]
            public string Pod { get; set; }
        }

        public class Weather
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

    }
}
