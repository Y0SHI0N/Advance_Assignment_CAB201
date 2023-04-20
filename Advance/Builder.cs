using System;
using System.Collections.Generic;

namespace Advance
{
    class Builder : Piece
    {
        public Builder(char _symbol, int row, int col)
        {
            symbol = _symbol;
            //if char is capital letter, then colour is white, else black
            colour = char.IsUpper(symbol) == true ? "White" : "Black";
            resourceValue = 2;
            posistion[0] = row;
            posistion[1] = col;
            canMove = true;
        }

        //The Builder can move and capture on any of the 8 adjoining squares
        public override void markNextLegalMove(int currentX, int currentY)
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        public override void Capture()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }

        /*Builders can also build walls on any of the 8 adjoining squares as well, as long as there is
        nothing occupying that square. The builder does this without moving*/
        public void buildWall()
        {
            Console.WriteLine($"To be written for {this.GetType().Name}");
        }
    }

    class Wall : Piece
    {
        public Wall(char _symbol, int row, int col)
        {
            symbol = _symbol;
            colour = null;
            resourceValue = 0;
            posistion[0] = row;
            posistion[1] = col;
            canMove = false;

        }
    } 
}
