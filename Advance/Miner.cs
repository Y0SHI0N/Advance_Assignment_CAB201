using System;
using System.Collections.Generic;

namespace Advance
{
    class Miner : Piece
    {
        public Miner(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 4;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        /*In addition, the Miner is able to capture walls.The Miner captures
        walls in the same way it captures pieces, and it is subject to the same limitations: it can only
        capture one piece(or wall) in a move and there must be an unobstructed path to that piece
        in one of the cardinal directions
        */
        public void detectMoveRange(List<int[]> moveList, Board board, Bot bot, int curRow, int curColumn)
        {
            foreach (int[] move in moveList)
            {
                int newTempX = move[0];
                int newTempY = move[1];
                bool captureCheck;
                bool breakWall;
                if (board.checkOccupy(newTempX, newTempY) == true) //check if the destination being occupied
                {
                    breakWall = board.troopsOnBoard[newTempX, newTempY].symbol == '#';
                    captureCheck = this.colour != (board.troopsOnBoard[newTempX, newTempY].colour);
                    if (breakWall || captureCheck) // true if either: there is a wall at destination, or there is enemy piece at destination
                    {
                        if (board.troopsOnBoard[newTempX, newTempY].isProtected == false)
                        {
                            captureCheck = true;
                            Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board, false, false, false, breakWall); //add all the moves prior to its destination
                            bot.possibleLegalMoveList.Add(possibleMove);
                            break;
                        }
                        else break;
                    }
                    else break;
                }
                else
                {
                    captureCheck = false;
                    Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
            }
        }

        //The Miner moves like a Rook does in chess
        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            List<int[]> toTop = new List<int[]>();
            List<int[]> toBottom = new List<int[]>();
            List<int[]> toLeft = new List<int[]>();
            List<int[]> toRight = new List<int[]>();

            for (int j = 0; j < 4; j++)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (curColumn + i < 9 && j == 0)
                    {
                        toRight.Add(new int[] { curRow, curColumn + i });
                    }

                    if (curColumn - i >= 0 && j == 1)
                    {
                        toLeft.Add(new int[] { curRow, curColumn - i });
                    }

                    if (curRow + i < 9 && j == 2)
                    {
                        toBottom.Add(new int[] { curRow + i, curColumn });
                    }

                    if (curRow - i >= 0 && j == 3)
                    {
                        toTop.Add(new int[] { curRow - i, curColumn });
                    }
                }
            }

            this.detectMoveRange(toTop,board,bot,curRow,curColumn);
            this.detectMoveRange(toBottom, board, bot, curRow, curColumn);
            this.detectMoveRange(toRight, board, bot, curRow, curColumn);
            this.detectMoveRange(toLeft, board, bot, curRow, curColumn);

        }
    }
}
