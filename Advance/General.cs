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
        public override void markNextLegalMove(Board board, int currentX, int currentY)
        {
            int[] move1, move2, move3, move4, move5, move6, move7, move8;
            int[][] tempLegalMoves = new int[][]
            {
            move1 = new int[2] { currentX + 1, currentY },
            move2 = new int[2] { currentX - 1, currentY },
            move3 = new int[2] { currentX, currentY + 1 },
            move4 = new int[2] { currentX, currentY - 1 },
            move5 = new int[2] { currentX - 1, currentY - 1 },
            move6 = new int[2] { currentX - 1, currentY + 1 },
            move7 = new int[2] { currentX + 1, currentY + 1 },
            move8 = new int[2] { currentX - 1, currentY - 1 },
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
                Console.WriteLine(tempLegalMoves[i][0] + "," + tempLegalMoves[i][1]);
                int newTempX = tempLegalMoves[i][0];
                int newTempY = tempLegalMoves[i][1];
                if (board.checkOccupy(newTempX, newTempY) == true)
                {
                    //In progress: checking if the General can move to this occupied posistion by capturing the occuping unit on this cell
                    Console.WriteLine($"Check Capture at {newTempX},{newTempY}");
                }
                else continue;
            }




        }
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
