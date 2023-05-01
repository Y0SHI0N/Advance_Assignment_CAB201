using System;
using System.Collections.Generic;
using System.Reflection;

namespace Advance
{
    class Catapult : Piece
    {
        public Catapult(char _symbol, int row, int col)
        {
            symbol = _symbol;
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 6;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }
        /*The Catapult can only move 1 square at a time, and only in the 4 cardinal directions. Also, it
        can only move to those squares – it cannot capture enemy pieces on those squares*/
        public override void markNextLegalMove(Board board, Bot bot, int curRow, int curColumn)
        {
            List<int[]> tempMoveList = new List<int[]>();
            
            for (int i = 0; i < 4; i++)
            {

                if (curColumn + 1 < 9 && i == 0)
                {
                    tempMoveList.Add(new int[] { curRow, curColumn + 1 });
                }

                if (curColumn - 1 >= 0 && i == 1)
                {
                    tempMoveList.Add(new int[] { curRow, curColumn - 1 });
                }

                if (curRow + 1 < 9 && i == 2)
                {
                    tempMoveList.Add(new int[] { curRow + 1, curColumn });
                }

                if (curRow - 1 >= 1 && i == 3)
                {
                    tempMoveList.Add(new int[] { curRow - 1, curColumn });
                }
            }

            for (int i = 0; i < tempMoveList.Count; i++)
            {
                int newTempX = tempMoveList[i][0];
                int newTempY = tempMoveList[i][1];
                bool captureCheck = false;
                bool wallCollision;

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
            }

            this.checkAimDestination(board, bot,curRow, curColumn);

        }

        /*The Catapult is able to capture pieces that are either 3 squares away in a cardinal
        direction or 2 squares away in two perpendicular cardinal directions. The Catapult’s attack is special, 
        in that it can remove an enemy piece on one of its capture squares, but it does not itself move when doing so. 
        It also does not matter if there are otherpieces in the way, as the Catapult’s projectile flies over the battlefield*/
        public void checkAimDestination(Board board, Bot bot, int curRow, int curColumn)
        {
            bool captureCheck = true;
            List<int[]> tempTargetList = new List<int[]>();

            // Calculate coordinates 3 squares away in a cardinal direction
            tempTargetList.Add(new int[] { curRow - 3, curColumn });
            tempTargetList.Add(new int[] { curRow + 3, curColumn });
            tempTargetList.Add(new int[] { curRow, curColumn - 3 });
            tempTargetList.Add(new int[] { curRow, curColumn + 3 });

            // Calculate coordinates 2 squares away in two perpendicular cardinal directions
            tempTargetList.Add(new int[] { curRow - 2, curColumn - 2 });
            tempTargetList.Add(new int[] { curRow - 2, curColumn + 2 });
            tempTargetList.Add(new int[] { curRow + 2, curColumn - 2 });
            tempTargetList.Add(new int[] { curRow + 2, curColumn + 2 });


            List<int[]> subArrays = tempTargetList.ToList();
            int index = 0;

            while (index < tempTargetList.Count)
            {
                if ((tempTargetList[index][0] < 9 && tempTargetList[index][0] > -1) && (tempTargetList[index][1] < 9 && tempTargetList[index][1] > -1))
                {
                    index++;
                }
                else
                {
                    tempTargetList.RemoveAt(index);
                }

            }

            foreach (int[] potentialTarget in  tempTargetList)
            {
                int newTempX = potentialTarget[0];
                int newTempY = potentialTarget[1];
                if (board.checkOccupy(newTempX, newTempY) == true) //check if the destination being occupied
                {
                    if (board.troopsOnBoard[newTempX, newTempY].symbol != '#' && this.colour != (board.troopsOnBoard[newTempX, newTempY].colour))
                    {
                        Move possibleMove = new Move(symbol, curRow, newTempX, curColumn, newTempY, captureCheck, bot.totalResource, board);
                        bot.possibleLegalMoveList.Add(possibleMove);
                    }
                }
            }
        }
    }
}
