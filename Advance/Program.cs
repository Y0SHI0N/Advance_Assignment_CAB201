﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Advance
{

    internal class Program
    {
        private static string botName = "Eudyptula";
        private static string[] firstArg = new string[3] {"white", "black", "name"};

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
                        // input validation for second and third argument
                        if ((File.Exists(args[1]) && File.Exists(args[2])) == true)
                        {
                            Board mainBoard = new Board();
                            mainBoard.readFileToBoard(args[1]);
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