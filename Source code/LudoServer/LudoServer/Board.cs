using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;

namespace LudoServer
{
    public class Board
    {
        private List<Square> squares = new List<Square>(92);
        private List<Piece> pieces = new List<Piece>();


        public List<Square> Squares
        {
            get { return this.squares; }
        }

        public List<Piece> Pieces
        {
            get { return this.pieces; }
        }

        public Board(List<Player> players)
        {
            this.InitializeBoard();
            this.CreatePieces(players);
        }

        public void MovePiece(Piece Piece, Square Square)
        {
            Piece.Square.RemovePiece(Piece);

        }


        private void InitializeBoard()
        {
            for (int i = 0; i < 92; i++)
                this.squares.Add(new Square(Color.White, i, false, false));

            for (int i = 76; i <= 79; i++)
            {
                this.squares[i].SetHouse(true);
                this.squares[i].SetColor(Color.Blue);
                
            }

            for (int i = 80; i<=83; i++)
            {
                this.squares[i].SetHouse(true);
                this.squares[i].SetColor(Color.Red);
            }

            for (int i = 84; i<= 87; i++)
            {
                this.squares[i].SetHouse(true);
                this.squares[i].SetColor(Color.Yellow);
            }

            for (int i = 88; i<= 91; i++)
            {
                this.squares[i].SetHouse(true);
                this.squares[i].SetColor(Color.Green);
            }

            this.squares[57].SetColor(Color.Blue);
            this.squares[57].SetGoal(true);



            this.squares[63].SetColor(Color.Red);
            this.squares[63].SetGoal(true);



            this.squares[69].SetColor(Color.Yellow);
            this.squares[69].SetGoal(true);



            this.squares[75].SetColor(Color.Green);
            this.squares[75].SetGoal(true);



            this.squares[3].SetColor(Color.Blue);



            this.squares[16].SetColor(Color.Red);



            this.squares[29].SetColor(Color.Green);



            this.squares[42].SetColor(Color.Yellow);



            for (int i = 52; i <= 56; i++)
                this.squares[i].SetColor(Color.Blue);



            for (int i = 58; i <= 62; i++)
                this.squares[i].SetColor(Color.Red);



            for (int i = 64; i <= 68; i++)
                this.squares[i].SetColor(Color.Yellow);



            for (int i = 70; i <= 74; i++)
                this.squares[i].SetColor(Color.Green);



        }

        private void CreatePieces(List<Player> players)
        {
            this.pieces.Clear();

            foreach (Player player in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    Piece piece = new Piece(player.color, i + 1);
                    this.pieces.Add(piece);

                    if (player.color == Color.Blue)
                    {
                        this.squares[76 + i].AddPiece(piece);
                        piece.Square = this.squares[76 + i];
                    }
                    else if (player.color == Color.Yellow)
                    {
                        this.squares[84 + i].AddPiece(piece);
                        piece.Square = this.squares[76 + i];
                    }
                    else if (player.color == Color.Red)
                    {
                        this.squares[80 + i].AddPiece(piece);
                        piece.Square = this.squares[80 + i];
                    }
                    else if (player.color == Color.Green)
                    {
                        this.squares[88 + i].AddPiece(piece);
                        piece.Square = this.squares[88 + i];
                    }
                }
            }
        }

    }
}