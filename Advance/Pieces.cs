using System;
using System.Collections.Generic;
using System.Text;

namespace Advance
{
    internal class Pieces
    {
        private char[] legalTroopSymbols = "ZBMJSDCGzbmjsdcg.#\n".ToCharArray();
        public string pieceName {  get; set; }
        public string pieceSymbol { get; set; }
        public int[] piecePos { get; set; } = new int[2];
        public bool canMove { get; set; }
        public bool inDanger { get; set; }
        //ZBMJSDCGzbmjsdcg
        public Pieces(string symbol, int x, int y)
        {
            pieceSymbol = symbol;
            piecePos[0] = x;
            piecePos[1] = y;
        }


    }
}
