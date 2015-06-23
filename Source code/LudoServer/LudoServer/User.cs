using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LudoServer
{
    [DataContractFormat]
    class User
    {
        [DataMember]
        public string name;

        public ILobbyCallback lobbycallback;

        public User(string name)
        {
            this.name = name;

        }


    }
}
