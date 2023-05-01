using System;
using System.Collections.Generic;

namespace Advance
{
    class Sentinel : Piece
    {
        public Sentinel(char _symbol, int row, int col)
        {
            symbol = _symbol;
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 5;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        /*It moves and captures similarly to a Knight in the
        game of chess, moving two squares in one cardinal direction and then one square in a
        perpendicular direction, jumping over any intervening pieces (or walls).*/
        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            List<int[]> possibleMoves = new List<int[]>();
            // Calculate moves in the L-shape
            int[,] offsets = { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };
            for (int i = 0; i < offsets.GetLength(0); i++)
            {
                int newX = curRow + offsets[i, 0];
                int newY = curColumn + offsets[i, 1];
                if (newX >= 0 && newX < 9 && newY >= 0 && newY < 9)
                {
                    possibleMoves.Add(new int[] { newX, newY });
                }
            }

            foreach (int[] move in possibleMoves)
            {
                bool captureCheck;
                bool wallCollision;
                bool protectionCheck;

                if (board.checkOccupy(move[0], move[1]) == true) // check if there is something in the destination
                {
                    if (board.troopsOnBoard[move[0], move[1]].symbol != '#') // make sure that something is not a wall
                    {
                        if (this.colour != (board.troopsOnBoard[move[0], move[1]].colour) && board.troopsOnBoard[move[0], move[1]].isProtected == false) // now that it is not a wall, make sure it is unprotected enemy
                        {
                            captureCheck = true;
                            Move possibleMove = new Move(symbol, curRow, move[0], curColumn, move[1], captureCheck, bot.totalResource, board);
                            bot.possibleLegalMoveList.Add(possibleMove);
                        }
                        else { ; } // either the occupying troop is a friendly, or it is protected, or both
                    }
                    else { ; } // hit a wall, no go
                }
                else // empty cell
                {
                    captureCheck = false;
                    Move possibleMove = new Move(symbol, curRow, move[0], curColumn, move[1], captureCheck, bot.totalResource, board);
                    bot.possibleLegalMoveList.Add(possibleMove);
                }
            }
        }

        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /* the Sentinel protects any friendly pieces (except for other Sentinels) on
        the 4 adjoining squares in cardinal directions, preventing enemy pieces from capturing your
        pieces on those squares, it does not include the Jester’s conversion move. 
        The General is not in danger if it is protected by a friendly Sentinel*/
        public void provideProtection()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
