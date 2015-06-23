using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;

namespace LudoService
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string name { get; set; }
        

        [DataMember]
        public Color color;
        
        [DataMember]
        public bool Haswon { get; set; }

        public int nr_piecesin { get; set; }
        public int nr_pieceout { get; set; }
        public int nr_piecewon { get; set; }
        public bool isturn;

        public IGameCallBack gamecallback;

        public Player(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public void SetWon(bool haswon)
        {
            this.Haswon = haswon;
        }
        public void setColor(Color color)
        {
            this.color = color;
        }
        public void SetTurn()
        {
            if(this.isturn == true)
            {
                this.isturn = false;
            }
                else
            {
               this.isturn = true;
                }
            }
        }

    }
