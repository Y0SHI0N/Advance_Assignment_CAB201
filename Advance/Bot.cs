using System;
using System.Collections.Generic;
using System.Text;

namespace Advance
{
    internal class Bot
    {
        public bool playAsWhite { get; set; }
        public List<Move> possibleLegalMoveList { get; set; } = new List<Move>();
        public int totalResource { get; set; }
        public Bot(bool playAsWhite, int totalResource)
        {
            this.playAsWhite = playAsWhite;
            this.totalResource = totalResource;
        }
    }
}
