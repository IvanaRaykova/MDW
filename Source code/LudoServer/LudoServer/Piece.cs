using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Runtime.Serialization;

namespace LudoService
{
    [DataContract]
    public class Piece
    {
        private Color color;
        private int piecenumber;
        private bool isatHome;
        private bool iswon;
        private Square square;

        public Piece(Color color, int PieceNumber)
        {
            this.color = color;
            this.piecenumber = PieceNumber;
        }

        public Color Color
        {
            get { return this.color; }
        }

        public int pieceNumber
        {
            get { return this.piecenumber; }
        }

        public bool IsAtHome
        {
            get { return this.isatHome; }
        }

        public bool IsWon
        {
            get { return this.iswon; }
        }

        public Square Square
        {
            get { return this.square; }
            set { this.square = value; }

        }

        public void setPieceStatus(bool isathome, bool iswon)
        {
            this.isatHome = isathome;
            this.iswon = iswon;
        }

    }
}