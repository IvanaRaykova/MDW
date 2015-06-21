using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Drawing;

namespace LudoServer
{
    [DataContract]
    public class Player
    {
        [DataMember]
         public string name;

        [DataMember]
        public Color color;

        public IGameCallBack lobbycallback; 
        
            public Player(string name, Color color)
            {
                this.name = name;
                this.color = color;
            }

    }
}