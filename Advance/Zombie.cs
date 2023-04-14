using System;
using System.Collections.Generic;

namespace Advance
{
    class Zombie : Piece
    {
        public Zombie(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 1;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        /*Zombies can move to and capture pieces on any of the three adjoining squares in front of
        the Zombie (that is, facing upwards for white and downwards for black)*/

        public override void markNextLegalMove()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*if there is an enemy piece two squares away in any of those three directions and
        the intermediate square is empty, a Zombie can perform a leaping attack, capturing the
        piece on that square*/
        public void leapAtk()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
