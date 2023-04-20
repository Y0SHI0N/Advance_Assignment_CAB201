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

        /*The Dragon is a powerful piece that can move any number of squares in a straight line in any
        of the 8 directions*/
        public override void markNextLegalMove(int currentX, int currentY)
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*It is most similar to a Queen in the game of chess, except for one
        downside: the Dragon cannot capture any piece it is immediately next to*/
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
