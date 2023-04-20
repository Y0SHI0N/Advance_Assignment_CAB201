using System;
using System.Collections.Generic;
using System.Text;

namespace Advance
{
    internal class Bot
    {
        public bool playAsWhite;
        public int totalResource;
        public Bot(bool playAsWhite, int totalResource)
        {
            this.playAsWhite = playAsWhite;
            this.totalResource = totalResource;
        }
    }
}
