using System;
using System.Collections.Generic;

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
        public override void markNextLegalMove(Board board, int currentX, int currentY)
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*The Catapult is able to capture pieces that are either 3 squares away in a cardinal
        direction or 2 squares away in two perpendicular cardinal directions. The Catapult’s attack is special, 
        in that it can remove an enemy piece on one of its capture squares, but it does not itself move when doing so. 
        It also does not matter if there are otherpieces in the way, as the Catapult’s projectile flies over the battlefield*/
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
