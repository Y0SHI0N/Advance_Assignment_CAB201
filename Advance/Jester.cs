using System;
using System.Collections.Generic;

namespace Advance
{
    class Jester : Piece
    {
        public Jester(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 3;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        //It can move to any of the 8 adjoining squares
        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            int[] move1, move2, move3, move4, move5, move6, move7, move8;
            int[][] tempLegalMoves = new int[][]
            {
            move1 = new int[2] { curRow + 1, curColumn },
            move2 = new int[2] { curRow - 1, curColumn },
            move3 = new int[2] { curRow, curColumn + 1 },
            move4 = new int[2] { curRow, curColumn - 1 },
            move5 = new int[2] { curRow - 1, curColumn - 1 },
            move6 = new int[2] { curRow - 1, curColumn + 1 },
            move7 = new int[2] { curRow + 1, curColumn + 1 },
            move8 = new int[2] { curRow + 1, curColumn - 1 },
            };
            List<int[]> subArrays = tempLegalMoves.ToList();


            int index = 0;
            int modifier = 0;

            while (index < tempLegalMoves.Length)
            {
                if ((tempLegalMoves[index][0] < 9 && tempLegalMoves[index][0] > -1) && (tempLegalMoves[index][1] < 9 && tempLegalMoves[index][1] > -1))
                {
                    ;
                }
                else
                {
                    subArrays.RemoveAt(index - modifier);
                    modifier++;
                }
                index++;
            }
            tempLegalMoves = subArrays.ToArray();

            for (int i = 0; i < tempLegalMoves.Length; i++)
            {
                int newTempX = tempLegalMoves[i][0];
                int newTempY = tempLegalMoves[i][1];
                bool captureCheck = false; // cannot capture anything
                bool swapCheck;
                bool convertCheck;
                bool wallCollision;

                //check to see if there is something in the way
                if (board.checkOccupy(newTempX, newTempY) == true)
                {
                    wallCollision = true;
                }
                else
                {
                    wallCollision = false;
                }

                if (wallCollision == false)
                {
                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
                else
                {
                    if (board.troopsOnBoard[newTempX, newTempY].symbol != '#')
                    {
                        if (this.colour != (board.troopsOnBoard[newTempX, newTempY].colour))
                        {
                            convertCheck = true;
                            swapCheck = false;
                            Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board,false,convertCheck,swapCheck);
                            bot.possibleLegalMoveList.Add(possibleMove);
                        }
                        else
                        {
                            convertCheck = false;
                            swapCheck = true;
                            Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board, false, convertCheck, swapCheck);
                            bot.possibleLegalMoveList.Add(possibleMove);
                        }
                    }
                }
            }
        }

        //The Jester is the only piece that cannot capture other pieces


        /*The first ability is that the Jester is nimble and can exchange places with a friendly piece, if it
        is on one of the adjoining squares. The only limitation here is that the Jester cannot
        exchange places with another Jester*/
        public void exchangePos()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*The other ability a Jester has is to convince enemy pieces to change to your side. This ability
        can be used on an enemy piece (other than the enemy General) in one of the 8 adjoining
        squares and changes that piece into one of your pieces. The Jester performs this action
        without moving*/
        public void convertHostileToFriendly()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
