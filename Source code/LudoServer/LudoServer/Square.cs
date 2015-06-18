using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;

namespace LudoServer
{
    [DataContract]
    public class Square
    {

        private Color color;
        private int number = 0;
        private Boolean ismultiple;
        private bool ishouse;
        private bool isgoal;
        private bool isemptysquare = true;


        private List<Piece> pieces = new List<Piece>();


        public Color Color
        {
            get { return this.color; }
        }

        public int Number
        {
            get { return this.number; }
        }

        public bool isHouse
        {
            get { return this.ishouse; }
        }

        public bool isMulti
        {
            get { return this.ismultiple; }
        }

        public bool isGoal
        {
            get { return this.isgoal; }
        }

        public List<Piece> Pieces
        {
            get { return this.pieces; }
        }

        public void AddPiece(Piece piece)
        {
            isemptysquare = false;
            pieces.Add(piece);

            if(pieces.Count >1)
            {
                ismultiple =true;
            }

        }

        public Square(Color color, int number, bool isHouse, bool isGoal)
        {
            this.color = color;
            this.number = number;
            this.ishouse = isHouse;
            this.isgoal = isGoal;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public void SetHouse(bool ishouse)
        {
            this.ishouse = ishouse;
        }

        public void SetGoal(bool isgoal)
        {
            this.isgoal = isgoal;
        }
    }
}