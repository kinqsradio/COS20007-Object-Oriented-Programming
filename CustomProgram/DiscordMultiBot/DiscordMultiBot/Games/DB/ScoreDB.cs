using DiscordMultiBot.Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games.DB
{
    public class ScoreDB : DB
    {
        public void RegisterGameData(Player player = null, GameBot ai = null)
        {
            if (player != null)
            {
                string playerId = player.Id.ToString();
                string playerResult = player.GameResult;
                bool isRegistered = IsUserDataRegistered(playerId);

                if (isRegistered)
                    UpdateUserData(playerId, playerResult);
                else
                {
                    CreateUserData(playerId);
                    UpdateUserData(playerId, playerResult);
                }
            }

            if (ai != null)
            {
                string aiId = ai.Id.ToString();
                string aiResult = ai.Result;
                bool isRegistered = IsUserDataRegistered(aiId);

                if (isRegistered)
                    UpdateUserData(aiId, aiResult);
                else
                {
                    CreateUserData(aiId);
                    UpdateUserData(aiId, aiResult);
                }
            }
        }

        private void CreateUserData(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                string sqlString = $"insert into ScoreList(userId, wins, losses, ties)" +
                                   $"values('{userId}', 0, 0, 0)";

                ExecuteSql(sqlString);
            }
            else
            {
                Console.WriteLine("Something went wrong. Player data could not be created in database.");
            }
        }

        private void UpdateUserData(string userId, string result)
        {
            PlayerDB member = FetchPreviousResults(userId);

            if (member != null)
            {
                int winss = member.Wins;
                int lossess = member.Losses;
                int tiess = member.Ties;

                if (result == "win")
                    winss++;
                else if (result == "loss")
                    lossess++;
                else
                    tiess++;

                string sqlUpdate = $"UPDATE ScoreList SET wins = {winss}, losses = {lossess}, ties = {tiess} WHERE userId = {userId}";
                ExecuteSql(sqlUpdate);
            }
            else
            {
                Console.WriteLine("Something went wrong. Player data could not be updated in database.");
            }
        }

        private bool IsUserDataRegistered(string userId)
        {
            if (string.IsNullOrEmpty(GetId("SELECT * from ScoreList WHERE userId = " + userId)))
                return false;

            return true;
        }

    }
}