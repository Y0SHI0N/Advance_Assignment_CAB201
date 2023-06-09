﻿using System;
using System.Collections.Generic;

namespace Advance
{
    internal class Piece
    {
        public string? colour { get; set; }
        public char symbol { get; set; }
        public int resourceValue { get; set; }  
        public int[] posistion { get; set; } = new int[2];
        public bool canMove { get; set; }
        public bool inDanger { get; set; }
        public bool isProtected { get; set; }

        public virtual void markNextLegalMove(Board board,Bot bot,int currentX, int currentY) {; }

        public virtual void Capture() {; }
    }

    internal class emptyCell : Piece
    {
        public emptyCell(char _symbol, int row, int col)
        {
            symbol = _symbol;
            resourceValue = 0;
            posistion[0] = row;
            posistion[1] = col;
            canMove = false;
        }
    }
}
