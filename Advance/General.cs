using System;
using System.Collections.Generic;


namespace Advance
{
    class General : Piece 
    {
        public General(char _symbol, int row, int col)
        {
            symbol = _symbol;
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 9999;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        /*The General functions almost identically to the King in chess. It can move and capture on
        any of the 8 adjoining squares*/
        public override void markNextLegalMove(Board board,Bot bot, int curRow, int curColumn)
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
                bool captureCheck;
                bool wallCollision;

                if (board.checkOccupy(newTempX, newTempY) == true)
                {
                    if (board.troopsOnBoard[newTempX, newTempY].symbol == '#')
                    {
                        captureCheck = false;
                        wallCollision = true;
                    }
                    else
                    {
                        if (this.colour != (board.troopsOnBoard[newTempX, newTempY].colour))
                        {
                            if (board.troopsOnBoard[newTempX, newTempY].isProtected == false)
                            {
                                captureCheck = true;
                                wallCollision = false;
                            }
                            else
                            {
                                captureCheck = false;
                                wallCollision = true;
                            }
                        }
                        else
                        {
                            captureCheck = false;
                            wallCollision = true;
                        }
                    }
                }
                else 
                {
                    captureCheck = false;
                    wallCollision = false;
                }

                if (wallCollision == false)
                {
                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
            }
        }
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
