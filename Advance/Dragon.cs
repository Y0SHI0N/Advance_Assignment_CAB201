using System;
using System.Collections.Generic;

namespace Advance
{
    class Dragon : Piece 
    {
        public Dragon(char _symbol, int row, int col)
        {
            symbol = _symbol;
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 7;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }


        public void detectDragonRange(List<int[]> moveList, Board board, Bot bot, int curRow, int curColumn)
        {
            foreach (int[] move in moveList)
            {
                int newTempX = move[0];
                int newTempY = move[1];
                bool captureCheck;
                bool adjacentCheck;

                switch (Math.Abs(newTempY - curColumn))
                {
                    case 0:
                        adjacentCheck = (Math.Abs(newTempX - curRow) == 1);
                        break;
                    case 1:
                        adjacentCheck = (Math.Abs(newTempX - curRow) <= 1);
                        break;
                    case 2:
                        adjacentCheck = (Math.Abs(newTempX - curRow) == 2);
                        break;
                    default:
                        adjacentCheck = false;
                        break;
                }

                if (board.checkOccupy(newTempX, newTempY) == true) //check if the destination being occupied
                {
                    if (board.troopsOnBoard[newTempX, newTempY].symbol != '#') // check if destination is not being blocked by a wall
                    {
                        if (this.colour != (board.troopsOnBoard[newTempX, newTempY].colour)) // check for enemy piece
                        {
                            if (adjacentCheck == false) // check for if they are adjacent
                            {
                                if (board.troopsOnBoard[newTempX, newTempY].isProtected == false)
                                {
                                    captureCheck = true;
                                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board); //add all the moves prior to its destination
                                    bot.possibleLegalMoveList.Add(possibleMove);
                                    break;
                                }
                                else { break; } // enemies are protected by a sentinel
                            }
                            else { break; }// enemies are adjacent, cannot capture
                        }
                        else { break; } // destination occupied by friendlies
                    }
                    else {break; }// not occupied by wall, but since friendly and hostile cases has been ruled out, essentially empty or potentially buggy square
                }
                else //empty square -> add all the moves prior to its destination
                {
                    captureCheck = false;
                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
            }
        }

        /*The Dragon is a powerful piece that can move any number of squares in a straight line in any
        of the 8 directions*/
        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            List<int[]> toTop = new List<int[]>();
            List<int[]> toBottom = new List<int[]>();
            List<int[]> toLeft = new List<int[]>();
            List<int[]> toRight = new List<int[]>();

            List<int[]> toTopRight = new List<int[]>();
            List<int[]> toBottomRight = new List<int[]>();
            List<int[]> toTopLeft = new List<int[]>();
            List<int[]> toBottomLeft = new List<int[]>();

            for (int j = 0; j < 8; j++)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (curColumn + i < 9 && j == 0) // go right
                    {
                        toRight.Add(new int[] { curRow, curColumn + i });
                    }

                    if (curColumn - i >= 0 && j == 1) // go left
                    {
                        toLeft.Add(new int[] { curRow, curColumn - i });
                    }

                    if (curRow + i < 9 && j == 2) // go  down
                    {
                        toBottom.Add(new int[] { curRow + i, curColumn });
                    }

                    if (curRow - i >= 0 && j == 3) // go up
                    {
                        toTop.Add(new int[] { curRow - i, curColumn });
                    }

                    if (curRow - i >= 0 && curColumn + i < 9 && j == 4) // go top right
                    {
                        toTopRight.Add(new int[] { curRow - i, curColumn + i });
                    }

                    if (curRow + i < 9 && curColumn + i < 9 && j == 5) // go bottom right
                    {
                        toBottomRight.Add(new int[] { curRow + i , curColumn + i });
                    }

                    if (curRow + i < 9 && curColumn - i >= 0 && j == 6) // go bottom left
                    {
                        toBottomLeft.Add(new int[] {curRow + i, curColumn - i });
                    }

                    if (curRow - i >= 0 && curColumn - i >= 0 && j == 7) // go top left
                    {
                        toTopLeft.Add(new int[] { curRow - i,curColumn - i});
                    }
                }
            }

            this.detectDragonRange(toTop, board, bot, curRow, curColumn);
            this.detectDragonRange(toBottom, board, bot, curRow, curColumn);
            this.detectDragonRange(toRight, board, bot, curRow, curColumn);
            this.detectDragonRange(toLeft, board, bot, curRow, curColumn);

            this.detectDragonRange(toTopRight,board, bot, curRow, curColumn);
            this.detectDragonRange(toBottomRight, board, bot, curRow, curColumn);
            this.detectDragonRange(toBottomLeft, board, bot, curRow, curColumn);
            this.detectDragonRange(toTopLeft, board, bot, curRow, curColumn);
        }

        /*It is most similar to a Queen in the game of chess, except for one
        downside: the Dragon cannot capture any piece it is immediately next to*/
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
