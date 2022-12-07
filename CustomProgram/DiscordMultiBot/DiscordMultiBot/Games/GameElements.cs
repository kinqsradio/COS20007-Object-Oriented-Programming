using DiscordMultiBot.Games.DB;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class GameElements
    {
        public bool Active = true;
        public string ActivePlayer;
        public bool Multiplayer;
        public string Winner;
        public int Turn;
        ScoreDB sdb = new ScoreDB();


        // Creates an embedded message with the game board. 
        public DiscordEmbedBuilder CreatePlayBoard(List<Square> board)
        {
            string descriptionString = $"";
            string bottomMessage = $"\n\n";
            DiscordEmbedBuilder newEmbed;

            for (int i = 0; i < board.Count; i++)
            {
                descriptionString += $"{i + 1} " + board[i].SquareEmoji + "    ";
                if (i == 2 || i == 5)
                    descriptionString += "\n\n";
            }

            // Result message
            if (Active)
                bottomMessage += $"{ActivePlayer} turn";

            else if (Active == false && !string.IsNullOrEmpty(Winner))
                bottomMessage += $"Winner: {Winner}";

            else if (Active == false && string.IsNullOrEmpty(Winner))
            {
                Winner = "tie";
                bottomMessage += $"Tie";
            }

            // Displays embed based on MP or SP
            if (Multiplayer)
            {
                newEmbed = new DiscordEmbedBuilder
                {
                    Title = EmbedDefaults.Title,
                    Description = EmbedDefaults.PlayerAndEmoji + "\n\n" +
                                  descriptionString + bottomMessage,
                    Color = DiscordColor.Red
                };
            }
            else
            {
                newEmbed = new DiscordEmbedBuilder
                {
                    Title = EmbedDefaults.Title,
                    Description = EmbedDefaults.PlayerAndEmoji + "\n\n" +
                                  descriptionString + bottomMessage,
                    Color = DiscordColor.Blue
                };
            }

            return newEmbed;
        }

        // Adds prefixed reactions to the embed.
        public async Task AddReactions(DiscordMessage embed)
        {
            foreach (DiscordEmoji discordEmoji in GameEmoji.OneThroughNine())
                await embed.CreateReactionAsync(discordEmoji);
        }

        // Removes the emoji that has been recently selected by a player or AI
        public async Task RemoveChoice(DiscordMessage embed, DiscordEmoji demoji)
        {
            await embed.DeleteReactionsEmojiAsync(demoji).ConfigureAwait(false);
        }

        // Updates the grid with Emoji and value.
        public async Task UpdateBoard(List<Square> board, DiscordMessage embed, DiscordEmoji demoji, DiscordEmoji playerEmoji, int playerValue)
        {
            for (int i = 0; i < 9; i++)
            {
                if (demoji == GameEmoji.OneThroughNine()[i])
                {
                    board[i].SquareEmoji = playerEmoji;
                    board[i].SquareNumber = playerValue;
                }
            }

            await embed.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayBoard(board))).ConfigureAwait(false);
        }

        // Checks if the player or AI has met the win conditions
        public void CheckWinCondition(string playerName, List<Square> board)
        {
            // Horizontal row 1
            /* Example condition if X wins:
            _X_|_X_|_X_
            ___|___|___
            ___|___|___
            */
            if (board[0].SquareNumber == board[1].SquareNumber && board[1].SquareNumber == board[2].SquareNumber && board[0].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Horizontal row 2
            /*Example condition if X wins:
            ___|___|___
            _X_|_X_|_X_
            ___|___|___
            */
            if (board[3].SquareNumber == board[4].SquareNumber && board[4].SquareNumber == board[5].SquareNumber && board[3].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Horizontal row 3
            /*Example condition if X wins:
            ___|___|___
            ___|___|___
            _X_|_X_|_X_
            */
            if (board[6].SquareNumber == board[7].SquareNumber && board[7].SquareNumber == board[8].SquareNumber && board[6].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Vertical row 1
            /*Example condition if X wins:
            _X_|___|___
            _X_|___|___
            _X_|___|___
            */
            if (board[0].SquareNumber == board[3].SquareNumber && board[3].SquareNumber == board[6].SquareNumber && board[0].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Vertical row 2
            /*Example condition if X wins:
            ___|_X_|___
            ___|_X_|___
            ___|_X_|___
            */
            if (board[1].SquareNumber == board[4].SquareNumber && board[4].SquareNumber == board[7].SquareNumber && board[1].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Vertical row 3
            /*Example condition if X wins:
            ___|___|_X_
            ___|___|_X_
            ___|___|_X_
            */
            if (board[2].SquareNumber == board[5].SquareNumber && board[5].SquareNumber == board[8].SquareNumber && board[2].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Diagonal row 1
            /*Example condition if X wins:
            _X_|___|___
            ___|_X_|___
            ___|___|_X_
            */
            if (board[0].SquareNumber == board[4].SquareNumber && board[4].SquareNumber == board[8].SquareNumber && board[0].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            // Diagonal row 2
            /*Example condition if X wins:
            ___|___|_X_
            ___|_X_|___
            _X_|___|___
            */
            if (board[2].SquareNumber == board[4].SquareNumber && board[4].SquareNumber == board[6].SquareNumber && board[2].SquareNumber != 0)
            {
                Winner = playerName;
                Active = false;
            }

            if (board[0].SquareNumber != 0 && board[1].SquareNumber != 0 && board[2].SquareNumber != 0 &&
                board[3].SquareNumber != 0 && board[4].SquareNumber != 0 && board[5].SquareNumber != 0 &&
                board[6].SquareNumber != 0 && board[7].SquareNumber != 0 && board[8].SquareNumber != 0)
            {
                Active = false;
            }
        }

        public void RegisterInDatabase(Player p1, Player p2 = null, GameBot ai = null)
        {
            if (p2 == null)
            {
                sdb.RegisterGameData(p1, null);
                sdb.RegisterGameData(null, ai);
            }
            else
            {
                sdb.RegisterGameData(p1, null);
                sdb.RegisterGameData(p2, null);
            }
        }
    }
}