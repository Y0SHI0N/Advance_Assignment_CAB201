﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Advance
{
    class Cell
    {
        public int row {  get; private set; }
        public int col { get; private set; }
        public bool currentlyOccupied { get; set; }
        public bool legalNextMove { get; set; }
        public char troopSymbol { get; set; }
        public Cell(int x, int y)
        {
            row = x;
            col = y;
        }
    }

    class Board
    {
        private char[] legalTroopSymbols = "ZBMJSDCGzbmjsdcg.#\n".ToCharArray();
        public int Size {get; set; }
        public Cell[,] Grid { get; set; }
        public Piece[,] troopsOnBoard { get; set; } = new Piece[9,9];
        public Board(int s = 9) 
        {
            Size = s;
            Grid =new Cell[Size,Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i,j] = new Cell(i,j);
                }
            }
        }
         public void addTroop(char c,int row, int col)
        {
            if (c == 'z' || c == 'Z')
            {
                troopsOnBoard[row, col] = new Zombie(c, row, col);
            }
            else if (c == 'b'|| c== 'B')
            {
                troopsOnBoard[row, col] = new Builder(c, row, col);
            }
            else if (c == '#')
            {
                troopsOnBoard[row, col] = new Wall(c, row, col);
            }
            else if (c == 'm' || c == 'M')
            {
                troopsOnBoard[row, col] = new Miner(c, row, col);
            }
            else if (c == 'j' || c == 'J')
            {
                troopsOnBoard[row, col] = new Jester(c, row, col);
            }
            else if (c == 's' || c == 'S')
            {
                troopsOnBoard[row, col] = new Sentinel(c, row, col);
            }
            else if (c == 'c' || c == 'C')
            {
                troopsOnBoard[row, col] = new Catapult(c, row, col);
            }
            else if (c == 'd' || c == 'D')
            {
                troopsOnBoard[row, col] = new Dragon(c, row, col);
            }
            else if (c == 'g' || c == 'G')
            {
                troopsOnBoard[row, col] = new General(c, row, col);
            }
            Grid[row, col].currentlyOccupied = true;
        }

        public void readFileToBoard(string path)
        {
            bool invalidSymbol = false;
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        int rowCnt = 0;
                        //Console.WriteLine("From file:");
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            //Console.WriteLine(line);
                            for (int columnCnt = 0; columnCnt < Size; columnCnt++)
                            {
                                if (!Array.Exists(legalTroopSymbols, x => x == line[columnCnt]))
                                {
                                    invalidSymbol = true;
                                    break;
                                }
                            }
                            if (invalidSymbol == true)
                            {
                                break;
                            }
                            else
                            {
                                rowCnt++;
                            }
                        }
                        reader.Close();
                    }

                    if (invalidSymbol != true)
                    {
                        using (StreamReader reader = new StreamReader(path))
                        {
                            int rowCnt = 0;
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                for (int columnCnt = 0; columnCnt < Size; columnCnt++)
                                {
                                    Grid[rowCnt, columnCnt].troopSymbol = line[columnCnt];
                                    if ((line[columnCnt] != '.' )|| (line[columnCnt] != '\n'))
                                    {
                                        addTroop(line[columnCnt], rowCnt, columnCnt);
                                    }
                                }
                                rowCnt++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Read Error: Invalid symbol detected!");
                        System.Environment.Exit(1);
                    }
                }
                else
                {
                    Console.WriteLine("Read Error: Invalid file path");
                    System.Environment.Exit(1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void writeBoardToFile(string path)
        {
            string text = "";

            for (int i = 0;i < Size; i++)
            {
                for(int j = 0;j < Size; j++)
                {
                    text = text + Grid[i,j].troopSymbol.ToString();
                }
                text = text + "\n";
            }

            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.Write(text);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
