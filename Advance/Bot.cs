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

        public Bot(bool _playAsWhite, bool _playAsBlack, int totalResource)
        {
            this.playAsWhite = _playAsWhite;
            this.playAsBlack = _playAsBlack;
            this.totalResource = totalResource;
        }
    }
}
