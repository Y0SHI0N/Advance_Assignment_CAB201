using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Advance
{
    internal class Program
    {
        public static readonly char[] legalTroopSymbols = "ZBMJSDCGzbmjsdcg.#\n".ToCharArray();
        private static string botName = "Eudyptula";
        private static string[] firstArg = new string[3] {"white", "black", "name"};
        public static bool playAsWhite;

        public static void outputError(string message)
        {
            Console.WriteLine("Error: {0}",message);
        }


        static void Main(string[] args)
        {
            string? errorMsg;
            try
            {
                if (args.Length == 1 && args[0] == firstArg[2])
                {
                    Console.WriteLine($"This bot name is: {botName}");
                }
                else if (args.Length == 3)
                {
                    bool argsOneBlackOrWhite = (Array.Exists(firstArg, x => x == args[0]) && args[0] != "name");

                    // check if the argument is 'white' or 'black'. if true, then proceed, otherwise abort
                    if (argsOneBlackOrWhite == true)
                    {
                        playAsWhite = args[0].ToLower() == "white" ? true : false;
                        // input validation for second and third argument
                        if ((File.Exists(args[1]) && File.Exists(args[2])) == true)
                        {
                            Board mainBoard = new Board();
                            mainBoard.readFileToBoard(args[1]);
                            Bot botWhite = new Bot(playAsWhite, mainBoard.calTotalValue(playAsWhite));
                            Bot botBlack = new Bot(!playAsWhite, mainBoard.calTotalValue(playAsWhite));

                            mainBoard.setProtection();

                            //for (int x = 0; x < 9; x++)
                            //{
                            //    for (int y = 0; y < 9; y++)
                            //    { 
                            //        if (mainBoard.troopsOnBoard[x,y].isProtected == true)
                            //        {
                            //            Console.WriteLine($"grid [{x+1},{y+1}] is protected from capture");
                            //        }
                            //    }
                            //}


                            if (playAsWhite == true)
                            {
                                mainBoard.scanBoard(playAsWhite, mainBoard, botWhite);
                            }
                            else
                            {
                                mainBoard.scanBoard(playAsWhite, mainBoard, botBlack);
                            }
                            


                            //analyse board and make a move here
                            Console.WriteLine("There are {0} total legal moves for white:", botWhite.possibleLegalMoveList.Count());
                            foreach (var item in botWhite.possibleLegalMoveList)
                            {
                                if (item.buildWall == true)
                                {
                                    Console.WriteLine("\tBuilder at row {0} col {1} can build a wall at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.SwapPlace == true)
                                {
                                    Console.WriteLine("\tJester at row {0} col {1} can swap place with a friendly at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.Bribe == true)
                                {
                                    Console.WriteLine("\tJester at row {0} col {1} can bribe an enemy at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if(item.breakWall == true)
                                {
                                    Console.WriteLine("\tMiner at row {0} col {1} can break a wall at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.checkForCapture == true)
                                {
                                    Console.WriteLine("\t{0} is capturing an enemy piece at row {1} col {2} from row {3} col {4}", item.troop, item.newX + 1, item.newY + 1, item.oldX + 1, item.oldY + 1);
                                }
                                else
                                {
                                    Console.WriteLine("\tmove {0} from row {1} col {2} to row {3} col {4}", item.troop, item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                            }

                            Console.WriteLine("There are {0} total legal moves for black:", botBlack.possibleLegalMoveList.Count());
                            foreach (var item in botBlack.possibleLegalMoveList)
                            {
                                if (item.buildWall == true)
                                {
                                    Console.WriteLine("\tBuilder at row {0} col {1} can build a wall at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.SwapPlace == true)
                                {
                                    Console.WriteLine("\tJester at row {0} col {1} can swap place with a friendly at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.Bribe == true)
                                {
                                    Console.WriteLine("\tJester at row {0} col {1} can bribe an enemy at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.breakWall == true)
                                {
                                    Console.WriteLine("\tMiner at row {0} col {1} can break a wall at row {2} col {3}", item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                                else if (item.checkForCapture == true)
                                {
                                    Console.WriteLine("\t{0} is capturing an enemy piece at row {1} col {2} from row {3} col {4}", item.troop, item.newX + 1, item.newY + 1, item.oldX + 1, item.oldY + 1);
                                }
                                else
                                {
                                    Console.WriteLine("\tmove {0} from row {1} col {2} to row {3} col {4}", item.troop, item.oldX + 1, item.oldY + 1, item.newX + 1, item.newY + 1);
                                }
                            }

                            mainBoard.writeBoardToFile(args[2]);
                        }
                        else
                        {
                            errorMsg = "The provided filepaths were invalid. Make sure the filepaths exsist and not being use by other programs";
                            outputError(errorMsg);
                        }
                    }
                    else
                    {
                        errorMsg = "The first argument provided was invalid. Make sure its 'white' or 'black' if you want to start the game, or 'name if you want to get the name of the bot";
                        outputError(errorMsg);
                    }
                }  
                else
                {
                    errorMsg = "An invalid number of argument/s were provided. Please check the provided arguments and try again";
                    outputError(errorMsg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine (e.ToString());
            }
        }
    }
}