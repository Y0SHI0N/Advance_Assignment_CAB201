using System;
using System.Collections.Generic;

namespace Advance
{
    class Jester : Piece
    {
        public Jester(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 3;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        //It can move to any of the 8 adjoining squares
        public override void markNextLegalMove(Board board, int currentX, int currentY)
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        //The Jester is the only piece that cannot capture other pieces
        public override void Capture()
        {
            Console.WriteLine($"Not possible for {this.GetType().Name}");
        }

        /*The first ability is that the Jester is nimble and can exchange places with a friendly piece, if it
        is on one of the adjoining squares. The only limitation here is that the Jester cannot
        exchange places with another Jester*/
        public void exchangePos()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*The other ability a Jester has is to convince enemy pieces to change to your side. This ability
        can be used on an enemy piece (other than the enemy General) in one of the 8 adjoining
        squares and changes that piece into one of your pieces. The Jester performs this action
        without moving*/
        public void convertHostileToFriendly()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }
}
