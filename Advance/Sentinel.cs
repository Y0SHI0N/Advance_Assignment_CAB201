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
        public override void markNextLegalMove(int currentX, int currentY)
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
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
