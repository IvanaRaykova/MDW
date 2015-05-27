using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LudoServer
{
    [DataContract]
    public class Game
    {
        [DataMember]
        List<Player> players;

        public Game()
        {
            players = new List<Player>();
        }
    }
}