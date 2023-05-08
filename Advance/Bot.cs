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

        private void decideMove(Bot opposingBot)
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
                    Move tempMove;
                    List<Move> tempMoves = new List<Move>();

                    foreach (Move move in this.possibleLegalMoveList)
                    {
                        tempMove = move;
                        tempMove.computeMove();
                        if (tempMove.outcomeResources >= tempMove.initialResources)
                        {
                            tempMoves.Add(tempMove);
                        }
                    }
                    // find out if taking the move would result in the general being in danger?
                    Console.WriteLine("multiple");


                    bestMove = this.possibleLegalMoveList[0];
                    bestMove.computeMove();
                    break;

            }
        }

        public void makeMove(Board mainboard, Bot opposingBot) 
        {
            decideMove(opposingBot);
            mainboard.Grid = bestMove.newBoard.Grid;
        }
    }
}
