using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class MultiplayerGame : GameElements
    {
        
        private Player p1;
        private Player p2;
        private Board board;
        private CommandContext ctx;

        public MultiplayerGame(CommandContext context, DiscordMember playerTwo)
        {
            ctx = context;
            p1 = new Player(ctx.Member.Id, ctx.Member.DisplayName, GameEmoji.X);
            p2 = new Player(playerTwo.Id, playerTwo.DisplayName, GameEmoji.O);
            board = new Board(GameEmoji.Field);
        }

        // Initates multiplayer game
        public async Task BeginMultiplayerGame()
        {
            Multiplayer = true;
            EmbedDefaults.SetEmbedDefaultsMP(p1, p2);

            ActivePlayer = p1.Name;

            // Creates and sends the embed that is used as the gameboard
            DiscordEmbedBuilder gameBoard = CreatePlayBoard(board.GameBoard);

            DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: gameBoard).ConfigureAwait(false);
            await AddReactions(embedMessage);

            // Loops the game until the game is over.
            while (Active)
            {
                await MakeMove(embedMessage);
                Turn++;
            }

            SetWinnerStatus(p1, p2);
            await embedMessage.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayBoard(board.GameBoard))).ConfigureAwait(false);
            await embedMessage.DeleteAllReactionsAsync();
            RegisterInDatabase(p1, p2, null);


        }

        // Waits for the player1 to make a move - after it will wait for player 2
        public async Task MakeMove(DiscordMessage embed)
        {
            if (Active)
            {
                InteractivityResult<MessageReactionAddEventArgs> reactionResultp1 = await InteractivityResult(p1.Id, embed);

                ActivePlayer = p2.Name;
                await RemoveChoice(embed, reactionResultp1.Result.Emoji);
                await UpdateBoard(board.GameBoard, embed, reactionResultp1.Result.Emoji, p1.PlayerEmoji, 1);
                if (Turn >= 2)
                    CheckWinCondition(p1.Name, board.GameBoard);
            }

            if (Active)
            {
                InteractivityResult<MessageReactionAddEventArgs> reactionResultp2 = await InteractivityResult(p2.Id, embed);

                ActivePlayer = p1.Name;
                await RemoveChoice(embed, reactionResultp2.Result.Emoji);
                await UpdateBoard(board.GameBoard, embed, reactionResultp2.Result.Emoji, p2.PlayerEmoji, 2);
                if (Turn >= 2)
                    CheckWinCondition(p2.Name, board.GameBoard);
            }
        }

        // Captures the users selected emoji returns it.
        private async Task<InteractivityResult<MessageReactionAddEventArgs>> InteractivityResult(ulong id, DiscordMessage embed)
        {
            var interactivity = ctx.Client.GetInteractivity();
            return await interactivity.WaitForReactionAsync(
                x => x.Message == embed &&
                     x.User.Id == id && GameEmoji.OneThroughNine().Contains(x.Emoji)).ConfigureAwait(false);
        }

        private void SetWinnerStatus(Player player1, Player player2)
        {
            if (Winner == player1.Name)
            {
                player1.SetGameResult("win");
                player2.SetGameResult("loss");
            }
            else if (Winner == player2.Name)
            {
                player2.SetGameResult("win");
                player1.SetGameResult("loss");
            }
            else
            {
                player1.SetGameResult("tie");
                player2.SetGameResult("tie");
            }
        }
    }
}
