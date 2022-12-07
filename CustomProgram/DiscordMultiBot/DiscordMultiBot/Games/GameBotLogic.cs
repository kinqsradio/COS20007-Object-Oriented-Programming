using DiscordMultiBot.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMultiBot.Games
{
    public class GameBotLogic
    {
        private int turnCount;
        public List<Square> square;
        private static Random random = new Random();

        public int StartMove(int difficultLevel)
        {
            int[] moveOptions;

            switch (difficultLevel)
            {
                case 1: //Level Easy: Dumb bot possible first move
                    moveOptions = Enumerable.Range(0, 9).ToArray();
                    return moveOptions[random.Next(moveOptions.Length)];
                case 2: //Level Medium: A better bot possible first move
                    if (square[4].SquareNumber == 0)
                        return 4;
                    else
                    {
                        moveOptions = Enumerable.Range(0, 9).ToArray();
                        return moveOptions[random.Next(moveOptions.Length)];
                    };
                case 3: //Level Hard: Best Moves
                    if (square[4].SquareNumber == 0)
                        return 4;
                    else
                    {
                        List<int> HardcoreListOptions = new List<int>{ 0, 2, 6, 8 };
                        moveOptions = HardcoreListOptions.ToArray();
                        return moveOptions[random.Next(moveOptions.Length)];
                    };
                default:
                    return 1;
            }
            
        }

        public int MakeMove(List<Square> grid, int difficultLevel, int turn)
        {
            square = new List<Square>(grid); 
            turnCount = turn;

            int PlaceRandomInEmpty;
            GameAnalyzer placerandominempty = new GameAnalyzer("counterstrat1");
            PlaceRandomInEmpty = placerandominempty.UsingStrate(square, random);


            if (turnCount == 0)
            {
                return StartMove(difficultLevel);
            }
            if (turnCount > 0)
            {
                int bot = InitializeBot(difficultLevel);
                return bot != -1 ? bot : PlaceRandomInEmpty;

            }
            return -1;
        }

        public int InitializeBot(int difficultLevel)
        {
            int winGamePossible; // = CanBlockOrWin(2);
            int blockPlayerPossible;
            int blockPlayer;
            int checkRandomStrat;

            int counterStrat1, counterStrat2, counterStrat3, tryToWin;

            //Bot Strategy
            GameAnalyzer CounterStrat1 = new GameAnalyzer("counterstrat1");
            counterStrat1 = CounterStrat1.UsingStrate(square, random);

            GameAnalyzer CounterStrat2 = new GameAnalyzer("counterstrat2");
            counterStrat2 = CounterStrat2.UsingStrate(square, random);

            GameAnalyzer CounterStrat3 = new GameAnalyzer("counterstrat3");
            counterStrat3 = CounterStrat3.UsingStrate(square, random);

            GameAnalyzer TryToWin = new GameAnalyzer("trywin");
            tryToWin = TryToWin.UsingStrate(square, random);

            GameAnalyzer blockorwin1 = new GameAnalyzer();
            blockPlayerPossible = blockorwin1.CanBlockOrWin(square, 1);

            winGamePossible = blockorwin1.CanBlockOrWin(square, 2);
            //End

            switch (difficultLevel)
            {
                case 1:
                    if (winGamePossible != -1)
                        return winGamePossible;

                        blockPlayer = random.Next(1, 11);

                    if (blockPlayer <= 7)
                    {
                        if (blockPlayerPossible != -1)
                        {
                            return blockPlayerPossible;
                        }
                    }

                    if (tryToWin != -1)
                    {
                        return tryToWin;
                    }
                    return -1;
                case 2:
                    if (winGamePossible != -1)
                    {
                        return winGamePossible;

                    }
                    if (blockPlayerPossible != -1)
                    {
                        return blockPlayerPossible;
                    }

                    if (turnCount <= 2)
                    {
                        checkRandomStrat = random.Next(1, 4);

                        switch (checkRandomStrat)
                        {
                            case 1:
                                if (counterStrat1 != -1)
                                {
                                    return counterStrat1;
                                }
                                break;
                            case 2:
                                if (counterStrat2 != -1)
                                {
                                    return counterStrat2;
                                }
                                break;
                            case 3:
                                if (counterStrat3 != -1)
                                {
                                    return counterStrat3;
                                }
                                break;
                        }
                    }

                    if (tryToWin != -1)
                        return tryToWin;

                    return -1;
                case 3:
                    if (winGamePossible != -1)
                        return winGamePossible;

                    if (blockPlayerPossible != -1)
                        return blockPlayerPossible;

                    if (turnCount <= 2)
                    {
                        if (counterStrat1 != -1)
                            return counterStrat1;

                        if (counterStrat2 != -1)
                            return counterStrat2;

                        if (counterStrat3 != -1)
                            return counterStrat3;
                    }

                    if (tryToWin != -1)
                        return tryToWin;
                    return -1;
                default:
                    return -1;
            }
        }
    }
}