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
                private string username;
                private string password;
                [DataMember]
                private string firstname;
                [DataMember]
                private int nrofWins;
            
            public Player(string username, string password, string firstname)
            { 
                this.username = username;
               this.password = password;
                this.firstname = firstname;
                this.nrofWins = 0;
            }

    }
}