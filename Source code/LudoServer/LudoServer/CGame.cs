using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LudoService
{
    public enum Action
    {
        Nothing = 0,
        RollDie = 1,
        MovePiece = 2,
        EndTurn = 3
    }

    public class CGame : IGame
    {
        private static readonly List<IGameCallBack> GameSubscribers = new List<IGameCallBack>();
        private List<Player> players;
        
        private int playersturn;
        public Board board { get; set; }
        public Player playersTurn = null;
        
        public Die die { get; set; }
        public Action nextAction = Action.Nothing;
        public int nrofactions;



        public void NewGame(List<Player> Players)
        {
            board = new Board(players);
            this.players = Players;
            playersTurn = this.players[0];
            playersturn = 0;
            die = new Die();
            this.board = new Board(players);
            
            nrofactions =0;
        }

        public void EndTurn()
        {
            nrofactions = 0;
            nextAction = Action.EndTurn;
            playersTurn.isturn = false;

        }

        public int RollDie()
        {
            if (die.DieValue == 6)
            {
                nrofactions++;
            }
           
            return die.DieValue;
            

          
        }
        public Boolean canMovePiece(Player player, Die die)
        {
            if (die.DieValue != 6 && player.nr_pieceout == 0)
            {
                return false;
            }
            if (die.DieValue == 6 && player.nr_pieceout <4)
            {
                return true;
            }
            if (player.color == Color.Red)
            {
                int pieceingoalpath = 0;
                for (int i = 58; i <64; i ++)
                { 
                    if(this.board.Squares[i].Pieces.Count>0)
                    {
                        pieceingoalpath = pieceingoalpath + this.board.Squares[i].Pieces.Count;
                        if (i+die.DieValue<=63)
                        {
                            return true;
                        }
                    }
                }

                if(player.nr_pieceout - pieceingoalpath>0)
                {
                    return true;
                }

            }

            else if(player.color == Color.Green)
            {
                  int pieceingoalpath = 0;
                for (int i = 70; i <76; i ++)
                { 
                    if(this.board.Squares[i].Pieces.Count>0)
                    {
                        pieceingoalpath = pieceingoalpath + this.board.Squares[i].Pieces.Count;
                        if (i+die.DieValue<=75)
                        {
                            return true;
                        }
                    }
                }

                if(player.nr_pieceout - pieceingoalpath>0)
                {
                    return true;
                }

            }
            else if(player.color == Color.Blue)
            {
                  int pieceingoalpath = 0;
                for (int i = 52; i <58; i ++)
                { 
                    if(this.board.Squares[i].Pieces.Count>0)
                    {
                        pieceingoalpath = pieceingoalpath + this.board.Squares[i].Pieces.Count;
                        if (i+die.DieValue<=57)
                        {
                            return true;
                        }
                    }
                }

                if(player.nr_pieceout - pieceingoalpath>0)
                {
                    return true;
                }

            }
            else if(player.color == Color.Yellow)
            {  
                int pieceingoalpath = 0;
                for (int i = 64; i <70; i ++)
                { 
                    if(this.board.Squares[i].Pieces.Count>0)
                    {
                        pieceingoalpath = pieceingoalpath + this.board.Squares[i].Pieces.Count;
                        if (i+die.DieValue<=69)
                        {
                            return true;
                        }
                    }
                }

                if(player.nr_pieceout - pieceingoalpath>0)
                {
                    return true;
                }

            }
            return false;
        }

        public int homeindex(Color PieceColor)
        {
            if (PieceColor == Color.Green)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[88 + i].Pieces.Count == 0)
                    {
                        return i + 88;

                    }

                }

            }

            else if (PieceColor == Color.Blue)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[76 + i].Pieces.Count == 0)
                    {
                        return i + 76;

                    }

                }

            }

            else if (PieceColor == Color.Yellow)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[84 + i].Pieces.Count == 0)
                    {
                        return i + 84;

                    }

                }

            }

            else if (PieceColor == Color.Red)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[80 + i].Pieces.Count == 0)
                    {
                        return i + 80;

                    }

                }

            }

            return -1;
        }
       

        public void UpdatePlayer(Player Player)
        {
            int nrpiecesout = 0;
            if (Player.color == Color.Green)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[88 + i].Pieces.Count == 0)
                    {
                        nrpiecesout++;

                    }


                }

                Player.nr_pieceout = nrpiecesout;

                if (this.board.Squares[75].Pieces.Count == 4)
                {
                    Player.Haswon = true;
                }
                else
                {
                    Player.nr_piecewon = this.board.Squares[75].Pieces.Count;
                }
            }

            else if (Player.color == Color.Blue)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[76 + i].Pieces.Count == 0)
                    {
                        nrpiecesout++;

                    }


                }

                Player.nr_pieceout = nrpiecesout;

                if (this.board.Squares[57].Pieces.Count == 4)
                {
                    Player.Haswon = true;
                }
                else
                {
                    Player.nr_piecewon = this.board.Squares[57].Pieces.Count;
                }
            }

            else if (Player.color == Color.Yellow)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[84 + i].Pieces.Count == 0)
                    {
                        nrpiecesout++;

                    }


                }

                Player.nr_pieceout = nrpiecesout;

                if (this.board.Squares[69].Pieces.Count == 4)
                {
                    Player.Haswon = true;
                }
                else
                {
                    Player.nr_piecewon = this.board.Squares[69].Pieces.Count;
                }

            }

            else if (Player.color == Color.Red)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (this.board.Squares[80 + i].Pieces.Count == 0)
                    {
                        nrpiecesout++;

                    }


                }

                Player.nr_pieceout = nrpiecesout;

                if (this.board.Squares[63].Pieces.Count == 4)
                {
                    Player.Haswon = true;
                }
                else
                {
                    Player.nr_pieceout = this.board.Squares[63].Pieces.Count;
                }
            }







        }

        public void MovePiece(Color PieceColor, int CurrentPosition)
        {
            
            /*if (nextAction == Action.MovePiece && playersTurn.color == PieceColor && nrofactions >0 )
            { 
                if(this.board.Squares[CurrentPosition].Pieces.Count>0)
                {
                    if (this.board.Squares[CurrentPosition].Pieces[0].Color == PieceColor)
                    {
                        
                        if (canMovePiece(playersTurn,die))
                        {   int nextindex = die.DieValue;
                            if(this.board.Squares.[nextindex].Pieces[0].Color != PieceColor)
                            {
                                int index = homeindex(this.board.Squares[nextindex].Pieces[0].Color);
                                this.board.MovePiece(this.board.Squares[nextindex].Pieces[0], this.board.Squares.[nextindex]);
                                this.board.MovePiece(this.board.Squares[CurrentPosition].Pieces[0],this.board.Squares[nextindex]);

                            if(!lastRollWasSix)
                            {
                                NextPlayersTurn();
                            }
                                nextAction= Action.RollDie;

                                foreach (Player player in this.players)
                                {
                                    UpdatePlayer(player);
                                }
                            }
                                
                            else
                                {
                                    this.board.MovePiece(this.board.Squares[CurrentPosition].Pieces[0], this.board.Squares[nextindex]);

                                if(!lastRollWasSix)
                                {
                                    NextPlayersTurn();
                                }

                                nextAction = Action.RollDie;
                                foreach (Player player in this.players)
                                {
                                    UpdatePlayer(player);
                                }
                            }
                        }
                    }
                }
              
        } */
            nrofactions--;
        
        }



        public void AddMessage(string playername, string message)
        {
            GameSubscribers.ForEach(delegate(IGameCallBack gamecallback)
            {
                if (((ICommunicationObject)gamecallback).State == CommunicationState.Opened)
                {
                    gamecallback.onMessageAdded(DateTime.Now, playername, message);
                }
                else
                {
                    GameSubscribers.Remove(gamecallback);
                }
            });
        }

        public bool Subscribe()
        {
            try
            {
                IGameCallBack gamecallback = OperationContext.Current.GetCallbackChannel<IGameCallBack>();
                if (!GameSubscribers.Contains(gamecallback))

                    GameSubscribers.Add(gamecallback);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool Unsubscribe()
        {
            try
            {
                IGameCallBack gamecallback = OperationContext.Current.GetCallbackChannel<IGameCallBack>();
                if (!GameSubscribers.Contains(gamecallback))
                    GameSubscribers.Remove(gamecallback);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void JoinGame()
        {


        }

        private void NextPlayersTurn()
        {
            if (playersturn < this.players.Count - 1)
            {
                playersturn++;
                playersTurn = this.players[playersturn];
            }

            else if (playersturn == this.players.Count - 1)
            {
                playersturn = 0;
                playersTurn = this.players[playersturn];
            }

            if (playersTurn.Haswon)
            {
                NextPlayersTurn();
            }

        }
    }
}