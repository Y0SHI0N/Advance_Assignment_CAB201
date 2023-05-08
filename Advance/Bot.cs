using System;
using System.Collections.Generic;
using System.Text;

namespace Advance
{
    internal class Bot
    {
        public bool playAsWhite { get; set; }
        public bool playAsBlack { get; set; }
        public List<Move> possibleLegalMoveList { get; set; } = new List<Move>();
        public int totalResource { get; set; }
        public Move bestMove { get; set; }

        public Bot(bool _playAsWhite, bool _playAsBlack, int totalResource)
        {
            this.playAsWhite = _playAsWhite;
            this.playAsBlack = _playAsBlack;
            this.totalResource = totalResource;
        }

        private void decideMove()
        {
           switch (this.possibleLegalMoveList.Count)
            {
                case 0:
                    Console.WriteLine("Error: There are no legal move to make");
                    Environment.Exit(0);
                    break;

                case 1:
                    bestMove = this.possibleLegalMoveList[0];
                    bestMove.computeMove();
                    break;

                default:
                    Console.WriteLine("multiple");
                    break;

            }
        }

        public void makeMove(Board mainboard) 
        {
            decideMove();
            mainboard.Grid = bestMove.newBoard.Grid;
        }
    }
}
