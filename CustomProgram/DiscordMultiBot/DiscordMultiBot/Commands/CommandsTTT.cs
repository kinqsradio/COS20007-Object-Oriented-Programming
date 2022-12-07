using DiscordMultiBot.Games;
using DiscordMultiBot.Games.DB;
using DiscordMultiBot.Games.Models;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Commands
{
    public class CommandsTTT : BaseCommandModule
    {
        [Command("ttt")]
        [Description("This is a Single and Multiplayer TicTacToe Game\n Player vs Player - type: \" " +
            "@Multibot ttt @DiscordUser\"\nPlayer vs A.I - type: \"@Multibot ttt @DiscordBot difficulty\"")]
        public async Task TicTacToeGame(CommandContext ctx, string userMention, string diff = "")
        {
            DiscordMember playerTwo = null;

            List<DiscordMember> dmList = await GetMemberList(ctx);

            await Task.WhenAny(GetMemberList(ctx));
            GameEmoji.InitEmoji(ctx);


            // Checks if the member that has been @'d is a member of the channel and if it is a bot. 
            foreach (DiscordMember discordMember in dmList)
            {
                if (userMention.Contains(discordMember.Id.ToString()) && discordMember.IsBot)
                {
                    playerTwo = discordMember;

                    if (string.IsNullOrEmpty(diff))
                    {
                        string message = "Please select a difficult level:\n1. Easy\n2. Medium\n3. Hard\nExample command: @Multibot ttt @Multibot 1";
                        var newMessage = Factory.Instance().InstantiateMessage(message);
                        DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
                    }
                    else
                    {
                        //difficulty = difficulty.ToLower();
                        int difficulty = Convert.ToInt32(diff);

                        SingleplayerGame sp = new SingleplayerGame(ctx, playerTwo, difficulty);
                        await sp.BeginSingleplayerGame();
                    }
                }

                else if (userMention.Contains(discordMember.Id.ToString()))
                {
                    playerTwo = discordMember;
                    MultiplayerGame mp = new MultiplayerGame(ctx, playerTwo);
                    await mp.BeginMultiplayerGame();
                }
            }

            if (playerTwo == null)
                await ctx.Channel.SendMessageAsync("Player not found");
        }


        // Returns the list of all members
        public async Task<List<DiscordMember>> GetMemberList(CommandContext ctx)
        {
            List<DiscordMember> memberList = await Task.Run(() => ctx.Channel.Users.ToList());

            return new List<DiscordMember>(memberList);
        }
        ScoreDB sdb = new ScoreDB();

        [Command("score")]
        public async Task Score(CommandContext ctx, string userMention = null)
        {
            if (!string.IsNullOrEmpty(userMention))
            {
                string userMentionParsed =
                    userMention.Replace("<", "").Replace(">", "").Replace("@", "").Replace("!", "");
                Console.WriteLine(userMentionParsed);
                PlayerDB player = sdb.FetchPreviousResults(userMentionParsed);

                if (!string.IsNullOrEmpty(player.UserId))
                {
                    string message =
                        $"{userMention}'s stats:\nWins: {player.Wins}\nLosses: {player.Losses}\nTies {player.Ties}";
                    var newMessage = Factory.Instance().InstantiateMessage(message);
                    DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
                }
                else
                {
                    string message = "The requested user is not yet registered in the Database. Play at least one game for the data to be registered.";
                    var newMessage = Factory.Instance().InstantiateMessage(message);
                    DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
                }


            }
            else
            {
                string memberId = ctx.Member.Id.ToString();
                Console.WriteLine(memberId);

                PlayerDB player = sdb.FetchPreviousResults(memberId);
                if (!string.IsNullOrEmpty(player.UserId))
                {
                    string message =
                        $"{ctx.Member.Mention}'s stats:\nWins: {player.Wins}\nLosses: {player.Losses}\nTies {player.Ties}";

                    var newMessage = Factory.Instance().InstantiateMessage(message);
                    DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
                }
                else
                {
                    string message = "The requested user is not yet registered in the Database. Play at least one game for the data to be registered.";
                    var newMessage = Factory.Instance().InstantiateMessage(message);
                    DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: newMessage).ConfigureAwait(false);
                }
            }
        }
    }
}
