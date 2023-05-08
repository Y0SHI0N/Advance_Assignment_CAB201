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
        public bool buildWall { get; set; }
        public bool Bribe { get; set; }
        public bool SwapPlace { get; set; }
        public bool breakWall { get; set; }
        public Board cloneBoard { get; set; }
        public Board newBoard { get; set; }
        public int initialResources { get; set; }
        public int outcomeResources { get; set; }

        public Move(char _troop,int oldX, int newX, int oldY, int newY, bool checkForCapture, int initialResources, Board oldBoard, bool _buildWall = false, bool bribe = false, bool swapPlace = false, bool breakWall = false)
        {
            this.troop = _troop;
            this.oldX = oldX;
            this.newX = newX;
            this.oldY = oldY;
            this.newY = newY;
            this.buildWall = _buildWall;
            this.Bribe = bribe;
            this.SwapPlace = swapPlace;
            this.checkForCapture = checkForCapture;
            this.initialResources = initialResources;
            this.cloneBoard = (Board)oldBoard.Clone();
            this.breakWall = breakWall;
        }

        public void computeMove()
        {
            newBoard = cloneBoard;

            if (checkForCapture)
            {
                newBoard.troopsOnBoard[oldX, oldY].symbol = '.';
                newBoard.troopsOnBoard[newX, newY].symbol = troop;
                outcomeResources = (char.IsUpper(troop) ? newBoard.calTotalValue()[0] : newBoard.calTotalValue()[1]);

                newBoard.Grid[oldX, oldY].troopSymbol = '.';
                newBoard.Grid[oldX, oldY].currentlyOccupied = false;

                newBoard.Grid[newX, newY].troopSymbol = troop;
                newBoard.Grid[newX, newY].currentlyOccupied = true;
            }
            else if (buildWall)
            {
                newBoard.troopsOnBoard[newX, newY].symbol = '#';
                outcomeResources = initialResources;

                newBoard.Grid[newX, newY].troopSymbol = '#';
                newBoard.Grid[newX, newY].currentlyOccupied = true;
            }

            else if (Bribe)
            {
                if (char.IsUpper(troop)) //If it is a white Jester
                {
                    // go turn troop symbol at target desitination into upper case aka white
                    newBoard.troopsOnBoard[newX, newY].symbol = char.ToUpper(newBoard.troopsOnBoard[newX, newY].symbol);

                    newBoard.Grid[newX, newY].troopSymbol = newBoard.troopsOnBoard[newX, newY].symbol;
                    newBoard.Grid[newX, newY].currentlyOccupied = true;
                }
                else
                {
                    // go turn troop symbol at target desitination into lower case aka black
                    newBoard.troopsOnBoard[newX, newY].symbol = char.ToLower(newBoard.troopsOnBoard[newX, newY].symbol);

                    //newBoard.Grid[newX, newY].troopSymbol = newBoard.troopsOnBoard[newX, newY].symbol;
                    //newBoard.Grid[newX, newY].currentlyOccupied = true;
                }
                outcomeResources = (char.IsUpper(troop) ? newBoard.calTotalValue()[0] : newBoard.calTotalValue()[1]);
            }

            else if (SwapPlace)
            {
                newBoard.troopsOnBoard[oldX, oldY].symbol = cloneBoard.troopsOnBoard[newX, newY].symbol;
                newBoard.troopsOnBoard[newX, newY].symbol = cloneBoard.troopsOnBoard[oldX, oldY].symbol;
                outcomeResources = initialResources;

                newBoard.Grid[oldX, oldY].troopSymbol = cloneBoard.troopsOnBoard[newX, newY].symbol;
                newBoard.Grid[newX, newY].troopSymbol = cloneBoard.troopsOnBoard[oldX, oldY].symbol;
            }
            else //just a normal move into an empty square
            {
                newBoard.troopsOnBoard[oldX, oldY].symbol = '.';
                newBoard.troopsOnBoard[newX, newY].symbol = troop;
                outcomeResources = initialResources;

                newBoard.Grid[oldX, oldY].troopSymbol = '.';
                newBoard.Grid[newX, newY].troopSymbol = troop;
            }
        }
    }
}
