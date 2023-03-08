﻿using LetsPlayDiscgolfMaui.Models;
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
        //----------------------------------------------------ROUNDS DATABASE-----------------------------------------
        public static async Task<IMongoCollection<GameInfo>> GetRoundsCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Dalovian:GqpXvG5hhjJKU4Io@cluster0.den2h0u.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("DiscPlayers");
            var myCollection = database.GetCollection<GameInfo>("Rounds");

            return myCollection;
        }

        public static async Task SaveRound(GameInfo gameinfo, IMongoCollection<GameInfo> discPlayers)
        {
            await discPlayers.InsertOneAsync(gameinfo);
        }
        public static List<GameInfo> GetRoundsPlayed(IMongoCollection<GameInfo> getRounds, string userName)
        {
            var player = getRounds.AsQueryable().Where(x => x.UserName.ToLower() == userName.ToLower()).ToList();
            return player;
        }


        //----------------------------------------------------USER DATABASE-----------------------------------------
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
        }

        public static async Task<User> CheckUserName(IMongoCollection<User> discPlayers, string userName)
        {

            var player = discPlayers.AsQueryable().Where(x=>x.UserName.ToLower() == userName.ToLower()).SingleOrDefault();

            return player;
        }

        public static async Task<User> CheckUserEmail(IMongoCollection<User> discPlayers, string email)
        {

            var player = discPlayers.AsQueryable().Where(x => x.Email.ToLower() == email.ToLower()).SingleOrDefault();

            return player;
        }
        public static User CompareUserNameToPassword(IMongoCollection<User> discPlayers, string playerName, string passWord)
        {
            var player = discPlayers.AsQueryable().Where(x => x.UserName.ToLower() == playerName.ToLower() && x.Password == passWord).FirstOrDefault();
            return player;
        }
    }
}
