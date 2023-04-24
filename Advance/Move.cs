using System;
using System.Collections.Generic;

namespace Advance
{
    internal class Move
    {
        public char troop { get; set; }
        public int oldX { get; set; }
        public int newX { get; set; }
        public int oldY { get; set; }
        public int newY { get; set; }
        public bool checkForCapture { get; set; }
        public bool checkForCheckmate { get; set; }
        public Board cloneBoard { get; set; }
        public Board newBoard { get; set; }
        public int initialResources { get; set; }
        public int outcomeResources { get; set; }

        public Move(char _troop,int oldX, int newX, int oldY, int newY, bool checkForCapture, int initialResources, Board oldBoard)
        {
            this.troop = _troop;
            this.oldX = oldX;
            this.newX = newX;
            this.oldY = oldY;
            this.newY = newY;
            this.checkForCapture = checkForCapture;
            this.initialResources = initialResources;
            this.cloneBoard = (Board)oldBoard.Clone();

        }
    }
}
