using LetsPlayDiscgolfMaui.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPlayDiscgolfMaui.Database
{
    internal class DataBase
    {
        public static async Task<IMongoCollection<User>> GetCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Dalovian:GqpXvG5hhjJKU4Io@cluster0.den2h0u.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DiscPlayers");
            var myCollection = database.GetCollection<User>("DiscGolfPlayers");

            return myCollection;
        }
        public static async Task SavePlayer(User player, IMongoCollection<User> discPlayers)
        {
            await discPlayers.InsertOneAsync(player);
            //await Task.Delay(2000);
            Console.WriteLine("Player saved!");
        }
        public static async Task<List<Models.User>> GetAllPlayers(IMongoCollection<Models.User> discPlayers)
        {
            var allMovies = await discPlayers.AsQueryable().ToListAsync();
            Task.Delay(2000).Wait();
            Console.WriteLine("Movies fetched!");
            return allMovies;
        }

        //public static async Task<Models.User> GetPlayerUserName(IMongoCollection<Models.User> discPlayers, string userName)
        //{

        //    var player = await discPlayers.AsQueryable().Where(x => x.UserName.ToLower() == userName.ToLower()).SingleOrDefaultAsync();

        //    return player;
        //}

        public static User CompareUserNameToPassword(IMongoCollection<User> discPlayers, string playerName, string passWord)
        {

            var player = discPlayers.AsQueryable().Where(x => x.UserName.ToLower() == playerName.ToLower() && x.Password == passWord).FirstOrDefault();
            //await Task.Delay(2000);  //.Wait();

            return player;
        }
    }
}
