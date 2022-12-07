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
    public class SingleplayerGame : GameElements
    {
        private Player p1;
        private GameBot ai;
        private Board board;
        private CommandContext ctx;
        private GameBotLogic aiLogic;

        public SingleplayerGame(CommandContext context, DiscordMember aiBot, int difficulty)
        {
            ctx = context;
            p1 = new Player(ctx.Member.Id, ctx.Member.DisplayName, GameEmoji.X);
            ai = new GameBot(aiBot.Id, aiBot.DisplayName, GameEmoji.O, difficulty);
            board = new Board(GameEmoji.Field);
            aiLogic = new GameBotLogic();
        }

        // Initiates a single player game.
        public async Task BeginSingleplayerGame()
        {
            Multiplayer = false;
            EmbedDefaults.SetEmbedDefaultsSP(p1, ai);

            ActivePlayer = p1.Name;

            // Creates and sends the embed that is used as the gameboard
            DiscordEmbedBuilder gameBoard = CreatePlayBoard(board.GameBoard);

            DiscordMessage embedMessage = await ctx.Channel.SendMessageAsync(embed: gameBoard).ConfigureAwait(false);
            await AddReactions(embedMessage);

            // Loops the game while the game isn't ended
            while (Active)
            {
                await MakeMove(embedMessage);
                Turn++;
            }
            SetWinnerStatus(p1, ai);
            await embedMessage.ModifyAsync(embed: new Optional<DiscordEmbed>(CreatePlayBoard(board.GameBoard))).ConfigureAwait(false);
            await embedMessage.DeleteAllReactionsAsync();
            RegisterInDatabase(p1, null, ai);


        }

        // Takes turns to wait for the player and ai to make a move.
        public async Task MakeMove(DiscordMessage embed)
        {
            if (Active)
            {
                InteractivityResult<MessageReactionAddEventArgs> reactionResultp1 = await InteractivityResult(p1.Id, embed);

                ActivePlayer = ai.Name;
                await RemoveChoice(embed, reactionResultp1.Result.Emoji);
                await UpdateBoard(board.GameBoard, embed, reactionResultp1.Result.Emoji, p1.PlayerEmoji, 1);

                if (Turn >= 2)
                    CheckWinCondition(p1.Name, board.GameBoard);
            }

            if (Active)
            {
                await Task.Delay(1000);
                ActivePlayer = p1.Name;

                DiscordEmoji aiMove = ConvertAiMove();

                await RemoveChoice(embed, aiMove);
                await UpdateBoard(board.GameBoard, embed, aiMove, ai.BotEmoji, 2);

                if (Turn >= 2)
                    CheckWinCondition(ai.Name, board.GameBoard);
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

        // Converts the bots move to an emoji and returns it.
        private DiscordEmoji ConvertAiMove()
        {
            int aiMove = aiLogic.MakeMove(board.GameBoard, ai.DifficultLevel, Turn);

            if (aiMove == -1)
            {
                ctx.Channel.SendMessageAsync("The bot couldn't figure out a move could result in a tie.");
                Active = false;
            }

            return GameEmoji.OneThroughNine()[aiMove];
        }

        private void SetWinnerStatus(Player player, GameBot aiPlayer)
        {
            if (Winner == player.Name)
            {
                player.SetGameResult("win");
                aiPlayer.SetGameResult("loss");
            }
            else if (Winner == aiPlayer.Name)
            {
                aiPlayer.SetGameResult("win");
                player.SetGameResult("loss");
            }
            else
            {
                player.SetGameResult("tie");
                aiPlayer.SetGameResult("tie");
            }
        }
    }
}