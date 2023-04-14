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

        //The Miner moves like a Rook does in chess
        public override void markNextLegalMove()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*In addition, the Miner is able to capture walls.The Miner captures
        walls in the same way it captures pieces, and it is subject to the same limitations: it can only
        capture one piece(or wall) in a move and there must be an unobstructed path to that piece
        in one of the cardinal directions
        */
        public void captureWall()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
