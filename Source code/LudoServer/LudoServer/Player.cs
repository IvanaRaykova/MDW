using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LudoServer
{
    [DataContract]
    public class Player
    {
        [DataMember]
         public string name;

        public ILobbyCallBack lobbycallback; 
         
         [DataMember]
         private int nrofWins;
            
            public Player(string name)
            {
                this.name = name;
            }

    }
}