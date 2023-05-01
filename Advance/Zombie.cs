using System;
using System.Collections.Generic;

namespace Advance
{
    class Zombie : Piece
    {
        public Zombie(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 1;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        /*Zombies can move to and capture pieces on any of the three adjoining squares in front of
        the Zombie (that is, facing upwards for white and downwards for black)*/

        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            //Console.WriteLine($"current pos: [{curRow+1},{curColumn+1}]");
            int[] move1, move2, move3, leap1, leap2, leap3;
            int[][] tempLegalMoves = new int[][]
            {
            move1 = (this.colour == "White") ? new int[2] { curRow - 1, curColumn - 1} : new int[2] {curRow + 1, curColumn - 1},
            move2 = (this.colour == "White") ? new int[2] { curRow - 1, curColumn} : new int[2] { curRow + 1, curColumn },
            move3 = (this.colour == "White") ? new int[2] { curRow - 1, curColumn + 1} : new int[2] { curRow + 1, curColumn + 1},
            };

            int[][] tempLegalLeap = new int[][]
            {
            /*if there is an enemy piece two squares away in any of those three directions and
            the intermediate square is empty, a Zombie can perform a leaping attack, capturing the
            piece on that square*/
            leap1 = (this.colour == "White") ? new int[2] {curRow - 2, curColumn - 2} : new int[2] {curRow + 2, curColumn - 2},
            leap2 = (this.colour == "White") ? new int[2] { curRow - 2, curColumn} : new int[2] {  curRow + 2, curColumn},
            leap3 = (this.colour == "White") ? new int[2] {curRow - 2, curColumn + 2 } : new int[2] {  curRow + 2, curColumn + 2},
            };

            List<int[]> subMovesArrays = tempLegalMoves.ToList();
            List<int[]> subLeapsArrays = tempLegalLeap.ToList();
            int index1 = 0;
            int index2 = 0;
            int modifier1 = 0;
            int modifier2 = 0;

            //Console.WriteLine("Moves before:");
            //foreach (var item in subMovesArrays)
            //{
            //    Console.Write($"[{item[0]}, {item[1]}]");
            //}
            //Console.WriteLine();

            //Console.WriteLine("leaps before:");
            //foreach (var item in subLeapsArrays)
            //{
            //    Console.Write($"[{item[0]}, {item[1]}]");
            //}
            //Console.WriteLine();

            while (index1 < tempLegalMoves.Length)
            {
                if ((tempLegalMoves[index1][0] < 9 && tempLegalMoves[index1][0] > -1) && (tempLegalMoves[index1][1] < 9 && tempLegalMoves[index1][1] > -1))
                {
                    ;
                }
                else
                {
                    subMovesArrays.RemoveAt(index1 - modifier1);
                    modifier1++;
                }
                index1++;
            }
            tempLegalMoves = subMovesArrays.ToArray();


            while (index2 < tempLegalLeap.Length)
            {
                if ((tempLegalLeap[index2][0] < 9 && tempLegalLeap[index2][0] > -1) && (tempLegalLeap[index2][1] < 9 && tempLegalLeap[index2][1] > -1))
                {
                    ;
                }
                else
                {
                    subLeapsArrays.RemoveAt(index2 - modifier2);
                    modifier2++;
                }
                index2++;
            }
            tempLegalLeap = subLeapsArrays.ToArray();

            //Console.WriteLine("Moves:");
            //foreach (var item in subMovesArrays)
            //{
            //    Console.Write($"[{item[0]}, {item[1]}]");
            //}
            //Console.WriteLine();

            //Console.WriteLine("leaps:");
            //foreach (var item in subLeapsArrays)
            //{
            //    Console.Write($"[{item[0]}, {item[1]}]");
            //}
            //Console.WriteLine();

            for (var i = 0; i < tempLegalMoves.Length; i++)
            {
                int newTempX = tempLegalMoves[i][0];
                int newTempY = tempLegalMoves[i][1];
                bool captureCheck;
                bool wallCollision;

                if (board.checkOccupy(newTempX, newTempY) == true) //return true if there is a wall or a troop there, aka, true if not empty, false if empty
                {
                    if (board.troopsOnBoard[newTempX, newTempY].symbol == '#') // destination contains a wall, illigal move
                    {
                        captureCheck = false;
                        wallCollision = true;
                    }
                    else
                    {
                        if (board.troopsOnBoard[newTempX, newTempY].colour != this.colour) // destination contains enemy troop, legal move
                        {
                            captureCheck = true;
                            wallCollision = false;
                        }
                        else if (board.troopsOnBoard[newTempX, newTempY].colour == this.colour) //destination contains friendly, illigal move
                        {
                            captureCheck = false;
                            wallCollision = true;
                        }
                        else // destination have no colore, denoting that it could be a wall or empty, however, the wall case have been handled, therefore implying empty cell
                        {
                            captureCheck = wallCollision = false;
                        }
                    }
                }
                else // not occupied, empty cell, legal move
                {
                    captureCheck = wallCollision = false;
                }

                if (wallCollision != true)
                {
                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
            }

            for (var i = 0; i < tempLegalLeap.Length; i++)
            {
                int newTempX = tempLegalLeap[i][0];
                int newTempY = tempLegalLeap[i][1];
                bool lineOfSight;
                bool captureCheck;
                bool leapConditionMet;
                int intermedX, intermedY;

                try
                {
                    switch (i)
                    {
                        case 0:
                            intermedX = (this.colour == "White") ? newTempX + 1 : newTempX - 1;
                            intermedY = (this.colour == "White") ? newTempY + 1 : newTempY + 1;
                            lineOfSight = (board.checkOccupy(intermedX, intermedY) == false) ? true : false;
                            break;

                        case 1:
                            intermedX = (this.colour == "White") ? newTempX + 1 : newTempX - 1;
                            intermedY = newTempY;
                            lineOfSight = (board.checkOccupy(intermedX, intermedY) == false) ? true : false;
                            break;

                        case 2:
                            intermedX = (this.colour == "White") ? newTempX + 1 : newTempX - 1;
                            intermedY = (this.colour == "White") ? newTempY - 1 : newTempY + 1;
                            lineOfSight = (board.checkOccupy(intermedX, intermedY) == false) ? true : false;
                            break;

                        default:
                            lineOfSight = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    lineOfSight = false;
                }

                if (lineOfSight == true)
                {
                    if (board.checkOccupy(newTempX, newTempY) == false)
                    {
                        continue;
                    }
                    else
                    {
                        if (board.troopsOnBoard[newTempX, newTempY].symbol == '#')
                        {
                            continue;
                        }
                        else
                        {
                            if (board.troopsOnBoard[newTempX, newTempY].colour != this.colour) // destination contains enemy troop, legal move
                            {
                                captureCheck = true;
                                Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                                bot.possibleLegalMoveList.Add(possibleMove);
                            }
                            else // destination have no colore, denoting that it could be a wall or empty, however, the wall case have been handled, therefore implying empty cell therefore cannot leap
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
