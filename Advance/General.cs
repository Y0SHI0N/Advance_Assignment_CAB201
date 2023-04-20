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
        public override void markNextLegalMove()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
